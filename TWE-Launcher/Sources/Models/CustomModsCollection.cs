using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TWE_Launcher.Models
{
	public class CustomModsCollection
	{
		private const string COLLECTIONS_FILENAME = "collections.json";
		private static readonly string collectionsFilePath;

		public string Name { get; set; }

		public Dictionary<string, string> Modifications { get; set; }

		public CustomModsCollection(string name, Dictionary<string, string> modifications)
		{
			Name = name;
			Modifications = modifications;
		}

		static CustomModsCollection()
		{
			collectionsFilePath = Path.Combine(Settings.CacheDirectoryPath, COLLECTIONS_FILENAME);
		}

		public static void WriteExistingCollections(List<CustomModsCollection> collections)
		{
			string collectionsTextContent = JsonConvert.SerializeObject(collections, Formatting.Indented);

			try
			{
				File.WriteAllText(collectionsFilePath, collectionsTextContent);
			}
			catch (FileNotFoundException)
			{
				throw;
			}
		}

		public static List<CustomModsCollection> ReadExistingCollections()
		{
			string collectionsTextContent = File.ReadAllText(collectionsFilePath);
			return JsonConvert.DeserializeObject<List<CustomModsCollection>>(collectionsTextContent);
		}
	}
}
