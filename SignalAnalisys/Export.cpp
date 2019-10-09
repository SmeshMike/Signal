#include "SignalAnalysis.h";
#define DllExport   __declspec( dllexport )


int size = 0;
std::vector<double> ampl;
std::vector<double> phase;
std::vector<double> freeq;

std::vector<int> start;
std::vector<int> finish;

extern "C"
{
	DllExport void __stdcall Run();
	DllExport void __stdcall PushSignal(double ampl, double phase, double freeq, int first, int last);

	DllExport int __stdcall GetSize();
}


DllExport void __stdcall  Run() {
	
	SigGen s; 

	// vector<smth>.data() == smth* arr

	s.SignalGen(size,ampl.data(),phase.data(),freeq.data(), start.data(), finish.data());
};

DllExport void __stdcall PushSignal(double a, double p, double f, int fs, int l) {

	//Заполняем массивы
	ampl.push_back(a);
	phase.push_back(p);
	freeq.push_back(f);

	start.push_back(fs);
	finish.push_back(l);

	++size;

}

DllExport int __stdcall GetSize() {
	return size;
}