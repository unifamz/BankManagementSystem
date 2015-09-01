using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace bank
{
    public partial class _10 : Form
    {
        public _10()
        {
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox1.Text) >= 2000 && int.Parse(textBox2.Text) <= 120)
                {
                    label6.Text = Convert.ToString((int.Parse(textBox1.Text) * int.Parse(textBox2.Text) * 0.05) + int.Parse(textBox1.Text));
                }
                else
                {
                    if (int.Parse(textBox1.Text) < 2000)
                    {
                        MessageBox.Show("minimum Rs. 2000 for deposit");
                    }
                    if (int.Parse(textBox2.Text) > 120)
                    {
                        MessageBox.Show("time period is out of scope");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int a = Class1.account2;
            string n = Class1.name1;
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm = new SqlCommand("insert into fd(name,account,time,deposit2,amount,interest) values('" + n + "','" + a + "','" + int.Parse(textBox2.Text) + "','" + textBox1.Text + "','" + label6.Text + "','" + int.Parse(label5.Text) + "') ", s);
            cm.ExecuteNonQuery();
            s.Close();
            MessageBox.Show("successfull......");
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
