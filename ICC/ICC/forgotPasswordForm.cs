using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICC
{
    public partial class forgotPasswordForm : Form
    {
        private SQLiteConnection myDatabaseConnection; // creating a database connection object

        public forgotPasswordForm()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string username, password, email, sqlCommand;

            email = emailTb.Text;

            sqlCommand = "SELECT userId, password FROM users WHERE email = '" + email + "'";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, myDatabaseConnection);
            DataSet validUserTable = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            dataAdapter.Fill(validUserTable);
            username = validUserTable.Tables[0].Rows[0][0].ToString();
            password = validUserTable.Tables[0].Rows[0][1].ToString();


            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(
                  "375icc@gmail.com", "icecreamforall");
                MailMessage msg = new MailMessage();
                msg.To.Add(email);
                msg.From = new MailAddress("375icc@gmail.com");
                msg.Subject = "ICC - Account Credentials";
                msg.Body = "Hello, we noticed you forgot your credentials. Here is a quick reminder:\n User name: " +
                           username + "\nPassword: " + password + "\nWe wish " +
                           "you a great day!!";
                client.Send(msg);
                MessageBox.Show("Successfully Sent Message.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Close();
        }
    

        private void forgotPasswordForm_Load(object sender, EventArgs e)
        {
            myDatabaseConnection = new SQLiteConnection("Data Source=icc_db.s3db;Version=3"); // identify connection string to database
            myDatabaseConnection.Open(); // open connection to database
        }
    }
}