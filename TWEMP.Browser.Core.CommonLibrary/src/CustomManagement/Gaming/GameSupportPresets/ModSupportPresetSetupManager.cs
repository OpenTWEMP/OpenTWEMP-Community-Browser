// <copyright file="ModSupportPresetSetupManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

public class ModSupportPresetSetupManager
{
    private ModSupportPresetSetupManager()
    {
    }

    /// <summary>
    /// Creates a custom instance of the <see cref="ModSupportPresetSetupManager"/> class.
    /// </summary>
    /// <returns>Instance of the <see cref="ModSupportPresetSetupManager"/> class.</returns>
    public static ModSupportPresetSetupManager Create()
    {
        return new ModSupportPresetSetupManager();
    }

    /// <summary>
    /// Creates a game mods collection view via a collection of mod preset setting view entities.
    /// </summary>
    /// <param name="gameModifications">A collection containing objects of the <see cref="GameModificationInfo"/> type.</param>
    /// <param name="presetSettings">A collection containing objects of the <see cref="ModPresetSettingView"/> type.</param>
    /// <param name="redistributablePresets">A collection containing objects of the <see cref="RedistributableModPreset"/> type.</param>
    /// <returns>An instance of the <see cref="FullGameModsCollectionView"/> class.</returns>
    public FullGameModsCollectionView CreateGameModsCollectionViewByPresetSettings(
        List<GameModificationInfo> gameModifications,
        List<ModPresetSettingView> presetSettings,
        List<RedistributableModPreset> redistributablePresets)
    {
        List<UpdatableGameModificationView> gameModificationViews = new ();

        foreach (ModPresetSettingView setting in presetSettings)
        {
            GameModificationInfo gameModInfo = gameModifications.ElementAt(setting.Id.NumericId);

            UpdatableGameModificationView gameModView;
            if (setting.UseCustomizablePreset)
            {
                gameModView = UpdatableGameModificationView.CreateGameModificationViewByCustomizablePreset(setting.Id, gameModInfo);
            }
            else
            {
                RedistributableModPreset redistributableModPreset = redistributablePresets.Find(
                    preset => preset.Metadata.Guid == setting.RedistributablePresetGuid) !;

                gameModView = UpdatableGameModificationView.CreateGameModificationViewByRedistributablePreset(
                    setting.Id, gameModInfo, redistributableModPreset);
            }

            gameModificationViews.Add(gameModView);
        }

        return new FullGameModsCollectionView(gameModificationViews);
    }
}
