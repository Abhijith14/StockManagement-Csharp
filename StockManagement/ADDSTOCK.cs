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
    public partial class ADDSTOCK : Form
    {
        public ADDSTOCK()
        {
            InitializeComponent();
            CodeGen();
        }

        private void ADDSTOCK_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlConnection con1 = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
            con1.Open();
            if (ifStockExists(con1, textBox2.Text))
            {

                SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                           SET [Class]='" + comboBox1.Text + "',[Subject] = '" + textBox4.Text + "',[Description] = '" + textBox1.Text + "',[Publisher] = '" + textBox3.Text + "',[Quantity] = '" + textBox5.Text + "' WHERE [Code] = '" + textBox2.Text + "'", con1);
                cmd.ExecuteNonQuery();
                
                SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                         SET [Stock] = '" + textBox5.Text + "' + [Stock]  WHERE[Code] = '" + textBox2.Text + "'", con1);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("RECORD ADDED SUCCESSFULLY...!");
                button3_Click(sender, e);
                LoadData();
            }
            else
            {
                string find = textBox2.Text.Substring(0, 1);
                if (find == comboBox1.Text)
                {
                   SqlCommand cmd = new SqlCommand(@"INSERT INTO[dbo].[StockAdd]
                           ([Code]
                           ,[Class]
                           ,[Subject]
                           ,[Description]
                           ,[Publisher]
                           ,[Quantity]
                           ,[Stock])
                             VALUES('" + textBox2.Text + "', '" + comboBox1.Text + "', '" + textBox4.Text + "', '" + textBox1.Text + "', '" + textBox3.Text + "', '" + textBox5.Text + "', '" + textBox5.Text + "')", con1);
                    cmd.ExecuteNonQuery();
                   
                    SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                         SET [Stock] = [Quantity]  WHERE[Code] = '" + textBox2.Text + "'", con1);
                    cmd1.ExecuteNonQuery();
                   
               

                    SqlCommand cmd2 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                         SET [Quantity] = 0 WHERE[Code] = '" + textBox2.Text + "'", con1);

                        cmd2.ExecuteNonQuery();
            
               
                     MessageBox.Show("RECORD ADDED SUCCESSFULLY...!");
                     button3_Click(sender, e);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("CODE INVALID...!");
                }
            }
            con1.Close();

        }
        private bool ifStockExists(SqlConnection con1, string Code)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT 1 FROM [dbo].[StockAdd] WHERE [Code] = '" + textBox2.Text + "'", con1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
            con1.Open();
            var sqlQuery = "";
            if (ifStockExists(con1, textBox2.Text))
            {
                sqlQuery = @"DELETE FROM [dbo].[StockAdd]
                             WHERE [Code] = '" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con1);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("RECORD DELETED SUCCESSFULLY...!");
            }
            else
            {
                MessageBox.Show("RECORD NOT FOUND...!");
            }
            con1.Close();
            button3_Click(sender, e);
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            comboBox1.Text = "";
            textBox4.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox2.Focus();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }
        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT* FROM [dbo].[StockAdd];", con);
            DataTable dt = new DataTable();
            dataGridView1.Rows.Clear();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["Code"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Class"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Subject"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Description"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["Publisher"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["Quantity"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["Stock"].ToString();
            }
        }
        public void CodeGen()
        {
            SqlConnection con3 = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");

            con3.Open();

            SqlCommand cmd2 = new SqlCommand(@"SELECT max(Code)+1 FROM [dbo].[StockAdd]  WHERE [Code] = '" + comboBox1.Text + "'", con3);

            SqlDataReader dr = cmd2.ExecuteReader();

            while (dr.Read())
            {
                textBox2.Text = dr.GetValue(0).ToString();
            }

            con3.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
