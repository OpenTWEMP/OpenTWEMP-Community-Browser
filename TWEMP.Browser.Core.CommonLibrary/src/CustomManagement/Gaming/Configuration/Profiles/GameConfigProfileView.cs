// <copyright file="GameConfigProfileView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1011 // Closing square brackets should be spaced correctly

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

/// <summary>
/// Defines a game configuration profile entity as a shared view which should be used when creating more complex view entities.
/// </summary>
public record GameConfigProfileView
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigProfileView"/> class.
    /// </summary>
    public GameConfigProfileView()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigProfileView"/> class.
    /// </summary>
    /// <param name="configId">The ID of the game configuration profile.</param>
    /// <param name="configName">The name of the game configuration profile.</param>
    /// <param name="gameModLocation">The game mod location for the game configuration profile.</param>
    public GameConfigProfileView(Guid configId, string configName, string gameModLocation)
    {
        this.ConfigId = configId;
        this.ConfigName = configName;
        this.ConfigType = GameEngineSupportType.M2TW;
        this.GameModLocation = gameModLocation;
        this.ConfigOptions = Array.Empty<GameConfigOptionView>();
    }

    /// <summary>
    /// Gets or sets the ID of this game configuration profile.
    /// </summary>
    public Guid ConfigId { get; set; }

    /// <summary>
    /// Gets or sets the current game configuration type.
    /// </summary>
    public GameEngineSupportType ConfigType { get; set; }

    /// <summary>
    /// Gets or sets the name of this game configuration profile.
    /// </summary>
    public string? ConfigName { get; set; }

    /// <summary>
    /// Gets or sets the game mod location for this game configuration profile.
    /// </summary>
    public string? GameModLocation { get; set; }

    /// <summary>
    /// Gets or sets the configuration options for this game configuration profile.
    /// </summary>
    public GameConfigOptionView[]? ConfigOptions { get; set; }
}
