using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutForm.Controls;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace OutForm
{
    public partial class MainForm : Form
    {
        public class WindowHandling
        {
            [DllImport("SignalAnalysis.h")]
            public static extern int SetForegroundWindow(IntPtr point);

            public void ActivateTargetApplication(string processName, List<string> barcodesList)
            {
                Process p = Process.Start("notepad++.exe");
                p.WaitForInputIdle();
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait("k");
                IntPtr processFoundWindow = p.MainWindowHandle;
            }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

                int s = Convert.ToInt32(SinCount.Text);
                tb = new SinPanel[s];

                for (int i = 0; i < s; i++)
                {
                    tb[i] = new SinPanel();
                    tb[i].Location = new System.Drawing.Point(SinCount.Location.X - 5 + (i) * tb[i].Width, 50);
                    tb[i].Name = "sinTextBox" + i;
                    tb[i].TabIndex = i + 3;
                    this.Size = new System.Drawing.Size(SinCount.Location.X + 125 + i * (tb[i].Width), 600);
                    this.Controls.Add(tb[i]);
                }
            }

        }

        private void SinCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string s = "";
            foreach (var el in tb)
            {
                s += string.Join(" ", el.TextBoxes.Select(t => t.Text).ToArray());
                s += '\n';
            }

            Console.WriteLine(s);
        }
 
    
   


}
}
