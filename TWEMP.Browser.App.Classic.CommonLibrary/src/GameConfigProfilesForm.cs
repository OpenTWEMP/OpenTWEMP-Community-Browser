// <copyright file="GameConfigProfilesForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

public partial class GameConfigProfilesForm : Form
{
    public GameConfigProfilesForm()
    {
        this.InitializeComponent();
    }

    private void ConfigProfileSelectButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("ConfigProfileSelectButtonClick");
    }

    private void ConfigProfileCreateButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("ConfigProfileCreateButtonClick");
    }

    private void ConfigProfileCopyButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("ConfigProfileCopyButtonClick");
    }

    private void ConfigProfileUpdateButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("ConfigProfileUpdateButtonClick");
    }

    private void ConfigProfileDeleteButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("ConfigProfileDeleteButtonClick");
    }

    private void ConfigProfilesDeleteAllButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("ConfigProfilesDeleteAllButtonClick");
    }

    private void ConfigProfilesExportButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("ConfigProfilesExportButtonClick");
    }

    private void ConfigProfilesImportButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("ConfigProfilesImportButtonClick");
    }

    private void FormCloseButtonClick(object sender, EventArgs e)
    {
        this.Close();
    }
}
