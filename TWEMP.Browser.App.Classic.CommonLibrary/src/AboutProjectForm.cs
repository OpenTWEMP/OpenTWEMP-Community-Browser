// <copyright file="AboutProjectForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class AboutProjectForm : Form, ICanChangeMyLocalization
{
    public AboutProjectForm()
    {
        InitializeComponent();
        SetupCurrentLocalizationForGUIControls();
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        Text = GetTextInCurrentLocalization(Name, Name);
        aboutProjectNameLabel3.Text = GetTextInCurrentLocalization(Name, aboutProjectNameLabel3.Name);
        aboutProjectNameLabel4.Text = GetTextInCurrentLocalization(Name, aboutProjectNameLabel4.Name);
    }
}
