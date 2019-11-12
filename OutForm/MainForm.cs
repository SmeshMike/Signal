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
using MySpace;
using static MySpace.SigGen;

namespace OutForm
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            this.SignGraph.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series()
            {
                Name = "Шум",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            });
            this.Load += Form1_Load;

            this.SignGraph.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series()
            {
                Name = "Новый сигнал",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            });


            this.Load += Form1_Load;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        SigGen forform = new SigGen();

        SinPanel[] tb = new SinPanel[0];

        double min_phase = 1.0;
        double full_energy = 0.0;
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
                    this.Size = new System.Drawing.Size(this.Width, this.Height);
                }

                for (int i = 0; i < s; i++)
                {
                    tb[i] = new SinPanel();

                    tb[i].Location = new System.Drawing.Point(SinCount.Location.X + -5 + ((i) * tb[i].Width), 50);
                    tb[i].Name = "sinTextBox" + i;
                    if (this.Width < SinCount.Location.X - 5 + (s * tb[i].Width))
                    {
                        this.Size = new System.Drawing.Size(SinCount.Location.X + 5 + ((i + 1) * tb[i].Width), this.Height);
                    }
                    this.Controls.Add(tb[i]);
                }
            }

        }

        List<dot> spisok = new List<dot>();
      
        int l = 0;

        private void Start_Click_1(object sender, EventArgs e)
        {
            forform.Clear();
            SignGraph.Series[0].Points.Clear();
            

            
            int s = Convert.ToInt32(SinCount.Text);

            double[] ampl = new double[s];
            double[] phase = new double[s];
            double[] freq = new double[s];
            UInt16[] first = new UInt16[s];
            UInt16[] last = new UInt16[s];



            for (int i = 0; i < s; i++)
            {
                ampl[i] = Convert.ToDouble(tb[i].tbA.Text);
                Console.Write(ampl[i].ToString() + " ");
                phase[i] = Convert.ToDouble(tb[i].tbB.Text);
                Console.Write(phase[i].ToString() + " ");
                freq[i] = Convert.ToDouble(tb[i].tbC.Text);
                Console.Write(freq[i].ToString() + " ");
                first[i] = Convert.ToUInt16(tb[i].tbD.Text);
                Console.Write(first[i].ToString() + " ");
                last[i] = Convert.ToUInt16(tb[i].tbE.Text);
                Console.WriteLine(last[i].ToString());
            }

            UInt16 v_first = last[s - 1];
            UInt16 v_last = first[0];

            for (int i = 0; i < s; i++)
            {
                if (v_first > first[i])
                    v_first = first[i];
                if (v_last < last[i])
                    v_last = last[i];
                if (min_phase > phase[i])
                    min_phase = phase[i];
            }

            forform.SignalGen(s, ampl, phase, freq, first, last);


            l = forform.GetS();

            double[] c_signal_x = new double[l];
            double[] c_signal_y = new double[l];
            double[] wn_signal_y = new double[l];

            for (UInt16 i = 0; i < forform.GetS(); i++)
            {
                c_signal_y[i] = forform.GetYPoints(i);
                c_signal_x[i] = forform.GetXPoints(i);
            }

            forform.SignalwithWhiteNoise(Convert.ToUInt16(NoisePerc.Text));


            for (UInt16 i = 0; i < forform.GetS(); i++)
            {
                wn_signal_y[i] = forform.GetYPoints(i);
                SigGen.dot temp = new SigGen.dot(wn_signal_y[i], 0, i);
                spisok.Add(temp);
            }

            NoiseText.Text = Convert.ToString(forform.GetCoef());
           
            SignGraph.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            SignGraph.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            SignGraph.Series[1].Color = Color.Green;
            SignGraph.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            SignGraph.Series[2].Color = Color.Red;


            for (int i = 0; i < l; i++)
            {
                double x = c_signal_x[i] * min_phase;
                double y = c_signal_y[i];
                double y_wn = wn_signal_y[i];

                SignGraph.Series[0].Points.AddXY(x, y);

                SignGraph.Series[1].Points.AddXY(x, y_wn);

                SignGraph.ChartAreas[0].AxisX.Interval = min_phase * 20;
            }

            full_energy = forform.GetEnergy();

            forform.Clear();
        }

        private void AfterFur_Click(object sender, EventArgs e)
        {
            double energy = 0.0;

            for (UInt16 i = 0; i < l; ++i)
            {
                energy += Math.Sqrt(spisok[i].im_amplitude * spisok[i].im_amplitude + spisok[i].real_amplitude * spisok[i].real_amplitude);
                if (energy > full_energy - 0.01 * full_energy && energy < full_energy + 0.01 * full_energy)
                {
                    while (i != l - i)
                    {
                        spisok[i + 1] = new dot(0.0, 0.0, i);
                        spisok[l - i] = new dot(0.0, 0.0, Convert.ToUInt16(l-i));

                        ++i;
                    }
                    break;
                }
            }

            SignGraph.Series[2].Points.Clear();
            forform.Clear();

            SignGraph.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            SignGraph.Series[2].Color = Color.Red;

            for (int i = 0; i < l; i++)
            {
                double x = spisok[i].x_pos * min_phase;
                double y = Math.Sqrt(spisok[i].im_amplitude * spisok[i].im_amplitude + spisok[i].real_amplitude * spisok[i].real_amplitude);

                SignGraph.Series[2].Points.AddXY(x, y);

            }

        }

        private void SinCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            SignGraph.Series[0].Points.Clear();
            SignGraph.Series[1].Points.Clear();
            SignGraph.Series[2].Points.Clear();
            forform.Clear();
            spisok.Clear();
        }

        private void BackFur_Click(object sender, EventArgs e)
        {
            SignGraph.Series[1].Points.Clear();
            SignGraph.Series[2].Points.Clear();

            forform.Fourea(spisok, Convert.ToInt32(Fur1.Text), 1);

            SignGraph.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            SignGraph.Series[2].Color = Color.Red;

            for (int i = 0; i < l; i++)
            {
                double x = spisok[i].x_pos *min_phase;
                double y =  spisok[i].real_amplitude ;

                SignGraph.Series[2].Points.AddXY(x, y);

            }
        }

        private void FrontFur_Click(object sender, EventArgs e)
        {
            SignGraph.Series[1].Points.Clear();
            SignGraph.Series[2].Points.Clear();

            forform.Fourea(spisok, Convert.ToInt32(Fur1.Text), (-1));

            SignGraph.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            SignGraph.Series[2].Color = Color.Red;

            for (int i = 0; i < l; i++)
            {
                double x = spisok[i].x_pos * min_phase;
                double y = Math.Sqrt(spisok[i].real_amplitude * spisok[i].real_amplitude + spisok[i].im_amplitude * spisok[i].im_amplitude);

                SignGraph.Series[2].Points.AddXY(x, y);

            }
        }
    }
}    


