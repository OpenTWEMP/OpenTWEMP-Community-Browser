// <copyright file="GameSetupInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

namespace TWEMP.Browser.Core.CommonLibrary;

public class GameSetupInfo
{
    public GameSetupInfo(string setupName, string executableFullPath, List<string> modcenterPaths)
    {
        Name = setupName;
        CacheDirectory = InitializeCacheDirectory(Name);
        HomeDirectory = Path.GetDirectoryName(executableFullPath);
        ExecutableFileName = Path.GetFileName(executableFullPath);
        AttachedModCenters = InitializeModCentersList(modcenterPaths);
    }

    public string Name { get; }

    public string CacheDirectory { get; }

    public string? HomeDirectory { get; }

    public string? ExecutableFileName { get; }

    public List<ModCenterInfo> AttachedModCenters { get; }

    public List<GameModificationInfo> GetInstalledMods()
    {
        var installedMods = new List<GameModificationInfo>();

        foreach (ModCenterInfo modCenter in AttachedModCenters)
        {
            List<GameModificationInfo> detectedMods = modCenter.FindAllModifications();
            installedMods.AddRange(detectedMods);
        }

        return installedMods;
    }

    private static string InitializeCacheDirectory(string cacheFolderName)
    {
        string cacheDirectoryPath = Path.Combine(GameSettingsCacheStorage.Location, cacheFolderName);

        if (!Directory.Exists(cacheDirectoryPath))
        {
            Directory.CreateDirectory(cacheDirectoryPath);
        }

        return cacheDirectoryPath;
    }

    private List<ModCenterInfo> InitializeModCentersList(List<string> modcenterPaths)
    {
        var detectedModCenters = new List<ModCenterInfo>();

        foreach (var modcenterPath in modcenterPaths)
        {
            if (Directory.Exists(modcenterPath))
            {
                var modcenterObject = new ModCenterInfo(modcenterPath, this);
                detectedModCenters.Add(modcenterObject);
            }
        }

        return detectedModCenters;
    }
}
