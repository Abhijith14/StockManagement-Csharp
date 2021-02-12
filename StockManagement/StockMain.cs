using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement
{
    public partial class StockMain : Form
    {
        private int childFormNumber = 0;
        string user;
        public StockMain(String a)
        {
            InitializeComponent();
            user = a;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void StockMain_Load(object sender, EventArgs e)
        {

        }
        string b = "admin";
        private void itemEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            IssueItem pro = new IssueItem(user);
            pro.MdiParent = this;
            pro.Show();


        }

        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit? Any unsaved progress will be lost!!", "WARNING", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if (use1 == 1)
            //{ MessageBox.Show("Admin Only!!!!"); }
            if (string.Compare(b, user, true) == 0)
            {
                ADDSTOCK pro = new ADDSTOCK();
                pro.MdiParent = this;
                pro.Show();
            }
            else
            {
                MessageBox.Show("Admin Only....!");
            }
        }

        private void modifyDefaultDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.Compare(b, user, true) == 0)
            {
                Update_Invoice pro = new Update_Invoice();
                pro.MdiParent = this;
                pro.Show();
            }
            else
            {
                MessageBox.Show("Admin Only....!");
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (use1 == 1)
            {
                MessageBox.Show("Admin Only!!!!");
                
            }*/

            if (string.Compare(b, user, true) == 0)
            {
                AddUser pro = new AddUser();
                pro.MdiParent = this;
                pro.Show();
            }
            else
            {
                MessageBox.Show("ADMIN ONLY....!");
            }
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (string.Compare(b, user, true) == 0)
            // {
            //   MessageBox.Show("Currently in Progress...!. Will Be Released Soon._.");
            //}
                StockReport pro = new StockReport();
                pro.MdiParent = this;
                pro.Show();
           
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

              this.Hide();
              Login main = new Login();
              main.Show();

            /// <summary>
            /// The main entry point for the application.
            /// </summary>
        
        
    }
             
    

        

        //  Application.EnableVisualStyles();
        //   Application.SetCompatibleTextRenderingDefault(false);
        // Form.ShowDialog(new Login);
        //Application.Run(new Login());
    
    }
}
