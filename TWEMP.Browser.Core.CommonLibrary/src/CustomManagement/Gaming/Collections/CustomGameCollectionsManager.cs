// <copyright file="CustomGameCollectionsManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;

using Newtonsoft.Json;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

/// <summary>
/// Represents a device to manage custom game collections into the application.
/// </summary>
public static class CustomGameCollectionsManager
{
    private const string CollectionsFileName = "collections.json";
    private const string FavoriteCollectionFileName = "favorite.json";
    private const string FavoriteCollectionTitle = "My Favorite Mods";

    private static readonly string CacheStorageLocation;

    private static List<UpdatableGameModsCollection> customCollections;
    private static UpdatableGameModsCollection favoriteCollection;

    static CustomGameCollectionsManager()
    {
        CacheStorageLocation = GameSettingsCacheStorage.Location;

        customCollections = InitializeCustomCollections();
        favoriteCollection = InitializeFavoriteCollection();

        FavoriteModsCollection = LoadFavoriteCollectionFromCache(CacheStorageLocation);
        UserCollections = LoadExistingCollectionsFromCache(CacheStorageLocation);
    }

    /// <summary>
    /// Gets user's favorite collection of game modifications.
    /// </summary>
    public static CustomModsCollection FavoriteModsCollection { get; private set; }

    /// <summary>
    /// Gets user's all collections of game modifications.
    /// </summary>
    public static List<CustomModsCollection> UserCollections { get; private set; }

    /// <summary>
    /// Writes user's all collections of game modifications to the cache storage.
    /// </summary>
    /// <param name="collections">The list of objects which are collections of game modifications.</param>
    public static void WriteExistingCollections(List<CustomModsCollection> collections)
    {
        string collectionsTextContent = JsonConvert.SerializeObject(collections, Formatting.Indented);

        try
        {
            File.WriteAllText(Path.Combine(GameSettingsCacheStorage.Location, CollectionsFileName), collectionsTextContent);
        }
        catch (FileNotFoundException)
        {
            throw;
        }
    }

    /// <summary>
    /// Writes user's favorite collection of game modifications to the cache storage.
    /// </summary>
    public static void WriteFavoriteCollection()
    {
        string favoriteCollectionTextContent = JsonConvert.SerializeObject(FavoriteModsCollection, Formatting.Indented);

        try
        {
            File.WriteAllText(Path.Combine(GameSettingsCacheStorage.Location, FavoriteCollectionFileName), favoriteCollectionTextContent);
        }
        catch (FileNotFoundException)
        {
            throw;
        }
    }

    private static List<CustomModsCollection> LoadExistingCollectionsFromCache(string cacheDirectoryPath)
    {
        string collectionsFilePath = Path.Combine(cacheDirectoryPath, CollectionsFileName);

        if (File.Exists(collectionsFilePath))
        {
            string collectionsTextContent = File.ReadAllText(collectionsFilePath);
            return JsonConvert.DeserializeObject<List<CustomModsCollection>>(collectionsTextContent) !;
        }

        return new List<CustomModsCollection>();
    }

    private static CustomModsCollection LoadFavoriteCollectionFromCache(string cacheDirectoryPath)
    {
        string favoriteCollectionFilePath = Path.Combine(cacheDirectoryPath, FavoriteCollectionFileName);

        if (File.Exists(favoriteCollectionFilePath))
        {
            string favoriteCollectionTextContent = File.ReadAllText(favoriteCollectionFilePath);
            return JsonConvert.DeserializeObject<CustomModsCollection>(favoriteCollectionTextContent) !;
        }

        return new CustomModsCollection(FavoriteCollectionTitle, new Dictionary<string, string>());
    }

    private static List<UpdatableGameModsCollection> InitializeCustomCollections()
    {
        return new List<UpdatableGameModsCollection>();
    }

    private static UpdatableGameModsCollection InitializeFavoriteCollection()
    {
        return new UpdatableGameModsCollection(
            header: new GameModsCollectionHeader(FavoriteCollectionTitle),
            gameMods: Array.Empty<UpdatableGameModificationView>());
    }
}
