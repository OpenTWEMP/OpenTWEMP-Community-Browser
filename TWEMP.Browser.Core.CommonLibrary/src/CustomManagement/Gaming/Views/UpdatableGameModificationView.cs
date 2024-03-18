// <copyright file="UpdatableGameModificationView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

/// <summary>
/// Defines a game modification entity as a shared view which can be displayed via UI and updated on demand.
/// </summary>
public class UpdatableGameModificationView
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdatableGameModificationView"/> class.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="info">The game modification info entity for this view.</param>
    private UpdatableGameModificationView(GameModificationIdView idView, GameModificationInfo info)
    {
        this.IdView = idView;
        this.CurrentInfo = info;
        this.ActivePreset = ModSupportPreset.CreateDefaultTemplate();
    }

    /// <summary>
    /// Gets the game modification identifier entity for this view.
    /// </summary>
    public GameModificationIdView IdView { get; }

    /// <summary>
    /// Gets the current game modification info entity for this view.
    /// </summary>
    public GameModificationInfo CurrentInfo { get; }

    /// <summary>
    /// Gets the active mod support preset entity for this view.
    /// </summary>
    public ModSupportPreset ActivePreset { get; private set; }

    /// <summary>
    /// Creates a new instance of the <see cref="UpdatableGameModificationView"/> record
    /// using an object of <see cref="RedistributableModPreset"/> class.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="info">The game modification info entity for this view.</param>
    /// <param name="redistributablePreset">The redistributable preset for this game modification.</param>
    /// <returns>A new configured instance of the <see cref="UpdatableGameModificationView"/> record.</returns>
    public static UpdatableGameModificationView CreateGameModificationViewByRedistributablePreset(
        GameModificationIdView idView,
        GameModificationInfo info,
        RedistributableModPreset redistributablePreset)
    {
        UpdatableGameModificationView gameModificationView = CreateGameModificationView(idView, info);
        gameModificationView.ActivePreset = redistributablePreset.Data;
        return gameModificationView;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="UpdatableGameModificationView"/> record
    /// using an object of <see cref="CustomizableModPreset"/> class.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="info">The game modification info entity for this view.</param>
    /// <param name="customizablePreset">The customizable preset for this game modification.</param>
    /// <returns>A new configured instance of the <see cref="UpdatableGameModificationView"/> record.</returns>
    public static UpdatableGameModificationView CreateGameModificationViewByCustomizablePreset(
        GameModificationIdView idView,
        GameModificationInfo info,
        CustomizableModPreset customizablePreset)
    {
        UpdatableGameModificationView gameModificationView = CreateGameModificationView(idView, info);
        gameModificationView.ActivePreset = customizablePreset.Data;
        return gameModificationView;
    }

    private static UpdatableGameModificationView CreateGameModificationView(GameModificationIdView idView, GameModificationInfo info)
    {
        return new UpdatableGameModificationView(idView, info);
    }
}
