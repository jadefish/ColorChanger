using System;
using System.Reflection;

namespace ColorChanger
{
	public static class Constants
	{
		public static readonly string APPLICATION_TITLE = "ColorChanger";
		public static readonly string MUTEX_GUID = "{57813921-C541-4C42-A080-A61AC75D02EF}";
		public static readonly string CURRENT_APPLICATION_PATH = Assembly.GetExecutingAssembly().Location;
		public static readonly string SETTINGS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\ColorChanger\settings.bin";
	}
}
