using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class loginFrom : Form
    {

        public const string userName = "admin";
        private const string password = "12345";
        public loginFrom()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != userName)
            {
                MessageBox.Show(@"Invalid user id");
                return;
            }
            else if (txtPassword.Text != password)
            {
                MessageBox.Show(@"Invalid password");
                return;
            }

            mainForm mainForm = new mainForm();
            mainForm.Show();

            //this.Close(); this will also close running application
            this.Hide();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = null;
            txtPassword.Text = null;
        }
    }
}
