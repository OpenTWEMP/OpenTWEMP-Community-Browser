// <copyright file="GameSupportManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;
using TWEMP.Browser.Core.CommonLibrary.Serialization;

/// <summary>
/// Represents a device to manage game support presets into the application.
/// </summary>
public static class GameSupportManager
{
    private const string PresetsHomeFolderName = "support";
    private const string PresetsConfigFileName = "games_support.json";

    private static readonly FileInfo PresetsConfigFileInfo;

    static GameSupportManager()
    {
        string presetsHomeDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), PresetsHomeFolderName);
        string presetsConfigFilePath = Path.Combine(presetsHomeDirectoryPath, PresetsConfigFileName);

        PresetsConfigFileInfo = new FileInfo(presetsConfigFilePath);
        PresetsHomeDirectoryInfo = new DirectoryInfo(presetsHomeDirectoryPath);

        AvailableModSupportPresets = new List<RedistributableModPreset>();
    }

    /// <summary>
    /// Gets information about the home directory of game support presets.
    /// </summary>
    public static DirectoryInfo PresetsHomeDirectoryInfo { get; }

    /// <summary>
    /// Gets the list of available redistributable mod support presets.
    /// </summary>
    public static List<RedistributableModPreset> AvailableModSupportPresets { get; private set; }

    /// <summary>
    /// Initializes the global device for game support management.
    /// </summary>
    public static void Initialize()
    {
        if (!PresetsHomeDirectoryInfo.Exists)
        {
            PresetsHomeDirectoryInfo.Create();
        }

        if (PresetsConfigFileInfo.Exists)
        {
            GameSupportConfiguration gameSupportConfiguration = ReadPresetsConfigFile();
            InitializeAvailablePresets(gameSupportConfiguration);
        }
        else
        {
            GameSupportConfiguration gameSupportConfiguration = GameSupportConfiguration.CreateTestConfigurationByDefault();
            InitializeAvailablePresets(gameSupportConfiguration);

            CreatePresetsConfigFileByDefault(gameSupportConfiguration);
        }
    }

    /// <summary>
    /// Creates a game mods collection view via a collection of mod preset setting view entities.
    /// </summary>
    /// <param name="presetSettings">A collection containing objects of the <see cref="ModPresetSettingView"/> type.</param>
    /// <returns>An instance of the <see cref="FullGameModsCollectionView"/> class.</returns>
    public static FullGameModsCollectionView CreateGameModsCollectionViewByPresetSettings(
        ICollection<ModPresetSettingView> presetSettings)
    {
        List<UpdatableGameModificationView> gameModificationViews = new ();

        foreach (ModPresetSettingView setting in presetSettings)
        {
            GameModificationInfo gameModInfo = CustomGameSetupManager.TotalModificationsList.ElementAt(setting.Id.NumericId);

            UpdatableGameModificationView gameModView;
            if (setting.UseCustomizablePreset)
            {
                gameModView = UpdatableGameModificationView.CreateGameModificationViewByCustomizablePreset(setting.Id, gameModInfo);
            }
            else
            {
                RedistributableModPreset redistributableModPreset = AvailableModSupportPresets.Find(
                    preset => preset.Metadata.Guid == setting.RedistributablePresetGuid)!;

                gameModView = UpdatableGameModificationView.CreateGameModificationViewByRedistributablePreset(
                    setting.Id, gameModInfo, redistributableModPreset);
            }

            gameModificationViews.Add(gameModView);
        }

        return new FullGameModsCollectionView(gameModificationViews);
    }

    private static void InitializeAvailablePresets(GameSupportConfiguration configuration)
    {
        List<RedistributableModPreset> presets = configuration.GetAllRedistributablePresets();

        foreach (var preset in presets)
        {
            AvailableModSupportPresets.Add(preset);
        }
    }

    private static void CreatePresetsConfigFileByDefault(GameSupportConfiguration configuration)
    {
        AppSerializer.SerializeToJson(configuration, PresetsConfigFileInfo.FullName);
    }

    private static GameSupportConfiguration ReadPresetsConfigFile()
    {
        return AppSerializer.DeserializeFromJson<GameSupportConfiguration>(PresetsConfigFileInfo.FullName);
    }
}
