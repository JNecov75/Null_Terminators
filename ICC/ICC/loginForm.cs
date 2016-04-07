using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ICC
{
    public partial class loginForm : Form
    {
        private SQLiteConnection myDatabaseConnection; // creating a database connection object

        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            string sqlQuery;
            if (!File.Exists("icc_db.s3db"))
            {
                myDatabaseConnection = new SQLiteConnection("Data Source=icc_db.s3db;Version=3"); // identify connection string to database
                myDatabaseConnection.Open(); // open connection to database

                sqlQuery = "CREATE TABLE users (userId VARCHAR(10) PRIMARY KEY, firstName VARCHAR(30), lastName VARCHAR(30), email VARCHAR(50), age INTEGER," +
                "sex VARCHAR(1), employeeType INTEGER, commission FLOAT, password VARCHAR(10))";

                SQLiteCommand command = new SQLiteCommand(sqlQuery, myDatabaseConnection);
                command.ExecuteNonQuery();
              //  myDatabaseConnection.Close();

            }         
            //myDatabaseConnection = new SQLiteConnection("Data Source=icc_db.sqlite;Version=3"); // identify connection string to database
            //myDatabaseConnection.Open(); // open connection to database
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            createAccountForm createAccountForm = new createAccountForm();
            createAccountForm.ShowDialog();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

        }

        private void usernameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
