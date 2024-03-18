// <copyright file="RedistributablePresetSelectionForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

public partial class RedistributablePresetSelectionForm : Form
{
    public RedistributablePresetSelectionForm()
    {
        this.InitializeComponent();
    }

    private void PresetSelectionButton_Click(object sender, EventArgs e)
    {
        if (this.presetsListBox.SelectedItem != null)
        {
            MessageBox.Show($"{this.presetsListBox.SelectedItem}");
        }
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
