// <copyright file="MainBrowserForm.GuiStyles.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;

internal partial class MainBrowserForm : IUpdatableBrowser
{
    public void UpdateGUIStyle(GuiStyle style)
    {
        ColorTheme colorTheme = BrowserKernel.UpdateCurrentColorTheme(style);

        // Set back color for main form.
        this.BackColor = colorTheme.MainFormBackColor;

        // Set back color for panels.
        this.panelCollections.BackColor = colorTheme.PanelsBackColor;
        this.panelLauncherToolkit.BackColor = colorTheme.PanelsBackColor;
        this.panelLauncherOptions.BackColor = colorTheme.PanelsBackColor;
        this.panelMediaDevice.BackColor = colorTheme.PanelsBackColor;

        // Set back color for mod UI controls.
        this.treeViewGameMods.BackColor = colorTheme.ModControlsBackColor;
        this.modMainTitleLabel.BackColor = colorTheme.ModControlsBackColor;
        this.modStatusLabel.BackColor = colorTheme.ModControlsBackColor;

        // Set back color for common UI controls.
        this.buttonLaunch.BackColor = colorTheme.CommonControlsBackColor;
        this.modQuickNavigationButton.BackColor = colorTheme.CommonControlsBackColor;
        this.buttonExplore.BackColor = colorTheme.CommonControlsBackColor;

        this.buttonMarkFavoriteMod.BackColor = colorTheme.CommonControlsBackColor;
        this.buttonCollectionCreate.BackColor = colorTheme.CommonControlsBackColor;
        this.buttonCollectionManage.BackColor = colorTheme.CommonControlsBackColor;

        // Set fore color for common UI controls.
        this.buttonLaunch.ForeColor = colorTheme.CommonControlsForeColor;
        this.modQuickNavigationButton.ForeColor = colorTheme.CommonControlsForeColor;
        this.buttonExplore.ForeColor = colorTheme.CommonControlsForeColor;

        this.buttonMarkFavoriteMod.ForeColor = colorTheme.CommonControlsForeColor;
        this.buttonCollectionCreate.ForeColor = colorTheme.CommonControlsForeColor;
        this.buttonCollectionManage.ForeColor = colorTheme.CommonControlsForeColor;

        this.groupBoxConfigProfiles.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonConfigProfile_Gaming.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonConfigProfile_Modding.ForeColor = colorTheme.CommonControlsForeColor;

        this.groupBoxConfigLaunchMode.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonLaunchWindowScreen.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonLaunchFullScreen.ForeColor = colorTheme.CommonControlsForeColor;
        this.checkBoxVideo.ForeColor = colorTheme.CommonControlsForeColor;
        this.checkBoxBorderless.ForeColor = colorTheme.CommonControlsForeColor;

        this.groupBoxConfigLogMode.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonLogOnlyError.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonLogOnlyTrace.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonLogErrorAndTrace.ForeColor = colorTheme.CommonControlsForeColor;
        this.checkBoxLogHistory.ForeColor = colorTheme.CommonControlsForeColor;

        this.groupBoxConfigCleanerMode.ForeColor = colorTheme.CommonControlsForeColor;
        this.checkBoxCleaner_MapRWM.ForeColor = colorTheme.CommonControlsForeColor;
        this.checkBoxCleaner_textBIN.ForeColor = colorTheme.CommonControlsForeColor;
        this.checkBoxCleaner_soundPacks.ForeColor = colorTheme.CommonControlsForeColor;

        this.groupBoxLauncherProviders.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonLauncherProvider_TWEMP.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonLauncherProvider_BatchScript.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonLauncherProvider_NativeSetup.ForeColor = colorTheme.CommonControlsForeColor;
        this.radioButtonLauncherProvider_M2TWEOP.ForeColor = colorTheme.CommonControlsForeColor;

        this.treeViewGameMods.ForeColor = colorTheme.CommonControlsForeColor;
        this.modMainTitleLabel.ForeColor = colorTheme.CommonControlsForeColor;
        this.modStatusLabel.ForeColor = colorTheme.CommonControlsForeColor;
    }
}
