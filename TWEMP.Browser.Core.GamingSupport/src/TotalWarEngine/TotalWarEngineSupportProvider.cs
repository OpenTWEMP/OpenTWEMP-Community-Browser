// <copyright file="TotalWarEngineSupportProvider.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

#define DEEP_M2TW_COMPATIBILITY_ANALYSIS
#undef DEEP_M2TW_COMPATIBILITY_ANALYSIS

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine;

using System.IO;

public static class TotalWarEngineSupportProvider
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

    public static bool IsCompatibleModification(string modHomeDirectoryPath)
    {
        // 1. Check mod's 'data' root folder.
        string modRootPath = Path.Combine(modHomeDirectoryPath, MOD_ROOT);

        if (!Directory.Exists(modRootPath))
        {
            return false;
        }

#if DEEP_M2TW_COMPATIBILITY_ANALYSIS
        // 2. Check mod's 'data/world/maps/campaign/imperial_campaign' folder.

        string modCampaignNodePath = Path.Combine(modRootPath, MOD_NODE1_WORLD, MOD_NODE2_MAPS, MOD_NODE3_MAPS_CAMPAIGN, MOD_NODE4_MAPS_IMPERIALCAMPAIGN);

        if (!Directory.Exists(modCampaignNodePath))
        {
            return false;
        }
        else
        {
            if (!File.Exists(Path.Combine(modCampaignNodePath, WORLD_MAPS_CAMPAIGN_DESCR_STRAT)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modCampaignNodePath, WORLD_MAPS_CAMPAIGN_DESCR_WINCONDITIONS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modCampaignNodePath, WORLD_MAPS_CAMPAIGN_SCRIPT)))
            {
                return false;
            }
        }


        // 3. Check mod's 'data/world/maps/base' folder.

        string modBaseNodePath = Path.Combine(modRootPath, MOD_NODE1_WORLD, MOD_NODE2_MAPS, MOD_NODE3_MAPS_BASE);

        if (!Directory.Exists(modBaseNodePath))
        {
            return false;
        }
        else
        {
            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_DESCR_REGIONS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_DESCR_SOUNDMUSICTYPES)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_CLIMATES)))
            {
                return false;
            }


            // This file might be named either "map_FE.tga" or "map_fe.tga" in different mods.
            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_FE)) && 
                    !File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_FE.ToLower())))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_FEATURES)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_FOG)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_GROUNDTYPES)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_HEIGHTS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_REGIONS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_ROUGHNESS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_TRADEROUTES)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, WORLD_MAPS_BASE_MAP_WATERSURFACES)))
            {
                return false;
            }

        }


        // 4. Check mod's 'data/sounds' folder.

        string modSoundsNodePath = Path.Combine(modRootPath, MOD_NODE1_SOUNDS);

        if (!Directory.Exists(modSoundsNodePath))
        {
            return false;
        }
        else
        {
            if (!File.Exists(Path.Combine(modSoundsNodePath, SOUNDS_DAT_EVENTS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, SOUNDS_DAT_MUSIC)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, SOUNDS_DAT_SFX)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, SOUNDS_DAT_VOICE)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, SOUNDS_IDX_EVENTS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, SOUNDS_IDX_MUSIC)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, SOUNDS_IDX_SFX)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, SOUNDS_IDX_VOICE)))
            {
                return false;
            }
        }

        // 5. Check mod's 'data/animations' folder.

        string modAnimationsNodePath = Path.Combine(modRootPath, MOD_NODE1_ANIMATIONS);

        if (!Directory.Exists(modAnimationsNodePath))
        {
            return false;
        }
        else
        {
            if (!File.Exists(Path.Combine(modAnimationsNodePath, ANIMATIONS_DAT_PACK)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modAnimationsNodePath, ANIMATIONS_DAT_SKELETONS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modAnimationsNodePath, ANIMATIONS_IDX_PACK)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modAnimationsNodePath, ANIMATIONS_IDX_SKELETONS)))
            {
                return false;
            }
        }
#endif

        return true;
    }
}
