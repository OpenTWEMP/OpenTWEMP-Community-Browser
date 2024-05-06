// <copyright file="GameConfigStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#define CFG_STATE_PROPERTIES

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

public record GameConfigStateView : ICustomConfigState
{
    public GameConfigStateView()
    {
    }

    public ModSettingsSectionStateView? ModCoreSettingsSection { get; set; } // [features] + [io]

    public ModDiagnosticSectionStateView? ModDiagnosticSection { get; set; } // [log]

    public ModGameplaySectionStateView? ModGameplaySection { get; set; } // [game] + [misc]

    public ModHotseatSectionStateView? HotseatSection { get; set; } // [hotseat] + [network] + [misc]

    public GameAudioCfgSectionStateView? GameAudioCfgSection { get; set; } // [audio]

    public GameCameraCfgSectionStateView? GameCameraCfgSection { get; set; } // [camera]

    public GameControlsCfgSectionStateView? GameControlsCfgSection { get; set; } // [controls]

    public GameUICfgSectionStateView? GameUICfgSection { get; set; } // [ui]

    public GameVideoCfgSectionStateView? GameVideoCfgSection { get; set; } // [video]

#if CFG_STATE_PROPERTIES
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
#endif

    public ICfgOptSubSet[] RetrieveCurrentSettings()
    {
        return new ICfgOptSubSet[] { };
    }
}
