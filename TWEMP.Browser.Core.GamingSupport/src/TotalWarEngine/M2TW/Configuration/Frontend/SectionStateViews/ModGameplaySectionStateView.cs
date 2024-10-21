// <copyright file="ModGameplaySectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;

public record ModGameplaySectionStateView : ICustomConfigState
{
    private const string GameConfigSwitch = "game";
    private const string MiscConfigSwitch = "misc";

    public const string GameAdvancedStatsAlwaysTextId = "advanced_stats_always";
    public const string GameAdvisorVerbosityTextId = "advisor_verbosity";
    public const string GameAiFactionsTextId = "ai_factions";
    public const string GameAllUsersTextId = "allusers";
    public const string GameAutoSaveTextId = "auto_save";
    public const string GameBlindAdvisorTextId = "blind_advisor";
    public const string GameCampaignMapGameSpeedTextId = "campaign_map_game_speed";
    public const string GameCampaignMapSpeedUpTextId = "campaign_map_speed_up";
    public const string GameCampaignNumTimePlayTextId = "campaign_num_time_play";
    public const string GameChatMsgDurationTextId = "chat_msg_duration";
    public const string GameDisableArrowMarkersTextId = "disable_arrow_markers";
    public const string GameDisableEventsTextId = "disable_events";
    public const string GameEnglishTextId = "english";
    public const string GameEventCutscenesTextId = "event_cutscenes";
    public const string GameFatigueTextId = "fatigue";
    public const string GameFirstTimePlayTextId = "first_time_play";
    public const string GameGamespySavePasswrdTextId = "gamespy_save_passwrd";
    public const string GameLabelCharactersTextId = "label_characters";
    public const string GameLabelSettlementsTextId = "label_settlements";
    public const string GameMicromanageAllSettlementsTextId = "micromanage_all_settlements";
    public const string GameMoraleTextId = "morale";
    public const string GameMuteAdvisorTextId = "mute_advisor";
    public const string GameNoCampaignBattleTimeLimitTextId = "no_campaign_battle_time_limit";
    public const string GamePrefFactionsPlayedTextId = "pref_factions_played";
    public const string GameTutorialBattlePlayedTextId = "tutorial_battle_played";
    public const string GameTutorialPathTextId = "tutorial_path";
    public const string GameUnitSizeTextId = "unit_size";
    public const string GameUnlimitedMenOnBattlefieldTextId = "unlimited_men_on_battlefield";
    public const string GameUseQuickchatTextId = "use_quickchat";
    public const string UnlockCampaignTextId = "unlock_campaign";
    public const string BypassToStrategySaveTextId = "bypass_to_strategy_save";

    public ModGameplaySectionStateView()
    {
    }

    public M2TW_Boolean? GameAdvancedStatsAlways { get; set; } // "advanced_stats_always"

    public M2TW_Boolean? GameAdvisorVerbosity { get; set; } // "advisor_verbosity"

    public M2TW_Boolean? GameAiFactions { get; set; } // "ai_factions" | show or skip ?

    public M2TW_Boolean? GameAllUsers { get; set; } // "allusers"

    public M2TW_Boolean? GameAutoSave { get; set; } // "auto_save"

    public M2TW_Boolean? GameBlindAdvisor { get; set; } // "blind_advisor"

    public M2TW_Integer? GameCampaignMapGameSpeed { get; set; } // "campaign_map_game_speed"

    public M2TW_Integer? GameCampaignMapSpeedUp { get; set; } // "campaign_map_speed_up"

    public M2TW_Integer? GameCampaignNumTimePlay { get; set; } // "campaign_num_time_play" | ???

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

    public int? GamePrefFactionsPlayed { get; set; } // "pref_factions_played" | 131071 - by default?

    public M2TW_Boolean? GameTutorialBattlePlayed { get; set; } // "tutorial_battle_played"

    public string? GameTutorialPath { get; set; } // "tutorial_path"

    public M2TW_UnitSize? GameUnitSize { get; set; } // "unit_size"

    public M2TW_Boolean? GameUnlimitedMenOnBattlefield { get; set; } // "unlimited_men_on_battlefield"

    public M2TW_Boolean? GameUseQuickchat { get; set; } // "use_quickchat"

    public M2TW_Boolean? UnlockCampaign { get; set; } // "unlock_campaign";

    public string? BypassToStrategySave { get; set; } // "bypass_to_strategy_save";

    public static ModGameplaySectionStateView CreateByDefault()
    {
        return new ModGameplaySectionStateView
        {
            GameAdvancedStatsAlways = new M2TW_Boolean(false),
            GameAdvisorVerbosity = new M2TW_Boolean(false),
            GameAiFactions = new M2TW_Boolean(M2TW_Deprecated_AI_Boolean.Follow),
            GameAllUsers = new M2TW_Boolean(true),
            GameAutoSave = new M2TW_Boolean(true),
            GameBlindAdvisor = new M2TW_Boolean(false),
            GameCampaignMapGameSpeed = new M2TW_Integer(10),
            GameCampaignMapSpeedUp = new M2TW_Integer(1),
            GameCampaignNumTimePlay = new M2TW_Integer(252),
            GameChatMsgDuration = new M2TW_Integer(M2TW_Integer.ExtendedMaxValue),
            GameDisableArrowMarkers = new M2TW_Boolean(false),
            GameDisableEvents = new M2TW_Boolean(false),
            GameEnglish = new M2TW_Boolean(false),
            GameEventCutscenes = new M2TW_Boolean(true),
            GameFatigue = new M2TW_Boolean(true),
            GameFirstTimePlay = new M2TW_Boolean(false),
            GameGamespySavePasswrd = new M2TW_Boolean(true),
            GameLabelCharacters = new M2TW_Boolean(false),
            GameLabelSettlements = new M2TW_Boolean(true),
            GameMicromanageAllSettlements = new M2TW_Boolean(true),
            GameMorale = new M2TW_Boolean(true),
            GameMuteAdvisor = new M2TW_Boolean(false),
            GameNoCampaignBattleTimeLimit = new M2TW_Boolean(true),
            GamePrefFactionsPlayed = 4177855,
            GameTutorialBattlePlayed = new M2TW_Boolean(false),
            GameTutorialPath = "norman_prologue/battle_of_hastings",
            GameUnitSize = new M2TW_UnitSize(M2TW_Size.Huge),
            GameUnlimitedMenOnBattlefield = new M2TW_Boolean(true),
            GameUseQuickchat = new M2TW_Boolean(false),
            UnlockCampaign = new M2TW_Boolean(false),
            BypassToStrategySave = string.Empty,
        };
    }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        M2TWGameCfgOption[] gameCfgOptions =
        {
            new (name: GameAdvancedStatsAlwaysTextId, value: this.GameAdvancedStatsAlways!, section: GameConfigSwitch),
            new (name: GameAdvisorVerbosityTextId, value: this.GameAdvisorVerbosity!, section: GameConfigSwitch),
            new (name: GameAiFactionsTextId, value: this.GameAiFactions!, section: GameConfigSwitch),
            new (name: GameAllUsersTextId, value: this.GameAllUsers!, section: GameConfigSwitch),
            new (name: GameAutoSaveTextId, value: this.GameAutoSave!, section: GameConfigSwitch),
            new (name: GameBlindAdvisorTextId, value: this.GameBlindAdvisor!, section: GameConfigSwitch),
            new (name: GameCampaignMapGameSpeedTextId, value: this.GameCampaignMapGameSpeed!, section: GameConfigSwitch),
            new (name: GameCampaignMapSpeedUpTextId, value: this.GameCampaignMapSpeedUp!, section: GameConfigSwitch),
            new (name: GameCampaignNumTimePlayTextId, value: this.GameCampaignNumTimePlay!, section: GameConfigSwitch),
            new (name: GameChatMsgDurationTextId, value: this.GameChatMsgDuration!, section: GameConfigSwitch),
            new (name: GameDisableArrowMarkersTextId, value: this.GameDisableArrowMarkers!, section: GameConfigSwitch),
            new (name: GameDisableEventsTextId, value: this.GameDisableEvents!, section: GameConfigSwitch),
            new (name: GameEnglishTextId, value: this.GameEnglish!, section: GameConfigSwitch),
            new (name: GameEventCutscenesTextId, value: this.GameEventCutscenes!, section: GameConfigSwitch),
            new (name: GameFatigueTextId, value: this.GameFatigue!, section: GameConfigSwitch),
            new (name: GameFirstTimePlayTextId, value: this.GameFirstTimePlay!, section: GameConfigSwitch),
            new (name: GameGamespySavePasswrdTextId, value: this.GameGamespySavePasswrd!, section: GameConfigSwitch),
            new (name: GameLabelCharactersTextId, value: this.GameLabelCharacters!, section: GameConfigSwitch),
            new (name: GameLabelSettlementsTextId, value: this.GameLabelSettlements!, section: GameConfigSwitch),
            new (name: GameMicromanageAllSettlementsTextId, value: this.GameMicromanageAllSettlements!, section: GameConfigSwitch),
            new (name: GameMoraleTextId, value: this.GameMorale!, section: GameConfigSwitch),
            new (name: GameMuteAdvisorTextId, value: this.GameMuteAdvisor!, section: GameConfigSwitch),
            new (name: GameNoCampaignBattleTimeLimitTextId, value: this.GameNoCampaignBattleTimeLimit!, section: GameConfigSwitch),
            new (name: GamePrefFactionsPlayedTextId, value: this.GamePrefFactionsPlayed!, section: GameConfigSwitch),
            new (name: GameTutorialBattlePlayedTextId, value: this.GameTutorialBattlePlayed!, section: GameConfigSwitch),
            new (name: GameTutorialPathTextId, value: this.GameTutorialPath!, section: GameConfigSwitch),
            new (name: GameUnitSizeTextId, value: this.GameUnitSize!, section: GameConfigSwitch),
            new (name: GameUnlimitedMenOnBattlefieldTextId, value: this.GameUnlimitedMenOnBattlefield!, section: GameConfigSwitch),
            new (name: GameUseQuickchatTextId, value: this.GameUseQuickchat!, section: GameConfigSwitch),
        };

        M2TWGameCfgOption[] miscCfgOptions =
        {
            new (name: BypassToStrategySaveTextId, value: this.BypassToStrategySave!, section: MiscConfigSwitch),
            new (name: UnlockCampaignTextId, value: this.UnlockCampaign!, section: MiscConfigSwitch),
        };

        GameCfgSection gameCfgSection = new M2TWGameCfgSection(GameConfigSwitch, gameCfgOptions);
        GameCfgSection miscCfgSection = new M2TWGameCfgSection(MiscConfigSwitch, miscCfgOptions);

        return new GameCfgSection[] { gameCfgSection, miscCfgSection };
    }
}
