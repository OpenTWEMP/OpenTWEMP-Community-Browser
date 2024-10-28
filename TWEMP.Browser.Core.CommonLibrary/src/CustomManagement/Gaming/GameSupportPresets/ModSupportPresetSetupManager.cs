// <copyright file="ModSupportPresetSetupManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;
using TWEMP.Browser.Core.CommonLibrary.Serialization;

public class ModSupportPresetSetupManager
{
    private const string PresetSetupHomeFolderName = "support";
    private const string PresetSetupConfigFileName = "preset_setup.json";

    private readonly CustomGameSetupManager gameSetupManager;
    private readonly GameSupportManager gameSupportManager;

    private readonly DirectoryInfo presetSetupHomeDirectoryInfo;
    private readonly FileInfo presetSetupConfigFileInfo;

    private List<ModPresetSettingView> presetSettingViews;
    private List<UpdatableGameModificationView> updatableGameModificationViews;

    private ModSupportPresetSetupManager(CustomGameSetupManager gameSetupManager, GameSupportManager gameSupportManager)
    {
        this.gameSetupManager = gameSetupManager;
        this.gameSupportManager = gameSupportManager;

        string presetSetupHomeDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), PresetSetupHomeFolderName);
        this.presetSetupHomeDirectoryInfo = new DirectoryInfo(presetSetupHomeDirectoryPath);

        if (!this.presetSetupHomeDirectoryInfo.Exists)
        {
            this.presetSetupHomeDirectoryInfo.Create();
        }

        string presetSetupConfigFilePath = Path.Combine(presetSetupHomeDirectoryPath, PresetSetupConfigFileName);
        this.presetSetupConfigFileInfo = new FileInfo(presetSetupConfigFilePath);

        List<GameModificationInfo> gameMods = this.gameSetupManager.TotalModificationsList;

        if (this.presetSetupConfigFileInfo.Exists)
        {
            List<RedistributableModPreset> modPresets = this.gameSupportManager.AvailableModSupportPresets;
            this.presetSettingViews = ReadPresetSetupConfigFile(this.presetSetupConfigFileInfo).ToList();
            this.updatableGameModificationViews = GetGameModificationViews(
                gameMods, modPresets, this.presetSettingViews);
        }
        else
        {
            this.updatableGameModificationViews = GetGameModificationViewsByDefault(gameMods);
            this.presetSettingViews = GetPresetSettingsByDefault(this.updatableGameModificationViews);

            CreatePresetSetupConfigFileByDefault(this.presetSettingViews, this.presetSetupConfigFileInfo);
        }

        this.CurrentGameModsCollectionView = new FullGameModsCollectionView(this.updatableGameModificationViews);
    }

    /// <summary>
    /// Gets the current view of a full collection entity of game modifications.
    /// </summary>
    public FullGameModsCollectionView CurrentGameModsCollectionView { get; private set; }

    /// <summary>
    /// Creates a custom instance of the <see cref="ModSupportPresetSetupManager"/> class.
    /// </summary>
    /// <param name="gameSetupManager">The instance of the <see cref="CustomGameSetupManager"/> class.</param>
    /// <param name="gameSupportManager">The instance of the <see cref="GameSupportManager"/> class.</param>
    /// <returns>Instance of the <see cref="ModSupportPresetSetupManager"/> class.</returns>
    public static ModSupportPresetSetupManager Create(
        CustomGameSetupManager gameSetupManager, GameSupportManager gameSupportManager)
    {
        return new ModSupportPresetSetupManager(gameSetupManager, gameSupportManager);
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

    private static List<UpdatableGameModificationView> GetGameModificationViews(
        List<GameModificationInfo> gameMods,
        List<RedistributableModPreset> modPresets,
        List<ModPresetSettingView> presetSettingViews)
    {
        List<UpdatableGameModificationView> gameModViews = new ();

        foreach (ModPresetSettingView presetSetting in presetSettingViews)
        {
            GameModificationInfo gameMod = gameMods.ElementAt(presetSetting.Id!.NumericId);

            UpdatableGameModificationView gameModView;
            if (presetSetting.UseCustomizablePreset)
            {
                gameModView = UpdatableGameModificationView.CreateGameModificationViewByCustomizablePreset(
                    presetSetting.Id, gameMod);
            }
            else
            {
                RedistributableModPreset redistributableModPreset = modPresets.Find(
                    preset => preset.Metadata.Guid == presetSetting.RedistributablePresetGuid) !;

                gameModView = UpdatableGameModificationView.CreateGameModificationViewByRedistributablePreset(
                    presetSetting.Id, gameMod, redistributableModPreset);
            }

            gameModViews.Add(gameModView);
        }

        return gameModViews;
    }

    private static List<UpdatableGameModificationView> GetGameModificationViewsByDefault(List<GameModificationInfo> gameMods)
    {
        List<UpdatableGameModificationView> gameModificationViews = new ();

        for (int modIndex = 0; modIndex < gameMods.Count; modIndex++)
        {
            UpdatableGameModificationView gameModificationView =
                UpdatableGameModificationView.CreateGameModificationViewByDefaultPreset(
                    new GameModificationIdView(modIndex), gameMods[modIndex]);

            gameModificationViews.Add(gameModificationView);
        }

        return gameModificationViews;
    }

    private static List<ModPresetSettingView> GetPresetSettingsByDefault(List<UpdatableGameModificationView> gameModViews)
    {
        List<ModPresetSettingView> presetSettings = new ();

        foreach (UpdatableGameModificationView view in gameModViews)
        {
            ModPresetSettingView presetSetting = new (
                idView: view.IdView,
                redistributablePresetGuid: view.GetRedistributablePresetId(),
                useCustomizablePreset: view.UseCustomizablePreset);

            presetSettings.Add(presetSetting);
        }

        return presetSettings;
    }

    private static void CreatePresetSetupConfigFileByDefault(
        ICollection<ModPresetSettingView> presetSettingViews, FileInfo presetSetupConfigFileInfo)
    {
        AppSerializer.SerializeToJson(presetSettingViews, presetSetupConfigFileInfo.FullName);
    }

    private static ModPresetSettingView[] ReadPresetSetupConfigFile(FileInfo presetSetupConfigFileInfo)
    {
        return AppSerializer.DeserializeFromJson<ModPresetSettingView[]>(presetSetupConfigFileInfo.FullName);
    }
}
