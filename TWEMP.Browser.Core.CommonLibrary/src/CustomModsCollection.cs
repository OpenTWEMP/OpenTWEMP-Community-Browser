// <copyright file="CustomModsCollection.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary;

using Newtonsoft.Json;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

public class CustomModsCollection
{
    public const string FAVORITE_COLLECTION_NAME = "My Favorite Mods";

    private const string COLLECTIONS_FILENAME = "collections.json";
    private const string FAVORITE_COLLECTION_FILENAME = "favorite.json";

    public CustomModsCollection(string name, Dictionary<string, string> modifications)
    {
        Name = name;
        Modifications = modifications;
    }

    public string Name { get; set; }

    public Dictionary<string, string> Modifications { get; set; }

    public static void WriteExistingCollections(List<CustomModsCollection> collections)
    {
        string collectionsTextContent = JsonConvert.SerializeObject(collections, Formatting.Indented);

        try
        {
            File.WriteAllText(Path.Combine(GameSettingsCacheStorage.Location, COLLECTIONS_FILENAME), collectionsTextContent);
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
            return JsonConvert.DeserializeObject<List<CustomModsCollection>>(collectionsTextContent) !;
        }

        return new List<CustomModsCollection>();
    }

    public static void WriteFavoriteCollection()
    {
        string favoriteCollectionTextContent = JsonConvert.SerializeObject(Settings.FavoriteModsCollection, Formatting.Indented);

        try
        {
            File.WriteAllText(Path.Combine(GameSettingsCacheStorage.Location, FAVORITE_COLLECTION_FILENAME), favoriteCollectionTextContent);
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
            return JsonConvert.DeserializeObject<CustomModsCollection>(favoriteCollectionTextContent) !;
        }

        return new CustomModsCollection(FAVORITE_COLLECTION_NAME, new Dictionary<string, string>());
    }
}
