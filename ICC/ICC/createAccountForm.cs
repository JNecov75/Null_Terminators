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


        private void createAccountButton_Click(object sender, EventArgs e)
        {
            string fname, lname, email, sex, username, password;
            int age, empType;
            string sqlCommand;

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
            else
                if (radioEmployeeTypeManager.Checked)
                empType = 2;
            else
                if (radioEmployeeTypeOwner.Checked)
                empType = 3;

            if (radioSexMale.Checked)
                sex = "m";
            else
                if (radioSexFemale.Checked)
                sex = "f";

            sqlCommand =
                "INSERT INTO users (userId, firstName, lastName, email, age, sex, employeeType, password) VALUES ('" +
                username + "', '" + fname + "', '" +
                lname + "', '" + email + "', " + age + ", '" + sex + "', " + empType + ", '" + password + "')";

            SQLiteCommand command = new SQLiteCommand(sqlCommand, myDatabaseConnection);
            command.ExecuteNonQuery();

            Close();
        }

        private void radioEmployeeTypeDriver_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
