using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace bank
{
    public partial class fd : Form
    {
        public fd()
        {
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string n = null;
            int a = 0;
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open(); 
            SqlCommand cm = new SqlCommand("select acnumber,name,image,signature from openaccount where name='" + textBox1.Text + "'and password='" + textBox2.Text + "'", s);
            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                label5.Text = Convert.ToString(sdr["acnumber"].ToString());
                a = int.Parse(label5.Text);
                n = sdr["name"].ToString();
                byte[] br = (byte[])sdr["image"];
                MemoryStream ms = new MemoryStream(br);
                pictureBox1.Image = Image.FromStream(ms);
                byte[] br1 = (byte[])sdr["signature"];
                MemoryStream ms1 = new MemoryStream(br1);
                pictureBox2.Image = Image.FromStream(ms1);
            }
            s.Close();
            Class1.name1 = n;
            Class1.account2 = a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty && textBox2.Text.Trim() != string.Empty && label5.Text.Trim() != string.Empty)
            {
                _5 t = new _5();
                t.ShowDialog();
            }
            else
            {
                MessageBox.Show("please fill all the entries");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty && textBox2.Text.Trim() != string.Empty && label5.Text.Trim() != string.Empty)
            {
                _10 t = new _10();
                t.ShowDialog();
            }
            else
            {
                MessageBox.Show("please fill all the entries");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty && textBox2.Text.Trim() != string.Empty && label5.Text.Trim() != string.Empty)
            {
                _15 t = new _15();
                t.ShowDialog();
            }
            else
            {
                MessageBox.Show("please fill all the entries");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty && textBox2.Text.Trim() != string.Empty && label5.Text.Trim() != string.Empty)
            {
                _20 t = new _20();
                t.ShowDialog();
            }
            else
            {
                MessageBox.Show("please fill all the entries");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            detail de = new detail();
            de.ShowDialog();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}