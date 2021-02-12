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
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
           /* SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
            con.Open();
            if (ifStockExists(con))
            {

            }
            else
            {
                
                var sql = "";
                sql = @"CREATE TABLE Login( Username nvarchar (50) NOT NULL, Password nvarchar(50) NOT NULL);";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                sql = @"INSERT INTO Login VALUES('admin','admin123')";
                SqlCommand cmd1 = new SqlCommand(sql, con);
                cmd1.ExecuteNonQuery();

            //  }
            con.Close();*/

        }
        private void button2_Click(object sender, EventArgs e)
        {
                textBox1.Text = "";
                textBox2.Clear();
                textBox1.Focus();
        }
        private bool ifStockExists(SqlConnection con1)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT 1 FROM [dbo].[Login]", con1);
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
             
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM Login WHERE UserName = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                  this.Hide();
                  StockMain main = new StockMain(textBox1.Text);
                  main.Show();
                }
                else
                {
                    MessageBox.Show("INVALID CREDENTIALS...!", "Error 401", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2_Click(sender, e);
                }

            }

            private void Login_Load(object sender, EventArgs e)
            {

            }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
            

        
}
