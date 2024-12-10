// <copyright file="ModSupportPresetPackage.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public class ModSupportPresetPackage
{
    private List<RedistributableModPreset> attachedPresets;

    public ModSupportPresetPackage()
    {
        this.attachedPresets = new List<RedistributableModPreset>();

        this.Name = string.Empty;
    }

    public ModSupportPresetPackage(string name, ICollection<RedistributableModPreset> presets)
    {
        this.attachedPresets = presets.ToList();

        this.Name = name;
    }

    public string Name { get; set; }

    public static List<ModSupportPresetPackage> CreateTestPackages()
    {
        ModSupportPresetPackage package_1 = CreatePackage("TWEMP");
        ModSupportPresetPackage package_2 = CreatePackage("M2TW");
        ModSupportPresetPackage package_3 = CreatePackage("RTW");

        return new List<ModSupportPresetPackage> { package_1, package_2, package_3 };
    }

    public List<RedistributableModPreset> GetAttachedPresets()
    {
        return this.attachedPresets;
    }

    public void AttachPreset(RedistributableModPreset preset)
    {
        this.attachedPresets.Add(preset);
    }

    private static ModSupportPresetPackage CreatePackage(string packageName)
    {
        List<RedistributableModPreset> presets = GenerateTestPresets();
        return new ModSupportPresetPackage(packageName, presets);
    }

    private static List<RedistributableModPreset> GenerateTestPresets(byte presetsCount = 5)
    {
        List<RedistributableModPreset> presets = new ();

        for (int i = 0; i < presetsCount; i++)
        {
            RedistributableModPreset preset = RedistributableModPreset.CreateDefaultTemplate();
            presets.Add(preset);
        }

        return presets;
    }
}
