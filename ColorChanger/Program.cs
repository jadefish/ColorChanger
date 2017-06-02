using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorChanger
{
	static class Program
	{
		static Mutex mutex;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			bool firstInstance = false;

			// Use a mutex to ensure only a single instance is running:
			mutex = new Mutex(true, Constants.MUTEX_GUID, out firstInstance);

			if (firstInstance)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				Application.Run(new SettingsForm());
				mutex.ReleaseMutex();
			}
			else
			{
				// Activate existing instance if one is already running:
				NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, (uint)NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
			}

		}
	}
}
