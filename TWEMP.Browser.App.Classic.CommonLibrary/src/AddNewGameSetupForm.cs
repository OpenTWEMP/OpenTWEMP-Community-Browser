// <copyright file="AddNewGameSetupForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class AddNewGameSetupForm : Form, ICanChangeMyLocalization
{
    private GameSetupConfigForm currentCallingForm;

    public AddNewGameSetupForm(GameSetupConfigForm callingForm)
    {
        this.InitializeComponent();

        this.SetupCurrentLocalizationForGUIControls();

        this.currentCallingForm = callingForm;
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        this.Text = GetTextInCurrentLocalization(this.Name, this.Name);
        this.gameSetupGroupBox.Text = GetTextInCurrentLocalization(this.Name, this.gameSetupGroupBox.Name);
        this.gameSetupNameLabel.Text = GetTextInCurrentLocalization(this.Name, this.gameSetupNameLabel.Name);
        this.setupNameResetButton.Text = GetTextInCurrentLocalization(this.Name, this.setupNameResetButton.Name);
        this.gameExecutablePathLabel.Text = GetTextInCurrentLocalization(this.Name, this.gameExecutablePathLabel.Name);
        this.gameExecutableSelectPathButton.Text = GetTextInCurrentLocalization(this.Name, this.gameExecutableSelectPathButton.Name);
        this.modcentersGroupBox.Text = GetTextInCurrentLocalization(this.Name, this.modcentersGroupBox.Name);
        this.modcenterAppendButton.Text = GetTextInCurrentLocalization(this.Name, this.modcenterAppendButton.Name);
        this.modcenterRemoveButton.Text = GetTextInCurrentLocalization(this.Name, this.modcenterRemoveButton.Name);
        this.saveButton.Text = GetTextInCurrentLocalization(this.Name, this.saveButton.Name);
        this.cancelButton.Text = GetTextInCurrentLocalization(this.Name, this.cancelButton.Name);
    }

    private static bool CanSaveNewGameSetup(string setupName, string executable, List<string> modcenters)
    {
        if (modcenters.Count == 0)
        {
            MessageBox.Show("Can't create a new Game Setup without modcenters.", "Cannot Save a New Game Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        foreach (GameSetupInfo existingGameSetup in BrowserKernel.GameInstallations)
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

            string existingExecutablePath = Path.Combine(existingGameSetup.HomeDirectory!, existingGameSetup.ExecutableFileName!);

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

    private void InitializeViewOnlyMode()
    {
        this.Text = "[VIEW ONLY MODE] View Selected Game Setup";
        this.gameSetupNameLabel.Text = "Current Game Setup Name";
        this.gameExecutablePathLabel.Text = "Current Game Executable";
        this.modcentersGroupBox.Text = "Attached ModCenters";

        this.gameSetupNameTextBox.ReadOnly = true;
        this.gameExecutablePathTextBox.ReadOnly = true;
        this.gameExecutablePathTextBox.Enabled = true;

        this.setupNameResetButton.Visible = false;
        this.gameExecutableSelectPathButton.Visible = false;
        this.saveButton.Visible = false;
        this.cancelButton.Visible = false;
        this.modcenterAppendButton.Visible = false;
        this.modcenterRemoveButton.Visible = false;
    }

    private void LoadGameSetupObject(GameSetupInfo gameSetupInfo)
    {
        this.gameSetupNameTextBox.Text = gameSetupInfo.Name;
        this.gameExecutablePathTextBox.Text = Path.Combine(gameSetupInfo.HomeDirectory!, gameSetupInfo.ExecutableFileName!);

        foreach (ModCenterInfo modCenterInfo in gameSetupInfo.AttachedModCenters)
        {
            this.modcentersListBox.Items.Add(modCenterInfo.Location);
        }
    }

    private void AddNewGameSetupForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.UpdateCallingFormState();
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        string setupName = this.gameSetupNameTextBox.Text;
        string executable = this.gameExecutablePathTextBox.Text;
        List<string> modcenters = this.GetModCentersList();

        if (CanSaveNewGameSetup(setupName, executable, modcenters))
        {
            GameSetupInfo gameSetup = BrowserKernel.RegistrateGameInstallation(setupName, executable, modcenters);

            MessageBox.Show($"Added the \'{gameSetup.Name}\' Game Setup.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.currentCallingForm.UpdateGameSetupListBox();
            this.ExecuteSmartClosing();
        }
    }

    private List<string> GetModCentersList()
    {
        var modcenters = new List<string>();

        foreach (string modcenterPath in this.modcentersListBox.Items)
        {
            if (Directory.Exists(modcenterPath))
            {
                modcenters.Add(modcenterPath);
            }
        }

        return modcenters;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        this.ExecuteSmartClosing();
    }

    private void ExecuteSmartClosing()
    {
        this.Close();
        this.UpdateCallingFormState();
    }

    private void UpdateCallingFormState()
    {
        this.currentCallingForm.Enabled = true;
    }

    private void SetupNameResetButton_Click(object sender, EventArgs e)
    {
        this.gameSetupNameTextBox.Text = "MyGameSetupName";
    }

    private void GameExecutableSelectPathButton_Click(object sender, EventArgs e)
    {
        var executableFileDialog = new OpenFileDialog();
        DialogResult result = executableFileDialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            this.gameExecutablePathTextBox.Text = executableFileDialog.FileName;
        }
    }

    private void ModcentersListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.modcenterRemoveButton.Enabled = true;
    }

    private void ModcenterAppendButton_Click(object sender, EventArgs e)
    {
        var folderBrowserDialog = new FolderBrowserDialog();
        DialogResult result = folderBrowserDialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            string modcenterPath = folderBrowserDialog.SelectedPath;
            this.modcentersListBox.Items.Add(modcenterPath);
        }
    }

    private void ModcenterRemoveButton_Click(object sender, EventArgs e)
    {
        int selectedItemIndex = this.modcentersListBox.SelectedIndex;
        this.modcentersListBox.Items.RemoveAt(selectedItemIndex);
        this.modcenterRemoveButton.Enabled = false;
    }
}
