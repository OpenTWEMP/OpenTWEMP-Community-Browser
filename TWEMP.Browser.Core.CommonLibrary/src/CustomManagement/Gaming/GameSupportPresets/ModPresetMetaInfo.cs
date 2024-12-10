// <copyright file="ModPresetMetaInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public record ModPresetMetaInfo
{
    public ModPresetMetaInfo(
        Guid guid,
        string version,
        string presetName,
        string packageName,
        string creator)
    {
        this.Guid = guid;
        this.Version = version;
        this.PresetName = presetName;
        this.PackageName = packageName;
        this.Creator = creator;
    }

    public Guid Guid { get; set; }

    public string Version { get; set; }

    public string PresetName { get; set; }

    public string PackageName { get; set; }

    public string Creator { get; set; }

    public static ModPresetMetaInfo CreateDefaultTemplate()
    {
        return new ModPresetMetaInfo(
            guid: Guid.NewGuid(),
            version: "0.0.0",
            presetName: "M2TW Game Engine Modification",
            packageName: "M2TW Mod Support Presets",
            creator: "The OpenTWEMP Project");
    }
}
