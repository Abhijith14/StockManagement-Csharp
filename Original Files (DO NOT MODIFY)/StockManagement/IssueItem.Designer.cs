namespace TEST
{
    partial class IssueItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueItem));
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.stockAddBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockManagementDataSet2 = new TEST.StockManagementDataSet2();
            this.DataGridView3 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.stockAddTableAdapter = new TEST.StockManagementDataSet2TableAdapters.StockAddTableAdapter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.TextBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DataGridView4 = new System.Windows.Forms.DataGridView();
            this.DataGridView5 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.stockAddBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockManagementDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox4
            // 
            this.TextBox4.Location = new System.Drawing.Point(12, 16);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new System.Drawing.Size(138, 20);
            this.TextBox4.TabIndex = 74;
            this.TextBox4.Visible = false;
            // 
            // ComboBox2
            // 
            this.ComboBox2.DataSource = this.stockAddBindingSource;
            this.ComboBox2.DisplayMember = "Subject";
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.Location = new System.Drawing.Point(467, 162);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(121, 21);
            this.ComboBox2.TabIndex = 63;
            this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // stockAddBindingSource
            // 
            this.stockAddBindingSource.DataMember = "StockAdd";
            this.stockAddBindingSource.DataSource = this.stockManagementDataSet2;
            // 
            // stockManagementDataSet2
            // 
            this.stockManagementDataSet2.DataSetName = "StockManagementDataSet2";
            this.stockManagementDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataGridView3
            // 
            this.DataGridView3.AllowUserToAddRows = false;
            this.DataGridView3.AllowUserToDeleteRows = false;
            this.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView3.Location = new System.Drawing.Point(12, 25);
            this.DataGridView3.Name = "DataGridView3";
            this.DataGridView3.ReadOnly = true;
            this.DataGridView3.Size = new System.Drawing.Size(93, 25);
            this.DataGridView3.TabIndex = 73;
            this.DataGridView3.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(188, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 71;
            this.label7.Text = "Date of Invoice";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(343, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 70;
            this.label6.Text = "Date of Issue";
            // 
            // DateTimePicker2
            // 
            this.DateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker2.Location = new System.Drawing.Point(346, 107);
            this.DateTimePicker2.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker2.Name = "DateTimePicker2";
            this.DateTimePicker2.Size = new System.Drawing.Size(104, 20);
            this.DateTimePicker2.TabIndex = 69;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker1.Location = new System.Drawing.Point(192, 107);
            this.DateTimePicker1.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(99, 20);
            this.DateTimePicker1.TabIndex = 68;
            this.DateTimePicker1.Value = new System.DateTime(2019, 12, 25, 23, 59, 59, 0);
            // 
            // TextBox3
            // 
            this.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox3.Location = new System.Drawing.Point(22, 164);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(254, 20);
            this.TextBox3.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 66;
            this.label3.Text = "Student Name";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(300, 163);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(112, 20);
            this.TextBox2.TabIndex = 65;
            this.TextBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            this.TextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox2_KeyPress);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(8, 204);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(784, 285);
            this.DataGridView1.TabIndex = 64;
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.DataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView1_DataError);
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(618, 16);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(124, 48);
            this.Button1.TabIndex = 62;
            this.Button1.Text = "SAVE";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(297, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 61;
            this.label4.Text = "CLASS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(464, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 60;
            this.label2.Text = "Subject";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(19, 107);
            this.TextBox1.MaxLength = 999999;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(138, 20);
            this.TextBox1.TabIndex = 59;
            this.TextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 58;
            this.label1.Text = "Invoice Number";
            // 
            // DataGridView2
            // 
            this.DataGridView2.AllowUserToAddRows = false;
            this.DataGridView2.AllowUserToDeleteRows = false;
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Location = new System.Drawing.Point(111, 16);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.ReadOnly = true;
            this.DataGridView2.Size = new System.Drawing.Size(127, 34);
            this.DataGridView2.TabIndex = 72;
            this.DataGridView2.Visible = false;
            // 
            // stockAddTableAdapter
            // 
            this.stockAddTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "StockAdd";
            // 
            // TextBox5
            // 
            this.TextBox5.Location = new System.Drawing.Point(644, 162);
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Size = new System.Drawing.Size(112, 20);
            this.TextBox5.TabIndex = 75;
            this.TextBox5.TextChanged += new System.EventHandler(this.TextBox5_TextChanged);
            this.TextBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox5_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(638, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 76;
            this.label5.Text = "Quantity Fix";
            // 
            // DataGridView4
            // 
            this.DataGridView4.AllowUserToAddRows = false;
            this.DataGridView4.AllowUserToDeleteRows = false;
            this.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView4.Location = new System.Drawing.Point(592, 89);
            this.DataGridView4.Name = "DataGridView4";
            this.DataGridView4.ReadOnly = true;
            this.DataGridView4.Size = new System.Drawing.Size(127, 34);
            this.DataGridView4.TabIndex = 77;
            this.DataGridView4.Visible = false;
            // 
            // DataGridView5
            // 
            this.DataGridView5.AllowUserToAddRows = false;
            this.DataGridView5.AllowUserToDeleteRows = false;
            this.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView5.Location = new System.Drawing.Point(439, 74);
            this.DataGridView5.Name = "DataGridView5";
            this.DataGridView5.ReadOnly = true;
            this.DataGridView5.Size = new System.Drawing.Size(127, 34);
            this.DataGridView5.TabIndex = 78;
            this.DataGridView5.Visible = false;
            // 
            // IssueItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(807, 493);
            this.Controls.Add(this.DataGridView5);
            this.Controls.Add(this.DataGridView4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TextBox5);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.ComboBox2);
            this.Controls.Add(this.DataGridView3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DateTimePicker2);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridView2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IssueItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Entry";
            this.Load += new System.EventHandler(this.IssueItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockAddBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockManagementDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox4;
        private System.Windows.Forms.ComboBox ComboBox2;
        private System.Windows.Forms.DataGridView DataGridView3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DateTimePicker2;
        private System.Windows.Forms.DateTimePicker DateTimePicker1;
        private System.Windows.Forms.TextBox TextBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridView2;
        private StockManagementDataSet2 stockManagementDataSet2;
        private System.Windows.Forms.BindingSource stockAddBindingSource;
        private StockManagementDataSet2TableAdapters.StockAddTableAdapter stockAddTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox TextBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DataGridView4;
        private System.Windows.Forms.DataGridView DataGridView5;
    }
}