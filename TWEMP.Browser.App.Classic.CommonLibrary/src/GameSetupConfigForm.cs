// <copyright file="GameSetupConfigForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class GameSetupConfigForm : Form, ICanChangeMyLocalization
{
    private readonly IUpdatableBrowser currentBrowser;

    public GameSetupConfigForm(IUpdatableBrowser browser)
    {
        InitializeComponent();

        SetupCurrentLocalizationForGUIControls();

        currentBrowser = browser;
    }

    public void UpdateGameSetupListBox()
    {
        gameSetupPathsListBox.Items.Clear();
        setupPathDeleteButton.Enabled = false;

        InitializeGameSetupListBox(BrowserKernel.GameInstallations);
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        Text = GetTextInCurrentLocalization(Name, Name);
        setupPathAddButton.Text = GetTextInCurrentLocalization(Name, setupPathAddButton.Name);
        setupPathDeleteButton.Text = GetTextInCurrentLocalization(Name, setupPathDeleteButton.Name);
        allPathsClearButton.Text = GetTextInCurrentLocalization(Name, allPathsClearButton.Name);
        formOkButton.Text = GetTextInCurrentLocalization(Name, formOkButton.Name);
    }

    private static string InitializeGameSetupObjectItem(GameSetupInfo gameSetupObject)
    {
        return gameSetupObject.Name +
            " [" + gameSetupObject.HomeDirectory + "] " +
                "(" + gameSetupObject.ExecutableFileName + ")";
    }

    private void GameSetupConfigForm_Load(object sender, EventArgs e)
    {
        Settings.SynchronizeGameSetupSettings();
        InitializeGameSetupListBox(BrowserKernel.GameInstallations);
    }

    private void InitializeGameSetupListBox(List<GameSetupInfo> gameSetupsObjects)
    {
        foreach (var gameSetup in gameSetupsObjects)
        {
            string gameSetupInfoText = InitializeGameSetupObjectItem(gameSetup);
            gameSetupPathsListBox.Items.Add(gameSetupInfoText);
        }
    }

    private void GameSetupConfigForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        UpdateCallingFormState();
    }

    private void SetupPathAddButton_Click(object sender, EventArgs e)
    {
        var gameSetupConfigForm = new AddNewGameSetupForm(this);
        Enabled = false;
        gameSetupConfigForm.Show();
    }

    private void SetupPathDeleteButton_Click(object sender, EventArgs e)
    {
        int selectedIndex = gameSetupPathsListBox.SelectedIndex;
        gameSetupPathsListBox.Items.RemoveAt(selectedIndex);
        Settings.DeleteGameSetupByIndex(selectedIndex);
        setupPathDeleteButton.Enabled = false;
    }

    private void AllPathsClearButton_Click(object sender, EventArgs e)
    {
        gameSetupPathsListBox.Items.Clear();
        Settings.ClearAllSettings();
        currentBrowser.UpdateModificationsTreeView();
    }

    private void FormOkButton_Click(object sender, EventArgs e)
    {
        UpdateCallingFormState();
        Close();
    }

    private void UpdateCallingFormState()
    {
        currentBrowser.UpdateModificationsTreeView();
        currentBrowser.Visible = true;
        currentBrowser.Enabled = true;
    }

    private void GameSetupPathsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        setupPathDeleteButton.Enabled = true;
    }

    private void GameSetupPathsListBox_Click(object sender, EventArgs e)
    {
        if (gameSetupPathsListBox.SelectedItems.Count > 0)
        {
            setupPathDeleteButton.Enabled = true;
        }
    }
}
