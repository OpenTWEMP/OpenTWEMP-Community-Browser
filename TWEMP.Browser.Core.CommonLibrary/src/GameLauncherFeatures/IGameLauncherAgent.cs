// <copyright file="IGameLauncherAgent.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1124 // Do not use regions
#pragma warning disable SA1600 // ElementsMustBeDocumented

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

#region Placeholder classes for possible game launcher agents.

public class TwempGameLauncher : IGameLauncherAgent
{
    public TwempGameLauncher()
    {
    }

    public void Execute()
    {
        // code specific for the OpenTWEMP Game Engine
    }
}

public class M2TWGameLauncher : IGameLauncherAgent
{
    public M2TWGameLauncher()
    {
    }

    public void Execute()
    {
        // code specific for the M2TW
    }
}

public class RTWGameLauncher : IGameLauncherAgent
{
    public RTWGameLauncher()
    {
    }

    public void Execute()
    {
        // code specific for the RTW
    }
}

#endregion

