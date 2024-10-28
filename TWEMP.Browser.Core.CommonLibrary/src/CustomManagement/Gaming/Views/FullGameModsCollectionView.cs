// <copyright file="FullGameModsCollectionView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

/// <summary>
/// Defines a full collection entity as a shared view which is intended to display all game modifications via UI.
/// </summary>
public class FullGameModsCollectionView
{
    private readonly List<UpdatableGameModificationView> currentGameModificationViews;

    /// <summary>
    /// Initializes a new instance of the <see cref="FullGameModsCollectionView"/> class.
    /// </summary>
    /// <param name="gameModificationViews">A collection containing from objects
    /// of the <see cref="UpdatableGameModificationView"/> class.</param>
    public FullGameModsCollectionView(ICollection<UpdatableGameModificationView> gameModificationViews)
    {
        this.currentGameModificationViews = gameModificationViews.ToList();
    }

    /// <summary>
    /// Gets the array containing objects of the <see cref="UpdatableGameModificationView"/> class.
    /// </summary>
    public UpdatableGameModificationView[] GameModificationViews
    {
        get
        {
            return this.currentGameModificationViews.ToArray();
        }
    }

    /// <summary>
    /// Selects an instance of the <see cref="UpdatableGameModificationView"/> class
    /// by a target identifier entity.
    /// </summary>
    /// <param name="gameModificationId">The identifier of a game modification.</param>
    /// <returns>An instance of the <see cref="UpdatableGameModificationView"/> class.</returns>
    public UpdatableGameModificationView? SelectGameModificationById(GameModificationIdView gameModificationId)
    {
        foreach (UpdatableGameModificationView gameModificationView in this.currentGameModificationViews)
        {
            if (gameModificationView.IdView.NumericId == gameModificationId.NumericId)
            {
                return gameModificationView;
            }
        }

        return null;
    }

    /// <summary>
    /// Selects an instance of the <see cref="UpdatableGameModificationView"/> class
    /// by a target identifier entity.
    /// </summary>
    /// <param name="gameModificationId">The identifier of a game modification.</param>
    /// <returns>An instance of the <see cref="UpdatableGameModificationView"/> class.</returns>
    public UpdatableGameModificationView? SelectGameModificationById(int gameModificationId)
    {
        foreach (UpdatableGameModificationView gameModificationView in this.currentGameModificationViews)
        {
            if (gameModificationView.IdView.NumericId == gameModificationId)
            {
                return gameModificationView;
            }
        }

        return null;
    }

    /// <summary>
    /// Selects an instance of the <see cref="UpdatableGameModificationView"/> class
    /// by a target identifier entity.
    /// </summary>
    /// <param name="gameModificationId">The identifier of a game modification.</param>
    /// <returns>An instance of the <see cref="UpdatableGameModificationView"/> class.</returns>
    public UpdatableGameModificationView? SelectGameModificationById(string gameModificationId)
    {
        foreach (UpdatableGameModificationView gameModificationView in this.currentGameModificationViews)
        {
            if (gameModificationView.IdView.TextId.Equals(gameModificationId))
            {
                return gameModificationView;
            }
        }

        return null;
    }

    /// <summary>
    /// Sets the current preset of the <see cref="CustomizableModPreset"/> type
    /// as the active mod support preset for all game modifications.
    /// </summary>
    public void ActivateCustomizablePresetsForAllMods()
    {
        foreach (UpdatableGameModificationView gameModificationView in this.currentGameModificationViews)
        {
            gameModificationView.SelectCustomizableModPreset();
        }
    }

    /// <summary>
    /// Sets the current preset of the <see cref="RedistributableModPreset"/> type
    /// as the active mod support preset for all game modifications.
    /// </summary>
    public void ActivateRedistributablePresetsForAllMods()
    {
        foreach (UpdatableGameModificationView gameModificationView in this.currentGameModificationViews)
        {
            gameModificationView.SelectRedistributableModPreset();
        }
    }

    /// <summary>
    /// Resets both <see cref="CustomizableModPreset"/> and <see cref="RedistributableModPreset"/> presets
    /// to its default settings for all game modifications.
    /// </summary>
    public void ResetAllModPresetsToDefaultSettings()
    {
        foreach (UpdatableGameModificationView gameModificationView in this.currentGameModificationViews)
        {
            gameModificationView.ResetAllModPresetsToDefaultSettings();
        }
    }

    /// <summary>
    /// Gets the current game collection data as the array of <see cref="ModPresetSettingView"/> objects.
    /// </summary>
    /// <returns>The array of <see cref="ModPresetSettingView"/> objects.</returns>
    public ModPresetSettingView[] GetModPresetSettings()
    {
        ModPresetSettingView[] presetSettings = new ModPresetSettingView[this.GameModificationViews.Length];

        for (int index = 0; index < presetSettings.Length; index++)
        {
            UpdatableGameModificationView gameModView = this.GameModificationViews[index];

            presetSettings[index] = new (
                idView: gameModView.IdView,
                redistributablePresetGuid: gameModView.GetRedistributablePresetId(),
                useCustomizablePreset: gameModView.UseCustomizablePreset);
        }

        return presetSettings;
    }
}
