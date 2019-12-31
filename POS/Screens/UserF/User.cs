using POS.General;
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

namespace POS.Screens.UserF
{
    public partial class User : MetroFramework.Forms.MetroForm
    {
        public User()
        {
            InitializeComponent();
        }
        private bool IsUpdate { get; set; }
        private string UserName { get; set; }

        private void User_Load(object sender, EventArgs e)
        {
            LoadAllUserIntoDataGridView();
        }

        private void LoadAllUserIntoDataGridView()
        {
            if (gridUser.Columns.Contains("Delete"))
            {
                gridUser.Columns.Remove("Delete");
            }
            if (gridUser.Columns.Contains("Edit"))
            {
                gridUser.Columns.Remove("Edit");
            }

            gridUser.DataSource = GetData();
            //gridUser.Columns[0].Visible = false;
            DataGridViewButtonColumn dv = new DataGridViewButtonColumn();
            dv.HeaderText = "Delete";
            dv.Name = "Delete";
            gridUser.Columns.Add(dv);


            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            edit.HeaderText = "Edit";
            edit.Name = "Edit";
            gridUser.Columns.Add(edit);
        }

        private object GetData()
        {
            DataTable User = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $"Select * from [dbo].[LoginUser]";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    User.Load(reader);
                }
            }
            return User;
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (IsUpdate)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = $"UPDATE [dbo].[LoginUser] SET UserName ='{txtUserName.Text}',[Password] = '{txtRetypePassword.Text}' WHERE UserName ='{this.UserName}'";
                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show($"User Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = $"INSERT INTO [dbo].[LoginUser] ([UserName],[Password]) VALUES('{txtUserName.Text}','{txtRetypePassword.Text}')";
                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show($"User Add Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clearForNewUser();
                LoadAllUserIntoDataGridView();

            }
        }

        private void clearForNewUser()
        {
             
            txtUserName.Clear();
            txtPassword.Clear();
            txtRetypePassword.Clear();
            this.IsUpdate = false;
            this.UserName = null;

        
        }

        private bool IsValid()
        {
          
            if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show("User Name Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Password Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }
            if (txtRetypePassword.Text == string.Empty)
            {
                MessageBox.Show("Retype Password Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRetypePassword.Focus();
                return false;
            }
            if (txtPassword.Text != txtRetypePassword.Text)
            {
                MessageBox.Show("Retype Password Is UnMached", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRetypePassword.Focus();
                return false;
            }

            return true;
        
        }

        private void gridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Delete
            if (gridUser.CurrentCell.ColumnIndex == 2)
            {
                string name = (string)gridUser.SelectedRows[0].Cells[0].Value;

                
                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = $"DELETE FROM [dbo].[LoginUser] WHERE [UserName] = '{name}'";

                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();


                        MessageBox.Show($"User Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAllUserIntoDataGridView();

                }


            }
            //Edit
            if (gridUser.CurrentCell.ColumnIndex == 3)
            {
                string name = (string)gridUser.SelectedRows[0].Cells[0].Value;
               
                    
                    this.IsUpdate = true;
                    this.UserName = name;
                    txtUserName.Text = (string)gridUser.SelectedRows[0].Cells[0].Value;
                txtPassword.Text = (string)gridUser.SelectedRows[0].Cells[1].Value;

                LoadAllUserIntoDataGridView();

            }
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (txtSearch.Text == null)
            {
                LoadAllUserIntoDataGridView();
            }
            else
            {

                if (gridUser.Columns.Contains("Delete"))
                {
                    gridUser.Columns.Remove("Delete");
                }

                if (gridUser.Columns.Contains("Edit"))
                {
                    gridUser.Columns.Remove("Edit");

                }

                gridUser.DataSource = GetDataByName();
                //gridUser.Columns[0].Visible = false;


                DataGridViewButtonColumn dv = new DataGridViewButtonColumn();
                dv.HeaderText = "Delete";
                dv.Name = "Delete";
                gridUser.Columns.Add(dv);

                DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
                edit.HeaderText = "Edit";
                edit.Name = "Edit";
                gridUser.Columns.Add(edit);



            }
        }

        private DataTable GetDataByName()
        {
            DataTable UserData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $"Select* from [POS].[dbo].[LoginUser] where [UserName] LIKE +'%'+'{txtSearch.Text}'+'%'";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    UserData.Load(reader);
                }
            }
            return UserData;
        }

        
    }
}
