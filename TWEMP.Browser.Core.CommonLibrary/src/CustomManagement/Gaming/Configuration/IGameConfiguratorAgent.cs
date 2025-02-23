﻿// <copyright file="IGameConfiguratorAgent.cs" company="The OpenTWEMP Project">
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
    public abstract GameCfgSection[] GetDefaultConfigSettings();

    /// <summary>
    /// Gets current game configuration settings.
    /// </summary>
    /// <returns>The array of game configuration settings.</returns>
    public abstract GameCfgSection[] GetCurrentConfigSettings();

    /// <summary>
    /// Overrides current game configuration settings by a specified custom quick config state.
    /// </summary>
    /// <param name="state">A custom qucik config state.</param>
    public abstract void OverrideConfigSettingsByCustomQuickState(ICustomQuickConfigState state);
}
