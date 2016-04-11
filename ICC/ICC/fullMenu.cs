using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICC
{
    public partial class fullMenu : Form
    {
        public fullMenu()
        {
            InitializeComponent();
        }

        private void fullMenu_Load(object sender, EventArgs e)
        {
            /*  dynamically size and position the listboxes and labels on bottom of tab  */
            topDriversList.Width = mainMenu.Width / 3;  //set width of control to 1/3rd of the menu tab
            topDriversList.Left = 0;  //set x location of control
            topDriversLabel.Left = topDriversList.Left;  //set the x location of the label

            topRoutesList.Width = mainMenu.Width / 3;  //set width of control to 1/3rd of the menu tab
            topRoutesList.Left = this.Width / 3;  //set x location of control
            topRoutesLabel.Left = topRoutesList.Left;  //set the x location of the label

            topItemsList.Width = mainMenu.Width / 3;  //set width of control to 1/3rd of the menu tab
            topItemsList.Left = this.Width / 3 * 2;  //set x location of control
            topItemsLabel.Left = topItemsList.Left;  //set the x location of the label
        }

        private void importFilesButton_Click(object sender, EventArgs e)
        {
            importFilesForm importFiles = new importFilesForm();
            importFiles.ShowDialog();
        }
    }
}
