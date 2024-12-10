// <copyright file="AboutProjectForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class AboutProjectForm : Form, ICanChangeMyLocalization
{
    public AboutProjectForm()
    {
        this.InitializeComponent();
        this.SetupCurrentLocalizationForGUIControls();
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        this.Text = GetTextInCurrentLocalization(this.Name, this.Name);
        this.aboutProjectNameLabel3.Text = GetTextInCurrentLocalization(this.Name, this.aboutProjectNameLabel3.Name);
        this.aboutProjectNameLabel4.Text = GetTextInCurrentLocalization(this.Name, this.aboutProjectNameLabel4.Name);
    }
}
