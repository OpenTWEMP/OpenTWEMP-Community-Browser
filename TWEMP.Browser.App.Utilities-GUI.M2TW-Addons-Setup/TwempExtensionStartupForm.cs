// <copyright file="TwempExtensionStartupForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Utilities_GUI.M2TW_Addons_Setup;

using TWEMP.Browser.Extension.AddonsSetupFramework.WinForms;

public partial class TwempExtensionStartupForm : Form
{
    public TwempExtensionStartupForm()
    {
        this.InitializeComponent();
    }

    private void StartupButton_Click(object sender, EventArgs e)
    {
        MainAddonsSetupFrameworkForm form = new ();
        form.Show();
    }
}
