// <copyright file="GameConfigProfileCreateForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;

public partial class GameConfigProfileCreateForm : Form
{
    private readonly GameEngineSupportType currentGameCfgType;
    private readonly GameModificationInfo currentGameModificationInfo;

    private Dictionary<int, Guid> viewOfGameConfigProfiles;
    private GameConfigProfile templateGameConfigProfile;

    public GameConfigProfileCreateForm(GameModificationInfo gameModificationInfo)
    {
        this.currentGameCfgType = GameEngineSupportType.M2TW;
        this.currentGameModificationInfo = gameModificationInfo;

        this.viewOfGameConfigProfiles = new Dictionary<int, Guid>();
        this.templateGameConfigProfile = GameConfigProfile.CreateDefaultTemplate(gameModificationInfo);

        this.InitializeComponent();

        this.Text = InitializeCaptionText(gameModificationInfo);
        this.InitializeGameConfigProfileTemplatesComboBox();
    }

    public GameConfigProfileCreateForm(GameModificationInfo gameModificationInfo, GameConfigProfile gameConfigProfile)
    {
        this.currentGameCfgType = GameEngineSupportType.M2TW;
        this.currentGameModificationInfo = gameModificationInfo;

        this.viewOfGameConfigProfiles = new Dictionary<int, Guid>();
        this.templateGameConfigProfile = gameConfigProfile;

        this.InitializeComponent();

        this.Text = InitializeCaptionText(gameModificationInfo, gameConfigProfile);
        this.cfgNewProfileNameTextBox.Text = gameConfigProfile.Name;
        this.cfgNewProfileTemplateCheckBox.Visible = false;
        this.cfgNewProfileTemplateComboBox.Visible = false;
    }

    private static string InitializeCaptionText(GameModificationInfo gameModificationInfo)
    {
        return $"Create a New Configuration [{gameModificationInfo.Location}]";
    }

    private static string InitializeCaptionText(GameModificationInfo gameModificationInfo, GameConfigProfile gameConfigProfile)
    {
        return $"Update: {gameConfigProfile.Name} [{gameModificationInfo.Location}]";
    }

    private static void ShowTempPlaceholderMessageBox()
    {
        MessageBox.Show(
            text: "NON-IMPLEMENTED CFG TYPE",
            caption: "Non-Implemented Game Configurator",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Exclamation);
    }

    private static void ShowNoSelectedItemMessageBox()
    {
        MessageBox.Show(
            text: "NO SELECTED ITEM",
            caption: "Select an item and try again",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Error);
    }

    private void InitializeGameConfigProfileTemplatesComboBox()
    {
        GameConfigProfile[] gameConfigProfiles = BrowserKernel.AvailableProfiles.ToArray();
        this.viewOfGameConfigProfiles = BrowserKernel.GetConfigProfilesToDisplay(gameConfigProfiles);

        this.cfgNewProfileTemplateComboBox.Items.Clear();
        object[] gameConfigProfileItems = BrowserKernel.GetNewConfigProfileItems(this.viewOfGameConfigProfiles);
        this.cfgNewProfileTemplateComboBox.Items.AddRange(gameConfigProfileItems);
    }

    private void LoadGameConfigSettingsForm(GameEngineSupportType gameCfgType)
    {
        switch (gameCfgType)
        {
            case GameEngineSupportType.M2TW:
                this.OpenModConfigSettingsForm();
                break;
            case GameEngineSupportType.TWEMP:
            case GameEngineSupportType.RTW:
                ShowTempPlaceholderMessageBox();
                break;
            default:
                break;
        }
    }

    private void OpenModConfigSettingsForm()
    {
        ModConfigSettingsForm modConfigSettingsForm = new (this.currentGameModificationInfo, this.templateGameConfigProfile);
        modConfigSettingsForm.ShowDialog();
    }

    private void CfgNewProfileTemplateCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (this.cfgNewProfileTemplateCheckBox.Checked)
        {
            this.cfgNewProfileTemplateComboBox.Enabled = true;
        }
        else
        {
            this.cfgNewProfileTemplateComboBox.Enabled = false;
        }
    }

    private void FormOkButton_Click(object sender, EventArgs e)
    {
        if (this.cfgNewProfileTemplateCheckBox.Checked)
        {
            object? selectedItem = this.cfgNewProfileTemplateComboBox.SelectedItem;

            if (selectedItem == null)
            {
                ShowNoSelectedItemMessageBox();
                return;
            }

            int selectedItemIndex = this.cfgNewProfileTemplateComboBox.SelectedIndex;
            Guid gameConfigProfileId = this.viewOfGameConfigProfiles[selectedItemIndex];
            GameConfigProfile gameConfigProfile = BrowserKernel.SelectProfileById(gameConfigProfileId);

            this.templateGameConfigProfile = gameConfigProfile;
        }

        this.templateGameConfigProfile.Name = this.cfgNewProfileNameTextBox.Text;

        this.LoadGameConfigSettingsForm(this.currentGameCfgType);
    }

    private void FormCancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
