// <copyright file="GameConfigProfilesForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

public partial class GameConfigProfilesForm : Form
{
    private Dictionary<int, Guid> viewOfGameConfigProfiles;

    public GameConfigProfilesForm()
    {
        this.viewOfGameConfigProfiles = new Dictionary<int, Guid>();

        this.InitializeComponent();
        this.InitializeGameConfigProfilesListBox();
    }

    public void ReturnToConfigProfilesFormAfterSuccessProfileCreation(GameConfigProfile createdProfile)
    {
        BrowserKernel.AddNewProfile(createdProfile);

        ShowConfigOperationResultMessageBox(
            messageBoxCaption: "<ADD NEW CFG>",
            messageBoxText: $"ADDED NEW CONFIG PROFILE:\n{createdProfile.Name}");

        this.InitializeGameConfigProfilesListBox();
    }

    public void ReturnToConfigProfilesFormAfterSuccessProfileUpdate(GameConfigProfile updatedProfile)
    {
        BrowserKernel.UpdateProfile(updatedProfile);

        ShowConfigOperationResultMessageBox(
            messageBoxCaption: "<UPDATE CFG>",
            messageBoxText: $"UPDATED CONFIG PROFILE:\n{updatedProfile.Name}");

        this.InitializeGameConfigProfilesListBox();
    }

    private static void ShowConfigOperationResultMessageBox(string messageBoxCaption, string messageBoxText)
    {
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        MessageBoxIcon icon = MessageBoxIcon.Information;

        MessageBox.Show(caption: messageBoxCaption, text: messageBoxText, buttons: buttons, icon: icon);
    }

    private static void ShowConfigErrorMessageBox(string messageBoxText)
    {
        string caption = "<ERROR>";
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        MessageBoxIcon icon = MessageBoxIcon.Error;

        MessageBox.Show(caption: caption, text: messageBoxText, buttons: buttons, icon: icon);
    }

    private void InitializeGameConfigProfilesListBox()
    {
        GameConfigProfile[] gameConfigProfiles = BrowserKernel.AvailableProfiles.ToArray();
        this.viewOfGameConfigProfiles = BrowserKernel.GetConfigProfilesToDisplay(gameConfigProfiles);

        this.gameConfigProfilesListBox.Items.Clear();
        object[] gameConfigProfileItems = BrowserKernel.GetNewConfigProfileItems(this.viewOfGameConfigProfiles);
        this.gameConfigProfilesListBox.Items.AddRange(gameConfigProfileItems);
    }

    private void GameConfigProfilesListBoxSelectedIndexChanged(object sender, EventArgs e)
    {
        object? selectedItem = this.gameConfigProfilesListBox.SelectedItem;

        if (selectedItem != null)
        {
            this.cfgProfileCurrentLabel.Text = selectedItem.ToString();
        }
    }

    private void ConfigProfileSelectButtonClick(object sender, EventArgs e)
    {
        UpdatableGameModificationView? gameModificationView = BrowserKernel.CurrentGameModView;

        if (gameModificationView == null)
        {
            ShowConfigErrorMessageBox("Cannot select a profile!\nSelect a game mod and try again.");
            return;
        }

        GameConfigProfileSwitchForm gameConfigProfileSwitchForm = new (gameModificationView);
        gameConfigProfileSwitchForm.ShowDialog();
    }

    private void ConfigProfileCreateButtonClick(object sender, EventArgs e)
    {
        UpdatableGameModificationView? gameModificationView = BrowserKernel.CurrentGameModView;

        if (gameModificationView == null)
        {
            ShowConfigErrorMessageBox("Cannot create a new profile!\nSelect a game mod and try again.");
            return;
        }

        GameConfigProfileCreateForm gameConfigProfileCreateForm = new (this, gameModificationView.CurrentInfo);
        gameConfigProfileCreateForm.ShowDialog();
    }

    private void ConfigProfileCopyButtonClick(object sender, EventArgs e)
    {
        object? selectedItem = this.gameConfigProfilesListBox.SelectedItem;

        if (selectedItem == null)
        {
            ShowConfigErrorMessageBox("Cannot copy a profile!\nSelect a profile and try again.");
            return;
        }

        int selectedItemIndex = this.gameConfigProfilesListBox.SelectedIndex;
        Guid gameConfigProfileId = this.viewOfGameConfigProfiles[selectedItemIndex];
        GameConfigProfile gameConfigProfile = BrowserKernel.SelectProfileById(gameConfigProfileId);

        BrowserKernel.CopyProfile(gameConfigProfile);

        ShowConfigOperationResultMessageBox(
            messageBoxCaption: "<COPY CFG>",
            messageBoxText: $"COPIED CONFIG PROFILE:\n{selectedItem}");

        this.InitializeGameConfigProfilesListBox();
    }

    private void ConfigProfileUpdateButtonClick(object sender, EventArgs e)
    {
        object? selectedItem = this.gameConfigProfilesListBox.SelectedItem;

        if (selectedItem == null)
        {
            ShowConfigErrorMessageBox("Cannot update a profile!\nSelect a profile and try again.");
            return;
        }

        int selectedItemIndex = this.gameConfigProfilesListBox.SelectedIndex;
        Guid gameConfigProfileId = this.viewOfGameConfigProfiles[selectedItemIndex];
        GameConfigProfile gameConfigProfile = BrowserKernel.SelectProfileById(gameConfigProfileId);

        GameConfigProfileCreateForm gameConfigProfileCreateForm = new (
            this, gameConfigProfile.TargetGameModInfo, gameConfigProfile);
        gameConfigProfileCreateForm.ShowDialog();
    }

    private void ConfigProfileDeleteButtonClick(object sender, EventArgs e)
    {
        object selectedItem = this.gameConfigProfilesListBox.SelectedItem!;

        if (selectedItem == null)
        {
            ShowConfigErrorMessageBox("Cannot delete a profile!\nSelect a profile and try again.");
            return;
        }

        int selectedItemIndex = this.gameConfigProfilesListBox.SelectedIndex;
        Guid gameConfigProfileId = this.viewOfGameConfigProfiles[selectedItemIndex];
        BrowserKernel.DeleteProfile(gameConfigProfileId);

        ShowConfigOperationResultMessageBox(
            messageBoxCaption: "<DELETE CFG>",
            messageBoxText: $"DELETED CONFIG PROFILE:\n{selectedItem}");

        this.InitializeGameConfigProfilesListBox();
    }

    private void ConfigProfilesDeleteAllButtonClick(object sender, EventArgs e)
    {
        BrowserKernel.DeleteAllProfiles();

        ShowConfigOperationResultMessageBox(
            messageBoxCaption: "<DELETE ALL CFGs>",
            messageBoxText: "DELETED ALL CONFIG PROFILES !!!");

        this.InitializeGameConfigProfilesListBox();
    }

    private void ConfigProfilesExportButtonClick(object sender, EventArgs e)
    {
        const string exportFileName = "export_profiles.json";
        BrowserKernel.ExportAllProfilesToFile(exportFileName);

        ShowConfigOperationResultMessageBox(
            messageBoxCaption: "<EXPORT ALL CFGs>",
            messageBoxText: $"All profiles were exported to the file:\n{exportFileName}");
    }

    private void ConfigProfilesImportButtonClick(object sender, EventArgs e)
    {
        OpenFileDialog importFileDialog = new ();
        importFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        DialogResult result = importFileDialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            string importFileFullName = importFileDialog.FileName;
            BrowserKernel.ImportAllProfilesFromFile(importFileFullName);

            ShowConfigOperationResultMessageBox(
                messageBoxCaption: "<IMPORT CFGs>",
                messageBoxText: $"Profiles were imported from the file:\n{importFileFullName}");

            this.InitializeGameConfigProfilesListBox();
        }
    }

    private void FormCloseButtonClick(object sender, EventArgs e)
    {
        this.Close();
    }
}
