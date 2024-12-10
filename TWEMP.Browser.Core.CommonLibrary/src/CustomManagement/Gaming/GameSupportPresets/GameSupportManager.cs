// <copyright file="GameSupportManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#define USE_REAL_PRESETS
#define USE_TEST_PRESETS
#undef USE_TEST_PRESETS

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;
using TWEMP.Browser.Core.CommonLibrary.Serialization;

/// <summary>
/// Represents a device to manage game support presets into the application.
/// </summary>
public class GameSupportManager
{
    private const string PresetsHomeFolderName = "support";
    private const string PresetsConfigFileName = "games_support.json";

    private readonly DirectoryInfo presetsHomeDirectoryInfo;
    private readonly FileInfo presetsConfigFileInfo;

    private GameSupportManager()
    {
        string presetsHomeDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), PresetsHomeFolderName);
        this.presetsHomeDirectoryInfo = new DirectoryInfo(presetsHomeDirectoryPath);

        string presetsConfigFilePath = Path.Combine(presetsHomeDirectoryPath, PresetsConfigFileName);
        this.presetsConfigFileInfo = new FileInfo(presetsConfigFilePath);

        this.AvailableModSupportPresets = new List<RedistributableModPreset>();

        if (!this.presetsHomeDirectoryInfo.Exists)
        {
            this.presetsHomeDirectoryInfo.Create();
        }

        if (this.presetsConfigFileInfo.Exists)
        {
            RedistributableModPreset[] presets = this.ReadPresetsConfigFile();
            this.InitializeAvailablePresets(presets);
        }
        else
        {
#if USE_REAL_PRESETS
            List<ModSupportPresetPackage> detectedPackages = this.GetAllPresetPackages();
            GameSupportConfiguration gameSupportConfiguration = new (
                provider: new GameSupportProvider(GameEngineSupportType.M2TW),
                packages: detectedPackages);
            this.InitializeAvailablePresets(gameSupportConfiguration);
            this.CreatePresetsConfigFileByDefault(gameSupportConfiguration);
#endif

#if USE_TEST_PRESETS
            GameSupportConfiguration gameSupportConfiguration = GameSupportConfiguration.CreateTestConfigurationByDefault();
            this.InitializeAvailablePresets(gameSupportConfiguration);
            this.CreatePresetsConfigFileByDefault(gameSupportConfiguration);
#endif
        }
    }

    /// <summary>
    /// Gets the list of available redistributable mod support presets.
    /// </summary>
    public List<RedistributableModPreset> AvailableModSupportPresets { get; private set; }

    /// <summary>
    /// Creates a custom instance of the <see cref="GameSupportManager"/> class.
    /// </summary>
    /// <returns>Instance of the <see cref="GameSupportManager"/> class.</returns>
    public static GameSupportManager Create()
    {
        return new GameSupportManager();
    }

    /// <summary>
    /// Gets the home directory info for a specified redistributable mod support presets by its ID.
    /// </summary>
    /// <param name="presetId">The <see cref="Guid"/> value for the target preset.</param>
    /// <returns>The home directory info for the target preset.</returns>
    public DirectoryInfo GetPresetHomeDirectoryInfo(Guid presetId)
    {
        RedistributableModPreset preset = this.SelectPresetById(presetId) !;

        if (preset != null)
        {
            return this.GetPresetHomeDirectoryInfo(preset);
        }

        return this.presetsHomeDirectoryInfo;
    }

    /// <summary>
    /// Gets the home directory info for a specified redistributable mod support preset.
    /// </summary>
    /// <param name="preset">The target preset of the <see cref="RedistributableModPreset"/> type.</param>
    /// <returns>The home directory info for the target preset.</returns>
    public DirectoryInfo GetPresetHomeDirectoryInfo(RedistributableModPreset preset)
    {
        string presetHomeDirectoryPath = Path.Combine(
            path1: this.presetsHomeDirectoryInfo.FullName,
            path2: preset.Metadata.PackageName,
            path3: preset.Metadata.PresetName);

        if (Directory.Exists(presetHomeDirectoryPath))
        {
            return new DirectoryInfo(presetHomeDirectoryPath);
        }

        return this.presetsHomeDirectoryInfo;
    }

    private List<ModSupportPresetPackage> GetAllPresetPackages()
    {
        const string packageConfigFileName = "twemp-package-config.json";
        const string presetConfigFileName = "twemp-preset-config.json";

        List<ModSupportPresetPackage> modSupportPresetPackages = new List<ModSupportPresetPackage>();

        DirectoryInfo[] packageDirectories = this.presetsHomeDirectoryInfo.GetDirectories();

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

    private void InitializeAvailablePresets(GameSupportConfiguration configuration)
    {
        List<RedistributableModPreset> presets = configuration.GetAllRedistributablePresets();

        foreach (RedistributableModPreset preset in presets)
        {
            this.AvailableModSupportPresets.Add(preset);
        }
    }

    private void InitializeAvailablePresets(RedistributableModPreset[] presets)
    {
        foreach (RedistributableModPreset preset in presets)
        {
            this.AvailableModSupportPresets.Add(preset);
        }
    }

    private void CreatePresetsConfigFileByDefault(GameSupportConfiguration configuration)
    {
        List<RedistributableModPreset> presets = new ();

        List<ModSupportPresetPackage> packages = configuration.RedistributablePackages;

        foreach (ModSupportPresetPackage package in packages)
        {
            List<RedistributableModPreset> attachedPresets = package.GetAttachedPresets();
            presets.AddRange(attachedPresets);
        }

        AppSerializer.SerializeToJson(presets, this.presetsConfigFileInfo.FullName);
    }

    private RedistributableModPreset[] ReadPresetsConfigFile()
    {
        return AppSerializer.DeserializeFromJson<RedistributableModPreset[]>(this.presetsConfigFileInfo.FullName);
    }

    private RedistributableModPreset? SelectPresetById(Guid presetId)
    {
        foreach (RedistributableModPreset preset in this.AvailableModSupportPresets)
        {
            if (preset.Metadata.Guid == presetId)
            {
                return preset;
            }
        }

        return null;
    }
}
