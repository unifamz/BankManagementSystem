using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace bank
{
    public partial class trasaction1 : Form
    {
        public trasaction1()
        {
            InitializeComponent();
        }
        private void trasaction1_Load(object sender, EventArgs e)
        {
        }
        int a = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void insert1()
        {
            SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
            s.Open();
            SqlCommand cm = new SqlCommand("select name,amount,status,time from trasaction  where account='" + a + "'", s);
            SqlCommand cm1 = new SqlCommand("select name,loan,deposit1,months,amount,interest from loan1  where account='" + a + "'", s);
            SqlCommand cm2 = new SqlCommand("select name,deposit2,time,amount,interest from fd  where account='" + a + "'", s);
            SqlDataAdapter sdr = new SqlDataAdapter(cm);
            SqlDataAdapter sdr1 = new SqlDataAdapter(cm1);
            SqlDataAdapter sdr2 = new SqlDataAdapter(cm2); 
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            DataTable dt1 = new DataTable();
            sdr1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            DataTable dt2 = new DataTable();
            sdr2.Fill(dt2);
            dataGridView3.DataSource = dt2;
            s.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
                s.Open();
                SqlCommand cm = new SqlCommand("select acnumber from openaccount where name='" + textBox1.Text + "'and password='" + textBox2.Text + "'", s);
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    a = int.Parse(sdr["acnumber"].ToString());
                    label5.Text = a.ToString();
                    insert1();
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && label5.Text != string.Empty)
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                dataGridView3.Visible = false;
            }
            else
                MessageBox.Show("please fill all the entries");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && label5.Text != string.Empty)
            {
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                dataGridView3.Visible = false;
            }
            else
                MessageBox.Show("please fill all the entries");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && label5.Text != string.Empty)
            {
                dataGridView3.Visible = true;
                dataGridView2.Visible = false;
                dataGridView1.Visible = false;
            }
            else
                MessageBox.Show("please fill all the entries");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}