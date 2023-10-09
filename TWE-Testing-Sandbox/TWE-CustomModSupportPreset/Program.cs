using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TWE_CustomModSupportPreset
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPresetSerialization();
            Console.WriteLine("SLEEPING...");
            System.Threading.Thread.Sleep(3000);
            TestPresetDeserialization();
        }

        private static void TestPresetSerialization()
        {
            Console.WriteLine("TestPresetSerialization()...");

            CustomModSupportPreset preset = CustomModSupportPreset.CreatePresetByDefault();
            string presetJsonText = JsonConvert.SerializeObject(preset, Formatting.Indented);

            using (var writer = new StreamWriter("preset.json"))
            {
                writer.WriteLine(presetJsonText);
            }
        }

        private static void TestPresetDeserialization()
        {
            Console.WriteLine("TestPresetDeserialization()...");

            string presetJsonText = File.ReadAllText("preset.json");
            CustomModSupportPreset preset = JsonConvert.DeserializeObject<CustomModSupportPreset>(presetJsonText);

            Console.WriteLine(preset.ToString());
        }
    }

	public class CustomModSupportPreset
	{
		public string ModTitle { get; set; }
		public string ModVersion { get; set; }
		public string LogotypeImage { get; set; }
		public string BackgroundSoundTrack { get; set; }

		public Dictionary<string, string> ModURLs { get; set; }

		public CustomModSupportPreset(string title, string version)
		{
			ModTitle = title;
            ModVersion = version;

            LogotypeImage = "SPLASH.png";
            BackgroundSoundTrack = "MUSIC.mp3";

            ModURLs = new Dictionary<string, string>()
            {
                { "URL1", "https://mymod1.mod" },
                { "URL2", "https://mymod1.org" },
                { "URL3", "https://mymod1.com" }
            };
		}

        public static CustomModSupportPreset CreatePresetByDefault()
        {
            return new CustomModSupportPreset("My Mod Title", "Mod Mod Version");
        }

        public override string ToString()
        {
            string str = "ModTitle: " + ModTitle + '\n';
            str += "ModVersion: " + ModVersion + '\n';
            str += "LogotypeImage: " + LogotypeImage + '\n';
            str += "BackgroundSoundTrack: " + BackgroundSoundTrack + '\n';
            str += "ModURLs:\n";

            foreach (var url in ModURLs)
            {
                str += "url_key = '" + url.Key + ", url_val = '" + url.Value + "'\n";
            }

            return str;
        }
	}
}
