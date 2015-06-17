// WorkAreaUtilityLib.h

#pragma once

namespace WorkAreaUtilityLib {
	public ref class HMonitor
	{
		HMONITOR monitor;
		MONITORINFOEX* info;
		bool isDisposed;
	public:
		HMonitor(HMONITOR handle);
		~HMonitor();
		!HMonitor();

		static array<HMonitor^>^ GetAllScreens();

		void SetWorkArea(System::Drawing::Rectangle p);
		void SetWorkAreaPadding(System::Windows::Forms::Padding p);

		virtual System::String^ ToString() override {
			return System::String::Format("{0}x{1} ({2})", Width, Height, DeviceName);
		}

		property System::IntPtr Handle {
			System::IntPtr get() {
				return (System::IntPtr)monitor;
			}
		}
		property System::Drawing::Rectangle MonitorCoordinates {
			System::Drawing::Rectangle get() {
				return System::Drawing::Rectangle(
					info->rcMonitor.left,
					info->rcMonitor.top,
					info->rcMonitor.right - info->rcMonitor.left,
					info->rcMonitor.bottom - info->rcMonitor.top);
			}
		}
		property System::Drawing::Rectangle WorkArea {
			System::Drawing::Rectangle get() {
				return System::Drawing::Rectangle(
					info->rcWork.left,
					info->rcWork.top,
					info->rcWork.right - info->rcWork.left,
					info->rcWork.bottom - info->rcWork.top);
			}
		}
		property System::Windows::Forms::Padding WorkAreaPadding {
			System::Windows::Forms::Padding get() {
				return System::Windows::Forms::Padding(
					info->rcWork.left - info->rcMonitor.left,
					info->rcWork.top - info->rcMonitor.top,
					info->rcMonitor.right - info->rcWork.right,
					info->rcMonitor.bottom - info->rcWork.bottom);
			}
		}
		property bool Primary {
			bool get() {
				return (info->dwFlags & MONITORINFOF_PRIMARY) != 0;
			}
		}
		property System::String^ DeviceName {
			System::String^ get() {
				return gcnew System::String(info->szDevice);
			}
		}
		property int Width {
			int get() {
				return info->rcMonitor.right - info->rcMonitor.left;
			}
		}
		property int Height {
			int get() {
				return info->rcMonitor.bottom - info->rcMonitor.top;
			}
		}
	};
}
