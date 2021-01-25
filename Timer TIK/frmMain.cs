using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer_TIK
{
    public partial class frmMain : Form
    {
        public int h = 1;
        public int m = 0;
        public int s = 0;
        private frmSet form_set;
        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            borderless_button();
        }

        private void borderless_button()
        {
            btnStart.TabStop = false;
            btnSet.TabStop = false;
            btnStop.TabStop = false;
            btnReset.TabStop = false;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnSet.FlatStyle = FlatStyle.Flat;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnStart.FlatAppearance.BorderSize = 0;
            btnSet.FlatAppearance.BorderSize = 0;
            btnStop.FlatAppearance.BorderSize = 0;
            btnReset.FlatAppearance.BorderSize = 0;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            label7.Text = "Start";
            label7.ForeColor = System.Drawing.Color.Blue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (h == 0 && m == 0 & s == 10)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Application.StartupPath+"\\10sb.wav");
                player.Play();
            }

            if (h <= 0 && m <= 0 && s <= 0)
            {
                timer1.Stop();
                label7.Text = "Stop";
                label7.ForeColor = Color.FromArgb(255, 128, 128);
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Akibara\Documents\Visual Studio 2013\Projects\Timer TIK\0s.wav");
                //player.Play();

            }
            label1.Text = Convert.ToString(h);
            label2.Text = Convert.ToString(m);
            label3.Text = Convert.ToString(s);
            s = s - 1;
            if (s == -1)
            {
                m = m - 1;
                s = 59;
            }

            if (m == -1)
            {
                h = h - 1;
                m = 59;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label7.Text = "Stop";
            label7.ForeColor = Color.FromArgb(255, 128, 128);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            
            s = form_set.s;
            m = form_set.m;
            h = form_set.h;
            label1.Text = Convert.ToString(h);
            label2.Text = Convert.ToString(m);
            label3.Text = Convert.ToString(s);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            form_set = new frmSet();
            form_set.ShowDialog();
            if (form_set.s == 0 && form_set.m == 0 && form_set.h == 0)
            {

            }
            else
            {
                s = form_set.s;
                m = form_set.m;
                h = form_set.h;
                label1.Text = Convert.ToString(h);
                label2.Text = Convert.ToString(m);
                label3.Text = Convert.ToString(s);
            }
        }

        private void btnSet_MouseEnter(object sender, EventArgs e)
        {
            btnSet.BackColor = Color.FromArgb(0x4E7E70);
        }

        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.FromArgb(0x4E7E70);
        }

        private void btnStop_MouseEnter(object sender, EventArgs e)
        {
            btnStop.BackColor = Color.FromArgb(0x4E7E70);
        }

        private void btnReset_MouseEnter(object sender, EventArgs e)
        {
            btnReset.BackColor = Color.FromArgb(0x4E7E70);
        }
    }
}
