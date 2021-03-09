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
    public partial class StockReport : Form
    {
        public StockReport()
        {
            InitializeComponent();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");

                if (DateTimePicker1.Text.Length > 0)
                {

                    SqlDataAdapter sda = new SqlDataAdapter("SELECT InvNo,InvDate,IssueDate,StudentName,Class,Code,Subject,Description,Quantity FROM Orders WHERE IssueDate LIKE '" + DateTimePicker1.Text + "'", con);
                    System.Data.DataTable data = new System.Data.DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    sda.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("SQL SERVER ERROR. {0}. Please Try Again!!!", ex), "Error 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT InvNo,InvDate,IssueDate,StudentName,Class,Code,Subject,Description,Quantity FROM [dbo].[Orders];", con);
            System.Data.DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
            sda.Dispose();
        }

        private void StockReport_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            #region ConvertPdf
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount - 1);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            int i = 0;
            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
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
            foreach (DataGridViewRow row in dataGridView1.Rows)
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

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

          
            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
               
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    //  cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    pdfTable.AddCell(cell);
              
            }
            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
               
                foreach (DataGridViewCell cell in row.Cells)
                {
                        pdfTable.AddCell(cell.Value.ToString());
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

        private void StockReport_FormClosed(object sender, FormClosedEventArgs e)
        {
        /*    if (File.Exists(@"C:\\StockManagement DATA\\TEMP1.pdf"))
            {
                File.Delete(@"C:\\StockManagement DATA\\TEMP1.pdf");
            }*/
        }
    }
}
