// <copyright file="M2TWGameValidator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Validator;

using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Modding;

public static class M2TWGameValidator
{
    public static bool IsCompatibleModification(string modHomeDirectoryPath)
    {
        // 1. Check mod's 'data' root folder.
        string modRootPath = Path.Combine(modHomeDirectoryPath, M2TWFileSystemInfo.MOD_ROOT);

        if (!Directory.Exists(modRootPath))
        {
            return false;
        }

        // 2. Check mod's 'data/world/maps/campaign/imperial_campaign' folder.
        string modCampaignNodePath = Path.Combine(
            modRootPath,
            M2TWFileSystemInfo.MOD_NODE1_WORLD,
            M2TWFileSystemInfo.MOD_NODE2_MAPS,
            M2TWFileSystemInfo.MOD_NODE3_MAPS_CAMPAIGN,
            M2TWFileSystemInfo.MOD_NODE4_MAPS_IMPERIALCAMPAIGN);

        if (!Directory.Exists(modCampaignNodePath))
        {
            return false;
        }
        else
        {
            if (!File.Exists(Path.Combine(modCampaignNodePath, M2TWFileSystemInfo.WORLD_MAPS_CAMPAIGN_DESCR_STRAT)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modCampaignNodePath, M2TWFileSystemInfo.WORLD_MAPS_CAMPAIGN_DESCR_WINCONDITIONS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modCampaignNodePath, M2TWFileSystemInfo.WORLD_MAPS_CAMPAIGN_SCRIPT)))
            {
                return false;
            }
        }

        // 3. Check mod's 'data/world/maps/base' folder.
        string modBaseNodePath = Path.Combine(
            modRootPath,
            M2TWFileSystemInfo.MOD_NODE1_WORLD,
            M2TWFileSystemInfo.MOD_NODE2_MAPS,
            M2TWFileSystemInfo.MOD_NODE3_MAPS_BASE);

        if (!Directory.Exists(modBaseNodePath))
        {
            return false;
        }
        else
        {
            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_DESCR_REGIONS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_DESCR_SOUNDMUSICTYPES)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_CLIMATES)))
            {
                return false;
            }

            // This file might be named either "map_FE.tga" or "map_fe.tga" in different mods.
            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_FE)) &&
                    !File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_FE.ToLower())))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_FEATURES)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_FOG)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_GROUNDTYPES)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_HEIGHTS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_REGIONS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_ROUGHNESS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_TRADEROUTES)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modBaseNodePath, M2TWFileSystemInfo.WORLD_MAPS_BASE_MAP_WATERSURFACES)))
            {
                return false;
            }
        }

        // 4. Check mod's 'data/sounds' folder.
        string modSoundsNodePath = Path.Combine(modRootPath, M2TWFileSystemInfo.MOD_NODE1_SOUNDS);

        if (!Directory.Exists(modSoundsNodePath))
        {
            return false;
        }
        else
        {
            if (!File.Exists(Path.Combine(modSoundsNodePath, M2TWFileSystemInfo.SOUNDS_DAT_EVENTS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, M2TWFileSystemInfo.SOUNDS_DAT_MUSIC)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, M2TWFileSystemInfo.SOUNDS_DAT_SFX)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, M2TWFileSystemInfo.SOUNDS_DAT_VOICE)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, M2TWFileSystemInfo.SOUNDS_IDX_EVENTS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, M2TWFileSystemInfo.SOUNDS_IDX_MUSIC)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, M2TWFileSystemInfo.SOUNDS_IDX_SFX)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modSoundsNodePath, M2TWFileSystemInfo.SOUNDS_IDX_VOICE)))
            {
                return false;
            }
        }

        // 5. Check mod's 'data/animations' folder.
        string modAnimationsNodePath = Path.Combine(modRootPath, M2TWFileSystemInfo.MOD_NODE1_ANIMATIONS);

        if (!Directory.Exists(modAnimationsNodePath))
        {
            return false;
        }
        else
        {
            if (!File.Exists(Path.Combine(modAnimationsNodePath, M2TWFileSystemInfo.ANIMATIONS_DAT_PACK)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modAnimationsNodePath, M2TWFileSystemInfo.ANIMATIONS_DAT_SKELETONS)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modAnimationsNodePath, M2TWFileSystemInfo.ANIMATIONS_IDX_PACK)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(modAnimationsNodePath, M2TWFileSystemInfo.ANIMATIONS_IDX_SKELETONS)))
            {
                return false;
            }
        }

        return true;
    }
}
