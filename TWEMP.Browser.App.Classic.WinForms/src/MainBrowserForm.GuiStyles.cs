namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary;

internal partial class MainBrowserForm : IUpdatableBrowser
{
    public void UpdateGUIStyle(GuiStyle style)
    {
        ColorTheme colorTheme = ColorTheme.SelectColorThemeByStyle(style);

        // Set back color for main form.
        BackColor = colorTheme.MainFormBackColor;

#if DISABLE_WHEN_MIGRATION
        // Set back color for panels.
        panelCollections.BackColor = colorTheme.PanelsBackColor;
        panelLauncherToolkit.BackColor = colorTheme.PanelsBackColor;
        panelLauncherOptions.BackColor = colorTheme.PanelsBackColor;

        // Set back color for mod UI controls.
        treeViewGameMods.BackColor = colorTheme.ModControlsBackColor;
        modMainTitleLabel.BackColor = colorTheme.ModControlsBackColor;
        modStatusLabel.BackColor = colorTheme.ModControlsBackColor;

        // Set back color for common UI controls.
        buttonLaunch.BackColor = colorTheme.CommonControlsBackColor;
        modQuickNavigationButton.BackColor = colorTheme.CommonControlsBackColor;
        buttonExplore.BackColor = colorTheme.CommonControlsBackColor;

        buttonMarkFavoriteMod.BackColor = colorTheme.CommonControlsBackColor;
        buttonCollectionCreate.BackColor = colorTheme.CommonControlsBackColor;
        buttonCollectionManage.BackColor = colorTheme.CommonControlsBackColor;


        // Set fore color for common UI controls.

        buttonLaunch.ForeColor = colorTheme.CommonControlsForeColor;
        modQuickNavigationButton.ForeColor = colorTheme.CommonControlsForeColor;
        buttonExplore.ForeColor = colorTheme.CommonControlsForeColor;

        buttonMarkFavoriteMod.ForeColor = colorTheme.CommonControlsForeColor;
        buttonCollectionCreate.ForeColor = colorTheme.CommonControlsForeColor;
        buttonCollectionManage.ForeColor = colorTheme.CommonControlsForeColor;

        groupBoxConfigProfiles.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonConfigProfile_Gaming.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonConfigProfile_Modding.ForeColor = colorTheme.CommonControlsForeColor;

        groupBoxConfigLaunchMode.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonLaunchWindowScreen.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonLaunchFullScreen.ForeColor = colorTheme.CommonControlsForeColor;
        checkBoxVideo.ForeColor = colorTheme.CommonControlsForeColor;
        checkBoxBorderless.ForeColor = colorTheme.CommonControlsForeColor;

        groupBoxConfigLogMode.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonLogOnlyError.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonLogOnlyTrace.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonLogErrorAndTrace.ForeColor = colorTheme.CommonControlsForeColor;
        checkBoxLogHistory.ForeColor = colorTheme.CommonControlsForeColor;

        groupBoxConfigCleanerMode.ForeColor = colorTheme.CommonControlsForeColor;
        checkBoxCleaner_MapRWM.ForeColor = colorTheme.CommonControlsForeColor;
        checkBoxCleaner_textBIN.ForeColor = colorTheme.CommonControlsForeColor;
        checkBoxCleaner_soundPacks.ForeColor = colorTheme.CommonControlsForeColor;

        groupBoxLauncherProviders.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonLauncherProvider_TWEMP.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonLauncherProvider_BatchScript.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonLauncherProvider_NativeSetup.ForeColor = colorTheme.CommonControlsForeColor;
        radioButtonLauncherProvider_M2TWEOP.ForeColor = colorTheme.CommonControlsForeColor;

        treeViewGameMods.ForeColor = colorTheme.CommonControlsForeColor;
        modMainTitleLabel.ForeColor = colorTheme.CommonControlsForeColor;
        modStatusLabel.ForeColor = colorTheme.CommonControlsForeColor;
#endif
    }
}
