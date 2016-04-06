using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
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
            myDatabaseConnection = new SQLiteConnection("Data Source=icc_db.sqlite;Version=3"); // identify connection string to database
            myDatabaseConnection.Open(); // open connection to database

            
        }
    }
}
