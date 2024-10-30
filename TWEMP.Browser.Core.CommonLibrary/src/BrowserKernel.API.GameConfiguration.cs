// <copyright file="BrowserKernel.API.GameConfiguration.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

public static partial class BrowserKernel
{
    public static List<GameConfigProfile> AvailableProfiles
    {
        get
        {
            return GameConfigurationManagerInstance.AvailableProfiles;
        }
    }

    public static UpdatableGameModificationView? CurrentGameModView
    {
        get
        {
            return GameConfigurationManagerInstance.CurrentGameModView;
        }

        set
        {
            GameConfigurationManagerInstance.CurrentGameModView = value;
        }
    }

    public static Dictionary<int, Guid> GetConfigProfilesToDisplay(GameConfigProfile[] gameConfigProfiles)
    {
        return GameConfigurationManager.GetConfigProfilesToDisplay(gameConfigProfiles);
    }

    public static object[] GetNewConfigProfileItems(Dictionary<int, Guid> viewOfGameConfigProfiles)
    {
        return GameConfigurationManagerInstance.GetNewConfigProfileItems(viewOfGameConfigProfiles);
    }

    public static GameConfigProfile[] GetAllConfigProfilesForSelectedGameMod(UpdatableGameModificationView gameModView)
    {
        return GameConfigurationManagerInstance.GetAllConfigProfilesForSelectedGameMod(gameModView);
    }

    public static void CreateNewProfile(GameSupportProvider provider, GameModificationInfo info, ICustomConfigState state)
    {
        GameConfigurationManagerInstance.CreateNewProfile(provider, info, state);
    }

    public static void CopyProfile(GameConfigProfile templateProfile)
    {
        GameConfigurationManagerInstance.CopyProfile(templateProfile);
    }

    public static GameConfigProfile SelectProfileById(Guid profileId)
    {
        return GameConfigurationManagerInstance.SelectProfileById(profileId);
    }

    public static void UpdateProfile(Guid profileId, string newProfileName, GameConfigState newState)
    {
        GameConfigurationManagerInstance.UpdateProfile(profileId, newProfileName, newState);
    }

    public static void DeleteProfile(Guid profileId)
    {
        GameConfigurationManagerInstance.DeleteProfile(profileId);
    }

    public static void DeleteAllProfiles()
    {
        GameConfigurationManagerInstance.DeleteAllProfiles();
    }

    public static void ExportAllProfilesToFile(string exportFileName)
    {
        string exportFilePath = Path.Combine(Directory.GetCurrentDirectory(), exportFileName);
        GameConfigurationManagerInstance.ExportAllProfilesToFile(exportFilePath);
    }

    public static void ImportAllProfilesFrom(string importFilePath)
    {
        GameConfigurationManagerInstance.ImportAllProfilesFromFile(importFilePath);
    }
}
