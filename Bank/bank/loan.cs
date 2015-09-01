using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Speech.Synthesis;
namespace bank
{
    public partial class loan : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        public loan()
        {
            InitializeComponent();
        }
        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty && textBox2.Text.Trim() != string.Empty && label4.Text.Trim() != string.Empty)
            {
                home h = new home();
                h.ShowDialog();
            }
            else
            {
                ss.Speak("please fill the entries");
                MessageBox.Show("please fill the entries");
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty && textBox2.Text.Trim() != string.Empty && label4.Text.Trim() != string.Empty)
            {
                vechile v = new vechile();
                v.ShowDialog();
            }
            else
            {
               // ss.Speak("please fill the entries");
                MessageBox.Show("please fill the entries");
            }
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty && textBox2.Text.Trim() != string.Empty && label4.Text.Trim() != string.Empty)
            {
                study s = new study();
                s.ShowDialog();
            }
            else
            {
               // ss.Speak("please fill the entries");
                MessageBox.Show("please fill the entries");
            }
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty && textBox2.Text.Trim() != string.Empty && label4.Text.Trim() != string.Empty)
            {
                personal p = new personal();
                p.ShowDialog();
            }
            else
            {
                //ss.Speak("please fill the entries");
                MessageBox.Show("please fill the entries");
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            nb();
        }
        public int a = 0;
        public string n = null;
        public void  nb()
        {
            try
            {
                SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
                s.Open();
                SqlCommand cm = new SqlCommand("select acnumber,name,image,signature from openaccount where name='" + textBox1.Text + "'and password='" + textBox2.Text + "' ", s);
                SqlDataReader sdr = cm.ExecuteReader();
                if (sdr.Read())
                {
                    label4.Text = sdr["acnumber"].ToString();
                    a = int.Parse(label4.Text);
                    n=sdr["name"].ToString();
                    byte[] br = (byte[])sdr["image"];
                    MemoryStream ms = new MemoryStream(br);
                    pictureBox1.Image = Image.FromStream(ms);
                    byte[] br1 = (byte[])sdr["signature"];
                    MemoryStream ms1 = new MemoryStream(br1);
                    pictureBox2.Image = Image.FromStream(ms1);
                }
                s.Close();
                Class1.account1 = a;
                Class1.name = n;      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}