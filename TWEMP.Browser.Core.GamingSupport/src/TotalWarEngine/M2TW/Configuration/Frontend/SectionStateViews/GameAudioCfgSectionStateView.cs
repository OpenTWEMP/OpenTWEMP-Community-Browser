// <copyright file="GameAudioCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public record GameAudioCfgSectionStateView : ICustomConfigState
{
    private const string AudioConfigSwitch = "audio";

    public const string AudioEnableTextId = "enable";
    public const string AudioMasterVolumeTextId = "master_vol";
    public const string AudioMusicVolumeTextId = "music_vol";
    public const string SoundEffectsVolumeTextId = "sfx_vol";
    public const string SpeechEnableTextId = "speech_enable";
    public const string SpeechVolumeTextId = "speech_vol";
    public const string SubFactionAccentsTextId = "sub_faction_accents";
    public const string SoundCardProviderTextId = "provider";

    public GameAudioCfgSectionStateView()
    {
    }

    public M2TW_Boolean? AudioEnable { get; set; } // "enable"

    public M2TW_Integer? AudioMasterVolume { get; set; } // "master_vol"

    public M2TW_Integer? AudioMusicVolume { get; set; } // "music_vol"

    public M2TW_Integer? SoundEffectsVolume { get; set; } // "sfx_vol"

    public M2TW_Boolean? SpeechEnable { get; set; } // "speech_enable"

    public M2TW_Integer? SpeechVolume { get; set; } // "speech_vol"

    public M2TW_Boolean? SubFactionAccents { get; set; } // "sub_faction_accents"

    public string? SoundCardProvider { get; set; } // "provider"

    public static GameAudioCfgSectionStateView CreateByDefault()
    {
        return new GameAudioCfgSectionStateView
        {
            AudioEnable = new M2TW_Boolean(true),
            AudioMasterVolume = new M2TW_Integer(85),
            AudioMusicVolume = new M2TW_Integer(70),
            SoundEffectsVolume = new M2TW_Integer(80),
            SpeechEnable = new M2TW_Boolean(true),
            SpeechVolume = new M2TW_Integer(85),
            SubFactionAccents = new M2TW_Boolean(true),
            SoundCardProvider = "Miles Fast 2D Positional Audio",
        };
    }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        M2TWGameCfgOption audioEnableOption = new (
            name: AudioEnableTextId, value: this.AudioEnable!.BooleanValue, section: AudioConfigSwitch);

        M2TWGameCfgOption audioMasterVolumeOption = new (
            name: AudioMasterVolumeTextId, value: this.AudioMasterVolume!.Value, section: AudioConfigSwitch);

        M2TWGameCfgOption audioMusicVolumeOption = new (
            name: AudioMusicVolumeTextId, value: this.AudioMusicVolume!.Value, section: AudioConfigSwitch);

        M2TWGameCfgOption soundEffectsVolumeOption = new (
            name: SoundEffectsVolumeTextId, value: this.SoundEffectsVolume!.Value, section: AudioConfigSwitch);

        M2TWGameCfgOption speechEnableOption = new (
            name: SpeechEnableTextId, value: this.SpeechEnable!.BooleanValue, section: AudioConfigSwitch);

        M2TWGameCfgOption speechVolumeOption = new (
            name: SpeechVolumeTextId, value: this.SpeechVolume!.Value, section: AudioConfigSwitch);

        M2TWGameCfgOption subFactionAccentsOption = new (
            name: SubFactionAccentsTextId, value: this.SubFactionAccents!.BooleanValue, section: AudioConfigSwitch);

        M2TWGameCfgOption soundCardProviderOption = new (
            name: SoundCardProviderTextId, value: this.SoundCardProvider!, section: AudioConfigSwitch);

        M2TWGameCfgOption[] audioCfgOptions =
        {
            audioEnableOption,
            audioMasterVolumeOption,
            audioMusicVolumeOption,
            soundEffectsVolumeOption,
            speechEnableOption,
            speechVolumeOption,
            subFactionAccentsOption,
            soundCardProviderOption,
        };

        GameCfgSection audioCfgSection = new M2TWGameCfgSection(AudioConfigSwitch, audioCfgOptions);
        return new GameCfgSection[] { audioCfgSection };
    }
}
