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
        /*public static extern void PushSignal(double a, double p, double f, int fs, int l);
        [DllImport("./SignalAnalisys.dll")]*/
        public static extern int Run(double ampl, double phase, double freeq, int first, int last);
        [DllImport("./SignalAnalisys.dll")]
        public static extern int GetSize();
        [DllImport("./SignalAnalisys.dll")]
        public static extern int GetX(int key);
        [DllImport("./SignalAnalisys.dll")]
        public static extern double GetY(int key);
        [DllImport("./SignalAnalisys.dll")]
        public static extern int GetS();
        [DllImport("./SignalAnalisys.dll")]
        public static extern void AddNoise(int percent);
        [DllImport("./SignalAnalisys.dll")]
        public static extern void Clear();
        [DllImport("./SignalAnalisys.dll")]
        public static extern void Fur(int k, int s);

        public MainForm()
        {
            InitializeComponent();
            this.SignGraph.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series()
            {
                Name = "Second",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            });


            this.Load += Form1_Load;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //Добавляем некоторую информацию в нашу dll

            /*PushSignal(1, 2, 3, 4, 5);
              PushSignal(1, 2, 3, 4, 5);
              PushSignal(1, 2, 3, 4, 5);*/


            //Проверяем, что размер всех массивов поднят до 3
            Console.WriteLine(GetSize());

            //Как только вся нужная информация запушена - начинаем выполнение основной логики
            //Run();

            //Наслаждаемся жизнью

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

                if (s == 0)
                {
                    this.Size = new System.Drawing.Size(SinCount.Location.X + 20 + SinCount.Width, this.Height);
                }

                for (int i = 0; i < s; i++)
                {

                    tb[i] = new SinPanel();
                    tb[i].Location = new System.Drawing.Point(SinCount.Location.X + -5 + ((i) * tb[i].Width), 50);
                    tb[i].Name = "sinTextBox" + i;
                    this.Size = new System.Drawing.Size(SinCount.Location.X + 5 + ((i + 1) * tb[i].Width), this.Height);
                    this.Controls.Add(tb[i]);
                }
            }

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            SignGraph.Series[0].Points.Clear();
            int l = 0;

            int s = Convert.ToInt32(SinCount.Text);

            double[] ampl = new double[s];
            double[] phase = new double[s];
            double[] freq = new double[s];
            int[] first = new int[s];
            int[] last = new int[s];

            for (int i = 0; i < s; i++)
            {
                ampl[i] = Convert.ToDouble(tb[i].tbA.Text);
                Console.Write(ampl[i].ToString() + " ");
                phase[i] = Convert.ToDouble(tb[i].tbB.Text);
                Console.Write(phase[i].ToString() + " ");
                freq[i] = Convert.ToDouble(tb[i].tbC.Text);
                Console.Write(freq[i].ToString() + " ");
                first[i] = Convert.ToInt32(tb[i].tbD.Text);
                Console.Write(first[i].ToString() + " ");
                last[i] = Convert.ToInt32(tb[i].tbE.Text);
                Console.WriteLine(last[i].ToString());

            }
            double temp_ampl = 0.0;
            double temp_phase = 0.0;
            double temp_freq = 0.0;
            int temp_first = 0;
            int temp_last = 0;

            for (int j = 0; j < s; j++)
            {
                temp_ampl = ampl[j];
                temp_phase = phase[j];
                temp_freq = freq[j];
                temp_first = first[j];
                temp_last = last[j];

                Run(temp_ampl, temp_phase, temp_freq, temp_first, temp_last);
            }

            SignGraph.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            double x = 0;
            l = GetS();
            Console.WriteLine(l);
            for (int i = 0; i < l; i++)
            {


                x = GetX(i) * temp_phase;
                double y = GetY(i);
                SignGraph.Series[0].Points.AddXY(x, y);

                Console.Write(x + " ");
                Console.WriteLine(y);
            }

            Clear();

            // SignGraph.Series[0].Points.Clear();


            SignGraph.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            SignGraph.Series[1].Color = Color.Green;

            for (int j = 0; j < s; j++)
            {
                temp_ampl = ampl[j];
                temp_phase = phase[j];
                temp_freq = freq[j];
                temp_first = first[j];
                temp_last = last[j];

                Run(temp_ampl, temp_phase, temp_freq, temp_first, temp_last);
                AddNoise(Convert.ToInt32(NoisePerc.Text));
            }



            double x1 = 0;
            l = GetS();
            Console.WriteLine(l);
            for (int i = 0; i < l; i++)
            {


                x1 = GetX(i) * temp_phase;
                double y1 = GetY(i);
                SignGraph.Series[1].Points.AddXY(x1, y1);

                Console.Write(x1 + " ");
                Console.WriteLine(y1);
            }


        }

        private void SinCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignGraph.Series[0].Points.Clear();
            SignGraph.Series[1].Points.Clear();
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SignGraph.Series[0].Points.Clear();
            int l = 0;

            int s = Convert.ToInt32(SinCount.Text);

            double[] ampl = new double[s];
            double[] phase = new double[s];
            double[] freq = new double[s];
            int[] first = new int[s];
            int[] last = new int[s];

            for (int i = 0; i < s; i++)
            {
                ampl[i] = Convert.ToDouble(tb[i].tbA.Text);
                Console.Write(ampl[i].ToString() + " ");
                phase[i] = Convert.ToDouble(tb[i].tbB.Text);
                Console.Write(phase[i].ToString() + " ");
                freq[i] = Convert.ToDouble(tb[i].tbC.Text);
                Console.Write(freq[i].ToString() + " ");
                first[i] = Convert.ToInt32(tb[i].tbD.Text);
                Console.Write(first[i].ToString() + " ");
                last[i] = Convert.ToInt32(tb[i].tbE.Text);
                Console.WriteLine(last[i].ToString());

            }
            double temp_ampl = 0.0;
            double temp_phase = 0.0;
            double temp_freq = 0.0;
            int temp_first = 0;
            int temp_last = 0;

            for (int j = 0; j < s; j++)
            {
                temp_ampl = ampl[j];
                temp_phase = phase[j];
                temp_freq = freq[j];
                temp_first = first[j];
                temp_last = last[j];

                Run(temp_ampl, temp_phase, temp_freq, temp_first, temp_last);
                AddNoise(Convert.ToInt32(NoisePerc.Text));
                Fur(20, 80);

            }

            SignGraph.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            double x = 0;
            l = GetS();
            Console.WriteLine(l);
            for (int i = 0; i < l; i++)
            {


                x = GetX(i) * temp_phase;
                double y = GetY(i);
                SignGraph.Series[0].Points.AddXY(x, y);

                Console.Write(x + " ");
                Console.WriteLine(y);
            }
        }
    }
}

