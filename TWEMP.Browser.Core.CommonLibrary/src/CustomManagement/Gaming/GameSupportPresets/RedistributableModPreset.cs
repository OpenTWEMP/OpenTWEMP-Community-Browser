// <copyright file="RedistributableModPreset.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public record RedistributableModPreset
{
    public RedistributableModPreset(ModSupportPreset preset, ModPresetMetaInfo metadata)
    {
        this.Data = preset;
        this.Metadata = metadata;
    }

    public ModSupportPreset Data { get; set; }

    public ModPresetMetaInfo Metadata { get; set; }

    public static RedistributableModPreset CreateDefaultTemplate()
    {
        ModSupportPreset preset = ModSupportPreset.CreateDefaultTemplate();
        ModPresetMetaInfo metadata = ModPresetMetaInfo.CreateDefaultTemplate();

        return new RedistributableModPreset(preset, metadata);
    }
}
