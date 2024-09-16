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
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing M2TW config settings!
    }

    /// <summary>
    /// Gets M2TW configuration settings via a custom configuration state.
    /// </summary>
    /// <param name="state">A target custom game configuration state.</param>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetCustomConfigSettings(ICustomConfigState state)
    {
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing M2TW config settings!
    }

#if LEGACY_CONFIG_BUILDER_CODE
    public static List<M2TWGameCfgSection> InitializeMinimalModSettings(GameModificationInfo mod, M2TWGameConfigStateView cfg)
    {
        List<M2TWGameCfgSection> settings = new ();

        M2TWGameCfgSection features_subset = GetFeaturesSubSet(mod); // [features]
        settings.Add(features_subset);

        M2TWGameCfgSection io_subset = GetIOSubSet(); // [io]
        settings.Add(io_subset);

        M2TWGameCfgSection log_subset = GetLogSubSet(mod, cfg); // [log]
        settings.Add(log_subset);

        M2TWGameCfgSection video_subset = GetVideoSubSet(cfg); // [video]
        settings.Add(video_subset);

        M2TWGameCfgSection hotseat_subset = GetHotseatSubSet(); // [hotseat]
        settings.Add(hotseat_subset);

        M2TWGameCfgSection multiplayer_subset = GetMultiplayerSubSet(); // [multiplayer]
        settings.Add(multiplayer_subset);

        M2TWGameCfgSection game_subset = GetGameSubSet(); // [game]
        settings.Add(game_subset);

        M2TWGameCfgSection ui_subset = GetUISubSet(); // [ui]
        settings.Add(ui_subset);

        M2TWGameCfgSection misc_subset = GetMiscSubSet(); // [misc]
        settings.Add(misc_subset);

        return settings;
    }
#endif
}
