// <copyright file="GameSupportManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

/// <summary>
/// Represents a device to manage game support presets into the application.
/// </summary>
public static class GameSupportManager
{
    private const string PresetsHomeFolderName = "support";

    static GameSupportManager()
    {
        string appSupportDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), PresetsHomeFolderName);
        PresetsHomeDirectoryInfo = new DirectoryInfo(appSupportDirectoryPath);
    }

    /// <summary>
    /// Gets information about the home directory of game support presets.
    /// </summary>
    public static DirectoryInfo PresetsHomeDirectoryInfo { get; }

    /// <summary>
    /// Initializes the global device for game support management.
    /// </summary>
    public static void Initialize()
    {
        if (!PresetsHomeDirectoryInfo.Exists)
        {
            PresetsHomeDirectoryInfo.Create();
        }
    }
}
