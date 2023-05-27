using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TWE_Launcher.Models;

namespace TWE_Launcher.Forms
{
	public partial class GameSetupConfigForm : Form
	{
		private MainLauncherForm currentCallingForm;
		public GameSetupConfigForm(MainLauncherForm callingForm)
		{
			InitializeComponent();
			currentCallingForm = callingForm;
		}

		private void GameSetupConfigForm_Load(object sender, EventArgs e)
		{
			Settings.SynchronizeGameSetupSettings();
			InitializeGameSetupListBox(Settings.GameInstallations);
		}

		private void InitializeGameSetupListBox(List<GameSetupInfo> gameSetupsObjects)
		{
			foreach (var gameSetup in gameSetupsObjects)
			{
				string gameSetupInfoText = InitializeGameSetupObjectItem(gameSetup);
				gameSetupPathsListBox.Items.Add(gameSetupInfoText);
			}
		}

		private string InitializeGameSetupObjectItem(GameSetupInfo gameSetupObject)
		{
			string gameSetupInfoText =
				gameSetupObject.Name +
					" [" + gameSetupObject.HomeDirectory + "] " +
						"(" + gameSetupObject.ExecutableFileName + ")";

			return gameSetupInfoText;
		}

		public void UpdateGameSetupListBox()
		{
			gameSetupPathsListBox.Items.Clear();
			setupViewButton.Enabled = false;
			setupPathDeleteButton.Enabled = false;

			InitializeGameSetupListBox(Settings.GameInstallations);
		}

		private void GameSetupConfigForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			UpdateCallingFormState();
		}

		private void setupPathAddButton_Click(object sender, EventArgs e)
		{
			var gameSetupConfigForm = new AddNewGameSetupForm(this);
			Enabled = false;
			gameSetupConfigForm.Show();
		}

		private void setupPathDeleteButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = gameSetupPathsListBox.SelectedIndex;
			gameSetupPathsListBox.Items.RemoveAt(selectedIndex);
			Settings.DeleteGameSetupByIndex(selectedIndex);

			setupViewButton.Enabled = false;
			setupPathDeleteButton.Enabled = false;
		}

		private void allPathsClearButton_Click(object sender, EventArgs e)
		{
			gameSetupPathsListBox.Items.Clear();
			Settings.ClearAllSettings();
			currentCallingForm.UpdateModificationsTreeView();
		}

		private void formOkButton_Click(object sender, EventArgs e)
		{
			UpdateCallingFormState();
			Close();
		}

		private void UpdateCallingFormState()
		{
			currentCallingForm.UpdateModificationsTreeView();
			currentCallingForm.Visible = true;
			currentCallingForm.Enabled = true;
		}

		private void setupViewButton_Click(object sender, EventArgs e)
		{
			int selectedGameSetupIndex = gameSetupPathsListBox.SelectedIndex;
			GameSetupInfo editableGameSetup = Settings.GameInstallations[selectedGameSetupIndex];
			var gameSetupConfigForm = new AddNewGameSetupForm(this, editableGameSetup);
			Enabled = false;
			gameSetupConfigForm.Show();
		}

		private void gameSetupPathsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			setupViewButton.Enabled = true;
			setupPathDeleteButton.Enabled = true;
		}

		private void gameSetupPathsListBox_Click(object sender, EventArgs e)
		{
			if (gameSetupPathsListBox.SelectedItems.Count > 0)
			{
				setupViewButton.Enabled = true;
				setupPathDeleteButton.Enabled = true;
			}
		}
	}
}
