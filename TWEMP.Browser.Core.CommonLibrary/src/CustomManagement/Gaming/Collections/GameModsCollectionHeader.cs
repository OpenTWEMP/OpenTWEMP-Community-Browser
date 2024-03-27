// <copyright file="GameModsCollectionHeader.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;

/// <summary>
/// Represents a header containing metadata for a collection of game mods.
/// </summary>
public record GameModsCollectionHeader
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameModsCollectionHeader"/> class.
    /// </summary>
    /// <param name="id">The GUID of a game mods collection.</param>
    /// <param name="name">The name of a game mods collection.</param>
    public GameModsCollectionHeader(string name)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
    }

    /// <summary>
    /// Gets the GUID of this collection.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets the name of a collection.
    /// </summary>
    public string Name { get; set; }
}
