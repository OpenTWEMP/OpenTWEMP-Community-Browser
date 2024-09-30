// <copyright file="BrowserFacadeAPI.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1124 // Do not use regions
#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;
using TWEMP.Browser.Core.CommonLibrary.Logging;

/// <summary>
/// Serves as a facade interface for available application settings. It is a temp design.
/// </summary>
public static class Settings
{
    static Settings()
    {
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

    #region Facade Interface: CustomGameSetupManager

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
