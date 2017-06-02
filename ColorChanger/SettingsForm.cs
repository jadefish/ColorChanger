using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ColorChanger.Controls;
using Microsoft.Win32;
using System.Security;
using System.IO;

namespace ColorChanger
{
	public partial class SettingsForm : Form
	{
		// TODO: Get from system metrics
		private const int TRAY_ICON_SIZE = 16;

		private const string DICTIONARY_STRING_FORMAT = "{0}: {1}\r\n";
		private const string COLOR_STRING_FORMAT = "ARGB: 255, {0}, {1}, {2}; Hex: #{3:X}";
		private static readonly Rectangle TRAY_ICON_RECTANGLE = new Rectangle(0, 0, 16, 16);
		private const int FADE_DURATION = 5;		// in seconds
		private const float QUICK_FADE_FACTOR = 25F;
		private const float MEDIUM_FADE_FACTOR = 10F;
		private const float SLOW_FADE_FACTOR = 5F;
		private float CurrentFadeFactor = SLOW_FADE_FACTOR;
		private List<Color> colors = new List<Color>();
		private Color selectedColor = Color.Black;
		private bool canShow = false;
		public bool canExit = false;
		private Settings settings = new Settings();
		private bool databinding = false;
		private Timer timer = new Timer();
		private bool changingColors = false;

		public SettingsForm()
		{
			InitializeComponent();

			// Reduce flicker for drawing form separators:
			this.SetStyle(ControlStyles.ResizeRedraw
				| ControlStyles.DoubleBuffer
				| ControlStyles.OptimizedDoubleBuffer,
				true);

			// Read settings, or create a default set if none exist:
			Settings.Deserialize(out this.settings, Constants.SETTINGS_PATH);
			
			this.Font = SystemFonts.MessageBoxFont;
			toolStrip_colors.Renderer = new FlatToolStripRenderer();
			label_colorsInstruction.Font = SystemFonts.CaptionFont;
			label_colorsInstruction.Height = (int)(label_colorsInstruction.CreateGraphics().MeasureString(label_colorsInstruction.Text, label_colorsInstruction.Font).Height * 1.2);
			label_transitionInstructions.Font = SystemFonts.CaptionFont;
			label_transitionInstructions.Height = (int)(label_transitionInstructions.CreateGraphics().MeasureString(label_transitionInstructions.Text, label_transitionInstructions.Font).Height * 1.2);
			label_durationInstructions.Font = SystemFonts.CaptionFont;
			label_durationInstructions.Height = (int)(label_durationInstructions.CreateGraphics().MeasureString(label_durationInstructions.Text, label_durationInstructions.Font).Height * 1.2);
			label_orderingInstructions.Font = SystemFonts.CaptionFont;
			label_orderingInstructions.Height = (int)(label_durationInstructions.CreateGraphics().MeasureString(label_durationInstructions.Text, label_durationInstructions.Font).Height * 1.2);

			timer.Tick += timer_Tick;
			timer.Interval = (int)this.settings.Schedule.TotalMilliseconds;
			timer.Enabled = this.settings.SchedulingMethod == SchedulingMethods.Scheduled;

			this.selectedColor = NativeMethods.GetWindowColor();
			this.notifyIcon.Text = Constants.APPLICATION_TITLE;
			this.notifyIcon.ContextMenu = contextMenu_notifyIcon;

			UpdateNotifyIcon(this.selectedColor);
		}

		private void UpdateNotifyIcon(Color color)
		{
			using (Bitmap bitmap = new Bitmap(TRAY_ICON_SIZE, TRAY_ICON_SIZE))
			{
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.Clear(color);
					graphics.DrawRectangle(SystemPens.ControlDarkDark, 0, 0, TRAY_ICON_SIZE - 1, TRAY_ICON_SIZE - 1);
				}

				this.notifyIcon.Icon = Icon.FromHandle(bitmap.GetHicon());
			}
		}

		private async void timer_Tick(object sender, EventArgs e)
		{
			if (!this.changingColors)
			{
				changingColors = true;
				int newIndex = ++this.settings.CurrentColorIndex % this.settings.Colors.Count;
				await this.SetWindowColor(this.settings.Colors[newIndex]);
				changingColors = false;
			}
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			// Bind controls to settings values:
			if (this.settings != null)
			{
				DataBind();
			}
		}

		/// <summary>
		/// Binds the form's controls to the appropriate current values in the settings.
		/// </summary>
		private void DataBind()
		{
			databinding = true;
			colorWell_colors.Controls.Clear();

			// Add colors:
			foreach (Color color in this.settings.Colors)
			{
				colorWell_colors.Add(color);
			}

			// Set active color:
			colorWell_colors.ActiveIndex = this.settings.CurrentColorIndex;

			switch (this.settings.TransitionMethod)
			{
				case TransitionMethods.Fade:
				default:
					radioButton_transition_fade.Checked = true;
					break;
				case TransitionMethods.Instant:
					radioButton_transition_instant.Checked = true;
					break;
			}

			switch (this.settings.FadeDuration)
			{
				case FadeDurations.Slow:
				default:
					radioButton_fade_slow.Checked = true;
					break;
				case FadeDurations.Medium:
					radioButton_fade_medium.Checked = true;
					break;
				case FadeDurations.Quick:
					radioButton_fade_fast.Checked = true;
					break;
			}

			switch (this.settings.SchedulingMethod)
			{
				case SchedulingMethods.Scheduled:
				default:
					radioButton_duration_schedule.Checked = true;
					break;
				case SchedulingMethods.Manual:
					radioButton_duration_manual.Checked = true;
					break;
			}

			if (this.settings.Schedule.Days > 0)
			{
				comboBox_timeIntervals.SelectedIndex = 3;
				numericUpDown_timeInterval.Value = this.settings.Schedule.Days;
			}
			else if (this.settings.Schedule.Hours > 0)
			{
				comboBox_timeIntervals.SelectedIndex = 2;
				numericUpDown_timeInterval.Value = this.settings.Schedule.Hours;
			}
			else if (this.settings.Schedule.Minutes > 0)
			{
				comboBox_timeIntervals.SelectedIndex = 1;
				numericUpDown_timeInterval.Value = this.settings.Schedule.Minutes;
			}
			else if (this.settings.Schedule.Seconds > 0)
			{
				comboBox_timeIntervals.SelectedIndex = 0;
				numericUpDown_timeInterval.Value = this.settings.Schedule.Seconds;
			}
			else
			{
				comboBox_timeIntervals.SelectedIndex = 1;
				numericUpDown_timeInterval.Value = this.settings.Schedule.Minutes;
			}

			radioButton_suffle_on.Checked = this.settings.ShuffleColors;

			menuItem_showTrayIcon.Checked = this.settings.ShowTrayIcon;
			menuItem_startWithWindows.Checked = this.settings.StartWithWindows && GetAutoStartStatus();

			databinding = false;
		}

		/// <summary>
		/// Determines whether the application is set to start with Windows by examining the current user's startup programs
		/// in the registry.
		/// </summary>
		/// <returns>True if the application will start with Windows; false otherwise.</returns>
		private bool GetAutoStartStatus()
		{
			try
			{
				RegistryKey startupProgramsKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
				return startupProgramsKey.GetValue(Constants.APPLICATION_TITLE) != null;
			}
			catch (SecurityException ex)
			{
				Debug.WriteLine("Unable to read from registry due to security issues. " + ex.Message);
			}

			return false;
		}

		/// <summary>
		/// Sets the application to start with Windows by writing to/removing a value in the current user's startup programs
		/// in the registry.
		/// </summary>
		/// <param name="status">True to enable autostart, false to disable it.</param>
		/// <returns>True if the registry write was successful.</returns>
		private bool SetAutoStartStatus(bool status)
		{
			// Check for registry key:
			try
			{
				RegistryKey startupProgramsKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

				if (status)
				{
					startupProgramsKey.SetValue(Constants.APPLICATION_TITLE, Constants.CURRENT_APPLICATION_PATH);
				}
				else
				{
					startupProgramsKey.DeleteValue(Constants.APPLICATION_TITLE, false);
				}

				return GetAutoStartStatus() == status;
			}
			catch (Exception ex)
			{
				if (ex.GetType() == typeof(SecurityException)
					|| ex.GetType() == typeof(UnauthorizedAccessException))
				{
					Debug.WriteLine("Unable to read from registry due to security/access issues. " + ex.Message);
				}
				else if (ex.GetType() == typeof(IOException))
				{
					Debug.WriteLine("Unable to read from registry due to IO issues. " + ex.Message);
				}

				return false;
			}
		}

		protected override void WndProc(ref Message m)
		{
			// Activate existing instance when a new one is started:
			if (m.Msg == NativeMethods.WM_SHOWME)
			{
				this.canShow = true;
				SetVisibleCore(true);
				NativeMethods.ShowWindow(this.Handle, NativeMethods.ShowWindowCommands.Normal);
				NativeMethods.SetForegroundWindow(this.Handle);
			}

			base.WndProc(ref m);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// Draw separator lines:
			Point[] topDarkLine = new Point[2]
			{
				new Point(0, panel_bottom.Top - 4),
				new Point(this.Width, panel_bottom.Top - 4)
			};

			Point[] topLightLine = new Point[2]
			{
				new Point(0, panel_bottom.Top - 3),
				new Point(this.Width, panel_bottom.Top - 3)
			};

			Point[] bottomDarkLine = new Point[2]
			{
				new Point(0, panel_form_spacer2.Top + 2),
				new Point(this.Width, panel_form_spacer2.Top + 2)
			};

			Point[] bottomLightLine = new Point[2]
			{
				new Point(0, panel_form_spacer2.Top + 3),
				new Point(this.Width, panel_form_spacer2.Top + 3)
			};

			e.Graphics.DrawLines(SystemPens.ControlDark, topDarkLine);
			e.Graphics.DrawLines(SystemPens.ControlDark, bottomDarkLine);
			e.Graphics.DrawLines(SystemPens.ControlLightLight, topLightLine);
			e.Graphics.DrawLines(SystemPens.ControlLightLight, bottomLightLine);
		}

		protected override void SetVisibleCore(bool value)
		{
			if (this.canShow)
			{
				base.SetVisibleCore(value);
			}
		}

		private void colorWell_colors_SelectionChanged(object sender, EventArgs e)
		{
			toolStripButton_removeColor.Enabled = colorWell_colors.SelectedIndex > -1;
			toolStripButton_moveLeft.Enabled = colorWell_colors.SelectedIndex > -1 && colorWell_colors.SelectedIndex > 0;
			toolStripButton_moveRight.Enabled = colorWell_colors.SelectedIndex > -1 && colorWell_colors.SelectedIndex < colorWell_colors.Controls.Count - 1;

			if (colorWell_colors.SelectedIndex > -1)
			{
				this.selectedColor = colorWell_colors.Controls[colorWell_colors.SelectedIndex].BackColor;
			}
		}

		private void toolStripButton_addColor_Click(object sender, EventArgs e)
		{
			using (ColorDialog dialog = new ColorDialog() { FullOpen = true })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					colors.Add(dialog.Color);
					colorWell_colors.Add(dialog.Color);
				}
			}
		}

		private void toolStripButton_removeColor_Click(object sender, EventArgs e)
		{
			if (colorWell_colors.Controls.Count > 0 && colorWell_colors.SelectedIndex > -1)
			{
				colorWell_colors.Controls.RemoveAt(colorWell_colors.SelectedIndex);
			}
		}

		private void toolStripButton_moveLeft_Click(object sender, EventArgs e)
		{
			colorWell_colors.MoveLeft(colorWell_colors.SelectedIndex);
		}

		private void toolStripButton_moveRight_Click(object sender, EventArgs e)
		{
			colorWell_colors.MoveRight(colorWell_colors.SelectedIndex);
		}

		private void radioButton_transition_instant_CheckedChanged(object sender, EventArgs e)
		{
			panel_transition_options.Enabled = !radioButton_transition_instant.Checked;
			this.settings.TransitionMethod = TransitionMethods.Instant;
		}

		private void radioButton_transition_fade_CheckedChanged(object sender, EventArgs e)
		{
			panel_transition_options.Enabled = !radioButton_transition_instant.Checked;
			this.settings.TransitionMethod = TransitionMethods.Fade;
		}

		private void radioButton_duration_manual_CheckedChanged(object sender, EventArgs e)
		{
			panel_duration_options.Enabled = !radioButton_duration_manual.Checked;
			this.settings.SchedulingMethod = SchedulingMethods.Manual;
		}

		private void radioButton_duration_interval_CheckedChanged(object sender, EventArgs e)
		{
			panel_duration_options.Enabled = !radioButton_duration_manual.Checked;
			this.settings.SchedulingMethod = SchedulingMethods.Scheduled;

			switch (comboBox_timeIntervals.SelectedIndex)
			{
				case 0:
					// Seconds
					this.settings.Schedule = TimeSpan.FromSeconds((double)numericUpDown_timeInterval.Value);
					break;
				case 1:
				default:
					// Minutes (default)
					this.settings.Schedule = TimeSpan.FromMinutes((double)numericUpDown_timeInterval.Value);
					break;
				case 2:
					// Hours
					this.settings.Schedule = TimeSpan.FromHours((double)numericUpDown_timeInterval.Value);
					break;
				case 3:
					// Days
					this.settings.Schedule = TimeSpan.FromDays((double)numericUpDown_timeInterval.Value);
					break;
			}
		}

		private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.canExit)
			{
				this.Hide();
				e.Cancel = true;
			}
		}

		public async Task SetWindowColor(Color newColor)
		{
			UpdateNotifyIcon(newColor);

			if (radioButton_transition_fade.Checked)
			{
				Color oldColor = NativeMethods.GetWindowColor();
				byte r = oldColor.R;
				byte g = oldColor.G;
				byte b = oldColor.B;
				int maxDifference = Math.Max(Math.Abs(r - newColor.R), Math.Max(Math.Abs(g - newColor.G), Math.Abs(b - newColor.B)));

				for (int i = 0; i < maxDifference; i++)
				{
					if (r < newColor.R)
					{
						r++;
					}
					else if (r > newColor.R)
					{
						r--;
					}

					if (g < newColor.G)
					{
						g++;
					}
					else if (g > newColor.G)
					{
						g--;
					}

					if (b < newColor.B)
					{
						b++;
					}
					else if (b > newColor.B)
					{
						b--;
					}

					NativeMethods.SetWindowColor(Color.FromArgb(255, r, g, b));
					float sleepDuration = (FADE_DURATION * 1000) / (maxDifference * CurrentFadeFactor);
					await Task.Delay(TimeSpan.FromMilliseconds(sleepDuration));
				}
			}
			else
			{
				NativeMethods.SetWindowColor(newColor);
			}

			this.settings.CurrentColorIndex = this.settings.Colors.IndexOf(newColor);
			colorWell_colors.ActiveIndex = this.settings.CurrentColorIndex;
			UpdateNotifyIcon(newColor);
		}

		private void radioButton_fade_slow_CheckedChanged(object sender, EventArgs e)
		{
			CurrentFadeFactor = SLOW_FADE_FACTOR;
			this.settings.FadeDuration = FadeDurations.Slow;
		}

		private void radioButton_fade_medium_CheckedChanged(object sender, EventArgs e)
		{
			CurrentFadeFactor = MEDIUM_FADE_FACTOR;
			this.settings.FadeDuration = FadeDurations.Medium;
		}

		private void radioButton_fade_fast_CheckedChanged(object sender, EventArgs e)
		{
			CurrentFadeFactor = QUICK_FADE_FACTOR;
			this.settings.FadeDuration = FadeDurations.Quick;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			this.settings.ShuffleColors = true;
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			this.settings.ShuffleColors = false;
		}

		private void menuItem15_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog dialog = new SaveFileDialog())
			{
				dialog.AddExtension = true;
				dialog.AutoUpgradeEnabled = true;
				dialog.CheckPathExists = true;
				dialog.CreatePrompt = true;
				dialog.DefaultExt = ".dat";
				dialog.Filter = "Binary files (*.dat)|*.dat";
				dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				dialog.OverwritePrompt = true;
				dialog.Title = "Export All Settings";
				dialog.ValidateNames = true;

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					Settings.Serialize(this.settings, dialog.FileName);
				}
			}
		}

		private void menuItem10_Click(object sender, EventArgs e)
		{
			menuItem_showTrayIcon.Checked = !menuItem_showTrayIcon.Checked;
			this.settings.ShowTrayIcon = menuItem_showTrayIcon.Checked;

			notifyIcon.Visible = menuItem_showTrayIcon.Checked;
		}

		private void menuItem11_Click(object sender, EventArgs e)
		{
			menuItem_startWithWindows.Checked = !menuItem_startWithWindows.Checked;
			this.settings.StartWithWindows = menuItem_startWithWindows.Checked;

			SetAutoStartStatus(this.settings.StartWithWindows);
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			// Update stored colors:
			this.settings.Colors.Clear();
			for (int i = 0; i < colorWell_colors.Controls.Count; i++)
			{
				Color color = colorWell_colors.GetColorAtIndex(i);
				this.settings.Colors.Add(color);
			}

			// Save settings:
			Settings.Serialize(this.settings, Constants.SETTINGS_PATH);
			this.Hide();
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void numericUpDown_timeInterval_ValueChanged(object sender, EventArgs e)
		{
			if (!databinding)
			{
				this.settings.Schedule = UpdateSchedule();
			}
		}

		private void comboBox_timeIntervals_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!databinding)
			{
				this.settings.Schedule = UpdateSchedule();
			}
		}

		private TimeSpan UpdateSchedule()
		{
			switch (comboBox_timeIntervals.SelectedIndex)
			{
				case 0:
					return TimeSpan.FromSeconds((double)numericUpDown_timeInterval.Value);
				case 1:
				default:
					return TimeSpan.FromMinutes((double)numericUpDown_timeInterval.Value);
				case 2:
					return TimeSpan.FromHours((double)numericUpDown_timeInterval.Value);
				case 3:
					return TimeSpan.FromDays((double)numericUpDown_timeInterval.Value);
			}
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			this.canShow = true;
			this.Show();
		}

		private void menuItem_exit_Click(object sender, EventArgs e)
		{
			this.canExit = true;
			Application.Exit();
		}

		private void menuItem_settings_Click(object sender, EventArgs e)
		{
			this.canShow = true;
			this.Show();
		}

		private async void menuItem_nextColor_Click(object sender, EventArgs e)
		{
			if (!this.changingColors)
			{
				changingColors = true;
				int newIndex = ++this.settings.CurrentColorIndex % this.settings.Colors.Count;
				this.settings.CurrentColorIndex = newIndex;
				await this.SetWindowColor(this.settings.Colors[newIndex]);
				changingColors = false;
			}
		}
	}
}
