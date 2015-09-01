using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Speech.Synthesis;
namespace bank
{
    public partial class open_account : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        public open_account()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int accountno = select2();
                if (Convert.ToString(accountno) == textBox4.Text.Trim())
                {
                //    ss.Speak("account number is already exists");
                    MessageBox.Show("account number is already exists");                   
                }
                else
                {
                    insert1();
                }
            }
            catch (Exception ex)
            {
                //ss.Speak(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        public int select2()
        {
            int account = 0;
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm1 = new SqlCommand("select acnumber from openaccount where acnumber='"+long.Parse(textBox4.Text)+"'", s);
            SqlDataReader sdr = cm1.ExecuteReader();
            while (sdr.Read())
            {
                account = int.Parse(sdr["acnumber"].ToString());
            }
            sdr.Close();
            s.Close();
            return account;
        }
        string ss2 = null;
        string ss3 = null;
        public int insert1()
        {
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            if (textBox1.Text.Trim() != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text.Trim().Length > 0 && textBox5.Text.Trim().Length > 0 && textBox6.Text.Trim() != string.Empty && textBox7.Text.Trim() != string.Empty && textBox8.Text.Trim() != string.Empty)
            {
                if (int.Parse(textBox5.Text.Trim()) >= 500 && textBox2.Text.Trim() == textBox3.Text.Trim() && textBox6.Text.Trim().Contains("@") == true && textBox6.Text.Trim().Contains(".") == true)
                {
                   
                    SqlCommand cm = new SqlCommand("insert into openaccount(name,password,retype,acnumber,deposit1,email,birthday,image,signature) values(@textBox1,@textBox2,@textBox3,@textBox4,@textBox5,@textBox6,@dateTimePicker1,@img,@sig)", s);
                    cm.Parameters.AddWithValue("@textBox1", textBox1.Text.Trim());
                    cm.Parameters.AddWithValue("@textBox2", textBox2.Text.Trim());
                    cm.Parameters.AddWithValue("@textBox3", textBox3.Text.Trim());
                    cm.Parameters.AddWithValue("@dateTimePicker1", dateTimePicker1.Value);
                    cm.Parameters.AddWithValue("@textBox4",long.Parse( textBox4.Text.Trim()));
                    cm.Parameters.AddWithValue("@textBox5", int.Parse(textBox5.Text.Trim()));
                    cm.Parameters.AddWithValue("@textBox6", textBox6.Text.Trim());
                    ss2 = openFileDialog1.FileName;
                    FileStream fs = new FileStream(ss2, FileMode.Open, FileAccess.Read);
                    byte[] ar = new byte[fs.Length];
                    fs.Read(ar, 0, ar.Length);
                    fs.Close();
                    cm.Parameters.AddWithValue("@img", ar);
                    ss3 = openFileDialog2.FileName;
                    FileStream fs1 = new FileStream(ss3, FileMode.Open, FileAccess.Read);
                    byte[] ar3 = new byte[fs1.Length];
                    fs1.Read(ar3, 0, ar3.Length);
                    fs1.Close();
                    cm.Parameters.AddWithValue("@sig", ar3);
                    cm.ExecuteNonQuery();
                    insert2();
                    MessageBox.Show("successfull.....");
                    this.Close();
                }
                else
                {
                    if (int.Parse(textBox5.Text) < 500)
                    {
                  //      ss.Speak("minimum Rs.500 for open account");
                        MessageBox.Show("minimum Rs.500 for open account"); 
                    }
                    if (textBox2.Text.Trim() != textBox3.Text.Trim())
                    {
                    //    ss.Speak("password does not match");
                        MessageBox.Show("password does not match");
                    }
                    if (textBox6.Text.Contains("@") == false || textBox6.Text.Contains(".") == false)
                    {
                      //  ss.Speak("email id is not in correct format");
                        MessageBox.Show("email id is not in correct format");
                    }
                }
            }
            else
            {
               // ss.Speak(" please fill all the entries");
                MessageBox.Show(" please fill all the entries");
            }
            s.Close();
            return 1;
        }
        public void insert2()
        {
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm = new SqlCommand("insert into trasaction(name,password,account,amount,time,status) values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + DateTime.Now.ToString() + "','" + "account open" + "')", s);
            cm.ExecuteNonQuery();
            s.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox7.Text =openFileDialog1.FileName;
            ss2 = openFileDialog1.FileName;
           
        }
        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            textBox8.Text = openFileDialog2.FileName;
            ss3 = openFileDialog2.FileName;
        }
    }
}