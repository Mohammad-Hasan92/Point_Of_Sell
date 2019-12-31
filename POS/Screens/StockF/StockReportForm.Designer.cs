namespace POS.Screens.StockF
{
    partial class StockReportForm
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
            this.StockReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // StockReportViewer
            // 
            this.StockReportViewer.ActiveViewIndex = -1;
            this.StockReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.StockReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockReportViewer.Location = new System.Drawing.Point(20, 60);
            this.StockReportViewer.Name = "StockReportViewer";
            this.StockReportViewer.Size = new System.Drawing.Size(824, 488);
            this.StockReportViewer.TabIndex = 0;
            this.StockReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // StockReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 568);
            this.Controls.Add(this.StockReportViewer);
            this.Name = "StockReportForm";
            this.Text = "Stock Report Form";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer StockReportViewer;
    }
}