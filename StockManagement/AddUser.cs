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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            LoadData();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTOCKDataSet1.Login' table. You can move, or remove it, as needed.
            this.loginTableAdapter.Fill(this.sTOCKDataSet1.Login);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }
        private bool ifStockExists(SqlConnection con1, string user)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT 1 FROM [dbo].[Login] WHERE [UserName] = '" + textBox1.Text + "'", con1);
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
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
            con1.Open();
            var sqlQuery = "";
            //var query2 = "";

            if (ifStockExists(con1, textBox1.Text))
            {

                sqlQuery = @"UPDATE [dbo].[Login]
                           SET [UserName] = '" + textBox1.Text + "',[Password] = '" + textBox2.Text + "' WHERE [UserName] = '" + textBox1.Text + "'";
                
            }
            else
            {

                sqlQuery = @"INSERT INTO[dbo].[Login]
                           ([UserName]
                           ,[Password])
                           VALUES ('" + textBox1.Text + "','"  + textBox2.Text + "')";
                
            }

            SqlCommand cmd = new SqlCommand(sqlQuery, con1);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con1.Close();
           
            //READING DATA

            MessageBox.Show("RECORD ADDED SUCCESSFULLY...!");
            button1_Click(sender, e);
            LoadData();

        }
        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT* FROM [dbo].[Login];", con);
            DataTable dt = new DataTable();
            dataGridView1.Rows.Clear();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["UserName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Password"].ToString();
              
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            
        }
    }
}
