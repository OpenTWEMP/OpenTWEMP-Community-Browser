// <copyright file="GameModificationIdView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

using Newtonsoft.Json;

/// <summary>
/// Represents a game modification identifier which can be used as a unique key by more complex view entities.
/// </summary>
public record GameModificationIdView
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameModificationIdView"/> class.
    /// </summary>
    public GameModificationIdView()
    {
        this.TextId = Convert.ToString(this.NumericId);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameModificationIdView"/> class.
    /// </summary>
    /// <param name="id">An object used by the game modification as the identifier.</param>
    public GameModificationIdView(object? id)
    {
        this.NumericId = Convert.ToInt32(id);
        this.TextId = Convert.ToString(this.NumericId);
    }

    // TODO: [BETA2027_002] Define a constructor with GameModificationInfo object's ID as a parameter.

    /// <summary>
    /// Gets or sets the identifier as a unsigned integer number.
    /// </summary>
    public int NumericId { get; set; }

    // TODO: [BETA2027_002] The ID public property should be related with GameModificationInfo object's ID.

    /// <summary>
    /// Gets the identifier as a Unicode string.
    /// </summary>
    [JsonIgnore]
    public string TextId { get; }
}
