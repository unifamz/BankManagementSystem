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
namespace bank
{
    public partial class view_admin_report : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        public view_admin_report()
        {
            InitializeComponent();
        }
        public void insert()
        {
            long c = 0, b = 0, todep = 0, towith = 0;
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm = new SqlCommand("select deposit1,withdraw1 from openaccount", s);
            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                long.TryParse(sdr["deposit1"].ToString(), out c);
                long.TryParse(sdr["withdraw1"].ToString(), out b);
                todep += c;
                towith += b;
            }
            if (todep > towith)
            {
                 ss.Speak("rise");
                label5.Text = "rise";
            }
            else if (todep < towith)
            {
                ss.Speak("fall");
                label5.Text = "fall";
            }
            else
            {
                ss.Speak("equal");
                label5.Text = "equal";
            }
            select2(todep, towith, label5.Text);
            s.Close();
        }
        public void select2(long c, long b, string v)
        {
            long todep = 0, towith = 0;
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm1 = new SqlCommand("select tdeposit,twithdraw from adminreport ", s);
            SqlDataReader sdr1 = cm1.ExecuteReader();
            while (sdr1.Read())
            {
                todep += c;
                towith += b;
            }
            label6.Text = Convert.ToString(c);
            label7.Text = Convert.ToString(b);
            label5.Text = v;
            select3(label6.Text, label7.Text, label5.Text);
            s.Close();
        }
        public void select3(string q, string w, string n)
        {
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm1 = new SqlCommand("update adminreport set tdeposit='" + q + "', twithdraw='" + w + "',overall='" + n + "'where admin='" + "sunny" + "' and password='" + "astron" + "'", s);
            cm1.ExecuteNonQuery();
            s.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string username = "sunny";
            string password = "astron";
            if (textBox1.Text == username && textBox2.Text == password)
            {
                insert();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cmd = new SqlCommand("select  acnumber,name,email,birthday,deposit1,withdraw1 from openaccount",s);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}