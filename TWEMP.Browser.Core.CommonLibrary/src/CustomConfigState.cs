// <copyright file="CustomConfigState.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

public record CustomConfigState
{
    public bool UseLauncherProvider_M2TWEOP { get; init; }

    public bool UseLauncherProvider_M2TWEOP_NativeSetup { get; init; }

    public bool UseLauncherProvider_M2TWEOP_NativeBatch { get; init; }

    public bool UseLauncherProvider_TWEMP { get; init; }

    public bool IsEnabledFullScreenMode { get; init; }

    public bool IsEnabledWindowedMode { get; init; }

    public bool ValidatorVideo { get; init; }

    public bool ValidatorBorderless { get; init; }

    public bool ValidatorLogLevel1 { get; init; }

    public bool ValidatorLogLevel2 { get; init; }

    public bool ValidatorLogLevel3 { get; init; }

    public bool IsShouldBeDeleted_MapRWM { get; init; }

    public bool IsShouldBeDeleted_TextBin { get; init; }

    public bool IsShouldBeDeleted_SoundPacks { get; init; }

    public bool EnabledLogsHistorySaving { get; init; }
}
