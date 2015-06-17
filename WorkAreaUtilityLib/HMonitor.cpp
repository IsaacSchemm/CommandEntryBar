// This is the main DLL file.

#include "stdafx.h"

#include "HMonitor.h"
#include <vector>

using namespace System;
using std::vector;

BOOL CALLBACK monitorEnumCallback(HMONITOR hMonitor, HDC hdcMonitor, LPRECT lprcMonitor, LPARAM dwData) {
	vector<HMONITOR>* vptr = (vector<HMONITOR>*)dwData;
	vptr->push_back(hMonitor);
	return TRUE;
}

namespace WorkAreaUtilityLib {
	HMonitor::HMonitor(HMONITOR handle) {
		monitor = handle;
		info = (MONITORINFOEX*)malloc(sizeof(MONITORINFOEX));
		info->cbSize = sizeof(MONITORINFOEX);
		GetMonitorInfo(monitor, info);
		isDisposed = false;
	}

	HMonitor::~HMonitor() {
		if (isDisposed) return;

		this->!HMonitor();
		isDisposed = true;
	}

	HMonitor::!HMonitor() {
		free(info);
	}

	void HMonitor::SetWorkArea(Drawing::Rectangle p) {
		RECT r;
		r.left = p.Left;
		r.top = p.Top;
		r.right = p.Right;
		r.bottom = p.Bottom;
		if (!SystemParametersInfo(SPI_SETWORKAREA, 0, &r, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE)) {
			throw gcnew Exception("Error code " + GetLastError().ToString());
		}
		GetMonitorInfo(monitor, info);
	}

	void HMonitor::SetWorkAreaPadding(Windows::Forms::Padding p) {
		RECT r;
		r.left = info->rcMonitor.left + p.Left;
		r.top = info->rcMonitor.top + p.Top;
		r.right = info->rcMonitor.right - p.Right;
		r.bottom = info->rcMonitor.bottom - p.Bottom;
		if (!SystemParametersInfo(SPI_SETWORKAREA, 0, &r, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE)) {
			throw gcnew Exception("Error code " + GetLastError().ToString());
		}
		GetMonitorInfo(monitor, info);
	}

	array<HMonitor^>^ HMonitor::GetAllScreens() {
		vector<HMONITOR> v;
		EnumDisplayMonitors(NULL, NULL, monitorEnumCallback, (LPARAM)&v);

		int size = v.size();
		array<HMonitor^>^ arr = gcnew array<HMonitor^>(size);
		for (int i = 0; i < size; i++) {
			arr[i] = gcnew HMonitor(v[i]);
		}

		return arr;
	}
}
