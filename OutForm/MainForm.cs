using OutForm.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutForm
{
    public partial class MainForm : Form
    {
        [DllImport("./SignalAnalisys.dll")]
        public static extern int SysAnalInterface(int l, double[] a, double[] f, double[] ff);

        public MainForm()
        {
            InitializeComponent();
            this.MouseClick += MainForm_MouseClick;


            this.Load += Form1_Load;
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Location.X);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double[] l = { 1.0, 2.2 };

            var res = SysAnalInterface(10, l , l, l);
            Console.WriteLine("Dll answer: " + res);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        SinPanel[] tb = new SinPanel[0];
        private void SinCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Нажали <ENTER>
            {
                foreach (var i in tb)
                    this.Controls.Remove(i);

                int s = 0;
                try
                {
                   s = Convert.ToInt32(SinCount.Text);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                tb = new SinPanel[s];

                for (int i = 0; i < s; i++)
                {
                    tb[i] = new SinPanel();
                    tb[i].Location = new System.Drawing.Point(SinCount.Location.X + -5 + ((i) * tb[i].Width), 50);
                    tb[i].Name = "sinTextBox" + i;
                    // tb[i].TabIndex = i + 4;
                    // this.Size = new System.Drawing.Size(SinCount.Location.X + 125 + i * (tb[i].Width), 600);
                    this.Controls.Add(tb[i]);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SinLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
