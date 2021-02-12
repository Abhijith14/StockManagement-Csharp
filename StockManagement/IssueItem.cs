using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;

namespace StockManagement
{
    public partial class IssueItem : Form
    {
        readonly string user;
        public IssueItem(string a)
        {
            InitializeComponent();
            user = a;
        }
        STOCKEntities1 db;
        
        
        private void IssueItem_Load(object sender, EventArgs e)
        {
            //TODO: This line of code loads data into the 'sTOCKDataSet.StockAdd' table. You can move, or remove it, as needed.
            this.stockAddTableAdapter.Fill(this.sTOCKDataSet.StockAdd);
            db = new STOCKEntities1();
            db.StockAdds.Load();
            stockAddBindingSource.DataSource = db.StockAdds.Local;
            comboBox2.Text = "";
            textBox4.Text = user;
           
        //    MessageBox.Show(String.Format("Hello {0} ", user));
            // db.Dispose();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");

            comboBox2.Text = "";

            

            if (textBox2.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Code,Class,Subject,Description,QuantityS FROM [dbo].[StockAdd] WHERE Class LIKE'" + textBox2.Text + "'", con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                SqlDataAdapter sda1 = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE Class LIKE'" + textBox2.Text + "'", con);
                DataTable data1 = new DataTable();
                sda1.Fill(data1);
                dataGridView2.DataSource = data1;
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Invoice FROM [dbo].[Invoice]", con);
                DataTable data2 = new DataTable();
                sda2.Fill(data2);
                dataGridView3.DataSource = data2;

                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");

            if (comboBox2.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Code,Class,Subject,Description,QuantityS FROM [dbo].[StockAdd] WHERE Class LIKE '" + textBox2.Text + "' AND Subject LIKE'" + comboBox2.Text + "'", con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                SqlDataAdapter sda1 = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE Class LIKE'" + textBox2.Text + "'", con);
                DataTable data1 = new DataTable();
                sda1.Fill(data1);
                dataGridView2.DataSource = data1;
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            var sqlQuery = "";
            int check = 0;
            int f = 0;
            //CHECK_NULL(check);
            
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("CANT KEEP Invoice Number AS NULL");
                check = 2;
                this.Close();
                IssueItem data = new IssueItem(user);

                data.Show();
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("CANT KEEP Class AS NULL");
                check = 2;
                this.Close();
                IssueItem data = new IssueItem(user);

                data.Show();
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("CANT KEEP Student Name AS NULL");
                this.Close();
                IssueItem data = new IssueItem(user);
                check = 2;
                data.Show();
                textBox3.Focus();
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "")
                {
                    check = 2;
                }
            }

            SqlConnection con2 = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (Convert.ToInt32(textBox1.Text) == Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value))
                    {
                        check = 1;
                        break;
                    }
                }
            
           
            if (check == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        if (Convert.ToInt64(dataGridView2.Rows[i].Cells[0].Value) < Convert.ToInt64(dataGridView1.Rows[i].Cells[4].Value))
                        {
                            int k, a;
                            k = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                            a = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value);

                            if (a == 0)
                            {
                                MessageBox.Show("Stock Error!!", "Error 422", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                // this.Close();
                                f = 1;
                            }
                            else
                            {
                                MessageBox.Show(String.Format("Your Book Code {0} does not contain prescribed Stock.", k), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                DialogResult dialogResult = MessageBox.Show(String.Format("The stock of {0} contains {1} data. Do You Wish To Continue with that Stock ?", k, a), "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    //SqlConnection con2 = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");

                                    dataGridView1.Rows[i].Cells[4].Value = a;
                                    sqlQuery = @"INSERT INTO [dbo].[Orders]
                                ([InvNo]
                                ,[InvDate]
                                ,[IssueDate]
                                ,[StudentName]
                                ,[Class]
                                ,[Code]
                                ,[Quantity]
                                ,[DoneBy])

                                   VALUES ('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + textBox4.Text + "' )";

                                    SqlCommand cmd1 = new SqlCommand(sqlQuery, con2);

                                    con2.Open();
                                    cmd1.ExecuteNonQuery();
                                    cmd1.Dispose();
                                    con2.Close();
                                }

                                else if (dialogResult == DialogResult.No)
                                {
                                    f = 1;
                                    
                                    //  IssueItem_Load(sender, e);//do something else
                                }
                            }
                        }
                        else if(Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value) == 0)
                        {
                            f = 1;
                            int n = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                            MessageBox.Show(string.Format("Quantity Entered at {0} is '0'",n), "Error 422", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else if (Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value) > Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value))

                        {

                            sqlQuery = @"INSERT INTO [dbo].[Orders]
                                ([InvNo]
                                ,[InvDate]
                                ,[IssueDate]
                                ,[StudentName]
                                ,[Class]
                                ,[Code]
                                ,[Quantity]
                                ,[DoneBy])
                                

                                   VALUES ('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + textBox4.Text + "' )";
                            if (f == 0)
                            {
                                SqlCommand cmd1 = new SqlCommand(sqlQuery, con2);

                                con2.Open();
                                cmd1.ExecuteNonQuery();
                                cmd1.Dispose();
                                con2.Close();
                            }

                        }
                       
                    }
                    
                    catch (Exception ex)
                    {
                    if (f == 0)
                    {
                        MessageBox.Show("Please Try AGAIN!!", "Error 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    }
                    

                }
                if (f == 0)
                {
                    SqlConnection con3 = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        SqlCommand cmd3 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                                                  SET [Stock] = [Stock] - '" + dataGridView1.Rows[i].Cells[4].Value + "' WHERE Code = '" + dataGridView1.Rows[i].Cells[0].Value + "'", con3);
                        con3.Open();
                        cmd3.ExecuteNonQuery();
                        cmd3.Dispose();
                        con3.Close();
                    }



                    MessageBox.Show("UPDATED", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SqlCommand cmd4 = new SqlCommand(@"INSERT INTO [dbo].[Invoice]
                                ([Invoice]
                                ,[Name])

                                   VALUES ('" + textBox1.Text + "','" + textBox3.Text + "' )", con3);

                    this.Close();


                    con3.Open();
                    cmd4.ExecuteNonQuery();
                    cmd4.Dispose();
                    con3.Close();
                    //MessageBox.Show("CHECK = 0");
                }
                else 
                {
                   //
                }
            }
            else if(check == 2)
            {
                MessageBox.Show("DATA NOT ADDED!!", "NULL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               MessageBox.Show("DATA ALREADY EXISTS!!", "Error 302", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintItem pro = new PrintItem(textBox2.Text, textBox3.Text,textBox1.Text, dateTimePicker1.Text, dateTimePicker2.Text,user);
           
            pro.Show();
        }

        private void IssueItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
