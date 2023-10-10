// <copyright file="MainBrowserForm.GameLauncher.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.App.Classic.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary;

internal partial class MainBrowserForm
{
    // LAUNCHER FEATURE TO RUN THE SELECTED MODIFICATION
    private void ButtonLaunch_Click(object sender, EventArgs e)
    {
        ChangeLauncherGUIWhenGameStarting();

        TreeNode modNode = treeViewGameMods.SelectedNode;

        GameModificationInfo targetModInfo;

        if (IsNodeOfFavoriteCollection(modNode) || IsNodeOfModificationFromCustomCollection(modNode))
        {
            targetModInfo = FindModBySelectedNodeFromCollection(modNode);
        }
        else if (IsNodeOfModificationFromAllModsCollection(modNode))
        {
            targetModInfo = FindModificationBySelectedTreeNode(modNode);
        }
        else
        {
            targetModInfo = null!;
            MessageBox.Show("ERROR: Cannot execute this MOD !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        CustomConfigState targetConfigState = GetCurrentGameConfigState();
        var launchConfiguration = new GameLaunchConfigurator(targetModInfo, targetConfigState);
        launchConfiguration.Execute();

        ChangeLauncherGUIWhenGameExiting();
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
        SystemToolbox.ShowFileSystemDirectory(current_mod_info.Location);
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
