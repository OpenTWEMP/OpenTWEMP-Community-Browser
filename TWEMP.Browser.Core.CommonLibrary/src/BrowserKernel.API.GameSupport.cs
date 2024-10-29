// <copyright file="BrowserKernel.API.GameSupport.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

public static partial class BrowserKernel
{
    public static List<RedistributableModPreset> AvailableModSupportPresets
    {
        get
        {
            return GameSupportManagerInstance.AvailableModSupportPresets;
        }
    }

    public static FileInfo GetActivePresetLogoImageFileInfo(UpdatableGameModificationView gameModView)
    {
        if (gameModView.UseCustomizablePreset)
        {
            return gameModView.GetLogoImageFromCustomizablePreset();
        }

        Guid presetId = gameModView.GetRedistributablePresetId();
        DirectoryInfo presetHomeDirectoryInfo = GameSupportManagerInstance.GetPresetHomeDirectoryInfo(presetId);
        return gameModView.GetLogoImageFromRedistributablePreset(presetHomeDirectoryInfo);
    }

    public static FileInfo GetActivePresetBackgroundSoundTrackFileInfo(UpdatableGameModificationView gameModView)
    {
        if (gameModView.UseCustomizablePreset)
        {
            return gameModView.GetBackgroundSoundTrackFromCustomizablePreset();
        }

        Guid presetId = gameModView.GetRedistributablePresetId();
        DirectoryInfo presetHomeDirectoryInfo = GameSupportManagerInstance.GetPresetHomeDirectoryInfo(presetId);
        return gameModView.GetBackgroundSoundTrackFromRedistributablePreset(presetHomeDirectoryInfo);
    }
}
