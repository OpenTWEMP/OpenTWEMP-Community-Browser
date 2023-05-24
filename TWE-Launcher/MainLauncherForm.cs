using System;
using System.IO;
using System.Windows.Forms;

using TWE_Launcher.Models;


namespace TWE_Launcher.Forms
{
	public partial class MainLauncherForm : Form
	{
		public RadioButton RadioButton_FullScreenMode => radioButtonLaunchFullScreen;
		public RadioButton RadioButton_WindowedMode => radioButtonLaunchWindowScreen;
		public CheckBox CheckBox_Video => checkBoxVideo;
		public CheckBox CheckBox_Borderless => checkBoxBorderless;

		public RadioButton RadioButton_LogErrorAndTrace => radioButtonLogErrorAndTrace;

		public RadioButton RadioButton_LogOnlyTrace => radioButtonLogOnlyTrace;
		public RadioButton RadioButton_LogOnlyError => radioButtonLogOnlyError;

		public CheckBox CheckBox_Cleaner_MapRWM => checkBoxCleaner_MapRWM;
		public CheckBox CheckBox_Cleaner_textBIN => checkBoxCleaner_textBIN;
		public CheckBox CheckBox_Cleaner_soundPacks => checkBoxCleaner_soundPacks;

		public CheckBox CheckBox_LogHistory => checkBoxLogHistory;


		public MainLauncherForm()
		{
			InitializeComponent();
			UpdateModificationsListBox();

			Text = GetApplicationFullName();
		}

		public MainLauncherForm(ref string localeSnapshotByDefault)
		{
			InitializeComponent();

			//
		}


		private static string GetApplicationFullName()
		{
			string appProjectTitle = "OpenTWEMP Community Browser";
			string appCurrentVersion = "Preview 2023.1";
			string appHomeFolder = Application.ExecutablePath;

			return appProjectTitle + " - " + appCurrentVersion + " [ " + appHomeFolder + " ]";
		}

		public void UpdateModificationsListBox()
		{
			listBoxMODS.Enabled = false;
			listBoxMODS.Items.Clear();

			Settings.UpdateTotalModificationsList();

			foreach (GameModificationInfo modification in Settings.TotalModificationsList)
			{
				listBoxMODS.Items.Add(modification.ShortName);
			}

			DisableModUIControls();
			listBoxMODS.Enabled = true;

			modMainTitleLabel.Text = string.Empty;
			modStatusLabel.Text = string.Empty;
			modLogoPictureBox.Visible = false;
		}

		private void listBoxMODS_SelectedIndexChanged(object sender, EventArgs e)
		{
			GameModificationInfo current_mod = Settings.GetActiveModificationInfo(listBoxMODS.SelectedIndex);
			current_mod.ShowModVisitingCard(modLogoPictureBox, modStatusLabel);
			modMainTitleLabel.Text = current_mod.ShortName;
			EnableModUIControls();
		}

		private void DisableModUIControls()
		{
			groupBoxConfigLaunchMode.Enabled = false;
			groupBoxConfigLogMode.Enabled = false;
			groupBoxConfigCleanerMode.Enabled = false;

			buttonLaunch.Enabled = false;
			buttonExplore.Enabled = false;
			modQuickNavigationButton.Enabled = false;
		}

		private void EnableModUIControls()
		{
			groupBoxConfigLaunchMode.Enabled = true;
			groupBoxConfigLogMode.Enabled = true;
			groupBoxConfigCleanerMode.Enabled = true;

			buttonLaunch.Enabled = true;
			buttonExplore.Enabled = true;
			modQuickNavigationButton.Enabled = true;
		}

		private void changeLauncherGUIWhenGameStarting()
		{
			WindowState = FormWindowState.Minimized;
			ShowInTaskbar = false;
		}

		private void changeLauncherGUIWhenGameExiting()
		{
			ShowInTaskbar = true;
			WindowState = FormWindowState.Normal;
		}


		private void buttonLaunch_Click(object sender, EventArgs e)
		{
			changeLauncherGUIWhenGameStarting();

			var custom_config_state = new CustomConfigState(this);
			GameModificationInfo selected_modification = Settings.GetActiveModificationInfo(listBoxMODS.SelectedIndex);
			LaunchConfiguration launchConfiguration = new LaunchConfiguration(selected_modification, custom_config_state);
			launchConfiguration.Execute();

			changeLauncherGUIWhenGameExiting();
		}

		private void modQuickNavigationButton_Click(object sender, EventArgs e)
		{
			int selectedModIndex = listBoxMODS.SelectedIndex;
			GameModificationInfo currentMod = Settings.GetActiveModificationInfo(selectedModIndex);
			var form = new ModQuickNavigatorForm(currentMod.Location);
			form.ShowDialog();
		}

		private void buttonExplore_Click(object sender, EventArgs e)
		{
			int current_mod_index = listBoxMODS.SelectedIndex;
			GameModificationInfo current_mod_info = Settings.GetActiveModificationInfo(current_mod_index);
			SystemToolbox.ShowFileSystemDirectory(current_mod_info.Location);
		}


		private void modConfigSettingsButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Config Settings");
		}

		private void buttonAboutProject_Click(object sender, EventArgs e)
		{

		}



		// COLOR THEMES FOR THE LAUNCHER


		public void UpdateGUIStyle(GuiStyle style)
		{
			ColorTheme colorTheme = ColorTheme.SelectColorThemeByStyle(style);

			// Set back color for main form.
			BackColor = colorTheme.MainFormBackColor;

			// Set back color for panels.
			panelLauncherToolkit.BackColor = colorTheme.PanelsBackColor;
			panelLauncherOptions.BackColor = colorTheme.PanelsBackColor;

			// Set back color for mod UI controls.
			listBoxMODS.BackColor = colorTheme.ModControlsBackColor;
			modMainTitleLabel.BackColor = colorTheme.ModControlsBackColor;
			modStatusLabel.BackColor = colorTheme.ModControlsBackColor;

			// Set back color for common UI controls.
			buttonLaunch.BackColor = colorTheme.CommonControlsBackColor;
			modQuickNavigationButton.BackColor = colorTheme.CommonControlsBackColor;
			buttonExplore.BackColor = colorTheme.CommonControlsBackColor;


			// Set fore color for common UI controls.

			buttonLaunch.ForeColor = colorTheme.CommonControlsForeColor;
			modQuickNavigationButton.ForeColor = colorTheme.CommonControlsForeColor;
			buttonExplore.ForeColor = colorTheme.CommonControlsForeColor;

			groupBoxConfigLaunchMode.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLaunchWindowScreen.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLaunchFullScreen.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxVideo.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxBorderless.ForeColor = colorTheme.CommonControlsForeColor;

			groupBoxConfigLogMode.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLogOnlyError.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLogOnlyTrace.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLogErrorAndTrace.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxLogHistory.ForeColor = colorTheme.CommonControlsForeColor;

			groupBoxConfigCleanerMode.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxCleaner_MapRWM.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxCleaner_textBIN.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxCleaner_soundPacks.ForeColor = colorTheme.CommonControlsForeColor;

			//appColorThemeGroupBox.ForeColor = colorTheme.CommonControlsForeColor;
			//uiStyleByDarkThemeRadioButton.ForeColor = colorTheme.CommonControlsForeColor;
			//uiStyleByLightThemeRadioButton.ForeColor = colorTheme.CommonControlsForeColor;
			//uiStyleByDefaultThemeRadioButton.ForeColor = colorTheme.CommonControlsForeColor;

			appLocalizationGroupBox.ForeColor = colorTheme.CommonControlsForeColor;
			enableEngLocaleRadioButton.ForeColor = colorTheme.CommonControlsForeColor;
			enableRusLocaleRadioButton.ForeColor = colorTheme.CommonControlsForeColor;

			listBoxMODS.ForeColor = colorTheme.CommonControlsForeColor;
			modMainTitleLabel.ForeColor = colorTheme.CommonControlsForeColor;
			modStatusLabel.ForeColor = colorTheme.CommonControlsForeColor;
		}


		private void enableEngLocaleRadioButton_Click(object sender, EventArgs e)
		{
			ChangeUILanguage();
		}

		private void enableRusLocaleRadioButton_Click(object sender, EventArgs e)
		{
			ChangeUILanguage();
		}

		private void ChangeUILanguage()
		{
			if (enableEngLocaleRadioButton.Checked)
			{
				ApplyUILanguageOnEnglish();
			}

			if (enableRusLocaleRadioButton.Checked)
			{
				ApplyUILanguageOnRussian();
			}
		}


		private void ApplyUILanguageOnEnglish()
		{
			buttonLaunch.Text = "LAUNCH";
			modQuickNavigationButton.Text = "MOD QUICK NAVIGATION";
			buttonExplore.Text = "MOD HOME FOLDER";

			appLocalizationGroupBox.Text = "Select GUI language";
			enableEngLocaleRadioButton.Text = "ENGLISH (by default)";
			enableRusLocaleRadioButton.Text = "RUSSIAN (in progress)";

			//appColorThemeGroupBox.Text = "Select GUI style theme";
			//uiStyleByDefaultThemeRadioButton.Text = "Standard Theme (by default)";
			//uiStyleByLightThemeRadioButton.Text = "Light Theme";
			//uiStyleByDarkThemeRadioButton.Text = "Dark Theme";

			groupBoxConfigCleanerMode.Text = "Select mod clean routines";
			checkBoxCleaner_MapRWM.Text = "Delete map.rwm file";
			checkBoxCleaner_textBIN.Text = "Delete localization *strings.bin files";
			checkBoxCleaner_soundPacks.Text = "Delete sound pack files (*.DAT + *.IDX)";

			groupBoxConfigLogMode.Text = "Select a mode of creating system.log file";
			radioButtonLogOnlyError.Text = "Only Errors";
			radioButtonLogOnlyTrace.Text = "Only Trace";
			radioButtonLogErrorAndTrace.Text = "Errors + Trace";
			checkBoxLogHistory.Text = "Save game system.log files";

			groupBoxConfigLaunchMode.Text = "Select game launch mode";
			radioButtonLaunchWindowScreen.Text = "Windowed Mode";
			radioButtonLaunchFullScreen.Text = "Full-Screen Mode";
			checkBoxVideo.Text = "Enable Game Video";
			checkBoxBorderless.Text = "Borderless Windowed Mode";
		}

		private void ApplyUILanguageOnRussian()
		{
			buttonLaunch.Text = "ИГРАТЬ";
			modQuickNavigationButton.Text = "БЫСТРАЯ МОД-НАВИГАЦИЯ";
			buttonExplore.Text = "РАЗМЕЩЕНИЕ МОДИФИКАЦИИ";

			appLocalizationGroupBox.Text = "Выберите язык GUI программы";
			enableEngLocaleRadioButton.Text = "Английский (по умолчанию)";
			enableRusLocaleRadioButton.Text = "Русский (в процессе)";

			groupBoxConfigCleanerMode.Text = "Выберите операции очистки для мода";
			checkBoxCleaner_MapRWM.Text = "Удалять файл map.rwm";
			checkBoxCleaner_textBIN.Text = "Удалять файлы *strings.bin";
			checkBoxCleaner_soundPacks.Text = "Удалять pack-файлы (*.DAT + *.IDX)";

			groupBoxConfigLogMode.Text = "Выберите режим записи журнала";
			radioButtonLogOnlyError.Text = "Только ошибки";
			radioButtonLogOnlyTrace.Text = "Только трассировка";
			radioButtonLogErrorAndTrace.Text = "Ошибки + трассировка";
			checkBoxLogHistory.Text = "Сохранять журналы system.log";

			groupBoxConfigLaunchMode.Text = "Выберите режим запуска игры";
			radioButtonLaunchWindowScreen.Text = "Оконный режим";
			radioButtonLaunchFullScreen.Text = "Полноэкранный режим";
			checkBoxVideo.Text = "Игровое видео";
			checkBoxBorderless.Text = "Оконный режим без границ";
		}



		private void exitFromApplicationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			const string MESSAGE_CAPTION = "Exit from the Application";
			const string MESSAGE_TEXT = "Do you want to exit from the program ?";
			MessageBoxButtons exit_dialog_buttons = MessageBoxButtons.OKCancel;
			MessageBoxIcon exit_dialog_icon = MessageBoxIcon.Question;

			DialogResult exitDialogResult = MessageBox.Show(
				MESSAGE_TEXT, MESSAGE_CAPTION, exit_dialog_buttons, exit_dialog_icon);

			if (exitDialogResult == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private void applicationHomeFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string appWorkDirectory = Directory.GetCurrentDirectory();
			SystemToolbox.ShowFileSystemDirectory(appWorkDirectory);
		}

		private void applicationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var appSettingsForm = new AppSettingsForm(this);
			appSettingsForm.Show();
		}

		private void gameSetupSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var gameSetupConfigForm = new GameSetupConfigForm(this);

			Enabled = false;
			Visible = false;

			gameSetupConfigForm.Show();
		}

		private void configSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var modConfigSettingsForm = new ModConfigSettingsForm();
			modConfigSettingsForm.Show();
		}

		private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var aboutProjectForm = new AboutProjectForm();
			aboutProjectForm.Show();
		}
	}
}
