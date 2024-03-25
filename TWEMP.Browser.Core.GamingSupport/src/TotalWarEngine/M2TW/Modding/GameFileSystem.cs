// <copyright file="GameFileSystem.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Modding;

public class GameFileSystem
{
    public const string ModDataFolderName = "data";

    public const string ModSavesFolderName = "saves";

    public const string ModLogsFolderName = "logs";

    public const string DataTextFolderName = "text";

    public const string DataLoadingScreenFolderName = "loading_screen";

    public const string DataUiFolderName = "ui";

    public const string DataFmvFolderName = "fmv";

    public const string DataSoundsFolderName = "sounds";

    public const string DataUnitModelsFolderName = "unit_models";

    public const string DataUnitSpritesFolderName = "unit_sprites";

    public const string DataAnimationsFolderName = "animations";

    public const string DataBannersFolderName = "banners";

    public const string DataModelsStratFolderName = "models_strat";

    public const string WorldMapsBaseFolderName = "world\\maps\\base";

    public const string WorldMapsCampaignFolderName = "world\\maps\\campaign\\imperial_campaign";

    public const string GAME_EXECUTABLE_BASENAME_CLASSIC1 = "medieval2";
    public const string GAME_EXECUTABLE_BASENAME_CLASSIC2 = "kingdoms";
    public const string GAME_EXECUTABLE_BASENAME_STEAM = "medieval2";

    public const string MOD_ROOT = "data";

    public const string MOD_NODE1_MENU = "menu";
    public const string MENU_IMAGE_LOGO = "splash.tga";

    public const string M2TWK_FOLDERNAME_MOD1 = "americas";
    public const string M2TWK_FOLDERNAME_MOD2 = "british_isles";
    public const string M2TWK_FOLDERNAME_MOD3 = "crusades";
    public const string M2TWK_FOLDERNAME_MOD4 = "teutonic";

    public const string MOD_NODE1_ANIMATIONS = "animations";
    public const string ANIMATIONS_DAT_PACK = "pack.dat";
    public const string ANIMATIONS_DAT_SKELETONS = "skeletons.dat";
    public const string ANIMATIONS_IDX_PACK = "pack.idx";
    public const string ANIMATIONS_IDX_SKELETONS = "skeletons.idx";

    public const string MOD_NODE1_SOUNDS = "sounds";
    public const string SOUNDS_IDX_EVENTS = "events.idx";
    public const string SOUNDS_IDX_MUSIC = "Music.idx";
    public const string SOUNDS_IDX_SFX = "SFX.idx";
    public const string SOUNDS_IDX_VOICE = "Voice.idx";
    public const string SOUNDS_DAT_EVENTS = "events.dat";
    public const string SOUNDS_DAT_MUSIC = "Music.dat";
    public const string SOUNDS_DAT_SFX = "SFX.dat";
    public const string SOUNDS_DAT_VOICE = "Voice.dat";

    public const string MOD_NODE1_WORLD = "world";
    public const string MOD_NODE2_MAPS = "maps";

    public const string MOD_NODE3_MAPS_BASE = "base";
    public const string WORLD_MAPS_BASE_MAP_CLIMATES = "map_climates.tga";
    public const string WORLD_MAPS_BASE_MAP_FE = "map_FE.tga";
    public const string WORLD_MAPS_BASE_MAP_FEATURES = "map_features.tga";
    public const string WORLD_MAPS_BASE_MAP_FOG = "map_fog.tga";
    public const string WORLD_MAPS_BASE_MAP_GROUNDTYPES = "map_ground_types.tga";
    public const string WORLD_MAPS_BASE_MAP_HEIGHTS = "map_heights.tga";
    public const string WORLD_MAPS_BASE_MAP_REGIONS = "map_regions.tga";
    public const string WORLD_MAPS_BASE_MAP_ROUGHNESS = "map_roughness.tga";
    public const string WORLD_MAPS_BASE_MAP_TRADEROUTES = "map_trade_routes.tga";
    public const string WORLD_MAPS_BASE_MAP_WATERSURFACES = "water_surface.tga";
    public const string WORLD_MAPS_BASE_DESCR_REGIONS = "descr_regions.txt";
    public const string WORLD_MAPS_BASE_DESCR_SOUNDMUSICTYPES = "descr_sounds_music_types.txt";

    public const string MOD_NODE3_MAPS_CAMPAIGN = "campaign";
    public const string MOD_NODE4_MAPS_IMPERIALCAMPAIGN = "imperial_campaign";
    public const string WORLD_MAPS_CAMPAIGN_DESCR_STRAT = "descr_strat.txt";
    public const string WORLD_MAPS_CAMPAIGN_DESCR_WINCONDITIONS = "descr_win_conditions.txt";
    public const string WORLD_MAPS_CAMPAIGN_SCRIPT = "campaign_script.txt";
}
