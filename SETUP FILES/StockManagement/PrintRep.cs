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
    public partial class PrintRep : Form
    {
        string user;
        public PrintRep(string a)
        {
            InitializeComponent();
            user = a;
        }

        private void PrintRep_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");

            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Code,Class,Subject,Description,Quantity FROM [dbo].[Orders] Where InvNo = '" + TextBox1.Text + "'", con2);
            DataTable data2 = new DataTable();
            sda2.Fill(data2);
            DataGridView1.DataSource = data2;

            string sql = "SELECT * FROM Orders Where InvNo = '" + TextBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con2);
            SqlDataReader myreader;
            con2.Open();
            
            myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                string DateofInv = myreader.GetDateTime(1).ToString();// GetString(1);
                string DateofIss = myreader.GetDateTime(2).ToString();
                string name = myreader.GetString(3);
                string Class = myreader.GetInt32(4).ToString();
                TextBox4.Text = DateofInv.Substring(0,10);
                TextBox5.Text = DateofIss.Substring(0,10);
                TextBox3.Text = name;
                TextBox2.Text = Class;
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                #region Common Part
                PdfPTable pdfTable3 = new PdfPTable(DataGridView1.ColumnCount - 2);
                pdfTable3.DefaultCell.Padding = 3;
                pdfTable3.WidthPercentage = 80;
                pdfTable3.HorizontalAlignment = Element.ALIGN_CENTER;
                // pdfTable3.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfTable3.DefaultCell.BorderWidth = 1;
                //Footer Sectionaa
                PdfPTable pdfTableFooter = new PdfPTable(1);
                pdfTableFooter.DefaultCell.BorderWidth = 0;
                pdfTableFooter.WidthPercentage = 100;
                pdfTableFooter.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


                Chunk cnkFooter = new Chunk("                                                                                                                                          SIGNATURE", FontFactory.GetFont("Times New Roman"));
                cnkFooter.Font.SetStyle(1);
                cnkFooter.Font.Size = 10;
                pdfTableFooter.AddCell(new Phrase(cnkFooter));

                Chunk e1 = new Chunk("                                                                                                                                                  '" + user + "'", FontFactory.GetFont("Times New Roman"));
                e1.Font.SetStyle(0);
                e1.Font.Size = 10;
                pdfTableFooter.AddCell(new Phrase(e1));
                //End Of Footer Section



                #endregion

                #region Page
                #region Section-1

                PdfPTable pdfTable1 = new PdfPTable(1);//Here 1 is Used For Count of Column
                PdfPTable pdfTable2 = new PdfPTable(1);
                PdfPTable pdfTable4 = new PdfPTable(1);
                PdfPTable pdfTable5 = new PdfPTable(1);

                //Font Style
                System.Drawing.Font fontH1 = new System.Drawing.Font("Bookman Old Style Bold", 16);

                pdfTable1.DefaultCell.Padding = 5;
                pdfTable1.WidthPercentage = 80;
                pdfTable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
               //// pdfTable1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170);
                pdfTable1.DefaultCell.BorderWidth = 0;


                pdfTable1.DefaultCell.Padding = 5;
                pdfTable2.WidthPercentage = 80;
                pdfTable2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable2.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
               // pdfTable1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170);
                pdfTable2.DefaultCell.BorderWidth = 0;

                pdfTable4.DefaultCell.Padding = 0;
                pdfTable4.WidthPercentage = 80;
                pdfTable4.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable4.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfTable4.DefaultCell.BorderWidth = 0;

                pdfTable5.DefaultCell.Padding = 0;
                pdfTable5.WidthPercentage = 80;
                pdfTable5.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable5.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfTable5.DefaultCell.BorderWidth = 0;

                Chunk c14 = new Chunk(" ");
                Phrase p14 = new Phrase();
                p14.Add(c14);
                pdfTable5.AddCell(p14);


                // Chunk c1 = new Chunk("" + TextBox6.Text +"");//("Jyothis Central School", FontFactory.GetFont("Bookman Old Style Bold"));
                Chunk c1 = new Chunk("Jyothis Central School");//, FontFactory.GetFont("Bookman Old Style Bold"));
                c1.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c1.Font.SetStyle(0);
                c1.Font.Size = 14;
                Phrase p1 = new Phrase();
                p1.Add(c1);
                pdfTable1.AddCell(p1);
                Chunk c2 = new Chunk("KAZHAKUTTOM P.O, Tvpm - 695582", FontFactory.GetFont("Times New Roman"));
                c2.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c2.Font.SetStyle(0);
                c2.Font.Size = 11;
                Phrase p2 = new Phrase();
                p2.Add(c2);
                pdfTable2.AddCell(p2);
                Chunk c3 = new Chunk("Ph: 0471 - 2705857, 6548751, 2925751, 2415751", FontFactory.GetFont("Times New Roman"));
                c3.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c3.Font.SetStyle(0);
                c3.Font.Size = 11;
                Phrase p3 = new Phrase();
                p3.Add(c3);
                pdfTable2.AddCell(p3);
                Chunk c4 = new Chunk(" ");
                Phrase p4 = new Phrase();
                p4.Add(c4);
                pdfTable2.AddCell(p4);

                Chunk c9 = new Chunk(" BOOK RECEIPT ");
                Phrase p9 = new Phrase();
                p9.Add(c9);
                pdfTable2.AddCell(p9);

                Chunk c11 = new Chunk("----------------------- ");
                Phrase p11 = new Phrase();
                p11.Add(c11);
                pdfTable2.AddCell(p11);

                Chunk c10 = new Chunk(" ");
                Phrase p10 = new Phrase();
                p10.Add(c10);
                pdfTable4.AddCell(p10);

                Chunk c5 = new Chunk("Student Name = '" + TextBox3.Text + "'                                                            Invoice Number = '" + TextBox1.Text + "'", FontFactory.GetFont("Times New Roman"));
                c5.Font.Size = 10;
                Phrase p5 = new Phrase();
                p5.Add(c5);
                pdfTable4.AddCell(p5);

                Chunk c6 = new Chunk(" ");
                Phrase p6 = new Phrase();
                p6.Add(c6);
                pdfTable4.AddCell(p6);

                Chunk c7 = new Chunk("Class = '" + TextBox2.Text + "'                                                                                           Date Of Invoice = '" + TextBox4.Text + "'", FontFactory.GetFont("Times New Roman"));
                c7.Font.Size = 10;
                Phrase p7 = new Phrase();
                p7.Add(c7);
                pdfTable4.AddCell(p7);

                Chunk c8 = new Chunk(" ");
                Phrase p8 = new Phrase();
                p8.Add(c8);
                pdfTable4.AddCell(p8);

                Chunk c12 = new Chunk("Date Of Issue = '" + TextBox5.Text + "'", FontFactory.GetFont("Times New Roman"));
                c12.Font.Size = 10;
                Phrase p12 = new Phrase();
                p12.Add(c12);
                pdfTable4.AddCell(p12);

                Chunk c13 = new Chunk(" ");
                Phrase p13 = new Phrase();
                p13.Add(c13);
                pdfTable4.AddCell(p13);
                pdfTable4.AddCell(p13);

                #endregion
                #region Section-1

                #endregion
                #region Section-Image

                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("JCS Logo.jpg");

                //Resize image depend upon your need
                jpg.ScaleToFit(100f, 80f);
                //Give space before image
                jpg.SpacingBefore = 10f;
                //Give some space after the image
                jpg.SpacingAfter = 100f;

                jpg.Alignment = Element.ALIGN_CENTER;
                #endregion

                #region section Table
                int i = 0;
                foreach (DataGridViewColumn column in DataGridView1.Columns)
                {
                    i++;
                    if (i > 2)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        pdfTable3.AddCell(cell);
                    }

                }
                //Adding DataRow
                foreach (DataGridViewRow row in DataGridView1.Rows)
                {
                    i = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        i++;
                        if (i > 2)
                        {
                            pdfTable3.AddCell(cell.Value.ToString());
                        }

                    }
                }


                #endregion

                #endregion


                #region Pdf Generation
                string folderPath = "C:\\StockManagement Data\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                //File Name
                //int fileCount = Directory.GetFiles("C:\\StockManagement Data\\").Length;
                string strFileName = "Invoice of '" + TextBox1.Text + "'.pdf"; //" + (fileCount + 1) + ".pdf";

                using (FileStream stream = new FileStream(folderPath + strFileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    #region PAGE-1
                    pdfDoc.Add(pdfTable5);
                    pdfDoc.Add(jpg);
                    pdfDoc.Add(pdfTable5);
                    pdfDoc.Add(pdfTable1);
                    pdfDoc.Add(pdfTable2);
                    pdfDoc.Add(pdfTable4);
                    pdfDoc.Add(pdfTable3);
                    pdfDoc.Add(pdfTable5);
                    pdfDoc.Add(pdfTable5);
                    pdfDoc.Add(pdfTable5);
                    pdfDoc.Add(pdfTable5);
                    pdfDoc.Add(pdfTableFooter);

                    pdfDoc.NewPage();
                    #endregion


                    pdfDoc.Close();
                    stream.Close();
                }
                #endregion

                #region Display PDF
                System.Diagnostics.Process.Start(folderPath + "\\" + strFileName);
                #endregion

            }
            catch (Exception ex)
            {

                throw;
            }

            TextBox1.Text = "0";
            Button2_Click(sender, e);
            TextBox1.Clear();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
