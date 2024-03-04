// <copyright file="GameSupportManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

using TWEMP.Browser.Core.CommonLibrary.Serialization;

/// <summary>
/// Represents a device to manage game support presets into the application.
/// </summary>
public static class GameSupportManager
{
    private const string PresetsHomeFolderName = "support";
    private const string PresetsConfigFileName = "games_support.json";

    private static readonly FileInfo PresetsConfigFileInfo;

    static GameSupportManager()
    {
        string presetsHomeDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), PresetsHomeFolderName);
        string presetsConfigFilePath = Path.Combine(presetsHomeDirectoryPath, PresetsConfigFileName);

        PresetsConfigFileInfo = new FileInfo(presetsConfigFilePath);
        PresetsHomeDirectoryInfo = new DirectoryInfo(presetsHomeDirectoryPath);
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

        if (!PresetsConfigFileInfo.Exists)
        {
            CreatePresetsConfigFileByDefault();
        }

        // GameSupportConfiguration configuration = ReadPresetsConfigFile();
    }

    private static void CreatePresetsConfigFileByDefault()
    {
        AppSerializer.SerializeToJson(new GameSupportConfiguration(), PresetsConfigFileInfo.FullName);
    }

    private static GameSupportConfiguration ReadPresetsConfigFile()
    {
        return AppSerializer.DeserializeFromJson<GameSupportConfiguration>(PresetsConfigFileInfo.FullName);
    }
}
