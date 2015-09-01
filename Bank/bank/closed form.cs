using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace bank
{
    public partial class closed_form : Form
    {
        public closed_form()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbid.Text.Trim() != string.Empty && tbpass.Text.Trim() != string.Empty)
                {
                    SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
                    s.Open();
                    SqlCommand cmd = new SqlCommand("select name,image,signature,balance from openaccount where acnumber='" + Convert.ToInt32(tbid.Text) + "' and password='" + tbpass.Text + "'", s);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        lbname.Text = sdr["name"].ToString();
                        byte[] bt = (byte[])sdr["image"];
                        MemoryStream ms = new MemoryStream(bt);
                        pictureBox1.Image = Image.FromStream(ms);
                        byte[] bt1 = (byte[])sdr["signature"];
                        MemoryStream ms1 = new MemoryStream(bt1);
                        pictureBox2.Image = Image.FromStream(ms1);
                        label8.Text=sdr["balance"].ToString();
                        s.Close();
                       
                    }
                }
                else
                {
                    MessageBox.Show("please fill all enteries");
                }
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
                if (tbid.Text.Trim() != string.Empty && tbpass.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("All money is withdraw and balance = 0");
                    label8.Text = "0";
                }
                else
                {
                    MessageBox.Show("Please fill all the entries");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbid.Text.Trim() != string.Empty && tbpass.Text.Trim() != string.Empty)
                {
                    SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
                    s.Open();
                    SqlCommand cmd = new SqlCommand("delete * from openaccount where acnumber='" + Convert.ToInt32(tbid.Text) + "' , password='" + tbpass.Text + "'", s);
                    cmd.ExecuteNonQuery();
                    s.Close();
                    MessageBox.Show("Account has been deleted parmanently");
                }
                else
                {
                    MessageBox.Show("Please fill all the entries");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void withdrawmoney()
        //{
        //    SqlConnection s = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=bank1;Integrated Security=True");
        //    s.Open();
        //    SqlCommand cmd = new SqlCommand("select );
        //}
    }
}
