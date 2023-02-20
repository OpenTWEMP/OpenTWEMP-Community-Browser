using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using TWE_Launcher.Models;

namespace TWE_Launcher.Forms
{
	public partial class AddNewGameSetupForm : Form
	{
		private GameSetupConfigForm currentCallingForm;

		public AddNewGameSetupForm(GameSetupConfigForm callingForm)
		{
			InitializeComponent();
			currentCallingForm = callingForm;
		}

		public AddNewGameSetupForm(GameSetupConfigForm callingForm, GameSetupInfo gameSetupInfo)
		{
			InitializeComponent();
			InitializeViewOnlyMode();

			currentCallingForm = callingForm;
			LoadGameSetupObject(gameSetupInfo);
		}

		private void InitializeViewOnlyMode()
		{
			Text = "[VIEW ONLY MODE] View Selected Game Setup";
			gameSetupNameLabel.Text = "Current Game Setup Name";
			gameExecutablePathLabel.Text = "Current Game Executable";
			modcentersGroupBox.Text = "Attached ModCenters";

			gameSetupNameTextBox.ReadOnly = true;
			gameExecutablePathTextBox.ReadOnly = true;
			gameExecutablePathTextBox.Enabled = true;

			setupNameResetButton.Visible = false;
			gameExecutableSelectPathButton.Visible= false;
			saveButton.Visible = false;
			cancelButton.Visible = false;
			modcenterAppendButton.Visible = false;
			modcenterRemoveButton.Visible = false;
		}

		private void LoadGameSetupObject(GameSetupInfo gameSetupInfo)
		{
			gameSetupNameTextBox.Text = gameSetupInfo.Name;
			gameExecutablePathTextBox.Text = Path.Combine(gameSetupInfo.HomeDirectory, gameSetupInfo.ExecutableFileName);

			
			foreach (ModCenterInfo modCenterInfo in gameSetupInfo.AttachedModCenters)
			{
				modcentersListBox.Items.Add(modCenterInfo.Location);
			}
		}

		private void AddNewGameSetupForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			UpdateCallingFormState();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			string setupName = gameSetupNameTextBox.Text;
			string executable = gameExecutablePathTextBox.Text;
			List<string> modcenters = GetModCentersList();

			if (CanSaveNewGameSetup(setupName, executable, modcenters))
			{
				GameSetupInfo gameSetup = Settings.RegistrateGameInstallation(setupName, executable, modcenters);

				MessageBox.Show($"Added the \'{gameSetup.Name}\' Game Setup.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				currentCallingForm.UpdateGameSetupListBox();
				ExecuteSmartClosing();
			}
		}

		private bool CanSaveNewGameSetup(string setupName, string executable, List<string> modcenters)
		{
			if (modcenters.Count == 0)
			{
				MessageBox.Show("Can't create a new Game Setup without modcenters.", "Cannot Save a New Game Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			foreach (GameSetupInfo existingGameSetup in Settings.GameInstallations)
			{
				if (existingGameSetup.Name.Equals(setupName))
				{
					MessageBox.Show($"Game Setup with \'{setupName}\' name already exists.", "Cannot Save a New Game Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				if (!File.Exists(executable))
				{
					MessageBox.Show("Specified executable path does not exist.", "Cannot Save a New Game Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				string existingExecutablePath = Path.Combine(existingGameSetup.HomeDirectory, existingGameSetup.ExecutableFileName);

				if (existingExecutablePath.Equals(executable))
				{
					MessageBox.Show("Specified executable path is already used.", "Cannot Save a New Game Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				foreach (ModCenterInfo existingModCenter in existingGameSetup.AttachedModCenters)
				{
					foreach (string modcenter in modcenters)
					{
						if (existingModCenter.Location.Equals(modcenter))
						{
							MessageBox.Show($"Cannot use \'{modcenter}\' modcenter twice.", "Cannot Save a New Game Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
					}
				}
			}

			return true;
		}

		private List<string> GetModCentersList()
		{
			var modcenters = new List<string>();

			foreach (string modcenterPath in modcentersListBox.Items)
			{
				if (Directory.Exists(modcenterPath))
				{
					modcenters.Add(modcenterPath);
				}
			}

			return modcenters;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			ExecuteSmartClosing();
		}

		private void ExecuteSmartClosing()
		{
			Close();
			UpdateCallingFormState();
		}

		private void UpdateCallingFormState()
		{
			currentCallingForm.Enabled = true;
		}

		private void setupNameResetButton_Click(object sender, EventArgs e)
		{
			gameSetupNameTextBox.Text = "MyGameSetupName";
		}

		private void gameExecutableSelectPathButton_Click(object sender, EventArgs e)
		{
			var executableFileDialog = new OpenFileDialog();
			DialogResult result = executableFileDialog.ShowDialog();

			if (result == DialogResult.OK)
			{
				gameExecutablePathTextBox.Text = executableFileDialog.FileName;
			}
		}

		private void modcentersListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			modcenterRemoveButton.Enabled = true;
		}

		private void modcenterAppendButton_Click(object sender, EventArgs e)
		{
			var folderBrowserDialog = new FolderBrowserDialog();
			DialogResult result = folderBrowserDialog.ShowDialog();

			if (result == DialogResult.OK)
			{
				string modcenterPath = folderBrowserDialog.SelectedPath;
				modcentersListBox.Items.Add(modcenterPath);
			}
		}

		private void modcenterRemoveButton_Click(object sender, EventArgs e)
		{
			int selectedItemIndex = modcentersListBox.SelectedIndex;
			modcentersListBox.Items.RemoveAt(selectedItemIndex);
			modcenterRemoveButton.Enabled = false;
		}
	}
}
