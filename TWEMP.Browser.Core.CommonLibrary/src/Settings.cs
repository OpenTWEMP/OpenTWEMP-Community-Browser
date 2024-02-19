// <copyright file="Settings.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1124 // Do not use regions
#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;

/// <summary>
/// Serves as a facade interface for available application settings. It is a temp design.
/// </summary>
public static class Settings
{
    private static readonly AppGuiStyleManager AppGuiStyleManagerInstance;

    static Settings()
    {
        // Setup the global object of the GUI style manager by default.
        AppGuiStyleManagerInstance = AppGuiStyleManager.Create();
    }

    #region Facade Interface: AppSystemSettingsManager

    public static DirectoryInfo AppSupportDirectoryInfo
    {
        get
        {
            return AppSystemSettingsManager.AppSupportDirectoryInfo;
        }
    }

    public static bool UseExperimentalFeatures
    {
        get
        {
            return AppSystemSettingsManager.UseExperimentalFeatures;
        }

        set
        {
            AppSystemSettingsManager.UseExperimentalFeatures = value;
        }
    }

    #endregion

    #region Facade Interface: AppGuiStyleManager

    public static GuiStyle CurrentGUIStyle
    {
        get
        {
            return AppGuiStyleManagerInstance.CurrentStyle;
        }

        set
        {
            AppGuiStyleManagerInstance.CurrentStyle = value;
        }
    }

    #endregion

    #region Facade Interface: LocalizationManager

    public static GuiLocale CurrentLocalization
    {
        get
        {
            return LocalizationManager.CurrentLocalization;
        }
    }

    public static void SetCurrentLocalizationByName(string guiLocaleName)
    {
        LocalizationManager.SetCurrentLocalizationByName(guiLocaleName);
    }

    #endregion

    #region Facade Interface: CustomGameCollectionsManager

    public static CustomModsCollection FavoriteModsCollection
#pragma warning restore SA1201 // Elements should appear in the correct order
    {
        get
        {
            return CustomGameCollectionsManager.FavoriteModsCollection;
        }
    }

    public static List<CustomModsCollection> UserCollections
    {
        get
        {
            return CustomGameCollectionsManager.UserCollections;
        }
    }

    #endregion

    #region Facade Interface: CustomGameSetupManager

    public static List<GameSetupInfo> GameInstallations
    {
        get
        {
            return CustomGameSetupManager.GameInstallations;
        }
    }

    public static List<GameModificationInfo> TotalModificationsList
    {
        get
        {
            return CustomGameSetupManager.TotalModificationsList;
        }
    }

    public static GameSetupInfo RegistrateGameInstallation(
        string setupName, string executableFullPath, List<string> modcenterPaths)
    {
        return CustomGameSetupManager.RegistrateGameInstallation(
            setupName, executableFullPath, modcenterPaths);
    }

    public static void UpdateTotalModificationsList()
    {
        CustomGameSetupManager.UpdateTotalModificationsList();
    }

    public static GameModificationInfo GetActiveModificationInfo(string modShortName)
    {
        return CustomGameSetupManager.GetActiveModificationInfo(modShortName);
    }

    public static void ClearAllSettings()
    {
        CustomGameSetupManager.ClearAllSettings();
    }

    public static List<GameSetupInfo> SynchronizeGameSetupSettings()
    {
        return CustomGameSetupManager.SynchronizeGameSetupSettings();
    }

    public static void DeleteGameSetupByIndex(int gameSetupIndex)
    {
        CustomGameSetupManager.DeleteGameSetupByIndex(gameSetupIndex);
    }

    #endregion
}
