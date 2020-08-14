using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aed_aoc_v2
{
    public partial class TelaCarregamento : Form
    {
        Random r = new Random();
        public TelaCarregamento()
        {
            InitializeComponent();
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.Location = new Point(20,20);
            pictureBox2.BackColor = Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int v = progressBar1.Value;
            int rnd = r.Next(3);
            if (progressBar1.Value < 100)
                try
                {
                    progressBar1.Value = progressBar1.Value + rnd;
                }
                catch (Exception)
                {

                }

            else
            {
                Form1 f = new Form1();
                timer1.Enabled = false;
                f.Focus();
                this.Close();
                this.Dispose();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
