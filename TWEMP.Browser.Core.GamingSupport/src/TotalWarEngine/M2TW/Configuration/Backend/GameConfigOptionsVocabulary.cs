// <copyright file="GameConfigOptionsVocabulary.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend;

public static class GameConfigOptionsVocabulary
{
    // [audio]
    public const string AudioConfigSwitch = "audio";

    public const string AudioEnable = "enable";
    public const string AudioMasterVolume = "master_vol";
    public const string AudioMusicVolume = "music_vol";
    public const string SoundCardProvider = "provider";
    public const string SoundEffectsVolume = "sfx_vol";
    public const string SpeechEnable = "speech_enable";
    public const string SpeechVolume = "speech_vol";
    public const string SubFactionAccents = "sub_faction_accents";

    // [camera]
    public const string CameraConfigSwitch = "camera";

    public const string CameraDefaultInBattle = "default_in_battle";
    public const string CameraMove = "move";
    public const string CameraRestrict = "restrict";
    public const string CameraRotate = "rotate";

    // [controls]
    public const string ControlsConfigSwitch = "controls";

    public const string CampaignScrollMaxZoom = "campaign_scroll_max_zoom";
    public const string CampaignScrollMinZoom = "campaign_scroll_min_zoom";
    public const string KeySet = "keyset";

    // [features]
    public const string FeaturesConfigSwitch = "features";

    public const string Mod = "mod";
    public const string Editor = "editor";

    // [game]
    public const string GameConfigSwitch = "game";

    public const string GameAdvancedStatsAlways = "advanced_stats_always";
    public const string GameAdvisorVerbosity = "advisor_verbosity";
    public const string GameAiFactions = "ai_factions";
    public const string GameAllSsers = "allusers";
    public const string GameAutoSave = "auto_save";
    public const string GameBlindAdvisor = "blind_advisor";
    public const string GameCampaignMapGameSpeed = "campaign_map_game_speed";
    public const string GameCampaignMapSpeedUp = "campaign_map_speed_up";
    public const string GameCampaignNumTimePlay = "campaign_num_time_play";
    public const string GameChatMsgDuration = "chat_msg_duration";
    public const string GameDisableArrowMarkers = "disable_arrow_markers";
    public const string GameDisableEvents = "disable_events";
    public const string GameEnglish = "english";
    public const string GameEventCutscenes = "event_cutscenes";
    public const string GameFatigue = "fatigue";
    public const string GameFirstTimePlay = "first_time_play";
    public const string GameGamespySavePasswrd = "gamespy_save_passwrd";
    public const string GameLabelCharacters = "label_characters";
    public const string GameLabelSettlements = "label_settlements";
    public const string GameMicromanageAllSettlements = "micromanage_all_settlements";
    public const string GameMorale = "morale";
    public const string GameMuteAdvisor = "mute_advisor";
    public const string GameNoCampaignBattleTimeLimit = "no_campaign_battle_time_limit";
    public const string GamePrefFactionsPlayed = "pref_factions_played";
    public const string GameTutorialPath = "tutorial_path";
    public const string GameUnitSize = "unit_size";
    public const string GameUnlimitedMenOnBattlefield = "unlimited_men_on_battlefield";
    public const string GameUseQuickchat = "use_quickchat";

    // [hotseat]
    public const string HotseatConfigSwitch = "hotseat";

    public const string HotseatAutoresolveBattles = "autoresolve_battles";
    public const string HotseatScroll = "scroll";
    public const string HotseatPasswords = "passwords";
    public const string HotseatTurns = "turns";
    public const string HotseatDisableConsole = "disable_console";
    public const string HotseatAdminPassword = "admin_password";
    public const string HotseatDisablePapalElections = "disable_papal_elections";
    public const string HotseatSavePrefs = "save_prefs";
    public const string HotseatUpdateAiCamera = "update_ai_camera";
    public const string HotseatAutoSave = "autosave";
    public const string HotseatSaveConfig = "save_config";
    public const string HotseatCloseAfterSave = "close_after_save";
    public const string HotseatGameName = "gamename";
    public const string HotseatValidateData = "validate_data";
    public const string HotseatAllowValidationFailures = "allow_validation_failures";
    public const string HotseatValidateDiplomacy = "validate_diplomacy";

    // [io]
    public const string IOConfigSwitch = "io";

    public const string FileFirst = "file_first";

    // [log]
    public const string LogConfigSwitch = "log";

    public const string LogTo = "to";

    // [misc]
    public const string MiscConfigSwitch = "misc";

    public const string BypassToStrategySave = "bypass_to_strategy_save";
    public const string UnlockCampaign = "unlock_campaign";

    // [network]
    public const string NetworkConfigSwitch = "network";

    public const string NetworkUseIp = "use_ip";
    public const string NetworkUsePort = "use_port";

    // [ui]
    public const string UIConfigSwitch = "ui";

    public const string UiSaCards = "SA_cards";
    public const string UiButtons = "buttons";
    public const string UiFullBattleHud = "full_battle_HUD";
    public const string UiRadar = "radar";
    public const string UiShowTooltips = "show_tooltips";
    public const string UiUnitCards = "unit_cards";

    // [video]
    public const string VideoConfigSwitch = "video";

    public const string VideoAnisotropicLevel = "anisotropic_level";
    public const string VideoAntiAliasMode = "anti_alias_mode";
    public const string VideoAntialiasing = "antialiasing";
    public const string VideoAssassinationMovies = "assassination_movies";
    public const string VideoAutodetect = "autodetect";
    public const string VideoBattleResolution = "battle_resolution";
    public const string VideoBloom = "bloom";
    public const string VideoBuildingDetail = "building_detail";
    public const string VideoCampaignResolution = "campaign_resolution";
    public const string VideoDepthShadows = "depth_shadows";
    public const string VideoDepthShadowsResolution = "depth_shadows_resolution";
    public const string VideoEffectQuality = "effect_quality";
    public const string VideoEventMovies = "event_movies";
    public const string VideoGamma = "gamma";
    public const string VideoGrassDistance = "grass_distance";
    public const string VideoGroundBuffersPerNode = "ground_buffers_per_node";
    public const string VideoGroundCoverBuffersPerNode = "ground_cover_buffers_per_node";
    public const string VideoInfiltrationMovies = "infiltration_movies";
    public const string VideoMovies = "movies";
    public const string VideoModelBuffersPerNode = "model_buffers_per_node";
    public const string VideoNoBackgroundFmv = "no_background_fmv";
    public const string VideoReflection = "reflection";
    public const string VideoSabotageMovies = "sabotage_movies";
    public const string VideoShader = "shader";
    public const string VideoShowBanners = "show_banners";
    public const string VideoShowPackageLitter = "show_package_litter";
    public const string VideoSkipMipLevels = "skip_mip_levels";
    public const string VideoSplashes = "splashes";
    public const string VideoSpriteBuffersPerNode = "sprite_buffers_per_node";
    public const string VideoStencilShadows = "stencil_shadows";
    public const string VideoSubtitles = "subtitles";
    public const string VideoTerrainQuality = "terrain_quality";
    public const string VideoTextureFiltering = "texture_filtering";
    public const string VideoUnitDetail = "unit_detail";
    public const string VideoVegetation = "vegetation";
    public const string VideoVsync = "vsync";
    public const string VideoWaterBuffersPerNode = "water_buffers_per_node";
    public const string VideoWidescreen = "widescreen";
    public const string VideoWindowed = "windowed";
}
