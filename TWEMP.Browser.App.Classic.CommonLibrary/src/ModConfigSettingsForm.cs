// <copyright file="ModConfigSettingsForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic.CommonLibrary;

public partial class ModConfigSettingsForm : Form
{
    public ModConfigSettingsForm()
    {
        InitializeComponent();
    }

    private void SaveConfigSettingsButton_Click(object sender, EventArgs e)
    {
        // Create a new game configuration state object.
        MessageBox.Show(
            text: "Your new game config is READY!",
            caption: "SUCCESS",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Information);
        this.Close();
    }

    private void ResetConfigSettingsButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("RESET CONFIG SETTINGS");
    }

    private void ExitConfigSettingsButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void ExportConfigSettingsButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("EXPORT CONFIG SETTINGS");
    }

    private void ImportConfigSettingsButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("IMPORT CONFIG SETTINGS");
    }
}
