// <copyright file="GameConfigProfileCreateForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

public partial class GameConfigProfileCreateForm : Form

{

    public GameConfigProfileCreateForm()
    {
        this.InitializeComponent();
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
            var modConfigSettingsForm = new ModConfigSettingsForm();
            modConfigSettingsForm.ShowDialog();
        }
    }

    private void FormCancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
