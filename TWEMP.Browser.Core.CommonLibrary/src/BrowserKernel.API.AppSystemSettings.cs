// <copyright file="BrowserKernel.API.AppSystemSettings.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

public static partial class BrowserKernel
{
    public static bool UseExperimentalFeatures
    {
        get
        {
            return AppSystemSettingsManagerInstance.UseExperimentalFeatures;
        }

        set
        {
            AppSystemSettingsManagerInstance.UseExperimentalFeatures = value;
        }
    }
}
