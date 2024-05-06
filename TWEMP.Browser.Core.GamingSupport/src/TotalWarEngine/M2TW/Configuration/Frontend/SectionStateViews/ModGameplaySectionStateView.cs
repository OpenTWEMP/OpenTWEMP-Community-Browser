// <copyright file="ModGameplaySectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

public record ModGameplaySectionStateView
{
    public bool GameAdvancedStatsAlways { get; set; } // "advanced_stats_always"

    public bool GameAdvisorVerbosity { get; set; } // "advisor_verbosity"

    public bool GameAiFactions { get; set; } // "ai_factions" | show or skip ?

    public bool GameAllSsers { get; set; } // "allusers"

    public bool GameAutoSave { get; set; } // "auto_save"

    public bool GameBlindAdvisor { get; set; } // "blind_advisor"

    public byte GameCampaignMapGameSpeed { get; set; } // "campaign_map_game_speed"

    public byte GameCampaignMapSpeedUp { get; set; } // "campaign_map_speed_up"

    public int GameCampaignNumTimePlay { get; set; } // "campaign_num_time_play" | ???

    public ushort GameChatMsgDuration { get; set; } // "chat_msg_duration"

    public bool GameDisableArrowMarkers { get; set; } // "disable_arrow_markers"

    public bool GameDisableEvents { get; set; } // "disable_events"

    public bool GameEnglish { get; set; } // "english"

    public bool GameEventCutscenes { get; set; } // "event_cutscenes"

    public bool GameFatigue { get; set; } // "fatigue"

    public bool GameFirstTimePlay { get; set; } // "first_time_play"

    public bool GameGamespySavePasswrd { get; set; } // "gamespy_save_passwrd"

    public bool GameLabelCharacters { get; set; } // "label_characters"

    public bool GameLabelSettlements { get; set; } // "label_settlements"

    public bool GameMicromanageAllSettlements { get; set; } // "micromanage_all_settlements"

    public bool GameMorale { get; set; } // "morale"

    public bool GameMuteAdvisor { get; set; } // "mute_advisor"

    public bool GameNoCampaignBattleTimeLimit { get; set; } // "no_campaign_battle_time_limit"

    public int GamePrefFactionsPlayed { get; set; } // "pref_factions_played" | 131071 - by default?

    public bool GameTutorialBattlePlayed { get; set; } // "tutorial_battle_played"

    public string? GameTutorialPath { get; set; } // "tutorial_path"

/*
    // Possible values: 'small', 'norma', 'large', 'huge'
    public <M2TW_TYPE> GameUnitSize { get; set; } // "unit_size"
*/

    public bool GameUnlimitedMenOnBattlefield { get; set; } // "unlimited_men_on_battlefield"

    public bool GameUseQuickchat { get; set; } // "use_quickchat"

    public bool UnlockCampaign { get; set; } // "unlock_campaign";

}
