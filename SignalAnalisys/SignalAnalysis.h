#define M_PI       3.14159265358979323846
#include <math.h>
#include <iostream>
#include <stdlib.h>
#include <vector>
#include <list>

typedef struct cmplx { float real; float image; } Cmplx;

struct complex
{
	double real = 0.0; double imagine = 0.0;
};

class SigGen
{
public:
	struct dot
	{
		complex amplitude; int x_pos;
	};
private:
	std::vector <dot> signal;
	int size;
	double noise_energy;
	double sign_energy;

	void Quicksort(std::vector<dot> item, int len);
	void Qs(std::vector<dot> item, int left, int right);

public:
	SigGen() 
	{
		size = 0;
		noise_energy = 0.0;
		sign_energy = 0.0;
	}

	void SinGen(double ampl, double phase, double samp_freq, int first, int last);
	void SignalGen(int sin_count, double _ampl[], double _phase[], double _samp_freq[], int _first[], int _last[]);
	void SignalwithWhiteNoise(std::vector<dot> k, int percent);	
};