﻿// <copyright file="RTWGameConfigurator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

// TODO: Move this class definition to the TWEMP.Browser.Core.GamingSupport class library!
namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Plugins;

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
    public CfgOptionsSubSet[] GetDefaultConfigSettings()
    {
        return new CfgOptionsSubSet[] { }; // TODO: Implement using existing RTW config settings!
    }

    /// <summary>
    /// Gets RTW configuration settings via a custom configuration state.
    /// </summary>
    /// <param name="state">A target custom game configuration state.</param>
    /// <returns>The array of game configuration settings.</returns>
    public CfgOptionsSubSet[] GetCustomConfigSettings(ICustomConfigState state)
    {
        return new CfgOptionsSubSet[] { }; // TODO: Implement using existing RTW config settings!
    }
}