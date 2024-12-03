// <copyright file="MainBrowserForm.GameProfiles.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic;

internal partial class MainBrowserForm
{
    // QUICK CONFIGURING VIA PROFILES
    private void RadioButtonConfigProfile_Gaming_CheckedChanged(object sender, EventArgs e)
    {
        this.radioButtonLaunchWindowScreen.Checked = false;
        this.radioButtonLaunchFullScreen.Checked = true;
        this.checkBoxVideo.Checked = true;
        this.checkBoxBorderless.Checked = false;

        this.radioButtonLogOnlyError.Checked = true;
        this.radioButtonLogOnlyTrace.Checked = false;
        this.radioButtonLogErrorAndTrace.Checked = false;
    }

    private void RadioButtonConfigProfile_Modding_CheckedChanged(object sender, EventArgs e)
    {
        this.radioButtonLaunchWindowScreen.Checked = true;
        this.radioButtonLaunchFullScreen.Checked = false;
        this.checkBoxVideo.Checked = false;
        this.checkBoxBorderless.Checked = false;

        this.radioButtonLogOnlyError.Checked = false;
        this.radioButtonLogOnlyTrace.Checked = false;
        this.radioButtonLogErrorAndTrace.Checked = true;
    }
}
