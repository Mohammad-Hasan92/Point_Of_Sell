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
    public partial class CategoryForm : MetroFramework.Forms.MetroForm
    {
        public CategoryForm()
        {
            InitializeComponent();
        }
        public bool IsUpdate { get; set; }
        public int CategoryId { get; set; }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadAllCategoryIntoGrid();
        }

        private void LoadAllCategoryIntoGrid()
        {
            if (gridCategory.Columns.Contains("Delete"))
            {
                gridCategory.Columns.Remove("Delete");

            }
            if (gridCategory.Columns.Contains("Edit"))
            {
                gridCategory.Columns.Remove("Edit");

            }

            gridCategory.DataSource = GetData();
            gridCategory.Columns[0].Visible = false;
            DataGridViewButtonColumn dv = new DataGridViewButtonColumn();
            dv.HeaderText = "Delete";
            dv.Name = "Delete";
            gridCategory.Columns.Add(dv);


            DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
            edit.HeaderText = "Edit";
            edit.Name = "Edit";
            gridCategory.Columns.Add(edit);
        }

        private object GetData()
        {
            DataTable CategoryData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $"Select * from [dbo].[Category]";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    CategoryData.Load(reader);
                }
            }
            return CategoryData;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == null)
            {
                LoadAllCategoryIntoGrid();
            }
            else
            {

                if (gridCategory.Columns.Contains("Delete"))
                {
                    gridCategory.Columns.Remove("Delete");

                }

                if (gridCategory.Columns.Contains("Edit"))
                {
                    gridCategory.Columns.Remove("Edit");

                }

                gridCategory.DataSource = GetDataByName();
                gridCategory.Columns[0].Visible = false;


                DataGridViewButtonColumn dv = new DataGridViewButtonColumn();
                dv.HeaderText = "Delete";
                dv.Name = "Delete";
                gridCategory.Columns.Add(dv);

                DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
                edit.HeaderText = "Edit";
                edit.Name = "Edit";
                gridCategory.Columns.Add(edit);



            }
        }

        private DataTable GetDataByName()
        {
            DataTable CategoryData = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand sqlCmd = sqlCon.CreateCommand())
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = $"Select* from[dbo].[Category] where [CategoryName] LIKE +'%'+'{txtSearch.Text}'+'%'";
                    sqlCon.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    CategoryData.Load(reader);
                }
            }
            return CategoryData;
        }

      

        private void gridCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Delete
            if (gridCategory.CurrentCell.ColumnIndex == 2)
            {
                int _id = (int)gridCategory.SelectedRows[0].Cells[0].Value;

                if (_id > 0)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = $"DELETE FROM [dbo].[Category] WHERE [CategoryId] = {_id}";

                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();


                        MessageBox.Show($"Category Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadAllCategoryIntoGrid();
                    }
                }


            }
            //Edit
            if (gridCategory.CurrentCell.ColumnIndex == 3)
            {
                int id = (int)gridCategory.SelectedRows[0].Cells[0].Value;
                if (id > 0)
                {
                    
                    this.IsUpdate = true;
                    this.CategoryId = id;
                    txtCategory.Text = (string)gridCategory.SelectedRows[0].Cells[1].Value;
                    MessageBox.Show(txtCategory.Text);
                    LoadAllCategoryIntoGrid();
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (IsUpdate)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = $"UPDATE [dbo].[Category] SET CategoryName ='{txtCategory.Text}' WHERE CategoryId ={this.CategoryId}";
                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show($"Category Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(ApplicationSetting.ConnectionString()))
                    {
                        SqlCommand sqlCmd = sqlCon.CreateCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = $"INSERT INTO [dbo].[Category] ([CategoryName]) VALUES('{txtCategory.Text}')";
                        sqlCon.Open();
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show($"Category Add Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clearForNewCategory();
                LoadAllCategoryIntoGrid();

            }
        }

        private void clearForNewCategory()
        {
            txtCategory.Clear();
            txtSearch.Clear();
            this.IsUpdate = false;
            this.CategoryId = 0;

        }

        private bool IsValid()
        {
            if (txtCategory.Text == string.Empty)
            {
                MessageBox.Show("Category Name Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategory.Focus();
                return false;

            }
            return true;
        }
    }
}
