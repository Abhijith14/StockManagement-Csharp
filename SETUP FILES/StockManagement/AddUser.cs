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

namespace TEST
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            LoadData();
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
        public void LoadData()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT* FROM [dbo].[Login] WHERE Username NOT LIKE 'ACHU';", con);
                DataTable dt = new DataTable();
                DataGridView1.Rows.Clear();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = DataGridView1.Rows.Add();
                    DataGridView1.Rows[n].Cells[0].Value = item["UserName"].ToString();
                    DataGridView1.Rows[n].Cells[1].Value = item["Password"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("SQL SERVER ERROR. {0}. Please Try Again!!!",ex), "Error 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockManagementDataSet1.Login' table. You can move, or remove it, as needed.
            this.loginTableAdapter.Fill(this.stockManagementDataSet1.Login);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
            textBox1.ReadOnly = false;
        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox1.ReadOnly = true;
                if (DataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "ADMIN")
                {
                    textBox1.Text = "UNEDITABLE";
                    textBox2.Text = DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                }
                else
                {
                    textBox1.Text = DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    textBox2.Text = DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                }
                
            }
            catch(Exception ex)
            {
               MessageBox.Show(String.Format("SQL SERVER ERROR.\n\n {0}.\n\n Please Try Again!!!", ex), "Error 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
                con1.Open();
                var sqlQuery = "";
                if (textBox1.Text == "UNEDITABLE")
                {
                    sqlQuery = @"UPDATE [dbo].[Login]
                           SET [Password] = '" + textBox2.Text + "' WHERE [UserName] = '" + "ADMIN" + "'";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con1);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    if (ifStockExists(con1, textBox1.Text))
                    {
                                           
                        sqlQuery = @"UPDATE [dbo].[Login]
                           SET [Password] = '" + textBox2.Text + "' WHERE [UserName] = '" + textBox1.Text + "'";

                    }
                    else
                    {

                        sqlQuery = @"INSERT INTO[dbo].[Login]
                           ([UserName]
                           ,[Password])
                           VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";

                    }

                    SqlCommand cmd = new SqlCommand(sqlQuery, con1);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                con1.Close();

                //READING DATA

                MessageBox.Show("RECORD ADDED SUCCESSFULLY...!");
                Button1_Click(sender, e);
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("SQL SERVER ERROR.\n\n {0}.\n\n Please Try Again!!!", ex), "Error 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "UNEDITABLE")
            {
                MessageBox.Show("Cannot Delete ADMIN");
            }
            else
            {

                DialogResult dialogResult = MessageBox.Show("Delete Confirmation ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
                    con1.Open();
                    var sqlQuery = "";
                    if (ifStockExists(con1, textBox1.Text))
                    {
                        sqlQuery = @"DELETE FROM [dbo].[Login]
                             WHERE [Username] = '" + textBox1.Text + "'";
                        SqlCommand cmd = new SqlCommand(sqlQuery, con1);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("RECORD DELETED SUCCESSFULLY...!");
                    }
                    else
                    {
                        MessageBox.Show("RECORD NOT FOUND...!");
                    }
                    con1.Close();
                }
            }
            Button1_Click(sender, e);
            LoadData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                
        }
    }
}
