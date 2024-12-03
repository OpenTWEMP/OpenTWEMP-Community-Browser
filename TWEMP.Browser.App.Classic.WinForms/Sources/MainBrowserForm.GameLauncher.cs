// <copyright file="MainBrowserForm.GameLauncher.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.App.Classic.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
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
        GameModificationInfo? currentGameModInfo = SelectGameModInfoFromBrowserTreeNode(currentGameModNode);

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

            M2TWCustomQuickConfigStateView currentQuickCustomConfigState = CreateQuickCustomConfigState();
            currentGameConfigurator.OverrideConfigSettingsByCustomQuickState(currentQuickCustomConfigState);

            ChangeLauncherGUIWhenGameStarting();
            MainGamingSupportHub.LaunchGameEngineAsM2TW(currentGameConfigurator, currentMessageProvider);
            ChangeLauncherGUIWhenGameExiting();

            this.SetCurrentGameModNode(currentGameModNode);
        }
    }

    private GameModificationInfo? SelectGameModInfoFromBrowserTreeNode(TreeNode treeNode)
    {
        GameModificationInfo? targetModInfo;

        if (IsNodeOfFavoriteCollection(treeNode) || IsNodeOfModificationFromCustomCollection(treeNode))
        {
            targetModInfo = FindModBySelectedNodeFromCollection(treeNode);
        }
        else if (IsNodeOfModificationFromAllModsCollection(treeNode))
        {
            targetModInfo = FindModificationBySelectedTreeNode(treeNode);
        }
        else
        {
            targetModInfo = null;
        }

        return targetModInfo;
    }

    private void ChangeLauncherGUIWhenGameStarting()
    {
        WindowState = FormWindowState.Minimized;
        ShowInTaskbar = false;
    }

    private void ChangeLauncherGUIWhenGameExiting()
    {
        ShowInTaskbar = true;
        WindowState = FormWindowState.Normal;
    }

    private void ModQuickNavigationButton_Click(object sender, EventArgs e)
    {
        GameModificationInfo currentMod = FindModBySelectedNodeFromCollection(treeViewGameMods.SelectedNode);
        var form = new ModQuickNavigatorForm(currentMod.Location);
        form.ShowDialog();
    }

    private void ButtonExplore_Click(object sender, EventArgs e)
    {
        GameModificationInfo current_mod_info = FindModBySelectedNodeFromCollection(treeViewGameMods.SelectedNode);
        SystemToolbox.ShowFileSystemDirectory(current_mod_info.Location, currentMessageProvider);
    }

    // PROVIDERS TO RUN THE SELECTED MODIFICATION
    private void RadioButtonLauncherProvider_M2TWEOP_CheckedChanged(object sender, EventArgs e)
    {
        DisableLauncherSettingsControls();
    }

    private void RadioButtonLauncherProvider_NativeSetup_CheckedChanged(object sender, EventArgs e)
    {
        DisableLauncherSettingsControls();
    }

    private void RadioButtonLauncherProvider_BatchScript_CheckedChanged(object sender, EventArgs e)
    {
        DisableLauncherSettingsControls();
    }

    private void RadioButtonLauncherProvider_TWEMP_CheckedChanged(object sender, EventArgs e)
    {
        EnableLauncherSettingsControls();
    }

    private void DisableLauncherSettingsControls()
    {
        groupBoxConfigProfiles.Enabled = false;
        groupBoxConfigLaunchMode.Enabled = false;
        groupBoxConfigLogMode.Enabled = false;
        groupBoxConfigCleanerMode.Enabled = false;
    }

    private void EnableLauncherSettingsControls()
    {
        groupBoxConfigProfiles.Enabled = true;
        groupBoxConfigLaunchMode.Enabled = true;
        groupBoxConfigLogMode.Enabled = true;
        groupBoxConfigCleanerMode.Enabled = true;
    }
}
