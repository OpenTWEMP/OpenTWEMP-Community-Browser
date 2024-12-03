// <copyright file="RTWGameConfigurator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.RTW.Configuration;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

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
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing RTW config settings!
    }

    /// <summary>
    /// Gets current RTW configuration settings.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetCurrentConfigSettings()
    {
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing RTW config settings!
    }

    /// <summary>
    /// Overrides current RTW configuration settings by a specified custom quick config state.
    /// </summary>
    /// <param name="state">A custom qucik config state.</param>
    public void OverrideConfigSettingsByCustomQuickState(ICustomQuickConfigState state)
    {
        // TODO: Implement using existing RTW config settings!
    }
}
