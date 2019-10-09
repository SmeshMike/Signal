#define M_PI       3.14159265358979323846
#include <math.h>
#include <iostream>
#include <stdlib.h>
#include <vector>
#include <list>

using namespace std;

typedef struct cmplx { float real; float image; } Cmplx;

class AddNoise
{
public:
	struct complex
	{
		double real = 0.0; double imagine = 0.0;
	};

	struct dot
	{
		complex amplitude; int x_pos;
	};

	int size = 0;

	double noise_energy = 0;

	double sign_energy = 0;

	//void quicksort(vector<dot> item, int len);

	//void qs(vector<dot> item, int left, int right);

	vector <dot> signal;			//Массив структуры для кранения значений амплитуд

	//void SinGen(double ampl, double phase, double samp_freq, int first, int last);		//Функция генящая синусоиду

	//void SignalGen(int sin_count, double _ampl[], double _phase[], double _samp_freq[], int _first[], int _last[]);		//функция складывающая синусоиды

	//void SignalwithWhiteNoise(vector<dot> k, int percent);

	void SinGen(double ampl, double phase, double samp_freq, int first, int last)
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

	void SignalGen(int sin_count, double _ampl[], double _phase[], double _samp_freq[], int _first[], int _last[])
	{

		for (int i = 0; i < sin_count; i++)
		{
			SinGen(_ampl[i], _phase[i], _samp_freq[i], _first[i], _last[i]);
		}


	//	return signal;
	}

	void SignalwithWhiteNoise(vector<dot> k, int ampl)
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


	void quicksort(vector<dot> item, int len)
	{
		qs(item, 0, len - 1);
	}

	void qs(vector<dot> item, int left, int right)
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

		if (left < j) qs(item, left, j);
		if (i < right) qs(item, i, right);
	}
};