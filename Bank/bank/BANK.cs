using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace bank
{
    public partial class BANK : Form
    {
        private int childFormNumber = 0;
        public BANK()
        {
            InitializeComponent();
            editMenu.Text = "Login";
            editMenu.Visible = true;
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
        public static int t = 0;
        public static int r = 0;
        private void fileMenu_Click(object sender, EventArgs e)
        {
                employee1 w = new employee1();
                w.MdiParent = this;
                w.Show();
                t++;
            
        }
       
       public  void editMenu_Click(object sender, EventArgs e)
        {
          
               login1 l = new login1();
               l.MdiParent = this;
               l.Show();
               r++;
           
        }
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Close();
        }
        private void BANK_Load(object sender, EventArgs e)
        {
            menuStrip.Visible = true;
        }
        private void accountOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_account o = new open_account();
            o.MdiParent = this;
            o.Show();
        }
        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
             deposit o = new deposit();
            o.MdiParent = this;
            o.Show();
        }
        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            withdraw o = new withdraw();
            o.MdiParent = this;
            o.Show();
        }
        private void viewBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_balance o = new view_balance();
            o.MdiParent = this;
            o.Show();
        }
        private void adminReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_admin_report o = new view_admin_report();
            o.MdiParent = this;
            o.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_admin_report o = new view_admin_report();
            o.MdiParent = this.MdiParent;
            o.Show();
        }
    }
}