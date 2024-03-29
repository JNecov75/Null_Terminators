﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICC
{
    public partial class importFilesForm : Form
    {
        public const int seqStart = 0;
        private int nextExpectedSequence;
        private SQLiteConnection myDatabaseConnection; // creating a database connection object

        private OpenFileDialog theDialog;

        public importFilesForm()
        {
            InitializeComponent();
        }

        private void openPathButton_Click(object sender, EventArgs e)
        {
            theDialog = new OpenFileDialog();
            theDialog.Title = "Open batch file";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"W:\";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileNameTb.Text = theDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        bool dateIsValid(string date)
        {
            int year;
            int month;
            int day;
            string[] dateSplit;
            char[] dashDelim = {'-'};

            dateSplit = date.Split(dashDelim, StringSplitOptions.RemoveEmptyEntries);
            year = int.Parse(dateSplit[0]);
            month = int.Parse(dateSplit[1]);
            day = int.Parse(dateSplit[2]);

            if (month > 12 || month < 1)
                return false;
            if (day > 31 || day < 1)
                return false;
            return true;

        }

        private void importButton_Click(object sender, EventArgs e)
        {
            List<string> entries;
            string[] lastLineSplit, firstLineSplit, lineSplit;
            string dateFromFile;
            int[] dateInts;
            StreamReader myStream;
            string firstLine;
            int linesOfDataFromFile;
            char[] tabDelim= {'\t'};
            char[] spacedelim= {' '};
            string date;
            string line;
            string sqlCommand;
            //some of these werent used,


            if (citiesFileRadio.Checked)
            {
                //test file name here; is the naming schema correct?

                
                    try
                    {
                        var lLine = File.ReadLines(theDialog.FileName).Last(); //this will go to the last line and store it in a string. var is basically a type determined by a functions return type. here it is string
                        lastLineSplit = lLine.Split(spacedelim,StringSplitOptions.RemoveEmptyEntries);//this splits the first line with a space delimeter. so now you have a string array where each index has a value.
                        linesOfDataFromFile = int.Parse(lastLineSplit[1]); //tail says "T 003" so the array looks like ["T","003"] so i take the string "003" and parse the int out of it
                        var linecount = File.ReadLines(theDialog.FileName).Count();//this calculates the actual lines in the file and returns an int. var here is an int.

                        myStream = File.OpenText(theDialog.FileName);
                        firstLine = myStream.ReadLine();
                        firstLineSplit = firstLine.Split(tabDelim, StringSplitOptions.RemoveEmptyEntries);//same as above but for line 1 and retrieving the date string
                        date = firstLineSplit[1];

                        if (linesOfDataFromFile != (linecount - 2))
                        {
                            MessageBox.Show(
                                "Error! The number of lines in the file are incorrect based on the values specified in tail!");
                        }
                        else
                        if (!dateIsValid(date))  
                        {
                            MessageBox.Show("Error! Date is not valid");
                        }
                    else
                        {
                            while (!myStream.EndOfStream)
                            {
                                line = myStream.ReadLine();
                                lineSplit = line.Split(tabDelim, StringSplitOptions.RemoveEmptyEntries);
                                if (lineSplit[0][0] != 'T')
                                {
                                    sqlCommand = "INSERT INTO route (cityLabel, city, state) VALUES ('" + lineSplit[0] +
                                                 "','" + lineSplit[1] + "','" + lineSplit[2] + "')";
                                    try
                                    {
                                        SQLiteCommand command = new SQLiteCommand(sqlCommand, myDatabaseConnection);
                                        command.ExecuteNonQuery();
                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message);
                                    }
                                }
                            }
                            myStream.Close();
                            MessageBox.Show("Success! File data has been transferred into the database.");
                        }                      
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            
        }

        private void importFilesForm_Load(object sender, EventArgs e)
        {
            myDatabaseConnection = new SQLiteConnection("Data Source=icc_db.s3db;Version=3"); // identify connection string to database
            myDatabaseConnection.Open(); // open connection to database
        }
    }
}
