using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace bank
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                label6.Text = Convert.ToString(((long.Parse(textBox1.Text) * 0.12) + long.Parse(textBox1.Text)) / (long.Parse(textBox2.Text)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int y = Class1.account1;
                string n = Class1.name;
                SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
                s.Open();
                SqlCommand cm = new SqlCommand("insert into loan1(name,account,loan,months,deposit1,amount,interest) values('" + n + "','" + y + "','" + "home" + "','" + long.Parse(textBox2.Text) + "','" + textBox1.Text + "','" + label6.Text + "','" + "12 %" + "')", s);
                cm.ExecuteNonQuery();
                s.Close();
                MessageBox.Show("successfull.....");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}