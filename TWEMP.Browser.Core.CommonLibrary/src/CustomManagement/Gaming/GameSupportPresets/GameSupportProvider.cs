// <copyright file="GameSupportProvider.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

// TODO: Do not use GameLauncher property while M2TWGameLauncher is in progress!
#define LAUNCHER_AGENT
#undef LAUNCHER_AGENT

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

using TWEMP.Browser.Core.BaseDataTypes;

#if LAUNCHER_AGENT
using TWEMP.Browser.Core.CommonLibrary.GameLauncherFeatures;
#endif

/// <summary>
/// Represents a game support provider type.
/// </summary>
public class GameSupportProvider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameSupportProvider"/> class.
    /// </summary>
    public GameSupportProvider()
    {
        this.GameEngine = GameEngineSupportType.TWEMP;

#if LAUNCHER_AGENT
        this.GameLauncher = InitializeGameLauncher(this.GameEngine);
#endif
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameSupportProvider"/> class.
    /// </summary>
    /// <param name="gameEngineSupportType">The game engine support type.</param>
    public GameSupportProvider(GameEngineSupportType gameEngineSupportType)
    {
        this.GameEngine = gameEngineSupportType;

#if LAUNCHER_AGENT
        this.GameLauncher = InitializeGameLauncher(this.GameEngine);
#endif
    }

    /// <summary>
    /// Gets the game engine support type used by the provider.
    /// </summary>
    public GameEngineSupportType GameEngine { get; }

#if LAUNCHER_AGENT
    /// <summary>
    /// Gets the game launcher agent used by the provider.
    /// </summary>
    public IGameLauncherAgent GameLauncher { get; }

    private static IGameLauncherAgent InitializeGameLauncher(GameEngineSupportType gameEngineSupportType)
    {
        switch (gameEngineSupportType)
        {
            case GameEngineSupportType.TWEMP:
                return new TwempGameLauncher();
            case GameEngineSupportType.M2TW:
                return new M2TWGameLauncher();
            case GameEngineSupportType.RTW:
                return new RTWGameLauncher();
            default:
                return new TwempGameLauncher();
        }
    }
#endif
}
