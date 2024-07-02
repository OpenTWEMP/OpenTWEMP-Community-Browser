// <copyright file="GameConfigProfileSwitchForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

public partial class GameConfigProfileSwitchForm : Form
{
    public GameConfigProfileSwitchForm()
    {
        this.InitializeComponent();
    }

    private void FormCloseButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void CurrentProfileComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        this.currentProfileNameLabel.Text = this.currentProfileComboBox.SelectedItem?.ToString();
    }
}
