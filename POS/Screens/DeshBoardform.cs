using CrystalDecisions.CrystalReports.Engine;
using POS.General;
using POS.Screens.CustomerF;
using POS.Screens.ProductsF;
using POS.Screens.StockF;
using POS.Screens.UserF;
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

namespace POS.Screens
{
    public partial class DeshBoardform : MetroFramework.Forms.MetroForm
    {
        public DeshBoardform()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDifineProducts_Click(object sender, EventArgs e)
        {
            DefineProductscreen dps = new DefineProductscreen();
            dps.Show();
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            ProductsRecordForm prf = new ProductsRecordForm();
            prf.Show();
        }

      

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomerForm ncf = new NewCustomerForm();
            ncf.Show();
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            CustomerRecordForm crf = new CustomerRecordForm();
            crf.Show();
        }

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            CategoryForm cf = new CategoryForm();
            cf.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
        }

        private void btnStockManagement_Click(object sender, EventArgs e)
        {
            StockForm sf = new StockForm();
            sf.Show();
        }

        private void btnCustomReports_Click(object sender, EventArgs e)
        {
            LoadStockReport();
        }

        private void LoadStockReport()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
                {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_Load_Stock";
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    sda.Fill(ds, "usp_Load_Stock");

                    ReportDocument rd = new ReportDocument();
                    string reportPath = Application.StartupPath + @"\Screens\Reports\StockReport.rpt";

                    rd.Load(reportPath);
                    rd.SetDataSource(ds);

                    StockReportForm rv = new StockReportForm();
                    rv.StockReportViewer.ReportSource = rd;
                    rv.Show(this);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
