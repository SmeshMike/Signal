
#include "SignalAnalysis.h"
double fRand(double fMin, double fMax);

void SigGen::fourea(std::vector<dot> data,int n,int is)
{
	int i,j,istep;
	int m,mmax;
	float r,r1,theta,w_r,w_i,temp_r,temp_i;
	float pi=3.1415926f;

	r=pi*is;
	j=0;
	for(i=0;i<n;i++)
	{
	if(i<j)
		{
		temp_r=data[j].amplitude.real;
		temp_i=data[j].amplitude.imagine;
		  data[j].amplitude.real=data[i].amplitude.real;
		  data[j].amplitude.imagine=data[i].amplitude.imagine;
			data[i].amplitude.real=temp_r;
			data[i].amplitude.imagine=temp_i;
		}
		m=n>>1;
		while(j>=m) { j-=m; m=(m+1)/2; }
		j+=m;
	}
		mmax=1;
		while(mmax<n)
		{
		istep=mmax<<1;
		r1=r/(float)mmax;
		for(m=0;m<mmax;m++)
			{
			theta=r1*m;
			w_r=(float)cos((double)theta);
			w_i=(float)sin((double)theta);
			for(i=m;i<n;i+=istep)
				{
				j=i+mmax;
				temp_r=w_r*data[j].amplitude.real - w_i*data[j].amplitude.imagine;
				temp_i=w_r*data[j].amplitude.imagine + w_i*data[j].amplitude.real;
				  data[j].amplitude.real=data[i].amplitude.real - temp_r;
				  data[j].amplitude.imagine=data[i].amplitude.imagine - temp_i;
					data[i].amplitude.real+=temp_r;
					data[i].amplitude.imagine+=temp_i;
				}
			}
		mmax=istep;
		}
		if (is > 0) {
			for (i = 0; i < n; i++)
			{
				data[i].amplitude.real /= (float)n;
				data[i].amplitude.imagine /= (float)n;
			}
		}
}


void SigGen::SinGen(double ampl, double phase, double samp_freq, int first, int last)
{

	for (int i = first; i < last; i++)
	{	
		bool k = false;
		complex a; dot b;
		a.real = ampl * sin(2. * M_PI * samp_freq * i + samp_freq);

		b.amplitude = a;
		b.x_pos = i;		

		for (int j = 0; j < signal.size(); j++)
		{
			if (signal[j].x_pos == i) 
			{
				signal[j].amplitude.real += a.real;
				signal[j].amplitude.imagine += a.imagine;
				k = true;


				break;
			}

		}
		if (!k)
		{
			signal.push_back(b);
			size++;
			sign_energy += a.real * a.real;
		}
	}
}

void SigGen::SignalGen(int sin_count, double _ampl[], double _phase[], double _samp_freq[], int _first[], int _last[])
{

	for (int i = 0; i < sin_count; i++)
	{
		SinGen(_ampl[i], _phase[i], _samp_freq[i], _first[i], _last[i]);
	}


	//	return signal;
}

void SigGen::SignalwithWhiteNoise(std::vector<dot> k, int ampl)
{
	for (int i = 0; i < size; i++)
	{

		double rand_part;
		for (int j = 0; j < 45; j++)
		{
			rand_part += fRand(-1, 1);
		}
		rand_part = rand_part / 45;

		noise_energy += rand_part * rand_part;

		k[i].amplitude.real = rand_part;
		rand_part = 0;
	}
}


void SigGen::Quicksort(std::vector<dot> item, int len)
{
	Qs(item, 0, len - 1);
}

void SigGen::Qs(std::vector<dot> item, int left, int right)
{
	int i, j, x;
	dot y;
	i = left;   j = right;
	x = item[(left + right) / 2].x_pos;
	do {
		while ((item[i].x_pos < x) && (i < right)); i++;
		while ((x < item[j].x_pos) && (j > left)); j--;
		if (i <= j)
		{
			y = item[i];
			item[i] = item[j];
			item[j] = y;
			i++; j--;
		}
	} while (i <= j);

	if (left < j) Qs(item, left, j);
	if (i < right) Qs(item, i, right);
}


double fRand(double fMin, double fMax)
{
	double f = (double)rand() / RAND_MAX;
	return fMin + f * (fMax - fMin);
}
