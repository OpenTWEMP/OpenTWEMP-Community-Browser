namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;

public partial class AppSettingsForm : Form, ICanChangeMyLocalization
{
	private readonly IUpdatableBrowser currentBrowser;

	private GuiStyle currentGuiStyle;

	public AppSettingsForm(IUpdatableBrowser browser)
	{
		InitializeComponent();

        currentBrowser = browser;
		currentGuiStyle = InitializeCurrentGUIStyle();

		if (LocalizationManager.IsCurrentLocalizationName(GuiLocale.LOCALE_NAME_ENG))
		{
			enableEngLocaleRadioButton.Checked = true;
			enableRusLocaleRadioButton.Checked = false;
		}

		if (LocalizationManager.IsCurrentLocalizationName(GuiLocale.LOCALE_NAME_RUS))
		{
			enableEngLocaleRadioButton.Checked = false;
			enableRusLocaleRadioButton.Checked = true;
		}

		activatePresetsCheckBox.Checked = Settings.UseExperimentalFeatures;

		SetupCurrentLocalizationForGUIControls();
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
			string guiLocaleName_ENG = "ENG";
			Settings.SetCurrentLocalizationByName(guiLocaleName_ENG);
		}

		if (enableRusLocaleRadioButton.Checked)
		{
			string guiLocaleName_RUS = "RUS";
			Settings.SetCurrentLocalizationByName(guiLocaleName_RUS);
		}

		this.SetupCurrentLocalizationForGUIControls();
		currentBrowser.UpdateLocalizationForGUIControls();

		Settings.UseExperimentalFeatures = activatePresetsCheckBox.Checked;
		currentBrowser.UpdateExperimentalGUIChanges();

		Close();
	}

	private void ExitAppSettingsButton_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void uiStyleByDefaultThemeRadioButton_Click(object sender, EventArgs e)
	{
		currentGuiStyle = GuiStyle.Default;
	}

	private void uiStyleByLightThemeRadioButton_Click(object sender, EventArgs e)
	{
		currentGuiStyle = GuiStyle.Light;
	}

	private void uiStyleByDarkThemeRadioButton_Click(object sender, EventArgs e)
	{
		currentGuiStyle = GuiStyle.Dark;
	}

	public void SetupCurrentLocalizationForGUIControls()
	{
		FormLocaleSnapshot snapshot = Settings.CurrentLocalization.GetFormLocaleSnapshotByKey(Name);

		this.Text = snapshot.GetLocalizedValueByKey(this.Name);

		appColorThemeGroupBox.Text = snapshot.GetLocalizedValueByKey(appColorThemeGroupBox.Name);
		uiStyleByDefaultThemeRadioButton.Text = snapshot.GetLocalizedValueByKey(uiStyleByDefaultThemeRadioButton.Name);
		uiStyleByLightThemeRadioButton.Text = snapshot.GetLocalizedValueByKey(uiStyleByLightThemeRadioButton.Name);
		uiStyleByDarkThemeRadioButton.Text = snapshot.GetLocalizedValueByKey(uiStyleByDarkThemeRadioButton.Name);

		appLocalizationGroupBox.Text = snapshot.GetLocalizedValueByKey(appLocalizationGroupBox.Name);
		enableEngLocaleRadioButton.Text = snapshot.GetLocalizedValueByKey(enableEngLocaleRadioButton.Name);
		enableRusLocaleRadioButton.Text = snapshot.GetLocalizedValueByKey(enableRusLocaleRadioButton.Name);

		appFeaturesGroupBox.Text = snapshot.GetLocalizedValueByKey(appFeaturesGroupBox.Name);
		activatePresetsCheckBox.Text = snapshot.GetLocalizedValueByKey(activatePresetsCheckBox.Name);

		saveAppSettingsButton.Text = snapshot.GetLocalizedValueByKey(saveAppSettingsButton.Name);
		exitAppSettingsButton.Text = snapshot.GetLocalizedValueByKey(exitAppSettingsButton.Name);
	}
}
