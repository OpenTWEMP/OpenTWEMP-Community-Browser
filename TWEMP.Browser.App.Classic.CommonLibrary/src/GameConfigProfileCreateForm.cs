// <copyright file="GameConfigProfileCreateForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;

public partial class GameConfigProfileCreateForm : Form
{
    private GameEngineSupportType currentGameCfgType = GameEngineSupportType.M2TW;

    public GameConfigProfileCreateForm()
    {
        this.InitializeComponent();
    }

    private static void LoadGameConfigSettingsForm(GameEngineSupportType gameCfgType)
    {
        /* Load a specific form for a selected game config type:
        * 1) M2TW -> ModConfigSettingsForm
        * 2) RTW/TWEMP -> a placeholder form */

        switch (gameCfgType)
        {
            case GameEngineSupportType.M2TW:
                var modConfigSettingsForm = new ModConfigSettingsForm();
                modConfigSettingsForm.ShowDialog();
                break;
            case GameEngineSupportType.TWEMP:
            case GameEngineSupportType.RTW:
                MessageBox.Show(
                    text: "NON-IMPLEMENTED CFG TYPE",
                    caption: "Non-Implemented Game Configurator",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Exclamation);
                break;
            default:
                break;
        }
    }

    private void CfgNewProfileTemplateCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (this.cfgNewProfileTemplateCheckBox.Checked)
        {
            this.cfgNewProfileTemplateComboBox.Enabled = true;
        }
        else
        {
            this.cfgNewProfileTemplateComboBox.Enabled = false;
        }
    }

    private void FormOkButton_Click(object sender, EventArgs e)
    {
        if (this.cfgNewProfileTemplateCheckBox.Checked)
        {
            MessageBox.Show(
                text: "SUCCESS!",
                caption: "RESULT",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Information);

            this.Close();
        }
        else
        {
            LoadGameConfigSettingsForm(this.currentGameCfgType);
        }
    }

    private void FormCancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
