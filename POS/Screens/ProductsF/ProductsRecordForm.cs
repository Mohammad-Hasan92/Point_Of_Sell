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

namespace POS.Screens.ProductsF
{
    public partial class ProductsRecordForm : MetroFramework.Forms.MetroForm
    {
        public ProductsRecordForm()
        {
            InitializeComponent();
        }

        private void ProductsRecordForm_Load(object sender, EventArgs e)
        {
            LoadAllProductIntoDataGridView();
            
        }

        private void LoadAllProductIntoDataGridView()
        {
            if (gridProductRecords.Columns.Contains("Delete"))
            {
                gridProductRecords.Columns.Remove("Delete");

            }

            gridProductRecords.DataSource = GetData();
            gridProductRecords.Columns[0].Visible = false;
            DataGridViewButtonColumn dv = new DataGridViewButtonColumn();
            dv.HeaderText = "Delete";
            dv.Name = "Delete";
            gridProductRecords.Columns.Add(dv);
        }

        private DataTable GetData()
        {
            DataTable productData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "usp_Products_LoadAllProductInDataGridView";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    productData.Load(reader);
                }
            }
            return productData;
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (txtProductName.Text == null)
            {
                LoadAllProductIntoDataGridView();
            }
            else
            {

                if (gridProductRecords.Columns.Contains("Delete"))
                {
                    gridProductRecords.Columns.Remove("Delete");

                }

                gridProductRecords.DataSource = GetDataByName();
                gridProductRecords.Columns[0].Visible = false;


                DataGridViewButtonColumn dv = new DataGridViewButtonColumn();
                dv.HeaderText = "Delete";
                dv.Name = "Delete";
                gridProductRecords.Columns.Add(dv);



            }
        }

        private DataTable GetDataByName()
        {
            DataTable productData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "usp_Products_LoadAllProductsbyProductName";
                    sqlCmd.Parameters.Add(new SqlParameter("@Name", txtProductName.Text));
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    productData.Load(reader);
                }
            }
            return productData;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridProductRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridProductRecords.CurrentCell.ColumnIndex == 7)
            {
                int _id = (int)gridProductRecords.SelectedRows[0].Cells[0].Value;

                if(_id > 0)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandText = "usp_Products_DeleteProductAndSizes";

                        sqlCmd.Parameters.Add(new SqlParameter("@ProductID", _id));
                        

                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();


                        MessageBox.Show($"Proudect Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadAllProductIntoDataGridView();
                    }
                }






            }
        }

       
    }
}
