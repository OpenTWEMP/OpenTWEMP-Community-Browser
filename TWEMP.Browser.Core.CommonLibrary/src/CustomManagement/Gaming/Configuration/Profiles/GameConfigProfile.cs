﻿// <copyright file="GameConfigProfile.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;

using TWEMP.Browser.Core.BaseDataTypes;
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

        this.Name = DefaultName;
        this.ConfigState = GameConfigState.CreateByDefault(provider, info);
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

        this.Name = DefaultName;
        this.ConfigState = GameConfigState.Create(provider, info, state);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigProfile"/> class.
    /// </summary>
    /// <param name="profile">A template game configuration profile.</param>
    public GameConfigProfile(GameConfigProfile profile)
    {
        this.Id = Guid.NewGuid();
        this.ConfigType = profile.ConfigType;

        this.Name = $"{profile.Name} Copy";
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
    /// Gets or sets the name of this game configuration profile.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the current game configuration state for this profile.
    /// </summary>
    public GameConfigState ConfigState { get; set; }
}