using System;
using System.Windows.Forms;
using TWE_Launcher.Forms;

namespace TWE_Launcher.Sources.Forms
{
	public partial class ApplicationSettingsForm : Form
	{
		private MainLauncherForm currentCallingForm;
		private GuiStyle currentGuiStyle;

		public ApplicationSettingsForm(MainLauncherForm callingForm)
		{
			InitializeComponent();

			currentCallingForm = callingForm;
			currentGuiStyle = InitializeCurrentGUIStyle();


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
	}
}
