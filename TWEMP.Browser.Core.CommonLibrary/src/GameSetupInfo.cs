// <copyright file="GameSetupInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

using System.Xml.Linq;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

public class GameSetupInfo
{
    private GameSetupInfo(string name, string executable, List<string> modcenters)
    {
        this.Name = name;
        this.HomeDirectory = Path.GetDirectoryName(executable);
        this.ExecutableFileName = Path.GetFileName(executable);
        this.AttachedModCenters = InitializeModCenters(modcenters);
    }

    public string Name { get; }

    public string? HomeDirectory { get; }

    public string? ExecutableFileName { get; }

    public List<ModCenterInfo> AttachedModCenters { get; }

    /// <summary>
    /// Creates the default instance of the <see cref="GameSetupInfo"/> class.
    /// </summary>
    /// <returns>An instance of the <see cref="GameSetupInfo"/> class.</returns>
    public static GameSetupInfo Create()
    {
        string name = "Default TWEMP Game Setup Template for M2TW";
        string executable = "twemp_game_executable.exe";
        List<string> modcenters = new () { "mods" };

        return Create(name, executable, modcenters);
    }

    /// <summary>
    /// Creates an instance of the <see cref="GameSetupInfo"/> class.
    /// </summary>
    /// <param name="name">Game setup name.</param>
    /// <param name="executable">The executable file path of the game setup.</param>
    /// <param name="modcenters">Directory paths to modcenters of the game setup.</param>
    /// <returns>An instance of the <see cref="GameSetupInfo"/> class.</returns>
    public static GameSetupInfo Create(string name, string executable, List<string> modcenters)
    {
        GameSetupInfo gameSetup = new (name, executable, modcenters);
        InitializeGameSetupCache(gameSetup);
        return gameSetup;
    }

    public List<GameModificationInfo> GetInstalledMods()
    {
        List<GameModificationInfo> installedMods = new ();

        foreach (ModCenterInfo modcenter in this.AttachedModCenters)
        {
            List<GameModificationInfo> detectedMods = GetValidGameModificationsFrom(this, modcenter);
            installedMods.AddRange(detectedMods);
        }

        return installedMods;
    }

    private static List<ModCenterInfo> InitializeModCenters(ICollection<string> modcenterPaths)
    {
        List<ModCenterInfo> detectedModCenters = new ();

        foreach (var modcenterPath in modcenterPaths)
        {
            if (Directory.Exists(modcenterPath))
            {
                ModCenterInfo modcenter = new (modcenterPath);
                detectedModCenters.Add(modcenter);
            }
        }

        return detectedModCenters;
    }

    private static void InitializeGameSetupCache(GameSetupInfo gamesetup)
    {
        string gamesetupCachePath = CreateCacheDirectoryPath(GameSettingsCacheStorage.Location, gamesetup.Name);

        foreach (ModCenterInfo modcenter in gamesetup.AttachedModCenters)
        {
            InitializeModCenterCache(gamesetupCachePath, modcenter);
        }
    }

    private static void InitializeModCenterCache(string gamesetupCachePath, ModCenterInfo modcenter)
    {
        string modcenterCachePath = CreateCacheDirectoryPath(gamesetupCachePath, modcenter.Name);

        foreach (GameModificationInfo mod in modcenter.InstalledModifications)
        {
            CreateCacheDirectoryPath(modcenterCachePath, mod.ShortName);
        }
    }

    private static string CreateCacheDirectoryPath(string parentDirectoryPath, string cacheFolderName)
    {
        string cacheDirectoryPath = Path.Combine(parentDirectoryPath, cacheFolderName);

        if (!Directory.Exists(cacheDirectoryPath))
        {
            Directory.CreateDirectory(cacheDirectoryPath);
        }

        return cacheDirectoryPath;
    }

    private static List<GameModificationInfo> GetValidGameModificationsFrom(GameSetupInfo gamesetup, ModCenterInfo modcenter)
    {
        modcenter.InstalledModifications.Clear();

        foreach (string path in Directory.GetDirectories(modcenter.Location))
        {
            if (GamingSupport.TotalWarEngineSupportProvider.IsCompatibleModification(path))
            {
                GameModificationInfo mod = new (gamesetup, modcenter, path);
                modcenter.InstalledModifications.Add(mod);
            }
        }

        return modcenter.InstalledModifications;
    }
}
