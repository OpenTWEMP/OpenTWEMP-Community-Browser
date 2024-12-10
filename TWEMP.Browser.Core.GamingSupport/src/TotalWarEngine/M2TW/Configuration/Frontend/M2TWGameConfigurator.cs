// <copyright file="M2TWGameConfigurator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#define EXPERIMENTAL_FEATURES
#undef EXPERIMENTAL_FEATURES

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;

/// <summary>
/// Implements the game configurator agent for the "Medieval 2 Total War" game engine (M2TW).
/// </summary>
public class M2TWGameConfigurator : IGameConfiguratorAgent
{
    private readonly GameModificationInfo currentGameModificationInfo;
    private readonly M2TWGameConfigStateView currentGameConfigStateView;
    private readonly M2TWCustomQuickConfigStateView currentQuickCustomConfigStateView;

#if EXPERIMENTAL_FEATURES
    /// <summary>
    /// Initializes a new instance of the <see cref="M2TWGameConfigurator"/> class.
    /// </summary>
    /// <param name="gameModificationInfo">Information about a target game modification.</param>
    /// <param name="gameConfigStateView">Information about a target game configuration.</param>
    /// <param name="quickCustomConfigStateView">Information about a quick custom configuration.</param>
    public M2TWGameConfigurator(
        GameModificationInfo gameModificationInfo,
        M2TWGameConfigStateView gameConfigStateView,
        M2TWCustomQuickConfigStateView quickCustomConfigStateView)
    {
        this.currentGameModificationInfo = gameModificationInfo;
        this.currentGameConfigStateView = gameConfigStateView;
        this.currentQuickCustomConfigStateView = quickCustomConfigStateView;

        this.CurrentInfo = this.currentGameModificationInfo;
        this.CurrentState = this.currentQuickCustomConfigStateView;
    }
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="M2TWGameConfigurator"/> class.
    /// </summary>
    /// <param name="gameModificationInfo">Information about a target game modification.</param>
    /// <param name="gameConfigStateView">Information about a target game configuration.</param>
    public M2TWGameConfigurator(
        GameModificationInfo gameModificationInfo,
        M2TWGameConfigStateView gameConfigStateView)
    {
        this.currentGameModificationInfo = gameModificationInfo;
        this.currentGameConfigStateView = gameConfigStateView;
        this.currentQuickCustomConfigStateView = new M2TWCustomQuickConfigStateView();

        this.CurrentInfo = this.currentGameModificationInfo;
        this.CurrentState = this.currentQuickCustomConfigStateView;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="M2TWGameConfigurator"/> class.
    /// </summary>
    /// <param name="gameModificationInfo">Information about a target game modification.</param>
    private M2TWGameConfigurator(GameModificationInfo gameModificationInfo)
    {
        this.currentGameModificationInfo = gameModificationInfo;
        this.currentGameConfigStateView = M2TWGameConfigStateView.CreateByDefault(gameModificationInfo);
        this.currentQuickCustomConfigStateView = new M2TWCustomQuickConfigStateView();

        this.CurrentInfo = this.currentGameModificationInfo;
        this.CurrentState = this.currentQuickCustomConfigStateView;
    }

    /// <summary>
    /// Gets the current game modification info.
    /// </summary>
    public GameModificationInfo CurrentInfo { get; }

    /// <summary>
    /// Gets the current quick custom config state.
    /// </summary>
    public M2TWCustomQuickConfigStateView CurrentState { get; }

    /// <summary>
    /// Creates the game configurator agent by default.
    /// </summary>
    /// <param name="gameModificationInfo">Information about a target game modification.</param>
    /// <returns>A new instance of the <see cref="M2TWGameConfigurator"/> class.</returns>
    public static M2TWGameConfigurator CreateByDefault(GameModificationInfo gameModificationInfo)
    {
        return new M2TWGameConfigurator(gameModificationInfo);
    }

    /// <summary>
    /// Gets M2TW configuration settings by default.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetDefaultConfigSettings()
    {
        M2TWGameConfigStateView view = M2TWGameConfigStateView.CreateByDefault(this.currentGameModificationInfo);
        return view.RetrieveCurrentSettings();
    }

    /// <summary>
    /// Gets current M2TW configuration settings.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetCurrentConfigSettings()
    {
        return this.currentGameConfigStateView.RetrieveCurrentSettings();
    }

    /// <summary>
    /// Overrides current game configuration settings by a specified custom quick config state.
    /// </summary>
    /// <param name="state">A custom qucik config state.</param>
    public void OverrideConfigSettingsByCustomQuickState(ICustomQuickConfigState state)
    {
        Dictionary<string, bool> viewsOfProperties = state.GetStateViewOfProperties();
        this.currentQuickCustomConfigStateView.SetPropertiesByStateView(viewsOfProperties);

        this.ApplyAllOverridedConfigSettings();
    }

    private void ApplyAllOverridedConfigSettings()
    {
        this.ApplyOverridedLogLevelSettings();
        this.ApplyOverridedVideoSettings();
    }

    private void ApplyOverridedLogLevelSettings()
    {
        if (this.currentQuickCustomConfigStateView.ValidatorLogLevel1)
        {
            this.currentGameConfigStateView.ModDiagnosticSection!.LogLevel = new M2TW_LoggingLevel(M2TW_LoggingMode.Error) !;
        }

        if (this.currentQuickCustomConfigStateView.ValidatorLogLevel2)
        {
            this.currentGameConfigStateView.ModDiagnosticSection!.LogLevel = new M2TW_LoggingLevel(M2TW_LoggingMode.Trace) !;
        }

        if (this.currentQuickCustomConfigStateView.ValidatorLogLevel3)
        {
            this.currentGameConfigStateView.ModDiagnosticSection!.LogLevel = new M2TW_LoggingLevel(M2TW_LoggingMode.ScriptTrace) !;
        }
    }

    private void ApplyOverridedVideoSettings()
    {
        if (this.currentQuickCustomConfigStateView.IsEnabledWindowedMode)
        {
            this.currentGameConfigStateView.GameVideoCfgSection!.VideoWindowedMode = new M2TW_Boolean(true);
        }

        if (this.currentQuickCustomConfigStateView.IsEnabledFullScreenMode)
        {
            this.currentGameConfigStateView.GameVideoCfgSection!.VideoWindowedMode = new M2TW_Boolean(false);
        }

        this.currentGameConfigStateView.GameVideoCfgSection!.VideoMovies =
            new M2TW_Boolean(this.currentQuickCustomConfigStateView.ValidatorVideo);

        this.currentGameConfigStateView.GameVideoCfgSection!.VideoBorderlessWindow =
            new M2TW_Boolean(this.currentQuickCustomConfigStateView.ValidatorBorderless);
    }
}
