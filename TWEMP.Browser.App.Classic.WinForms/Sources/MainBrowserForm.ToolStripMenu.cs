// <copyright file="MainBrowserForm.ToolStripMenu.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.App.Classic.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;
using TWEMP.Browser.Core.CommonLibrary.Utilities;

internal partial class MainBrowserForm
{
    private static void ShowCannotConfigureGameModMessageBox()
    {
        MessageBox.Show(
            text: "Cannot configure a game mod!\nSelect a game mod and try again.",
            caption: "ERROR",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Error);
    }

    private void ExitFromApplicationToolStripMenuItem_Click(object sender, EventArgs e)
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

    private void ApplicationHomeFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string appWorkDirectory = Directory.GetCurrentDirectory();
        SystemToolbox.ShowFileSystemDirectory(appWorkDirectory, this.currentMessageProvider);
    }

    private void ApplicationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var appSettingsForm = new AppSettingsForm(this);
        appSettingsForm.ShowDialog();
    }

    private void GameSetupSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var gameSetupConfigForm = new GameSetupConfigForm(this);

        this.Enabled = false;
        this.Visible = false;

        gameSetupConfigForm.Show();
    }

    private void GameConfigProfilesSwitcherToolStripMenuItem_Click(object sender, EventArgs e)
    {
        UpdatableGameModificationView gameModificationView = BrowserKernel.CurrentGameModView!;

        if (gameModificationView == null)
        {
            ShowCannotConfigureGameModMessageBox();
        }
        else
        {
            GameConfigProfileSwitchForm gameConfigProfileSwitchForm = new (gameModificationView);
            gameConfigProfileSwitchForm.ShowDialog();
        }
    }

    private void GameConfigProfilesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var gameConfigProfilesForm = new GameConfigProfilesForm();
        gameConfigProfilesForm.ShowDialog();
    }

    private void ModSupportPresetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var appSettingsForm = new ModSupportPresetSettingsForm();
        appSettingsForm.ShowDialog();
    }

    private void GameMusicPlayerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var gameMusicPlayerForm = new GameMusicPlayerForm();
        gameMusicPlayerForm.ShowDialog();
    }

    private void ConfigSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        UpdatableGameModificationView gameModificationView = BrowserKernel.CurrentGameModView!;

        if (gameModificationView == null)
        {
            ShowCannotConfigureGameModMessageBox();
        }
        else
        {
            ModConfigSettingsForm modConfigSettingsForm = new (gameModificationView.CurrentInfo);
            modConfigSettingsForm.ShowDialog();
        }
    }

    private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var aboutProjectForm = new AboutProjectForm();
        aboutProjectForm.ShowDialog();
    }
}
