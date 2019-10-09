
#include "SignalAnalysis.h"

void fourea(struct cmplx *data,int n,int is)
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
		temp_r=data[j].real;
		temp_i=data[j].image;
		  data[j].real=data[i].real;
		  data[j].image=data[i].image;
			data[i].real=temp_r;
			data[i].image=temp_i;
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
				temp_r=w_r*data[j].real - w_i*data[j].image;
				temp_i=w_r*data[j].image + w_i*data[j].real;
				  data[j].real=data[i].real - temp_r;
				  data[j].image=data[i].image - temp_i;
					data[i].real+=temp_r;
					data[i].image+=temp_i;
				}
			}
		mmax=istep;
		}
		if (is > 0) {
			for (i = 0; i < n; i++)
			{
				data[i].real /= (float)n;
				data[i].image /= (float)n;
			}
		}
}


void SigGen::SinGen(double ampl, double phase, double samp_freq, int first, int last)
{

	for (int i = first; i < last; i++)
	{
		//signal.push_back();
		complex a; dot b;

		a.real += ampl * sin(2. * M_PI * samp_freq * i + samp_freq);
		b.amplitude = a;
		b.x_pos = i;
		signal[i] = b;
		size++;
		sign_energy += a.real * a.real;
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
			rand_part += rand() % 1 - 1;
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
