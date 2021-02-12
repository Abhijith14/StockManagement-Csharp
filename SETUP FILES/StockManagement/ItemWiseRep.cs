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
using System.Reflection;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;

namespace TEST
{
    public partial class ItemWiseRep : Form
    {
        int Length = 0;
        public ItemWiseRep()
        {
            InitializeComponent();
            // LoadItem();
            FINALISE();
        }
       
        private void ItemWiseRep_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockManagementDataSet5.StockAdd' table. You can move, or remove it, as needed.
            this.stockAddTableAdapter1.Fill(this.stockManagementDataSet5.StockAdd);
            // TODO: This line of code loads data into the 'stockManagementDataSet4.ItemWiseRep' table. You can move, or remove it, as needed.
           // this.itemWiseRepTableAdapter1.Fill(this.stockManagementDataSet4.ItemWiseRep);
            // TODO: This line of code loads data into the 'stockManagementDataSet3.StockAdd' table. You can move, or remove it, as needed.
        //    this.stockAddTableAdapter.Fill(this.stockManagementDataSet3.StockAdd);
            // TODO: This line of code loads data into the 'stockManagementDataSet3.ItemWiseRep' table. You can move, or remove it, as needed.
          //  this.itemWiseRepTableAdapter.Fill(this.stockManagementDataSet3.ItemWiseRep);
            comboBox1.Text = " ";
        }
        public void FINALISE()
        {
            for (int i = 0;i < Length; i++)
            {
                LoadItem();
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
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Code,PurchaseQty,InvNo,SaleQty,[Balance Stock],NUM FROM [dbo].[ItemWiseRep] WHERE Code = '"+ Code +"'", con1);
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);
                DataGridView2.DataSource = dt;
                DataGridView2.Sort(DataGridView2.Columns[5], ListSortDirection.Ascending);
                Length = DataGridView2.Rows.Count;
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
                        else if(DataGridView2.Rows[i - 1].Cells[3].Value.ToString() != "")
                        {
                            int S = Convert.ToInt32(DataGridView2.Rows[i - 2].Cells[4].Value) - Convert.ToInt32(DataGridView2.Rows[i - 1].Cells[3].Value);
                            MessageBox.Show(String.Format("{0} - {1} = {2} , {3}",Convert.ToInt32(DataGridView2.Rows[i - 2].Cells[4].Value), Convert.ToInt32(DataGridView2.Rows[i - 1].Cells[3].Value),S,(i-1)));
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


        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Code,Item,Publisher,DateOfPurchase,PurchaseQty,InvNo,StudentName,DateOfSale,SaleQty,[Balance Stock],DateSort FROM [dbo].[ItemWiseRep];", con);
            System.Data.DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            DataGridView1.DataSource = dt;

            
            
            con.Close();
            sda.Dispose();


               DataGridView1.Sort(DataGridView1.Columns[10], ListSortDirection.Descending);
           // DataGridView1.Sort(DataGridView1.Columns[11], ListSortDirection.Ascending);
            DataGridView1.Columns["DateSort"].Visible = false;
            //DataGridView1.Columns["NUM"].Visible = false;
            comboBox1.Text = " ";
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");

            if (comboBox1.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Code,Item,Publisher,DateOfPurchase,PurchaseQty,InvNo,StudentName,DateOfSale,SaleQty,[Balance Stock],NUM FROM [dbo].[ItemWiseRep] WHERE Code LIKE '" + comboBox1.Text + "'", con);
                System.Data.DataTable data = new System.Data.DataTable();
                sda.Fill(data);
                
                DataGridView1.DataSource = data;

                DataGridView1.Sort(DataGridView1.Columns[10], ListSortDirection.Ascending);

                DataGridView1.Columns["NUM"].Visible = false;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

       /*     SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Code,Item,Publisher,DateOfPurchase,PurchaseQty,InvNo,StudentName,DateOfSale,SaleQty,[Balance Stock] FROM [dbo].[ItemWiseRep];", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridView1.DataSource = dt;*/

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(DataGridView1.ColumnCount - 1);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            int i = 0;
            //Adding Header row
            foreach (DataGridViewColumn column in DataGridView1.Columns)
            {
                i++;
                if (i < 11)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    //  cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    pdfTable.AddCell(cell);
                }
               // MessageBox.Show(String.Format(" No = {0}", i));
            }
            //Adding DataRow
            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                i = 0;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    i++;
                    if (i < 11)
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                     }
                   // MessageBox.Show(String.Format(" No = {0}", i));
                }
            }

            //Exporting to PDF
            SaveFileDialog abc = new SaveFileDialog();
            //FolderBrowserDialog abc = new FolderBrowserDialog();
            string path = "C:\\StockManagement DATA\\";
            abc.Filter = "PDF File|*.pdf";
            abc.FileName = "Item Wise";
            abc.Title = "Export Report as PDF";
            if (abc.ShowDialog() == DialogResult.OK)
            {
                path = abc.FileName;
            }
            string folderPath = path;//"C:\\StockManagement DATA\\";
      
            /*     if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            } */

            using (FileStream stream = new FileStream(folderPath, FileMode.Create))
            {
               // var pgSize = new iTextSharp.text.Rectangle(1090, 792);
                Document pdfDoc = new Document(PageSize.A2, 10, -2500, 10, 0); // left ,   , top,
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
            MessageBox.Show("SUCCESFULLY EXPORTED !");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
          //  try
         ///   {
                #region ConvertPdf
                PdfPTable pdfTable = new PdfPTable(DataGridView1.ColumnCount - 1);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 30;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;

                int i = 0;
                //Adding Header row
                foreach (DataGridViewColumn column in DataGridView1.Columns)
                {
                    i++;
                    if (i < 11)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        //  cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTable.AddCell(cell);
                    }
                    // MessageBox.Show(String.Format(" No = {0}", i));
                }
                //Adding DataRow
                foreach (DataGridViewRow row in DataGridView1.Rows)
                {
                    i = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        i++;
                        if (i < 11)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                        // MessageBox.Show(String.Format(" No = {0}", i));
                    }
                }
                string folderPath = "C:\\StockData\\TempFiles\\TEMP.pdf";
                using (FileStream stream = new FileStream(folderPath, FileMode.Create))
                {
                    // var pgSize = new iTextSharp.text.Rectangle(1090, 792);
                    Document pdfDoc = new Document(PageSize.A2, 10, -2500, 10, 0); // left ,   , top,
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }

            #endregion

                SaveFileDialog abc = new SaveFileDialog();
               
                string path = "C:\\StockManagement DATA\\";
                abc.Filter = "EXCEL File|*.xls";
                abc.FileName = "Item Wise";
                abc.Title = "Export Report as EXCEL";
                if (abc.ShowDialog() == DialogResult.OK)
                {
                    path = abc.FileName;
                }


                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                f.OpenPdf(folderPath);
                f.ToExcel(path);
                MessageBox.Show("SUCCESFULLY EXPORTED !");

               
              
           // }
       //     catch (Exception ex)
      //      {
       //         MessageBox.Show("Please Try Again !!");
         //   }
        }

        private void ItemWiseRep_FormClosed(object sender, FormClosedEventArgs e)
        {
           /* if (File.Exists(@"C:\\StockManagement DATA\\TEMP.pdf"))
            {
                File.Delete(@"C:\\StockManagement DATA\\TEMP.pdf");
            }*/
        }
    }
}
