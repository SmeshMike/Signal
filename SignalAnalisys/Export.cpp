#include "SignalAnalysis.h";
#define DllExport   __declspec( dllexport )


extern "C"
{
	DllExport int __stdcall SysAnalInterface(int len, double* ampl, double* phase, double* freeq);
}


DllExport int __stdcall  SysAnalInterface(int len, const double* ampl, const double* phase, const double* freeq ) {
	SigGen s;

	double* a = new double[len];
	double* b = new double[len];
	double* c = new double[len];
	for (int i = 0; i < len; ++i)
	{
		a[i] = ampl[i];
		b[i] = phase[i];
		c[i] = freeq[i];
	}

	s.SignalGen(len,a,b,c, nullptr, nullptr);

	delete[] a;
	delete[] b;
	delete[] c;

	return 10;
};