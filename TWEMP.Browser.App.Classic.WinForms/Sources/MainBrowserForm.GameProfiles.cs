// <copyright file="MainBrowserForm.GameProfiles.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic;

internal partial class MainBrowserForm
{
    // QUICK CONFIGURING VIA PROFILES
    private void RadioButtonConfigProfile_Gaming_CheckedChanged(object sender, EventArgs e)
    {
        radioButtonLaunchWindowScreen.Checked = false;
        radioButtonLaunchFullScreen.Checked = true;
        checkBoxVideo.Checked = true;
        checkBoxBorderless.Checked = false;

        radioButtonLogOnlyError.Checked = true;
        radioButtonLogOnlyTrace.Checked = false;
        radioButtonLogErrorAndTrace.Checked = false;
    }

    private void RadioButtonConfigProfile_Modding_CheckedChanged(object sender, EventArgs e)
    {
        radioButtonLaunchWindowScreen.Checked = true;
        radioButtonLaunchFullScreen.Checked = false;
        checkBoxVideo.Checked = false;
        checkBoxBorderless.Checked = false;

        radioButtonLogOnlyError.Checked = false;
        radioButtonLogOnlyTrace.Checked = false;
        radioButtonLogErrorAndTrace.Checked = true;
    }
}
