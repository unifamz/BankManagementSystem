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
    public partial class welcome1 : Form
    {
        public welcome1()
        {
            InitializeComponent();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            login1 l = new login1();
            l.MdiParent = this.MdiParent; 
            l.Show();
        }
        private void accountOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deposit o = new deposit();
            o.MdiParent = this.MdiParent;
            o.Show();
        }
        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            withdraw o = new withdraw();
            o.MdiParent = this.MdiParent;
            o.Show();
        }
        private void viewBalaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_balance o = new view_balance();
            o.MdiParent = this.MdiParent;
            o.Show();
        }
        private void adminReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trasaction1 t = new trasaction1();
            t.MdiParent = this.MdiParent;
            t.Show();
        }

        private void loanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loan t = new loan();
            t.MdiParent = this.MdiParent;
            t.Show();
        }

        private void fDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fd f = new fd();
            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_account o = new open_account();
            o.MdiParent = this.MdiParent;
            o.Show();
        }

        private void closedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closed_form c = new closed_form();
            c.MdiParent = this.MdiParent;
            c.Show();
        }
    }
}