// <copyright file="MainBrowserForm.Localization.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

internal partial class MainBrowserForm : IUpdatableBrowser, ICanChangeMyLocalization
{
    public void UpdateLocalizationForGUIControls()
    {
        this.SetupCurrentLocalizationForGUIControls();
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        FormLocaleSnapshot snapshot = Settings.CurrentLocalization.GetFormLocaleSnapshotByKey(Name);

        buttonLaunch.Text = snapshot.GetLocalizedValueByKey(buttonLaunch.Name);
        modQuickNavigationButton.Text = snapshot.GetLocalizedValueByKey(modQuickNavigationButton.Name);
        buttonExplore.Text = snapshot.GetLocalizedValueByKey(buttonExplore.Name);

        groupBoxConfigCleanerMode.Text = snapshot.GetLocalizedValueByKey(groupBoxConfigCleanerMode.Name);
        checkBoxCleaner_MapRWM.Text = snapshot.GetLocalizedValueByKey(checkBoxCleaner_MapRWM.Name);
        checkBoxCleaner_textBIN.Text = snapshot.GetLocalizedValueByKey(checkBoxCleaner_textBIN.Name);
        checkBoxCleaner_soundPacks.Text = snapshot.GetLocalizedValueByKey(checkBoxCleaner_soundPacks.Name);

        groupBoxConfigLogMode.Text = snapshot.GetLocalizedValueByKey(groupBoxConfigLogMode.Name);
        radioButtonLogOnlyError.Text = snapshot.GetLocalizedValueByKey(radioButtonLogOnlyError.Name);
        radioButtonLogOnlyTrace.Text = snapshot.GetLocalizedValueByKey(radioButtonLogOnlyTrace.Name);
        radioButtonLogErrorAndTrace.Text = snapshot.GetLocalizedValueByKey(radioButtonLogErrorAndTrace.Name);
        checkBoxLogHistory.Text = snapshot.GetLocalizedValueByKey(checkBoxLogHistory.Name);

        groupBoxConfigLaunchMode.Text = snapshot.GetLocalizedValueByKey(groupBoxConfigLaunchMode.Name);
        radioButtonLaunchWindowScreen.Text = snapshot.GetLocalizedValueByKey(radioButtonLaunchWindowScreen.Name);
        radioButtonLaunchFullScreen.Text = snapshot.GetLocalizedValueByKey(radioButtonLaunchFullScreen.Name);
        checkBoxVideo.Text = snapshot.GetLocalizedValueByKey(checkBoxVideo.Name);
        checkBoxBorderless.Text = snapshot.GetLocalizedValueByKey(checkBoxBorderless.Name);
        checkBoxBorderless.Text = snapshot.GetLocalizedValueByKey(checkBoxBorderless.Name);

        toolStripAppItem.Text = snapshot.GetLocalizedValueByKey(toolStripAppItem.Name);
        gameSetupSettingsToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(gameSetupSettingsToolStripMenuItem.Name);
        applicationSettingsToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(applicationSettingsToolStripMenuItem.Name);
        applicationHomeFolderToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(applicationHomeFolderToolStripMenuItem.Name);
        exitFromApplicationToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(exitFromApplicationToolStripMenuItem.Name);

        toolStripHelpItem.Text = snapshot.GetLocalizedValueByKey(toolStripHelpItem.Name);
        aboutProgramToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(aboutProgramToolStripMenuItem.Name);

        groupBoxConfigProfiles.Text = snapshot.GetLocalizedValueByKey(groupBoxConfigProfiles.Name);
        radioButtonConfigProfile_Gaming.Text = snapshot.GetLocalizedValueByKey(radioButtonConfigProfile_Gaming.Name);
        radioButtonConfigProfile_Modding.Text = snapshot.GetLocalizedValueByKey(radioButtonConfigProfile_Modding.Name);

        groupBoxLauncherProviders.Text = snapshot.GetLocalizedValueByKey(groupBoxLauncherProviders.Name);
        radioButtonLauncherProvider_TWEMP.Text = snapshot.GetLocalizedValueByKey(radioButtonLauncherProvider_TWEMP.Name);
        radioButtonLauncherProvider_BatchScript.Text = snapshot.GetLocalizedValueByKey(radioButtonLauncherProvider_BatchScript.Name);
        radioButtonLauncherProvider_NativeSetup.Text = snapshot.GetLocalizedValueByKey(radioButtonLauncherProvider_NativeSetup.Name);
        radioButtonLauncherProvider_M2TWEOP.Text = snapshot.GetLocalizedValueByKey(radioButtonLauncherProvider_M2TWEOP.Name);

        buttonCollectionManage.Text = snapshot.GetLocalizedValueByKey(buttonCollectionManage.Name);
        buttonCollectionCreate.Text = snapshot.GetLocalizedValueByKey(buttonCollectionCreate.Name);
        buttonMarkFavoriteMod.Text = snapshot.GetLocalizedValueByKey(buttonMarkFavoriteMod.Name);
    }
}
