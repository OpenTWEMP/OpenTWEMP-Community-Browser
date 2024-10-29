// <copyright file="BrowserKernel.API.GameConfiguration.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

public static partial class BrowserKernel
{
    public static List<GameConfigProfile> AvailableProfiles
    {
        get
        {
            return GameConfigurationManagerInstance.AvailableProfiles;
        }
    }

    public static UpdatableGameModificationView? CurrentGameModView
    {
        get
        {
            return GameConfigurationManagerInstance.CurrentGameModView;
        }

        set
        {
            GameConfigurationManagerInstance.CurrentGameModView = value;
        }
    }
}
