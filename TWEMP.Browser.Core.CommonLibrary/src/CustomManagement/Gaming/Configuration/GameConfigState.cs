// <copyright file="GameConfigState.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

/// <summary>
/// Represents the current state of a game configuration.
/// </summary>
public class GameConfigState
{
    private readonly GameSupportProvider gameSupportProvider;
    private readonly GameModificationInfo gameModificationInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigState"/> class.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    private GameConfigState(GameSupportProvider provider, GameModificationInfo info)
    {
        this.gameSupportProvider = provider;
        this.gameModificationInfo = info;

        this.CurrentSettings = InitializeSettingsByDefault(
            provider: this.gameSupportProvider, info: this.gameModificationInfo);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigState"/> class.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    /// <param name="options">Target game configuration options.</param>
    private GameConfigState(GameSupportProvider provider, GameModificationInfo info, GameCfgSection[] options)
    {
        this.gameSupportProvider = provider;
        this.gameModificationInfo = info;

        this.CurrentSettings = options;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigState"/> class.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    /// <param name="state">A target custom game configuration state.</param>
    private GameConfigState(GameSupportProvider provider, GameModificationInfo info, ICustomConfigState state)
    {
        this.gameSupportProvider = provider;
        this.gameModificationInfo = info;

        this.CurrentSettings = state.RetrieveCurrentSettings();
    }

    /// <summary>
    /// Gets or sets current configuration settings.
    /// </summary>
    public GameCfgSection[] CurrentSettings { get; set; }

    /// <summary>
    /// Creates a game configuration state with default settings.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    /// <returns>A new instance of the <see cref="GameConfigState"/> class.</returns>
    public static GameConfigState CreateByDefault(GameSupportProvider provider, GameModificationInfo info)
    {
        switch (provider.GameEngine)
        {
            case GameEngineSupportType.TWEMP:
            case GameEngineSupportType.M2TW:
            case GameEngineSupportType.RTW:
            default:
                return new GameConfigState(provider, info);
        }
    }

    /// <summary>
    /// Creates a game configuration state via a custom configuration options.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    /// <param name="options">Target game configuration options.</param>
    /// <returns>A new instance of the <see cref="GameConfigState"/> class.</returns>
    public static GameConfigState Create(
        GameSupportProvider provider, GameModificationInfo info, GameCfgSection[] options)
    {
        switch (provider.GameEngine)
        {
            case GameEngineSupportType.TWEMP:
            case GameEngineSupportType.M2TW:
            case GameEngineSupportType.RTW:
            default:
                return new GameConfigState(provider, info, options);
        }
    }

    /// <summary>
    /// Creates a game configuration state via a custom configuration state.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    /// <param name="state">A target custom game configuration state.</param>
    /// <returns>A new instance of the <see cref="GameConfigState"/> class.</returns>
    public static GameConfigState Create(
        GameSupportProvider provider, GameModificationInfo info, ICustomConfigState state)
    {
        switch (provider.GameEngine)
        {
            case GameEngineSupportType.TWEMP:
            case GameEngineSupportType.M2TW:
            case GameEngineSupportType.RTW:
            default:
                return new GameConfigState(provider, info, state);
        }
    }

    private static GameCfgSection[] InitializeSettingsByDefault(GameSupportProvider provider, GameModificationInfo info)
    {
        return Array.Empty<GameCfgSection>(); // TODO: Implement using existing M2TW config settings!
    }
}
