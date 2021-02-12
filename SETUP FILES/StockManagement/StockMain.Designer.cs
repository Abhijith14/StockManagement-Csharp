namespace TEST
{
    partial class StockMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.aDDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemWiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oldReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 707);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1350, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDDToolStripMenuItem,
            this.addStockToolStripMenuItem,
            this.itemEntryToolStripMenuItem,
            this.invoiceEditToolStripMenuItem,
            this.stockReportToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1350, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // aDDToolStripMenuItem
            // 
            this.aDDToolStripMenuItem.Name = "aDDToolStripMenuItem";
            this.aDDToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.aDDToolStripMenuItem.Text = "Add User";
            this.aDDToolStripMenuItem.Click += new System.EventHandler(this.aDDToolStripMenuItem_Click);
            // 
            // addStockToolStripMenuItem
            // 
            this.addStockToolStripMenuItem.Name = "addStockToolStripMenuItem";
            this.addStockToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.addStockToolStripMenuItem.Text = "Add Stock";
            this.addStockToolStripMenuItem.Click += new System.EventHandler(this.addStockToolStripMenuItem_Click);
            // 
            // itemEntryToolStripMenuItem
            // 
            this.itemEntryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataEntryToolStripMenuItem,
            this.printDataToolStripMenuItem});
            this.itemEntryToolStripMenuItem.Name = "itemEntryToolStripMenuItem";
            this.itemEntryToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.itemEntryToolStripMenuItem.Text = "Item Entry";
            this.itemEntryToolStripMenuItem.Click += new System.EventHandler(this.itemEntryToolStripMenuItem_Click);
            // 
            // dataEntryToolStripMenuItem
            // 
            this.dataEntryToolStripMenuItem.Name = "dataEntryToolStripMenuItem";
            this.dataEntryToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.dataEntryToolStripMenuItem.Text = "Data Entry";
            this.dataEntryToolStripMenuItem.Click += new System.EventHandler(this.dataEntryToolStripMenuItem_Click);
            // 
            // printDataToolStripMenuItem
            // 
            this.printDataToolStripMenuItem.Name = "printDataToolStripMenuItem";
            this.printDataToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.printDataToolStripMenuItem.Text = "Print Data";
            this.printDataToolStripMenuItem.Click += new System.EventHandler(this.printDataToolStripMenuItem_Click);
            // 
            // invoiceEditToolStripMenuItem
            // 
            this.invoiceEditToolStripMenuItem.Name = "invoiceEditToolStripMenuItem";
            this.invoiceEditToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.invoiceEditToolStripMenuItem.Text = "Invoice Edit";
            this.invoiceEditToolStripMenuItem.Click += new System.EventHandler(this.invoiceEditToolStripMenuItem_Click);
            // 
            // stockReportToolStripMenuItem
            // 
            this.stockReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemWiseToolStripMenuItem,
            this.oldReportToolStripMenuItem});
            this.stockReportToolStripMenuItem.Name = "stockReportToolStripMenuItem";
            this.stockReportToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.stockReportToolStripMenuItem.Text = "Stock Report";
            this.stockReportToolStripMenuItem.Click += new System.EventHandler(this.stockReportToolStripMenuItem_Click);
            // 
            // itemWiseToolStripMenuItem
            // 
            this.itemWiseToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.itemWiseToolStripMenuItem.Name = "itemWiseToolStripMenuItem";
            this.itemWiseToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.itemWiseToolStripMenuItem.Text = "Item Code Wise";
            this.itemWiseToolStripMenuItem.Click += new System.EventHandler(this.itemWiseToolStripMenuItem_Click);
            // 
            // oldReportToolStripMenuItem
            // 
            this.oldReportToolStripMenuItem.Name = "oldReportToolStripMenuItem";
            this.oldReportToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.oldReportToolStripMenuItem.Text = "Issue Date Wise";
            this.oldReportToolStripMenuItem.Click += new System.EventHandler(this.oldReportToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1059, 723);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "A Software Developed By ABHIJITH UDAYAKUMAR";
            // 
            // StockMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "StockMain";
            this.Text = "DASHBOARD - STOCK MANAGEMENT JCS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockMain_FormClosing);
            this.Load += new System.EventHandler(this.StockMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem aDDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemWiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oldReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printDataToolStripMenuItem;
    }
}



