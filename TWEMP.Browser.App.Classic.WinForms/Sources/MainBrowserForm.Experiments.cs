// <copyright file="MainBrowserForm.Experiments.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;

internal partial class MainBrowserForm : IUpdatableBrowser
{
    public void UpdateExperimentalGUIChanges(bool enabled)
    {
        this.groupBoxLauncherProviders.Visible = enabled;
        this.radioButtonLauncherProvider_TWEMP.Checked = true;
    }
}
