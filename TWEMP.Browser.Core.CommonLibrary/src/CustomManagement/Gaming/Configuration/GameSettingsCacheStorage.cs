// <copyright file="GameSettingsCacheStorage.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

using System.IO;

/// <summary>
/// Represents a storage for custom game settings used by the application.
/// </summary>
public static class GameSettingsCacheStorage
{
    private const string FolderName = "cache";

    static GameSettingsCacheStorage()
    {
        string appHomeDirectory = Directory.GetCurrentDirectory();
        Location = Path.Combine(appHomeDirectory, FolderName);

        if (!Directory.Exists(Location))
        {
            Directory.CreateDirectory(Location);
        }
    }

    /// <summary>
    /// Gets the directory path for the cache storage of game settings.
    /// </summary>
    public static string Location { get; private set; }
}
