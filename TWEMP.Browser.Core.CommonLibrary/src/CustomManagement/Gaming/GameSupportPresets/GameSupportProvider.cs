// <copyright file="GameSupportProvider.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

using TWEMP.Browser.Core.CommonLibrary.GameLauncherFeatures;

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
        this.GameLauncher = InitializeGameLauncher(this.GameEngine);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameSupportProvider"/> class.
    /// </summary>
    /// <param name="gameEngineSupportType">The game engine support type.</param>
    public GameSupportProvider(GameEngineSupportType gameEngineSupportType)
    {
        this.GameEngine = gameEngineSupportType;
        this.GameLauncher = InitializeGameLauncher(this.GameEngine);
    }

    /// <summary>
    /// Gets the game engine support type used by the provider.
    /// </summary>
    public GameEngineSupportType GameEngine { get; }

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
}
