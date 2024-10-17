// <copyright file="ModSupportPreset.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public record ModSupportPreset
{
    public ModSupportPreset(
        ModHeaderInfo headerInfo,
        ModContentInfo contentInfo,
        ModLauncherInfo launcherInfo,
        ModSocialMediaInfo socialMediaInfo)
    {
        this.HeaderInfo = headerInfo;
        this.ContentInfo = contentInfo;
        this.LauncherInfo = launcherInfo;
        this.SocialMediaInfo = socialMediaInfo;
    }

    public ModHeaderInfo HeaderInfo { get; set; }

    public ModContentInfo ContentInfo { get; set; }

    public ModLauncherInfo LauncherInfo { get; set; }

    public ModSocialMediaInfo SocialMediaInfo { get; set; }

    public static ModSupportPreset CreateDefaultTemplate()
    {
        const string modTitle = "My_Title";
        const string modVersion = "My_Version";

        ModHeaderInfo header = new (modTitle, modVersion);

        const string modLogoFileName = "DEFAULT.png";
        const string modMusicFileName = "My_Background_SoundTrack.mp3";

        ModContentInfo content = new (modLogoFileName, modMusicFileName);

        const string launcherNativeBatch = "My_Batch_Script.bat";
        const string launcherNativeSetup = "My_Setup_Program.exe";
        const string launcherM2TWEOP = "M2TWEOP GUI.exe";

        ModLauncherInfo launcher = new ModLauncherInfo(launcherNativeBatch, launcherNativeSetup, launcherM2TWEOP);

        ModSocialMediaInfo socialmedia = new (new Dictionary<string, string>()
        {
            { "URL1", "https://my-public-mod-url1.twemp/" },
            { "URL2", "https://my-public-mod-url2.twemp" },
            { "URL3", "https://my-public-mod-url3.twemp" },
        });

        return new ModSupportPreset(header, content, launcher, socialmedia);
    }
}

public record CustomizableModPreset
{
    private const string PresetFolderName = ".twemp";
    private const string PresetConfigFileName = "mod_support.json";

    public CustomizableModPreset(ModSupportPreset preset, string modURI)
    {
        this.Data = preset;
        this.Location = InitializeModPresetHomeDirectoryInfo(modURI);
        this.Config = InitializeModPresetConfigFileInfo(modURI);
    }

    public ModSupportPreset Data { get; set; }

    public DirectoryInfo Location { get; set; }

    public FileInfo Config { get; set; }

    public static CustomizableModPreset CreateDefaultTemplate(string modURI)
    {
        ModSupportPreset preset = ModSupportPreset.CreateDefaultTemplate();
        return new CustomizableModPreset(preset, modURI);
    }

    private static DirectoryInfo InitializeModPresetHomeDirectoryInfo(string modURI)
    {
        string directoryPath = Path.Combine(modURI, PresetFolderName);
        return new DirectoryInfo(directoryPath);
    }

    private static FileInfo InitializeModPresetConfigFileInfo(string modURI)
    {
        string filePath = Path.Combine(modURI, PresetFolderName, PresetConfigFileName);
        return new FileInfo(filePath);
    }
}

public record RedistributableModPreset
{
    public RedistributableModPreset(ModSupportPreset preset, ModPresetMetaInfo metadata)
    {
        this.Data = preset;
        this.Metadata = metadata;
    }

    public ModSupportPreset Data { get; set; }

    public ModPresetMetaInfo Metadata { get; set; }

    public static RedistributableModPreset CreateDefaultTemplate()
    {
        ModSupportPreset preset = ModSupportPreset.CreateDefaultTemplate();
        ModPresetMetaInfo metadata = ModPresetMetaInfo.CreateDefaultTemplate();

        return new RedistributableModPreset(preset, metadata);
    }
}

public record ModPresetMetaInfo
{
    public ModPresetMetaInfo(
        Guid guid,
        string version,
        string presetName,
        string packageName,
        string creator)
    {
        this.Guid = guid;
        this.Version = version;
        this.PresetName = presetName;
        this.PackageName = packageName;
        this.Creator = creator;
    }

    public Guid Guid { get; set; }

    public string Version { get; set; }

    public string PresetName { get; set; }

    public string PackageName { get; set; }

    public string Creator { get; set; }

    public static ModPresetMetaInfo CreateDefaultTemplate()
    {
        return new ModPresetMetaInfo(
            guid: Guid.NewGuid(),
            version: "0.0.0",
            presetName: "M2TW Game Engine Modification",
            packageName: "M2TW Mod Support Presets",
            creator: "The OpenTWEMP Project");
    }
}

public record ModHeaderInfo
{
    public ModHeaderInfo(string title, string version)
    {
        this.ModTitle = title;
        this.ModVersion = version;
    }

    public string ModTitle { get; set; }

    public string ModVersion { get; set; }
}

public record ModContentInfo
{
    public ModContentInfo(string logoFilePath, string musicFilePath)
    {
        this.LogotypeImage = logoFilePath;
        this.BackgroundSoundTrack = musicFilePath;
    }

    public string LogotypeImage { get; set; }

    public string BackgroundSoundTrack { get; set; }
}

public record ModLauncherInfo
{
    public ModLauncherInfo(string batch, string setup, string eop)
    {
        this.LauncherProvider_NativeBatch = batch;
        this.LauncherProvider_NativeSetup = setup;
        this.LauncherProvider_M2TWEOP = eop;
    }

    public string LauncherProvider_NativeBatch { get; set; }

    public string LauncherProvider_NativeSetup { get; set; }

    public string LauncherProvider_M2TWEOP { get; set; }
}

public record ModSocialMediaInfo
{
    public ModSocialMediaInfo(Dictionary<string, string> urlPairs)
    {
        this.ModURLs = urlPairs;
    }

    public Dictionary<string, string> ModURLs { get; set; }
}
