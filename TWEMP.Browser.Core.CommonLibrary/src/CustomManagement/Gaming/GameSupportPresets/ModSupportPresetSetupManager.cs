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

        if (this.presetSetupConfigFileInfo.Exists)
        {
            this.presetSettingViews = ReadPresetSetupConfigFile(this.presetSetupConfigFileInfo).ToList();
            this.updatableGameModificationViews = this.GetGameModificationViews(this.presetSettingViews);
        }
        else
        {
            List<GameModificationInfo> gameMods = this.gameSetupManager.TotalModificationsList;
            this.updatableGameModificationViews = GetGameModificationViewsByDefault(gameMods);
            this.presetSettingViews = GetPresetSettingsByDefault(this.updatableGameModificationViews);

            WritePresetSetupConfigFile(this.presetSettingViews, this.presetSetupConfigFileInfo);
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
    /// Updates the current mod preset settings for all game modifications.
    /// </summary>
    /// <param name="presetSettingViews">A collection containing objects of the <see cref="ModPresetSettingView"/> type.</param>
    public void UpdatePresetSettings(ICollection<ModPresetSettingView> presetSettingViews)
    {
        if (this.SynchronizePresetSettingsViews(presetSettingViews))
        {
            if (this.SynchronizeGameModificationViews(this.presetSettingViews))
            {
                this.CurrentGameModsCollectionView = new FullGameModsCollectionView(this.updatableGameModificationViews);
            }
        }
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

    private static void WritePresetSetupConfigFile(ICollection<ModPresetSettingView> presetSettingViews, FileInfo presetSetupConfigFileInfo)
    {
        AppSerializer.SerializeToJson(presetSettingViews, presetSetupConfigFileInfo.FullName);
    }

    private static ModPresetSettingView[] ReadPresetSetupConfigFile(FileInfo presetSetupConfigFileInfo)
    {
        return AppSerializer.DeserializeFromJson<ModPresetSettingView[]>(presetSetupConfigFileInfo.FullName);
    }

    private bool SynchronizePresetSettingsViews(ICollection<ModPresetSettingView> presetSettingViews)
    {
        this.presetSettingViews.Clear();

        foreach (ModPresetSettingView view in presetSettingViews)
        {
            this.presetSettingViews.Add(view);
        }

        WritePresetSetupConfigFile(this.presetSettingViews, this.presetSetupConfigFileInfo);

        return this.presetSetupConfigFileInfo.Exists;
    }

    private bool SynchronizeGameModificationViews(ICollection<ModPresetSettingView> presetSettingViews)
    {
        int previousItemsCount = this.updatableGameModificationViews.Count;
        this.updatableGameModificationViews.Clear();

        List<UpdatableGameModificationView> gameModViews = this.GetGameModificationViews(presetSettingViews);
        this.updatableGameModificationViews.AddRange(gameModViews);

        return this.updatableGameModificationViews.Count == previousItemsCount;
    }

    private List<UpdatableGameModificationView> GetGameModificationViews(ICollection<ModPresetSettingView> presetSettingViews)
    {
        List<UpdatableGameModificationView> gameModViews = new ();

        foreach (ModPresetSettingView presetSettingView in presetSettingViews)
        {
            UpdatableGameModificationView gameModView = this.GetGameModificationView(presetSettingView);
            gameModViews.Add(gameModView);
        }

        return gameModViews;
    }

    private UpdatableGameModificationView GetGameModificationView(ModPresetSettingView presetSettingView)
    {
        GameModificationInfo gameModInfo = this.gameSetupManager.TotalModificationsList.ElementAt(presetSettingView.Id!.NumericId);
        RedistributableModPreset modPreset = this.SelectRedistributablePresetById(presetSettingView.RedistributablePresetGuid);

        UpdatableGameModificationView gameModView =
            UpdatableGameModificationView.CreateGameModificationViewByRedistributablePreset(
                idView: presetSettingView.Id, info: gameModInfo, preset: modPreset);

        if (presetSettingView.UseCustomizablePreset)
        {
            gameModView.SelectCustomizableModPreset();
        }

        return gameModView;
    }

    private RedistributableModPreset SelectRedistributablePresetById(Guid presetId)
    {
        List<RedistributableModPreset> modPresets = this.gameSupportManager.AvailableModSupportPresets;

        foreach (RedistributableModPreset preset in modPresets)
        {
            if (preset.Metadata.Guid == presetId)
            {
                return preset;
            }
        }

        return UpdatableGameModificationView.GetRedistributablePresetByDefault();
    }
}
