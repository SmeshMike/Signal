#include "SignalAnalysis.h";
#define DllExport   __declspec( dllexport )


int size = 0;
double ampl;
double phase;
double freeq;

SigGen s;	

int start;
int finish;


extern "C"
{
	DllExport void __stdcall Run(double ampl, double phase, double freeq, int first, int last);
	//DllExport void __stdcall PushSignal(double ampl, double phase, double freeq, int first, int last);
	DllExport void __stdcall  GetS();
	DllExport int __stdcall GetX(int key);
	DllExport double __stdcall GetY(int key);
	DllExport int __stdcall GetSize();
	DllExport void __stdcall Clear();
	DllExport void __stdcall AddNoise(int percent);
	DllExport void __stdcall Fur();
}


DllExport void __stdcall  Run(double ampl, double phase, double freeq, int first, int last)
{

	// vector<smth>.data() == smth* arr

	s.SinGen(ampl,phase,freeq, first, last);
	
};

DllExport void __stdcall  GetS()
{
	s.GetS();
}

/*DllExport void __stdcall PushSignal(double a, double p, double f, int fs, int l) {

	//Заполняем массивы
	ampl.push_back(a);
	phase.push_back(p);
	freeq.push_back(f);

	start.push_back(fs);
	finish.push_back(l);

	++size;

}*/

DllExport int __stdcall GetSize()
{
	return size;
}

DllExport int __stdcall GetX(int key)
{
	return s.GetXPoints(key);
}

DllExport double __stdcall GetY( int key)
{
	return s.GetYPoints(key);
}

DllExport void __stdcall Clear()
{
	s.Clear();
}

DllExport void __stdcall AddNoise(int percent)
{
	s.SignalwithWhiteNoise(percent);
}

DllExport void __stdcall Fur()
{
	s.fourea();
}