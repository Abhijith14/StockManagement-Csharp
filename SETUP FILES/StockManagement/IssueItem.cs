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
using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace TEST
{
    public partial class IssueItem : Form
    {
        readonly string user;
        public IssueItem(string a)
        {
            InitializeComponent();
            user = a;
        }
        StockManagementEntities db;
        int TABLE = 0;
        int success = 0;
        private void IssueItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockManagementDataSet2.StockAdd' table. You can move, or remove it, as needed.
            this.stockAddTableAdapter.Fill(this.stockManagementDataSet2.StockAdd);

            db = new StockManagementEntities();
            db.StockAdds.Load();
            stockAddBindingSource.DataSource = db.StockAdds.Local;
            ComboBox2.Text = "";
            TextBox4.Text = user;
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

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");

            ComboBox2.Text = "";

       //     if (success == 2)
         //   {

                if (TextBox2.Text.Length > 0)
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT Code,Class,Subject,Description,QuantityS Quantity FROM [dbo].[StockAdd] WHERE Class LIKE'" + TextBox2.Text + "'", con);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    DataGridView1.DataSource = data;
                    SqlDataAdapter sda1 = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE Class LIKE'" + TextBox2.Text + "'", con);
                    DataTable data1 = new DataTable();
                    sda1.Fill(data1);
                    DataGridView2.DataSource = data1;
                    SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Invoice FROM [dbo].[Invoice]", con);
                    DataTable data2 = new DataTable();
                    sda2.Fill(data2);
                    DataGridView3.DataSource = data2;

                    DataGridView1.Columns[0].ReadOnly = true;
                    DataGridView1.Columns[1].ReadOnly = true;
                    DataGridView1.Columns[2].ReadOnly = true;
                    DataGridView1.Columns[3].ReadOnly = true;

                }
          //  }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");

                if (ComboBox2.Text.Length > 0)
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT Code,Class,Subject,Description,QuantityS Quantity FROM [dbo].[StockAdd] WHERE Class LIKE '" + TextBox2.Text + "' AND Subject LIKE'" + ComboBox2.Text + "'", con);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    DataGridView1.DataSource = data;
                    SqlDataAdapter sda1 = new SqlDataAdapter("SELECT Stock FROM [dbo].[StockAdd] WHERE Class LIKE'" + TextBox2.Text + "'", con);
                    DataTable data1 = new DataTable();
                    sda1.Fill(data1);
                    DataGridView2.DataSource = data1;
                }
            
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
        {

            success = 0;

            var sqlQuery = "";
            int check = 0;
            int f = 0;
            //CHECK_NULL(check);




            if (TextBox1.Text == "")
            {
                MessageBox.Show("CANT KEEP Invoice Number AS NULL");
                check = 2;
                this.Close();
                IssueItem data = new IssueItem(user);

                data.Show();
                TextBox1.Focus();
            }
            else if (TextBox2.Text == "")
            {
                MessageBox.Show("CANT KEEP Class AS NULL");
                check = 2;
                this.Close();
                IssueItem data = new IssueItem(user);

                data.Show();
                TextBox2.Focus();
            }
            else if (TextBox3.Text == "")
            {
                MessageBox.Show("CANT KEEP Student Name AS NULL");
                this.Close();
                IssueItem data = new IssueItem(user);
                check = 2;
                data.Show();
                TextBox3.Focus();
            }

           

            for (int i = 0; i < DataGridView3.Rows.Count; i++)
            {
                if (Convert.ToInt32(TextBox1.Text) == Convert.ToInt32(DataGridView3.Rows[i].Cells[0].Value))
                {
                    check = 1;
                    break;
                }
            }

            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");

            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Invoice FROM [dbo].[Invoice] WHERE Invoice = '" + TextBox1.Text + "'", con2);
            DataTable data2 = new DataTable();
            sda2.Fill(data2);
            DataGridView5.DataSource = data2;

            if (DataGridView5.Rows.Count > 0)
            {
                if (TextBox1.Text == DataGridView5.Rows[0].Cells[0].Value.ToString())
                {
                    success = 1;
                }
            }
            if (success == 0)
            {
                if (check == 0)
                {

                    for (int j = 0; j < DataGridView1.Rows.Count; j++)
                    {
                        int test = 0;
                        if (DataGridView1.Rows[j].Cells[4].Value.ToString() == "")
                        {
                            test = 1;
                        }
                        if (test == 0)
                        {
                            if (Convert.ToInt32(DataGridView1.Rows[j].Cells[4].Value) == 0)
                            {
                                int n = Convert.ToInt32(DataGridView1.Rows[j].Cells[0].Value);
                                DialogResult dialogResult = MessageBox.Show(String.Format("Quantity Entered at {0} is '0'. Do You Wish To Continue Ignoring that Stock ?", n), "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.No)
                                {
                                    f = 1;
                                }
                                else if (dialogResult == DialogResult.Yes)
                                {
                                    f = 0;
                                }

                            }
                        }
                    }
                    for (int i = 0; i < DataGridView1.Rows.Count; i++)
                    {
                        try
                        {

                            if (Convert.ToInt64(DataGridView2.Rows[i].Cells[0].Value) < Convert.ToInt64(DataGridView1.Rows[i].Cells[4].Value))
                            {
                                int k, a;
                                k = Convert.ToInt32(DataGridView1.Rows[i].Cells[0].Value);
                                a = Convert.ToInt32(DataGridView2.Rows[i].Cells[0].Value);

                                if (a == 0)
                                {
                                    MessageBox.Show("Stock Error!!", "Error 422", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    LoadItem();
                                 //    this.Close();
                                    f = 1;
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show(String.Format("Your Book Code {0} does not contain prescribed Stock.", k), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    DialogResult dialogResult = MessageBox.Show(String.Format("The stock of {0} contains {1} data. Do You Wish To Continue with that Stock ?", k, a), "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        //SqlConnection con2 = new SqlConnection("Data Source=.;Initial Catalog=STOCK;Integrated Security=True");

                                        DataGridView1.Rows[i].Cells[4].Value = a;
                                        sqlQuery = @"INSERT INTO [dbo].[Orders]
                                        ([InvNo]
                                        ,[InvDate]
                                        ,[IssueDate]
                                        ,[StudentName]
                                        ,[Class]
                                        ,[Code]
                                        ,[Quantity]
                                        ,[DoneBy]
                                        ,[Subject]
                                        ,[Description])

                                           VALUES ('" + TextBox1.Text + "','" + DateTimePicker1.Text + "','" + DateTimePicker2.Text + "','" + TextBox3.Text + "','" + TextBox2.Text + "','" + DataGridView1.Rows[i].Cells[0].Value + "','" + DataGridView1.Rows[i].Cells[4].Value + "','" + TextBox4.Text + "','" + DataGridView1.Rows[i].Cells[2].Value + "','" + DataGridView1.Rows[i].Cells[3].Value + "' )";

                                        SqlCommand cmd1 = new SqlCommand(sqlQuery, con2);

                                        con2.Open();
                                        cmd1.ExecuteNonQuery();
                                        cmd1.Dispose();

                                        SqlDataAdapter sda8 = new SqlDataAdapter("SELECT NUM FROM [dbo].[ItemWiseRep] WHERE [Code] = '" + DataGridView1.Rows[i].Cells[0].Value + "'", con2);
                                        DataTable data8 = new DataTable();
                                        sda8.Fill(data8);
                                        DataGridView4.DataSource = data8;

                                        int l = DataGridView4.Rows.Count;
                                        //int DIFF = 0;//Convert.ToInt32(DataGridView4.Rows[l - 1].Cells[0].Value) - Convert.ToInt32(DataGridView1.Rows[i].Cells[4].Value);


                                        SqlCommand cmd3 = new SqlCommand(@"INSERT INTO[dbo].[ItemWiseRep]
                                                                 ([Code]
                                                                 ,[Item]
                                                                 ,[DateOfSale]
                                                                 ,[SaleQty]
                                                                 ,[Balance Stock]
                                                                 ,[InvNo]
                                                                 ,[StudentName]
                                                                 ,[DateSort]
                                                                 ,[NUM])

                           
                                            VALUES('" + DataGridView1.Rows[i].Cells[0].Value + "', '" + DataGridView1.Rows[i].Cells[2].Value + "', '" + DateTimePicker2.Text + "', '" + DataGridView1.Rows[i].Cells[4].Value + "', '" + 0 + "','" + TextBox1.Text + "','" + TextBox3.Text + "', '" + DateTimePicker2.Text + "','" + (l + 1) + "')", con2);

                                        cmd3.ExecuteNonQuery();

                                        con2.Close();
                                        TABLE = 1;
                                    }

                                    else if (dialogResult == DialogResult.No)
                                    {
                                        f = 1;
                                        return;
                                        // break;
                                        //  IssueItem_Load(sender, e);//do something else
                                    }
                                }

                            }
                            else if (Convert.ToInt32(DataGridView1.Rows[i].Cells[4].Value) == 0)
                            {
                                f = 0;
                                // MessageBox.Show("HELLO 0");
                            }
                            else if (Convert.ToInt32(DataGridView2.Rows[i].Cells[0].Value) > Convert.ToInt32(DataGridView1.Rows[i].Cells[4].Value))
                            {
                                if (f == 0)
                                {
                                  //  MessageBox.Show("ENTERED");
                                    sqlQuery = @"INSERT INTO [dbo].[Orders]
                                    ([InvNo]
                                    ,[InvDate]
                                    ,[IssueDate]
                                    ,[StudentName]
                                    ,[Class]
                                    ,[Code]
                                    ,[Quantity]
                                    ,[DoneBy]
                                    ,[Subject]
                                    ,[Description])
                                

                                    VALUES ('" + TextBox1.Text + "','" + DateTimePicker1.Text + "','" + DateTimePicker2.Text + "','" + TextBox3.Text + "','" + TextBox2.Text + "','" + DataGridView1.Rows[i].Cells[0].Value + "','" + DataGridView1.Rows[i].Cells[4].Value + "','" + TextBox4.Text + "','" + DataGridView1.Rows[i].Cells[2].Value + "','" + DataGridView1.Rows[i].Cells[3].Value + "' )";

                                    SqlCommand cmd1 = new SqlCommand(sqlQuery, con2);

                                    con2.Open();
                                    cmd1.ExecuteNonQuery();
                                    //cmd1.Dispose();
                                    
                                    SqlDataAdapter sda8 = new SqlDataAdapter("SELECT NUM FROM [dbo].[ItemWiseRep] WHERE [Code] = '" + DataGridView1.Rows[i].Cells[0].Value + "'", con2);
                                    DataTable data8 = new DataTable();
                                    sda8.Fill(data8);
                                    DataGridView4.DataSource = data8;
                                   // MessageBox.Show("ENTERED");
                                    int l = DataGridView4.Rows.Count;
                                    //   int DIFF = 0;//Convert.ToInt32(DataGridView4.Rows[l - 1].Cells[0].Value) - Convert.ToInt32(DataGridView1.Rows[i].Cells[4].Value);
                                  //  MessageBox.Show("ENTERED");
                                    SqlCommand cmd3 = new SqlCommand(@"INSERT INTO[dbo].[ItemWiseRep]
                                                                 ([Code]
                                                                 ,[Item]
                                                                 ,[DateOfSale]
                                                                 ,[SaleQty]
                                                                 ,[Balance Stock]
                                                                 ,[InvNo]
                                                                 ,[StudentName]
                                                                 ,[DateSort]
                                                                 ,[NUM])

                           
                                    VALUES('" + DataGridView1.Rows[i].Cells[0].Value + "', '" + DataGridView1.Rows[i].Cells[2].Value + "', '" + DateTimePicker2.Text + "', '" + DataGridView1.Rows[i].Cells[4].Value + "', '" + 0 + "','" + TextBox1.Text + "','" + TextBox3.Text + "', '" + DateTimePicker2.Text + "','" + (l + 1) + "')", con2);
                                   // MessageBox.Show("ENTERED!!!");
                                    cmd3.ExecuteNonQuery();
                                  //  MessageBox.Show("ENTERED");
                                    con2.Close();
                                    TABLE = 1;
                                   // MessageBox.Show(String.Format(" T = {0}", TABLE));
                                }

                            }



                        }

                        catch (Exception)
                        {
                            if (f == 0)
                            {
                                Thread.Sleep(1);
                            }
                        }


                    }

                    if (f == 0 && TABLE == 1)
                    {
                        SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");

                        for (int i = 0; i < DataGridView1.Rows.Count; i++)
                        {

                            SqlCommand cmd3 = new SqlCommand(@"UPDATE [dbo].[StockAdd]
                                                  SET [Stock] = [Stock] - '" + DataGridView1.Rows[i].Cells[4].Value + "' WHERE Code = '" + DataGridView1.Rows[i].Cells[0].Value + "'", con3);
                            con3.Open();
                            cmd3.ExecuteNonQuery();
                            cmd3.Dispose();
                            con3.Close();
                        }



                        MessageBox.Show("UPDATED", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand cmd4 = new SqlCommand(@"INSERT INTO [dbo].[Invoice]
                                ([Invoice]
                                ,[Name])

                                   VALUES ('" + TextBox1.Text + "','" + TextBox3.Text + "' )", con3);

                        LoadItem();

                        //                        this.Close();

                       
                         
                        con3.Open();
                        cmd4.ExecuteNonQuery();
                        cmd4.Dispose();
                        con3.Close();
                        //MessageBox.Show("CHECK = 0");

                        
                        TextBox1.Clear();
                        TextBox2.Text = "0";
                        TextBox3.Clear();
                        TextBox5.Clear();
                        ComboBox2.Text = "";
                        TextBox2.Clear();

                    }
                    else
                    {
                        MessageBox.Show("DATA NOT ADDED!!", "NULL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      
                    }
                }
                else if (check == 2)
                {
                    MessageBox.Show("DATA NOT ADDED!!!", "NULL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Invoice Number ALREADY EXISTS!!", "Error 302", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (success ==  1)
            {
                MessageBox.Show("Invoice Number ALREADY EXISTS!!", "Error 302", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (TextBox5.Text.Length > 0)
            {
                for (int i = 0; i < DataGridView1.Rows.Count; i++)
                {
                        DataGridView1.Rows[i].Cells[4].Value = TextBox5.Text;
                }
                
            }
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
          
        }

       

       
    }
}
