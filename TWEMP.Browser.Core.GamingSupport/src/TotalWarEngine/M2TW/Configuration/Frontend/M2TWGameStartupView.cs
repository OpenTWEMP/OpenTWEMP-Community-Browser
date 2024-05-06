// <copyright file="M2TWGameStartupView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

public class M2TWGameStartupView
{
    public bool UseLauncherProvider_M2TWEOP { get; init; }

    public bool UseLauncherProvider_M2TWEOP_NativeSetup { get; init; }

    public bool UseLauncherProvider_M2TWEOP_NativeBatch { get; init; }

    public bool UseLauncherProvider_TWEMP { get; init; }

    public bool IsShouldBeDeleted_MapRWM { get; init; }

    public bool IsShouldBeDeleted_TextBin { get; init; }

    public bool IsShouldBeDeleted_SoundPacks { get; init; }

    public bool EnabledLogsHistorySaving { get; init; }
}
