// <copyright file="GameSetupConfigForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class GameSetupConfigForm : Form, ICanChangeMyLocalization
{
    private readonly IUpdatableBrowser currentBrowser;

    public GameSetupConfigForm(IUpdatableBrowser browser)
    {
        this.InitializeComponent();

        this.SetupCurrentLocalizationForGUIControls();

        this.currentBrowser = browser;
    }

    public void UpdateGameSetupListBox()
    {
        this.gameSetupPathsListBox.Items.Clear();
        this.setupPathDeleteButton.Enabled = false;

        this.InitializeGameSetupListBox(BrowserKernel.GameInstallations);
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        this.Text = GetTextInCurrentLocalization(this.Name, this.Name);
        this.setupPathAddButton.Text = GetTextInCurrentLocalization(this.Name, this.setupPathAddButton.Name);
        this.setupPathDeleteButton.Text = GetTextInCurrentLocalization(this.Name, this.setupPathDeleteButton.Name);
        this.allPathsClearButton.Text = GetTextInCurrentLocalization(this.Name, this.allPathsClearButton.Name);
        this.formOkButton.Text = GetTextInCurrentLocalization(this.Name, this.formOkButton.Name);
    }

    private static string InitializeGameSetupObjectItem(GameSetupInfo gameSetupObject)
    {
        return gameSetupObject.Name +
            " [" + gameSetupObject.HomeDirectory + "] " +
                "(" + gameSetupObject.ExecutableFileName + ")";
    }

    private void GameSetupConfigForm_Load(object sender, EventArgs e)
    {
        BrowserKernel.SynchronizeGameSetupSettings();
        this.InitializeGameSetupListBox(BrowserKernel.GameInstallations);
    }

    private void InitializeGameSetupListBox(List<GameSetupInfo> gameSetupsObjects)
    {
        foreach (var gameSetup in gameSetupsObjects)
        {
            string gameSetupInfoText = InitializeGameSetupObjectItem(gameSetup);
            this.gameSetupPathsListBox.Items.Add(gameSetupInfoText);
        }
    }

    private void GameSetupConfigForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        this.UpdateCallingFormState();
    }

    private void SetupPathAddButton_Click(object sender, EventArgs e)
    {
        var gameSetupConfigForm = new AddNewGameSetupForm(this);
        this.Enabled = false;
        gameSetupConfigForm.Show();
    }

    private void SetupPathDeleteButton_Click(object sender, EventArgs e)
    {
        int selectedIndex = this.gameSetupPathsListBox.SelectedIndex;
        this.gameSetupPathsListBox.Items.RemoveAt(selectedIndex);
        BrowserKernel.DeleteGameSetupByIndex(selectedIndex);
        this.setupPathDeleteButton.Enabled = false;
    }

    private void AllPathsClearButton_Click(object sender, EventArgs e)
    {
        this.gameSetupPathsListBox.Items.Clear();
        BrowserKernel.ClearAllSettings();
        this.currentBrowser.UpdateModificationsTreeView();
    }

    private void FormOkButton_Click(object sender, EventArgs e)
    {
        this.UpdateCallingFormState();
        this.Close();
    }

    private void UpdateCallingFormState()
    {
        this.currentBrowser.UpdateModificationsTreeView();
        this.currentBrowser.Visible = true;
        this.currentBrowser.Enabled = true;
    }

    private void GameSetupPathsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.setupPathDeleteButton.Enabled = true;
    }

    private void GameSetupPathsListBox_Click(object sender, EventArgs e)
    {
        if (this.gameSetupPathsListBox.SelectedItems.Count > 0)
        {
            this.setupPathDeleteButton.Enabled = true;
        }
    }
}
