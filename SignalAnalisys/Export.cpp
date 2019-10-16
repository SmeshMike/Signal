#include "SignalAnalysis.h";
#define DllExport   __declspec( dllexport )


int size = 0;
double ampl;
double phase;
double freeq;

int start;
int finish;


extern "C"
{
	DllExport void __stdcall Run(double ampl, double phase, double freeq, int first, int last);
	DllExport void __stdcall PushSignal(double ampl, double phase, double freeq, int first, int last);

	DllExport int __stdcall GetSize();
}


DllExport void __stdcall  Run(double ampl, double phase, double freeq, int first, int last) {
	
	SigGen s; 

	// vector<smth>.data() == smth* arr

	s.SinGen(ampl,phase,freeq, first, last);
};

DllExport void __stdcall  GetS()
{
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

DllExport int __stdcall GetSize() {
	return size;
}