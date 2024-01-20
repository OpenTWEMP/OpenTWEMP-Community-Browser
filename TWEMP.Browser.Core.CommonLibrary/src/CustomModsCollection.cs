// <copyright file="CustomModsCollection.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;

/// <summary>
/// Represents an object of a custom collection of game modifications.
/// </summary>
public class CustomModsCollection
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomModsCollection"/> class.
    /// </summary>
    /// <param name="name">Collection's name.</param>
    /// <param name="modifications">Collection's game modifications.</param>
    public CustomModsCollection(string name, Dictionary<string, string> modifications)
    {
        this.Name = name;
        this.Modifications = modifications;
    }

    /// <summary>
    /// Gets or sets collection's name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets collection's game modifications.
    /// </summary>
    public Dictionary<string, string> Modifications { get; set; }

    /// <summary>
    /// Wrapping method. Deprecate this method when resolving its external dependencies via the CustomGameCollectionsManager class.
    /// </summary>
    /// <param name="collections">User's collections of game modifications.</param>
    public static void WriteExistingCollections(List<CustomModsCollection> collections)
    {
        CustomGameCollectionsManager.WriteExistingCollections(collections);
    }

    /// <summary>
    /// Wrapping method. Deprecate this method when resolving its external dependencies via the CustomGameCollectionsManager class.
    /// </summary>
    public static void WriteFavoriteCollection()
    {
        // Deprecate this method when resolving its external dependencies via the CustomGameCollectionsManager class.
        CustomGameCollectionsManager.WriteFavoriteCollection();
    }
}
