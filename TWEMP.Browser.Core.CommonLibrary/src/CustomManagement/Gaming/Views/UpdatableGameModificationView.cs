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
    private CustomizableModPreset customizableModPreset;
    private RedistributableModPreset redistributableModPreset;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdatableGameModificationView"/> class.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="info">The game modification info entity for this view.</param>
    private UpdatableGameModificationView(GameModificationIdView idView, GameModificationInfo info)
    {
        this.IdView = idView;
        this.CurrentInfo = info;

        this.customizableModPreset = CustomizableModPreset.CreateDefaultTemplate(info.Location);
        this.redistributableModPreset = RedistributableModPreset.CreateDefaultTemplate();

        this.ActivePreset = ModSupportPreset.CreateDefaultTemplate();
        this.UseCustomizablePreset = false;
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
    /// Gets a value indicating whether the current game modification uses a customizable preset.
    /// This property is 'true' for a customizable preset and 'false' for a redistributable preset.
    /// </summary>
    public bool UseCustomizablePreset { get; private set; }

    /// <summary>
    /// Creates a new instance of the <see cref="UpdatableGameModificationView"/> record
    /// using an object of <see cref="RedistributableModPreset"/> class.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="info">The game modification info entity for this view.</param>
    /// <param name="preset">The redistributable preset for this game modification.</param>
    /// <returns>A new configured instance of the <see cref="UpdatableGameModificationView"/> record.</returns>
    public static UpdatableGameModificationView CreateGameModificationViewByRedistributablePreset(
        GameModificationIdView idView,
        GameModificationInfo info,
        RedistributableModPreset preset)
    {
        UpdatableGameModificationView gameModificationView = new (idView, info);
        gameModificationView.SelectRedistributableModPreset(preset);
        return gameModificationView;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="UpdatableGameModificationView"/> record
    /// using an object of <see cref="CustomizableModPreset"/> class.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="info">The game modification info entity for this view.</param>
    /// <returns>A new configured instance of the <see cref="UpdatableGameModificationView"/> record.</returns>
    public static UpdatableGameModificationView CreateGameModificationViewByCustomizablePreset(
        GameModificationIdView idView,
        GameModificationInfo info)
    {
        UpdatableGameModificationView gameModificationView = new (idView, info);
        gameModificationView.SelectCustomizableModPreset();
        return gameModificationView;
    }

    /// <summary>
    /// Selects the current preset of the <see cref="RedistributableModPreset"/> type
    /// as the active mod support preset for this game modification.
    /// </summary>
    public void SelectRedistributableModPreset()
    {
        this.ActivePreset = this.redistributableModPreset.Data;
        this.UseCustomizablePreset = false;
    }

    /// <summary>
    /// Selects the current preset of the <see cref="RedistributableModPreset"/> type
    /// as the active mod support preset for this game modification.
    /// </summary>
    /// <param name="preset">The redistributable preset for this game modification.</param>
    public void SelectRedistributableModPreset(RedistributableModPreset preset)
    {
        this.redistributableModPreset = preset;
        this.ActivePreset = preset.Data;
        this.UseCustomizablePreset = false;
    }

    /// <summary>
    /// Selects the current preset of the <see cref="CustomizableModPreset"/> type
    /// as the active mod support preset for this game modification.
    /// </summary>
    public void SelectCustomizableModPreset()
    {
        this.ActivePreset = this.customizableModPreset.Data;
        this.UseCustomizablePreset = true;
    }

    /// <summary>
    /// Resets both <see cref="CustomizableModPreset"/> and <see cref="RedistributableModPreset"/> presets
    /// to its default settings for this game modification.
    /// </summary>
    public void ResetAllModPresetsToDefaultSettings()
    {
        this.customizableModPreset = CustomizableModPreset.CreateDefaultTemplate(this.CurrentInfo.Location);
        this.redistributableModPreset = RedistributableModPreset.CreateDefaultTemplate();
    }
}
