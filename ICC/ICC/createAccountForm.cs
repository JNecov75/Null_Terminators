using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICC
{
    public partial class createAccountForm : Form
    {
        private SQLiteConnection myDatabaseConnection; // creating a database connection object

        public createAccountForm()
        {
            InitializeComponent();
        }

        private void createAccountForm_Load(object sender, EventArgs e)
        {
            myDatabaseConnection = new SQLiteConnection("Data Source=icc_db.s3db;Version=3"); // identify connection string to database
            myDatabaseConnection.Open(); // open connection to database
        }

        bool checkText(string text)   // checks the validity of text
        {
            text.Trim();
            for (int i = 0; i < text.Length; i++)
            {
                if ((text[i] <= 'A' || text[i] >= 'Z') && (text[i] <= 'a' || text[i] >= 'z'))
                {
                    return true;
                }
                else
                {
                    if (text[i] == ' ')
                    {
                        return false;
                    }
                   
                }
            }
            return false;
        }


        private void createAccountButton_Click(object sender, EventArgs e)
        {
            string fname, lname, email, sex, username, password;
            int age, empType;
            string sqlCommand, errorDetails = "";

            //if (checkText(fnameTb.Text))
           // {
           //     MessageBox.Show("Success! All credentials entered are valid.");
           // }
           // else
           if(!checkText(fnameTb.Text))
            {
                errorDetails += "First name has not met the requirements.\n";
            }
            if (string.IsNullOrWhiteSpace(fnameTb.Text))
            {
                errorDetails += "Please enter a valid first name\n";
            }
            if (string.IsNullOrWhiteSpace(lnameTb.Text))
            {
                errorDetails +="Please enter a valid last name\n";
            }
            if (string.IsNullOrWhiteSpace(emailTb.Text))
            {
                errorDetails += "Please enter a valid email address\n";
            }
            if (string.IsNullOrWhiteSpace(usernameTb.Text))
            {
                errorDetails += "Please enter a valid user name\n";
            }
            if (string.IsNullOrWhiteSpace(passwordTb.Text))
            {
                errorDetails += "Please enter a valid password\n";
            }

            if (errorDetails != "")
            {
                MessageBox.Show("Error! One or more entries have invalid values.\nDetails:\n" + errorDetails);
            }
            else
            {
                
                fname = fnameTb.Text;
                lname = lnameTb.Text;
                email = emailTb.Text;
                username = usernameTb.Text;
                password = passwordTb.Text;
                age = int.Parse(ageTb.Text);
                sex = "";
                empType = 1;

                if (radioEmployeeTypeDriver.Checked)
                    empType = 1;
                else if (radioEmployeeTypeManager.Checked)
                    empType = 2;
                else if (radioEmployeeTypeOwner.Checked)
                    empType = 3;

                if (radioSexMale.Checked)
                    sex = "m";
                else if (radioSexFemale.Checked)
                    sex = "f";

                sqlCommand =
                    "INSERT INTO users (userId, firstName, lastName, email, age, sex, employeeType, password) VALUES ('" +
                    username + "', '" + fname + "', '" +
                    lname + "', '" + email + "', " + age + ", '" + sex + "', " + empType + ", '" + password + "')";
                try
                {
                    SQLiteCommand command = new SQLiteCommand(sqlCommand, myDatabaseConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("The account has successfully been created.");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                Close();
            }
        }

        private void radioEmployeeTypeDriver_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
