// <copyright file="GameModificationInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

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

        this.Launcher = ModLauncherInfo.CreateByDefault();

        this.ShortName = new DirectoryInfo(path).Name;
        this.Location = path; // for example: "A:\TWEMP\modcenter_M2TW\MEDD"

        this.ModArgRelativePath = InitializeModArgRelativePath(this.ShortName, modcenter.Name);
        this.ModCfgRelativePath = InitializeModCfgRelativePath(this.ShortName, modcenter.Name);

        this.LogFileName = InitializeLogFileName();
        this.LogFileRelativePath = InitializeLogFileRelativePath(this.ModCfgRelativePath, this.LogFileName);

        this.IsFavoriteMod = false;
    }

    public GameSetupInfo CurrentSetup { get; }

    public ModLauncherInfo Launcher { get; set; }

    public string ShortName { get; }

    public string Location { get; }

    public string ModArgRelativePath { get; }

    public string ModCfgRelativePath { get; }

    public string LogFileName { get; }

    public string LogFileRelativePath { get; }

    public bool IsFavoriteMod { get; set; }

    public bool CanBeLaunchedViaNativeBatch() => File.Exists(
        Path.Combine(this.Location, this.Launcher.LauncherProvider_NativeBatch));

    public bool CanBeLaunchedViaNativeSetup() => File.Exists(
        Path.Combine(this.Location, this.Launcher.LauncherProvider_NativeSetup));

    public bool CanBeLaunchedViaM2TWEOP() => File.Exists(
        Path.Combine(this.Location, this.Launcher.LauncherProvider_M2TWEOP));

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
        const string separatorSlash = "/";
        return modRelativePath + separatorSlash + modLogFileName; // example: "to = mods/MEDD/system.log.txt"
    }

    private static string InitializeLogFileName()
    {
        string fileBaseName = "twe-mod-log";
        string fileExtension = ".txt";

        return fileBaseName + fileExtension;
    }
}
