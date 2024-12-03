// <copyright file="CustomGameSetupManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

#define LEGACY_XML_SERIALIZATION
#define MODERN_JSON_SERIALIZATION
#undef MODERN_JSON_SERIALIZATION

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;
using TWEMP.Browser.Core.CommonLibrary.Serialization;

/// <summary>
/// Represents a device to manage custom game setup installations into the application.
/// </summary>
public class CustomGameSetupManager
{
    private const string ConfigFileName = "setup.json";

    private readonly string gameSetupConfigFilePath;

    private CustomGameSetupManager()
    {
#if LEGACY_XML_SERIALIZATION
        this.gameSetupConfigFilePath = GameSetupConfFileBuilder.GetSetupConfFileName();
#endif

#if MODERN_JSON_SERIALIZATION
        this.gameSetupConfigFilePath = Path.Combine(Directory.GetCurrentDirectory(), ConfigFileName);
#endif

        this.GameInstallations = new List<GameSetupInfo>();
        this.TotalModificationsList = new List<GameModificationInfo>();
    }

    /// <summary>
    /// Gets user's game setup installations.
    /// </summary>
    public List<GameSetupInfo> GameInstallations { get; private set; }

    /// <summary>
    /// Gets all game modifications from user's game setup installations.
    /// </summary>
    public List<GameModificationInfo> TotalModificationsList { get; private set; }

    /// <summary>
    /// Creates a custom instance of the <see cref="CustomGameSetupManager"/> class.
    /// </summary>
    /// <returns>Instance of the <see cref="CustomGameSetupManager"/> class.</returns>
    public static CustomGameSetupManager Create()
    {
        return new CustomGameSetupManager();
    }

    public GameSetupInfo RegistrateGameInstallation(string setupName, string executableFullPath, List<string> modcenterPaths)
    {
#if LEGACY_XML_SERIALIZATION
        GameSetupConfFileBuilder.WriteNewSetupToConfFile(this.gameSetupConfigFilePath, setupName, executableFullPath, modcenterPaths);
#endif

        GameSetupInfo gameSetupInfo = GameSetupInfo.Create(setupName, executableFullPath, modcenterPaths);
        this.GameInstallations.Add(gameSetupInfo);

#if MODERN_JSON_SERIALIZATION
        this.WriteGameSetupObjectsToConfigFile(this.GameInstallations);
#endif

        return gameSetupInfo;
    }

    public List<GameSetupInfo> SynchronizeGameSetupSettings()
    {
#if LEGACY_XML_SERIALIZATION
        if (GameSetupConfFileBuilder.ShouldGameSetupConfFileBeCreated(this.gameSetupConfigFilePath))
        {
            GameSetupConfFileBuilder.CreateSetupConfFile(this.gameSetupConfigFilePath);
        }
        else
        {
            if (this.GameInstallations.Count == 0)
            {
                uint gameSetupObjectsCount = GameSetupConfFileBuilder.ReadTotalGameSetupCount(this.gameSetupConfigFilePath);

                if (gameSetupObjectsCount > 0)
                {
                    List<GameSetupInfo> gameSetupObjects = GameSetupConfFileBuilder.ReadAllSetupConfFile(this.gameSetupConfigFilePath);
                    this.GameInstallations.AddRange(gameSetupObjects);
                }
            }
        }
#endif

#if MODERN_JSON_SERIALIZATION
        this.GameInstallations = this.ReadGameSetupObjectsFromConfigFile();
#endif

        return this.GameInstallations;
    }

    public void DeleteGameSetupByIndex(int gameSetupIndex)
    {
#if LEGACY_XML_SERIALIZATION
        GameSetupInfo gameSetupInfo = this.GameInstallations[gameSetupIndex];
        GameSetupConfFileBuilder.DeleteGameSetupFromConfFile(gameSetupInfo, this.gameSetupConfigFilePath);
#endif

        this.GameInstallations.RemoveAt(gameSetupIndex);

#if MODERN_JSON_SERIALIZATION
        this.WriteGameSetupObjectsToConfigFile(this.GameInstallations);
#endif
    }

    public void UpdateTotalModificationsList()
    {
        this.TotalModificationsList.Clear();

        foreach (var installation in this.GameInstallations)
        {
            List<GameModificationInfo> mods = installation.GetInstalledMods();
            this.TotalModificationsList.AddRange(mods);
        }
    }

    public GameModificationInfo GetActiveModificationInfo(string modShortName)
    {
        foreach (GameModificationInfo modInfo in this.TotalModificationsList)
        {
            if (modInfo.ShortName.Equals(modShortName))
            {
                return modInfo;
            }
        }

        return null!;
    }

    public void ClearAllSettings()
    {
        this.TotalModificationsList.Clear();
        this.GameInstallations.Clear();

        if (File.Exists(this.gameSetupConfigFilePath))
        {
            File.Delete(this.gameSetupConfigFilePath);

#if LEGACY_XML_SERIALIZATION
            GameSetupConfFileBuilder.CreateSetupConfFile(this.gameSetupConfigFilePath);
#endif
        }
    }

#if MODERN_JSON_SERIALIZATION
    private List<GameSetupInfo> ReadGameSetupObjectsFromConfigFile()
    {
        List<GameSetupInfo> gameSetupObjects = new ();

        GameSetupView[] gameSetupViews = AppSerializer.DeserializeFromJson<GameSetupView[]>(this.gameSetupConfigFilePath);

        foreach (GameSetupView view in gameSetupViews)
        {
            GameSetupInfo gameSetupInfo = GameSetupInfo.Create(view);
            gameSetupObjects.Add(gameSetupInfo);
        }

        return gameSetupObjects;
    }

    private void WriteGameSetupObjectsToConfigFile(ICollection<GameSetupInfo> gameSetupObjects)
    {
        List<GameSetupView> gameSetupViews = new ();

        foreach (GameSetupInfo gameSetupInfo in gameSetupObjects)
        {
            gameSetupViews.Add(new GameSetupView(gameSetupInfo));
        }

        AppSerializer.SerializeToJson(gameSetupViews, this.gameSetupConfigFilePath);
    }
#endif
}
