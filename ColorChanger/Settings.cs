using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace ColorChanger
{
	public enum TransitionMethods
	{
		Instant = 0,
		Fade = 1,
	}

	public enum FadeDurations
	{
		Slow = 0,
		Medium = 1,
		Quick = 2,
	}

	public enum SchedulingMethods
	{
		Manual = 0,
		Scheduled = 1,
	}

	[Serializable]
	public class Settings
	{
		private TransitionMethods transitionMethod = TransitionMethods.Fade;
		private FadeDurations fadeDuration = FadeDurations.Slow;
		private SchedulingMethods schedulingMethod = SchedulingMethods.Scheduled;
		private TimeSpan schedule = TimeSpan.FromMinutes(5);
		private bool shuffleColors = false;
		private List<Color> colors = new List<Color>();
		private bool showTrayIcon = true;
		private bool startWithWindows = false;
		private DateTime dateModified = DateTime.Now;
		private int currentColorIndex = -1;

		public TransitionMethods TransitionMethod
		{
			get { return this.transitionMethod; }
			set { this.transitionMethod = value; }
		}

		public FadeDurations FadeDuration
		{
			get { return this.fadeDuration; }
			set { this.fadeDuration = value; }
		}

		public SchedulingMethods SchedulingMethod
		{
			get { return this.schedulingMethod; }
			set { this.schedulingMethod = value; }
		}

		public TimeSpan Schedule
		{
			get { return this.schedule; }
			set { this.schedule = value; }
		}

		public bool ShuffleColors
		{
			get { return this.shuffleColors; }
			set { this.shuffleColors = value; }
		}

		public List<Color> Colors
		{
			get { return this.colors; }
			set { this.colors = value; }
		}

		public bool ShowTrayIcon
		{
			get { return this.showTrayIcon; }
			set { this.showTrayIcon = value; }
		}

		public bool StartWithWindows
		{
			get { return this.startWithWindows; }
			set { this.startWithWindows = value; }
		}

		public DateTime DateModified
		{
			get { return this.dateModified; }
		}

		public int CurrentColorIndex
		{
			get { return this.currentColorIndex; }
			set { this.currentColorIndex = value; }
		}

		public static void Serialize(Settings settings, string fileName)
		{
			// Check directory exists:
			DirectoryInfo info = new DirectoryInfo(fileName.Remove(fileName.LastIndexOf('\\') + 1));

			if (!info.Exists)
			{
				try
				{
					info.Create();
				}
				catch (IOException ex)
				{
					Debug.WriteLine(ex.ToString());
				}
			}

			// Update date modified timestamp:
			settings.dateModified = DateTime.Now;

			// Serialize settings to file:
			using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, settings);
				stream.Close();
			}
		}

		public static void Deserialize(out Settings settings, string fileName, bool defaultIfMissing = true)
		{
			// Check file exists:
			FileInfo info = new FileInfo(fileName);

			if (!info.Exists)
			{
				Debug.WriteLine("Couldn't locate settings file for deserialization: \"" + fileName + "\".");
				if (defaultIfMissing)
				{
					settings = new Settings();
					return;
				}
				else
				{
					// TODO
					throw new FileNotFoundException("Couldn't locate file for deserialization.", fileName);
				}
			}

			// Deserialize from the file:
			using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				settings = (Settings)formatter.Deserialize(stream);
			}
		}
	}
}
