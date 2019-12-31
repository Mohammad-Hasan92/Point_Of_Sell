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
    public partial class ViewStockForm : MetroFramework.Forms.MetroForm
    {
        public ViewStockForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewStockForm_Load(object sender, EventArgs e)
        {
            LoadAllDataIntoGridView();
        }

        private void LoadAllDataIntoGridView()
        {

            gridStock.DataSource = GetData();
            //gridStock.Columns[0].Visible = false;
            
        }

        private object GetData()
        {
            DataTable StockData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = $"usp_Load_Stock";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    StockData.Load(reader);
                }
            }
            return StockData;
        
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBox.Text == null)
            {
                LoadAllDataIntoGridView();
            }
            else
            {

                gridStock.DataSource = GetDataByName();
                //gridStock.Columns[0].Visible = false;

            }
        }

        private DataTable GetDataByName()
        {
            DataTable StockData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = $"usp_Load_StockByName";
                    sqlCmd.Parameters.Add(new SqlParameter("@name",txtSearchBox.Text));
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    StockData.Load(reader);



                }

                
            }
            return StockData;
        }


        
    }
}
