// <copyright file="ModSupportPreset.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public record ModSupportPreset
{
    public const string ModTitle = "TITLE";
    public const string ModVersion = "VERSION";

    private const string ModLogoFileName = "LOGO.png";
    private const string ModMusicFileName = "MUSIC.mp3";

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
        ModHeaderInfo header = new (ModTitle, ModVersion);
        ModContentInfo content = new (ModLogoFileName, ModMusicFileName);
        ModLauncherInfo launcher = ModLauncherInfo.CreateByDefault();

        ModSocialMediaInfo socialmedia = new (new Dictionary<string, string>()
        {
            { "URL1", "https://my-public-mod-url1.twemp/" },
            { "URL2", "https://my-public-mod-url2.twemp" },
            { "URL3", "https://my-public-mod-url3.twemp" },
        });

        return new ModSupportPreset(header, content, launcher, socialmedia);
    }
}
