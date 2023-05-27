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
		private const string FAVORITE_COLLECTION_FILENAME = "favorite.json";
		public const string FAVORITE_COLLECTION_NAME = "My Favorite Mods";

		public string Name { get; set; }

		public Dictionary<string, string> Modifications { get; set; }

		public CustomModsCollection(string name, Dictionary<string, string> modifications)
		{
			Name = name;
			Modifications = modifications;
		}

		public static void WriteExistingCollections(List<CustomModsCollection> collections)
		{
			string collectionsTextContent = JsonConvert.SerializeObject(collections, Formatting.Indented);

			try
			{
				File.WriteAllText(Path.Combine(Settings.CacheDirectoryPath, COLLECTIONS_FILENAME), collectionsTextContent);
			}
			catch (FileNotFoundException)
			{
				throw;
			}
		}

		public static List<CustomModsCollection> LoadExistingCollectionsFromCache(string cacheDirectoryPath)
		{
			string collectionsFilePath = Path.Combine(cacheDirectoryPath, COLLECTIONS_FILENAME);

			if (File.Exists(collectionsFilePath))
			{
				string collectionsTextContent = File.ReadAllText(collectionsFilePath);
				return JsonConvert.DeserializeObject<List<CustomModsCollection>>(collectionsTextContent);
			}

			return new List<CustomModsCollection>();
		}

		public static void WriteFavoriteCollection()
		{
			string favoriteCollectionTextContent = JsonConvert.SerializeObject(Settings.FavoriteModsCollection, Formatting.Indented);

			try
			{
				File.WriteAllText(Path.Combine(Settings.CacheDirectoryPath, FAVORITE_COLLECTION_FILENAME), favoriteCollectionTextContent);
			}
			catch (FileNotFoundException)
			{
				throw;
			}
		}

		public static CustomModsCollection LoadFavoriteCollectionFromCache(string cacheDirectoryPath)
		{
			string favoriteCollectionFilePath = Path.Combine(cacheDirectoryPath, FAVORITE_COLLECTION_FILENAME);

			if (File.Exists(favoriteCollectionFilePath))
			{
				string favoriteCollectionTextContent = File.ReadAllText(favoriteCollectionFilePath);
				return JsonConvert.DeserializeObject<CustomModsCollection>(favoriteCollectionTextContent);
			}

			return new CustomModsCollection(FAVORITE_COLLECTION_NAME, new Dictionary<string, string>());
		}
	}
}
