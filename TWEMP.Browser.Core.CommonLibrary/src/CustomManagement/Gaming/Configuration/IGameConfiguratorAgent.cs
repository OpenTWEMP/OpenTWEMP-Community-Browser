// <copyright file="IGameConfiguratorAgent.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

/// <summary>
/// Defines API which must be implemented by any game configurator agent.
/// </summary>
public interface IGameConfiguratorAgent
{
    /// <summary>
    /// Gets game configuration settings by default.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public abstract CfgOptionsSubSet[] GetDefaultConfigSettings();

    /// <summary>
    /// Gets game configuration settings via a custom configuration state.
    /// </summary>
    /// <param name="state">A target custom game configuration state.</param>
    /// <returns>The array of game configuration settings.</returns>
    public abstract CfgOptionsSubSet[] GetCustomConfigSettings(ICustomConfigState state);
}
