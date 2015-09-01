using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Speech.Synthesis;
using System.IO;
namespace bank
{
    public partial class withdraw : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        public withdraw()
        {
            InitializeComponent();
        }
        int accountno = 0;
        public int account(string username, string password)
        {
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm1 = new SqlCommand("select acnumber,image,signature from  openaccount where name='" + username + "' and password='" + password + "'", s);
            SqlDataReader sdr1 = cm1.ExecuteReader();
            if (sdr1.Read())
            {
                accountno = int.Parse(sdr1["acnumber"].ToString());
                label5.Text = sdr1["acnumber"].ToString();
                byte[] br = (byte[])sdr1["image"];
                MemoryStream ms = new MemoryStream(br);
                pictureBox1.Image = Image.FromStream(ms);
                byte[] br1 = (byte[])sdr1["signature"];
                MemoryStream ms1 = new MemoryStream(br1);
                pictureBox2.Image = Image.FromStream(ms1);
            }
            sdr1.Close();
            return 1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                long dep = 0;
                long? withdraw1 = 0;
                long intTest = 0;
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text.Trim().Length > 0 && label5.Text.Trim().Length > 0)
                {
                    SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
                    s.Open();
                    SqlCommand cm1 = new SqlCommand("select withdraw1,deposit1 from  openaccount where acnumber='" + accountno + "'", s);
                    SqlDataReader sdr1 = cm1.ExecuteReader();
                    if (sdr1.Read())
                    {
                        dep = long.Parse(sdr1["deposit1"].ToString());
                        long.TryParse(sdr1["withdraw1"].ToString(), out intTest);
                    }
                    withdraw1 = intTest;
                    sdr1.Close();
                    long y = long.Parse(textBox3.Text);
                    string o = Convert.ToString(y);           
                    long  val = 0;
                    long.TryParse(o, out val);
                    long? totalamount = withdraw1 + val;
                    if (dep >= totalamount)
                    {
                        SqlCommand cm2 = new SqlCommand("update openaccount set withdraw1='" + totalamount + "' where acnumber='" + accountno + "'", s);
                        cm2.ExecuteNonQuery();
                        s.Close();
                        insert1();
                        MessageBox.Show("successfull.....");
                        this.Close();
                    }
                    else
                    {
                        ss.Speak("not enough balance in your account");
                        MessageBox.Show("not enough balance in your account");
                    }
                }
                else
                {
                    ss.Speak("please fill all the enteries ");
                    MessageBox.Show("please fill all the enteries ");
                }
            }
            catch (Exception ex)
            {
                ss.Speak("you input an amount in wrong format");
                MessageBox.Show("you input an amount in wrong format");
            }
        }
        public void insert1()
        {
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm = new SqlCommand("insert into trasaction(name,password,account,amount,time,status) values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + label5.Text + "','" + textBox3.Text.Trim() + "','" + DateTime.Now.ToString() + "','" + "withdraw" + "')", s);
            cm.ExecuteNonQuery();
            s.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
       {
            string username = null;
            string password = null;
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm = new SqlCommand("select name,password from  openaccount", s);
            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                username = sdr["name"].ToString();
                password = sdr["password"].ToString();
                if (textBox1.Text == username && textBox2.Text == password)
                {
                    account(username, password);
                    break;
                }
            }
            s.Close();
        }
    }
}