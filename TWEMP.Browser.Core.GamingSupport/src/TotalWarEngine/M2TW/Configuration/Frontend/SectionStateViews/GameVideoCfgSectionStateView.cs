// <copyright file="GameVideoCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

public record GameVideoCfgSectionStateView : ICustomConfigState
{
    /*
        // Possible values: 'bilinear', 'trilinear', '2', '4', '8', '16'
        public <M2TW_TYPE> VideoAnisotropicLevel { get; set; } // "anisotropic_level"
    */

    /*
        // Possible values: 'off', '2', '4'
        public <M2TW_TYPE> VideoAntiAliasMode { get; set; } // "anti_alias_mode"
    */

    /*
        // Possible values: '0', '2', '4'
        // public <M2TW_TYPE> VideoAntialiasing { get; set; } // "antialiasing"
    */

    public bool VideoAssassinationMovies { get; set; } // "assassination_movies"

    public bool VideoAutodetect { get; set; } // "autodetect"

    /*
        // For example: 1440 900
        public <M2TW_TYPE> VideoBattleResolution { get; set; } // "battle_resolution"
    */

    public bool VideoBloom { get; set; } // "bloom"

    /*
        // Possible values: 'low', 'medium', 'high', 'highest'
        public <M2TW_TYPE> VideoBuildingDetail { get; set; } // "building_detail"
    */

    /*
        // For example: 1440 900
        public <M2TW_TYPE> VideoCampaignResolution { get; set; } // "campaign_resolution"
    */

    public byte VideoDepthShadows { get; set; } // "depth_shadows" | ???

    public byte VideoDepthShadowsResolution { get; set; } // "depth_shadows_resolution" | ???

    /*
        // Possible values: 'low', 'medium', 'high', 'highest'
        public <M2TW_TYPE> VideoEffectQuality { get; set; } // "effect_quality"
    */

    public bool VideoEventMovies { get; set; } // "event_movies"

    public byte VideoGamma { get; set; } // "gamma" | ???

    /*
        // Possible values: '0', '25', '50', '75'
        public <M2TW_TYPE> VideoGrassDistance { get; set; } // "grass_distance"
    */

    public byte VideoGroundBuffersPerNode { get; set; } // "ground_buffers_per_node" | ???

    public byte VideoGroundCoverBuffersPerNode { get; set; } // "ground_cover_buffers_per_node" | ???

    public bool VideoInfiltrationMovies { get; set; } // "infiltration_movies"

    public bool VideoMovies { get; set; } // "movies"

    public byte VideoModelBuffersPerNode { get; set; } // "model_buffers_per_node" | ???

    public bool VideoNoBackgroundFmv { get; set; } // "no_background_fmv"

    public bool VideoReflection { get; set; } // "reflection"

    public bool VideoSabotageMovies { get; set; } // "sabotage_movies"

    /*
        // Possible values: '1' or '2'
        public <M2TW_TYPE> VideoShader { get; set; } // "shader"
    */

    public bool VideoShowBanners { get; set; } // "show_banners"

    public bool VideoShowPackageLitter { get; set; } // "show_package_litter"

    public bool VideoSkipMipLevels { get; set; } // "skip_mip_levels" | ???

    public bool VideoSplashes { get; set; } // "splashes"

    public byte VideoSpriteBuffersPerNode { get; set; } // "sprite_buffers_per_node" | ???

    public bool VideoStencilShadows { get; set; } // "stencil_shadows"

    public bool VideoSubtitles { get; set; } // "subtitles"

    public string? VideoTerrainQuality { get; set; } // "terrain_quality" | 'custom' ???

    public byte VideoTextureFiltering { get; set; } // "texture_filtering" | ???

    /*
        // Possible values: 'low', 'medium', 'high', 'highest'
        public <M2TW_TYPE> VideoUnitDetail { get; set; } // "unit_detail"
    */

    public bool VideoVegetation { get; set; } // "vegetation" | ???

    /*
        // Possible values: 'low', 'medium', 'high', 'highest'
        public <M2TW_TYPE> VideoVegetationQuality { get; set; } // "vegetation_quality"
    */

    public bool VideoVsync { get; set; } // "vsync"

    public byte VideoWaterBuffersPerNode { get; set; } // "water_buffers_per_node" | ???

    public bool VideoWidescreen { get; set; } // "widescreen"

    public bool VideoWindowed { get; set; } // "windowed"

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }
}
