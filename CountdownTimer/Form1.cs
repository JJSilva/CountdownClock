using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountdownTimer
{
    public partial class Form1 : Form
    {

        private TimeSpan ts = new TimeSpan();
        private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            sw.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ts = ts.Subtract(new TimeSpan(0, 0, 1));
            lblCountdown.Text = ts.ToString();



            if (ts.TotalSeconds < 60)
            {
                this.BackColor = Color.Yellow;
            }
            else
            {
                this.BackColor = DefaultBackColor;

            }

            if (ts.TotalMinutes < 0)
            {
                this.BackColor = Color.Red;
            }
            else
            {
                this.BackColor = DefaultBackColor;
            }



        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = (10 * 100); // 1 secs
            timer.Tick += new EventHandler(timer_Tick);
            textBox1.Text = "Band Name";
        }

        private void btnRemoveTime_Click(object sender, EventArgs e)
        {
            ts = ts.Subtract(new TimeSpan(0, 15, 0));
            lblCountdown.Text = ts.ToString();
        }


        private void btnAddTime_Click(object sender, EventArgs e)
        {
            ts = ts.Add(new TimeSpan(0, 15, 0));
            lblCountdown.Text = ts.ToString();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            sw.Stop();
            timer.Stop();
            timer.Enabled = false;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            //sw.Restart();
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = (10 * 100); // 1 secs
            //timer.Tick += new EventHandler(timer_Tick);

            ts = new TimeSpan(0, 0, 0);
            lblCountdown.Text = ts.ToString();
        }

        private void lblCountdown_Click(object sender, EventArgs e)
        {

        }
    }
}

