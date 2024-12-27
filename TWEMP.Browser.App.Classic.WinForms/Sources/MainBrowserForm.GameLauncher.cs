// <copyright file="MainBrowserForm.GameLauncher.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.App.Classic.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;
using TWEMP.Browser.Core.CommonLibrary.Utilities;
using TWEMP.Browser.Core.GamingSupport;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

internal partial class MainBrowserForm
{
    private static void ShowGameModLaunchErrorMessageBox(string messageText)
    {
        MessageBox.Show(
            text: messageText,
            caption: "ERROR",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Error);
    }

    private void ButtonLaunch_Click(object sender, EventArgs e)
    {
        TreeNode currentGameModNode = this.GetCurrentGameModNode();
        GameModificationInfo? currentGameModInfo = this.SelectGameModInfoFromBrowserTreeNode(currentGameModNode);

        this.InterruptGameModBackgroundMusic();

        if (currentGameModInfo == null)
        {
            ShowGameModLaunchErrorMessageBox("Cannot execute this game mod!");
        }
        else
        {
            var currentGameConfigurator = (M2TWGameConfigurator?)BrowserKernel.CurrentConfigurator;

            if (currentGameConfigurator == null)
            {
                ShowGameModLaunchErrorMessageBox("Cannot configure this game mod!");
                return;
            }

            M2TWCustomQuickConfigStateView currentQuickCustomConfigState = this.CreateQuickCustomConfigState();
            currentGameConfigurator.OverrideConfigSettingsByCustomQuickState(currentQuickCustomConfigState);

            this.ChangeLauncherGUIWhenGameStarting();
            MainGamingSupportHub.LaunchGameEngineAsM2TW(currentGameConfigurator, this.currentMessageProvider);
            this.ChangeLauncherGUIWhenGameExiting();

            this.SetCurrentGameModNode(currentGameModNode);
        }
    }

    private GameModificationInfo? SelectGameModInfoFromBrowserTreeNode(TreeNode treeNode)
    {
        GameModificationInfo? targetModInfo;

        if (this.IsNodeOfFavoriteCollection(treeNode) || this.IsNodeOfModificationFromCustomCollection(treeNode))
        {
            targetModInfo = this.FindModBySelectedNodeFromCollection(treeNode);
        }
        else if (this.IsNodeOfModificationFromAllModsCollection(treeNode))
        {
            targetModInfo = this.FindModificationBySelectedTreeNode(treeNode);
        }
        else
        {
            targetModInfo = null;
        }

        return targetModInfo;
    }

    private void ChangeLauncherGUIWhenGameStarting()
    {
        this.WindowState = FormWindowState.Minimized;
        this.ShowInTaskbar = false;
    }

    private void ChangeLauncherGUIWhenGameExiting()
    {
        this.ShowInTaskbar = true;
        this.WindowState = FormWindowState.Normal;
    }

    private void ModQuickNavigationButton_Click(object sender, EventArgs e)
    {
        GameModificationInfo currentMod = this.FindModBySelectedNodeFromCollection(this.treeViewGameMods.SelectedNode);
        var form = new ModQuickNavigatorForm(currentMod.Location);
        form.ShowDialog();
    }

    private void ButtonExplore_Click(object sender, EventArgs e)
    {
        GameModificationInfo current_mod_info = this.FindModBySelectedNodeFromCollection(this.treeViewGameMods.SelectedNode);
        SystemToolbox.ShowFileSystemDirectory(current_mod_info.Location, this.currentMessageProvider);
    }

    // PROVIDERS TO RUN THE SELECTED MODIFICATION
    private void RadioButtonLauncherProvider_M2TWEOP_CheckedChanged(object sender, EventArgs e)
    {
        this.DisableLauncherSettingsControls();
    }

    private void RadioButtonLauncherProvider_NativeSetup_CheckedChanged(object sender, EventArgs e)
    {
        this.DisableLauncherSettingsControls();
    }

    private void RadioButtonLauncherProvider_BatchScript_CheckedChanged(object sender, EventArgs e)
    {
        this.DisableLauncherSettingsControls();
    }

    private void RadioButtonLauncherProvider_TWEMP_CheckedChanged(object sender, EventArgs e)
    {
        this.EnableLauncherSettingsControls();
    }

    private void DisableLauncherSettingsControls()
    {
        this.groupBoxConfigProfiles.Enabled = false;
        this.groupBoxConfigLaunchMode.Enabled = false;
        this.groupBoxConfigLogMode.Enabled = false;
        this.groupBoxConfigCleanerMode.Enabled = false;
        this.modConfigSettingsButton.Enabled = false;
    }

    private void EnableLauncherSettingsControls()
    {
        this.groupBoxConfigProfiles.Enabled = true;
        this.groupBoxConfigLaunchMode.Enabled = true;
        this.groupBoxConfigLogMode.Enabled = true;
        this.groupBoxConfigCleanerMode.Enabled = true;
        this.modConfigSettingsButton.Enabled = true;
    }

    private void ModConfigSettingsButton_Click(object sender, EventArgs e)
    {
        GameModificationInfo gameModificationInfo = BrowserKernel.CurrentGameModView!.CurrentInfo;
        var modConfigSettingsForm = new ModConfigSettingsForm(gameModificationInfo);
        modConfigSettingsForm.ShowDialog();
    }

    private void ModConfigProfilesButton_Click(object sender, EventArgs e)
    {
        var gameConfigProfilesForm = new GameConfigProfilesForm();
        gameConfigProfilesForm.ShowDialog();
    }
}
