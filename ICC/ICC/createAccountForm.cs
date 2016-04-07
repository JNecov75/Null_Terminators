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
            
        }
    }
}
