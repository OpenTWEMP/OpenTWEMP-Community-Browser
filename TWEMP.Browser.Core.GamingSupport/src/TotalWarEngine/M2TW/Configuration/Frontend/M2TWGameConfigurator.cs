// <copyright file="M2TWGameConfigurator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

/// <summary>
/// Implements the game configurator agent for the "Medieval 2 Total War" game engine (M2TW).
/// </summary>
public class M2TWGameConfigurator : IGameConfiguratorAgent
{
    private readonly GameModificationInfo gameModificationInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="M2TWGameConfigurator"/> class.
    /// </summary>
    /// <param name="info">Information about a target game modification.</param>
    public M2TWGameConfigurator(GameModificationInfo info)
    {
        this.gameModificationInfo = info;
    }

    /// <summary>
    /// Gets M2TW configuration settings by default.
    /// </summary>
    /// <returns>The string with default settings of the game configuration.</returns>
    public string GetDefaultSettingsString()
    {
        return string.Empty; // TODO: Implement using existing M2TW config settings!
    }

    /// <summary>
    /// Gets M2TW configuration settings via a custom configuration state.
    /// </summary>
    /// <param name="state">A target custom game configuration state.</param>
    /// <returns>The string with custom settings of the game configuration.</returns>
    public string GetCustomSettingsString(ICustomConfigState state)
    {
        return string.Empty; // TODO: Implement using existing M2TW config settings!
    }

    public static List<M2TWGameCfgSection> InitializeMinimalModSettings(GameModificationInfo mod, M2TWGameConfigStateView cfg)
    {
        List<M2TWGameCfgSection> settings = new ();

        M2TWGameCfgSection features_subset = GetFeaturesSubSet(mod); // [features]
        settings.Add(features_subset);

        M2TWGameCfgSection io_subset = GetIOSubSet(); // [io]
        settings.Add(io_subset);

        M2TWGameCfgSection log_subset = GetLogSubSet(mod, cfg); // [log]
        settings.Add(log_subset);

        M2TWGameCfgSection video_subset = GetVideoSubSet(cfg); // [video]
        settings.Add(video_subset);

        M2TWGameCfgSection hotseat_subset = GetHotseatSubSet(); // [hotseat]
        settings.Add(hotseat_subset);

        M2TWGameCfgSection multiplayer_subset = GetMultiplayerSubSet(); // [multiplayer]
        settings.Add(multiplayer_subset);

        M2TWGameCfgSection game_subset = GetGameSubSet(); // [game]
        settings.Add(game_subset);

        M2TWGameCfgSection ui_subset = GetUISubSet(); // [ui]
        settings.Add(ui_subset);

        M2TWGameCfgSection misc_subset = GetMiscSubSet(); // [misc]
        settings.Add(misc_subset);

        return settings;
    }

    private static M2TWGameCfgSection GetFeaturesSubSet(GameModificationInfo mod)
    {
        string subsetName = "features";

        var subsetOptions = new List<M2TWGameCfgOption>();

        subsetOptions.Add(new M2TWGameCfgOption("editor", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("mod", mod.ModCfgRelativePath!, subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static M2TWGameCfgSection GetIOSubSet()
    {
        string subsetName = "io";

        var subsetOptions = new List<M2TWGameCfgOption>();
        subsetOptions.Add(new M2TWGameCfgOption("file_first", true, subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static M2TWGameCfgSection GetLogSubSet(GameModificationInfo mod, M2TWGameConfigStateView cfg)
    {
        string subsetName = "log";

        var subsetOptions = new List<M2TWGameCfgOption>();
        subsetOptions.Add(new M2TWGameCfgOption("to", mod.LogFileRelativePath!, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("level", SetLogLevel(cfg), subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static string SetLogLevel(M2TWGameConfigStateView cfg)
    {
        const string strLogLevelError = "* error";
        const string strLogLevelTrace = "* trace";
        const string strLogLevelScriptTrace = "*script* trace";

        string strLogLevel = string.Empty;

        if (cfg.ValidatorLogLevel1)
        {
            strLogLevel = strLogLevelError;
        }

        if (cfg.ValidatorLogLevel2)
        {
            strLogLevel = strLogLevelTrace;
        }

        if (cfg.ValidatorLogLevel3)
        {
            strLogLevel = strLogLevelScriptTrace;
        }

        return strLogLevel;
    }

    private static M2TWGameCfgSection GetVideoSubSet(M2TWGameConfigStateView cfg)
    {
        string subsetName = "video";
        var subsetOptions = new List<M2TWGameCfgOption>();
        subsetOptions.Add(new M2TWGameCfgOption("windowed", cfg.IsEnabledWindowedMode, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("movies", cfg.ValidatorVideo, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("borderless_window", cfg.ValidatorBorderless, subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static Dictionary<string, object> GenerateDefaultVideoSettings()
    {
        Dictionary<string, object> settings;

        settings = new Dictionary<string, object>()
        {
            { "assassination_movies", false },
            { "autodetect", false },
            { "bloom", true },
            { "borderless_window", false },
            { "event_movies", true },
            { "infiltration_movies", false },
            { "movies", false },
            { "no_background_fmv", true },
            { "reflection", true },
            { "sabotage_movies", false },
            { "show_banners", false },
            { "show_package_litter", true },
            { "skip_mip_levels", false },
            { "splashes", true },
            { "stencil_shadows", true },
            { "subtitles", false },
            { "vegetation", false },
            { "vsync", false },
            { "widescreen", false },
            { "windowed", false },
            { "anti_alias_mode", "off" },
            { "building_detail", "high" },
            { "effect_quality", "highest" },
            { "terrain_quality", "custom" },
            { "unit_detail", "highest" },
            { "vegetation_quality", "high" },
            { "anisotropic_level", 16 },
            { "antialiasing", 8 },
            { "depth_shadows", 2 },
            { "depth_shadows_resolution", 3 },
            { "gamma", 122 },
            { "grass_distance", 500 },
            { "ground_buffers_per_node", 4 },
            { "ground_cover_buffers_per_node", 4 },
            { "model_buffers_per_node", 4 },
            { "shader", 2 },
            { "sprite_buffers_per_node", 4 },
            { "texture_filtering", 2 },
            { "water_buffers_per_node", 4 },
            { "battle_resolution", new uint[] { 1600, 900 } },
            { "campaign_resolution", new uint[] { 1600, 900 } },
        };

        return settings;
    }

    private static M2TWGameCfgSection GetHotseatSubSet()
    {
        string subsetName = "hotseat";

        var subsetOptions = new List<M2TWGameCfgOption>();

        subsetOptions.Add(new M2TWGameCfgOption("scroll", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("turns", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("disable_console", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("admin_password", "qwerty", subsetName)); // resolve password !!!
        subsetOptions.Add(new M2TWGameCfgOption("update_ai_camera", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("disable_papal_elections", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("autoresolve_battles", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("validate_diplomacy", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("save_prefs", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("autosave", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("save_config", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("close_after_save", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("gamename", "hotseat_gamename", subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("validate_data", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("allow_validation_failures", false, subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static M2TWGameCfgSection GetMultiplayerSubSet()
    {
        string subsetName = "multiplayer";

        var subsetOptions = new List<M2TWGameCfgOption>();

        subsetOptions.Add(new M2TWGameCfgOption("playable", true, subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
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

    private static M2TWGameCfgSection GetUISubSet()
    {
        string subsetName = "ui";

        var subsetOptions = new List<M2TWGameCfgOption>();

        subsetOptions.Add(new M2TWGameCfgOption("full_battle_HUD", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("show_tooltips", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("buttons", "slide", subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("radar", "slide", subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("unit_cards", "slide", subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("SA_cards", "slide", subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static M2TWGameCfgSection GetMiscSubSet()
    {
        string subsetName = "misc";

        var subsetOptions = new List<M2TWGameCfgOption>();

        subsetOptions.Add(new M2TWGameCfgOption("show_hud_date", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("bypass_sprite_script", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("bypass_to_strategy_save", "game_name.sav", subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static M2TWGameCfgSection GenerateOptsSubSet(string subsetName, Dictionary<string, object> settings)
    {
        var subsetOptions = new List<M2TWGameCfgOption>();

        foreach (var setting in settings)
        {
            subsetOptions.Add(new M2TWGameCfgOption(setting.Key, setting.Value, subsetName));
        }

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }
}
