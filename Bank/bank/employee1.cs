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
    public partial class employee1 : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        public employee1()
        {
            InitializeComponent();   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = select2();
                if (id ==int.Parse( textBox1.Text.Trim()))
                {
                    //ss.Speak("account number is already exists");
                    MessageBox.Show("account number is already exists");
                }
                else
                {
                    insert1();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int select2()
        {
            int id1 = 0;
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm1 = new SqlCommand("select id from employee", s);
            SqlDataReader sdr = cm1.ExecuteReader();
            while (sdr.Read())
            {
                id1 = int.Parse(sdr["id"].ToString());
            }
            sdr.Close();
            s.Close();
            return id1;
        }
        public int insert1()
        {
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            if (textBox1.Text.Trim().Length > 0 && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text.Trim().Length > 0 && textBox5.Text.Trim() != string.Empty && textBox6.Text.Trim() != string.Empty && textBox7.Text.Trim() != string.Empty && textBox8.Text.Trim() != null && textBox9.Text.Trim() != null)
            {
                if (textBox6.Text.Trim() == textBox7.Text.Trim() && textBox5.Text.Trim().Contains("@") == true && textBox5.Text.Trim().Contains(".") == true)
                {
                    SqlCommand cm = new SqlCommand("insert into employee(id,name,designation,mobile,mail,password,image,signature) values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + ar + "','" +t + "')", s);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("successfull.....");
                    this.Close();
                }
                else
                {
                    if (textBox6.Text.Trim() != textBox7.Text.Trim())
                    {
                        //ss.Speak("password does not match");
                        MessageBox.Show("password does not match");  
                    }
                    if (textBox6.Text.Contains("@") == false || textBox6.Text.Contains(".") == false)
                    {
                        //ss.Speak("email id is not in correct format");
                        MessageBox.Show("email id is not in correct format");
                    }
                }
            }
            else
            {
                //ss.Speak("please fill all the entries");
                MessageBox.Show(" please fill all the entries");
            }
            s.Close();
            return 1;
        }
        byte[] ar = null;
        byte[] t = null;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            textBox8.Text=op.FileName;
            FileStream fs = new FileStream(op.FileName, FileMode.Open);
            ar=new byte[(int)fs.Length];
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            textBox8.Text = op.FileName;
            FileStream fs = new FileStream(op.FileName, FileMode.Open);
            t = new byte[(int)fs.Length];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}