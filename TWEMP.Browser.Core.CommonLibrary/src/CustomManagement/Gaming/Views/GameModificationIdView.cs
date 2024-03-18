// <copyright file="GameModificationIdView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

/// <summary>
/// Represents a game modification identifier which can be used as a unique key by more complex view entities.
/// </summary>
public record GameModificationIdView
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameModificationIdView"/> class.
    /// </summary>
    /// <param name="id">An object used by the game modification as the identifier.</param>
    public GameModificationIdView(object? id)
    {
        this.NumericId = Convert.ToUInt32(id);
        this.TextId = Convert.ToString(this.NumericId);
    }

    /// <summary>
    /// Gets the identifier as a unsigned integer number.
    /// </summary>
    public uint NumericId { get; }

    /// <summary>
    /// Gets the identifier as a Unicode string.
    /// </summary>
    public string TextId { get; }
}
