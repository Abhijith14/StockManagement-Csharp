using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class StockMain : Form
    {
        // private int childFormNumber = 0;
        int close = 0;
        string user;
        string b = "admin";
        string c = "ACHU";
        public StockMain(string a)
        {
            InitializeComponent();
            user = a;
        }

       
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 0)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to exit? Any unsaved progress will be lost!!", "WARNING", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    this.Hide();
                    close = 1;
                    Login main = new Login();
                    main.Show();
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;

                }
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            close = 1;
            Login main = new Login();
            main.Show();
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.Compare(b, user, true) == 0 || string.Compare(c, user, true) == 0)
            {
                AddUser pro = new AddUser();
                pro.MdiParent = this;
                pro.Show();
            }
            else
            {
                MessageBox.Show("UNAUTHORIZED ACCESS!! The requested option can only be accessed using admin rights.", "Error 401", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.Compare(b, user, true) == 0 || string.Compare(c, user, true) == 0)
            {
                ADDSTOCK pro = new ADDSTOCK();
                pro.MdiParent = this;
                pro.Show();
            }
            else
            {
                MessageBox.Show("UNAUTHORIZED ACCESS!! The requested option can only be accessed using admin rights.", "Error 401", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void invoiceEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.Compare(b, user, true) == 0 || string.Compare(c, user, true) == 0)
            {
                Update_Invoice pro = new Update_Invoice();
                pro.MdiParent = this;
                pro.Show();
            }
            else
            {
                MessageBox.Show("UNAUTHORIZED ACCESS!! The requested option can only be accessed using admin rights.", "Error 401", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StockMain_Load(object sender, EventArgs e)
        {

        }

        private void oldReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReport pro = new StockReport();
            pro.MdiParent = this;
            pro.Show();
        }

        private void itemWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemWiseRep pro = new ItemWiseRep();
            pro.MdiParent = this;
            pro.Show();
        }

        private void dataEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueItem pro = new IssueItem(user);
            pro.MdiParent = this;
            pro.Show();
        }

        private void printDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintRep pro = new PrintRep(user);
            pro.MdiParent = this;
            pro.Show();
        }
    }
}
