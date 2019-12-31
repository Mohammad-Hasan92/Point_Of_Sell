using POS.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Screens.ProductsF
{
    public partial class DefineProductscreen : MetroFramework.Forms.MetroForm
    {
        public DefineProductscreen()
        {
            InitializeComponent();
        }

        public bool IsUpdate { get; set; }

        

        private void DefineProductscreen_Load(object sender, EventArgs e)
        {
            if(!this.IsUpdate)
            {

            }
            LoadAllSizesInDataGridView();
            LoadDataIntoComboBoxes();
        }

        private void LoadDataIntoComboBoxes()
        {
            DataSet ds = new DataSet();
            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {


                SqlCommand sqlCmd = sqlCon.CreateCommand();
                SqlDataAdapter sqlAdp = new SqlDataAdapter("usp_Load_Category_Supplier", sqlCon);  
                sqlCon.Open();
                sqlAdp.Fill(ds);
                sqlCon.Close();
                ds.Tables[0].TableName = "Category";
                ds.Tables[1].TableName = "Supplier";

            }
            cmbCategory.DataSource = ds.Tables["Category"];
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";

            cmbSupplier.DataSource = ds.Tables["Supplier"];
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierId";
        }

       

        private void LoadAllSizesInDataGridView()
        {
            gridProductSize.DataSource = GetSizesData();
            
        }

        private DataTable GetSizesData()
        {
            DataTable dtSizes = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "usp_Sizes_LoadSizes";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    dtSizes.Load(reader);
                }
            }
            return dtSizes;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtProductName.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            txtPurchasePrice.Clear();
            txtSalesPrice.Clear();
            txtAddOrSearch.Clear();
            txtProductName.Focus();

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                
                using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "usp_products_insertNewProducts";

                    sqlCmd.Parameters.Add(new SqlParameter("@Name", txtProductName.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@CategoryId", cmbCategory.SelectedValue));
                    sqlCmd.Parameters.Add(new SqlParameter("@SupplierId", cmbSupplier.SelectedValue));
                    sqlCmd.Parameters.Add(new SqlParameter("@PurchasePrice", txtPurchasePrice.Text));
                    sqlCmd.Parameters.Add(new SqlParameter("@SalesPrice", txtSalesPrice.Text));

                    int sid = (int)gridProductSize.SelectedRows[0].Cells[0].Value;
                    sqlCon.Open();
                    var id = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    SaveSizes(id,sid);
                    MessageBox.Show($"Proudect Save in id = {id.ToString()}","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void SaveSizes(int _id,int sid)
        {
            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                if(sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                
                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "usp_products_insertSizes";

                    sqlCmd.Parameters.Add(new SqlParameter("@ProductId", _id));
                    sqlCmd.Parameters.Add(new SqlParameter("@SizeId", sid));

                    sqlCmd.ExecuteNonQuery();
 
            }
        }

      

        private bool IsValid()
        {
            if(txtProductName.Text == string.Empty)
            {
                MessageBox.Show("Product Name Is Requird","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductName.Focus();
                return false;
            }
            if (txtPurchasePrice.Text == string.Empty)
            {
                MessageBox.Show("Purchase Price Is Requird", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSalesPrice.Text == string.Empty)
            {
                MessageBox.Show("Sales Price Is Requird", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {
            if (IsValidSize())
            {
                using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                {
                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $"INSERT INTO [dbo].[Sizes] ([SizeValue]) VALUES ('{txtAddOrSearch.Text}')";    
                    sqlCon.Open();
                    sqlCmd.ExecuteScalar();
                    
                    MessageBox.Show($"Add Size is Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllSizesInDataGridView();
                }
            }
        }

        private bool IsValidSize()
        {
            if (txtAddOrSearch.Text == string.Empty)
            {
                MessageBox.Show("Size Value Is Requird", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddOrSearch.Focus();
                return false;
            }
            return true;
        }

        private void txtAddOrSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtAddOrSearch.Text == null)
            {
                LoadAllSizesInDataGridView(); 
            }
            else
            {
                gridProductSize.DataSource = GetDataByValue();
                //gridProductSize.Columns[0].Visible = false;
            }
        }

        private DataTable GetDataByValue()
        {
            DataTable SizeData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $"Select* from[dbo].[Sizes] where [SizeValue] LIKE +'%'+'{txtAddOrSearch.Text}'+'%'";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    SizeData.Load(reader);
                }
            }
            return SizeData;
        }
    }
}
