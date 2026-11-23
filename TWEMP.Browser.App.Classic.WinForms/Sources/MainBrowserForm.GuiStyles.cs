// <copyright file="MainBrowserForm.GuiStyles.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic;

using System.Drawing;
using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;

internal partial class MainBrowserForm : IUpdatableBrowser
{
    public void UpdateGUIStyle(GuiStyle style)
    {
        ColorTheme theme = BrowserKernel.UpdateCurrentColorTheme(style);

        this.SetMainBrowserFormBackColor(theme.MainFormBackColor);
        this.SetBackColorForBrowserPanels(theme.PanelsBackColor);
        this.SetBackColorForModificationControls(theme.ModControlsBackColor);
        this.SetColorsForBrowserCommonControls(theme.CommonControlsBackColor, theme.CommonControlsForeColor);
    }

    private void SetMainBrowserFormBackColor(Color color) => this.BackColor = color;

    private void SetBackColorForBrowserPanels(Color color)
    {
        this.panelCollections.BackColor = color;
        this.panelLauncherToolkit.BackColor = color;
        this.panelLauncherOptions.BackColor = color;
        this.panelMediaDevice.BackColor = color;
    }

    private void SetBackColorForModificationControls(Color color)
    {
        this.treeViewGameMods.BackColor = color;
        this.modMainTitleLabel.BackColor = color;
        this.modStatusLabel.BackColor = color;
    }

    private void SetColorsForBrowserCommonControls(Color backColor, Color foreColor)
    {
        this.SetBackColorForCommonControls(backColor);
        this.SetForeColorForCommonControls(foreColor);
    }

    private void SetBackColorForCommonControls(Color color)
    {
        this.buttonLaunch.BackColor = color;
        this.modConfigSettingsButton.BackColor = color;
        this.modConfigProfilesButton.BackColor = color;
        this.modQuickNavigationButton.BackColor = color;
        this.buttonExplore.BackColor = color;

        this.configProfileSwitchButton.BackColor = color;

        this.buttonMarkFavoriteMod.BackColor = color;
        this.buttonCollectionCreate.BackColor = color;
        this.buttonCollectionManage.BackColor = color;

        this.buttonMusicPlay.BackColor = color;
        this.buttonMusicPause.BackColor = color;
        this.buttonMusicRewind.BackColor = color;
    }

    private void SetForeColorForCommonControls(Color color)
    {
        this.buttonLaunch.ForeColor = color;
        this.modConfigSettingsButton.ForeColor = color;
        this.modConfigProfilesButton.ForeColor = color;
        this.modQuickNavigationButton.ForeColor = color;
        this.buttonExplore.ForeColor = color;

        this.buttonMarkFavoriteMod.ForeColor = color;
        this.buttonCollectionCreate.ForeColor = color;
        this.buttonCollectionManage.ForeColor = color;

        this.buttonMusicPlay.ForeColor = color;
        this.buttonMusicPause.ForeColor = color;
        this.buttonMusicRewind.ForeColor = color;

        this.groupBoxConfigProfiles.ForeColor = color;
        this.radioButtonConfigProfile_Gaming.ForeColor = color;
        this.radioButtonConfigProfile_Modding.ForeColor = color;
        this.configProfileSwitchButton.ForeColor = color;

        this.groupBoxConfigLaunchMode.ForeColor = color;
        this.radioButtonLaunchWindowScreen.ForeColor = color;
        this.radioButtonLaunchFullScreen.ForeColor = color;
        this.checkBoxVideo.ForeColor = color;
        this.checkBoxBorderless.ForeColor = color;

        this.groupBoxConfigLogMode.ForeColor = color;
        this.radioButtonLogOnlyError.ForeColor = color;
        this.radioButtonLogOnlyTrace.ForeColor = color;
        this.radioButtonLogErrorAndTrace.ForeColor = color;
        this.checkBoxLogHistory.ForeColor = color;

        this.groupBoxConfigCleanerMode.ForeColor = color;
        this.checkBoxCleaner_MapRWM.ForeColor = color;
        this.checkBoxCleaner_textBIN.ForeColor = color;
        this.checkBoxCleaner_soundPacks.ForeColor = color;

        this.groupBoxLauncherProviders.ForeColor = color;
        this.radioButtonLauncherProvider_TWEMP.ForeColor = color;
        this.radioButtonLauncherProvider_BatchScript.ForeColor = color;
        this.radioButtonLauncherProvider_NativeSetup.ForeColor = color;
        this.radioButtonLauncherProvider_M2TWEOP.ForeColor = color;

        this.treeViewGameMods.ForeColor = color;
        this.modMainTitleLabel.ForeColor = color;
        this.modStatusLabel.ForeColor = color;
    }
}
