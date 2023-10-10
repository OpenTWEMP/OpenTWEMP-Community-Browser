// <copyright file="MainBrowserForm.ToolStripMenu.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.App.Classic.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary;

internal partial class MainBrowserForm
{
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
        SystemToolbox.ShowFileSystemDirectory(appWorkDirectory);
    }

    private void ApplicationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var appSettingsForm = new AppSettingsForm(this);
        appSettingsForm.Show();
    }

    private void GameSetupSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var gameSetupConfigForm = new GameSetupConfigForm(this);

        Enabled = false;
        Visible = false;

        gameSetupConfigForm.Show();
    }

    private void ConfigSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var modConfigSettingsForm = new ModConfigSettingsForm();
        modConfigSettingsForm.Show();
    }

    private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var aboutProjectForm = new AboutProjectForm();
        aboutProjectForm.Show();
    }
}
