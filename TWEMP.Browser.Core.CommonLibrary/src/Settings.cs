// <copyright file="Settings.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;

public static class Settings
{
    internal static readonly DirectoryInfo AppSupportNode_M2TW_LOGO_DirectoryInfo;

    private const string APP_SUPPORT_DIRECTORY_NAME = "support";
    private const string APP_SUPPORT_NODE1_M2TW = "M2TWK";
    private const string APP_SUPPORT_NODE2_LOGO = "images";

    private static readonly AppGuiStyleManager AppGuiStyleManagerInstance;

    static Settings()
    {
        string appSupportDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), APP_SUPPORT_DIRECTORY_NAME);
        AppSupportDirectoryInfo = new DirectoryInfo(appSupportDirectoryPath);

        // Initialize app's file system.
        if (!AppSupportDirectoryInfo.Exists)
        {
            AppSupportDirectoryInfo.Create();
        }

        string appSupportNode_M2TW_LOGO_DirectoryPath = Path.Combine(appSupportDirectoryPath, APP_SUPPORT_NODE1_M2TW, APP_SUPPORT_NODE2_LOGO);
        AppSupportNode_M2TW_LOGO_DirectoryInfo = new DirectoryInfo(appSupportNode_M2TW_LOGO_DirectoryPath);

        if (!AppSupportNode_M2TW_LOGO_DirectoryInfo.Exists)
        {
            AppSupportNode_M2TW_LOGO_DirectoryInfo.Create();
        }

        // Setup the global object of the GUI style manager by default.
        AppGuiStyleManagerInstance = AppGuiStyleManager.Create();

        // Initialize extra flags by default.
        UseExperimentalFeatures = true;
    }

    public static DirectoryInfo AppSupportDirectoryInfo { get; }

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

    public static CustomModsCollection FavoriteModsCollection
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

    public static GuiLocale CurrentLocalization
    {
        get
        {
            return LocalizationManager.CurrentLocalization;
        }
    }

    public static bool UseExperimentalFeatures { get; set; }

    public static void SetCurrentLocalizationByName(string guiLocaleName)
    {
        LocalizationManager.SetCurrentLocalizationByName(guiLocaleName);
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
}
