namespace POS.Screens.StockF
{
    partial class StockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridLoadProduct = new MetroFramework.Controls.MetroGrid();
            this.txtSearchProduct = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtProductId = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtSizeId = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtPurchasePrice = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtSallPrice = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtQuantity = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnClose = new MetroFramework.Controls.MetroButton();
            this.btnStockView = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoadProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLoadProduct
            // 
            this.gridLoadProduct.AllowUserToAddRows = false;
            this.gridLoadProduct.AllowUserToDeleteRows = false;
            this.gridLoadProduct.AllowUserToResizeColumns = false;
            this.gridLoadProduct.AllowUserToResizeRows = false;
            this.gridLoadProduct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridLoadProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridLoadProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridLoadProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLoadProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLoadProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLoadProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridLoadProduct.EnableHeadersVisualStyles = false;
            this.gridLoadProduct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridLoadProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridLoadProduct.Location = new System.Drawing.Point(355, 115);
            this.gridLoadProduct.MultiSelect = false;
            this.gridLoadProduct.Name = "gridLoadProduct";
            this.gridLoadProduct.ReadOnly = true;
            this.gridLoadProduct.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLoadProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridLoadProduct.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridLoadProduct.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridLoadProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLoadProduct.Size = new System.Drawing.Size(476, 321);
            this.gridLoadProduct.TabIndex = 0;
            this.gridLoadProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLoadProduct_CellClick);
            // 
            // txtSearchProduct
            // 
            // 
            // 
            // 
            this.txtSearchProduct.CustomButton.Image = null;
            this.txtSearchProduct.CustomButton.Location = new System.Drawing.Point(388, 1);
            this.txtSearchProduct.CustomButton.Name = "";
            this.txtSearchProduct.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearchProduct.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearchProduct.CustomButton.TabIndex = 1;
            this.txtSearchProduct.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearchProduct.CustomButton.UseSelectable = true;
            this.txtSearchProduct.CustomButton.Visible = false;
            this.txtSearchProduct.Lines = new string[0];
            this.txtSearchProduct.Location = new System.Drawing.Point(421, 86);
            this.txtSearchProduct.MaxLength = 32767;
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PasswordChar = '\0';
            this.txtSearchProduct.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearchProduct.SelectedText = "";
            this.txtSearchProduct.SelectionLength = 0;
            this.txtSearchProduct.SelectionStart = 0;
            this.txtSearchProduct.ShortcutsEnabled = true;
            this.txtSearchProduct.Size = new System.Drawing.Size(410, 23);
            this.txtSearchProduct.TabIndex = 1;
            this.txtSearchProduct.UseSelectable = true;
            this.txtSearchProduct.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearchProduct.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(355, 86);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(48, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Search";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(36, 86);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(79, 19);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "Product Id";
            // 
            // txtProductId
            // 
            // 
            // 
            // 
            this.txtProductId.CustomButton.Image = null;
            this.txtProductId.CustomButton.Location = new System.Drawing.Point(104, 1);
            this.txtProductId.CustomButton.Name = "";
            this.txtProductId.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtProductId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProductId.CustomButton.TabIndex = 1;
            this.txtProductId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProductId.CustomButton.UseSelectable = true;
            this.txtProductId.CustomButton.Visible = false;
            this.txtProductId.Lines = new string[0];
            this.txtProductId.Location = new System.Drawing.Point(136, 86);
            this.txtProductId.MaxLength = 32767;
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.PasswordChar = '\0';
            this.txtProductId.ReadOnly = true;
            this.txtProductId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProductId.SelectedText = "";
            this.txtProductId.SelectionLength = 0;
            this.txtProductId.SelectionStart = 0;
            this.txtProductId.ShortcutsEnabled = true;
            this.txtProductId.Size = new System.Drawing.Size(126, 23);
            this.txtProductId.TabIndex = 1;
            this.txtProductId.UseSelectable = true;
            this.txtProductId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProductId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(62, 119);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(53, 19);
            this.metroLabel5.TabIndex = 2;
            this.metroLabel5.Text = "Size Id";
            // 
            // txtSizeId
            // 
            // 
            // 
            // 
            this.txtSizeId.CustomButton.Image = null;
            this.txtSizeId.CustomButton.Location = new System.Drawing.Point(104, 1);
            this.txtSizeId.CustomButton.Name = "";
            this.txtSizeId.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSizeId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSizeId.CustomButton.TabIndex = 1;
            this.txtSizeId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSizeId.CustomButton.UseSelectable = true;
            this.txtSizeId.CustomButton.Visible = false;
            this.txtSizeId.Lines = new string[0];
            this.txtSizeId.Location = new System.Drawing.Point(136, 115);
            this.txtSizeId.MaxLength = 32767;
            this.txtSizeId.Name = "txtSizeId";
            this.txtSizeId.PasswordChar = '\0';
            this.txtSizeId.ReadOnly = true;
            this.txtSizeId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSizeId.SelectedText = "";
            this.txtSizeId.SelectionLength = 0;
            this.txtSizeId.SelectionStart = 0;
            this.txtSizeId.ShortcutsEnabled = true;
            this.txtSizeId.Size = new System.Drawing.Size(126, 23);
            this.txtSizeId.TabIndex = 1;
            this.txtSizeId.UseSelectable = true;
            this.txtSizeId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSizeId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(8, 151);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(107, 19);
            this.metroLabel6.TabIndex = 2;
            this.metroLabel6.Text = "Purchase Price";
            // 
            // txtPurchasePrice
            // 
            // 
            // 
            // 
            this.txtPurchasePrice.CustomButton.Image = null;
            this.txtPurchasePrice.CustomButton.Location = new System.Drawing.Point(104, 1);
            this.txtPurchasePrice.CustomButton.Name = "";
            this.txtPurchasePrice.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPurchasePrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPurchasePrice.CustomButton.TabIndex = 1;
            this.txtPurchasePrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPurchasePrice.CustomButton.UseSelectable = true;
            this.txtPurchasePrice.CustomButton.Visible = false;
            this.txtPurchasePrice.Lines = new string[0];
            this.txtPurchasePrice.Location = new System.Drawing.Point(136, 151);
            this.txtPurchasePrice.MaxLength = 32767;
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.PasswordChar = '\0';
            this.txtPurchasePrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPurchasePrice.SelectedText = "";
            this.txtPurchasePrice.SelectionLength = 0;
            this.txtPurchasePrice.SelectionStart = 0;
            this.txtPurchasePrice.ShortcutsEnabled = true;
            this.txtPurchasePrice.Size = new System.Drawing.Size(126, 23);
            this.txtPurchasePrice.TabIndex = 1;
            this.txtPurchasePrice.UseSelectable = true;
            this.txtPurchasePrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPurchasePrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel7.Location = new System.Drawing.Point(36, 189);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(75, 19);
            this.metroLabel7.TabIndex = 2;
            this.metroLabel7.Text = "Sale Price";
            // 
            // txtSallPrice
            // 
            // 
            // 
            // 
            this.txtSallPrice.CustomButton.Image = null;
            this.txtSallPrice.CustomButton.Location = new System.Drawing.Point(104, 1);
            this.txtSallPrice.CustomButton.Name = "";
            this.txtSallPrice.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSallPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSallPrice.CustomButton.TabIndex = 1;
            this.txtSallPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSallPrice.CustomButton.UseSelectable = true;
            this.txtSallPrice.CustomButton.Visible = false;
            this.txtSallPrice.Lines = new string[0];
            this.txtSallPrice.Location = new System.Drawing.Point(136, 189);
            this.txtSallPrice.MaxLength = 32767;
            this.txtSallPrice.Name = "txtSallPrice";
            this.txtSallPrice.PasswordChar = '\0';
            this.txtSallPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSallPrice.SelectedText = "";
            this.txtSallPrice.SelectionLength = 0;
            this.txtSallPrice.SelectionStart = 0;
            this.txtSallPrice.ShortcutsEnabled = true;
            this.txtSallPrice.Size = new System.Drawing.Size(126, 23);
            this.txtSallPrice.TabIndex = 1;
            this.txtSallPrice.UseSelectable = true;
            this.txtSallPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSallPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel8.Location = new System.Drawing.Point(45, 226);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(66, 19);
            this.metroLabel8.TabIndex = 2;
            this.metroLabel8.Text = "Quantity";
            // 
            // txtQuantity
            // 
            // 
            // 
            // 
            this.txtQuantity.CustomButton.Image = null;
            this.txtQuantity.CustomButton.Location = new System.Drawing.Point(104, 1);
            this.txtQuantity.CustomButton.Name = "";
            this.txtQuantity.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQuantity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQuantity.CustomButton.TabIndex = 1;
            this.txtQuantity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQuantity.CustomButton.UseSelectable = true;
            this.txtQuantity.CustomButton.Visible = false;
            this.txtQuantity.Lines = new string[0];
            this.txtQuantity.Location = new System.Drawing.Point(136, 226);
            this.txtQuantity.MaxLength = 32767;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PasswordChar = '\0';
            this.txtQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.SelectionLength = 0;
            this.txtQuantity.SelectionStart = 0;
            this.txtQuantity.ShortcutsEnabled = true;
            this.txtQuantity.Size = new System.Drawing.Size(126, 23);
            this.txtQuantity.TabIndex = 1;
            this.txtQuantity.UseSelectable = true;
            this.txtQuantity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQuantity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(36, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(172, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStockView
            // 
            this.btnStockView.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnStockView.Location = new System.Drawing.Point(36, 332);
            this.btnStockView.Name = "btnStockView";
            this.btnStockView.Size = new System.Drawing.Size(226, 104);
            this.btnStockView.TabIndex = 4;
            this.btnStockView.Text = "View Stock";
            this.btnStockView.UseSelectable = true;
            this.btnStockView.Click += new System.EventHandler(this.btnStockView_Click);
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 477);
            this.Controls.Add(this.btnStockView);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtSallPrice);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.txtSizeId);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.txtSearchProduct);
            this.Controls.Add(this.gridLoadProduct);
            this.MinimizeBox = false;
            this.Name = "StockForm";
            this.ShowInTaskbar = false;
            this.Text = "Stock Entry Form";
            this.Load += new System.EventHandler(this.StockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLoadProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid gridLoadProduct;
        private MetroFramework.Controls.MetroTextBox txtSearchProduct;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtProductId;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtSizeId;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtPurchasePrice;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtSallPrice;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtQuantity;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnClose;
        private MetroFramework.Controls.MetroButton btnStockView;
    }
}