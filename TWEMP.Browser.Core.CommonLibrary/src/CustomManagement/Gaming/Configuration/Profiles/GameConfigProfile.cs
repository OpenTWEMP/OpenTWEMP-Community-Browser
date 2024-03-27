// <copyright file="GameConfigProfile.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

/// <summary>
/// Represents an abstract entity for a game configuration profile.
/// </summary>
public abstract class GameConfigProfile
{
    private const string DefaultName = "My Configuration by Default";

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigProfile"/> class.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    protected GameConfigProfile(GameSupportProvider provider, GameModificationInfo info)
    {
        this.Id = Guid.NewGuid();
        this.Name = DefaultName;

        this.State = GameConfigState.CreateByDefault(provider, info);
    }

    /// <summary>
    /// Gets the GUID of this game configuration profile.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets the name of this game configuration profile.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the current game configuration state for this profile.
    /// </summary>
    public GameConfigState State { get; set; }
}
