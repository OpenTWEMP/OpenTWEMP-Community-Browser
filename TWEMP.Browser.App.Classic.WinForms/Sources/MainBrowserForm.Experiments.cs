// <copyright file="MainBrowserForm.Experiments.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary;

internal partial class MainBrowserForm : IUpdatableBrowser
{
    public void UpdateExperimentalGUIChanges(bool enabled)
    {
        groupBoxLauncherProviders.Visible = enabled;
        radioButtonLauncherProvider_TWEMP.Checked = true;
    }
}
