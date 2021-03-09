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
    public partial class Update_Invoice : Form
    {
        public Update_Invoice()
        {
            InitializeComponent();
        }
        private bool ifInvoiceExists(SqlConnection con1)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT 1 FROM [dbo].[Orders]", con1);
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
        private bool CheckStockExists(string StockNew, string Code)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            SqlDataAdapter sda3 = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE Code LIKE'" + Code + "'", con1);
            DataTable data3 = new DataTable();
            sda3.Fill(data3);
            DataGridView4.DataSource = data3;

            if (Convert.ToInt32(StockNew) <= Convert.ToInt32(DataGridView4.Rows[0].Cells[0].Value))
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
            if (textBox1.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT InvNo,InvDate,IssueDate,StudentName,Class,Code,Subject,Quantity,DoneBy FROM Orders WHERE InvNo LIKE'" + textBox1.Text + "'", con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                SqlDataAdapter sda1 = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE Class LIKE'" + textBox2.Text + "'", con);
                DataTable data1 = new DataTable();
                sda1.Fill(data1);
                dataGridView2.DataSource = data1;
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Quantity FROM [dbo].[Orders] WHERE Class LIKE'" + textBox2.Text + "' AND InvNo = '" + textBox1.Text +"'", con);
                DataTable data2 = new DataTable();
                sda2.Fill(data2);
                dataGridView3.DataSource = data2;
               

            }
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = false;
            dataGridView1.Columns[8].ReadOnly = true;
        }
       
        private void NumChanger(string ID, string Codenum)
        {
            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            con2.Open();
            int idnum = Convert.ToInt32(ID);

            SqlDataAdapter sda = new SqlDataAdapter("SELECT NUM FROM [dbo].[ItemWiseRep] WHERE Code = '" + Codenum + "'", con2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;


            for (int i = 0; i < dataGridView2.Rows.Count+1; i++)
            {
                SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[ItemWiseRep]
                                               SET [NUM] = '" + (idnum + i) + "'  WHERE[Code] = '" + Codenum + "' AND [NUM] = '" + (idnum + i + 1) + "'", con2);
                cmd1.ExecuteNonQuery();

             //   MessageBox.Show(String.Format("{0} to {1}", (idnum + i), (idnum + i + 1)));
            }

        }
        private void LoadItem()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
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
                dataGridView2.DataSource = dt;
                dataGridView2.Sort(dataGridView2.Columns[5], ListSortDirection.Ascending);

                for (int i = 1; i <= dataGridView2.Rows.Count; i++)
                {

                    if (i > 1)
                    {
                        if (dataGridView2.Rows[i - 1].Cells[1].Value.ToString() != "")
                        {
                            int S = Convert.ToInt32(dataGridView2.Rows[i - 1].Cells[1].Value) + Convert.ToInt32(dataGridView2.Rows[i - 2].Cells[4].Value);
                            //  MessageBox.Show(String.Format("{0} + {1} = {2}", DataGridView2.Rows[i - 1].Cells[1].Value, DataGridView2.Rows[i - 2].Cells[4].Value, S));

                            SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[ItemWiseRep]
                                                               SET [Balance Stock] = '" + S + "'  WHERE[Code] = '" + Code + "' AND [NUM] LIKE '" + i + "'", con2);
                            cmd1.ExecuteNonQuery();

                        }
                        else if (dataGridView2.Rows[i - 1].Cells[3].Value.ToString() != "")
                        {
                            int S = Convert.ToInt32(dataGridView2.Rows[i - 2].Cells[4].Value) - Convert.ToInt32(dataGridView2.Rows[i - 1].Cells[3].Value);
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

        private void Update_Invoice_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT InvNo,InvDate,IssueDate,StudentName,Class,Code,Subject,Quantity,DoneBy FROM Orders ", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            

            //}
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = false;
            dataGridView1.Columns[8].ReadOnly = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            int CS = 0;
            con3.Open();
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    CS = 0;
                    int NewData, OldData, Diff;
                    OldData = Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value);
                    NewData = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                    Diff = OldData - NewData;

                    //MessageBox.Show(String.Format("{0} - {1} = {2}",OldData,NewData,Diff));

                    if (Diff != 0)
                    {
                        //           MessageBox.Show("ENTERED!!");
                        if (CheckStockExists(dataGridView1.Rows[i].Cells[7].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString()))
                        {
                            CS = 0;
                        }
                        else
                        {
                            CS = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                            //  return;
                            break;

                        }


                        //      MessageBox.Show(String.Format("CS = {0}", CS));
                    }

                    if (CS == 0 && Diff != 0)
                    {
                        //MessageBox.Show("ENTERED at CS!!");
                        if (Diff > 0)
                        {
                            //  MessageBox.Show("ENTERED at > 0 !!");
                            SqlCommand cmd3 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                                                     SET [Stock] = [Stock] + '" + Diff + "' WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'", con3);

                            cmd3.ExecuteNonQuery();

                            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'", con3);
                            DataTable data1 = new DataTable();
                            sda1.Fill(data1);
                            DataGridView5.DataSource = data1;

                            SqlCommand cmd9 = new SqlCommand(@"UPDATE [dbo].[ItemWiseRep]
                                                           SET [SaleQty] = '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value) + "' WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'AND InvNo = '" + dataGridView1.Rows[i].Cells[0].Value + "'", con3);
                            cmd9.ExecuteNonQuery();
                            //,[Balance Stock] = '" + Convert.ToInt32(DataGridView5.Rows[0].Cells[0].Value) + "'

                           
                            
                        //    MessageBox.Show(String.Format("{0} - {1} = {2}", Convert.ToInt32(DataGridView4.Rows[l - 1].Cells[0].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value), DIFF));
                        }
                        else if (Diff < 0)
                        {
                            //MessageBox.Show("ENTERED at < 0!!");
                            SqlCommand cmd4 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                                                     SET [Stock] = [Stock] + '" + Diff + "' WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'", con3);

                            cmd4.ExecuteNonQuery();

                            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'", con3);
                            DataTable data1 = new DataTable();
                            sda1.Fill(data1);
                            DataGridView5.DataSource = data1;

                            SqlCommand cmd9 = new SqlCommand(@"UPDATE [dbo].[ItemWiseRep]
                                                           SET [SaleQty] = '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value) + "' WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'AND InvNo = '" + dataGridView1.Rows[i].Cells[0].Value + "'", con3);
                            cmd9.ExecuteNonQuery();
                            //,[Balance Stock] = '" + Convert.ToInt32(DataGridView5.Rows[0].Cells[0].Value) + "'

                          
                           // MessageBox.Show(String.Format("{0} - {1} = {2}", Convert.ToInt32(DataGridView4.Rows[l - 1].Cells[0].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value), DIFF));

                        }

                        SqlCommand cmd5 = new SqlCommand(@"UPDATE [dbo].[Orders]
                                                       SET [Quantity] = '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value) + "' WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'AND InvNo = '" + dataGridView1.Rows[i].Cells[0].Value + "'", con3);
                        cmd5.ExecuteNonQuery();



                        if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "0")
                        {

                            //MessageBox.Show("ENTERED 0!!");
                            SqlCommand cmd6 = new SqlCommand(@"DELETE
                                                               FROM [dbo].[Orders]
                                                              WHERE Quantity = '" + dataGridView1.Rows[i].Cells[7].Value + "'AND InvNo = '" + dataGridView1.Rows[i].Cells[0].Value + "'", con3);
                            cmd6.ExecuteNonQuery();

                            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
                            string sqlQ = @"SELECT NUM FROM ItemWiseRep WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'AND InvNo = '" + dataGridView1.Rows[i].Cells[0].Value + "'";
                            SqlCommand cmd = new SqlCommand(sqlQ, con);
                            SqlDataReader myreader;
                            con.Open();
                            myreader = cmd.ExecuteReader();
                            string IDNUM ="";
                            while (myreader.Read())
                            {
                                IDNUM = myreader.GetInt32(0).ToString();
                            }

                            SqlCommand cmd8 = new SqlCommand(@"DELETE
                                                               FROM [dbo].[ItemWiseRep]
                                                               WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'AND InvNo = '" + dataGridView1.Rows[i].Cells[0].Value + "'", con3);
                            cmd8.ExecuteNonQuery();
                       //     SqlCommand cmd9 = new SqlCommand(@"UPDATE [dbo].[ItemWiseRep]
                                                    //           SET [PurCode] = '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value) + "'  WHERE Code = '" + dataGridView1.Rows[i].Cells[5].Value + "'AND InvNo = '" + dataGridView1.Rows[i].Cells[0].Value + "'", con3);
                         //   cmd9.ExecuteNonQuery();

                            NumChanger(IDNUM, dataGridView1.Rows[i].Cells[5].Value.ToString());

                            if (!ifInvoiceExists(con3))
                            {
                                SqlCommand cmd7 = new SqlCommand(@"DELETE
                                                                FROM [dbo].[Invoice]
                                                                WHERE Invoice = '" + textBox1.Text + "'", con3);
                                cmd7.ExecuteNonQuery();
                                MessageBox.Show(String.Format("SUCCESSFULLY DELETED Invoice Number - {0} !!", textBox1.Text));

                            }

                        }


                    }


                }
                if (CS > 0)
                {
                    //record = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                    MessageBox.Show(String.Format("Your Book Code {0} does not contain prescribed Stock.", CS), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 

                if (CS == 0)
                {
                    MessageBox.Show("UPDATED", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                con3.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Pls Try Again!");
            }
            LoadData();
            LoadItem();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            string sql = "SELECT * FROM Orders Where InvNo = '" + textBox1.Text + "'";
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
                SqlDataAdapter sda1 = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE Class LIKE'" + textBox4.Text + "'", con);
                DataTable data1 = new DataTable();
                sda1.Fill(data1);
                dataGridView2.DataSource = data1;
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Quantity FROM [dbo].[Orders] WHERE Class LIKE'" + textBox4.Text + "' AND InvNo = '" + textBox1.Text + "'", con);
                DataTable data2 = new DataTable();
                sda2.Fill(data2);
                dataGridView3.DataSource = data2;
                

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           /* if (e.ColumnIndex ==  7)
            {
                if (dataGridView1.IsCurrentCellDirty)
                {
                    int test = 0;
                    if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(), out test))
                    {
                        MessageBox.Show("NUMBER");
                    }
                    else
                    {
                        MessageBox.Show("NOT A NUMBER!!");
                    }
                }
            }*/
        }
    }
}
