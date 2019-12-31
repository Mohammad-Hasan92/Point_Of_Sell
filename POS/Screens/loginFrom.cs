using POS.General;
using POS.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class loginFrom : MetroFramework.Forms.MetroForm
    {
        

        public loginFrom()
        {
            InitializeComponent();
        }

       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                //string conString = ApplicationSetting.ConnectionString();
                //MessageBox.Show(conString);

                using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "usp_Login_VerifyLoginDetails";

                    sqlCmd.Parameters.Add(new SqlParameter("@userName", txtUserName.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@password", txtPassword.Text));


                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        this.Hide();
                        DeshBoardform df = new DeshBoardform();
                        df.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorect Password Or User Name!!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    }
                }

            }

           

        }

        private bool IsValid()
        {
            if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show(@"User Name Is Required","Form Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show(@"Password Is Required", "Form Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = null;
            txtPassword.Text = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginFrom_Load(object sender, EventArgs e)
        {

        }
    }
}
