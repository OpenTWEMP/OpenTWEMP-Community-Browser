namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary;

internal partial class MainBrowserForm: IUpdatableBrowser, ICanChangeMyLocalization
{
    public void UpdateLocalizationForGUIControls()
    {
        this.SetupCurrentLocalizationForGUIControls();
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        FormLocaleSnapshot snapshot = Settings.CurrentLocalization.GetFormLocaleSnapshotByKey(Name);

#if DISABLE_WHEN_MIGRATION
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
#endif
    }
}
