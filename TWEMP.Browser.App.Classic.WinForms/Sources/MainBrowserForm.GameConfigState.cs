// <copyright file="MainBrowserForm.GameConfigState.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

internal partial class MainBrowserForm
{
    public M2TWCustomQuickConfigStateView CreateQuickCustomConfigState()
    {
        return new ()
        {
            IsEnabledWindowedMode = this.radioButtonLaunchWindowScreen.Checked,
            IsEnabledFullScreenMode = this.radioButtonLaunchFullScreen.Checked,
            ValidatorVideo = this.checkBoxVideo.Checked,
            ValidatorBorderless = this.checkBoxBorderless.Checked,

            ValidatorLogLevel1 = this.radioButtonLogOnlyError.Checked,
            ValidatorLogLevel2 = this.radioButtonLogOnlyTrace.Checked,
            ValidatorLogLevel3 = this.radioButtonLogErrorAndTrace.Checked,
            EnabledLogsHistorySaving = this.checkBoxLogHistory.Checked,

            IsShouldBeDeleted_MapRWM = this.checkBoxCleaner_MapRWM.Checked,
            IsShouldBeDeleted_TextBin = this.checkBoxCleaner_textBIN.Checked,
            IsShouldBeDeleted_SoundPacks = this.checkBoxCleaner_soundPacks.Checked,

            UseLauncherProvider_TWEMP = this.radioButtonLauncherProvider_TWEMP.Checked,
            UseLauncherProvider_M2TWEOP_NativeSetup = this.radioButtonLauncherProvider_NativeSetup.Checked,
            UseLauncherProvider_M2TWEOP_NativeBatch = this.radioButtonLauncherProvider_BatchScript.Checked,
            UseLauncherProvider_M2TWEOP = this.radioButtonLauncherProvider_M2TWEOP.Checked,
        };
    }
}
