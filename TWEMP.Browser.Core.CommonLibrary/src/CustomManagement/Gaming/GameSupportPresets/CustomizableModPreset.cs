// <copyright file="CustomizableModPreset.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public record CustomizableModPreset
{
    private const string PresetFolderName = ".twemp";
    private const string PresetConfigFileName = "twemp_preset_config.json";

    public CustomizableModPreset(ModSupportPreset preset, string modURI)
    {
        this.Data = preset;

        string directoryPath = Path.Combine(modURI, PresetFolderName);
        this.Location = new DirectoryInfo(directoryPath);

        string filePath = Path.Combine(this.Location.FullName, PresetConfigFileName);
        this.Config = new FileInfo(filePath);
    }

    public ModSupportPreset Data { get; set; }

    public DirectoryInfo Location { get; set; }

    public FileInfo Config { get; set; }

    public static CustomizableModPreset CreateDefaultTemplate(string modURI)
    {
        ModSupportPreset preset = ModSupportPreset.CreateDefaultTemplate();
        return new CustomizableModPreset(preset, modURI);
    }

    public static bool Exists(string modURI)
    {
        string presetConfigFilePath = Path.Combine(modURI, PresetFolderName, PresetConfigFileName);
        return File.Exists(presetConfigFilePath);
    }

    public static CustomizableModPreset ReadCurrentPreset(string modURI)
    {
        string presetConfigFilePath = Path.Combine(modURI, PresetFolderName, PresetConfigFileName);

        CustomizableModPreset preset;
        try
        {
            preset = Serialization.AppSerializer.DeserializeFromJson<CustomizableModPreset>(presetConfigFilePath);
        }
        catch (InvalidOperationException)
        {
            preset = CreateDefaultTemplate(modURI);
        }

        return preset;
    }

#if LEGACY_CUSTOM_PRESET_CREATE_IMPL
    public static CustomModSupportPreset CreatePresetByDefault(string modificationURI)
    {
        // 1. Prepare preset's folder into modification's home directory.
        string presetHomeDirectoryPath = Path.Combine(modificationURI, MOD_PRESET_FOLDERNAME);

        if (!Directory.Exists(presetHomeDirectoryPath))
        {
            Directory.CreateDirectory(presetHomeDirectoryPath);
        }

        // 2. Generate 'mod_support.json' preset configuration file.
        var presetByDefault = new CustomModSupportPreset();
        string presetJsonText = JsonConvert.SerializeObject(presetByDefault, Formatting.Indented);
        string presetFilePath = Path.Combine(presetHomeDirectoryPath, MOD_PRESET_FILENAME);

        File.WriteAllText(presetFilePath, presetJsonText);

        return presetByDefault;
    }
#endif
}
