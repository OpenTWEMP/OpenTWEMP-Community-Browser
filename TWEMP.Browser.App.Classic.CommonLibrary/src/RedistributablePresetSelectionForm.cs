// <copyright file="RedistributablePresetSelectionForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public partial class RedistributablePresetSelectionForm : Form
{
    private readonly ModSupportPresetSettingsForm presetSettingsForm;
    private readonly int gameModId;
    private readonly List<RedistributableModPreset> redistributableModPresets;

    public RedistributablePresetSelectionForm(ModSupportPresetSettingsForm presetSettingsForm, int gameModId)
    {
        this.InitializeComponent();

        this.presetSettingsForm = presetSettingsForm;
        this.gameModId = gameModId;

        this.redistributableModPresets = BrowserKernel.AvailableModSupportPresets;
        this.InitializeListBoxOfRedistributablePresets(this.redistributableModPresets);
    }

    private void InitializeListBoxOfRedistributablePresets(List<RedistributableModPreset> presets)
    {
        foreach (var preset in presets)
        {
            string presetItem = $"{preset.Metadata.PresetName} [{preset.Metadata.Version}]";
            this.presetsListBox.Items.Add(presetItem);
        }
    }

    private void InitializeTestPresetPlaceholders()
    {
        List<string> presets = new List<string>();

        for (int i = 0; i < 150; i++)
        {
            string preset = $"PRESET_{i}";
            presets.Add(preset);
        }

        foreach (var preset in presets)
        {
            this.presetsListBox.Items.Add(preset);
        }
    }

    private void PresetSelectionButton_Click(object sender, EventArgs e)
    {
        if (this.presetsListBox.SelectedItem != null)
        {
            int presetIndex = this.presetsListBox.SelectedIndex;
            RedistributableModPreset selectedPreset = this.redistributableModPresets.ElementAt(presetIndex);

            this.presetSettingsForm.AttachRedistributablePresetToGameModification(this.gameModId, selectedPreset);
        }

        this.Close();
    }

    private void PresetCancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void PresetsListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedIndex = this.presetsListBox.SelectedIndex;
        RedistributableModPreset selectedPreset = this.redistributableModPresets[selectedIndex];
        this.DisplayPresetInformation(selectedPreset);

        this.presetSelectionButton.Enabled = true;
    }

    private void DisplayPresetInformation(RedistributableModPreset preset)
    {
        this.modNameLabel.Text = $"Mod Name: {preset.Data.HeaderInfo.ModTitle}";
        this.modVersionLabel.Text = $"Mod Version: {preset.Data.HeaderInfo.ModVersion}";

        this.modUrl1LinkLabel.Text = $"{preset.Data.SocialMediaInfo.ModURLs["URL1"]}";
        this.modUrl2LinkLabel.Text = $"{preset.Data.SocialMediaInfo.ModURLs["URL2"]}";
        this.modUrl3LinkLabel.Text = $"{preset.Data.SocialMediaInfo.ModURLs["URL3"]}";

        this.presetGuidLabel.Text = $"Preset GUID: {preset.Metadata.Guid}";
        this.presetNameLabel.Text = $"Preset Name: {preset.Metadata.PresetName}";
        this.presetVersionLabel.Text = $"Preset Version: {preset.Metadata.Version}";
        this.presetCreatorLabel.Text = $"Preset Creator: {preset.Metadata.Creator}";
        this.packageLabel.Text = $"Package: {preset.Metadata.PackageName}";

        this.modSupportPresetTitlelabel.Text = $"{preset.Data.HeaderInfo.ModTitle} ({preset.Data.HeaderInfo.ModVersion})";
    }
}
