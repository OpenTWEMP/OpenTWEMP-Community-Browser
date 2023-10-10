// <copyright file="ModCenterInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.Core.CommonLibrary;

public class ModCenterInfo
{
    private readonly GameSetupInfo parentGameSetup;

    public ModCenterInfo(string modcenterDirectory, GameSetupInfo gameSetupInfo)
    {
        parentGameSetup = gameSetupInfo;
        var modcenterDirectoryInfo = new DirectoryInfo(modcenterDirectory);
        Location = modcenterDirectoryInfo.FullName;
        Name = modcenterDirectoryInfo.Name;
        CacheDirectory = InitializeCacheDirectory(parentGameSetup.CacheDirectory, Name);
        InstalledModifications = new List<GameModificationInfo>();
    }

    public string Location { get; }

    public string Name { get; }

    public string CacheDirectory { get; }

    public List<GameModificationInfo> InstalledModifications { get; }

    public List<GameModificationInfo> FindAllModifications()
    {
        string[] modFolders = Directory.GetDirectories(Location);
        InstalledModifications.Clear();

        foreach (string modFolder in modFolders)
        {
            if (IsModification(modFolder))
            {
                var mod = new GameModificationInfo(modFolder, this, parentGameSetup);
                InstalledModifications.Add(mod);
            }
        }

        return InstalledModifications;
    }

    private static string InitializeCacheDirectory(string cacheGameSetupDirectoryPath, string cacheModCenterFolderName)
    {
        string cacheDirectoryPath = Path.Combine(cacheGameSetupDirectoryPath, cacheModCenterFolderName);

        if (!Directory.Exists(cacheDirectoryPath))
        {
            Directory.CreateDirectory(cacheDirectoryPath);
        }

        return cacheDirectoryPath;
    }

    private static bool IsModification(string modFolder)
    {
        return TWEMP.Browser.Core.GamingSupport.TotalWarEngineSupportProvider
            .IsCompatibleModification(modFolder);
    }
}
