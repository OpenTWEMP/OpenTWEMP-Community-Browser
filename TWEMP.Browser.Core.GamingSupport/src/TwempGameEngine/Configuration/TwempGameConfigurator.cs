// <copyright file="TwempGameConfigurator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.GamingSupport.TwempGameEngine.Configuration;

using TWEMP.Browser.Core.CommonLibrary;
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
    /// Gets OpenTWEMP configuration settings by default.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetDefaultConfigSettings()
    {
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing OpenTWEMP config settings!
    }

    /// <summary>
    /// Gets OpenTWEMP configuration settings via a custom configuration state.
    /// </summary>
    /// <param name="state">A target custom game configuration state.</param>
    /// <returns>The array of game configuration settings.</returns>
    public GameCfgSection[] GetCustomConfigSettings(ICustomConfigState state)
    {
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing OpenTWEMP config settings!
    }
}
