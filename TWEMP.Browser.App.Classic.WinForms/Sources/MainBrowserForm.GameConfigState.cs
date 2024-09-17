// <copyright file="MainBrowserForm.GameConfigState.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

internal partial class MainBrowserForm : IGameConfigState
{
    public CustomConfigState GetCurrentGameConfigState()
    {
        return new CustomConfigState()
        {
            UseLauncherProvider_M2TWEOP = this.radioButtonLauncherProvider_M2TWEOP.Checked,
            UseLauncherProvider_M2TWEOP_NativeSetup = this.radioButtonLauncherProvider_NativeSetup.Checked,
            UseLauncherProvider_M2TWEOP_NativeBatch = this.radioButtonLauncherProvider_BatchScript.Checked,
            UseLauncherProvider_TWEMP = this.radioButtonLauncherProvider_TWEMP.Checked,

            IsEnabledFullScreenMode = this.radioButtonLaunchFullScreen.Checked,
            IsEnabledWindowedMode = this.radioButtonLaunchWindowScreen.Checked,

            ValidatorVideo = this.checkBoxVideo.Checked,
            ValidatorBorderless = this.checkBoxBorderless.Checked,

            ValidatorLogLevel1 = this.radioButtonLogOnlyError.Checked,
            ValidatorLogLevel2 = this.radioButtonLogOnlyTrace.Checked,
            ValidatorLogLevel3 = this.radioButtonLogErrorAndTrace.Checked,

            IsShouldBeDeleted_MapRWM = this.checkBoxCleaner_MapRWM.Checked,
            IsShouldBeDeleted_TextBin = this.checkBoxCleaner_textBIN.Checked,
            IsShouldBeDeleted_SoundPacks = this.checkBoxCleaner_soundPacks.Checked,

            EnabledLogsHistorySaving = this.checkBoxLogHistory.Checked,
        };
    }
}
