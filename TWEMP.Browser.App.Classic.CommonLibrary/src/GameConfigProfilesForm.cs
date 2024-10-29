// <copyright file="GameConfigProfilesForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;

public partial class GameConfigProfilesForm : Form
{
    private readonly List<GameConfigProfile> gameConfigProfiles;

    private Dictionary<int, Guid> gameConfigProfilesDictionary;

    public GameConfigProfilesForm()
    {
        this.gameConfigProfiles = BrowserKernel.AvailableProfiles;
        this.gameConfigProfilesDictionary = CreateGameConfigProfilesDictionary(this.gameConfigProfiles.ToArray());

        this.InitializeComponent();
        this.InitializeGameConfigProfilesListBox();
    }

    private static Dictionary<int, Guid> CreateGameConfigProfilesDictionary(GameConfigProfile[] gameConfigProfiles)
    {
        Dictionary<int, Guid> gameConfigProfilesDictionary = new ();

        for (int index = 0; index < gameConfigProfiles.Length; index++)
        {
            gameConfigProfilesDictionary.Add(key: index, value: gameConfigProfiles[index].Id);
        }

        return gameConfigProfilesDictionary;
    }

    private void ConfigProfileSelectButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("ConfigProfileSelectButtonClick");
    }

    private void ConfigProfileCreateButtonClick(object sender, EventArgs e)
    {
        var gameConfigProfileCreateForm = new GameConfigProfileCreateForm();
        gameConfigProfileCreateForm.ShowDialog();
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

    private void InitializeGameConfigProfilesListBox()
    {
        this.gameConfigProfilesListBox.Items.Clear();

        foreach (GameConfigProfile gameConfigProfile in this.gameConfigProfiles)
        {
            this.gameConfigProfilesListBox.Items.Add(gameConfigProfile.Name);
        }
    }
}
