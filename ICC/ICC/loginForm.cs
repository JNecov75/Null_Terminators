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
        //public static string currentUser;
        private SQLiteConnection myDatabaseConnection; // creating a database connection object
        public User currentUser;

        public loginForm()
        {
            InitializeComponent();
        }

        public class User
        {
            private string userName;
            int empType;

            public User()
            {
                
            }
            public string UserName
            {
                get
                {
                    return userName;
                }
                set { userName = value; }
            }

            public int EmployeeType
            {
                get { return empType; }
                set { empType = value; }
            }
            
                     
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            string sqlQuery;
            string sqlQueryRoute, sqlQueryTruck, sqlQueryMasterInv, sqlQueryTruckInv;
            if (!File.Exists("icc_db.s3db"))
            {
                myDatabaseConnection = new SQLiteConnection("Data Source=icc_db.s3db;Version=3"); // identify connection string to database
                myDatabaseConnection.Open(); // open connection to database

                sqlQuery = "CREATE TABLE users (userId VARCHAR(10) PRIMARY KEY, firstName VARCHAR(30), lastName VARCHAR(30), email VARCHAR(50), age INTEGER," +
                "sex VARCHAR(1), employeeType INTEGER, commission FLOAT, password VARCHAR(10))";

                sqlQueryRoute =
                    "CREATE TABLE route (cityLabel VARCHAR(20) PRIMARY KEY, city VARCHAR(20), state VARCHAR(2), routeNumber INTEGER)";
                sqlQueryTruck =
                    "CREATE TABLE truck (truckId INTEGER PRIMARY KEY, cityLabel VARCHAR(20), userId VARCHAR(10), routeComplete BOOLEAN, inMaintenance BOOLEAN, FOREIGN KEY (cityLabel) REFERENCES route(cityLabel), FOREIGN KEY (userId) REFERENCES user(userID))";
                sqlQueryMasterInv =
                    "CREATE TABLE masterInventory (iceCreamId INTEGER PRIMARY KEY, name VARCHAR(30), quantity INTEGER, price FLOAT, promoPercentage FLOAT)";
                sqlQueryTruckInv =
                    "CREATE TABLE truckInventory (iceCreamId INTEGER PRIMARY KEY, truckId INTEGER, quantity INTEGER, FOREIGN KEY (truckId) REFERENCES truck (truckId))";



                SQLiteCommand command = new SQLiteCommand(sqlQuery, myDatabaseConnection);
                command.ExecuteNonQuery();
                command.CommandText = sqlQueryRoute;
                command.ExecuteNonQuery();
                command.CommandText = sqlQueryTruck;
                command.ExecuteNonQuery();
                command.CommandText = sqlQueryMasterInv;
                command.ExecuteNonQuery();
                command.CommandText = sqlQueryTruckInv;
                command.ExecuteNonQuery();
                myDatabaseConnection.Close();

            }         
            myDatabaseConnection = new SQLiteConnection("Data Source=icc_db.s3db;Version=3"); // identify connection string to database
            myDatabaseConnection.Open(); // open connection to database
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            createAccountForm createAccountForm = new createAccountForm();
            createAccountForm.ShowDialog();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username, password;
            string sqlCommand;
            int employeeType;
            //string sample1, sample2;

            username = usernameTb.Text;
            password = passwordTb.Text;
            sqlCommand = "SELECT userId, password, employeeType FROM users WHERE userId = '" + username + "'";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, myDatabaseConnection);
            DataSet validUserTable = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            dataAdapter.Fill(validUserTable);
            //sample1 = validUserTable.Tables[0].Rows[0][0].ToString();
            //sample2 = validUserTable.Tables[0].Rows[0][1].ToString();

            if(validUserTable.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Login failed! The user does not exist.");
            }
            else
            if (validUserTable.Tables[0].Rows[0][0].ToString() == username && validUserTable.Tables[0].Rows[0][1].ToString() == password)
            {
                MessageBox.Show("Login success! Welcome " + username);
                currentUser = new User();
                currentUser.UserName = username;
                employeeType = int.Parse(validUserTable.Tables[0].Rows[0][2].ToString());
                currentUser.EmployeeType = employeeType;
                
                this.Hide();
                fullMenu fullMenuForm = new fullMenu();
                fullMenuForm.ShowDialog();
            }
            else
            if (validUserTable.Tables[0].Rows[0][0].ToString() == username && validUserTable.Tables[0].Rows[0][1].ToString() != password)
            {
                MessageBox.Show("Login failed! Password is incorrect!");
            }
        }


        //this code isn't working, I want to select all text when the textbox is tabbed into
        private void usernameTb_Enter(object sender, EventArgs e) 
        {
            MessageBox.Show("username got keyboard focus");
            usernameTb.SelectionStart = 0;
            usernameTb.SelectionLength = usernameTb.Text.Length;
        }

        private void usernameTb_TextChanged(object sender, EventArgs e)  //when text is changed
        {
            usernameTb.ForeColor = System.Drawing.Color.Black;  //change text color to black
        }

        private void passwordTb_TextChanged_1(object sender, EventArgs e)  //when text is changed
        {
            passwordTb.ForeColor = System.Drawing.Color.Black;  //change text color to black
            passwordTb.PasswordChar = '*';
        }


        //label2_click needs to be removed
        private void label2_Click(object sender, EventArgs e)
        {

        }

        //label3_click needs to be removed
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void forgotPasswordButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgotPasswordForm fpForm = new forgotPasswordForm();
            fpForm.ShowDialog();
        }
    }
}
