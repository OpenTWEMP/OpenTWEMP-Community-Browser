// <copyright file="ModSupportPresetPackage.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public class ModSupportPresetPackage
{
    public ModSupportPresetPackage()
    {
        this.Name = string.Empty;
        this.Presets = new List<ModSupportPreset>();
    }

    public ModSupportPresetPackage(string name, ICollection<ModSupportPreset> presets)
    {
        this.Name = name;
        this.Presets = presets;
    }

    public string Name { get; set; }

    public ICollection<ModSupportPreset> Presets { get; set; }

    public static List<ModSupportPresetPackage> CreateTestPackages()
    {
        ModSupportPresetPackage package_1 = CreatePackage("TWEMP");
        ModSupportPresetPackage package_2 = CreatePackage("M2TW");
        ModSupportPresetPackage package_3 = CreatePackage("RTW");

        return new List<ModSupportPresetPackage> { package_1, package_2, package_3 };
    }

    private static ModSupportPresetPackage CreatePackage(string packageName)
    {
        List<ModSupportPreset> presets = GenerateTestPresets();
        return new ModSupportPresetPackage(packageName, presets);
    }

    private static List<ModSupportPreset> GenerateTestPresets(byte presetsCount = 5)
    {
        List<ModSupportPreset> presets = new ();

        for (int i = 0; i < presetsCount; i++)
        {
            ModSupportPreset preset = ModSupportPreset.CreateDefaultTemplate();
            presets.Add(preset);
        }

        return presets;
    }
}
