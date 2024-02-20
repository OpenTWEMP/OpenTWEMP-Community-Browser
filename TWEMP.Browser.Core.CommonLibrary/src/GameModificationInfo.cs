// <copyright file="GameModificationInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

public class GameModificationInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameModificationInfo"/> class.
    /// </summary>
    /// <param name="gamesetup">The game setup of the current game modification.</param>
    /// <param name="modcenter">The modcenter of the current game modification.</param>
    /// <param name="path">The directory path to the current game modification.</param>
    public GameModificationInfo(GameSetupInfo gamesetup, ModCenterInfo modcenter, string path)
    {
        this.CurrentSetup = gamesetup;

        this.ShortName = new DirectoryInfo(path).Name;
        this.Location = path; // for example: "A:\TWEMP\modcenter_M2TW\MEDD"

        this.ModArgRelativePath = InitializeModArgRelativePath(this.ShortName, modcenter.Name);
        this.ModCfgRelativePath = InitializeModCfgRelativePath(this.ShortName, modcenter.Name);

        this.LogFileName = InitializeLogFileName();
        this.LogFileRelativePath = InitializeLogFileRelativePath(this.ModCfgRelativePath, this.LogFileName);

        this.CurrentPreset = InitializeModificationPreset(path);

        this.IsFavoriteMod = false;
    }

    public GameSetupInfo CurrentSetup { get; }

    public string ShortName { get; }

    public string Location { get; }

    public string ModArgRelativePath { get; }

    public string ModCfgRelativePath { get; }

    public string LogFileName { get; }

    public string LogFileRelativePath { get; }

    public CustomModSupportPreset CurrentPreset { get; }

    public bool IsFavoriteMod { get; set; }

    public string GetPresetFilePath()
    {
        return CustomModSupportPreset.GetPresetFilePath(this.Location);
    }

    public string GetModPresetLogoImageFilePath()
    {
        return Path.Combine(this.Location, CustomModSupportPreset.MOD_PRESET_FOLDERNAME, this.CurrentPreset.LogotypeImage);
    }

    public bool CanBeLaunchedViaNativeBatch()
    {
        return File.Exists(Path.Combine(this.Location, this.CurrentPreset.LauncherProvider_NativeBatch));
    }

    public bool CanBeLaunchedViaNativeSetup()
    {
        return File.Exists(Path.Combine(this.Location, this.CurrentPreset.LauncherProvider_NativeSetup));
    }

    public bool CanBeLaunchedViaM2TWEOP()
    {
        return File.Exists(Path.Combine(this.Location, this.CurrentPreset.LauncherProvider_M2TWEOP));
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
