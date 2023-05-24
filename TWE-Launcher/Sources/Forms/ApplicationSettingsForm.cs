using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TWE_Launcher.Forms;
using TWE_Launcher.Sources.Models.Localizations;

namespace TWE_Launcher.Forms
{
	public partial class AppSettingsForm : Form, ICanChangeMyLocalization
	{
		private MainLauncherForm currentCallingForm;
		private GuiStyle currentGuiStyle;

		public AppSettingsForm()
		{
			InitializeComponent();
		}

		public AppSettingsForm(MainLauncherForm callingForm)
		{
			InitializeComponent();

			currentCallingForm = callingForm;
			currentGuiStyle = InitializeCurrentGUIStyle();


			// check and update gui locale - if a form will be initialized again
			// update gui locale - if the form is already opened
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
			// Change GUI localization.
			//AppLocalizationManager.InitializeLocaleData();

			SaveGUIChanges(currentGuiStyle);
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






		// apply the current gui locale to form's controls
		public Dictionary<string, string> GetLocalizableGUIControls()
		{
			return new Dictionary<string, string>()
			{
				{ appColorThemeGroupBox.Name, appColorThemeGroupBox.Text },
				{ uiStyleByDefaultThemeRadioButton.Name, uiStyleByDefaultThemeRadioButton.Text },
				{ uiStyleByLightThemeRadioButton.Name, uiStyleByLightThemeRadioButton.Text },
				{ uiStyleByDarkThemeRadioButton.Name, uiStyleByDarkThemeRadioButton.Text }
			};
		}
	}
}
