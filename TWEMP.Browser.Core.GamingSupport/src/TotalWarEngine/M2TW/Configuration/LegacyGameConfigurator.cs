// <copyright file="LegacyGameConfigurator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

#define NON_IMPLEMENTED_SETTINGS
#undef NON_IMPLEMENTED_SETTINGS

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

/// <summary>
/// Implements the game configurator agent for the "Medieval 2 Total War" game engine (M2TW).
/// </summary>
public class LegacyGameConfigurator : IGameConfiguratorAgent
{
    private readonly GameModificationInfo gameModificationInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="LegacyGameConfigurator"/> class.
    /// </summary>
    /// <param name="info">Information about a target game modification.</param>
    public LegacyGameConfigurator(GameModificationInfo info)
    {
        this.gameModificationInfo = info;
    }

    /// <summary>
    /// Gets M2TW configuration settings by default.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetDefaultConfigSettings()
    {
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing M2TW config settings!
    }

    /// <summary>
    /// Gets M2TW configuration settings via a custom configuration state.
    /// </summary>
    /// <param name="state">A target custom game configuration state.</param>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetCustomConfigSettings(ICustomConfigState state)
    {
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing M2TW config settings!
    }

    public List<CfgOptionsSubSet> InitializeMinimalModSettings(CustomConfigState cfg)
    {
        List<CfgOptionsSubSet> settings = new ();

        CfgOptionsSubSet features_subset = GetFeaturesSubSet(this.gameModificationInfo); // [features]
        settings.Add(features_subset);

        CfgOptionsSubSet io_subset = GetIOSubSet(); // [io]
        settings.Add(io_subset);

        CfgOptionsSubSet log_subset = GetLogSubSet(this.gameModificationInfo, cfg); // [log]
        settings.Add(log_subset);

        CfgOptionsSubSet video_subset = GetVideoSubSet(cfg); // [video]
        settings.Add(video_subset);

        CfgOptionsSubSet hotseat_subset = GetHotseatSubSet(); // [hotseat]
        settings.Add(hotseat_subset);

        CfgOptionsSubSet multiplayer_subset = GetMultiplayerSubSet(); // [multiplayer]
        settings.Add(multiplayer_subset);

        CfgOptionsSubSet game_subset = GetGameSubSet(); // [game]
        settings.Add(game_subset);

        CfgOptionsSubSet ui_subset = GetUISubSet(); // [ui]
        settings.Add(ui_subset);

        CfgOptionsSubSet misc_subset = GetMiscSubSet(); // [misc]
        settings.Add(misc_subset);

        return settings;
    }

    private static CfgOptionsSubSet GetFeaturesSubSet(GameModificationInfo mod)
    {
        string subsetName = "features";

        var subsetOptions = new List<CfgOption>();

        subsetOptions.Add(new CfgOption("editor", true));
        subsetOptions.Add(new CfgOption("mod", mod.ModCfgRelativePath));

        return new CfgOptionsSubSet(subsetName, subsetOptions);
    }

    private static CfgOptionsSubSet GetIOSubSet()
    {
        string subsetName = "io";

        var subsetOptions = new List<CfgOption>();
        subsetOptions.Add(new CfgOption("file_first", true));

        return new CfgOptionsSubSet(subsetName, subsetOptions);
    }

    private static CfgOptionsSubSet GetLogSubSet(GameModificationInfo mod, CustomConfigState cfg)
    {
        string subsetName = "log";

        var subsetOptions = new List<CfgOption>();
        subsetOptions.Add(new CfgOption("to", mod.LogFileRelativePath));
        subsetOptions.Add(new CfgOption("level", SetLogLevel(cfg)));

        return new CfgOptionsSubSet(subsetName, subsetOptions);
    }

    private static string SetLogLevel(CustomConfigState cfg)
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

    private static CfgOptionsSubSet GetVideoSubSet(CustomConfigState cfg)
    {
        string subsetName = "video";
        var subsetOptions = new List<CfgOption>();
        subsetOptions.Add(new CfgOption("windowed", cfg.IsEnabledWindowedMode));
        subsetOptions.Add(new CfgOption("movies", cfg.ValidatorVideo));
        subsetOptions.Add(new CfgOption("borderless_window", cfg.ValidatorBorderless));

        return new CfgOptionsSubSet(subsetName, subsetOptions);
    }

#if NON_IMPLEMENTED_SETTINGS
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
#endif

    private static CfgOptionsSubSet GetHotseatSubSet()
    {
        return new CfgOptionsSubSet("hotseat", new List<CfgOption>());

#if NON_IMPLEMENTED_SETTINGS
        string subsetName = "hotseat";
        var subsetOptions = new List<CfgOption>();
        subsetOptions.Add(new CfgOption("scroll", false));
        subsetOptions.Add(new CfgOption("turns", false));
        subsetOptions.Add(new CfgOption("disable_console", false));
        subsetOptions.Add(new CfgOption("admin_password", "qwerty")); // resolve password !!!
        subsetOptions.Add(new CfgOption("update_ai_camera", true));
        subsetOptions.Add(new CfgOption("disable_papal_elections", false));
        subsetOptions.Add(new CfgOption("autoresolve_battles", false));
        subsetOptions.Add(new CfgOption("validate_diplomacy", false));
        subsetOptions.Add(new CfgOption("save_prefs", true));
        subsetOptions.Add(new CfgOption("autosave", true));
        subsetOptions.Add(new CfgOption("save_config", true));
        subsetOptions.Add(new CfgOption("close_after_save", true));
        subsetOptions.Add(new CfgOption("gamename", "hotseat_gamename"));
        subsetOptions.Add(new CfgOption("validate_data", true));
        subsetOptions.Add(new CfgOption("allow_validation_failures", false));
        return new CfgOptionsSubSet(subsetName, subsetOptions);
#endif
    }

    private static CfgOptionsSubSet GetMultiplayerSubSet()
    {
        return new CfgOptionsSubSet("multiplayer", new List<CfgOption>());

#if NON_IMPLEMENTED_SETTINGS
        string subsetName = "multiplayer";
        var subsetOptions = new List<CfgOption>();
        subsetOptions.Add(new CfgOption("playable", true));
        return new CfgOptionsSubSet(subsetName, subsetOptions);
#endif
    }

    private static CfgOptionsSubSet GetGameSubSet()
    {
        return new CfgOptionsSubSet("game", new List<CfgOption>());

#if NON_IMPLEMENTED_SETTINGS
        string subsetName = "game";
        var subsetOptions = new List<CfgOption>();
        subsetOptions.Add(new CfgOption("unlimited_men_on_battlefield", true));
        subsetOptions.Add(new CfgOption("unit_size", "huge"));
        subsetOptions.Add(new CfgOption("no_campaign_battle_time_limit", false));
        subsetOptions.Add(new CfgOption("advisor_verbosity", false));
        subsetOptions.Add(new CfgOption("event_cutscenes", false));
        return new CfgOptionsSubSet(subsetName, subsetOptions);
#endif
    }

#if NON_IMPLEMENTED_SETTINGS
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
#endif

    private static CfgOptionsSubSet GetUISubSet()
    {
        return new CfgOptionsSubSet("ui", new List<CfgOption>());

#if NON_IMPLEMENTED_SETTINGS
        string subsetName = "ui";
        Dictionary<string, object> settings = GenerateDefaultUISettings();
        return GenerateOptsSubSet(subsetName, settings);
#endif
    }

#if NON_IMPLEMENTED_SETTINGS
    private static Dictionary<string, object> GenerateDefaultUISettings()
    {
        return new Dictionary<string, object>
        {
            { "full_battle_HUD", true },
            { "show_tooltips", true },
            { "buttons", "slide" },
            { "radar", "slide" },
            { "unit_cards", "slide" },
            { "SA_cards", "slide" },
        };
    }
#endif

    private static CfgOptionsSubSet GetMiscSubSet()
    {
        return new CfgOptionsSubSet("misc", new List<CfgOption>());

#if NON_IMPLEMENTED_SETTINGS
        string subsetName = "misc";
        var subsetOptions = new List<CfgOption>();
        subsetOptions.Add(new CfgOption("show_hud_date", true));
        subsetOptions.Add(new CfgOption("bypass_sprite_script", true));
        subsetOptions.Add(new CfgOption("bypass_to_strategy_save", "game_name.sav"));
        return new CfgOptionsSubSet(subsetName, subsetOptions);
#endif
    }
}
