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
            if (!File.Exists("icc_db.s3db"))
            {
                myDatabaseConnection = new SQLiteConnection("Data Source=icc_db.s3db;Version=3"); // identify connection string to database
                myDatabaseConnection.Open(); // open connection to database

                sqlQuery = "CREATE TABLE users (userId VARCHAR(10) PRIMARY KEY, firstName VARCHAR(30), lastName VARCHAR(30), email VARCHAR(50), age INTEGER," +
                "sex VARCHAR(1), employeeType INTEGER, commission FLOAT, password VARCHAR(10))";

                SQLiteCommand command = new SQLiteCommand(sqlQuery, myDatabaseConnection);
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

        private void usernameTb_TextChanged(object sender, EventArgs e)  //when text is changed
        {
            usernameTb.ForeColor = System.Drawing.Color.Black;  //change text color to black
        }

        private void passwordTb_TextChanged(object sender, EventArgs e)  //when text is changed
        {
            usernameTb.ForeColor = System.Drawing.Color.Black;  //change text color to black
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }
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
