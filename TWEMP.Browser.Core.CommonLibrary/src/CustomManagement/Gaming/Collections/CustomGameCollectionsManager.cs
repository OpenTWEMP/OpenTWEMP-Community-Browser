// <copyright file="CustomGameCollectionsManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.CommonLibrary.Serialization;

/// <summary>
/// Represents a device to manage custom game collections into the application.
/// </summary>
public class CustomGameCollectionsManager
{
    private const string CollectionsFileName = "collections.json";
    private const string FavoriteCollectionFileName = "favorite.json";
    private const string FavoriteCollectionTitle = "My Favorite Mods";

    private readonly string cacheStorageLocation;

    private CustomGameCollectionsManager()
    {
        this.cacheStorageLocation = GameSettingsCacheStorage.Location;

        this.FavoriteModsCollection = LoadFavoriteCollectionFromCache(this.cacheStorageLocation);
        this.UserCollections = LoadExistingCollectionsFromCache(this.cacheStorageLocation);
    }

    /// <summary>
    /// Gets user's favorite collection of game modifications.
    /// </summary>
    public CustomModsCollection FavoriteModsCollection { get; private set; }

    /// <summary>
    /// Gets user's all collections of game modifications.
    /// </summary>
    public List<CustomModsCollection> UserCollections { get; private set; }

    /// <summary>
    /// Creates a custom instance of the <see cref="CustomGameCollectionsManager"/> class.
    /// </summary>
    /// <returns>Instance of the <see cref="CustomGameCollectionsManager"/> class.</returns>
    public static CustomGameCollectionsManager Create()
    {
        return new CustomGameCollectionsManager();
    }

    /// <summary>
    /// Writes user's all collections of game modifications to the cache storage.
    /// </summary>
    public void WriteExistingCollections()
    {
        try
        {
            string path = Path.Combine(GameSettingsCacheStorage.Location, CollectionsFileName);
            AppSerializer.SerializeToJson(this.UserCollections, path);
        }
        catch (FileNotFoundException)
        {
            throw;
        }
    }

    /// <summary>
    /// Writes user's favorite collection of game modifications to the cache storage.
    /// </summary>
    public void WriteFavoriteCollection()
    {
        try
        {
            string path = Path.Combine(GameSettingsCacheStorage.Location, FavoriteCollectionFileName);
            AppSerializer.SerializeToJson(this.FavoriteModsCollection, path);
        }
        catch (FileNotFoundException)
        {
            throw;
        }
    }

    private static List<CustomModsCollection> LoadExistingCollectionsFromCache(string cacheDirectoryPath)
    {
        List<CustomModsCollection> collections;

        string collectionsFilePath = Path.Combine(cacheDirectoryPath, CollectionsFileName);

        if (File.Exists(collectionsFilePath))
        {
            collections = AppSerializer.DeserializeFromJson<List<CustomModsCollection>>(collectionsFilePath);
        }
        else
        {
            collections = new List<CustomModsCollection>();
        }

        return collections;
    }

    private static CustomModsCollection LoadFavoriteCollectionFromCache(string cacheDirectoryPath)
    {
        CustomModsCollection collection;

        string favoriteCollectionFilePath = Path.Combine(cacheDirectoryPath, FavoriteCollectionFileName);

        if (File.Exists(favoriteCollectionFilePath))
        {
            collection = AppSerializer.DeserializeFromJson<CustomModsCollection>(favoriteCollectionFilePath);
        }
        else
        {
            collection = new CustomModsCollection(FavoriteCollectionTitle, new Dictionary<string, string>());
        }

        return collection;
    }
}
