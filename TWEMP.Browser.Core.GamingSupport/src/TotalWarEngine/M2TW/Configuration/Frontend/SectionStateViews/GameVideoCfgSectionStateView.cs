// <copyright file="GameVideoCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using ICustomConfigState = AbstractPlaceholders.ICustomConfigState;

public record GameVideoCfgSectionStateView : ICustomConfigState
{
    public GameVideoCfgSectionStateView()
    {
    }

    public M2TW_QualityLevel? VideoAnisotropicLevel { get; set; } // "anisotropic_level"

    public M2TW_QualityLevel? VideoAntiAliasMode { get; set; } // "anti_alias_mode"

    public M2TW_QualityLevel? VideoAntialiasing { get; set; } // "antialiasing"

    public M2TW_Boolean? VideoAssassinationMovies { get; set; } // "assassination_movies"

    public M2TW_Boolean? VideoAutodetect { get; set; } // "autodetect"

    public M2TW_DisplayResolution? VideoBattleResolution { get; set; } // "battle_resolution"

    public M2TW_DisplayResolution? VideoCampaignResolution { get; set; } // "campaign_resolution"

    public M2TW_Boolean? VideoBloom { get; set; } // "bloom"

    public M2TW_QualityLevel? VideoBuildingDetail { get; set; } // "building_detail"

    public M2TW_Integer? VideoDepthShadows { get; set; } // "depth_shadows" | ???

    public M2TW_Integer? VideoDepthShadowsResolution { get; set; } // "depth_shadows_resolution" | ???

    public M2TW_QualityLevel? VideoEffectQuality { get; set; } // "effect_quality"

    public M2TW_Boolean? VideoEventMovies { get; set; } // "event_movies"

    public M2TW_Integer? VideoGamma { get; set; } // "gamma" | ???

    public M2TW_QualityLevel? VideoGrassDistance { get; set; } // "grass_distance"

    public M2TW_Integer? VideoGroundBuffersPerNode { get; set; } // "ground_buffers_per_node" | ???

    public M2TW_Integer? VideoGroundCoverBuffersPerNode { get; set; } // "ground_cover_buffers_per_node" | ???

    public M2TW_Boolean? VideoInfiltrationMovies { get; set; } // "infiltration_movies"

    public M2TW_Boolean? VideoMovies { get; set; } // "movies"

    public M2TW_Integer? VideoModelBuffersPerNode { get; set; } // "model_buffers_per_node" | ???

    public M2TW_Boolean? VideoNoBackgroundFmv { get; set; } // "no_background_fmv"

    public M2TW_Boolean? VideoReflection { get; set; } // "reflection"

    public M2TW_Boolean? VideoSabotageMovies { get; set; } // "sabotage_movies"

    public M2TW_QualityLevel? VideoShader { get; set; } // "shader"

    public M2TW_Boolean? VideoShowBanners { get; set; } // "show_banners"

    public M2TW_Boolean? VideoShowPackageLitter { get; set; } // "show_package_litter"

    public M2TW_Boolean? VideoSkipMipLevels { get; set; } // "skip_mip_levels" | ???

    public M2TW_Boolean? VideoSplashes { get; set; } // "splashes"

    public M2TW_Integer? VideoSpriteBuffersPerNode { get; set; } // "sprite_buffers_per_node" | ???

    public M2TW_Boolean? VideoStencilShadows { get; set; } // "stencil_shadows"

    public M2TW_Boolean? VideoSubtitles { get; set; } // "subtitles"

    public string? VideoTerrainQuality { get; set; } // "terrain_quality" | 'custom' ???

    public M2TW_Integer? VideoTextureFiltering { get; set; } // "texture_filtering" | ???

    public M2TW_QualityLevel? VideoUnitDetail { get; set; } // "unit_detail"

    public M2TW_Boolean? VideoVegetation { get; set; } // "vegetation" | ???

    public M2TW_QualityLevel? VideoVegetationQuality { get; set; } // "vegetation_quality"

    public M2TW_Boolean? VideoVsync { get; set; } // "vsync"

    public M2TW_Integer? VideoWaterBuffersPerNode { get; set; } // "water_buffers_per_node" | ???

    public M2TW_Boolean? VideoWidescreen { get; set; } // "widescreen"

    public M2TW_Boolean? VideoWindowed { get; set; } // "windowed"

    public M2TW_Boolean? IsEnabledFullScreenMode { get; set; }

    public M2TW_Boolean? IsEnabledWindowedMode { get; set; }

    public M2TW_Boolean? ValidatorVideo { get; set; }

    public M2TW_Boolean? ValidatorBorderless { get; set; }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }

    private static M2TWGameCfgSection GetVideoSubSet(M2TWGameConfigStateView cfg)
    {
        string subsetName = "video";
        var subsetOptions = new List<M2TWGameCfgOption>();
        subsetOptions.Add(new M2TWGameCfgOption("windowed", cfg.GameVideoCfgSection!.IsEnabledWindowedMode!, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("movies", cfg.GameVideoCfgSection!.ValidatorVideo!, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("borderless_window", cfg.GameVideoCfgSection!.ValidatorBorderless!, subsetName));

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
}
