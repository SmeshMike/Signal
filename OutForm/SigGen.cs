using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpace
{
    class SigGen
    {
        public struct dot
        {
            public double real_amplitude; public double im_amplitude; public UInt16 x_pos;
            public dot(double param1, double param2, UInt16 param3)
            { real_amplitude = param1; im_amplitude = param2; x_pos = param3; }

        }

        //double[] temp = new double[size];

        List<dot> signal = new List<dot>();

        private Int16 size;
        private double noise_energy;
        private double signal_energy;

        public SigGen()
        {
            size = 0;
            noise_energy = 0.0;
            signal_energy = 0.0;
        }

        public void SinGen(double ampl, double phase, double samp_freq, UInt16 first, UInt16 last)
        {
            for (UInt16 i = first; i < last; i++)
            {
                bool k = false;
                dot temp = new dot(ampl * Math.Sin(phase * i + samp_freq), 0, i);


                for (int j = 0; j < signal.Count; j++)
                {
                    if (signal[j].x_pos == i)
                    {
                        signal[j] = new dot(signal[j].real_amplitude + ampl * Math.Sin(phase * i + samp_freq), 0, i);
                       k = true;

                       break;
                    }
                }

                if (!k)
                {
                    signal.Add(temp);
                    size++;
                    signal_energy += signal[i].real_amplitude * signal[i].real_amplitude;
                }
            }
        }
        public void Fourea(List<dot> sig, int n, int s)
        {
            int i, j, istep;
            int m, mmax;
            double r, r1, theta, w_r, w_i, temp_r, temp_i;
            double pi = 3.1415926f;

            r = pi * s;
            j = 0;
            for (i = 0; i < n; i++)
            {
                if (i < j)
                {

                    temp_r = sig[j].real_amplitude;
                    temp_i = sig[j].im_amplitude;

                    sig[j] = new dot(sig[i].real_amplitude, sig[i].im_amplitude, sig[j].x_pos);
                    sig[i] = new dot(temp_r, temp_i, sig[i].x_pos);
                }
                m = n >> 1;
                while (j >= m) { j -= m; m = (m + 1) / 2; }
                j += m;
            }
            mmax = 1;
            while (mmax < n)
            {
                istep = mmax << 1;
                r1 = r / (double)mmax;
                for (m = 0; m < mmax; m++)
                {
                    theta = r1 * m;
                    w_r = (double)Math.Cos((double)theta);
                    w_i = (double)Math.Sin((double)theta);
                    for (i = m; i < n; i += istep)
                    {

                        j = i + mmax;
                        temp_r = w_r * sig[j].real_amplitude - w_i * sig[j].im_amplitude;
                        temp_i = w_r * sig[j].im_amplitude + w_i * sig[j].real_amplitude;

                        sig[j] = new dot(sig[i].real_amplitude - temp_r, sig[i].im_amplitude - temp_i, sig[j].x_pos);

                        sig[i] = new dot(sig[i].real_amplitude + temp_r, sig[i].im_amplitude + temp_i, sig[i].x_pos);
                    }
                }
                mmax = istep;
            }
            if (s > 0)
                for (i = 0; i < n; i++)
                {
                    sig[i] = new dot(sig[i].real_amplitude / (Convert.ToDouble(n)), sig[i].im_amplitude / (Convert.ToDouble(n)), sig[i].x_pos);
                }

        }

        public void SignalGen(int sin_count, double[] _ampl, double[] _phase, double[] _samp_freq, UInt16[] _first, UInt16[] _last)
        {
            for (int i = 0; i < sin_count; i++)
            {
                SinGen(_ampl[i], _phase[i], _samp_freq[i], _first[i], _last[i]);
            }
        }
        public void SignalwithWhiteNoise(int percent)
        {
            double[] noise = new double[size];
            Random rnd = new Random();
            double rand_part = 0;
            double new_rand = 0.0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    rand_part += rnd.NextDouble() * 2 - 1;
                }
                new_rand = rand_part / 10 ;

                noise_energy += new_rand * new_rand;
                noise[i] = new_rand * percent / 100;

                rand_part = 0;
            }

            for (UInt16 i = 0; i < size; i++)
            {
                signal[i] = new dot(signal[i].real_amplitude + percent * noise[i], 0, i);
            }
        }

        public double GetYPoints(int key)
        {
            return signal[key].real_amplitude;
        }
        public int GetXPoints(int key)
        {
            return signal[key].x_pos;
        }
        public int GetS()
        {
            return size;
        }
        public void Clear()
        {
            signal.Clear();
            size = 0;
            signal_energy = 0;
            noise_energy = 0;
        }
        public int GetCoef()
        {
            return Convert.ToInt32(Math.Sqrt(signal_energy / noise_energy));
        }

        public double GetEnergy()
        {
            return signal_energy + noise_energy;
        }


        public int Nevyazki(List<dot> sig, List<dot> sign)
        {
            double temp= 0.0;

            for (UInt16 i = 0; i < sig.Count; i++)
            {
                temp += (sign[i].real_amplitude - sig[i].real_amplitude)* (sign[i].real_amplitude - sig[i].real_amplitude);
            }

            return Convert.ToInt32(temp);
        }

        
    }
}
