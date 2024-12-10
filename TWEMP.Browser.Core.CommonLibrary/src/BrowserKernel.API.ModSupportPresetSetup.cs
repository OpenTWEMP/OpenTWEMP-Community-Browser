// <copyright file="BrowserKernel.API.ModSupportPresetSetup.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

public static partial class BrowserKernel
{
    public static FullGameModsCollectionView CurrentGameModsCollectionView
    {
        get
        {
            return ModSupportPresetSetupManagerInstance.CurrentGameModsCollectionView;
        }
    }

    public static void UpdatePresetSettings(ICollection<ModPresetSettingView> presetSettingViews)
    {
        ModSupportPresetSetupManagerInstance.UpdatePresetSettings(presetSettingViews);
    }
}
