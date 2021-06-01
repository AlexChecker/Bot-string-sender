using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int count = trackBar1.Value;
            Counter.Text = Convert.ToString(count);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                checkBox1.Enabled = false;
                textBox2.Enabled = false;
                trackBar1.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                checkBox1.Enabled = true;
                textBox2.Enabled = true;
                trackBar1.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else 
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("1)This program works only with english words\n2)The decimal separator is a comma","Please, read this!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool count = true;
            if (radioButton1.Checked) count = true;
            else if (radioButton2.Checked) count = false;
            Clipboard.SetText(textBox1.Text);
            Thread.Sleep(5000);
            Random rnd = new Random();
            switch (count)
            {
                case true:
                    for (int i = 0; i < trackBar1.Value; i++)
                    {
                        SendKeys.Send("^(V)");
                        SendKeys.Send("{Enter}");
                    }
                    break;
                case false:
                    float maindelay = float.Parse(textBox2.Text)*60000;
                    if (checkBox1.Checked)
                    {
                        float minrandsec = float.Parse(textBox3.Text) * 60000;
                        float maxrandsec = float.Parse(textBox4.Text) * 60000;
                        float rnddelay = rnd.Next(Convert.ToInt32(minrandsec), Convert.ToInt32(maxrandsec));
                        float finaldelay = maindelay + rnddelay;
                        while (true)
                        {
                            SendKeys.Send("^(V)");
                            SendKeys.Send("{Enter}");
                            Thread.Sleep(Convert.ToInt32(finaldelay));
                        }
                    }
                    else 
                    {
                        while (true)
                        {
                            SendKeys.Send("^(V)");
                            SendKeys.Send("{Enter}");
                            Thread.Sleep(Convert.ToInt32(maindelay));
                        }
                    }
                    break;
            }
                
        }
    }
}
