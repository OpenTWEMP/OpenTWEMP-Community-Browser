// <copyright file="MainBrowserForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.App.Classic.CommonLibrary;
using TWEMP.Browser.App.Classic.WinForms.Properties;
using TWEMP.Browser.Core.CommonLibrary;

internal partial class MainBrowserForm : Form
{
    private readonly BrowserMessageProvider currentMessageProvider;

    public MainBrowserForm()
    {
        this.InitializeComponent();

        this.currentMessageProvider = BrowserMessageProvider.CurrentProvider;

        this.SetupCurrentLocalizationForGUIControls();
        this.UpdateModificationsTreeView();

        this.Text = GetApplicationFullName();
    }

    private static string GetApplicationFullName()
    {
        string appProjectTitle = "OpenTWEMP Community Browser";
        string appHomeFolder = Application.ExecutablePath;

        return appProjectTitle + " [ " + appHomeFolder + " ]";
    }

    private void DisableModUIControls()
    {
        this.groupBoxLauncherProviders.Enabled = false;
        this.groupBoxLauncherProviders.Visible = false;

        this.groupBoxConfigProfiles.Enabled = false;
        this.groupBoxConfigProfiles.Visible = false;

        this.groupBoxConfigLaunchMode.Enabled = false;
        this.groupBoxConfigLaunchMode.Visible = false;

        this.groupBoxConfigLogMode.Enabled = false;
        this.groupBoxConfigLogMode.Visible = false;

        this.groupBoxConfigCleanerMode.Enabled = false;
        this.groupBoxConfigCleanerMode.Visible = false;

        this.buttonLaunch.Enabled = false;
        this.buttonLaunch.Visible = false;

        this.modConfigSettingsButton.Enabled = false;
        this.modConfigSettingsButton.Visible = false;

        this.modConfigProfilesButton.Enabled = false;
        this.modConfigProfilesButton.Visible = false;

        this.buttonExplore.Enabled = false;
        this.buttonExplore.Visible = false;

        this.modQuickNavigationButton.Enabled = false;
        this.modQuickNavigationButton.Visible = false;

        this.buttonMarkFavoriteMod.Enabled = false;
        this.buttonMarkFavoriteMod.Visible = false;

        this.buttonMusicPlay.Enabled = false;
        this.buttonMusicPlay.Visible = false;

        this.buttonMusicPause.Enabled = false;
        this.buttonMusicPause.Visible = false;

        this.buttonMusicRewind.Enabled = false;
        this.buttonMusicRewind.Visible = false;

        this.modMainTitleLabel.Text = string.Empty;
        this.modStatusLabel.Text = string.Empty;

        if (this.modLogoPictureBox.Image != null)
        {
            this.modLogoPictureBox.Image.Dispose();
            this.modLogoPictureBox.Image = Resources.OPENTWEMP_LOGO;
        }

        if (BrowserKernel.CurrentGameModView == null)
        {
            this.gameConfigProfilesSwitcherToolStripMenuItem.Enabled = false;
            this.configSettingsToolStripMenuItem.Enabled = false;
        }
    }

    private void EnableModUIControls()
    {
        this.groupBoxLauncherProviders.Enabled = true;
        this.groupBoxLauncherProviders.Visible = true;

        this.groupBoxConfigProfiles.Enabled = true;
        this.groupBoxConfigProfiles.Visible = true;

        this.groupBoxConfigLaunchMode.Enabled = true;
        this.groupBoxConfigLaunchMode.Visible = true;

        this.groupBoxConfigLogMode.Enabled = true;
        this.groupBoxConfigLogMode.Visible = true;

        this.groupBoxConfigCleanerMode.Enabled = true;
        this.groupBoxConfigCleanerMode.Visible = true;

        this.buttonLaunch.Enabled = true;
        this.buttonLaunch.Visible = true;

        this.modConfigSettingsButton.Enabled = true;
        this.modConfigSettingsButton.Visible = true;

        this.modConfigProfilesButton.Enabled = true;
        this.modConfigProfilesButton.Visible = true;

        this.buttonExplore.Enabled = true;
        this.buttonExplore.Visible = true;

        this.modQuickNavigationButton.Enabled = true;
        this.modQuickNavigationButton.Visible = true;

        this.buttonMarkFavoriteMod.Enabled = true;
        this.buttonMarkFavoriteMod.Visible = true;

        this.buttonMusicPlay.Enabled = true;
        this.buttonMusicPlay.Visible = true;

        this.buttonMusicPause.Enabled = true;
        this.buttonMusicPause.Visible = true;

        this.buttonMusicRewind.Enabled = true;
        this.buttonMusicRewind.Visible = true;

        if (BrowserKernel.CurrentGameModView != null)
        {
            this.gameConfigProfilesSwitcherToolStripMenuItem.Enabled = true;
            this.configSettingsToolStripMenuItem.Enabled = true;
        }
    }
}
