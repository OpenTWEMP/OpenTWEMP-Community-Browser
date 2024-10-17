// <copyright file="GameSupportManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#define USE_REAL_PRESETS
#define USE_TEST_PRESETS
#undef USE_TEST_PRESETS

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
        PresetsHomeDirectoryInfo = new DirectoryInfo(presetsHomeDirectoryPath);

        string presetsConfigFilePath = Path.Combine(presetsHomeDirectoryPath, PresetsConfigFileName);
        PresetsConfigFileInfo = new FileInfo(presetsConfigFilePath);

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
            RedistributableModPreset[] presets = ReadPresetsConfigFile();
            InitializeAvailablePresets(presets);
        }
        else
        {
#if USE_REAL_PRESETS
            List<ModSupportPresetPackage> detectedPackages = GetAllPresetPackages();
            GameSupportConfiguration gameSupportConfiguration = new (
                provider: new GameSupportProvider(GameEngineSupportType.M2TW),
                packages: detectedPackages);
            InitializeAvailablePresets(gameSupportConfiguration);
            CreatePresetsConfigFileByDefault(gameSupportConfiguration);
#endif

#if USE_TEST_PRESETS
            GameSupportConfiguration gameSupportConfiguration = GameSupportConfiguration.CreateTestConfigurationByDefault();
            InitializeAvailablePresets(gameSupportConfiguration);
            CreatePresetsConfigFileByDefault(gameSupportConfiguration);
#endif
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

    private static List<ModSupportPresetPackage> GetAllPresetPackages()
    {
        const string packageConfigFileName = "twemp-package-config.json";
        const string presetConfigFileName = "twemp-preset-config.json";

        List<ModSupportPresetPackage> modSupportPresetPackages = new List<ModSupportPresetPackage>();

        DirectoryInfo[] packageDirectories = PresetsHomeDirectoryInfo.GetDirectories();

        foreach (DirectoryInfo packageDirectory in packageDirectories)
        {
            FileInfo[] packageFiles = packageDirectory.GetFiles();

            foreach (FileInfo packageFile in packageFiles)
            {
                if (packageFile.Name.Equals(packageConfigFileName))
                {
                    ModSupportPresetPackage package = AppSerializer.DeserializeFromJson<ModSupportPresetPackage>(packageFile.FullName);

                    DirectoryInfo[] presetDirectories = packageDirectory.GetDirectories();

                    foreach (DirectoryInfo presetDirectory in presetDirectories)
                    {
                        FileInfo[] presetFiles = presetDirectory.GetFiles();

                        foreach (FileInfo presetFile in presetFiles)
                        {
                            if (presetFile.Name.Equals(presetConfigFileName))
                            {
                                RedistributableModPreset preset = AppSerializer.DeserializeFromJson<RedistributableModPreset>(presetFile.FullName);
                                package.AttachPreset(preset);
                            }
                        }
                    }

                    modSupportPresetPackages.Add(package);
                }
            }
        }

        return modSupportPresetPackages;
    }

    private static void InitializeAvailablePresets(GameSupportConfiguration configuration)
    {
        List<RedistributableModPreset> presets = configuration.GetAllRedistributablePresets();

        foreach (RedistributableModPreset preset in presets)
        {
            AvailableModSupportPresets.Add(preset);
        }
    }

    private static void InitializeAvailablePresets(RedistributableModPreset[] presets)
    {
        foreach (RedistributableModPreset preset in presets)
        {
            AvailableModSupportPresets.Add(preset);
        }
    }

    private static void CreatePresetsConfigFileByDefault(GameSupportConfiguration configuration)
    {
        List<RedistributableModPreset> presets = new ();

        List<ModSupportPresetPackage> packages = configuration.RedistributablePackages;

        foreach (ModSupportPresetPackage package in packages)
        {
            List<RedistributableModPreset> attachedPresets = package.GetAttachedPresets();
            presets.AddRange(attachedPresets);
        }

        AppSerializer.SerializeToJson(presets, PresetsConfigFileInfo.FullName);
    }

    private static RedistributableModPreset[] ReadPresetsConfigFile()
    {
        return AppSerializer.DeserializeFromJson<RedistributableModPreset[]>(PresetsConfigFileInfo.FullName);
    }
}
