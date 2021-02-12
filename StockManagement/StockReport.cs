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

namespace StockManagement
{
    public partial class StockReport : Form
    {
        public StockReport()
        {
            InitializeComponent();
        }

        private void StockReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTOCKDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.sTOCKDataSet.Orders);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");

            if (dateTimePicker1.Text.Length > 0)
            {

                SqlDataAdapter sda = new SqlDataAdapter("SELECT InvNo,InvDate,IssueDate,StudentName,Class,Code,Quantity FROM Orders WHERE IssueDate LIKE '" + dateTimePicker1.Text + "'", con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT* FROM [dbo].[Orders];", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
         
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
