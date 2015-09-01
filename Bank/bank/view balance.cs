using System;
using System.IO;
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
    public partial class view_balance : Form
    {
        public view_balance()
        {
            InitializeComponent();
        }
        public void select2()
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
        int accountno = 0;
        int q=0;
        public int account(string username, string password)
        {
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm1 = new SqlCommand("select acnumber,image,signature from  openaccount where name='" + username + "' and password='" + password + "'", s);
            SqlDataReader sdr1 = cm1.ExecuteReader();
            if (sdr1.Read())
            {
                accountno = int.Parse(sdr1["acnumber"].ToString());
                q = accountno;
                label5.Text = sdr1["acnumber"].ToString();
                byte[] br = (byte[])sdr1["image"];
                MemoryStream ms = new MemoryStream(br);
                pictureBox1.Image = Image.FromStream(ms);
                byte[] br1 = (byte[])sdr1["signature"];
                MemoryStream ms1 = new MemoryStream(br1);
                pictureBox2.Image = Image.FromStream(ms1);
            }
            sdr1.Close();
            return q;
        }
        public int insert1(int ac)
        {
            int r = 0;
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm2 = new SqlCommand("select deposit1,withdraw1 from openaccount where acnumber='" + ac + "'", s);
            SqlDataReader sdr = cm2.ExecuteReader();
            if (sdr.Read())
            {
                int e = int.Parse(sdr["deposit1"].ToString());
                  int.TryParse(sdr["withdraw1"].ToString(),out r);
                int t = e - r;
                label4.Text = Convert.ToString(t);
                insert(t);
            }
            s.Close();
            return 1;
        }
        public void insert(int y)
        {
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm2 = new SqlCommand("update openaccount set balance='"+y+"' where acnumber='"+accountno+"'" , s);
            cm2.ExecuteNonQuery();
            s.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {   
            this.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            select2();
            int w = q;
            insert1(w);
        }
    }
}