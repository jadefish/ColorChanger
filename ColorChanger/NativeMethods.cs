using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ColorChanger
{
	static class NativeMethods
	{
		internal const int BS_SPLITBUTTON = 0x0000000C;
		internal const int BCN_SETDROPDOWNSTATE = 0x1606;

		internal const int BCSIF_GLYPH = 1;
		internal const int BCSIF_IMAGE = 2;
		internal const int BCSIF_STYLE = 4;
		internal const int BCSIF_SIZE = 8;

		internal const int BCSS_NOSPLIT = 1;
		internal const int BCSS_STRETCH = 2;
		internal const int BCSS_ALIGNLEFT = 4;
		internal const int BCSS_IMAGE = 8;

		internal const uint HWND_BROADCAST = 0xffff;
		internal const uint BCM_SETSPLITINFO = 0x1607;
		internal static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");

		internal const int TVP_TREEITEM = 1;
		internal const int TREIS_SELECTED = 3;

		internal struct SIZE
		{
			public long cx;
			public long cy;
		}
		internal struct BUTTON_SPLITINFO
		{
			public uint mask;
			public IntPtr himlGlyph;
			public uint uSplitStyle;
			public SIZE size;
		}
		private struct DWM_COLORIZATION_PARAMS
		{
			public uint clrColor;
			public uint clrAfterGlow;
			public uint nIntensity;
			public uint clrAfterGlowBalance;
			public uint clrBlurBalance;
			public uint clrGlassReflectionIntensity;
			public bool fOpaque;
		}
		[StructLayout(LayoutKind.Sequential)] public struct RECT
		{
			public int Left, Top, Right, Bottom;

			public RECT(int left, int top, int right, int bottom)
			{
				Left = left;
				Top = top;
				Right = right;
				Bottom = bottom;
			}

			public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

			public int X
			{
				get { return Left; }
				set { Right -= (Left - value); Left = value; }
			}

			public int Y
			{
				get { return Top; }
				set { Bottom -= (Top - value); Top = value; }
			}

			public int Height
			{
				get { return Bottom - Top; }
				set { Bottom = value + Top; }
			}

			public int Width
			{
				get { return Right - Left; }
				set { Right = value + Left; }
			}

			public System.Drawing.Point Location
			{
				get { return new System.Drawing.Point(Left, Top); }
				set { X = value.X; Y = value.Y; }
			}

			public System.Drawing.Size Size
			{
				get { return new System.Drawing.Size(Width, Height); }
				set { Width = value.Width; Height = value.Height; }
			}

			public static implicit operator System.Drawing.Rectangle(RECT r)
			{
				return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
			}

			public static implicit operator RECT(System.Drawing.Rectangle r)
			{
				return new RECT(r);
			}

			public static bool operator ==(RECT r1, RECT r2)
			{
				return r1.Equals(r2);
			}

			public static bool operator !=(RECT r1, RECT r2)
			{
				return !r1.Equals(r2);
			}

			public bool Equals(RECT r)
			{
				return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
			}

			public override bool Equals(object obj)
			{
				if (obj is RECT)
					return Equals((RECT)obj);
				else if (obj is System.Drawing.Rectangle)
					return Equals(new RECT((System.Drawing.Rectangle)obj));
				return false;
			}

			public override int GetHashCode()
			{
				return ((System.Drawing.Rectangle)this).GetHashCode();
			}

			public override string ToString()
			{
				return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
			}
		}
		public enum ShowWindowCommands
		{
			/// <summary>
			/// Hides the window and activates another window.
			/// </summary>
			Hide = 0,
			/// <summary>
			/// Activates and displays a window. If the window is minimized or 
			/// maximized, the system restores it to its original size and position.
			/// An application should specify this flag when displaying the window 
			/// for the first time.
			/// </summary>
			Normal = 1,
			/// <summary>
			/// Activates the window and displays it as a minimized window.
			/// </summary>
			ShowMinimized = 2,
			/// <summary>
			/// Maximizes the specified window.
			/// </summary>
			Maximize = 3, // is this the right value?
			/// <summary>
			/// Activates the window and displays it as a maximized window.
			/// </summary>       
			ShowMaximized = 3,
			/// <summary>
			/// Displays a window in its most recent size and position. This value 
			/// is similar to <see cref="Win32.ShowWindowCommand.Normal"/>, except 
			/// the window is not activated.
			/// </summary>
			ShowNoActivate = 4,
			/// <summary>
			/// Activates the window and displays it in its current size and position. 
			/// </summary>
			Show = 5,
			/// <summary>
			/// Minimizes the specified window and activates the next top-level 
			/// window in the Z order.
			/// </summary>
			Minimize = 6,
			/// <summary>
			/// Displays the window as a minimized window. This value is similar to
			/// <see cref="Win32.ShowWindowCommand.ShowMinimized"/>, except the 
			/// window is not activated.
			/// </summary>
			ShowMinNoActive = 7,
			/// <summary>
			/// Displays the window in its current size and position. This value is 
			/// similar to <see cref="Win32.ShowWindowCommand.Show"/>, except the 
			/// window is not activated.
			/// </summary>
			ShowNA = 8,
			/// <summary>
			/// Activates and displays the window. If the window is minimized or 
			/// maximized, the system restores it to its original size and position. 
			/// An application should specify this flag when restoring a minimized window.
			/// </summary>
			Restore = 9,
			/// <summary>
			/// Sets the show state based on the SW_* value specified in the 
			/// STARTUPINFO structure passed to the CreateProcess function by the 
			/// program that started the application.
			/// </summary>
			ShowDefault = 10,
			/// <summary>
			///  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread 
			/// that owns the window is not responding. This flag should only be 
			/// used when minimizing windows from a different thread.
			/// </summary>
			ForceMinimize = 11
		}
		[StructLayout(LayoutKind.Sequential)] public struct PAINTSTRUCT
		{
			public IntPtr hdc;
			public bool fErase;
			public RECT rcPaint;
			public bool fRestore;
			public bool fIncUpdate;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public byte[] rgbReserved;
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("dwmapi.dll", EntryPoint = "#127", PreserveSig = false)]
		private static extern void DwmGetColorizationParameters(out DWM_COLORIZATION_PARAMS parameters);

		[DllImport("dwmapi.dll", EntryPoint = "#131", PreserveSig = false)]
		private static extern void DwmSetColorizationParameters(ref DWM_COLORIZATION_PARAMS parameters, bool unknown);

		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32")]
		public static extern int RegisterWindowMessage(string message);

		[DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern IntPtr OpenThemeData(IntPtr hWnd, String classList);

		[DllImport("uxtheme", ExactSpelling = true)]
		public static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
		   int iStateId, ref RECT pRect, ref RECT pClipRect);

		[DllImport("uxtheme", ExactSpelling = true)]
		public static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
		   int iStateId, ref RECT pRect, IntPtr pClipRect);

		[DllImport("uxtheme", ExactSpelling = true)]
		public static extern int DrawThemeParentBackground(IntPtr hWnd, IntPtr hdc, ref RECT pRect);

		[DllImport("uxtheme", ExactSpelling = true)]
		public static extern int DrawThemeParentBackground(IntPtr hWnd, IntPtr hdc, int pRect);

		[DllImport("uxtheme.dll", ExactSpelling = true)]
		public static extern int CloseThemeData(IntPtr hTheme);

		[DllImport("user32.dll")]
		public static extern IntPtr BeginPaint(IntPtr hwnd, out PAINTSTRUCT lpPaint);

		[DllImport("user32.dll")]
		public static extern bool EndPaint(IntPtr hWnd, [In] ref PAINTSTRUCT lpPaint);

		[DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);

		/// <summary>
		/// Converts .NET Color structure to a Win32 BGRA color.
		/// </summary>
		/// <param name="color">The Color structure to convert to BGRA format.</param>
		/// <returns>A BGRA-format color representing the specified .NET Color.</returns>
		private static uint ColorToBgra(Color color)
		{
			return (uint)(color.B | (color.G << 8) | (color.R << 16) | (color.A << 24));
		}
		
		/// <summary>
		/// Converts Win32 BGRA color to a .NET Color structure.
		/// </summary>
		/// <param name="color">The BGRA color to convert to a .NET Color structure.</param>
		/// <returns>A .NET Color structure representing the specified Win32 BGRA color.</returns>
		private static Color BgraToColor(uint color)
		{
			return Color.FromArgb(Int32.Parse(color.ToString("X"), NumberStyles.HexNumber));
		}

		public static void SetWindowColor(Color color)
		{
			DWM_COLORIZATION_PARAMS dwmParams = new DWM_COLORIZATION_PARAMS();
			DwmGetColorizationParameters(out dwmParams);
			dwmParams.clrColor = ColorToBgra(color);
			dwmParams.nIntensity = 100;
			dwmParams.clrAfterGlow = dwmParams.clrColor;

			try
			{
				DwmSetColorizationParameters(ref dwmParams, false);
			}
			catch (ExternalException)
			{
				// TODO: Often occurs if DwmSetColorizationParameters is called before a color change
				// has completed. Need to handle it.
			}
		}
		
		public static Color GetWindowColor()
		{
			DWM_COLORIZATION_PARAMS dwmParams = new DWM_COLORIZATION_PARAMS();
			DwmGetColorizationParameters(out dwmParams);
			return BgraToColor(dwmParams.clrColor);
		}
	}
}
