namespace TEST
{
    partial class ItemWiseRep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemWiseRep));
            this.Button1 = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.stockAddBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.stockManagementDataSet5 = new TEST.StockManagementDataSet5();
            this.stockAddBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockManagementDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockManagementDataSet3 = new TEST.StockManagementDataSet3();
            this.itemWiseRepBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemWiseRepTableAdapter = new TEST.StockManagementDataSet3TableAdapters.ItemWiseRepTableAdapter();
            this.stockAddTableAdapter = new TEST.StockManagementDataSet3TableAdapters.StockAddTableAdapter();
            this.Button2 = new System.Windows.Forms.Button();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.stockManagementDataSet4 = new TEST.StockManagementDataSet4();
            this.itemWiseRepBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.itemWiseRepTableAdapter1 = new TEST.StockManagementDataSet4TableAdapters.ItemWiseRepTableAdapter();
            this.stockAddTableAdapter1 = new TEST.StockManagementDataSet5TableAdapters.StockAddTableAdapter();
            this.Button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockAddBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockManagementDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockAddBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockManagementDataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockManagementDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemWiseRepBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockManagementDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemWiseRepBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(210, 57);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(48, 25);
            this.Button1.TabIndex = 61;
            this.Button1.Text = "ALL";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(41, 101);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.Size = new System.Drawing.Size(1044, 337);
            this.DataGridView1.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Item Code";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.stockAddBindingSource1;
            this.comboBox1.DisplayMember = "Code";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 62;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // stockAddBindingSource1
            // 
            this.stockAddBindingSource1.DataMember = "StockAdd";
            this.stockAddBindingSource1.DataSource = this.stockManagementDataSet5;
            // 
            // stockManagementDataSet5
            // 
            this.stockManagementDataSet5.DataSetName = "StockManagementDataSet5";
            this.stockManagementDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockAddBindingSource
            // 
            this.stockAddBindingSource.DataMember = "StockAdd";
            this.stockAddBindingSource.DataSource = this.stockManagementDataSet3BindingSource;
            // 
            // stockManagementDataSet3BindingSource
            // 
            this.stockManagementDataSet3BindingSource.DataSource = this.stockManagementDataSet3;
            this.stockManagementDataSet3BindingSource.Position = 0;
            // 
            // stockManagementDataSet3
            // 
            this.stockManagementDataSet3.DataSetName = "StockManagementDataSet3";
            this.stockManagementDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemWiseRepBindingSource
            // 
            this.itemWiseRepBindingSource.DataMember = "ItemWiseRep";
            this.itemWiseRepBindingSource.DataSource = this.stockManagementDataSet3BindingSource;
            // 
            // itemWiseRepTableAdapter
            // 
            this.itemWiseRepTableAdapter.ClearBeforeFill = true;
            // 
            // stockAddTableAdapter
            // 
            this.stockAddTableAdapter.ClearBeforeFill = true;
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(809, 20);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(108, 48);
            this.Button2.TabIndex = 63;
            this.Button2.Text = "EXPORT TO PDF";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // DataGridView2
            // 
            this.DataGridView2.AllowUserToAddRows = false;
            this.DataGridView2.AllowUserToDeleteRows = false;
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Location = new System.Drawing.Point(440, 12);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.Size = new System.Drawing.Size(240, 150);
            this.DataGridView2.TabIndex = 64;
            this.DataGridView2.Visible = false;
            // 
            // stockManagementDataSet4
            // 
            this.stockManagementDataSet4.DataSetName = "StockManagementDataSet4";
            this.stockManagementDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemWiseRepBindingSource1
            // 
            this.itemWiseRepBindingSource1.DataMember = "ItemWiseRep";
            this.itemWiseRepBindingSource1.DataSource = this.stockManagementDataSet4;
            // 
            // itemWiseRepTableAdapter1
            // 
            this.itemWiseRepTableAdapter1.ClearBeforeFill = true;
            // 
            // stockAddTableAdapter1
            // 
            this.stockAddTableAdapter1.ClearBeforeFill = true;
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.Location = new System.Drawing.Point(939, 19);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(108, 48);
            this.Button3.TabIndex = 65;
            this.Button3.Text = "EXPORT TO EXCEL";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // ItemWiseRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1135, 450);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.DataGridView2);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ItemWiseRep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockReport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemWiseRep_FormClosed);
            this.Load += new System.EventHandler(this.ItemWiseRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockAddBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockManagementDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockAddBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockManagementDataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockManagementDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemWiseRepBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockManagementDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemWiseRepBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource stockManagementDataSet3BindingSource;
        private StockManagementDataSet3 stockManagementDataSet3;
        private System.Windows.Forms.BindingSource itemWiseRepBindingSource;
        private StockManagementDataSet3TableAdapters.ItemWiseRepTableAdapter itemWiseRepTableAdapter;
        private System.Windows.Forms.BindingSource stockAddBindingSource;
        private StockManagementDataSet3TableAdapters.StockAddTableAdapter stockAddTableAdapter;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.DataGridView DataGridView2;
        private StockManagementDataSet4 stockManagementDataSet4;
        private System.Windows.Forms.BindingSource itemWiseRepBindingSource1;
        private StockManagementDataSet4TableAdapters.ItemWiseRepTableAdapter itemWiseRepTableAdapter1;
        private StockManagementDataSet5 stockManagementDataSet5;
        private System.Windows.Forms.BindingSource stockAddBindingSource1;
        private StockManagementDataSet5TableAdapters.StockAddTableAdapter stockAddTableAdapter1;
        private System.Windows.Forms.Button Button3;
    }
}