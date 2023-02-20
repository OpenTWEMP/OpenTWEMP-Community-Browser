using System;
using System.Drawing;
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

			modLogoPictureBox.Visible = false;
			aboutProjectPanel.Visible = true;
		}

		private void listBoxMODS_SelectedIndexChanged(object sender, EventArgs e)
		{
			GameModificationInfo current_mod = Settings.GetActiveModificationInfo(listBoxMODS.SelectedIndex);
			modMainTitleLabel.Text = current_mod.ShortName;
			EnableModUIControls();

			aboutProjectPanel.Visible = false;

			if (modLogoPictureBox.Image != null)
			{
				modLogoPictureBox.Image.Dispose();
				modLogoPictureBox.Image = null;
			}

			if (File.Exists(current_mod.LogotypeImage))
			{
				modLogoPictureBox.Load(current_mod.LogotypeImage);
				modLogoPictureBox.Visible = true;
			}
			else
			{
				aboutProjectNameLabel1.Visible = false;
				aboutProjectNameLabel2.Visible = false;
				errorModLogotypeNotFoundLabel.Visible = true;
				aboutProjectPanel.BackColor = Color.WhiteSmoke;

				aboutProjectPanel.Visible = true;
			}
		}

		private void DisableModUIControls()
		{
			panelLauncherOptions.Enabled = false;
			buttonLaunch.Enabled = false;
			buttonExplore.Enabled = false;
			modQuickNavigationButton.Enabled = false;
		}

		private void EnableModUIControls()
		{
			panelLauncherOptions.Enabled = true;
			buttonLaunch.Enabled = true;
			buttonExplore.Enabled = true;
			modQuickNavigationButton.Enabled = true;
		}


		private void buttonExit_Click(object sender, EventArgs e)
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

		private void importGameSetupButton_Click(object sender, EventArgs e)
		{
			var gameSetupConfigForm = new GameSetupConfigForm(this);

			Enabled = false;
			Visible= false;

			gameSetupConfigForm.Show();
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

		private void buttonShowHomeDirectory_Click(object sender, EventArgs e)
		{
			string appWorkDirectory = Directory.GetCurrentDirectory();
			SystemToolbox.ShowFileSystemDirectory(appWorkDirectory);
		}

		private void buttonAboutProject_Click(object sender, EventArgs e)
		{
			modLogoPictureBox.Visible = false;

			aboutProjectNameLabel1.Visible = true;
			aboutProjectNameLabel2.Visible = true;
			errorModLogotypeNotFoundLabel.Visible = false;
			aboutProjectPanel.BackColor = Color.Black;

			aboutProjectPanel.Visible = true;
		}



		private void uiStyleByDefaultThemeRadioButton_Click(object sender, EventArgs e)
		{
			ApplyUIStyle();
		}

		private void uiStyleByLightThemeRadioButton_Click(object sender, EventArgs e)
		{
			ApplyUIStyle();
		}

		private void uiStyleByDarkThemeRadioButton_Click(object sender, EventArgs e)
		{
			ApplyUIStyle();
		}


		private void ApplyUIStyle()
		{
			if (uiStyleByDefaultThemeRadioButton.Checked)
			{
				ApplyUIStyleByDefaultTheme();
			}

			if (uiStyleByLightThemeRadioButton.Checked)
			{
				ApplyUIStyleByLightTheme();
			}

			if (uiStyleByDarkThemeRadioButton.Checked)
			{
				ApplyUIStyleByDarkTheme();
			}
		}


		private void ApplyUIStyleByDefaultTheme()
		{
			BackColor= Color.DarkSeaGreen;

			aboutProjectReleaseLabel.BackColor = Color.MediumAquamarine;
			panelLauncherActions.BackColor = Color.MediumAquamarine;
			panelLauncherToolkit.BackColor = Color.MediumAquamarine;
			panelLauncherOptions.BackColor = Color.MediumAquamarine;

			listBoxMODS.BackColor= Color.MediumSeaGreen;
			modMainTitleLabel.BackColor = Color.MediumSeaGreen;

			importGameSetupButton.BackColor = Color.LightGreen;
			buttonLaunch.BackColor = Color.LightGreen;
			modQuickNavigationButton.BackColor = Color.LightGreen;
			buttonExplore.BackColor = Color.LightGreen;
			buttonAboutProject.BackColor = Color.LightGreen;
			buttonShowHomeDirectory.BackColor = Color.LightGreen;
			buttonExit.BackColor = Color.LightGreen;


			importGameSetupButton.ForeColor = Color.Black;
			buttonLaunch.ForeColor = Color.Black;
			modQuickNavigationButton.ForeColor = Color.Black;
			buttonExplore.ForeColor = Color.Black;
			buttonAboutProject.ForeColor = Color.Black;
			buttonShowHomeDirectory.ForeColor = Color.Black;
			buttonExit.ForeColor = Color.Black;

			groupBoxConfigLaunchMode.ForeColor = Color.Black;
			radioButtonLaunchWindowScreen.ForeColor = Color.Black;
			radioButtonLaunchFullScreen.ForeColor = Color.Black;
			checkBoxVideo.ForeColor = Color.Black;
			checkBoxBorderless.ForeColor = Color.Black;

			groupBoxConfigLogMode.ForeColor = Color.Black;
			radioButtonLogOnlyError.ForeColor = Color.Black;
			radioButtonLogOnlyTrace.ForeColor = Color.Black;
			radioButtonLogErrorAndTrace.ForeColor = Color.Black;
			checkBoxLogHistory.ForeColor = Color.Black;

			groupBoxConfigCleanerMode.ForeColor = Color.Black;
			checkBoxCleaner_MapRWM.ForeColor = Color.Black;
			checkBoxCleaner_textBIN.ForeColor = Color.Black;
			checkBoxCleaner_soundPacks.ForeColor = Color.Black;

			appColorThemeGroupBox.ForeColor = Color.Black;
			uiStyleByDarkThemeRadioButton.ForeColor = Color.Black;
			uiStyleByLightThemeRadioButton.ForeColor= Color.Black;
			uiStyleByDefaultThemeRadioButton.ForeColor = Color.Black;

			appLocalizationGroupBox.ForeColor= Color.Black;
			enableEngLocaleRadioButton.ForeColor = Color.Black;
			enableRusLocaleRadioButton.ForeColor= Color.Black;

			listBoxMODS.ForeColor = Color.Black;
			modMainTitleLabel.ForeColor = Color.Black;
			aboutProjectReleaseLabel.ForeColor = Color.Black;
		}

		private void ApplyUIStyleByLightTheme()
		{
			BackColor = Color.SeaShell;

			aboutProjectReleaseLabel.BackColor = Color.Azure;
			panelLauncherActions.BackColor = Color.Azure;
			panelLauncherToolkit.BackColor = Color.Azure;
			panelLauncherOptions.BackColor = Color.Azure;

			listBoxMODS.BackColor = Color.AliceBlue;
			modMainTitleLabel.BackColor = Color.AliceBlue;

			importGameSetupButton.BackColor = Color.GhostWhite;
			buttonLaunch.BackColor = Color.GhostWhite;
			modQuickNavigationButton.BackColor = Color.GhostWhite;
			buttonExplore.BackColor = Color.GhostWhite;
			buttonAboutProject.BackColor = Color.GhostWhite;
			buttonShowHomeDirectory.BackColor = Color.GhostWhite;
			buttonExit.BackColor = Color.GhostWhite;


			importGameSetupButton.ForeColor = Color.Black;
			buttonLaunch.ForeColor = Color.Black;
			modQuickNavigationButton.ForeColor = Color.Black;
			buttonExplore.ForeColor = Color.Black;
			buttonAboutProject.ForeColor = Color.Black;
			buttonShowHomeDirectory.ForeColor = Color.Black;
			buttonExit.ForeColor = Color.Black;

			groupBoxConfigLaunchMode.ForeColor = Color.Black;
			radioButtonLaunchWindowScreen.ForeColor = Color.Black;
			radioButtonLaunchFullScreen.ForeColor = Color.Black;
			checkBoxVideo.ForeColor = Color.Black;
			checkBoxBorderless.ForeColor = Color.Black;

			groupBoxConfigLogMode.ForeColor = Color.Black;
			radioButtonLogOnlyError.ForeColor = Color.Black;
			radioButtonLogOnlyTrace.ForeColor = Color.Black;
			radioButtonLogErrorAndTrace.ForeColor = Color.Black;
			checkBoxLogHistory.ForeColor = Color.Black;

			groupBoxConfigCleanerMode.ForeColor = Color.Black;
			checkBoxCleaner_MapRWM.ForeColor = Color.Black;
			checkBoxCleaner_textBIN.ForeColor = Color.Black;
			checkBoxCleaner_soundPacks.ForeColor = Color.Black;

			appColorThemeGroupBox.ForeColor = Color.Black;
			uiStyleByDarkThemeRadioButton.ForeColor = Color.Black;
			uiStyleByLightThemeRadioButton.ForeColor = Color.Black;
			uiStyleByDefaultThemeRadioButton.ForeColor = Color.Black;

			appLocalizationGroupBox.ForeColor = Color.Black;
			enableEngLocaleRadioButton.ForeColor = Color.Black;
			enableRusLocaleRadioButton.ForeColor = Color.Black;

			listBoxMODS.ForeColor = Color.Black;
			modMainTitleLabel.ForeColor = Color.Black;
			aboutProjectReleaseLabel.ForeColor = Color.Black;
		}

		private void ApplyUIStyleByDarkTheme()
		{
			BackColor = Color.DarkSlateGray;

			aboutProjectReleaseLabel.BackColor = Color.LightSlateGray;
			panelLauncherActions.BackColor = Color.LightSlateGray;
			panelLauncherToolkit.BackColor = Color.LightSlateGray;
			panelLauncherOptions.BackColor = Color.LightSlateGray;

			listBoxMODS.BackColor = Color.SlateGray;
			modMainTitleLabel.BackColor = Color.SlateGray;

			importGameSetupButton.BackColor = Color.DarkGray;
			buttonLaunch.BackColor = Color.DarkGray;
			modQuickNavigationButton.BackColor = Color.DarkGray;
			buttonExplore.BackColor = Color.DarkGray;
			buttonAboutProject.BackColor = Color.DarkGray;
			buttonShowHomeDirectory.BackColor = Color.DarkGray;
			buttonExit.BackColor = Color.DarkGray;


			importGameSetupButton.ForeColor = Color.Snow;
			buttonLaunch.ForeColor = Color.Snow;
			modQuickNavigationButton.ForeColor = Color.Snow;
			buttonExplore.ForeColor = Color.Snow;
			buttonAboutProject.ForeColor = Color.Snow;
			buttonShowHomeDirectory.ForeColor = Color.Snow;
			buttonExit.ForeColor = Color.Snow;

			groupBoxConfigLaunchMode.ForeColor = Color.Snow;
			radioButtonLaunchWindowScreen.ForeColor = Color.Snow;
			radioButtonLaunchFullScreen.ForeColor = Color.Snow;
			checkBoxVideo.ForeColor = Color.Snow;
			checkBoxBorderless.ForeColor = Color.Snow;

			groupBoxConfigLogMode.ForeColor = Color.Snow;
			radioButtonLogOnlyError.ForeColor = Color.Snow;
			radioButtonLogOnlyTrace.ForeColor = Color.Snow;
			radioButtonLogErrorAndTrace.ForeColor = Color.Snow;
			checkBoxLogHistory.ForeColor = Color.Snow;

			groupBoxConfigCleanerMode.ForeColor = Color.Snow;
			checkBoxCleaner_MapRWM.ForeColor = Color.Snow;
			checkBoxCleaner_textBIN.ForeColor = Color.Snow;
			checkBoxCleaner_soundPacks.ForeColor = Color.Snow;

			appColorThemeGroupBox.ForeColor = Color.Snow;
			uiStyleByDarkThemeRadioButton.ForeColor = Color.Snow;
			uiStyleByLightThemeRadioButton.ForeColor = Color.Snow;
			uiStyleByDefaultThemeRadioButton.ForeColor = Color.Snow;

			appLocalizationGroupBox.ForeColor = Color.Snow;
			enableEngLocaleRadioButton.ForeColor = Color.Snow;
			enableRusLocaleRadioButton.ForeColor = Color.Snow;

			listBoxMODS.ForeColor = Color.Snow;
			modMainTitleLabel.ForeColor = Color.Snow;
			aboutProjectReleaseLabel.ForeColor = Color.Snow;
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
			importGameSetupButton.Text = "GAME SETUP SETTINGS";
			buttonLaunch.Text = "LAUNCH";
			buttonExit.Text = "EXIT";
			buttonAboutProject.Text = "ABOUT";
			buttonShowHomeDirectory.Text = "APP HOME FOLDER";
			modQuickNavigationButton.Text = "MOD QUICK NAVIGATION";
			buttonExplore.Text = "MOD HOME FOLDER";

			appLocalizationGroupBox.Text = "Select GUI language";
			enableEngLocaleRadioButton.Text = "ENGLISH (by default)";
			enableRusLocaleRadioButton.Text = "RUSSIAN (in progress)";

			appColorThemeGroupBox.Text = "Select GUI style theme";
			uiStyleByDefaultThemeRadioButton.Text = "Standard Theme (by default)";
			uiStyleByLightThemeRadioButton.Text = "Light Theme";
			uiStyleByDarkThemeRadioButton.Text = "Dark Theme";

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

			errorModLogotypeNotFoundLabel.Text
				= "ERROR: Mod logotype image was not found."
				+ "Probably, caching was finished with failure.";
		}

		private void ApplyUILanguageOnRussian()
		{
			importGameSetupButton.Text = "ИГРОВЫЕ УСТАНОВКИ";
			buttonLaunch.Text = "ИГРАТЬ";
			buttonExit.Text = "ВЫХОД";
			buttonAboutProject.Text = "ИНФО";
			buttonShowHomeDirectory.Text = "ДОМАШНИЙ КАТАЛОГ ПРОГРАММЫ";
			modQuickNavigationButton.Text = "БЫСТРАЯ МОД-НАВИГАЦИЯ";
			buttonExplore.Text = "РАЗМЕЩЕНИЕ МОДИФИКАЦИИ";

			appLocalizationGroupBox.Text = "Выберите язык интерфейса программы";
			enableEngLocaleRadioButton.Text = "Английский (по умолчанию)";
			enableRusLocaleRadioButton.Text = "Русский (в процессе)";

			appColorThemeGroupBox.Text = "Выберите тему интерфейса программы";
			uiStyleByDefaultThemeRadioButton.Text = "Стандартная тема (по умолчанию)";
			uiStyleByLightThemeRadioButton.Text = "Светлая тема";
			uiStyleByDarkThemeRadioButton.Text = "Темная тема";

			groupBoxConfigCleanerMode.Text = "Выберите операции очистки мод-контента";
			checkBoxCleaner_MapRWM.Text = "Удалять файл map.rwm";
			checkBoxCleaner_textBIN.Text = "Удалять файлы локализации *strings.bin";
			checkBoxCleaner_soundPacks.Text = "Удалять звуковые pack-файлы (*.DAT + *.IDX)";

			groupBoxConfigLogMode.Text = "Выберите режим записи журнала system.log";
			radioButtonLogOnlyError.Text = "Только ошибки";
			radioButtonLogOnlyTrace.Text = "Только трассировка";
			radioButtonLogErrorAndTrace.Text = "Ошибки + трассировка";
			checkBoxLogHistory.Text = "Сохранять игровые логи system.log";

			groupBoxConfigLaunchMode.Text = "Выберите режим запуска игры";
			radioButtonLaunchWindowScreen.Text = "Оконный режим";
			radioButtonLaunchFullScreen.Text = "Полноэкранный режим";
			checkBoxVideo.Text = "Игровое видео";
			checkBoxBorderless.Text = "Оконный режим без границ";

			errorModLogotypeNotFoundLabel.Text 
				= "ОШИБКА: Изображение логотипа мода не было найдено. "
				+ "Возможно, произошла ошибка кэширования.";
		}
	}
}
