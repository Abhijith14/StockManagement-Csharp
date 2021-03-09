namespace TEST
{
    partial class PrintRep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintRep));
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.TextBox5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(194, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 81;
            this.label7.Text = "Date of Invoice";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(349, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 80;
            this.label6.Text = "Date of Issue";
            // 
            // TextBox3
            // 
            this.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox3.Location = new System.Drawing.Point(28, 130);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.ReadOnly = true;
            this.TextBox3.Size = new System.Drawing.Size(269, 20);
            this.TextBox3.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 76;
            this.label3.Text = "Student Name";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(352, 130);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ReadOnly = true;
            this.TextBox2.Size = new System.Drawing.Size(112, 20);
            this.TextBox2.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(349, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 74;
            this.label4.Text = "CLASS";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(25, 73);
            this.TextBox1.MaxLength = 999999;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(138, 20);
            this.TextBox1.TabIndex = 73;
            this.TextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 72;
            this.label1.Text = "Invoice Number";
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(4, 181);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.Size = new System.Drawing.Size(784, 257);
            this.DataGridView1.TabIndex = 82;
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(530, 18);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(112, 37);
            this.Button2.TabIndex = 83;
            this.Button2.Text = "LOAD DATA";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.Location = new System.Drawing.Point(663, 18);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(112, 37);
            this.Button3.TabIndex = 84;
            this.Button3.Text = "PRINT";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // TextBox4
            // 
            this.TextBox4.Location = new System.Drawing.Point(197, 73);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.ReadOnly = true;
            this.TextBox4.Size = new System.Drawing.Size(112, 20);
            this.TextBox4.TabIndex = 85;
            // 
            // TextBox5
            // 
            this.TextBox5.Location = new System.Drawing.Point(352, 73);
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.ReadOnly = true;
            this.TextBox5.Size = new System.Drawing.Size(112, 20);
            this.TextBox5.TabIndex = 86;
            // 
            // PrintRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TextBox5);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrintRep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Report";
            this.Load += new System.EventHandler(this.PrintRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button3;
        private System.Windows.Forms.TextBox TextBox4;
        private System.Windows.Forms.TextBox TextBox5;
    }
}