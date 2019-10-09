#include "SignalAnalysis.h";
#define DllExport   __declspec( dllexport )


extern "C"
{
	DllExport int __stdcall SysAnalInterface(int a);
}


DllExport int __stdcall  SysAnalInterface(int a) {
	SigGen s;

	return 2*a;
};