// <copyright file="GameConfigProfileSwitchForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

public partial class GameConfigProfileSwitchForm : Form
{
    private readonly UpdatableGameModificationView currentGameModificationView;

    private readonly GameConfigProfile[] gameConfigProfiles;
    private readonly Dictionary<int, Guid> gameConfigProfilesDictionary;

    public GameConfigProfileSwitchForm(UpdatableGameModificationView gameModificationView)
    {
        this.currentGameModificationView = gameModificationView;

        this.gameConfigProfiles = BrowserKernel.GetAllConfigProfilesForSelectedGameMod(this.currentGameModificationView);
        this.gameConfigProfilesDictionary = BrowserKernel.GetConfigProfilesToDisplay(this.gameConfigProfiles);

        this.InitializeComponent();
        this.InitializeCaptionText();
        this.InitializeCurrentProfilesComboBox();
    }

    private void InitializeCaptionText()
    {
        this.Text = $"Current Game Mod: \"{this.currentGameModificationView.CurrentInfo.ShortName}\"";
    }

    private void FormCloseButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void CurrentProfileComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        this.currentProfileNameLabel.Text = this.currentProfileComboBox.SelectedItem?.ToString();
    }

    private void InitializeCurrentProfilesComboBox()
    {
        this.currentProfileComboBox.Items.Clear();

        foreach (GameConfigProfile gameConfigProfile in this.gameConfigProfiles)
        {
            this.currentProfileComboBox.Items.Add(gameConfigProfile.Name);
        }
    }
}
