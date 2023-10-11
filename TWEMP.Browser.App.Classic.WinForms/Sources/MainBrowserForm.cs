// <copyright file="MainBrowserForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.App.Classic.CommonLibrary;
using TWEMP.Browser.App.Classic.WinForms.Properties;

internal partial class MainBrowserForm : Form
{
    private readonly BrowserMessageProvider currentMessageProvider;

    public MainBrowserForm()
    {
        InitializeComponent();

        currentMessageProvider = BrowserMessageProvider.CurrentProvider;

        SetupCurrentLocalizationForGUIControls();
        UpdateModificationsTreeView();

        Text = GetApplicationFullName();
    }

    private static string GetApplicationFullName()
    {
        string appProjectTitle = "OpenTWEMP Community Browser";
        string appHomeFolder = Application.ExecutablePath;

        return appProjectTitle + " [ " + appHomeFolder + " ]";
    }

    private void DisableModUIControls()
    {
        groupBoxLauncherProviders.Enabled = false;
        groupBoxLauncherProviders.Visible = false;

        groupBoxConfigProfiles.Enabled = false;
        groupBoxConfigProfiles.Visible = false;

        groupBoxConfigLaunchMode.Enabled = false;
        groupBoxConfigLaunchMode.Visible = false;

        groupBoxConfigLogMode.Enabled = false;
        groupBoxConfigLogMode.Visible = false;

        groupBoxConfigCleanerMode.Enabled = false;
        groupBoxConfigCleanerMode.Visible = false;

        buttonLaunch.Enabled = false;
        buttonLaunch.Visible = false;

        buttonExplore.Enabled = false;
        buttonExplore.Visible = false;

        modQuickNavigationButton.Enabled = false;
        modQuickNavigationButton.Visible = false;

        buttonMarkFavoriteMod.Enabled = false;
        buttonMarkFavoriteMod.Visible = false;

        modMainTitleLabel.Text = string.Empty;
        modStatusLabel.Text = string.Empty;

        if (modLogoPictureBox.Image != null)
        {
            modLogoPictureBox.Image.Dispose();
            modLogoPictureBox.Image = Resources.OPENTWEMP_LOGO;
        }
    }

    private void EnableModUIControls()
    {
        groupBoxLauncherProviders.Enabled = true;
        groupBoxLauncherProviders.Visible = true;

        groupBoxConfigProfiles.Enabled = true;
        groupBoxConfigProfiles.Visible = true;

        groupBoxConfigLaunchMode.Enabled = true;
        groupBoxConfigLaunchMode.Visible = true;

        groupBoxConfigLogMode.Enabled = true;
        groupBoxConfigLogMode.Visible = true;

        groupBoxConfigCleanerMode.Enabled = true;
        groupBoxConfigCleanerMode.Visible = true;

        buttonLaunch.Enabled = true;
        buttonLaunch.Visible = true;

        buttonExplore.Enabled = true;
        buttonExplore.Visible = true;

        modQuickNavigationButton.Enabled = true;
        modQuickNavigationButton.Visible = true;

        buttonMarkFavoriteMod.Enabled = true;
        buttonMarkFavoriteMod.Visible = true;
    }
}
