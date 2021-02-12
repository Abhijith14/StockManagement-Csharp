using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement
{
    public partial class Update_Invoice : Form
    {
        public Update_Invoice()
        {
            InitializeComponent();
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

       

        private void Update_Invoice_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTOCKDataSet.StockAdd' table. You can move, or remove it, as needed.
            this.stockAddTableAdapter.Fill(this.sTOCKDataSet.StockAdd);
            // TODO: This line of code loads data into the 'sTOCKDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.sTOCKDataSet.Orders);

        }
        public void LoadData()
        {
            if (textBox1.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT InvNo,InvDate,IssueDate,StudentName,Class,Code,Quantity FROM Orders WHERE InvNo LIKE'" + textBox1.Text + "'", con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                SqlDataAdapter sda1 = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE Class LIKE'" + textBox2.Text + "'", con);
                DataTable data1 = new DataTable();
                sda1.Fill(data1);
                dataGridView2.DataSource = data1;
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Quantity FROM [dbo].[Orders] WHERE Class LIKE'" + textBox2.Text + "'", con);
                DataTable data2 = new DataTable();
                sda2.Fill(data2);
                dataGridView3.DataSource = data2;

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT* FROM [dbo].[Orders];", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlConnection con3 = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                int NewData, OldData, Diff;
                OldData = Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value);
                NewData = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                Diff = OldData - NewData;
                con3.Open();
                if (Diff > 0)
                {
                    SqlCommand cmd3 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                                                 SET [Stock] = [Stock] + '" + Diff + "' WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'", con3);
                    
                    cmd3.ExecuteNonQuery();
                    
                }
                else if (Diff < 0)
                {
                    SqlCommand cmd4 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                                                 SET [Stock] = [Stock] + '" + Diff + "' WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'", con3);
                    
                    cmd4.ExecuteNonQuery();
                   
                   
                }
                SqlCommand cmd5 = new SqlCommand(@"UPDATE [dbo].[Orders]
                                                 SET [Quantity] = '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value) + "' WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'", con3);
                cmd5.ExecuteNonQuery();
                
                con3.Close();
            }



            MessageBox.Show("UPDATED", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
            string sql = "SELECT * FROM Orders Where InvNo = '"+textBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            con.Open();
            myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                string DateofInv = myreader.GetDateTime(1).ToString();// GetString(1);
                string DateofIss = myreader.GetDateTime(2).ToString();
                string name = myreader.GetString(3);
                string Class = myreader.GetInt32(4).ToString();
                dateTimePicker1.Text = DateofInv;
                dateTimePicker2.Text = DateofIss;
                textBox3.Text = name;
                textBox2.Text = Class;
            }
            LoadData();
        }
    }
}
