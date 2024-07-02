// <copyright file="GameAudioCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public record GameAudioCfgSectionStateView : ICustomConfigState
{
    public GameAudioCfgSectionStateView()
    {
    }

    public M2TW_Boolean? AudioEnable { get; set; } // "enable"

    public M2TW_Integer? AudioMasterVolume { get; set; } // "master_vol"

    public M2TW_Integer? AudioMusicVolume { get; set; } // "music_vol"

    public M2TW_Integer? SoundCardProvider { get; set; } // "provider"

    public M2TW_Integer? SoundEffectsVolume { get; set; } // "sfx_vol"

    public M2TW_Boolean? SpeechEnable { get; set; } // "speech_enable"

    public M2TW_Integer? SpeechVolume { get; set; } // "speech_vol"

    public M2TW_Boolean? SubFactionAccents { get; set; } // "sub_faction_accents"

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }
}
