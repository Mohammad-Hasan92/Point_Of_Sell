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

namespace POS.Screens.StockF
{
    public partial class StockForm : MetroFramework.Forms.MetroForm
    {
        public StockForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            LoadAllProductIntoStokEntryGrid();
        }

        private void LoadAllProductIntoStokEntryGrid()
        {
            gridLoadProduct.DataSource = GetData();
            gridLoadProduct.Columns[0].Visible = false;
            gridLoadProduct.Columns[1].Visible = false;
  
        }

        private object GetData()
        {
            DataTable StockEntryData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = $"usp_Load_ProductIntoStokEntryForm";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    StockEntryData.Load(reader);
                }
            }
            return StockEntryData;
        
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchProduct.Text == null)
            {
                LoadAllProductIntoStokEntryGrid();
            }
            else
            {
                gridLoadProduct.DataSource = GetDataByName();
                gridLoadProduct.Columns[0].Visible = false;
                gridLoadProduct.Columns[1].Visible = false;
            }
        }

        private DataTable GetDataByName()
        {
            DataTable StockEntryData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = $"usp_Load_ProductIntoStokEntryFormByName";
                    sqlCmd.Parameters.Add(new SqlParameter("@Name", txtSearchProduct.Text));
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    StockEntryData.Load(reader);
                }
            }
            return StockEntryData;
        }

        private void gridLoadProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                   
                    txtProductId.Text =Convert.ToString(gridLoadProduct.SelectedRows[0].Cells[0].Value);
                    txtSizeId.Text = Convert.ToString(gridLoadProduct.SelectedRows[0].Cells[1].Value);
            txtPurchasePrice.Text = Convert.ToString(gridLoadProduct.SelectedRows[0].Cells[4].Value);
            txtSallPrice.Text = Convert.ToString(gridLoadProduct.SelectedRows[0].Cells[5].Value);

            //LoadAllProductIntoStokEntryGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Ishave())
            {
                UpdateDataIntoStocktable();
                clearForNewStock();
            }
            else
            {
                SaveDataIntoStocktable();
                clearForNewStock();
            }
            
        }

        private void UpdateDataIntoStocktable()
        {
            

                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = $"UPDATE [dbo].[Stock] SET [Quantity] =[Quantity] +{txtQuantity.Text} WHERE [ProductId] ={txtProductId.Text}";
                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show($"Category Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
                
        }

        private bool Ishave()
        {


            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                SqlCommand sqlCmd = sqlCon.CreateCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = $"usp_Stock_VerifyUpdateDetails";
                sqlCmd.Parameters.Add(new SqlParameter("@ProductId", txtProductId.Text));
                sqlCmd.Parameters.Add(new SqlParameter("@SizeId", txtSizeId.Text));
                sqlCon.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }





        }

        private void SaveDataIntoStocktable()
        {
            if (IsValid())
            {
               
                
                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = $"INSERT INTO [dbo].[Stock] ([ProductId],[SizeId],[PurchasePrice],[SalePrice],[Quantity]) VALUES ({txtProductId.Text},{txtSizeId.Text},{txtPurchasePrice.Text},{txtSallPrice.Text},{txtQuantity.Text})";
                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show($"Stock Entry Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
                
                

            }
        
            
        }

        private void clearForNewStock()
        {      
            txtProductId.Clear();
            txtSizeId.Clear();
            txtPurchasePrice.Clear();
            txtSallPrice.Clear();
            txtQuantity.Clear();
        }

        private bool IsValid()
        {
            if (txtPurchasePrice.Text == string.Empty)
            {
                MessageBox.Show("Purchase Price Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPurchasePrice.Focus();
                return false;
            }
            if (txtSallPrice.Text == string.Empty)
            {
                MessageBox.Show("Sall Price Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSallPrice.Focus();
                return false;
            }
            if (txtQuantity.Text == string.Empty)
            {
                MessageBox.Show("Quantity Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return false;
            }
            return true;
        
            
        }

        private void btnStockView_Click(object sender, EventArgs e)
        {
            ViewStockForm vsf = new ViewStockForm();
            vsf.Show();
        }
    }
}
