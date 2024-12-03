// <copyright file="CampaignConfigForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Extension.AddonsSetupFramework.WinForms;

using System;
using System.Windows.Forms;

public partial class CampaignConfigForm : Form
{
    private readonly string currentGameCampaign;
    private readonly string currentGameLocalization;

    public CampaignConfigForm(string campaign, string localization)
    {
        this.InitializeComponent();

        this.currentGameCampaign = campaign;
        this.currentGameLocalization = localization;

        string campaignDescription = $"{this.currentGameCampaign} [ {this.currentGameLocalization} ]";
        this.Text = $"Campaign Configurator: {campaignDescription}";
        this.campaignDescriptionLabel.Text = campaignDescription;
    }

    private void FormApplyButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show(
            text: "Your Campaign is Ready to Game!",
            caption: "Applying Changes ...",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Asterisk);

        this.Close();
    }

    private void FormCloseButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
