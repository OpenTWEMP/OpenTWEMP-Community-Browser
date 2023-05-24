using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TWE_Launcher.Models;
using TWE_Launcher.Sources.Models.Localizations;

namespace TWE_Launcher.Forms
{
	public partial class MainLauncherForm : Form, ICanChangeMyLocalization
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

			SetupCurrentLocalizationForGUIControls();

			UpdateModificationsListBox();

			Text = GetApplicationFullName();
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

			listBoxMODS.ForeColor = colorTheme.CommonControlsForeColor;
			modMainTitleLabel.ForeColor = colorTheme.CommonControlsForeColor;
			modStatusLabel.ForeColor = colorTheme.CommonControlsForeColor;
		}


		public void SetupCurrentLocalizationForGUIControls()
		{
			FormLocaleSnapshot snapshot = Program.CurrentLocalization.GetFormLocaleSnapshotByKey(Name);

			buttonLaunch.Text = snapshot.GetLocalizedValueByKey(buttonLaunch.Name);
			modQuickNavigationButton.Text = snapshot.GetLocalizedValueByKey(modQuickNavigationButton.Name);
			buttonExplore.Text = snapshot.GetLocalizedValueByKey(buttonExplore.Name);

			groupBoxConfigCleanerMode.Text = snapshot.GetLocalizedValueByKey(groupBoxConfigCleanerMode.Name);
			checkBoxCleaner_MapRWM.Text = snapshot.GetLocalizedValueByKey(checkBoxCleaner_MapRWM.Name);
			checkBoxCleaner_textBIN.Text = snapshot.GetLocalizedValueByKey(checkBoxCleaner_textBIN.Name);
			checkBoxCleaner_soundPacks.Text = snapshot.GetLocalizedValueByKey(checkBoxCleaner_soundPacks.Name);

			groupBoxConfigLogMode.Text = snapshot.GetLocalizedValueByKey(groupBoxConfigLogMode.Name);
			radioButtonLogOnlyError.Text = snapshot.GetLocalizedValueByKey(radioButtonLogOnlyError.Name);
			radioButtonLogOnlyTrace.Text = snapshot.GetLocalizedValueByKey(radioButtonLogOnlyTrace.Name);
			radioButtonLogErrorAndTrace.Text = snapshot.GetLocalizedValueByKey(radioButtonLogErrorAndTrace.Name);
			checkBoxLogHistory.Text = snapshot.GetLocalizedValueByKey(checkBoxLogHistory.Name);

			groupBoxConfigLaunchMode.Text = snapshot.GetLocalizedValueByKey(groupBoxConfigLaunchMode.Name);
			radioButtonLaunchWindowScreen.Text = snapshot.GetLocalizedValueByKey(radioButtonLaunchWindowScreen.Name);
			radioButtonLaunchFullScreen.Text = snapshot.GetLocalizedValueByKey(radioButtonLaunchFullScreen.Name);
			checkBoxVideo.Text = snapshot.GetLocalizedValueByKey(checkBoxVideo.Name);
			checkBoxBorderless.Text = snapshot.GetLocalizedValueByKey(checkBoxBorderless.Name);
			checkBoxBorderless.Text = snapshot.GetLocalizedValueByKey(checkBoxBorderless.Name);

			toolStripAppItem.Text = snapshot.GetLocalizedValueByKey(toolStripAppItem.Name);
			gameSetupSettingsToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(gameSetupSettingsToolStripMenuItem.Name);
			applicationSettingsToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(applicationSettingsToolStripMenuItem.Name);
			applicationHomeFolderToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(applicationHomeFolderToolStripMenuItem.Name);
			exitFromApplicationToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(exitFromApplicationToolStripMenuItem.Name);

			toolStripHelpItem.Text = snapshot.GetLocalizedValueByKey(toolStripHelpItem.Name);
			aboutProgramToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(aboutProgramToolStripMenuItem.Name);
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
