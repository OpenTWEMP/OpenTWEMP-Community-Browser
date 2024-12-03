// <copyright file="MainAddonsSetupFrameworkForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Extension.AddonsSetupFramework.WinForms;

using System;
using System.Drawing;
using System.Windows.Forms;

public partial class MainAddonsSetupFrameworkForm : Form
{
    private const string GameCampaignByDefault = "CAMPAIGN_TYPE_0";
    private const string GameLocalizationByDefault = "LOCALIZATION_TYPE_0";

    private string currentGameCampaign;
    private string currentGameLocalization;

    public MainAddonsSetupFrameworkForm()
    {
        this.InitializeComponent();
        this.InitializeControlsByDefault();

        this.currentGameCampaign = GameCampaignByDefault;
        this.currentGameLocalization = GameLocalizationByDefault;
    }

    private void InitializeControlsByDefault()
    {
        this.gameCampaignComboBox.SelectedItem = GameCampaignByDefault;
        this.gameLocalizationComboBox.SelectedItem = GameLocalizationByDefault;

        this.gameCampaignLabel.Text = GameCampaignByDefault;
        this.gameLocalizationLabel.Text = GameLocalizationByDefault;
    }

    private void GameLaunchButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show(
            text: $"{this.gameCampaignLabel.Text}\n{this.gameLocalizationLabel.Text}",
            caption: "Launching the Game ...",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Information);
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void GameCampaignComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        this.currentGameCampaign = this.gameCampaignComboBox.SelectedItem!.ToString() !;
        this.gameCampaignLabel.Text = this.currentGameCampaign;
    }

    private void GameLocalizationComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        this.currentGameLocalization = this.gameLocalizationComboBox.SelectedItem!.ToString() !;
        this.gameLocalizationLabel.Text = this.currentGameLocalization;
    }

    private void GameCampaignComboBox_Click(object sender, EventArgs e)
    {
        this.gameCampaignComboBox.DroppedDown = true;
    }

    private void GameLocalizationComboBox_Click(object sender, EventArgs e)
    {
        this.gameLocalizationComboBox.DroppedDown = true;
    }

    private void GameCampaignLabel_Click(object sender, EventArgs e)
    {
        var form = new CampaignConfigForm(this.currentGameCampaign, this.currentGameLocalization);
        form.Show();
    }

    private void GameCampaignLabel_MouseEnter(object sender, EventArgs e)
    {
        this.gameCampaignLabel.Text = $"Click to configure the campaign:\n{this.currentGameCampaign}";
        this.gameCampaignLabel.BackColor = Color.Yellow;
    }

    private void GameCampaignLabel_MouseLeave(object sender, EventArgs e)
    {
        this.gameCampaignLabel.Text = this.currentGameCampaign;
        this.gameCampaignLabel.BackColor = Color.Honeydew;
    }
}
