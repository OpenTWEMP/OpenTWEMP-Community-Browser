using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TWE_Launcher.Forms;
using TWE_Launcher.Sources.Models;
using TWE_Launcher.Sources.Models.Localizations;

namespace TWE_Launcher.Forms
{
	public partial class AppSettingsForm : Form, ICanChangeMyLocalization
	{
		private MainLauncherForm currentCallingForm;
		private GuiStyle currentGuiStyle;

		public AppSettingsForm(MainLauncherForm callingForm)
		{
			InitializeComponent();

			currentCallingForm = callingForm;
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

			SetupCurrentLocalizationForGUIControls();
		}


		private GuiStyle InitializeCurrentGUIStyle()
		{
			GuiStyle activeStyle = Program.CurrentGUIStyle;

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
			// 1. Change GUI style.

			SaveGUIChanges(currentGuiStyle);

			// 2. Change GUI localization.

			if (enableEngLocaleRadioButton.Checked)
			{
				string guiLocaleName_ENG = "ENG";
				Program.SetCurrentLocalizationByName(guiLocaleName_ENG);
			}

			if (enableRusLocaleRadioButton.Checked)
			{
				string guiLocaleName_RUS = "RUS";
				Program.SetCurrentLocalizationByName(guiLocaleName_RUS);
			}

			this.SetupCurrentLocalizationForGUIControls();
			currentCallingForm.SetupCurrentLocalizationForGUIControls();

			// 3. Close the form.

			Close();
		}

		private void SaveGUIChanges(GuiStyle style)
		{
			currentCallingForm.UpdateGUIStyle(style);
			Program.CurrentGUIStyle = style;
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
			FormLocaleSnapshot snapshot = Program.CurrentLocalization.GetFormLocaleSnapshotByKey(Name);

			this.Text = snapshot.GetLocalizedValueByKey(this.Name);

			appColorThemeGroupBox.Text = snapshot.GetLocalizedValueByKey(appColorThemeGroupBox.Name);
			uiStyleByDefaultThemeRadioButton.Text = snapshot.GetLocalizedValueByKey(uiStyleByDefaultThemeRadioButton.Name);
			uiStyleByLightThemeRadioButton.Text = snapshot.GetLocalizedValueByKey(uiStyleByLightThemeRadioButton.Name);
			uiStyleByDarkThemeRadioButton.Text = snapshot.GetLocalizedValueByKey(uiStyleByDarkThemeRadioButton.Name);

			appLocalizationGroupBox.Text = snapshot.GetLocalizedValueByKey(appLocalizationGroupBox.Name);
			enableEngLocaleRadioButton.Text = snapshot.GetLocalizedValueByKey(enableEngLocaleRadioButton.Name);
			enableRusLocaleRadioButton.Text = snapshot.GetLocalizedValueByKey(enableRusLocaleRadioButton.Name);

			saveAppSettingsButton.Text = snapshot.GetLocalizedValueByKey(saveAppSettingsButton.Name);
			exitAppSettingsButton.Text = snapshot.GetLocalizedValueByKey(exitAppSettingsButton.Name);
		}
	}
}
