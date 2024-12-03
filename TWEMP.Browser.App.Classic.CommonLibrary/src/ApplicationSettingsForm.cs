// <copyright file="ApplicationSettingsForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class AppSettingsForm : Form, ICanChangeMyLocalization
{
    private readonly IUpdatableBrowser currentBrowser;

    private GuiStyle currentGuiStyle;

    public AppSettingsForm(IUpdatableBrowser browser)
    {
        this.InitializeComponent();

        this.currentBrowser = browser;
        this.currentGuiStyle = this.InitializeCurrentGUIStyle();

        if (IsEnabledLocalizationOnEnglish())
        {
            this.enableEngLocaleRadioButton.Checked = true;
            this.enableRusLocaleRadioButton.Checked = false;
        }

        if (IsEnabledLocalizationOnRussian())
        {
            this.enableEngLocaleRadioButton.Checked = false;
            this.enableRusLocaleRadioButton.Checked = true;
        }

        this.activatePresetsCheckBox.Checked = UseExperimentalFeatures;

        this.SetupCurrentLocalizationForGUIControls();
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        this.Text = GetTextInCurrentLocalization(this.Name, this.Name);

        this.appColorThemeGroupBox.Text = GetTextInCurrentLocalization(this.Name, this.appColorThemeGroupBox.Name);
        this.uiStyleByDefaultThemeRadioButton.Text = GetTextInCurrentLocalization(this.Name, this.uiStyleByDefaultThemeRadioButton.Name);
        this.uiStyleByLightThemeRadioButton.Text = GetTextInCurrentLocalization(this.Name, this.uiStyleByLightThemeRadioButton.Name);
        this.uiStyleByDarkThemeRadioButton.Text = GetTextInCurrentLocalization(this.Name, this.uiStyleByDarkThemeRadioButton.Name);

        this.appLocalizationGroupBox.Text = GetTextInCurrentLocalization(this.Name, this.appLocalizationGroupBox.Name);
        this.enableEngLocaleRadioButton.Text = GetTextInCurrentLocalization(this.Name, this.enableEngLocaleRadioButton.Name);
        this.enableRusLocaleRadioButton.Text = GetTextInCurrentLocalization(this.Name, this.enableRusLocaleRadioButton.Name);

        this.appFeaturesGroupBox.Text = GetTextInCurrentLocalization(this.Name, this.appFeaturesGroupBox.Name);
        this.activatePresetsCheckBox.Text = GetTextInCurrentLocalization(this.Name, this.activatePresetsCheckBox.Name);

        this.saveAppSettingsButton.Text = GetTextInCurrentLocalization(this.Name, this.saveAppSettingsButton.Name);
        this.exitAppSettingsButton.Text = GetTextInCurrentLocalization(this.Name, this.exitAppSettingsButton.Name);
    }

    private GuiStyle InitializeCurrentGUIStyle()
    {
        GuiStyle activeStyle = BrowserKernel.CurrentGUIStyle;

        switch (activeStyle)
        {
            case GuiStyle.Default:
                this.uiStyleByDefaultThemeRadioButton.Checked = true;
                this.uiStyleByLightThemeRadioButton.Checked = false;
                this.uiStyleByDarkThemeRadioButton.Checked = false;
                break;
            case GuiStyle.Light:
                this.uiStyleByDefaultThemeRadioButton.Checked = false;
                this.uiStyleByLightThemeRadioButton.Checked = true;
                this.uiStyleByDarkThemeRadioButton.Checked = false;
                break;
            case GuiStyle.Dark:
                this.uiStyleByDefaultThemeRadioButton.Checked = false;
                this.uiStyleByLightThemeRadioButton.Checked = false;
                this.uiStyleByDarkThemeRadioButton.Checked = true;
                break;
            default:
                break;
        }

        return activeStyle;
    }

    private void SaveAppSettingsButton_Click(object sender, EventArgs e)
    {
        this.currentBrowser.UpdateGUIStyle(this.currentGuiStyle);

        if (this.enableEngLocaleRadioButton.Checked)
        {
            SetLocalizationOnEnglishAsCurrent();
        }

        if (this.enableRusLocaleRadioButton.Checked)
        {
            SetLocalizationOnRussianAsCurrent();
        }

        this.SetupCurrentLocalizationForGUIControls();
        this.currentBrowser.UpdateLocalizationForGUIControls();

        UseExperimentalFeatures = this.activatePresetsCheckBox.Checked;
        this.currentBrowser.UpdateExperimentalGUIChanges(this.activatePresetsCheckBox.Checked);

        this.Close();
    }

    private void ExitAppSettingsButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void UiStyleByDefaultThemeRadioButton_Click(object sender, EventArgs e)
    {
        this.currentGuiStyle = GuiStyle.Default;
    }

    private void UiStyleByLightThemeRadioButton_Click(object sender, EventArgs e)
    {
        this.currentGuiStyle = GuiStyle.Light;
    }

    private void UiStyleByDarkThemeRadioButton_Click(object sender, EventArgs e)
    {
        this.currentGuiStyle = GuiStyle.Dark;
    }
}
