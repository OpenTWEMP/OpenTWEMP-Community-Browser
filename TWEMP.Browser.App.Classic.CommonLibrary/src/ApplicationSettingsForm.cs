// <copyright file="ApplicationSettingsForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class AppSettingsForm : Form, ICanChangeMyLocalization
{
    private readonly IUpdatableBrowser currentBrowser;

    private GuiStyle currentGuiStyle;

    public AppSettingsForm(IUpdatableBrowser browser)
    {
        InitializeComponent();

        currentBrowser = browser;
        currentGuiStyle = InitializeCurrentGUIStyle();

        if (IsEnabledLocalizationOnEnglish())
        {
            enableEngLocaleRadioButton.Checked = true;
            enableRusLocaleRadioButton.Checked = false;
        }

        if (IsEnabledLocalizationOnRussian())
        {
            enableEngLocaleRadioButton.Checked = false;
            enableRusLocaleRadioButton.Checked = true;
        }

        activatePresetsCheckBox.Checked = UseExperimentalFeatures;

        SetupCurrentLocalizationForGUIControls();
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        Text = GetTextInCurrentLocalization(Name, Name);

        appColorThemeGroupBox.Text = GetTextInCurrentLocalization(Name, appColorThemeGroupBox.Name);
        uiStyleByDefaultThemeRadioButton.Text = GetTextInCurrentLocalization(Name, uiStyleByDefaultThemeRadioButton.Name);
        uiStyleByLightThemeRadioButton.Text = GetTextInCurrentLocalization(Name, uiStyleByLightThemeRadioButton.Name);
        uiStyleByDarkThemeRadioButton.Text = GetTextInCurrentLocalization(Name, uiStyleByDarkThemeRadioButton.Name);

        appLocalizationGroupBox.Text = GetTextInCurrentLocalization(Name, appLocalizationGroupBox.Name);
        enableEngLocaleRadioButton.Text = GetTextInCurrentLocalization(Name, enableEngLocaleRadioButton.Name);
        enableRusLocaleRadioButton.Text = GetTextInCurrentLocalization(Name, enableRusLocaleRadioButton.Name);

        appFeaturesGroupBox.Text = GetTextInCurrentLocalization(Name, appFeaturesGroupBox.Name);
        activatePresetsCheckBox.Text = GetTextInCurrentLocalization(Name, activatePresetsCheckBox.Name);

        saveAppSettingsButton.Text = GetTextInCurrentLocalization(Name, saveAppSettingsButton.Name);
        exitAppSettingsButton.Text = GetTextInCurrentLocalization(Name, exitAppSettingsButton.Name);
    }

    private GuiStyle InitializeCurrentGUIStyle()
    {
        GuiStyle activeStyle = Settings.CurrentGUIStyle;

        switch (activeStyle)
        {
            case GuiStyle.Default:
                uiStyleByDefaultThemeRadioButton.Checked = true;
                uiStyleByLightThemeRadioButton.Checked = false;
                uiStyleByDarkThemeRadioButton.Checked = false;
                break;
            case GuiStyle.Light:
                uiStyleByDefaultThemeRadioButton.Checked = false;
                uiStyleByLightThemeRadioButton.Checked = true;
                uiStyleByDarkThemeRadioButton.Checked = false;
                break;
            case GuiStyle.Dark:
                uiStyleByDefaultThemeRadioButton.Checked = false;
                uiStyleByLightThemeRadioButton.Checked = false;
                uiStyleByDarkThemeRadioButton.Checked = true;
                break;
            default:
                break;
        }

        return activeStyle;
    }

    private void SaveAppSettingsButton_Click(object sender, EventArgs e)
    {
        Settings.CurrentGUIStyle = currentGuiStyle;
        currentBrowser.UpdateGUIStyle(currentGuiStyle);

        if (enableEngLocaleRadioButton.Checked)
        {
            SetLocalizationOnEnglishAsCurrent();
        }

        if (enableRusLocaleRadioButton.Checked)
        {
            SetLocalizationOnRussianAsCurrent();
        }

        this.SetupCurrentLocalizationForGUIControls();
        currentBrowser.UpdateLocalizationForGUIControls();

        UseExperimentalFeatures = activatePresetsCheckBox.Checked;
        currentBrowser.UpdateExperimentalGUIChanges(activatePresetsCheckBox.Checked);

        Close();
    }

    private void ExitAppSettingsButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void UiStyleByDefaultThemeRadioButton_Click(object sender, EventArgs e)
    {
        currentGuiStyle = GuiStyle.Default;
    }

    private void UiStyleByLightThemeRadioButton_Click(object sender, EventArgs e)
    {
        currentGuiStyle = GuiStyle.Light;
    }

    private void UiStyleByDarkThemeRadioButton_Click(object sender, EventArgs e)
    {
        currentGuiStyle = GuiStyle.Dark;
    }
}
