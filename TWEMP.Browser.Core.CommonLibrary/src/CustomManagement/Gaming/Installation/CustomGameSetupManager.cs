// <copyright file="CustomGameSetupManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

#define LEGACY_XML_SERIALIZATION
#define MODERN_JSON_SERIALIZATION

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;
using TWEMP.Browser.Core.CommonLibrary.Serialization;

/// <summary>
/// Represents a device to manage custom game setup installations into the application.
/// </summary>
public static class CustomGameSetupManager
{
    private const string ConfigFileName = "setup.json";

    private static readonly string GameSetupConfigFilePath;

    /// <summary>
    /// Initializes static members of the <see cref="CustomGameSetupManager"/> class.
    /// </summary>
    static CustomGameSetupManager()
    {
#if LEGACY_XML_SERIALIZATION
        GameSetupConfigFilePath = GameSetupConfFileBuilder.GetSetupConfFileName();
#endif

#if MODERN_JSON_SERIALIZATION
        GameSetupConfigFilePath = Path.Combine(Directory.GetCurrentDirectory(), ConfigFileName);
#endif

        GameInstallations = new List<GameSetupInfo>();
        TotalModificationsList = new List<GameModificationInfo>();
    }

    /// <summary>
    /// Gets user's game setup installations.
    /// </summary>
    public static List<GameSetupInfo> GameInstallations { get; private set; }

    /// <summary>
    /// Gets all game modifications from user's game setup installations.
    /// </summary>
    public static List<GameModificationInfo> TotalModificationsList { get; private set; }

    public static GameSetupInfo RegistrateGameInstallation(string setupName, string executableFullPath, List<string> modcenterPaths)
    {
#if LEGACY_XML_SERIALIZATION
        GameSetupConfFileBuilder.WriteNewSetupToConfFile(GameSetupConfigFilePath, setupName, executableFullPath, modcenterPaths);
#endif

        GameSetupInfo gameSetupInfo = GameSetupInfo.Create(setupName, executableFullPath, modcenterPaths);
        GameInstallations.Add(gameSetupInfo);

#if MODERN_JSON_SERIALIZATION
        WriteGameSetupObjectsToConfigFile(GameInstallations);
#endif

        return gameSetupInfo;
    }

    public static List<GameSetupInfo> SynchronizeGameSetupSettings()
    {
#if LEGACY_XML_SERIALIZATION
        if (GameSetupConfFileBuilder.ShouldGameSetupConfFileBeCreated(GameSetupConfigFilePath))
        {
            GameSetupConfFileBuilder.CreateSetupConfFile(GameSetupConfigFilePath);
        }
        else
        {
            if (GameInstallations.Count == 0)
            {
                uint gameSetupObjectsCount = GameSetupConfFileBuilder.ReadTotalGameSetupCount(GameSetupConfigFilePath);

                if (gameSetupObjectsCount > 0)
                {
                    List<GameSetupInfo> gameSetupObjects = GameSetupConfFileBuilder.ReadAllSetupConfFile(GameSetupConfigFilePath);
                    GameInstallations.AddRange(gameSetupObjects);
                }
            }
        }
#endif

#if MODERN_JSON_SERIALIZATION
        GameInstallations = ReadGameSetupObjectsFromConfigFile();
#endif

        return GameInstallations;
    }

    public static void DeleteGameSetupByIndex(int gameSetupIndex)
    {
#if LEGACY_XML_SERIALIZATION
        GameSetupInfo gameSetupInfo = GameInstallations[gameSetupIndex];
        GameSetupConfFileBuilder.DeleteGameSetupFromConfFile(gameSetupInfo, GameSetupConfigFilePath);
#endif

        GameInstallations.RemoveAt(gameSetupIndex);

#if MODERN_JSON_SERIALIZATION
        WriteGameSetupObjectsToConfigFile(GameInstallations);
#endif
    }

    public static void UpdateTotalModificationsList()
    {
        TotalModificationsList.Clear();

        foreach (var installation in GameInstallations)
        {
            List<GameModificationInfo> mods = installation.GetInstalledMods();
            TotalModificationsList.AddRange(mods);
        }
    }

    public static GameModificationInfo GetActiveModificationInfo(string modShortName)
    {
        foreach (GameModificationInfo modInfo in TotalModificationsList)
        {
            if (modInfo.ShortName.Equals(modShortName))
            {
                return modInfo;
            }
        }

        return null!;
    }

    public static void ClearAllSettings()
    {
        TotalModificationsList.Clear();
        GameInstallations.Clear();

        if (File.Exists(GameSetupConfigFilePath))
        {
            File.Delete(GameSetupConfigFilePath);

#if LEGACY_XML_SERIALIZATION
            GameSetupConfFileBuilder.CreateSetupConfFile(GameSetupConfigFilePath);
#endif
        }
    }

#if MODERN_JSON_SERIALIZATION
    private static List<GameSetupInfo> ReadGameSetupObjectsFromConfigFile()
    {
        List<GameSetupInfo> gameSetupObjects = new ();

        GameSetupView[] gameSetupViews = AppSerializer.DeserializeFromJson<GameSetupView[]>(GameSetupConfigFilePath);

        foreach (GameSetupView view in gameSetupViews)
        {
            GameSetupInfo gameSetupInfo = GameSetupInfo.Create(view);
            gameSetupObjects.Add(gameSetupInfo);
        }

        return gameSetupObjects;
    }

    private static void WriteGameSetupObjectsToConfigFile(ICollection<GameSetupInfo> gameSetupObjects)
    {
        List<GameSetupView> gameSetupViews = new ();

        foreach (GameSetupInfo gameSetupInfo in gameSetupObjects)
        {
            gameSetupViews.Add(new GameSetupView(gameSetupInfo));
        }

        AppSerializer.SerializeToJson(gameSetupViews, GameSetupConfigFilePath);
    }
#endif
}
