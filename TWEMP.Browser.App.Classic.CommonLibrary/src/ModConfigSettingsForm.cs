// <copyright file="ModConfigSettingsForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

#define TESTING_IMPORT_FEATURE
#undef TESTING_IMPORT_FEATURE

#define SKIPPED_IMPLEMENTATION
#undef SKIPPED_IMPLEMENTATION

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

public partial class ModConfigSettingsForm : Form
{
    private readonly GameModificationInfo currentGameModificationInfo;
    private readonly GameConfigProfile currentGameConfigProfile;
    private readonly GameConfigProfileCreateForm? currentCallingForm;

    private readonly M2TWGameConfigStateView gameConfigStateView;

    public ModConfigSettingsForm(GameModificationInfo gameModificationInfo)
    {
        this.currentGameModificationInfo = gameModificationInfo;
        this.currentGameConfigProfile = GameConfigProfile.CreateDefaultTemplate(this.currentGameModificationInfo);
        this.currentCallingForm = null;

        this.gameConfigStateView = M2TWGameConfigStateView.CreateByDefault(this.currentGameModificationInfo);

        InitializeComponent();
        InitializeConfigControls();
    }

    public ModConfigSettingsForm(
        GameModificationInfo gameModificationInfo,
        GameConfigProfile gameConfigProfile,
        GameConfigProfileCreateForm callingForm)
    {
        this.currentGameModificationInfo = gameModificationInfo;
        this.currentGameConfigProfile = gameConfigProfile;
        this.currentCallingForm = callingForm;

        this.gameConfigStateView = M2TWGameConfigStateView.CreateByDefault(this.currentGameModificationInfo);

        InitializeComponent();
        InitializeConfigControls();
    }

    private void SaveConfigSettingsButton_Click(object sender, EventArgs e)
    {
        M2TWGameConfigStateView gameConfigStateView = CreateGameConfigStateView();
        M2TWGameConfigurator gameConfigurator = new (this.currentGameModificationInfo, gameConfigStateView);
        BrowserKernel.CurrentConfigurator = gameConfigurator;

        GameCfgSection[] settings = gameConfigStateView.RetrieveCurrentSettings();
        this.currentGameConfigProfile.ConfigState.CurrentSettings = settings;

        MessageBox.Show(
            text: "Your new game config is READY!",
            caption: "SUCCESS",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Information);

        this.Close();

        if (this.currentCallingForm != null)
        {
            this.currentCallingForm.ReturnToConfigProfilesForm();
        }
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
        const string exportFileName = "config.json";

        M2TWGameConfigStateView gameConfigStateView = CreateGameConfigStateView();
        GameCfgSection[] cfgSettingSections = gameConfigStateView.RetrieveCurrentSettings();

        BrowserKernel.ExportConfigSettingsToFile(cfgSettingSections, exportFileName);

        MessageBox.Show(
            text: $"Config settings were exported to the file:\n{exportFileName}",
            caption: "<EXPORT CFG>",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Information);
    }

    private void ImportConfigSettingsButton_Click(object sender, EventArgs e)
    {
        OpenFileDialog importFileDialog = new ();
        importFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        DialogResult result = importFileDialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            string importFileFullName = importFileDialog.FileName;

#if TESTING_IMPORT_FEATURE
            // TODO: Fix an exception when deserialization GameCfgSection objects!
            GameCfgSection[] gameCfgSections = BrowserKernel.ImportConfigSettingsFromFile(importFileFullName);
            this.InitializeConfigControls(gameCfgSections); // TODO: Implement this method in future.
#endif

            MessageBox.Show(
                text: $"Config settings were imported from the file:\n{importFileFullName}",
                caption: "<IMPORT CFG [TESTING]>",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Information);
        }
    }

    private void InitializeItemsForComboBoxControls()
    {
        // cfgGameUnitSizeComboBox
        this.cfgGameUnitSizeComboBox.Items.Insert(index: 0, item: M2TW_Size.Small);
        this.cfgGameUnitSizeComboBox.Items.Insert(index: 1, item: M2TW_Size.Normal);
        this.cfgGameUnitSizeComboBox.Items.Insert(index: 2, item: M2TW_Size.Large);
        this.cfgGameUnitSizeComboBox.Items.Insert(index: 3, item: M2TW_Size.Huge);

        // cfgGameAiFactionsComboBox
        this.cfgGameAiFactionsComboBox.Items.Insert(index: 0, item: M2TW_Deprecated_AI_Boolean.Skip);
        this.cfgGameAiFactionsComboBox.Items.Insert(index: 1, item: M2TW_Deprecated_AI_Boolean.Follow);

        // cfgControlsDefaultInBattleComboBox
        this.cfgControlsDefaultInBattleComboBox.Items.Insert(index: 0, item: M2TW_BattleCamera.Default);
        this.cfgControlsDefaultInBattleComboBox.Items.Insert(index: 1, item: M2TW_BattleCamera.Generals);
        this.cfgControlsDefaultInBattleComboBox.Items.Insert(index: 2, item: M2TW_BattleCamera.RTS);

        // cfgVideoWaterBuffersPerNodeComboBox
        this.cfgVideoWaterBuffersPerNodeComboBox.Items.Insert(index: 0, item: 0);
        this.cfgVideoWaterBuffersPerNodeComboBox.Items.Insert(index: 1, item: 1);
        this.cfgVideoWaterBuffersPerNodeComboBox.Items.Insert(index: 2, item: 2);
        this.cfgVideoWaterBuffersPerNodeComboBox.Items.Insert(index: 3, item: 3);
        this.cfgVideoWaterBuffersPerNodeComboBox.Items.Insert(index: 4, item: 4);

        // cfgVideoUnitDetailComboBox
        this.cfgVideoUnitDetailComboBox.Items.Insert(index: 0, item: M2TW_Quality.Low);
        this.cfgVideoUnitDetailComboBox.Items.Insert(index: 1, item: M2TW_Quality.Medium);
        this.cfgVideoUnitDetailComboBox.Items.Insert(index: 2, item: M2TW_Quality.High);
        this.cfgVideoUnitDetailComboBox.Items.Insert(index: 3, item: M2TW_Quality.Highest);

        // cfgVideoTextureFilteringComboBox
        this.cfgVideoTextureFilteringComboBox.Items.Insert(index: 0, item: 0);
        this.cfgVideoTextureFilteringComboBox.Items.Insert(index: 1, item: 1);
        this.cfgVideoTextureFilteringComboBox.Items.Insert(index: 2, item: 2);

        // cfgVideoTerrainQualityComboBox
        this.cfgVideoTerrainQualityComboBox.Items.Insert(index: 0, item: M2TW_Quality.Low);
        this.cfgVideoTerrainQualityComboBox.Items.Insert(index: 1, item: M2TW_Quality.Medium);
        this.cfgVideoTerrainQualityComboBox.Items.Insert(index: 2, item: M2TW_Quality.High);
        this.cfgVideoTerrainQualityComboBox.Items.Insert(index: 3, item: M2TW_Quality.Highest);

        // cfgVideoSpriteBuffersPerNodeComboBox
        this.cfgVideoSpriteBuffersPerNodeComboBox.Items.Insert(index: 0, item: 0);
        this.cfgVideoSpriteBuffersPerNodeComboBox.Items.Insert(index: 1, item: 1);
        this.cfgVideoSpriteBuffersPerNodeComboBox.Items.Insert(index: 2, item: 2);
        this.cfgVideoSpriteBuffersPerNodeComboBox.Items.Insert(index: 3, item: 3);
        this.cfgVideoSpriteBuffersPerNodeComboBox.Items.Insert(index: 4, item: 4);

        // cfgVideoShaderComboBox
        this.cfgVideoShaderComboBox.Items.Insert(index: 0, item: M2TW_ShaderLevel.ShaderVersion_v1);
        this.cfgVideoShaderComboBox.Items.Insert(index: 1, item: M2TW_ShaderLevel.ShaderVersion_v2);

        // cfgVideoModelBuffersPerNodeComboBox
        this.cfgVideoModelBuffersPerNodeComboBox.Items.Insert(index: 0, item: 0);
        this.cfgVideoModelBuffersPerNodeComboBox.Items.Insert(index: 1, item: 1);
        this.cfgVideoModelBuffersPerNodeComboBox.Items.Insert(index: 2, item: 2);
        this.cfgVideoModelBuffersPerNodeComboBox.Items.Insert(index: 3, item: 3);
        this.cfgVideoModelBuffersPerNodeComboBox.Items.Insert(index: 4, item: 4);

        // cfgVideoGroundCoverBuffersPerNodeComboBox
        this.cfgVideoGroundCoverBuffersPerNodeComboBox.Items.Insert(index: 0, item: 0);
        this.cfgVideoGroundCoverBuffersPerNodeComboBox.Items.Insert(index: 1, item: 1);
        this.cfgVideoGroundCoverBuffersPerNodeComboBox.Items.Insert(index: 2, item: 2);
        this.cfgVideoGroundCoverBuffersPerNodeComboBox.Items.Insert(index: 3, item: 3);
        this.cfgVideoGroundCoverBuffersPerNodeComboBox.Items.Insert(index: 4, item: 4);

        // cfgVideoGroundBuffersPerNodeComboBox
        this.cfgVideoGroundBuffersPerNodeComboBox.Items.Insert(index: 0, item: 0);
        this.cfgVideoGroundBuffersPerNodeComboBox.Items.Insert(index: 1, item: 1);
        this.cfgVideoGroundBuffersPerNodeComboBox.Items.Insert(index: 2, item: 2);
        this.cfgVideoGroundBuffersPerNodeComboBox.Items.Insert(index: 3, item: 3);
        this.cfgVideoGroundBuffersPerNodeComboBox.Items.Insert(index: 4, item: 4);

        // cfgVideoGrassDistanceComboBox
        this.cfgVideoGrassDistanceComboBox.Items.Insert(index: 0, item: M2TW_GrassDistance.Level_0);
        this.cfgVideoGrassDistanceComboBox.Items.Insert(index: 1, item: M2TW_GrassDistance.Level_1);
        this.cfgVideoGrassDistanceComboBox.Items.Insert(index: 2, item: M2TW_GrassDistance.Level_2);
        this.cfgVideoGrassDistanceComboBox.Items.Insert(index: 3, item: M2TW_GrassDistance.Level_3);

        // cfgVideoEffectQualityComboBox
        this.cfgVideoEffectQualityComboBox.Items.Insert(index: 0, item: M2TW_Quality.Low);
        this.cfgVideoEffectQualityComboBox.Items.Insert(index: 1, item: M2TW_Quality.Medium);
        this.cfgVideoEffectQualityComboBox.Items.Insert(index: 2, item: M2TW_Quality.High);
        this.cfgVideoEffectQualityComboBox.Items.Insert(index: 3, item: M2TW_Quality.Highest);

        // cfgVideoDepthShadowsResolutionComboBox
        this.cfgVideoDepthShadowsResolutionComboBox.Items.Insert(index: 0, item: 0);
        this.cfgVideoDepthShadowsResolutionComboBox.Items.Insert(index: 1, item: 1);
        this.cfgVideoDepthShadowsResolutionComboBox.Items.Insert(index: 2, item: 2);
        this.cfgVideoDepthShadowsResolutionComboBox.Items.Insert(index: 3, item: 3);
        this.cfgVideoDepthShadowsResolutionComboBox.Items.Insert(index: 4, item: 4);

        // cfgVideoDepthShadowsComboBox
        this.cfgVideoDepthShadowsComboBox.Items.Insert(index: 0, item: 0);
        this.cfgVideoDepthShadowsComboBox.Items.Insert(index: 1, item: 1);
        this.cfgVideoDepthShadowsComboBox.Items.Insert(index: 2, item: 2);
        this.cfgVideoDepthShadowsComboBox.Items.Insert(index: 3, item: 3);
        this.cfgVideoDepthShadowsComboBox.Items.Insert(index: 4, item: 4);

        // cfgVideoBattleResolutionComboBox
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 0, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_640x480).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 1, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_800x600).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 2, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1024x768).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 3, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1280x720).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 4, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1280x1024).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 5, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1366x768).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 6, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1600x900).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 7, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1600x1200).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 8, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1920x1080).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 9, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_2048x1536).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 10, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_2560x1440).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 11, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_3072x1728).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 12, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_3200x1800).Value);
        this.cfgVideoBattleResolutionComboBox.Items.Insert(index: 13, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_3840x2160).Value);

        // cfgVideoCampaignResolutionComboBox
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 0, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_640x480).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 1, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_800x600).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 2, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1024x768).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 3, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1280x720).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 4, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1280x1024).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 5, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1366x768).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 6, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1600x900).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 7, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1600x1200).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 8, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1920x1080).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 9, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_2048x1536).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 10, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_2560x1440).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 11, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_3072x1728).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 12, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_3200x1800).Value);
        this.cfgVideoCampaignResolutionComboBox.Items.Insert(index: 13, item: new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_3840x2160).Value);

        // cfgVideoBuildingDetailComboBox
        this.cfgVideoBuildingDetailComboBox.Items.Insert(index: 0, item: M2TW_Quality.Low);
        this.cfgVideoBuildingDetailComboBox.Items.Insert(index: 1, item: M2TW_Quality.Medium);
        this.cfgVideoBuildingDetailComboBox.Items.Insert(index: 2, item: M2TW_Quality.High);
        this.cfgVideoBuildingDetailComboBox.Items.Insert(index: 3, item: M2TW_Quality.Highest);

        // cfgVideoAntialiasingComboBox
        this.cfgVideoAntialiasingComboBox.Items.Insert(index: 0, item: M2TW_AntiAliasing.AntiAliasMode_None);
        this.cfgVideoAntialiasingComboBox.Items.Insert(index: 1, item: M2TW_AntiAliasing.AntiAliasMode_x2);
        this.cfgVideoAntialiasingComboBox.Items.Insert(index: 2, item: M2TW_AntiAliasing.AntiAliasMode_x4);

        // cfgVideoAntiAliasModeComboBox
        this.cfgVideoAntiAliasModeComboBox.Items.Insert(index: 0, item: M2TW_AntiAliasMode.AntiAliasMode_Off);
        this.cfgVideoAntiAliasModeComboBox.Items.Insert(index: 1, item: M2TW_AntiAliasMode.AntiAliasMode_x2);
        this.cfgVideoAntiAliasModeComboBox.Items.Insert(index: 2, item: M2TW_AntiAliasMode.AntiAliasMode_x4);

        // cfgVideoAnisotropicLevelComboBox
        this.cfgVideoAnisotropicLevelComboBox.Items.Insert(index: 0, item: M2TW_AnisotropicFilteringLevel.Bilinear);
        this.cfgVideoAnisotropicLevelComboBox.Items.Insert(index: 1, item: M2TW_AnisotropicFilteringLevel.Trilinear);
        this.cfgVideoAnisotropicLevelComboBox.Items.Insert(index: 2, item: M2TW_AnisotropicFilteringLevel.AF_x2);
        this.cfgVideoAnisotropicLevelComboBox.Items.Insert(index: 3, item: M2TW_AnisotropicFilteringLevel.AF_x4);
        this.cfgVideoAnisotropicLevelComboBox.Items.Insert(index: 4, item: M2TW_AnisotropicFilteringLevel.AF_x8);
        this.cfgVideoAnisotropicLevelComboBox.Items.Insert(index: 5, item: M2TW_AnisotropicFilteringLevel.AF_x16);
    }

    private void InitializeBoundValuesForNumericUpDownControls()
    {
        this.cfgGameChatMsgDurationNumericUpDown.Maximum = M2TW_Integer.ExtendedMaxValue;
        this.cfgGameChatMsgDurationNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgGameCampaignMapSpeedUpNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgGameCampaignMapSpeedUpNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgGameCampaignMapGameSpeedNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgGameCampaignMapGameSpeedNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgAudioSpeechNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgAudioSpeechNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgAudioSfxNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgAudioSfxNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgAudioSoundCardProviderNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgAudioSoundCardProviderNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgAudioMusicVolumeNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgAudioMusicVolumeNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgAudioMasterVolumeNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgAudioMasterVolumeNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgCameraRotateNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgCameraRotateNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgCameraMoveNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgCameraMoveNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgControlsKeysetNumericUpDown.Maximum = (decimal)M2TW_KeySet.KeySet_0;
        this.cfgControlsKeysetNumericUpDown.Minimum = (decimal)M2TW_KeySet.KeySet_3;

        this.cfgControlsScrollMinZoomNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgControlsScrollMinZoomNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgControlsScrollMaxZoomNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgControlsScrollMaxZoomNumericUpDown.Minimum = M2TW_Integer.MinValue;

        this.cfgVideoGammaNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgVideoGammaNumericUpDown.Minimum = M2TW_Integer.MinValue;
    }

    private M2TWGameConfigStateView CreateGameConfigStateView()
    {
        M2TWGameConfigStateView gameConfigStateView = new (this.gameConfigStateView);

        // [GAME] ModGameplaySection
        gameConfigStateView.ModGameplaySection!.GameUseQuickchat = new M2TW_Boolean(this.cfgGameUseQuickchatCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameUnlimitedMenOnBattlefield = new M2TW_Boolean(this.cfgGameUnlimitedMenOnBattlefieldCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameNoCampaignBattleTimeLimit = new M2TW_Boolean(this.cfgGameNoCampaignBattleTimeLimitCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameMuteAdvisor = new M2TW_Boolean(this.cfgGameMuteAdvisorCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameMorale = new M2TW_Boolean(this.cfgGameMoraleCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameMicromanageAllSettlements = new M2TW_Boolean(this.cfgGameMicromanageAllSettlementsCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameLabelSettlements = new M2TW_Boolean(this.cfgGameLabelSettlementsCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameLabelCharacters = new M2TW_Boolean(this.cfgGameLabelCharactersCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameGamespySavePasswrd = new M2TW_Boolean(this.cfgGameGamespySavePasswrdCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameFirstTimePlay = new M2TW_Boolean(this.cfgGameFirstTimePlayCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameFatigue = new M2TW_Boolean(this.cfgGameFatigueCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameEventCutscenes = new M2TW_Boolean(this.cfgGameEventCutscenesCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameEnglish = new M2TW_Boolean(this.cfgGameEnglishCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameDisableEvents = new M2TW_Boolean(this.cfgGameDisableEventsCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameDisableArrowMarkers = new M2TW_Boolean(this.cfgGameDisableArrowMarkersCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameBlindAdvisor = new M2TW_Boolean(this.cfgGameBlindAdvisorCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameAutoSave = new M2TW_Boolean(this.cfgGameAutoSaveCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameAllUsers = new M2TW_Boolean(this.cfgGameAllUsersCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameAdvisorVerbosity = new M2TW_Boolean(this.cfgGameAdvisorVerbosityCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameAdvancedStatsAlways = new M2TW_Boolean(this.cfgGameAdvancedStatsAlwaysCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameUnitSize = new M2TW_UnitSize(M2TW_Size.Huge); // REPLACE: this.cfgGameUnitSizeComboBox.Text;
        gameConfigStateView.ModGameplaySection.GameChatMsgDuration = new M2TW_Integer(M2TW_Integer.ExtendedMaxValue); // REPLACE: this.cfgGameChatMsgDurationNumericUpDown.Text;
        gameConfigStateView.ModGameplaySection.GameCampaignMapSpeedUp = new M2TW_Integer(Convert.ToByte(this.cfgGameCampaignMapSpeedUpNumericUpDown.Text));
        gameConfigStateView.ModGameplaySection.GameCampaignMapGameSpeed = new M2TW_Integer(Convert.ToByte(this.cfgGameCampaignMapGameSpeedNumericUpDown.Text));
        gameConfigStateView.ModGameplaySection.GamePrefFactionsPlayed = Convert.ToInt32(this.cfgGamePrefFactionsPlayedTextBox.Text);
        gameConfigStateView.ModGameplaySection.GameTutorialPath = this.cfgGameTutorialPathTextBox.Text; // "norman_prologue/battle_of_hastings",
        gameConfigStateView.ModGameplaySection.GameAiFactions = new M2TW_Boolean(M2TW_Deprecated_AI_Boolean.Follow); // REPLACE: this.cfgGameAiFactionsComboBox.Text;
        gameConfigStateView.ModGameplaySection.GameCampaignNumTimePlay = new M2TW_Integer(Convert.ToByte(this.cfgGameCampaignNumTimePlayTextBox.Text));

        // [AUDIO] GameAudioCfgSectionStateView
        gameConfigStateView.GameAudioCfgSection!.SpeechVolume = new M2TW_Integer(Convert.ToByte(this.cfgAudioSpeechNumericUpDown.Text));
        gameConfigStateView.GameAudioCfgSection.SoundEffectsVolume = new M2TW_Integer(Convert.ToByte(this.cfgAudioSfxNumericUpDown.Text));
        gameConfigStateView.GameAudioCfgSection.SpeechVolume = new M2TW_Integer(Convert.ToByte(this.cfgAudioSoundCardProviderNumericUpDown.Text));
        gameConfigStateView.GameAudioCfgSection.AudioMusicVolume = new M2TW_Integer(Convert.ToByte(this.cfgAudioMusicVolumeNumericUpDown.Text));
        gameConfigStateView.GameAudioCfgSection.AudioMasterVolume = new M2TW_Integer(Convert.ToByte(this.cfgAudioMasterVolumeNumericUpDown.Text));
        gameConfigStateView.GameAudioCfgSection.SpeechEnable = new M2TW_Boolean(this.cfgAudioSpeechEnableCheckBox.Checked);
        gameConfigStateView.GameAudioCfgSection.AudioEnable = new M2TW_Boolean(this.cfgAudioEnableCheckBox.Checked);
        gameConfigStateView.GameAudioCfgSection.SubFactionAccents = new M2TW_Boolean(this.cfgAudioSubFactionAccentsEnableCheckBox.Checked);

        // [CAMERA] GameCameraCfgSectionStateView
        gameConfigStateView.GameCameraCfgSection!.CameraDefaultInBattle = new M2TW_BattleCameraStyle(M2TW_BattleCamera.RTS); // REPLACE: this.cfgControlsDefaultInBattleComboBox.Text;
        gameConfigStateView.GameCameraCfgSection.CameraRotate = new M2TW_Integer(Convert.ToByte(this.cfgCameraRotateNumericUpDown.Text));
        gameConfigStateView.GameCameraCfgSection.CameraMove = new M2TW_Integer(Convert.ToByte(this.cfgCameraMoveNumericUpDown.Text));
        gameConfigStateView.GameCameraCfgSection.CameraRestrict = new M2TW_Boolean(this.cfgCameraRestrictCheckBox.Checked);

        // [CONTROLS] GameControlsCfgSectionStateView
        gameConfigStateView.GameControlsCfgSection!.KeySet = new M2TW_QualityLevel(M2TW_KeySet.KeySet_0); // REPLACE: this.cfgControlsKeysetNumericUpDown.Text;
        gameConfigStateView.GameControlsCfgSection.CampaignScrollMinZoom = Convert.ToByte(this.cfgControlsScrollMinZoomNumericUpDown.Text);
        gameConfigStateView.GameControlsCfgSection.CampaignScrollMaxZoom = Convert.ToByte(this.cfgControlsScrollMaxZoomNumericUpDown.Text);

        // [HOTSEAT] ModHotseatSectionStateView
        gameConfigStateView.HotseatSection!.HotseatGameName = this.cfgHotseatGameNameTextBox.Text;
        gameConfigStateView.HotseatSection.HotseatAdminPassword = new M2TW_Boolean(this.cfgHotseatAdminPasswordCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatPasswords = new M2TW_Boolean(this.cfgHotseatPasswordsCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatValidateDiplomacy = new M2TW_Boolean(this.cfgHotseatValidateDiplomacyCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatAllowValidationFailures = new M2TW_Boolean(this.cfgHotseatAllowValidationFailuresCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatValidateData = new M2TW_Boolean(this.cfgHotseatValidateDataCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatCloseAfterSave = new M2TW_Boolean(this.cfgHotseatCloseAfterSaveCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatSaveConfig = new M2TW_Boolean(this.cfgHotseatSaveConfigCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatAutoSave = new M2TW_Boolean(this.cfgHotseatAutosaveCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatUpdateAiCamera = new M2TW_Boolean(this.cfgHotseatUpdateAiCameraCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatSavePrefs = new M2TW_Boolean(this.cfgHotseatSavePrefsCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatDisablePapalElections = new M2TW_Boolean(this.cfgHotseatDisablePapalElectionsCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatDisableConsole = new M2TW_Boolean(this.cfgHotseatDisableConsoleCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatTurns = new M2TW_Boolean(this.cfgHotseatTurnsCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatScroll = new M2TW_Boolean(this.cfgHotseatScrollCheckBox.Checked);
        gameConfigStateView.HotseatSection.HotseatAutoresolveBattles = new M2TW_Boolean(this.cfgHotseatAutoresolveBattlesCheckBox.Checked);

        // [NETWORK]
        gameConfigStateView.HotseatSection.NetworkUsePort = Convert.ToUInt16(this.cfgNetworkUsePortTextBox.Text);
        gameConfigStateView.HotseatSection.NetworkUseIp = new M2TW_IpAddress(127, 0, 0, 1); // REPLACE: this.cfgNetworkUseIpTextBox.Text;

        // [MISC]
        gameConfigStateView.HotseatSection.BypassToStrategySave = this.cfgMiscBypassToStrategySaveTextBox.Text; // "game_name.sav",
        gameConfigStateView.ModGameplaySection.UnlockCampaign = new M2TW_Boolean(this.cfgMiscUnlockCampaignCheckBox.Checked);

        // [IO] ModSettingsSectionStateView
        gameConfigStateView.ModCoreSettingsSection!.FileFirst = new M2TW_Boolean(this.cfgIOFileFirstCheckBox.Checked);
        gameConfigStateView.ModCoreSettingsSection.Editor = new M2TW_Boolean(this.cfgFeaturesEditorCheckBox.Checked);

        // [LOG]
        gameConfigStateView.ModDiagnosticSection!.LogTo = this.cfgLogLocationTextBox.Text; // mod.LogFileRelativePath,

        // [UI] GameUICfgSectionStateView
        gameConfigStateView.GameUICfgSection!.UiUnitCards = new M2TW_Boolean(this.cfgUiUnitCardsCheckBox.Checked);
        gameConfigStateView.GameUICfgSection.UiShowTooltips = new M2TW_Boolean(this.cfgUiShowTooltipsCheckBox.Checked);
        gameConfigStateView.GameUICfgSection.UiRadar = new M2TW_Boolean(this.cfgUiRadarCheckBox.Checked);
        gameConfigStateView.GameUICfgSection.UiFullBattleHud = new M2TW_Boolean(this.cfgUiFullBattleHudCheckBox.Checked);
        gameConfigStateView.GameUICfgSection.UiButtons = new M2TW_Boolean(this.cfgUiButtonsCheckBox.Checked);
        gameConfigStateView.GameUICfgSection.UiSaCards = new M2TW_Boolean(this.cfgUiSaCardsCheckBox.Checked);

        // [VIDEO] GameVideoCfgSectionStateView
        gameConfigStateView.GameVideoCfgSection!.VideoGamma = new M2TW_Integer(Convert.ToByte(this.cfgVideoGammaNumericUpDown.Text));
        gameConfigStateView.GameVideoCfgSection.VideoWaterBuffersPerNode = new M2TW_Integer(Convert.ToByte(this.cfgVideoWaterBuffersPerNodeComboBox.Text));
        gameConfigStateView.GameVideoCfgSection.VideoUnitDetail = new M2TW_QualityLevel(M2TW_Quality.Highest); // REPLACE: this.cfgVideoUnitDetailComboBox.Text
        gameConfigStateView.GameVideoCfgSection.VideoTextureFiltering = new M2TW_Integer(Convert.ToByte(this.cfgVideoTextureFilteringComboBox.Text));
        gameConfigStateView.GameVideoCfgSection.VideoTerrainQuality = new M2TW_QualityLevel(M2TW_Quality.High); // REPLACE: this.cfgVideoTerrainQualityComboBox.Text;
        gameConfigStateView.GameVideoCfgSection.VideoSpriteBuffersPerNode = new M2TW_Integer(Convert.ToByte(this.cfgVideoSpriteBuffersPerNodeComboBox.Text));
        gameConfigStateView.GameVideoCfgSection.VideoShader = new M2TW_QualityLevel(M2TW_ShaderLevel.ShaderVersion_v2); // REPLACE: this.cfgVideoShaderComboBox.Text;
        gameConfigStateView.GameVideoCfgSection.VideoModelBuffersPerNode = new M2TW_Integer(Convert.ToByte(this.cfgVideoModelBuffersPerNodeComboBox.Text));
        gameConfigStateView.GameVideoCfgSection.VideoGroundCoverBuffersPerNode = new M2TW_Integer(Convert.ToByte(this.cfgVideoGroundCoverBuffersPerNodeComboBox.Text));
        gameConfigStateView.GameVideoCfgSection.VideoGroundBuffersPerNode = new M2TW_Integer(Convert.ToByte(this.cfgVideoGroundBuffersPerNodeComboBox.Text));
        gameConfigStateView.GameVideoCfgSection.VideoGrassDistance = new M2TW_QualityLevel(M2TW_GrassDistance.Level_1); // REPLACE: this.cfgVideoGrassDistanceComboBox.Text;
        gameConfigStateView.GameVideoCfgSection.VideoEffectQuality = new M2TW_QualityLevel(M2TW_Quality.Highest); // REPLACE: this.cfgVideoEffectQualityComboBox.Text;
        gameConfigStateView.GameVideoCfgSection.VideoDepthShadowsResolution = new M2TW_Integer(Convert.ToByte(this.cfgVideoDepthShadowsResolutionComboBox.Text));
        gameConfigStateView.GameVideoCfgSection.VideoDepthShadows = new M2TW_Integer(Convert.ToByte(this.cfgVideoDepthShadowsComboBox.Text));
        gameConfigStateView.GameVideoCfgSection.VideoCampaignResolution = new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1024x768); // REPLACE: this.cfgVideoCampaignResolutionComboBox.Text
        gameConfigStateView.GameVideoCfgSection.VideoBuildingDetail = new M2TW_QualityLevel(M2TW_Quality.High); // REPLACE: this.cfgVideoBuildingDetailComboBox.Text;
        gameConfigStateView.GameVideoCfgSection.VideoBattleResolution = new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1024x768); // REPLACE: this.cfgVideoBattleResolutionComboBox.Text;
        gameConfigStateView.GameVideoCfgSection.VideoAntialiasing = new M2TW_QualityLevel(M2TW_AntiAliasing.AntiAliasMode_x4); // REPLACE: this.cfgVideoAntialiasingComboBox.Text;
        gameConfigStateView.GameVideoCfgSection.VideoAntiAliasMode = new M2TW_QualityLevel(M2TW_AntiAliasMode.AntiAliasMode_x4); // REPLACE: this.cfgVideoAntiAliasModeComboBox.Text;
        gameConfigStateView.GameVideoCfgSection.VideoAnisotropicLevel = new M2TW_QualityLevel(M2TW_AnisotropicFilteringLevel.AF_x16); // REPLACE: this.cfgVideoAnisotropicLevelComboBox.Text;
        gameConfigStateView.GameVideoCfgSection.VideoWindowedMode = new M2TW_Boolean(this.cfgVideoWindowedCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoWidescreenMode = new M2TW_Boolean(this.cfgVideoWidescreenCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoVsync = new M2TW_Boolean(this.cfgVideoVsyncCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoVegetation = new M2TW_Boolean(this.cfgVideoVegetationCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoSubtitles = new M2TW_Boolean(this.cfgVideoSubtitlesCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoStencilShadows = new M2TW_Boolean(this.cfgVideoStencilShadowsCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoSplashes = new M2TW_Boolean(this.cfgVideoSplashesCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoSkipMipLevels = new M2TW_Boolean(this.cfgVideoSkipMipLevelsChecBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoShowPackageLitter = new M2TW_Boolean(this.cfgVideoShowPackageLitterCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoShowBanners = new M2TW_Boolean(this.cfgVideoShowBannersCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoSabotageMovies = new M2TW_Boolean(this.cfgVideoSabotageMoviesCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoReflection = new M2TW_Boolean(this.cfgVideoReflectionCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoNoBackgroundFmv = new M2TW_Boolean(this.cfgVideoNoBackgroundFmvCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoMovies = new M2TW_Boolean(this.cfgVideoMoviesCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoInfiltrationMovies = new M2TW_Boolean(this.cfgVideoInfiltrationMoviesCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoEventMovies = new M2TW_Boolean(this.cfgVideoEventMoviesCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoBloom = new M2TW_Boolean(this.cfgVideoBloomCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoAutodetect = new M2TW_Boolean(this.cfgVideoAutodetectCheckBox.Checked);
        gameConfigStateView.GameVideoCfgSection.VideoAssassinationMovies = new M2TW_Boolean(this.cfgVideoAssassinationMoviesCheckBox.Checked);

        return gameConfigStateView;
    }

#if TESTING_IMPORT_FEATURE
    private void InitializeConfigControls(GameCfgSection[] gameCfgSections)
    {
        // TODO: Implement initialization of UI controls via the 'gameCfgSections' array.
    }
#endif

    private void InitializeConfigControls()
    {
        this.InitializeItemsForComboBoxControls();
        this.InitializeBoundValuesForNumericUpDownControls();

        this.Text = $"M2TW Config Settings: \"{this.currentGameConfigProfile.Name}\" [ {this.currentGameModificationInfo.Location} ]";

        // [GAME] ModGameplaySection
        this.cfgGameUseQuickchatCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameUseQuickchat!.GetValue();
        this.cfgGameUnlimitedMenOnBattlefieldCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameUnlimitedMenOnBattlefield!.GetValue();
        this.cfgGameNoCampaignBattleTimeLimitCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameNoCampaignBattleTimeLimit!.GetValue();
        this.cfgGameMuteAdvisorCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameMuteAdvisor!.GetValue();
        this.cfgGameMoraleCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameMorale!.GetValue();
        this.cfgGameMicromanageAllSettlementsCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameMicromanageAllSettlements!.GetValue();
        this.cfgGameLabelSettlementsCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameLabelSettlements!.GetValue();
        this.cfgGameLabelCharactersCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameLabelCharacters!.GetValue();
        this.cfgGameGamespySavePasswrdCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameGamespySavePasswrd!.GetValue();
        this.cfgGameFirstTimePlayCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameFirstTimePlay!.GetValue();
        this.cfgGameFatigueCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameFatigue!.GetValue();
        this.cfgGameEventCutscenesCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameEventCutscenes!.GetValue();
        this.cfgGameEnglishCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameEnglish!.GetValue();
        this.cfgGameDisableEventsCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameDisableEvents!.GetValue();
        this.cfgGameDisableArrowMarkersCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameDisableArrowMarkers!.GetValue();
        this.cfgGameBlindAdvisorCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameBlindAdvisor!.GetValue();
        this.cfgGameAutoSaveCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameAutoSave!.GetValue();
        this.cfgGameAllUsersCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameAllUsers!.GetValue();
        this.cfgGameAdvisorVerbosityCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameAdvisorVerbosity!.GetValue();
        this.cfgGameAdvancedStatsAlwaysCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.GameAdvancedStatsAlways!.GetValue();
        this.cfgGameUnitSizeComboBox.Text = this.gameConfigStateView.ModGameplaySection.GameUnitSize!.Value;
        this.cfgGameChatMsgDurationNumericUpDown.Text = this.gameConfigStateView.ModGameplaySection.GameChatMsgDuration!.Value;
        this.cfgGameCampaignMapSpeedUpNumericUpDown.Text = this.gameConfigStateView.ModGameplaySection.GameCampaignMapSpeedUp!.Value;
        this.cfgGameCampaignMapGameSpeedNumericUpDown.Text = this.gameConfigStateView.ModGameplaySection.GameCampaignMapGameSpeed!.Value;
        this.cfgGamePrefFactionsPlayedTextBox.Text = this.gameConfigStateView.ModGameplaySection.GamePrefFactionsPlayed.ToString();
        this.cfgGameTutorialPathTextBox.Text = this.gameConfigStateView.ModGameplaySection.GameTutorialPath;
        this.cfgGameAiFactionsComboBox.Text = this.gameConfigStateView.ModGameplaySection.GameAiFactions!.BooleanValue;
        this.cfgGameCampaignNumTimePlayTextBox.Text = this.gameConfigStateView.ModGameplaySection.GameCampaignNumTimePlay!.Value;

        // [AUDIO] GameAudioCfgSectionStateView
        this.cfgAudioSpeechNumericUpDown.Text = this.gameConfigStateView.GameAudioCfgSection!.SpeechVolume!.Value;
        this.cfgAudioSfxNumericUpDown.Text = this.gameConfigStateView.GameAudioCfgSection.SoundEffectsVolume!.Value;
        this.cfgAudioSoundCardProviderNumericUpDown.Text = this.gameConfigStateView.GameAudioCfgSection.SpeechVolume.Value;
        this.cfgAudioMusicVolumeNumericUpDown.Text = this.gameConfigStateView.GameAudioCfgSection.AudioMusicVolume!.Value;
        this.cfgAudioMasterVolumeNumericUpDown.Text = this.gameConfigStateView.GameAudioCfgSection.AudioMasterVolume!.Value;
        this.cfgAudioSpeechEnableCheckBox.Checked = this.gameConfigStateView.GameAudioCfgSection.SpeechEnable!.GetValue();
        this.cfgAudioEnableCheckBox.Checked = this.gameConfigStateView.GameAudioCfgSection.AudioEnable!.GetValue();
        this.cfgAudioSubFactionAccentsEnableCheckBox.Checked = this.gameConfigStateView.GameAudioCfgSection.SubFactionAccents!.GetValue();

        // [CAMERA] GameCameraCfgSectionStateView
        this.cfgControlsDefaultInBattleComboBox.Text = this.gameConfigStateView.GameCameraCfgSection!.CameraDefaultInBattle!.Value;
        this.cfgCameraRotateNumericUpDown.Text = this.gameConfigStateView.GameCameraCfgSection.CameraRotate!.Value;
        this.cfgCameraMoveNumericUpDown.Text = this.gameConfigStateView.GameCameraCfgSection.CameraMove!.Value;
        this.cfgCameraRestrictCheckBox.Checked = this.gameConfigStateView.GameCameraCfgSection.CameraRestrict!.GetValue();

        // [CONTROLS] GameControlsCfgSectionStateView
        this.cfgControlsKeysetNumericUpDown.Text = this.gameConfigStateView.GameControlsCfgSection!.KeySet!.Value;
        this.cfgControlsScrollMinZoomNumericUpDown.Text = this.gameConfigStateView.GameControlsCfgSection.CampaignScrollMinZoom.ToString();
        this.cfgControlsScrollMaxZoomNumericUpDown.Text = this.gameConfigStateView.GameControlsCfgSection.CampaignScrollMaxZoom.ToString();

        // [HOTSEAT] ModHotseatSectionStateView
        this.cfgHotseatGameNameTextBox.Text = this.gameConfigStateView.HotseatSection!.HotseatGameName;
        this.cfgHotseatAdminPasswordCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatAdminPassword!.GetValue();
        this.cfgHotseatPasswordsCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatPasswords!.GetValue();
        this.cfgHotseatValidateDiplomacyCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatValidateDiplomacy!.GetValue();
        this.cfgHotseatAllowValidationFailuresCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatAllowValidationFailures!.GetValue();
        this.cfgHotseatValidateDataCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatValidateData!.GetValue();
        this.cfgHotseatCloseAfterSaveCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatCloseAfterSave!.GetValue();
        this.cfgHotseatSaveConfigCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatSaveConfig!.GetValue();
        this.cfgHotseatAutosaveCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatAutoSave!.GetValue();
        this.cfgHotseatUpdateAiCameraCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatUpdateAiCamera!.GetValue();
        this.cfgHotseatSavePrefsCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatSavePrefs!.GetValue();
        this.cfgHotseatDisablePapalElectionsCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatDisablePapalElections!.GetValue();
        this.cfgHotseatDisableConsoleCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatDisableConsole!.GetValue();
        this.cfgHotseatTurnsCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatTurns!.GetValue();
        this.cfgHotseatScrollCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatScroll!.GetValue();
        this.cfgHotseatAutoresolveBattlesCheckBox.Checked = this.gameConfigStateView.HotseatSection.HotseatAutoresolveBattles!.GetValue();

        // [NETWORK]
        this.cfgNetworkUsePortTextBox.Text = this.gameConfigStateView.HotseatSection.NetworkUsePort.ToString();
        this.cfgNetworkUseIpTextBox.Text = this.gameConfigStateView.HotseatSection.NetworkUseIp!.Value;

        // [MISC]
        this.cfgMiscBypassToStrategySaveTextBox.Text = this.gameConfigStateView.HotseatSection.BypassToStrategySave;
        this.cfgMiscUnlockCampaignCheckBox.Checked = this.gameConfigStateView.ModGameplaySection.UnlockCampaign!.GetValue();

        // [IO] ModSettingsSectionStateView
        this.cfgIOFileFirstCheckBox.Checked = this.gameConfigStateView.ModCoreSettingsSection!.FileFirst!.GetValue();
        this.cfgFeaturesEditorCheckBox.Checked = this.gameConfigStateView.ModCoreSettingsSection.Editor!.GetValue();

        // [LOG]
        this.cfgLogLocationTextBox.Text = this.gameConfigStateView.ModDiagnosticSection!.LogTo;

        // [UI] GameUICfgSectionStateView
        this.cfgUiUnitCardsCheckBox.Checked = this.gameConfigStateView.GameUICfgSection!.UiUnitCards!.GetValue();
        this.cfgUiShowTooltipsCheckBox.Checked = this.gameConfigStateView.GameUICfgSection.UiShowTooltips!.GetValue();
        this.cfgUiRadarCheckBox.Checked = this.gameConfigStateView.GameUICfgSection.UiRadar!.GetValue();
        this.cfgUiFullBattleHudCheckBox.Checked = this.gameConfigStateView.GameUICfgSection.UiFullBattleHud!.GetValue();
        this.cfgUiButtonsCheckBox.Checked = this.gameConfigStateView.GameUICfgSection.UiButtons!.GetValue();
        this.cfgUiSaCardsCheckBox.Checked = this.gameConfigStateView.GameUICfgSection.UiSaCards!.GetValue();

        // [VIDEO] GameVideoCfgSectionStateView
        this.cfgVideoGammaNumericUpDown.Text = this.gameConfigStateView.GameVideoCfgSection!.VideoGamma!.Value;
        this.cfgVideoWaterBuffersPerNodeComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoWaterBuffersPerNode!.Value;
        this.cfgVideoUnitDetailComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoUnitDetail!.Value;
        this.cfgVideoTextureFilteringComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoTextureFiltering!.Value;
        this.cfgVideoTerrainQualityComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoTerrainQuality!.Value;
        this.cfgVideoSpriteBuffersPerNodeComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoSpriteBuffersPerNode!.Value;
        this.cfgVideoShaderComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoShader!.Value;
        this.cfgVideoModelBuffersPerNodeComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoModelBuffersPerNode!.Value;
        this.cfgVideoGroundCoverBuffersPerNodeComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoGroundCoverBuffersPerNode!.Value;
        this.cfgVideoGroundBuffersPerNodeComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoGroundBuffersPerNode!.Value;
        this.cfgVideoGrassDistanceComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoGrassDistance!.Value;
        this.cfgVideoEffectQualityComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoEffectQuality!.Value;
        this.cfgVideoDepthShadowsResolutionComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoDepthShadowsResolution!.Value;
        this.cfgVideoDepthShadowsComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoDepthShadows!.Value;
        this.cfgVideoCampaignResolutionComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoCampaignResolution!.Value;
        this.cfgVideoBuildingDetailComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoBuildingDetail!.Value;
        this.cfgVideoBattleResolutionComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoBattleResolution!.Value;
        this.cfgVideoAntialiasingComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoAntialiasing!.Value;
        this.cfgVideoAntiAliasModeComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoAntiAliasMode!.Value;
        this.cfgVideoAnisotropicLevelComboBox.Text = this.gameConfigStateView.GameVideoCfgSection.VideoAnisotropicLevel!.Value;
        this.cfgVideoWindowedCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoWindowedMode!.GetValue();
        this.cfgVideoWidescreenCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoWidescreenMode!.GetValue();
        this.cfgVideoVsyncCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoVsync!.GetValue();
        this.cfgVideoVegetationCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoVegetation!.GetValue();
        this.cfgVideoSubtitlesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoSubtitles!.GetValue();
        this.cfgVideoStencilShadowsCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoStencilShadows!.GetValue();
        this.cfgVideoSplashesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoSplashes!.GetValue();
        this.cfgVideoSkipMipLevelsChecBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoSkipMipLevels!.GetValue();
        this.cfgVideoShowPackageLitterCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoShowPackageLitter!.GetValue();
        this.cfgVideoShowBannersCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoShowBanners!.GetValue();
        this.cfgVideoSabotageMoviesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoSabotageMovies!.GetValue();
        this.cfgVideoReflectionCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoReflection!.GetValue();
        this.cfgVideoNoBackgroundFmvCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoNoBackgroundFmv!.GetValue();
        this.cfgVideoMoviesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoMovies!.GetValue();
        this.cfgVideoInfiltrationMoviesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoInfiltrationMovies!.GetValue();
        this.cfgVideoEventMoviesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoEventMovies!.GetValue();
        this.cfgVideoBloomCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoBloom!.GetValue();
        this.cfgVideoAutodetectCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoAutodetect!.GetValue();
        this.cfgVideoAssassinationMoviesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection.VideoAssassinationMovies!.GetValue();
    }

#if TESTING
    private void TestConfigSettings()
    {
        // [GAME]

        this.cfgGameUseQuickchatCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameUseQuickchat = new M2TW_Boolean(false),
        this.cfgGameUnlimitedMenOnBattlefieldCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameUnlimitedMenOnBattlefield = new M2TW_Boolean(true),
        this.cfgGameNoCampaignBattleTimeLimitCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameNoCampaignBattleTimeLimit = new M2TW_Boolean(true),
        this.cfgGameMuteAdvisorCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameMuteAdvisor = new M2TW_Boolean(false),
        this.cfgGameMoraleCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameMorale = new M2TW_Boolean(true),
        this.cfgGameMicromanageAllSettlementsCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameMicromanageAllSettlements = new M2TW_Boolean(true),
        this.cfgGameLabelSettlementsCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameLabelSettlements = new M2TW_Boolean(true),
        this.cfgGameLabelCharactersCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameLabelCharacters = new M2TW_Boolean(false),
        this.cfgGameGamespySavePasswrdCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameGamespySavePasswrd = new M2TW_Boolean(true),
        this.cfgGameFirstTimePlayCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameFirstTimePlay = new M2TW_Boolean(false),
        this.cfgGameFatigueCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameFatigue = new M2TW_Boolean(true),
        this.cfgGameEventCutscenesCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameEventCutscenes = new M2TW_Boolean(true),
        this.cfgGameEnglishCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameEnglish = new M2TW_Boolean(false),
        this.cfgGameDisableEventsCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameDisableEvents = new M2TW_Boolean(false),
        this.cfgGameDisableArrowMarkersCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameDisableArrowMarkers = new M2TW_Boolean(false),
        this.cfgGameBlindAdvisorCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameBlindAdvisor = new M2TW_Boolean(false),
        this.cfgGameAutoSaveCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameAutoSave = new M2TW_Boolean(true),
        this.cfgGameAllUsersCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameAllUsers = new M2TW_Boolean(true),
        this.cfgGameAdvisorVerbosityCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameAdvisorVerbosity = new M2TW_Boolean(false),
        this.cfgGameAdvancedStatsAlwaysCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModGameplaySection.GameAdvancedStatsAlways = new M2TW_Boolean(false),
        this.cfgGameUnitSizeComboBox/* ComboBox(); */ // this.gameConfigStateView.ModGameplaySection.GameUnitSize = new M2TW_UnitSize(M2TW_Size.Huge),
        this.cfgGameChatMsgDurationNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.ModGameplaySection.GameChatMsgDuration = new M2TW_Integer(M2TW_Integer.ExtendedMaxValue),
        this.cfgGameCampaignMapSpeedUpNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.ModGameplaySection.GameCampaignMapSpeedUp = new M2TW_Integer(1),
        this.cfgGameCampaignMapGameSpeedNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.ModGameplaySection.GameCampaignMapGameSpeed = new M2TW_Integer(10),
        this.cfgGamePrefFactionsPlayedTextBox/* TextBox(); */ // this.gameConfigStateView.ModGameplaySection.GamePrefFactionsPlayed = 4177855,
        this.cfgGameTutorialPathTextBox/* TextBox(); */ // this.gameConfigStateView.ModGameplaySection.GameTutorialPath = "norman_prologue/battle_of_hastings",
        this.cfgGameAiFactionsComboBox/* ComboBox(); */ // this.gameConfigStateView.ModGameplaySection.GameAiFactions = new M2TW_Boolean(M2TW_Deprecated_AI_Boolean.Follow),
        this.cfgGameCampaignNumTimePlayTextBox/* TextBox(); */ // this.gameConfigStateView.ModGameplaySection.GameCampaignNumTimePlay = new M2TW_Integer(252),

        // [AUDIO] GameAudioCfgSectionStateView

        this.cfgAudioSpeechNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameAudioCfgSection.SpeechVolume = new M2TW_Integer(85),
        this.cfgAudioSfxNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameAudioCfgSection.SoundEffectsVolume = new M2TW_Integer(80),
        this.cfgAudioSoundCardProviderNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameAudioCfgSection.SpeechVolume = new M2TW_Integer(85),
        this.cfgAudioMusicVolumeNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameAudioCfgSection.AudioMusicVolume = new M2TW_Integer(70),
        this.cfgAudioMasterVolumeNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameAudioCfgSection.AudioMasterVolume = new M2TW_Integer(85),
        this.cfgAudioSpeechEnableCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameAudioCfgSection.SpeechEnable = new M2TW_Boolean(true),
        this.cfgAudioEnableCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameAudioCfgSection.AudioEnable = new M2TW_Boolean(true),
        this.cfgAudioSubFactionAccentsEnableCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameAudioCfgSection.SubFactionAccents = new M2TW_Boolean(true),

        // [CAMERA] GameCameraCfgSectionStateView

        this.cfgControlsDefaultInBattleComboBox/* ComboBox(); */ // this.gameConfigStateView.GameCameraCfgSection.CameraDefaultInBattle = new M2TW_BattleCameraStyle(M2TW_BattleCamera.RTS),
        this.cfgCameraRotateNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameCameraCfgSection.CameraRotate = new M2TW_Integer(30),
        this.cfgCameraMoveNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameCameraCfgSection.CameraMove = new M2TW_Integer(70),
        this.cfgCameraRestrictCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameCameraCfgSection.CameraRestrict = new M2TW_Boolean(false),

        // [CONTROLS] GameControlsCfgSectionStateView

        this.cfgControlsKeysetNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameControlsCfgSection.KeySet = new M2TW_QualityLevel(M2TW_KeySet.KeySet_0),
        this.cfgControlsScrollMinZoomNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameControlsCfgSection.CampaignScrollMinZoom = Convert.ToByte(30),
        this.cfgControlsScrollMaxZoomNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameControlsCfgSection.CampaignScrollMaxZoom = Convert.ToByte(30),

        // [HOTSEAT] ModHotseatSectionStateView

        this.cfgHotseatGameNameTextBox/* TextBox(); */ // this.gameConfigStateView.HotseatSection.HotseatGameName = "hotseat_gamename.sav",
        this.cfgHotseatAdminPasswordTextBox/* TextBox(); */ // this.gameConfigStateView.HotseatSection.HotseatAdminPassword = string.Empty,
        this.cfgHotseatPasswordsTextBox/* TextBox(); */ // this.gameConfigStateView.HotseatSection.HotseatPasswords = new M2TW_Boolean(false),
        this.cfgHotseatValidateDiplomacyCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatValidateDiplomacy = new M2TW_Boolean(false),
        this.cfgHotseatAllowValidationFailuresCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatAllowValidationFailures = new M2TW_Boolean(false),
        this.cfgHotseatValidateDataCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatValidateData = new M2TW_Boolean(false),
        this.cfgHotseatCloseAfterSaveCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatCloseAfterSave = new M2TW_Boolean(false),
        this.cfgHotseatSaveConfigCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatSaveConfig = new M2TW_Boolean(true),
        this.cfgHotseatAutosaveCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatAutoSave = new M2TW_Boolean(true),
        this.cfgHotseatUpdateAiCameraCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatUpdateAiCamera = new M2TW_Boolean(true),
        this.cfgHotseatSavePrefsCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatSavePrefs = new M2TW_Boolean(true),
        this.cfgHotseatDisablePapalElectionsCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatDisablePapalElections = new M2TW_Boolean(true),
        this.cfgHotseatDisableConsoleCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatDisableConsole = new M2TW_Boolean(false),
        this.cfgHotseatTurnsCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatTurns = new M2TW_Boolean(false),
        this.cfgHotseatScrollCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatScroll = new M2TW_Boolean(false),
        this.cfgHotseatAutoresolveBattlesCheckBox/* CheckBox(); */ // this.gameConfigStateView.HotseatSection.HotseatAutoresolveBattles = new M2TW_Boolean(false),

        // [NETWORK]

        this.cfgNetworkUsePortTextBox/* TextBox(); */ // this.gameConfigStateView.HotseatSection.NetworkUsePort = Convert.ToUInt16(M2TW_IpAddress.DefaultPort),
        this.cfgNetworkUseIpTextBox/* TextBox(); */ // this.gameConfigStateView.HotseatSection.NetworkUseIp = new M2TW_IpAddress(127, 0, 0, 1),

        // [MISC]

        this.cfgMiscBypassToStrategySaveTextBox/* TextBox(); */ // this.gameConfigStateView.BypassToStrategySave = "game_name.sav",
        this.cfgMiscUnlockCampaignCheckBox/* CheckBox(); */ // this.gameConfigStateView.UnlockCampaign = new M2TW_Boolean(false),

        // [IO] ModSettingsSectionStateView

        this.cfgIOFileFirstCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModCoreSettingsSection.FileFirst = new M2TW_Boolean(true),
        this.cfgFeaturesEditorCheckBox/* CheckBox(); */ // this.gameConfigStateView.ModCoreSettingsSection.Editor = new M2TW_Boolean(true),

        // [UI] GameUICfgSectionStateView

        this.cfgUiUnitCardsCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameUICfgSection.UiUnitCards = new M2TW_Boolean(M2TW_Deprecated_UI_Boolean.Show),
        this.cfgUiShowTooltipsCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameUICfgSection.UiShowTooltips = new M2TW_Boolean(true),
        this.cfgUiRadarCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameUICfgSection.UiRadar = new M2TW_Boolean(M2TW_Deprecated_UI_Boolean.Show),
        this.cfgUiFullBattleHudCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameUICfgSection.UiFullBattleHud = new M2TW_Boolean(true),
        this.cfgUiButtonsCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameUICfgSection.UiButtons = new M2TW_Boolean(M2TW_Deprecated_UI_Boolean.Show),
        this.cfgUiSaCardsCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameUICfgSection.UiSaCards = new M2TW_Boolean(M2TW_Deprecated_UI_Boolean.Show),

        // [VIDEO] GameVideoCfgSectionStateView

        this.cfgVideoGammaNumericUpDown/* NumericUpDown(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoGamma = new M2TW_Integer(120),
        this.cfgVideoWaterBuffersPerNodeComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoWaterBuffersPerNode = new M2TW_Integer(4),
        this.cfgVideoUnitDetailComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoUnitDetail = new M2TW_QualityLevel(M2TW_Quality.Highest),
        this.cfgVideoTextureFilteringComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoTextureFiltering = new M2TW_Integer(2),
        this.cfgVideoTerrainQualityComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoTerrainQuality = new M2TW_QualityLevel(M2TW_Quality.High),
        this.cfgVideoSpriteBuffersPerNodeComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoSpriteBuffersPerNode = new M2TW_Integer(4),
        this.cfgVideoShaderComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoShader = new M2TW_QualityLevel(M2TW_ShaderLevel.ShaderVersion_v2),
        this.cfgVideoModelBuffersPerNodeComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoModelBuffersPerNode = new M2TW_Integer(4),
        this.cfgVideoGroundCoverBuffersPerNodeComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoGroundCoverBuffersPerNode = new M2TW_Integer(4),
        this.cfgVideoGroundBuffersPerNodeComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoGroundBuffersPerNode = new M2TW_Integer(4),
        this.cfgVideoGrassDistanceComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoGrassDistance = new M2TW_QualityLevel(M2TW_GrassDistance.Level_1),
        this.cfgVideoEffectQualityComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoEffectQuality = new M2TW_QualityLevel(M2TW_Quality.Highest),
        this.cfgVideoDepthShadowsResolutionComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoDepthShadowsResolution = new M2TW_Integer(3),
        this.cfgVideoDepthShadowsComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoDepthShadows = new M2TW_Integer(2),
        this.cfgVideoCampaignResolutionComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoCampaignResolution = new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1024x768),
        this.cfgVideoBuildingDetailComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoBuildingDetail = new M2TW_QualityLevel(M2TW_Quality.High),
        this.cfgVideoBattleResolutionComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoBattleResolution = new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1024x768),
        this.cfgVideoAntialiasingComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoAntialiasing = new M2TW_QualityLevel(M2TW_AntiAliasing.AntiAliasMode_x4),
        this.cfgVideoAntiAliasModeComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoAntiAliasMode = new M2TW_QualityLevel(M2TW_AntiAliasMode.AntiAliasMode_x4),
        this.cfgVideoAnisotropicLevelComboBox/* ComboBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoAnisotropicLevel = new M2TW_QualityLevel(M2TW_AnisotropicFilteringLevel.AF_x16),
        this.cfgVideoWindowedCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoWindowedMode = new M2TW_Boolean(false),
        this.cfgVideoWidescreenCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoWidescreenMode = new M2TW_Boolean(true),
        this.cfgVideoVsyncCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoVsync = new M2TW_Boolean(false),
        this.cfgVideoVegetationCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoVegetation = new M2TW_Boolean(false),
        this.cfgVideoSubtitlesCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoSubtitles = new M2TW_Boolean(false),
        this.cfgVideoStencilShadowsCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoStencilShadows = new M2TW_Boolean(true),
        this.cfgVideoSplashesCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoSplashes = new M2TW_Boolean(true),
        this.cfgVideoSkipMipLevelsChecBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoSkipMipLevels = new M2TW_Boolean(false),
        this.cfgVideoShowPackageLitterCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoShowPackageLitter = new M2TW_Boolean(true),
        this.cfgVideoShowBannersCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoShowBanners = new M2TW_Boolean(false),
        this.cfgVideoSabotageMoviesCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoSabotageMovies = new M2TW_Boolean(false),
        this.cfgVideoReflectionCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoReflection = new M2TW_Boolean(true),
        this.cfgVideoNoBackgroundFmvCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoNoBackgroundFmv = new M2TW_Boolean(true),
        this.cfgVideoMoviesCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoMovies = new M2TW_Boolean(true),
        this.cfgVideoInfiltrationMoviesCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoInfiltrationMovies = new M2TW_Boolean(false),
        this.cfgVideoEventMoviesCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoEventMovies = new M2TW_Boolean(true),
        this.cfgVideoBloomCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoBloom = new M2TW_Boolean(true),
        this.cfgVideoAutodetectCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoAutodetect = new M2TW_Boolean(false),
        this.cfgVideoAssassinationMoviesCheckBox/* CheckBox(); */ // this.gameConfigStateView.GameVideoCfgSection.VideoAssassinationMovies = new M2TW_Boolean(false),

        // [LOG]

        this.checkBoxLogHistory/* CheckBox(); */ // this.gameConfigStateView.ModDiagnosticSection // OVERRIDE!!!
        this.radioButtonLogErrorAndTrace/* RadioButton(); */ // this.gameConfigStateView.ModDiagnosticSection.LogLevel = new M2TW_LoggingLevel(M2TW_LoggingMode.Error), // OVERRIDE!!!
        this.radioButtonLogOnlyTrace/* RadioButton(); */ // this.gameConfigStateView.ModDiagnosticSection.LogLevel = new M2TW_LoggingLevel(M2TW_LoggingMode.Error), // OVERRIDE!!!
        this.radioButtonLogOnlyError/* RadioButton(); */ // this.gameConfigStateView.ModDiagnosticSection.LogLevel = new M2TW_LoggingLevel(M2TW_LoggingMode.Error), // OVERRIDE!!!
        this.cfgLogLocationTextBox/* TextBox(); */ // this.gameConfigStateView.ModDiagnosticSection.LogTo = mod.LogFileRelativePath,
    }
#endif

#if SKIPPED_IMPLEMENTATION


    private void InitializeAdditionalUIControls() // TODO: Implement this method later...
    {
        // [GAME]
        // GameTutorialBattlePlayed = new M2TW_Boolean(false),

        // [AUDIO]
        // SoundCardProvider = "Miles Fast 2D Positional Audio",

        // [HOTSEAT]
        // MultiplayerPlayable = new M2TW_Boolean(true), ???

        // [VIDEO]
        // VideoVegetationQuality = new M2TW_QualityLevel(M2TW_Quality.High),
        // VideoBorderlessWindow = new M2TW_Boolean(false),

        // ADDITIONAL CONFIG SETTINGS

        // [LOG]
        this.checkBoxLogHistory/* CheckBox(); */ // this.gameConfigStateView.ModDiagnosticSection
        this.radioButtonLogErrorAndTrace/* RadioButton(); */ // this.gameConfigStateView.ModDiagnosticSection.LogLevel = new M2TW_LoggingLevel(M2TW_LoggingMode.Error)
        this.radioButtonLogOnlyTrace/* RadioButton(); */ // this.gameConfigStateView.ModDiagnosticSection.LogLevel = new M2TW_LoggingLevel(M2TW_LoggingMode.Error)
        this.radioButtonLogOnlyError/* RadioButton(); */ // this.gameConfigStateView.ModDiagnosticSection.LogLevel = new M2TW_LoggingLevel(M2TW_LoggingMode.Error)
        this.cfgLogLocationTextBox/* TextBox(); */ // this.gameConfigStateView.ModDiagnosticSection.LogTo = mod.LogFileRelativePath,
    }
#endif
}
