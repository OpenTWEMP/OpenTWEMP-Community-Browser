// <copyright file="BrowserKernel.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using TWEMP.Browser.Core.CommonLibrary.Logging;
using TWEMP.Browser.Core.CommonLibrary.MediaDevices;
using TWEMP.Browser.Core.CommonLibrary.src.CustomManagement.Gaming.Views;

/// <summary>
/// Defines the kernel of any OpenTWEMP Community Browser implementation.
/// </summary>
public static partial class BrowserKernel
{
    private static readonly AppSystemSettingsManager AppSystemSettingsManagerInstance;

    private static readonly AppGuiStyleManager AppGuiStyleManagerInstance;

    private static readonly AppLocalizationManager AppLocalizationManagerInstance;

    private static readonly MediaDeviceManager MediaDeviceManagerInstance;

    private static readonly CustomGameSetupManager CustomGameSetupManagerInstance;

    private static readonly CustomGameCollectionsManager CustomGameCollectionsManagerInstance;

    private static readonly GameSupportManager GameSupportManagerInstance;

    private static readonly ModSupportPresetSetupManager ModSupportPresetSetupManagerInstance;

    private static readonly GameConfigurationManager GameConfigurationManagerInstance;

    static BrowserKernel()
    {
        AppSystemSettingsManagerInstance = AppSystemSettingsManager.Create();

        AppGuiStyleManagerInstance = AppGuiStyleManager.Create();

        AppLocalizationManagerInstance = AppLocalizationManager.Create();

        MediaDeviceManagerInstance = MediaDeviceManager.Create();

        CustomGameSetupManagerInstance = CustomGameSetupManager.Create();
        CustomGameSetupManagerInstance.SynchronizeGameSetupSettings();
        CustomGameSetupManagerInstance.UpdateTotalModificationsList();

        CustomGameCollectionsManagerInstance = CustomGameCollectionsManager.Create();

        GameSupportManagerInstance = GameSupportManager.Create();

        ModSupportPresetSetupManagerInstance = ModSupportPresetSetupManager.Create(CustomGameSetupManagerInstance, GameSupportManagerInstance);

        GameConfigurationManagerInstance = GameConfigurationManager.Create(CustomGameSetupManagerInstance);

        // Initialize the default logging device.
        Logger.InitializeByDefault();

        Logger.CurrentInstance?.Open(); // test logging

        Logger.CurrentInstance?.LogEventMessage(new BrowserEventMessage(
            "AppGuiStyleManager", "AppGuiStyleManager.Create()", DateTime.Now)); // test logging

        Logger.CurrentInstance?.LogEventMessage(new BrowserEventMessage(
            "GameSupportManager", "GameSupportManager.Initialize()", DateTime.Now)); // test logging

        Logger.CurrentInstance?.LogEventMessage(new BrowserEventMessage(
            "GameConfigurationManager", "GameConfigurationManager.Initialize()", DateTime.Now)); // test logging

        Logger.CurrentInstance?.Close(); // test logging
    }

    public static void Initialize()
    {
    }

    public static bool SyncUserDataForAllGameMods()
    {
        // 1. Update CustomGameSetupManager.TotalModificationsList.
        CustomGameSetupManagerInstance.UpdateTotalModificationsList();

        // 2. Update ModSupportPresetSetupManager.CurrentGameModsCollectionView.
        ModSupportPresetSetupManagerInstance.UpdatePresetSettings();

        int currentGameModsCount = CustomGameSetupManagerInstance.TotalModificationsList.Count;
        int currentModViewsCount = ModSupportPresetSetupManagerInstance
            .CurrentGameModsCollectionView.GameModificationViews.Length;

        return currentModViewsCount == currentGameModsCount;
    }
}
