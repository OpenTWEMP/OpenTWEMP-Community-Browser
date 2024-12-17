// <copyright file="MainBrowserForm.Localization.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

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
        this.buttonLaunch.Text = GetTextInCurrentLocalization(this.Name, this.buttonLaunch.Name);
        this.modConfigSettingsButton.Text = GetTextInCurrentLocalization(this.Name, this.modConfigSettingsButton.Name);
        this.modQuickNavigationButton.Text = GetTextInCurrentLocalization(this.Name, this.modQuickNavigationButton.Name);
        this.buttonExplore.Text = GetTextInCurrentLocalization(this.Name, this.buttonExplore.Name);

        this.groupBoxConfigCleanerMode.Text = GetTextInCurrentLocalization(this.Name, this.groupBoxConfigCleanerMode.Name);
        this.checkBoxCleaner_MapRWM.Text = GetTextInCurrentLocalization(this.Name, this.checkBoxCleaner_MapRWM.Name);
        this.checkBoxCleaner_textBIN.Text = GetTextInCurrentLocalization(this.Name, this.checkBoxCleaner_textBIN.Name);
        this.checkBoxCleaner_soundPacks.Text = GetTextInCurrentLocalization(this.Name, this.checkBoxCleaner_soundPacks.Name);

        this.groupBoxConfigLogMode.Text = GetTextInCurrentLocalization(this.Name, this.groupBoxConfigLogMode.Name);
        this.radioButtonLogOnlyError.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonLogOnlyError.Name);
        this.radioButtonLogOnlyTrace.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonLogOnlyTrace.Name);
        this.radioButtonLogErrorAndTrace.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonLogErrorAndTrace.Name);
        this.checkBoxLogHistory.Text = GetTextInCurrentLocalization(this.Name, this.checkBoxLogHistory.Name);

        this.groupBoxConfigLaunchMode.Text = GetTextInCurrentLocalization(this.Name, this.groupBoxConfigLaunchMode.Name);
        this.radioButtonLaunchWindowScreen.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonLaunchWindowScreen.Name);
        this.radioButtonLaunchFullScreen.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonLaunchFullScreen.Name);
        this.checkBoxVideo.Text = GetTextInCurrentLocalization(this.Name, this.checkBoxVideo.Name);
        this.checkBoxBorderless.Text = GetTextInCurrentLocalization(this.Name, this.checkBoxBorderless.Name);
        this.checkBoxBorderless.Text = GetTextInCurrentLocalization(this.Name, this.checkBoxBorderless.Name);

        this.toolStripAppItem.Text = GetTextInCurrentLocalization(this.Name, this.toolStripAppItem.Name!);
        this.gameSetupSettingsToolStripMenuItem.Text = GetTextInCurrentLocalization(this.Name, this.gameSetupSettingsToolStripMenuItem.Name!);
        this.modSupportPresetSettingsToolStripMenuItem.Text = GetTextInCurrentLocalization(this.Name, this.modSupportPresetSettingsToolStripMenuItem.Name!);
        this.applicationSettingsToolStripMenuItem.Text = GetTextInCurrentLocalization(this.Name, this.applicationSettingsToolStripMenuItem.Name!);
        this.applicationHomeFolderToolStripMenuItem.Text = GetTextInCurrentLocalization(this.Name, this.applicationHomeFolderToolStripMenuItem.Name!);
        this.exitFromApplicationToolStripMenuItem.Text = GetTextInCurrentLocalization(this.Name, this.exitFromApplicationToolStripMenuItem.Name!);

        this.toolStripHelpItem.Text = GetTextInCurrentLocalization(this.Name, this.toolStripHelpItem.Name!);
        this.aboutProgramToolStripMenuItem.Text = GetTextInCurrentLocalization(this.Name, this.aboutProgramToolStripMenuItem.Name!);

        this.groupBoxConfigProfiles.Text = GetTextInCurrentLocalization(this.Name, this.groupBoxConfigProfiles.Name);
        this.radioButtonConfigProfile_Gaming.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonConfigProfile_Gaming.Name);
        this.radioButtonConfigProfile_Modding.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonConfigProfile_Modding.Name);

        this.groupBoxLauncherProviders.Text = GetTextInCurrentLocalization(this.Name, this.groupBoxLauncherProviders.Name);
        this.radioButtonLauncherProvider_TWEMP.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonLauncherProvider_TWEMP.Name);
        this.radioButtonLauncherProvider_BatchScript.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonLauncherProvider_BatchScript.Name);
        this.radioButtonLauncherProvider_NativeSetup.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonLauncherProvider_NativeSetup.Name);
        this.radioButtonLauncherProvider_M2TWEOP.Text = GetTextInCurrentLocalization(this.Name, this.radioButtonLauncherProvider_M2TWEOP.Name);

        this.buttonCollectionManage.Text = GetTextInCurrentLocalization(this.Name, this.buttonCollectionManage.Name);
        this.buttonCollectionCreate.Text = GetTextInCurrentLocalization(this.Name, this.buttonCollectionCreate.Name);
        this.buttonMarkFavoriteMod.Text = GetTextInCurrentLocalization(this.Name, this.buttonMarkFavoriteMod.Name);

        this.buttonMusicPlay.Text = GetTextInCurrentLocalization(this.Name, this.buttonMusicPlay.Name);
        this.buttonMusicPause.Text = GetTextInCurrentLocalization(this.Name, this.buttonMusicPause.Name);
        this.buttonMusicRewind.Text = GetTextInCurrentLocalization(this.Name, this.buttonMusicRewind.Name);
    }
}
