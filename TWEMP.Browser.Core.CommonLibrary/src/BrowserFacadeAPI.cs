// <copyright file="BrowserFacadeAPI.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1124 // Do not use regions
#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using TWEMP.Browser.Core.CommonLibrary.GameLauncherFeatures.Plugins;
using TWEMP.Browser.Core.CommonLibrary.Logging;

/// <summary>
/// Serves as a facade interface for available application settings. It is a temp design.
/// </summary>
public static class Settings
{
    private static readonly AppGuiStyleManager AppGuiStyleManagerInstance;

    static Settings()
    {
        // Initialize the default logging device.
        Logger.InitializeByDefault();

        Logger.CurrentInstance?.Open(); // test logging

        // Setup the global object of the GUI style manager by default.
        AppGuiStyleManagerInstance = AppGuiStyleManager.Create();
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

    #region Facade Interface: AppSystemSettingsManager

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
            return new GuiLocale(AppLocalizationManager.CurrentLocalization);
        }
    }

    public static void SetCurrentLocalizationByName(string guiLocaleName)
    {
        AppLocalizationManager.SetCurrentLocalizationByName(guiLocaleName);
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

/// <summary>
/// Serves as a facade interface for application's localization manager.
/// It is a temp design.
/// </summary>
public static class LocalizationManager
{
    public static bool IsCurrentLocalizationName(string guiLocaleName)
    {
        return AppLocalizationManager.IsCurrentLocalizationName(guiLocaleName);
    }
}

/// <summary>
/// Serves as a facade interface for application's UI localization.
/// It is a temp design.
/// </summary>
public class GuiLocale
{
    private readonly AppLocalization localization;

    public GuiLocale(AppLocalization appLocalization)
    {
        this.localization = appLocalization;
    }

    public static string LOCALE_NAME_ENG
    {
        get
        {
            return AppLocalization.LOCALE_NAME_ENG;
        }
    }

    public static string LOCALE_NAME_RUS
    {
        get
        {
            return AppLocalization.LOCALE_NAME_RUS;
        }
    }

    public FormLocaleSnapshot GetFormLocaleSnapshotByKey(string targetKey)
    {
        LocaleSnapshot snapshot = this.localization.GetFormLocaleSnapshotByKey(targetKey);
        return new FormLocaleSnapshot(snapshot);
    }
}

/// <summary>
/// Serves as a facade interface for a target UI control element's locale snapshot.
/// It is a temp design.
/// </summary>
public class FormLocaleSnapshot
{
    private readonly LocaleSnapshot snapshot;

    public FormLocaleSnapshot(LocaleSnapshot formLocaleSnapshot)
    {
        this.snapshot = formLocaleSnapshot;
    }

    public string GetLocalizedValueByKey(string targetKey)
    {
        return this.snapshot.GetLocalizedValueByKey(targetKey);
    }
}

/// <summary>
/// Serves as a facade interface for the original game launcher implementation.
/// It is a temp design.
/// </summary>
public class GameLaunchConfigurator
{
    private readonly M2TWGameLauncher agent;

    public GameLaunchConfigurator(GameModificationInfo mod_info, CustomConfigState state, IBrowserMessageProvider messageProvider)
    {
        this.agent = new M2TWGameLauncher(mod_info, state, messageProvider);
    }

    public void Execute()
    {
        this.agent.Execute();
    }
}
