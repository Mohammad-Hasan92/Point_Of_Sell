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

namespace POS.Screens.CustomerF
{
    public partial class NewCustomerForm : MetroFramework.Forms.MetroForm
    {
        public NewCustomerForm()
        {
            InitializeComponent();
        }
        public bool IsUpdate { get; set; }
        public int CustomerId { get; set; }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        sqlCmd.CommandText = $"UPDATE [dbo].[Customers] SET Name ='{txtCustomerName.Text}',Mobile ={txtMobileNo.Text},Address ='{txtAddress.Text}' WHERE CustomerId ={this.CustomerId} ";
                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show($"Customer Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = $"INSERT INTO [dbo].[Customers] ([Name],[Mobile],[Address]) VALUES('{txtCustomerName.Text}',{txtMobileNo.Text},'{txtAddress.Text}')";
                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();


                        MessageBox.Show($"Customer Add Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clearForNewCustomer();
                
            }
        }

        private void clearForNewCustomer()
        {
            txtCustomerName.Clear();
            txtMobileNo.Clear();
            txtAddress.Clear();
            txtCustomerName.Focus();
            this.IsUpdate = false;
            this.CustomerId = 0;
        }

        private bool IsValid()
        {
           if(txtCustomerName.Text == string.Empty)
            {
                MessageBox.Show("Customer Name Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus();
                return false;

            }
            if (txtMobileNo.Text == string.Empty)
            {
                MessageBox.Show("Mobile No Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Focus();
                return false;
            }
            return true;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtCustomerName.Clear();
            txtMobileNo.Clear();
            txtAddress.Clear();
            txtCustomerName.Focus();
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            CustomerRecordForm crf = new CustomerRecordForm();
            crf.Show();
        }

        private void NewCustomerForm_Load(object sender, EventArgs e)
        {
            if (this.IsUpdate)
            {
                LoadDataAndMapIntoControls();
            }
        }

        private void LoadDataAndMapIntoControls()
        {
            DataTable dtRecords = GetCustomerData();
            DataRow row;
            row = dtRecords.Rows[0];

            txtCustomerName.Text = row["Name"].ToString();
            txtMobileNo.Text = row["Mobile"].ToString();
            txtAddress.Text = row["Address"].ToString();
        }

        private DataTable GetCustomerData()
        {
            DataTable dr = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $"Select * from[dbo].[Customers] where [CustomerId] ={this.CustomerId}";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    dr.Load(reader);
                }
            }

            return dr;
        }
    }
}
