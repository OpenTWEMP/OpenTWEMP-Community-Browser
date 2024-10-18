// <copyright file="BrowserKernel.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using TWEMP.Browser.Core.CommonLibrary.Logging;
using TWEMP.Browser.Core.CommonLibrary.MediaDevices;

/// <summary>
/// Defines the kernel of any OpenTWEMP Community Browser implementation.
/// </summary>
public static class BrowserKernel
{
    private static readonly AppSystemSettingsManager AppSystemSettingsManagerInstance;

    private static readonly AppGuiStyleManager AppGuiStyleManagerInstance;

    private static readonly AppLocalizationManager AppLocalizationManagerInstance;

    private static readonly MediaDeviceManager MediaDeviceManagerInstance;

    private static readonly CustomGameCollectionsManager CustomGameCollectionsManagerInstance;


    // CustomGameSetupManager

    // GameSupportManager

    // PresetManager ???

    // GameConfigurationManager


    static BrowserKernel()
    {
        AppSystemSettingsManagerInstance = AppSystemSettingsManager.Create();

        AppGuiStyleManagerInstance = AppGuiStyleManager.Create();

        AppLocalizationManagerInstance = AppLocalizationManager.Create();

        MediaDeviceManagerInstance = MediaDeviceManager.Create();

        CustomGameCollectionsManagerInstance = CustomGameCollectionsManager.Create();



        // Initialize the default logging device.
        Logger.InitializeByDefault();

        Logger.CurrentInstance?.Open(); // test logging

        Logger.CurrentInstance?.LogEventMessage(new BrowserEventMessage(
            "AppGuiStyleManager", "AppGuiStyleManager.Create()", DateTime.Now)); // test logging

        // Setup the global device for game support manager by default.
        GameSupportManager.Initialize();
        Logger.CurrentInstance?.LogEventMessage(new BrowserEventMessage(
            "GameSupportManager", "GameSupportManager.Initialize()", DateTime.Now)); // test logging

        // Setup the global device for game configuration profile manager by default.
        GameConfigurationManager.Initialize();
        Logger.CurrentInstance?.LogEventMessage(new BrowserEventMessage(
            "GameConfigurationManager", "GameConfigurationManager.Initialize()", DateTime.Now)); // test logging

        Logger.CurrentInstance?.Close(); // test logging
    }


    // BROWSER API: COLLECTIONS


    public static CustomModsCollection FavoriteModsCollection
    {
        get
        {
            return CustomGameCollectionsManagerInstance.FavoriteModsCollection;
        }
    }

    public static List<CustomModsCollection> UserCollections
    {
        get
        {
            return CustomGameCollectionsManagerInstance.UserCollections;
        }
    }

    public static void WriteExistingCollections()
    {
        CustomGameCollectionsManagerInstance.WriteExistingCollections();
    }

    public static void WriteFavoriteCollection()
    {
        CustomGameCollectionsManagerInstance.WriteFavoriteCollection();
    }


    // BROWSER API: GAME SETUP MANAGEMENT


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


    // BROWSER API: GUI CUSTOMIZATION


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


    // BROWSER API: APPLICATION FEATURES


    public static bool UseExperimentalFeatures
    {
        get
        {
            return AppSystemSettingsManagerInstance.UseExperimentalFeatures;
        }

        set
        {
            AppSystemSettingsManagerInstance.UseExperimentalFeatures = value;
        }
    }


    // BROWSER API: GAME SETUP MANAGEMENT


    public static List<GameSetupInfo> SynchronizeGameSetupSettings()
    {
        return CustomGameSetupManager.SynchronizeGameSetupSettings();
    }

    public static GameModificationInfo GetActiveModificationInfo(string modShortName)
    {
        return CustomGameSetupManager.GetActiveModificationInfo(modShortName);
    }

    public static GameSetupInfo RegistrateGameInstallation(string setupName, string executableFullPath, List<string> modcenterPaths)
    {
        return CustomGameSetupManager.RegistrateGameInstallation(setupName, executableFullPath, modcenterPaths);
    }

    public static void DeleteGameSetupByIndex(int gameSetupIndex)
    {
        CustomGameSetupManager.DeleteGameSetupByIndex(gameSetupIndex);
    }

    public static void UpdateTotalModificationsList()
    {
        CustomGameSetupManager.UpdateTotalModificationsList();
    }

    public static void ClearAllSettings()
    {
        CustomGameSetupManager.ClearAllSettings();
    }


    // BROWSER API: GUI CUSTOMIZATION


    public static ColorTheme SelectCurrentColorTheme()
    {
        return AppGuiStyleManagerInstance.GetCurrentColorTheme();
    }

    public static ColorTheme UpdateCurrentColorTheme(GuiStyle style)
    {
        if (CurrentGUIStyle != style)
        {
            CurrentGUIStyle = style;
        }

        return AppGuiStyleManagerInstance.GetCurrentColorTheme();
    }


    // BROWSER API: LOCALIZATION


    public static bool IsEnabledLocalizationOnEnglish()
    {
        return AppLocalizationManagerInstance.IsCurrentLocalizationName(AppLocalization.LOCALE_NAME_ENG);
    }

    public static bool IsEnabledLocalizationOnRussian()
    {
        return AppLocalizationManagerInstance.IsCurrentLocalizationName(AppLocalization.LOCALE_NAME_RUS);
    }

    public static void SetLocalizationOnEnglishAsCurrent()
    {
        AppLocalizationManagerInstance.SetCurrentLocalizationByName(AppLocalization.LOCALE_NAME_ENG);
    }

    public static void SetLocalizationOnRussianAsCurrent()
    {
        AppLocalizationManagerInstance.SetCurrentLocalizationByName(AppLocalization.LOCALE_NAME_RUS);
    }

    public static string GetTextInCurrentLocalization(string formName, string controlName)
    {
        LocaleSnapshot snapshot = AppLocalizationManagerInstance.CurrentLocalization.GetFormLocaleSnapshotByKey(formName);
        return snapshot.GetLocalizedValueByKey(controlName);
    }
}
