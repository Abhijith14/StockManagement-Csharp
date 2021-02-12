using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace StockManagement
{
    public partial class PrintItem : DevExpress.XtraBars.TabForm
    {
       
        public PrintItem(String s1, String s2, string s3, String s4, String s5, string a)
        {
            InitializeComponent();
            textBox3.Text = s1;
            textBox2.Text = s2;
            textBox1.Text = s3;
            dateTimePicker1.Text = s4;
            dateTimePicker2.Text = s5;
            textBox6.Text = a;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PrintItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTOCKDataSet.StockAdd' table. You can move, or remove it, as needed.
            this.stockAddTableAdapter.Fill(this.sTOCKDataSet.StockAdd);
            // TODO: This line of code loads data into the 'sTOCKDataSet.StockAdd' table. You can move, or remove it, as needed.
            this.stockAddTableAdapter.Fill(this.sTOCKDataSet.StockAdd);

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        Bitmap bmp;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");

            
            if (textBox3.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Code,Subject,Description,QuantityS FROM [dbo].[StockAdd] WHERE Class LIKE'" + textBox3.Text + "'", con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                

            }
        }
       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}