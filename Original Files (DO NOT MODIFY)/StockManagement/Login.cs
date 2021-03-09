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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }
       

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StockManagement.mdf;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM Login WHERE UserName = '" + TextBox1.Text + "' AND Password = '" + TextBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    StockMain main = new StockMain(TextBox1.Text);
                    main.Show();
                }
                else
                {
                    MessageBox.Show("INVALID CREDENTIALS...!", "Error 401", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Button2_Click(sender, e);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please Try Again!.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Clear();
            TextBox1.Focus();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        

        private void Button3_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox2.PasswordChar = '*';
            TextBox2.Focus();
        }

        private void Button3_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox2.PasswordChar = '\0';
        }
    }
}
