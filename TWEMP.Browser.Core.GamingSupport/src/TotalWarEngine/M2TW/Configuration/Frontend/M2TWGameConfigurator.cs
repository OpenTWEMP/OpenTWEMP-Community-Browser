// <copyright file="M2TWGameConfigurator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

/// <summary>
/// Implements the game configurator agent for the "Medieval 2 Total War" game engine (M2TW).
/// </summary>
public class M2TWGameConfigurator : IGameConfiguratorAgent
{
    private readonly GameModificationInfo gameModificationInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="M2TWGameConfigurator"/> class.
    /// </summary>
    /// <param name="info">Information about a target game modification.</param>
    public M2TWGameConfigurator(GameModificationInfo info)
    {
        this.gameModificationInfo = info;
    }

    /// <summary>
    /// Gets M2TW configuration settings by default.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetDefaultConfigSettings()
    {
        M2TWGameConfigStateView view = M2TWGameConfigStateView.CreateByDefault(this.gameModificationInfo);
        return view.RetrieveCurrentSettings();
    }

    /// <summary>
    /// Gets M2TW configuration settings via a custom configuration state.
    /// </summary>
    /// <param name="state">A target custom game configuration state.</param>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetCustomConfigSettings(ICustomConfigState state)
    {
        return state.RetrieveCurrentSettings();
    }

    public List<CfgOptionsSubSet> InitializeMinimalModSettings(CustomConfigState cfg)
    {
        List<CfgOptionsSubSet> settings = new ();

        CfgOptionsSubSet features_subset = GetFeaturesSubSet(this.gameModificationInfo); // [features]
        settings.Add(features_subset);

        CfgOptionsSubSet io_subset = GetIOSubSet(); // [io]
        settings.Add(io_subset);

        CfgOptionsSubSet log_subset = GetLogSubSet(this.gameModificationInfo, cfg); // [log]
        settings.Add(log_subset);

        CfgOptionsSubSet video_subset = GetVideoSubSet(cfg); // [video]
        settings.Add(video_subset);

        return settings;
    }

    private static CfgOptionsSubSet GetFeaturesSubSet(GameModificationInfo mod)
    {
        string subsetName = "features";

        var subsetOptions = new List<CfgOption>();

        subsetOptions.Add(new CfgOption("editor", true));
        subsetOptions.Add(new CfgOption("mod", mod.ModCfgRelativePath));

        return new CfgOptionsSubSet(subsetName, subsetOptions);
    }

    private static CfgOptionsSubSet GetIOSubSet()
    {
        string subsetName = "io";

        var subsetOptions = new List<CfgOption>();
        subsetOptions.Add(new CfgOption("file_first", true));

        return new CfgOptionsSubSet(subsetName, subsetOptions);
    }

    private static CfgOptionsSubSet GetLogSubSet(GameModificationInfo mod, CustomConfigState cfg)
    {
        string subsetName = "log";

        var subsetOptions = new List<CfgOption>();
        subsetOptions.Add(new CfgOption("to", mod.LogFileRelativePath));
        subsetOptions.Add(new CfgOption("level", SetLogLevel(cfg)));

        return new CfgOptionsSubSet(subsetName, subsetOptions);
    }

    private static string SetLogLevel(CustomConfigState cfg)
    {
        const string strLogLevelError = "* error";
        const string strLogLevelTrace = "* trace";
        const string strLogLevelScriptTrace = "*script* trace";

        string strLogLevel = string.Empty;

        if (cfg.ValidatorLogLevel1)
        {
            strLogLevel = strLogLevelError;
        }

        if (cfg.ValidatorLogLevel2)
        {
            strLogLevel = strLogLevelTrace;
        }

        if (cfg.ValidatorLogLevel3)
        {
            strLogLevel = strLogLevelScriptTrace;
        }

        return strLogLevel;
    }

    private static CfgOptionsSubSet GetVideoSubSet(CustomConfigState cfg)
    {
        string subsetName = "video";
        var subsetOptions = new List<CfgOption>();
        subsetOptions.Add(new CfgOption("windowed", cfg.IsEnabledWindowedMode));
        subsetOptions.Add(new CfgOption("movies", cfg.ValidatorVideo));
        subsetOptions.Add(new CfgOption("borderless_window", cfg.ValidatorBorderless));

        return new CfgOptionsSubSet(subsetName, subsetOptions);
    }
}
