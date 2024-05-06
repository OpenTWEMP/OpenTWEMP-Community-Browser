// <copyright file="GameAudioCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

public record GameAudioCfgSectionStateView : ICustomConfigState
{
    public GameAudioCfgSectionStateView()
    {
    }

    public bool AudioEnable { get; set; } // "enable"

    public byte AudioMasterVolume { get; set; } // "master_vol"

    public byte AudioMusicVolume { get; set; } // "music_vol"

    public byte SoundCardProvider { get; set; } // "provider"

    public byte SoundEffectsVolume { get; set; } // "sfx_vol"

    public bool SpeechEnable { get; set; } // "speech_enable"

    public byte SpeechVolume { get; set; } // "speech_vol"

    public bool SubFactionAccents { get; set; } // "sub_faction_accents"

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }
}
