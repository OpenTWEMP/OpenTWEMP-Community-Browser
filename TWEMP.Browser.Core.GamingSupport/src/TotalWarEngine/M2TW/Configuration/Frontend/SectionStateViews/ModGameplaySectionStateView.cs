// <copyright file="ModGameplaySectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using ICustomConfigState = AbstractPlaceholders.ICustomConfigState;

public record ModGameplaySectionStateView : ICustomConfigState
{
    public ModGameplaySectionStateView()
    {
    }

    public M2TW_Boolean? GameAdvancedStatsAlways { get; set; } // "advanced_stats_always"

    public M2TW_Boolean? GameAdvisorVerbosity { get; set; } // "advisor_verbosity"

    public M2TW_Boolean? GameAiFactions { get; set; } // "ai_factions" | show or skip ?

    public M2TW_Boolean? GameAllSsers { get; set; } // "allusers"

    public M2TW_Boolean? GameAutoSave { get; set; } // "auto_save"

    public M2TW_Boolean? GameBlindAdvisor { get; set; } // "blind_advisor"

    public M2TW_Integer? GameCampaignMapGameSpeed { get; set; } // "campaign_map_game_speed"

    public M2TW_Integer? GameCampaignMapSpeedUp { get; set; } // "campaign_map_speed_up"

    public int GameCampaignNumTimePlay { get; set; } // "campaign_num_time_play" | ???

    public M2TW_Integer? GameChatMsgDuration { get; set; } // "chat_msg_duration"

    public M2TW_Boolean? GameDisableArrowMarkers { get; set; } // "disable_arrow_markers"

    public M2TW_Boolean? GameDisableEvents { get; set; } // "disable_events"

    public M2TW_Boolean? GameEnglish { get; set; } // "english"

    public M2TW_Boolean? GameEventCutscenes { get; set; } // "event_cutscenes"

    public M2TW_Boolean? GameFatigue { get; set; } // "fatigue"

    public M2TW_Boolean? GameFirstTimePlay { get; set; } // "first_time_play"

    public M2TW_Boolean? GameGamespySavePasswrd { get; set; } // "gamespy_save_passwrd"

    public M2TW_Boolean? GameLabelCharacters { get; set; } // "label_characters"

    public M2TW_Boolean? GameLabelSettlements { get; set; } // "label_settlements"

    public M2TW_Boolean? GameMicromanageAllSettlements { get; set; } // "micromanage_all_settlements"

    public M2TW_Boolean? GameMorale { get; set; } // "morale"

    public M2TW_Boolean? GameMuteAdvisor { get; set; } // "mute_advisor"

    public M2TW_Boolean? GameNoCampaignBattleTimeLimit { get; set; } // "no_campaign_battle_time_limit"

    public int GamePrefFactionsPlayed { get; set; } // "pref_factions_played" | 131071 - by default?

    public M2TW_Boolean? GameTutorialBattlePlayed { get; set; } // "tutorial_battle_played"

    public string? GameTutorialPath { get; set; } // "tutorial_path"

    public M2TW_UnitSize? GameUnitSize { get; set; } // "unit_size"

    public bool GameUnlimitedMenOnBattlefield { get; set; } // "unlimited_men_on_battlefield"

    public bool GameUseQuickchat { get; set; } // "use_quickchat"

    public bool UnlockCampaign { get; set; } // "unlock_campaign";

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }

    private static M2TWGameCfgSection GetGameSubSet()
    {
        string subsetName = "game";

        var subsetOptions = new List<M2TWGameCfgOption>();
        subsetOptions.Add(new M2TWGameCfgOption("unlimited_men_on_battlefield", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("unit_size", "huge", subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("no_campaign_battle_time_limit", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("advisor_verbosity", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("event_cutscenes", false, subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static Dictionary<string, bool> GenerateDefaultGameSettings()
    {
        return new Dictionary<string, bool>
        {
            { "advanced_stats_always", true },
            { "allusers", true },
            { "auto_save", true },
            { "blind_advisor", false },
            { "disable_arrow_markers", false },
            { "disable_events", false },
            { "english", false },
            { "event_cutscenes", true },
            { "fatigue", true },
            { "first_time_play", false },
            { "gamespy_save_passwrd", true },
            { "label_characters", false },
            { "label_settlements", true },
            { "micromanage_all_settlements", true },
            { "morale", true },
            { "mute_advisor", false },
            { "no_campaign_battle_time_limit", false },
            { "tutorial_battle_played", true },
            { "use_quickchat", false },
        };
    }
}
