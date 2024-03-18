// <copyright file="RedistributablePresetSelectionForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

public partial class RedistributablePresetSelectionForm : Form
{
    private readonly ModSupportPresetSettingsForm presetSettingsForm;
    private readonly int gameModId;

    public RedistributablePresetSelectionForm(ModSupportPresetSettingsForm presetSettingsForm, int gameModId)
    {
        this.InitializeComponent();
        this.presetSettingsForm = presetSettingsForm;
        this.gameModId = gameModId;
    }

    private void PresetSelectionButton_Click(object sender, EventArgs e)
    {
        if (this.presetsListBox.SelectedItem != null)
        {
            string presetPlaceholder = this.presetsListBox.SelectedItem.ToString() !;
            this.presetSettingsForm.AttachRedistributablePresetToGameModification(presetPlaceholder, this.gameModId);
        }

        this.Close();
    }

    private void PresetCancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void PresetsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.presetSelectionButton.Enabled = true;
    }
}
