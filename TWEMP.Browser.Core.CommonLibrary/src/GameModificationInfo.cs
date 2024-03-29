﻿// <copyright file="GameModificationInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.Core.CommonLibrary;

public class GameModificationInfo
{
    // example: modificationURI = "A:\TWEMP\modcenter_M2TW\MEDD"
    public GameModificationInfo(string modificationURI, ModCenterInfo parentModCenter, GameSetupInfo setupInfo)
    {
        Location = modificationURI;
        CurrentSetup = setupInfo;

        ShortName = new DirectoryInfo(modificationURI).Name;
        CacheDirectory = InitializeCacheDirectory(parentModCenter.CacheDirectory, ShortName);

        ModArgRelativePath = InitializeModArgRelativePath(ShortName, parentModCenter.Name);
        ModCfgRelativePath = InitializeModCfgRelativePath(ShortName, parentModCenter.Name);

        LogFileName = InitializeLogFileName();
        LogFileRelativePath = InitializeLogFileRelativePath(ModCfgRelativePath, LogFileName);

        CurrentPreset = InitializeModificationPreset(modificationURI);

        IsFavoriteMod = false;
    }

    public string Location { get; }

    public GameSetupInfo CurrentSetup { get; }

    public string ShortName { get; }

    public string CacheDirectory { get; }

    public string ModArgRelativePath { get; }

    public string ModCfgRelativePath { get; }

    public string LogFileName { get; }

    public string LogFileRelativePath { get; }

    public CustomModSupportPreset CurrentPreset { get; }

    public bool IsFavoriteMod { get; set; }

    public string GetPresetFilePath()
    {
        return CustomModSupportPreset.GetPresetFilePath(Location);
    }

    public string GetModPresetLogoImageFilePath()
    {
        return Path.Combine(Location, CustomModSupportPreset.MOD_PRESET_FOLDERNAME, CurrentPreset.LogotypeImage);
    }

    public bool CanBeLaunchedViaNativeBatch()
    {
        return File.Exists(Path.Combine(Location, CurrentPreset.LauncherProvider_NativeBatch));
    }

    public bool CanBeLaunchedViaNativeSetup()
    {
        return File.Exists(Path.Combine(Location, CurrentPreset.LauncherProvider_NativeSetup));
    }

    public bool CanBeLaunchedViaM2TWEOP()
    {
        return File.Exists(Path.Combine(Location, CurrentPreset.LauncherProvider_M2TWEOP));
    }

    private static string InitializeCacheDirectory(string cacheModCenterDirectoryPath, string cacheModFolderName)
    {
        string cacheDirectoryPath = Path.Combine(cacheModCenterDirectoryPath, cacheModFolderName);

        if (!Directory.Exists(cacheDirectoryPath))
        {
            Directory.CreateDirectory(cacheDirectoryPath);
        }

        return cacheDirectoryPath;
    }

    private static string InitializeModArgRelativePath(string modFolderName, string modcenterFolderName)
    {
        const string argumentLabel = "@";
        const string separatorSlash = "\\";

        return argumentLabel + modcenterFolderName + separatorSlash + modFolderName + separatorSlash; // example: "@mods\MEDD\"
    }

    private static string InitializeModCfgRelativePath(string modFolderName, string modcenterFolderName)
    {
        const string separatorSlash = "/";
        return modcenterFolderName + separatorSlash + modFolderName; // example: "mod = mods/MEDD"
    }

    private static string InitializeLogFileRelativePath(string modRelativePath, string modLogFileName)
    {
        return Path.Combine(modRelativePath, modLogFileName); // example: "to = mods/MEDD/system.log.txt"
    }

    private static string InitializeLogFileName()
    {
        string fileBaseName = "twe-mod-log";
        string fileExtension = ".txt";

        return fileBaseName + fileExtension;
    }

    private static CustomModSupportPreset InitializeModificationPreset(string modificationURI)
    {
        if (CustomModSupportPreset.Exists(modificationURI))
        {
            return CustomModSupportPreset.ReadExistingPreset(modificationURI);
        }
        else
        {
            return CustomModSupportPreset.CreatePresetByDefault(modificationURI);
        }
    }
}
