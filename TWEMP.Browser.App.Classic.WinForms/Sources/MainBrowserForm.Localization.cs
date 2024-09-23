// <copyright file="MainBrowserForm.Localization.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

internal partial class MainBrowserForm : IUpdatableBrowser, ICanChangeMyLocalization
{
    public void UpdateLocalizationForGUIControls()
    {
        this.SetupCurrentLocalizationForGUIControls();
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        buttonLaunch.Text = GetTextInCurrentLocalization(Name, buttonLaunch.Name);
        modQuickNavigationButton.Text = GetTextInCurrentLocalization(Name, modQuickNavigationButton.Name);
        buttonExplore.Text = GetTextInCurrentLocalization(Name, buttonExplore.Name);

        groupBoxConfigCleanerMode.Text = GetTextInCurrentLocalization(Name, groupBoxConfigCleanerMode.Name);
        checkBoxCleaner_MapRWM.Text = GetTextInCurrentLocalization(Name, checkBoxCleaner_MapRWM.Name);
        checkBoxCleaner_textBIN.Text = GetTextInCurrentLocalization(Name, checkBoxCleaner_textBIN.Name);
        checkBoxCleaner_soundPacks.Text = GetTextInCurrentLocalization(Name, checkBoxCleaner_soundPacks.Name);

        groupBoxConfigLogMode.Text = GetTextInCurrentLocalization(Name, groupBoxConfigLogMode.Name);
        radioButtonLogOnlyError.Text = GetTextInCurrentLocalization(Name, radioButtonLogOnlyError.Name);
        radioButtonLogOnlyTrace.Text = GetTextInCurrentLocalization(Name, radioButtonLogOnlyTrace.Name);
        radioButtonLogErrorAndTrace.Text = GetTextInCurrentLocalization(Name, radioButtonLogErrorAndTrace.Name);
        checkBoxLogHistory.Text = GetTextInCurrentLocalization(Name, checkBoxLogHistory.Name);

        groupBoxConfigLaunchMode.Text = GetTextInCurrentLocalization(Name, groupBoxConfigLaunchMode.Name);
        radioButtonLaunchWindowScreen.Text = GetTextInCurrentLocalization(Name, radioButtonLaunchWindowScreen.Name);
        radioButtonLaunchFullScreen.Text = GetTextInCurrentLocalization(Name, radioButtonLaunchFullScreen.Name);
        checkBoxVideo.Text = GetTextInCurrentLocalization(Name, checkBoxVideo.Name);
        checkBoxBorderless.Text = GetTextInCurrentLocalization(Name, checkBoxBorderless.Name);
        checkBoxBorderless.Text = GetTextInCurrentLocalization(Name, checkBoxBorderless.Name);

        toolStripAppItem.Text = GetTextInCurrentLocalization(Name, toolStripAppItem.Name);
        gameSetupSettingsToolStripMenuItem.Text = GetTextInCurrentLocalization(Name, gameSetupSettingsToolStripMenuItem.Name);
        applicationSettingsToolStripMenuItem.Text = GetTextInCurrentLocalization(Name, applicationSettingsToolStripMenuItem.Name);
        applicationHomeFolderToolStripMenuItem.Text = GetTextInCurrentLocalization(Name, applicationHomeFolderToolStripMenuItem.Name);
        exitFromApplicationToolStripMenuItem.Text = GetTextInCurrentLocalization(Name, exitFromApplicationToolStripMenuItem.Name);

        toolStripHelpItem.Text = GetTextInCurrentLocalization(Name, toolStripHelpItem.Name);
        aboutProgramToolStripMenuItem.Text = GetTextInCurrentLocalization(Name, aboutProgramToolStripMenuItem.Name);

        groupBoxConfigProfiles.Text = GetTextInCurrentLocalization(Name, groupBoxConfigProfiles.Name);
        radioButtonConfigProfile_Gaming.Text = GetTextInCurrentLocalization(Name, radioButtonConfigProfile_Gaming.Name);
        radioButtonConfigProfile_Modding.Text = GetTextInCurrentLocalization(Name, radioButtonConfigProfile_Modding.Name);

        groupBoxLauncherProviders.Text = GetTextInCurrentLocalization(Name, groupBoxLauncherProviders.Name);
        radioButtonLauncherProvider_TWEMP.Text = GetTextInCurrentLocalization(Name, radioButtonLauncherProvider_TWEMP.Name);
        radioButtonLauncherProvider_BatchScript.Text = GetTextInCurrentLocalization(Name, radioButtonLauncherProvider_BatchScript.Name);
        radioButtonLauncherProvider_NativeSetup.Text = GetTextInCurrentLocalization(Name, radioButtonLauncherProvider_NativeSetup.Name);
        radioButtonLauncherProvider_M2TWEOP.Text = GetTextInCurrentLocalization(Name, radioButtonLauncherProvider_M2TWEOP.Name);

        buttonCollectionManage.Text = GetTextInCurrentLocalization(Name, buttonCollectionManage.Name);
        buttonCollectionCreate.Text = GetTextInCurrentLocalization(Name, buttonCollectionCreate.Name);
        buttonMarkFavoriteMod.Text = GetTextInCurrentLocalization(Name, buttonMarkFavoriteMod.Name);
    }
}
