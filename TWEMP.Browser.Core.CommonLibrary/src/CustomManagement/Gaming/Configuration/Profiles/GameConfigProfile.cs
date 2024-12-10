// <copyright file="GameConfigProfile.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

/// <summary>
/// Represents an abstract entity for a game configuration profile.
/// </summary>
public class GameConfigProfile
{
    private const string DefaultName = "My Configuration by Default";

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigProfile"/> class.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    public GameConfigProfile(GameSupportProvider provider, GameModificationInfo info)
    {
        this.Id = Guid.NewGuid();
        this.ConfigType = provider.GameEngine;
        this.TargetGameModInfo = info;
        this.Name = DefaultName;
        this.ConfigState = GameConfigState.CreateByDefault(provider, info);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigProfile"/> class.
    /// </summary>
    /// <param name="id">The game configuration profile ID.</param>
    /// <param name="name">The game configuration profile name.</param>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    /// <param name="options">Target game configuration options.</param>
    public GameConfigProfile(
        Guid id, string? name, GameSupportProvider provider, GameModificationInfo info, GameCfgSection[] options)
    {
        this.Id = id;

        if (name == null)
        {
            this.Name = $"M2TW Config Profile for {info.ShortName}";
        }
        else
        {
            this.Name = name;
        }

        this.ConfigType = provider.GameEngine;
        this.TargetGameModInfo = info;

        this.ConfigState = GameConfigState.Create(provider, info, options);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigProfile"/> class.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    /// <param name="state">A target custom game configuration state.</param>
    public GameConfigProfile(
        GameSupportProvider provider, GameModificationInfo info, ICustomConfigState state)
    {
        this.Id = Guid.NewGuid();
        this.ConfigType = provider.GameEngine;
        this.TargetGameModInfo = info;
        this.Name = DefaultName;
        this.ConfigState = GameConfigState.Create(provider, info, state);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigProfile"/> class.
    /// </summary>
    /// <param name="id">The game configuration profile ID.</param>
    /// <param name="profile">A template game configuration profile.</param>
    public GameConfigProfile(Guid id, GameConfigProfile profile)
    {
        this.Id = id;
        this.ConfigType = profile.ConfigType;
        this.TargetGameModInfo = profile.TargetGameModInfo;
        this.Name = $"{profile.Name} - COPY";
        this.ConfigState = profile.ConfigState;
    }

    /// <summary>
    /// Gets the GUID of this game configuration profile.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the current game configuration type.
    /// </summary>
    public GameEngineSupportType ConfigType { get; }

    /// <summary>
    /// Gets the target game modification info.
    /// </summary>
    public GameModificationInfo TargetGameModInfo { get; }

    /// <summary>
    /// Gets or sets the name of this game configuration profile.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the current game configuration state for this profile.
    /// </summary>
    public GameConfigState ConfigState { get; set; }

    /// <summary>
    /// Creates the default template of the game config profile by a game modification view.
    /// </summary>
    /// <param name="gameModificationInfo">The game modification info.</param>
    /// <returns>A new instanse of the <see cref="GameConfigProfile"/> class.</returns>
    public static GameConfigProfile CreateDefaultTemplate(GameModificationInfo gameModificationInfo) =>
        new (provider: new GameSupportProvider(GameEngineSupportType.M2TW), info: gameModificationInfo);
}
