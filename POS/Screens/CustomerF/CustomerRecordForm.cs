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
    public partial class CustomerRecordForm : MetroFramework.Forms.MetroForm
    {
        public CustomerRecordForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerRecordForm_Load(object sender, EventArgs e)
        {
            LoadAllCustomerIntoDataGridView();
        }

        private void LoadAllCustomerIntoDataGridView()
        {
            if (gridCustomerRecords.Columns.Contains("Delete"))
            {
                gridCustomerRecords.Columns.Remove("Delete");

            }
            if (gridCustomerRecords.Columns.Contains("Edit"))
            {
                gridCustomerRecords.Columns.Remove("Edit");

            }

            gridCustomerRecords.DataSource = GetData();
            gridCustomerRecords.Columns[0].Visible = false;
            DataGridViewButtonColumn dv = new DataGridViewButtonColumn();
            dv.HeaderText = "Delete";
            dv.Name = "Delete";
            gridCustomerRecords.Columns.Add(dv);


            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            edit.HeaderText = "Edit";
            edit.Name = "Edit";
            gridCustomerRecords.Columns.Add(edit);
        }

        private object GetData()
        {
            DataTable productData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $"Select * from [dbo].[Customers]";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    productData.Load(reader);
                }
            }
            return productData;
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == null)
            {
                LoadAllCustomerIntoDataGridView();
            }
            else
            {

                if (gridCustomerRecords.Columns.Contains("Delete"))
                {
                    gridCustomerRecords.Columns.Remove("Delete");

                }

                if (gridCustomerRecords.Columns.Contains("Edit"))
                {
                    gridCustomerRecords.Columns.Remove("Edit");

                }

                gridCustomerRecords.DataSource = GetDataByName();
                gridCustomerRecords.Columns[0].Visible = false;


                DataGridViewButtonColumn dv = new DataGridViewButtonColumn();
                dv.HeaderText = "Delete";
                dv.Name = "Delete";
                gridCustomerRecords.Columns.Add(dv);

                DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
                edit.HeaderText = "Edit";
                edit.Name = "Edit";
                gridCustomerRecords.Columns.Add(edit);



            }
        }

        private DataTable GetDataByName()
        {
            DataTable CustomerData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $"Select* from[dbo].[Customers] where [Name] LIKE +'%'+'{txtCustomerName.Text}'+'%'";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    CustomerData.Load(reader);
                }
            }
            return CustomerData;
        }

        private void gridCustomerRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Delete
            if (gridCustomerRecords.CurrentCell.ColumnIndex == 4)
            {
                int _id = (int)gridCustomerRecords.SelectedRows[0].Cells[0].Value;

                if (_id > 0)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = $"DELETE FROM [dbo].[Customers] WHERE [CustomerId] = {_id}";

                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();


                        MessageBox.Show($"Customer Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadAllCustomerIntoDataGridView();
                    }
                }


            }
            //Edit
            if (gridCustomerRecords.CurrentCell.ColumnIndex == 5)
            {
                int id = (int)gridCustomerRecords.SelectedRows[0].Cells[0].Value;
                if(id > 0)
                {
                    NewCustomerForm ncf = new NewCustomerForm();
                    ncf.IsUpdate = true;
                    ncf.CustomerId = id;
                    ncf.ShowDialog();
                    LoadAllCustomerIntoDataGridView();
                }
                
            }






            
        }

        
    }
}
