// <copyright file="TwempGameConfigurator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.GamingSupport.TwempGameEngine.Configuration;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

/// <summary>
/// Implements the game configurator agent for the "OpenTWEMP Game Engine" game engine (TWEMP).
/// </summary>
public class TwempGameConfigurator : IGameConfiguratorAgent
{
    private readonly GameModificationInfo gameModificationInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="TwempGameConfigurator"/> class.
    /// </summary>
    /// <param name="info">Information about a target game modification.</param>
    public TwempGameConfigurator(GameModificationInfo info)
    {
        this.gameModificationInfo = info;
    }

    /// <summary>
    /// Gets TWEMP configuration settings by default.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetDefaultConfigSettings()
    {
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing OpenTWEMP config settings!
    }

    /// <summary>
    /// Gets current TWEMP configuration settings.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetCurrentConfigSettings()
    {
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing OpenTWEMP config settings!
    }

    /// <summary>
    /// Overrides current TWEMP configuration settings by a specified custom quick config state.
    /// </summary>
    /// <param name="state">A custom qucik config state.</param>
    public void OverrideConfigSettingsByCustomQuickState(ICustomQuickConfigState state)
    {
        // TODO: Implement using existing OpenTWEMP config settings!
    }
}
