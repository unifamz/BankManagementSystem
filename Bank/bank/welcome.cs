using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace bank
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
            //System.Speech.Synthesis.SpeechSynthesizer gh = new System.Speech.Synthesis.SpeechSynthesizer();
            //gh.Speak("invalid");
           

           // VoiceInfo d;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            BANK b = new BANK();
            
           b.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void welcome_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(this.tim);
            t.Start();
        }
        public void tim()
        {
            string s = "1:35  AM";
            int i;
            for (i = 1; i <= 2; i++)
            {
                string ss = DateTime.Now.ToShortTimeString();
                if (s == ss)
                {
                    this.Close();
                    break;
                }
                i = 1;
                Thread.Sleep(1000);
            }
        }
    }
}