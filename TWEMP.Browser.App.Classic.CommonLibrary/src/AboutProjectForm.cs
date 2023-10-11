// <copyright file="AboutProjectForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;

public partial class AboutProjectForm : Form, ICanChangeMyLocalization
{
    public AboutProjectForm()
    {
        InitializeComponent();

        SetupCurrentLocalizationForGUIControls();
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        FormLocaleSnapshot snapshot = Settings.CurrentLocalization.GetFormLocaleSnapshotByKey(Name);

        Text = snapshot.GetLocalizedValueByKey(Name);
        aboutProjectNameLabel3.Text = snapshot.GetLocalizedValueByKey(aboutProjectNameLabel3.Name);
        aboutProjectNameLabel4.Text = snapshot.GetLocalizedValueByKey(aboutProjectNameLabel4.Name);
    }
}
