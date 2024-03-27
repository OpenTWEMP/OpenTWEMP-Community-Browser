// <copyright file="IGameLauncherAgent.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.GameLauncherFeatures;

/// <summary>
/// Defines API which must be implemented by any game launcher agent.
/// </summary>
public interface IGameLauncherAgent
{
    /// <summary>
    /// Launches a game according to the rules of its game launcher agent.
    /// </summary>
    public abstract void Execute();
}
