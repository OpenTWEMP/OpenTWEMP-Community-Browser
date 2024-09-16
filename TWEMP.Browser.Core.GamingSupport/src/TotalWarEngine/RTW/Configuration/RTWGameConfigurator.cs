// <copyright file="RTWGameConfigurator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.RTW.Configuration;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using ICustomConfigState = AbstractPlaceholders.ICustomConfigState;
using IGameConfiguratorAgent = AbstractPlaceholders.IGameConfiguratorAgent;

/// <summary>
/// Implements the game configurator agent for the "Rome Total War" game engine (RTW).
/// </summary>
public class RTWGameConfigurator : IGameConfiguratorAgent
{
    private readonly GameModificationInfo gameModificationInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="RTWGameConfigurator"/> class.
    /// </summary>
    /// <param name="info">Information about a target game modification.</param>
    public RTWGameConfigurator(GameModificationInfo info)
    {
        this.gameModificationInfo = info;
    }

    /// <summary>
    /// Gets RTW configuration settings by default.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetDefaultConfigSettings()
    {
        return new GameCfgSection[] { }; // TODO: Implement using existing RTW config settings!
    }

    /// <summary>
    /// Gets RTW configuration settings via a custom configuration state.
    /// </summary>
    /// <param name="state">A target custom game configuration state.</param>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetCustomConfigSettings(ICustomConfigState state)
    {
        return new GameCfgSection[] { }; // TODO: Implement using existing RTW config settings!
    }
}
