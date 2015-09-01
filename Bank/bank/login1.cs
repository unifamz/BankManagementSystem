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
using System.Speech.Synthesis;
namespace bank
{
    public partial class login1 : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        public login1()
        {
            InitializeComponent();
        }
        string w = null;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (label4.Text == w)
                {
                    login1 l = new login1();
                    BANK d = new BANK();
                    this.Hide();
                    ActiveForm.MainMenuStrip.Items.Clear();
                    welcome1 y = new welcome1();
                    y.MdiParent = this.MdiParent;
                    y.Show();
                    this.Close();
                }
                else
                {
                   ss.Speak("invalid id or password");
                    MessageBox.Show("invalid id or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
                s.Open();
                if (textBox1.Text.Trim().Length > 0 && textBox3.Text.Trim() != string.Empty)
                {
                    SqlCommand cm = new SqlCommand("select name,password from employee where id='" + int.Parse(textBox1.Text) + "'and password='" + textBox3.Text + "'", s);
                    SqlDataReader sdr = cm.ExecuteReader();
                    if (sdr.Read())
                    {
                        w = sdr["name"].ToString();
                        string p = sdr["password"].ToString();

                        if (textBox3.Text != null && p == textBox3.Text)
                        {
                            if (p.Length == textBox3.Text.Length)
                            {
                                label4.Text = w;
                            }
                        }
                    }
                    else
                    {
                        label4.Text = "";
                    }
                }
                else
                {
                //    ss.Speak("please fill all the entries ");
                    MessageBox.Show("please fill all the entries ");
                }
            }
            catch
            {
                //ss.Speak("you input in wrong format");
                MessageBox.Show("you input in wrong format");
            }
        }
    }
}