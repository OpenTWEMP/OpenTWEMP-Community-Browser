// <copyright file="BrowserKernel.API.GameSupport.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public static partial class BrowserKernel
{
    public static List<RedistributableModPreset> AvailableModSupportPresets
    {
        get
        {
            return GameSupportManagerInstance.AvailableModSupportPresets;
        }
    }
}
