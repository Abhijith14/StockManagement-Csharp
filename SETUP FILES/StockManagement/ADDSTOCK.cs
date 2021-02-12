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
    public partial class ADDSTOCK : Form
    {
        public ADDSTOCK()
        {
            InitializeComponent();
           // CodeGen();
        }

        private void ADDSTOCK_Load(object sender, EventArgs e)
        {
            ComboBox1.SelectedIndex = 0;
            LoadData();
        }
        private bool ifStockExists(SqlConnection con1, string Code)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT 1 FROM [dbo].[StockAdd] WHERE [Code] = '" + TextBox2.Text + "'", con1);
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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT* FROM [dbo].[StockAdd];", con);
            DataTable dt = new DataTable();
            DataGridView1.Rows.Clear();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = DataGridView1.Rows.Add();
                DataGridView1.Rows[n].Cells[0].Value = item["Code"].ToString();
                DataGridView1.Rows[n].Cells[1].Value = item["Class"].ToString();
                DataGridView1.Rows[n].Cells[2].Value = item["Subject"].ToString();
                DataGridView1.Rows[n].Cells[3].Value = item["Description"].ToString();
                DataGridView1.Rows[n].Cells[4].Value = item["Publisher"].ToString();
                DataGridView1.Rows[n].Cells[5].Value = item["DateofPurchase"].ToString();
                DataGridView1.Rows[n].Cells[6].Value = item["Supplier"].ToString();
                DataGridView1.Rows[n].Cells[7].Value = item["Quantity"].ToString();
                DataGridView1.Rows[n].Cells[8].Value = item["Stock"].ToString();
            }
           
        }

        /*  public void CodeGen()
          {
              SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");

              con3.Open();

              SqlCommand cmd2 = new SqlCommand(@"SELECT Code FROM [dbo].[StockAdd]", con3);

              SqlDataReader dr = cmd2.ExecuteReader();

              while (dr.Read())
              {
                  TextBox7.Text = dr.GetValue(0).ToString();
                  MessageBox.Show("CODE EXECUTING!!!");
              }

              con3.Close();
          }*/
        private void LoadItem()
        {
            SqlConnection con  = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            con2.Open();
            string sql = "SELECT DISTINCT Code FROM ItemWiseRep";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            con.Open();
            myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                string Code = myreader.GetInt32(0).ToString();

                #region ADDING
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Code,PurchaseQty,InvNo,SaleQty,[Balance Stock],NUM FROM [dbo].[ItemWiseRep] WHERE Code = '" + Code + "'", con1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataGridView2.DataSource = dt;

                DataGridView2.Sort(DataGridView2.Columns[5], ListSortDirection.Ascending);

                for (int i = 1; i <= DataGridView2.Rows.Count; i++)
                {

                    if (i > 1)
                    {
                        if (DataGridView2.Rows[i - 1].Cells[1].Value.ToString() != "")
                        {
                            int S = Convert.ToInt32(DataGridView2.Rows[i - 1].Cells[1].Value) + Convert.ToInt32(DataGridView2.Rows[i - 2].Cells[4].Value);
                            //  MessageBox.Show(String.Format("{0} + {1} = {2}", DataGridView2.Rows[i - 1].Cells[1].Value, DataGridView2.Rows[i - 2].Cells[4].Value, S));

                            SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[ItemWiseRep]
                                                               SET [Balance Stock] = '" + S + "'  WHERE[Code] = '" + Code + "' AND [NUM] LIKE '" + i + "'", con2);
                            cmd1.ExecuteNonQuery();

                        }
                        else if (DataGridView2.Rows[i - 1].Cells[3].Value.ToString() != "")
                        {
                            int S = Convert.ToInt32(DataGridView2.Rows[i - 2].Cells[4].Value) - Convert.ToInt32(DataGridView2.Rows[i - 1].Cells[3].Value);
                            //  MessageBox.Show(String.Format("{0} - {1} = {2}",Convert.ToInt32(DataGridView2.Rows[i - 2].Cells[4].Value), Convert.ToInt32(DataGridView2.Rows[i - 1].Cells[3].Value),S));
                            SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[ItemWiseRep]
                                                               SET [Balance Stock] = '" + S + "'  WHERE[Code] = '" + Code + "' AND [NUM] LIKE '" + i + "'", con2);
                            cmd1.ExecuteNonQuery();
                        }


                        else
                        {
                            continue;
                        }
                    }

                }
                #endregion



            }
        }
            private void Button3_Click(object sender, EventArgs e)
            {
                TextBox2.Clear();
                ComboBox1.Text = "";
                TextBox4.Clear();
                TextBox1.Clear();
                TextBox3.Clear();
                TextBox5.Clear();
                textBox6.Clear();
                TextBox2.Focus();
            }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete Confirmation ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
                con1.Open();
                var sqlQuery = "";
                if (ifStockExists(con1, TextBox2.Text))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT Code FROM [dbo].[Orders] WHERE [Code] = '" + TextBox2.Text + "'", con1);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    DataGridView3.DataSource = data;

                    int l = DataGridView3.Rows.Count;

                  //  MessageBox.Show(String.Format("l = {0}", l));

                    int f = 0;

                    if (l > 0)
                    {
                        if (TextBox2.Text == DataGridView3.Rows[0].Cells[0].Value.ToString())
                        {
                            MessageBox.Show("CANNOT DELETE THIS RECORD...!");
                            f = 1;
                        }
                        else
                        {
                            f = 0;
                        }
                    }
                    else
                    {
                        f = 0;
                    }
                    if (f == 0)
                    {
                        sqlQuery = @"DELETE FROM [dbo].[StockAdd]
                             WHERE [Code] = '" + TextBox2.Text + "'";
                        SqlCommand cmd = new SqlCommand(sqlQuery, con1);
                        cmd.ExecuteNonQuery();

                        SqlCommand cmd1 = new SqlCommand(@"DELETE FROM [dbo].[ItemWiseRep]
                                                         WHERE [Code] = '" + TextBox2.Text + "'", con1);
                        cmd1.ExecuteNonQuery();

                        MessageBox.Show("RECORD DELETED SUCCESSFULLY...!");
                    }
                    
                }
                else
                {
                    MessageBox.Show("RECORD NOT FOUND...!");
                }
                con1.Close();
            }
            Button3_Click(sender, e);
            LoadData();
        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox2.Text = DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ComboBox1.Text = DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            TextBox4.Text = DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            TextBox1.Text = DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            TextBox3.Text = DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            dateTimePicker2.Text = DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = DataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            TextBox5.Text = DataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
                int check = 0;
                if (TextBox2.Text == "")
                {
                    MessageBox.Show("Subject Code CANT BE NULL");
                    check = 1;
                    TextBox2.Focus();
                }
                else if (ComboBox1.Text == "")
                {
                    MessageBox.Show("Class CANT BE NULL");
                    check = 1;
                    TextBox2.Focus();
                }
                else if (TextBox4.Text == "")
                {
                    MessageBox.Show("Subject CANT BE NULL");
                    check = 1;
                    TextBox4.Focus();
                }
                else if (TextBox1.Text == "")
                {
                    MessageBox.Show("Subject Description CANT BE NULL");
                    check = 1;
                    TextBox1.Focus();
                }
                else if (TextBox3.Text == "")
                {
                    MessageBox.Show("Publishers CANT BE NULL");
                    check = 1;
                    TextBox3.Focus();
                }
           

                if (check == 0)
                {
                
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
                    con1.Open();
                    if (ifStockExists(con1, TextBox2.Text))
                    {
                        DialogResult dialogResult = MessageBox.Show("Are You Sure To Update ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {

                            SqlDataAdapter sda = new SqlDataAdapter("SELECT NUM FROM [dbo].[ItemWiseRep] WHERE [Code] = '" + TextBox2.Text + "'", con1);
                            DataTable data = new DataTable();
                            sda.Fill(data);
                            DataGridView2.DataSource = data;

                            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT Subject,Description FROM [dbo].[StockAdd]", con1);
                            DataTable data1 = new DataTable();
                            sda1.Fill(data1);
                            DataGridView3.DataSource = data1;


                            int U = 0;
                            for (int i = 0; i < DataGridView3.Rows.Count; i++)
                            {
                               // MessageBox.Show(String.Format("{0} and {1}", DataGridView3.Rows[i].Cells[0].Value.ToString(), TextBox4.Text));

                                if (DataGridView3.Rows[i].Cells[0].Value.ToString() == TextBox4.Text && DataGridView3.Rows[i].Cells[1].Value.ToString() == TextBox1.Text)
                                {
                                    U = 0;
                                }
                                else if (DataGridView3.Rows[i].Cells[0].Value.ToString() != TextBox4.Text || DataGridView3.Rows[i].Cells[1].Value.ToString() != TextBox1.Text)
                                {
                                    U = 1;
                                    SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
                                    con2.Open();
                                    SqlCommand cmd4 = new SqlCommand(@"UPDATE [dbo].[ItemWiseRep]
                                        SET [Item] = '" + TextBox4.Text + "' WHERE [Code] = '" + TextBox2.Text + "'", con2);
                                    cmd4.ExecuteNonQuery();
                                   // MessageBox.Show("YEP");
                                }
                            }



                            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                               SET [Class]='" + ComboBox1.Text + "',[Subject] = '" + TextBox4.Text + "',[Description] = '" + TextBox1.Text + "',[Publisher] = '" + TextBox3.Text + "',[Quantity] = '" + 0 + "',[Dateofpurchase] = '" + dateTimePicker2.Text + "',[Supplier] = '" + textBox6.Text + "' WHERE [Code] = '" + TextBox2.Text + "'", con1);
                            cmd.ExecuteNonQuery();

                            SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                             SET [Stock] = '" + TextBox5.Text + "' + [Stock]  WHERE [Code] = '" + TextBox2.Text + "'", con1);
                            cmd1.ExecuteNonQuery();

                           
                            if (U == 0)
                            {
                                int l = DataGridView2.Rows.Count;

                                int SUM = 0;//Convert.ToInt32(DataGridView2.Rows[l - 1].Cells[0].Value) + Convert.ToInt32(TextBox5.Text);

                                SqlCommand cmd3 = new SqlCommand(@"INSERT INTO[dbo].[ItemWiseRep]
                               ([Code]
                               ,[Item]
                               ,[DateOfPurchase]
                               ,[PurchaseQty]
                               ,[Balance Stock]
                               ,[Publisher]
                               ,[DateSort]
                               ,[NUM])
                                                    
                                 VALUES('" + TextBox2.Text + "', '" + TextBox4.Text + "', '" + dateTimePicker2.Text + "', '" + TextBox5.Text + "', '" + SUM + "','" + TextBox3.Text + "', '" + dateTimePicker2.Text + "', '" + (l + 1) + "')", con1);
                                      //MessageBox.Show("Edted1");   
                                 cmd3.ExecuteNonQuery();
                                         //  MessageBox.Show("Edited2");
                            }



                            MessageBox.Show("RECORD ADDED SUCCESSFULLY...!");
                            //Button3_Click(sender, e);

                            LoadData();





                             LoadItem();

                            //SqlCommand cmd4 = new SqlCommand(@"UPDATE [dbo].[ItemWiseRep]
                            //   SET [Balance Stock] = '" + DataGridView2.Rows[0].Cells[0].Value + "'  WHERE[PurCode] = '" + DataGridView3.Rows[0].Cells[0].Value + "'", con1);
                            //cmd4.ExecuteNonQuery();



                            Button3_Click(sender, e);
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Are You Sure To Add?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string find = TextBox2.Text.Substring(0, 1);
                            if (find == ComboBox1.Text)
                            {
                                SqlCommand cmd = new SqlCommand(@"INSERT INTO[dbo].[StockAdd]
                               ([Code]
                               ,[Class]
                               ,[Subject]
                               ,[Description]
                               ,[Publisher]
                               ,[Quantity]
                               ,[DateofPurchase]
                               ,[Supplier])
                                 VALUES('" + TextBox2.Text + "', '" + ComboBox1.Text + "', '" + TextBox4.Text + "', '" + TextBox1.Text + "', '" + TextBox3.Text + "', '" + TextBox5.Text + "', '" + dateTimePicker2.Text + "', '" + textBox6.Text + "')", con1);
                                cmd.ExecuteNonQuery();

                                SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                             SET [Stock] = [Quantity]  WHERE[Code] = '" + TextBox2.Text + "'", con1);
                                cmd1.ExecuteNonQuery();



                                SqlCommand cmd2 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                             SET [Quantity] = 0 WHERE[Code] = '" + TextBox2.Text + "'", con1);

                                cmd2.ExecuteNonQuery();

                                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [dbo].[StockAdd]", con1);
                                DataTable data = new DataTable();
                                sda.Fill(data);
                                DataGridView2.DataSource = data;

                                   int l = 1;
                                


                                  SqlCommand cmd3 = new SqlCommand(@"INSERT INTO[dbo].[ItemWiseRep]
                                  ([Code]
                                  ,[Item]
                                  ,[DateOfPurchase]
                                  ,[PurchaseQty]
                                  ,[Balance Stock]
                                  ,[Publisher]
                                  ,[DateSort]
                                  ,[NUM])

                                    VALUES('" + TextBox2.Text + "', '" + TextBox4.Text + "', '" + dateTimePicker2.Text + "', '" + TextBox5.Text + "', '" + TextBox5.Text + "','" + TextBox3.Text + "', '" + dateTimePicker2.Text + "','" + l + "')", con1);
                                   cmd3.ExecuteNonQuery(); 

                               



                                MessageBox.Show("RECORD ADDED SUCCESSFULLY...!");
                                LoadData();





                            // CodeGen();

                            /*     SqlDataAdapter sda = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE[Code] = '" + TextBox2.Text + "'", con1);
                                 DataTable data = new DataTable();
                                 sda.Fill(data);
                                 DataGridView2.DataSource = data;


                                 SqlCommand cmd4 = new SqlCommand(@"UPDATE [dbo].[ItemWiseRep]
                                  SET [Balance Stock] = '" + DataGridView2.Rows[0].Cells[0].Value + "'  WHERE[Code] = '" + TextBox2.Text + "'", con1);
                                 cmd4.ExecuteNonQuery();*/

                                     LoadItem();

                                Button3_Click(sender, e);
                                //LoadData();
                            }
                            else
                            {
                                MessageBox.Show("CODE INVALID...!");
                            }
                        }
                    }
                    con1.Close();
                
                }
                else
                {
                    MessageBox.Show("DATA NOT ADDED!!", "NULL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
    }
}
