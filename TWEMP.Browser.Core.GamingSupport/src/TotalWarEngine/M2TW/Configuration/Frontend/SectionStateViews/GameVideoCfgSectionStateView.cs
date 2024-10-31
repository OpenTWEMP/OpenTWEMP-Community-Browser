// <copyright file="GameVideoCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;

public record GameVideoCfgSectionStateView : ICustomConfigState
{
    private const string VideoConfigSwitch = "video";

    public const string VideoAnisotropicLevelTextId = "anisotropic_level";
    public const string VideoAntiAliasModeTextId = "anti_alias_mode";
    public const string VideoAntialiasingTextId = "antialiasing";
    public const string VideoAssassinationMoviesTextId = "assassination_movies";
    public const string VideoAutodetectTextId = "autodetect";
    public const string VideoBattleResolutionTextId = "battle_resolution";
    public const string VideoBloomTextId = "bloom";
    public const string VideoBuildingDetailTextId = "building_detail";
    public const string VideoCampaignResolutionTextId = "campaign_resolution";
    public const string VideoDepthShadowsTextId = "depth_shadows";
    public const string VideoDepthShadowsResolutionTextId = "depth_shadows_resolution";
    public const string VideoEffectQualityTextId = "effect_quality";
    public const string VideoEventMoviesTextId = "event_movies";
    public const string VideoGammaTextId = "gamma";
    public const string VideoGrassDistanceTextId = "grass_distance";
    public const string VideoGroundBuffersPerNodeTextId = "ground_buffers_per_node";
    public const string VideoGroundCoverBuffersPerNodeTextId = "ground_cover_buffers_per_node";
    public const string VideoInfiltrationMoviesTextId = "infiltration_movies";
    public const string VideoModelBuffersPerNodeTextId = "model_buffers_per_node";
    public const string VideoNoBackgroundFmvTextId = "no_background_fmv";
    public const string VideoReflectionTextId = "reflection";
    public const string VideoSabotageMoviesTextId = "sabotage_movies";
    public const string VideoShaderTextId = "shader";
    public const string VideoShowBannersTextId = "show_banners";
    public const string VideoShowPackageLitterTextId = "show_package_litter";
    public const string VideoSkipMipLevelsTextId = "skip_mip_levels";
    public const string VideoSplashesTextId = "splashes";
    public const string VideoSpriteBuffersPerNodeTextId = "sprite_buffers_per_node";
    public const string VideoStencilShadowsTextId = "stencil_shadows";
    public const string VideoSubtitlesTextId = "subtitles";
    public const string VideoTerrainQualityTextId = "terrain_quality";
    public const string VideoTextureFilteringTextId = "texture_filtering";
    public const string VideoUnitDetailTextId = "unit_detail";
    public const string VideoVegetationTextId = "vegetation";
    public const string VideoVegetationQualityTextId = "vegetation_quality";
    public const string VideoVsyncTextId = "vsync";
    public const string VideoWaterBuffersPerNodeTextId = "water_buffers_per_node";
    public const string VideoWidescreenModeTextId = "widescreen";
    public const string VideoWindowedModeTextId = "windowed";
    public const string VideoMoviesTextId = "movies";
    public const string VideoBorderlessWindowTextId = "borderless_window";

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

    public M2TW_QualityLevel? VideoTerrainQuality { get; set; } // "terrain_quality" | 'custom' ???

    public M2TW_Integer? VideoTextureFiltering { get; set; } // "texture_filtering" | ???

    public M2TW_QualityLevel? VideoUnitDetail { get; set; } // "unit_detail"

    public M2TW_Boolean? VideoVegetation { get; set; } // "vegetation" | ???

    public M2TW_QualityLevel? VideoVegetationQuality { get; set; } // "vegetation_quality"

    public M2TW_Boolean? VideoVsync { get; set; } // "vsync"

    public M2TW_Integer? VideoWaterBuffersPerNode { get; set; } // "water_buffers_per_node" | ???

    public M2TW_Boolean? VideoWidescreenMode { get; set; } // "widescreen"

    public M2TW_Boolean? VideoWindowedMode { get; set; } // "windowed"

    public M2TW_Boolean? VideoMovies { get; set; } // "movies"

    public M2TW_Boolean? VideoBorderlessWindow { get; set; } // "borderless_window"

    public static GameVideoCfgSectionStateView CreateByDefault()
    {
        return new GameVideoCfgSectionStateView
        {
            VideoAnisotropicLevel = new M2TW_QualityLevel(M2TW_AnisotropicFilteringLevel.AF_x16),
            VideoAntiAliasMode = new M2TW_QualityLevel(M2TW_AntiAliasMode.AntiAliasMode_x4),
            VideoAntialiasing = new M2TW_QualityLevel(M2TW_AntiAliasing.AntiAliasMode_x4),
            VideoAssassinationMovies = new M2TW_Boolean(false),
            VideoAutodetect = new M2TW_Boolean(false),
            VideoBattleResolution = new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1024x768),
            VideoCampaignResolution = new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1024x768),
            VideoBloom = new M2TW_Boolean(true),
            VideoBuildingDetail = new M2TW_QualityLevel(M2TW_Quality.High),
            VideoDepthShadows = new M2TW_Integer(2),
            VideoDepthShadowsResolution = new M2TW_Integer(3),
            VideoEffectQuality = new M2TW_QualityLevel(M2TW_Quality.Highest),
            VideoEventMovies = new M2TW_Boolean(true),
            VideoGamma = new M2TW_Integer(120),
            VideoGrassDistance = new M2TW_QualityLevel(M2TW_GrassDistance.Level_1),
            VideoGroundBuffersPerNode = new M2TW_Integer(4),
            VideoGroundCoverBuffersPerNode = new M2TW_Integer(4),
            VideoInfiltrationMovies = new M2TW_Boolean(false),
            VideoModelBuffersPerNode = new M2TW_Integer(4),
            VideoNoBackgroundFmv = new M2TW_Boolean(true),
            VideoReflection = new M2TW_Boolean(true),
            VideoSabotageMovies = new M2TW_Boolean(false),
            VideoShader = new M2TW_QualityLevel(M2TW_ShaderLevel.ShaderVersion_v2),
            VideoShowBanners = new M2TW_Boolean(false),
            VideoShowPackageLitter = new M2TW_Boolean(true),
            VideoSkipMipLevels = new M2TW_Boolean(false),
            VideoSplashes = new M2TW_Boolean(true),
            VideoSpriteBuffersPerNode = new M2TW_Integer(4),
            VideoStencilShadows = new M2TW_Boolean(true),
            VideoSubtitles = new M2TW_Boolean(false),
            VideoTerrainQuality = new M2TW_QualityLevel(M2TW_Quality.High),
            VideoTextureFiltering = new M2TW_Integer(2),
            VideoUnitDetail = new M2TW_QualityLevel(M2TW_Quality.Highest),
            VideoVegetation = new M2TW_Boolean(false),
            VideoVegetationQuality = new M2TW_QualityLevel(M2TW_Quality.High),
            VideoVsync = new M2TW_Boolean(false),
            VideoWaterBuffersPerNode = new M2TW_Integer(4),
            VideoWidescreenMode = new M2TW_Boolean(true),
            VideoWindowedMode = new M2TW_Boolean(false),
            VideoMovies = new M2TW_Boolean(true),
            VideoBorderlessWindow = new M2TW_Boolean(false),
        };
    }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        M2TWGameCfgOption[] videoCfgOptions =
        {
            new (name: VideoAnisotropicLevelTextId, value: this.VideoAnisotropicLevel!.Value, section: VideoConfigSwitch),
            new (name: VideoAntiAliasModeTextId, value: this.VideoAntiAliasMode!.Value, section: VideoConfigSwitch),
            new (name: VideoAntialiasingTextId, value: this.VideoAntialiasing!.Value, section: VideoConfigSwitch),
            new (name: VideoAssassinationMoviesTextId, value: this.VideoAssassinationMovies!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoAutodetectTextId, value: this.VideoAutodetect!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoBattleResolutionTextId, value: this.VideoBattleResolution!.Value, section: VideoConfigSwitch),
            new (name: VideoBloomTextId, value: this.VideoBloom!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoBuildingDetailTextId, value: this.VideoBuildingDetail!.Value, section: VideoConfigSwitch),
            new (name: VideoCampaignResolutionTextId, value: this.VideoCampaignResolution!.Value, section: VideoConfigSwitch),
            new (name: VideoDepthShadowsTextId, value: this.VideoDepthShadows!.Value, section: VideoConfigSwitch),
            new (name: VideoDepthShadowsResolutionTextId, value: this.VideoDepthShadowsResolution!.Value, section: VideoConfigSwitch),
            new (name: VideoEffectQualityTextId, value: this.VideoEffectQuality!.Value, section: VideoConfigSwitch),
            new (name: VideoEventMoviesTextId, value: this.VideoEventMovies!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoGammaTextId, value: this.VideoGamma!.Value, section: VideoConfigSwitch),
            new (name: VideoGrassDistanceTextId, value: this.VideoGrassDistance!.Value, section: VideoConfigSwitch),
            new (name: VideoGroundBuffersPerNodeTextId, value: this.VideoGroundBuffersPerNode!.Value, section: VideoConfigSwitch),
            new (name: VideoGroundCoverBuffersPerNodeTextId, value: this.VideoGroundCoverBuffersPerNode!.Value, section: VideoConfigSwitch),
            new (name: VideoInfiltrationMoviesTextId, value: this.VideoInfiltrationMovies!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoModelBuffersPerNodeTextId, value: this.VideoModelBuffersPerNode!.Value, section: VideoConfigSwitch),
            new (name: VideoNoBackgroundFmvTextId, value: this.VideoNoBackgroundFmv!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoReflectionTextId, value: this.VideoReflection!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoSabotageMoviesTextId, value: this.VideoSabotageMovies!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoShaderTextId, value: this.VideoShader!.Value, section: VideoConfigSwitch),
            new (name: VideoShowBannersTextId, value: this.VideoShowBanners!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoShowPackageLitterTextId, value: this.VideoShowPackageLitter!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoSkipMipLevelsTextId, value: this.VideoSkipMipLevels!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoSplashesTextId, value: this.VideoSplashes!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoSpriteBuffersPerNodeTextId, value: this.VideoSpriteBuffersPerNode!.Value, section: VideoConfigSwitch),
            new (name: VideoStencilShadowsTextId, value: this.VideoStencilShadows!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoSubtitlesTextId, value: this.VideoSubtitles!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoTerrainQualityTextId, value: this.VideoTerrainQuality!.Value, section: VideoConfigSwitch),
            new (name: VideoTextureFilteringTextId, value: this.VideoTextureFiltering!.Value, section: VideoConfigSwitch),
            new (name: VideoUnitDetailTextId, value: this.VideoUnitDetail!.Value, section: VideoConfigSwitch),
            new (name: VideoVegetationTextId, value: this.VideoVegetation!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoVegetationQualityTextId, value: this.VideoVegetationQuality!.Value, section: VideoConfigSwitch),
            new (name: VideoVsyncTextId, value: this.VideoVsync!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoWaterBuffersPerNodeTextId, value: this.VideoWaterBuffersPerNode!.Value, section: VideoConfigSwitch),
            new (name: VideoWidescreenModeTextId, value: this.VideoWidescreenMode!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoWindowedModeTextId, value: this.VideoWindowedMode!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoMoviesTextId, value: this.VideoMovies!.BooleanValue, section: VideoConfigSwitch),
            new (name: VideoBorderlessWindowTextId, value: this.VideoBorderlessWindow!.BooleanValue, section: VideoConfigSwitch),
        };

        GameCfgSection videoCfgSection = new M2TWGameCfgSection(VideoConfigSwitch, videoCfgOptions);
        return new GameCfgSection[] { videoCfgSection };
    }
}
