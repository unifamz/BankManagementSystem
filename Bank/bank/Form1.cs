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
    public partial class Form1 : Form
    {
       public Form1()
        {
            InitializeComponent();
            
        }
       private void button1_Click(object sender, EventArgs e)
       {
           open_account o = new open_account();
           o.ShowDialog();
       }
       private void button2_Click(object sender, EventArgs e)
       {
           deposit d = new deposit();
           d.ShowDialog();
       }
       private void button3_Click(object sender, EventArgs e)
       {
           withdraw w = new withdraw();
           w.ShowDialog();
       }
       private void button4_Click(object sender, EventArgs e)
       {
           view_balance v = new view_balance();
           v.ShowDialog();
       }
       private void button5_Click(object sender, EventArgs e)
       {
           view_admin_report vi = new view_admin_report();
           vi.ShowDialog();
       }

       private void button6_Click(object sender, EventArgs e)
       {
           this.Close();
       }
    }
}
