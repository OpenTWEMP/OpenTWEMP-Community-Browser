﻿// <copyright file="RedistributablePresetSelectionForm.cs" company="The OpenTWEMP Project">
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

        this.InitializeTestPresetPlaceholders();

        this.presetSettingsForm = presetSettingsForm;
        this.gameModId = gameModId;
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
        object presetPlaceholder = this.presetsListBox.SelectedItem !;
        this.DisplayPresetInformation(presetPlaceholder);

        this.presetSelectionButton.Enabled = true;
    }

    private void DisplayPresetInformation(object presetPlaceholder)
    {
        this.modNameLabel.Text = $"Mod Name: {presetPlaceholder}.ModName";
        this.modVersionLabel.Text = $"Mod Version: {presetPlaceholder}.ModVersion";

        this.modUrl1LinkLabel.Text = $"{presetPlaceholder}.URL1";
        this.modUrl2LinkLabel.Text = $"{presetPlaceholder}.URL2";
        this.modUrl3LinkLabel.Text = $"{presetPlaceholder}.URL3";

        this.presetGuidLabel.Text = $"Preset GUID: {presetPlaceholder}.GUID";
        this.presetNameLabel.Text = $"Preset Name: {presetPlaceholder}.PresetName";
        this.presetVersionLabel.Text = $"Preset Version: {presetPlaceholder}.PresetVersion";
        this.presetCreatorLabel.Text = $"Preset Creator: {presetPlaceholder}.PresetCreator";
        this.packageLabel.Text = $"Package: {presetPlaceholder}.Package";

        this.modSupportPresetTitlelabel.Text = $"{presetPlaceholder}.ModName ({presetPlaceholder}.ModVersion)";
    }
}