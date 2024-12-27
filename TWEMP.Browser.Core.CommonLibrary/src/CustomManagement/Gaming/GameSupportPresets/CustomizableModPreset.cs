// <copyright file="CustomizableModPreset.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

using TWEMP.Browser.Core.CommonLibrary.Serialization;

public record CustomizableModPreset
{
    private const string PresetFolderName = ".twemp";
    private const string PresetConfigFileName = "twemp-preset-config.json";

    private CustomizableModPreset(ModSupportPreset preset, string modURI)
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

    public static CustomizableModPreset Create(GameModificationInfo info)
    {
        CustomizableModPreset preset;
        string presetConfigFilePath = GetConfigFilePath(info);

        if (File.Exists(presetConfigFilePath))
        {
            preset = ReadCurrentPreset(info.Location);
        }
        else
        {
            preset = CreateDefaultTemplate(info.Location);
        }

        return preset;
    }

    private static string GetConfigFilePath(GameModificationInfo info) =>
        Path.Combine(info.Location, PresetFolderName, PresetConfigFileName);

    private static CustomizableModPreset ReadCurrentPreset(string modURI)
    {
        string presetConfigFilePath = Path.Combine(modURI, PresetFolderName, PresetConfigFileName);

        CustomizableModPreset customizablePreset;
        try
        {
            var preset = AppSerializer.DeserializeFromJson<ModSupportPreset>(presetConfigFilePath);
            customizablePreset = new CustomizableModPreset(preset, modURI);
        }
        catch (InvalidOperationException)
        {
            customizablePreset = CreateDefaultTemplate(modURI);
        }

        return customizablePreset;
    }

    private static CustomizableModPreset CreateDefaultTemplate(string modURI)
    {
        ModSupportPreset preset = ModSupportPreset.CreateDefaultTemplate();
        return new CustomizableModPreset(preset, modURI);
    }

    public void GenerateConfigTemplateByDefault()
    {
        if (!this.Location.Exists)
        {
            this.Location.Create();
        }

        AppSerializer.SerializeToJson(obj: this.Data, file: this.Config.FullName);
    }
}
