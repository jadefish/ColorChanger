using System;
using System.Windows.Forms;
using ColorChanger;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;

namespace ColorChanger.Controls
{
	/// <summary>
	/// A natively-themed SplitButton control that shows the control's ContextMenu when the dropdown portion is clicked.
	/// </summary>
	[Description("A natively-themed SplitButton control that shows the control's ContextMenu when the dropdown portion is clicked.")]
	class SplitButton : Button
	{
		private bool splitter = true;
		private ContextMenu dropdownMenu;

		/// <summary>
		/// Determines whether the button will have a distinct button and dropdown component, or simply function as a dropdown menu.
		/// </summary>
		[Description("Determines whether the button will have a distinct button and dropdown component, or simply function as a dropdown menu.")]
		[DefaultValue(true)]
		public bool Splitter
		{
			get { return this.splitter; }
			set
			{
				if (this.splitter != value)
				{
					this.splitter = value;
					ToggleSplitter(value);
					this.Refresh();
				}
			}
		}

		/// <summary>
		/// The menu to display when the user clicks the dropdown portion of the button.
		/// </summary>
		[Description("The menu to display when the user clicks the dropdown portion of the button.")]
		public ContextMenu DropdownMenu
		{
			get { return this.dropdownMenu; }
			set { this.dropdownMenu = value; }
		}

		protected override CreateParams CreateParams
		{
			get
			{
				// Style the button like a SplitButton:
				CreateParams createParams = base.CreateParams;
				createParams.Style |= NativeMethods.BS_SPLITBUTTON;
				return createParams;
			}
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case (NativeMethods.BCN_SETDROPDOWNSTATE):
					if (m.HWnd == this.Handle && m.WParam == (IntPtr)1)
					{
						ShowDropdownMenu();
					}
					break;
			}

			base.WndProc(ref m);
		}

		protected override void OnClick(EventArgs e)
		{
			if (!this.splitter)
			{
				ShowDropdownMenu();
			}

			base.OnClick(e);
		}

		private void ToggleSplitter(bool visible)
		{
			// BS_SPLITBUTTON is Vista or later only. For now, there's no pre-Vista support.
			if (Environment.OSVersion.Version.Major >= 6)
			{
				// Set the button's split info based on visible:
				NativeMethods.BUTTON_SPLITINFO splitInfo = new NativeMethods.BUTTON_SPLITINFO();
				splitInfo.mask = NativeMethods.BCSIF_STYLE;
				splitInfo.uSplitStyle = ~(uint)(visible ? 1 : 0) & NativeMethods.BCSS_NOSPLIT;

				IntPtr splitInfoPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(splitInfo));
				Marshal.StructureToPtr(splitInfo, splitInfoPtr, false);

				NativeMethods.SendMessage(this.Handle, NativeMethods.BCM_SETSPLITINFO, IntPtr.Zero, splitInfoPtr);
			}
		}

		private void ShowDropdownMenu()
		{
			if (this.dropdownMenu != null)
			{
				this.dropdownMenu.Show(this, new Point(this.Right, this.Bottom), LeftRightAlignment.Left);
			}
		}
	}
}
