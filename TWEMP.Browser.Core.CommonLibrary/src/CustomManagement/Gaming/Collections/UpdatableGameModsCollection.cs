// <copyright file="UpdatableGameModsCollection.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

/// <summary>
/// Represents an entity of a updatable collection of game modifications.
/// </summary>
public class UpdatableGameModsCollection
{
    private List<UpdatableGameModificationView> updatableGameModificationViews;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdatableGameModsCollection"/> class.
    /// </summary>
    /// <param name="header">A header containing metadata of this collection.</param>
    /// <param name="gameMods">A collection containing instances of the <see cref="UpdatableGameModificationView"/> class.</param>
    public UpdatableGameModsCollection(GameModsCollectionHeader header, ICollection<UpdatableGameModificationView> gameMods)
    {
        this.Metadata = header;
        this.updatableGameModificationViews = gameMods.ToList();
    }

    /// <summary>
    /// Gets the metadata of this collection.
    /// </summary>
    public GameModsCollectionHeader Metadata { get; private set; }

    /// <summary>
    /// Gets items of this collection.
    /// </summary>
    public UpdatableGameModificationView[] Items => this.updatableGameModificationViews.ToArray();

    /// <summary>
    /// Converts the collection to the <see cref="CustomModsCollection"/> type.
    /// </summary>
    /// <returns>An instance of the <see cref="CustomModsCollection"/> class.</returns>
    public CustomModsCollection ToCustomModsCollection()
    {
        Dictionary<string, string> mods = new ();

        foreach (UpdatableGameModificationView item in this.updatableGameModificationViews)
        {
            mods.Add(key: item.CurrentInfo.Location, value: item.CurrentInfo.ShortName);
        }

        return new CustomModsCollection(name: this.Metadata.Name, modifications: mods);
    }

    /// <summary>
    /// Updates the name of this collection.
    /// </summary>
    /// <param name="name">A new name for this collection.</param>
    public void UpdateName(string name)
    {
        if (!this.Metadata.Name.Equals(name))
        {
            this.Metadata.Name = name;
        }
    }

    /// <summary>
    /// Updates items of this collections.
    /// </summary>
    /// <param name="collection">A collection to update items of this collection.</param>
    public void UpdateItems(ICollection<UpdatableGameModificationView> collection)
    {
        this.ClearItems();

        foreach (UpdatableGameModificationView item in collection)
        {
            this.updatableGameModificationViews.Add(item);
        }
    }

    /// <summary>
    /// Clears items of this collections.
    /// </summary>
    public void ClearItems()
    {
        this.updatableGameModificationViews.Clear();
    }

    /// <summary>
    /// Add a new item to this collection.
    /// </summary>
    /// <param name="item">A new item of the <see cref="UpdatableGameModificationView"/> class.</param>
    public void AddItem(UpdatableGameModificationView item)
    {
        if (!this.ContainsItem(item))
        {
            this.updatableGameModificationViews.Add(item);
        }
    }

    /// <summary>
    /// Removes an item from this collection.
    /// </summary>
    /// <param name="item">A new item of the <see cref="UpdatableGameModificationView"/> class.</param>
    public void RemoveItem(UpdatableGameModificationView item)
    {
        if (this.ContainsItem(item))
        {
            this.updatableGameModificationViews.Remove(item);
        }
    }

    private bool ContainsItem(UpdatableGameModificationView targetItem)
    {
        foreach (UpdatableGameModificationView item in this.updatableGameModificationViews)
        {
            if (item.IdView.NumericId == targetItem.IdView.NumericId)
            {
                return true;
            }
        }

        return false;
    }
}
