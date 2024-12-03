// <copyright file="ModConfigSettingsForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

#define DISABLED_CFG_OPTIONS
#undef DISABLED_CFG_OPTIONS

#define EXPERIMENTAL_FEATURES
#undef EXPERIMENTAL_FEATURES

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

public partial class ModConfigSettingsForm : Form
{
    private static readonly (string Text, byte Obj)[] CfgVideoWaterBuffersPerNodeItems;
    private static readonly (string Text, byte Obj)[] CfgVideoTextureFilteringItems;
    private static readonly (string Text, byte Obj)[] CfgVideoSpriteBuffersPerNodeItems;
    private static readonly (string Text, byte Obj)[] CfgVideoModelBuffersPerNodeItems;
    private static readonly (string Text, byte Obj)[] CfgVideoGroundCoverBuffersPerNodeItems;
    private static readonly (string Text, byte Obj)[] CfgVideoGroundBuffersPerNodeItems;
    private static readonly (string Text, byte Obj)[] CfgVideoDepthShadowsResolutionItems;
    private static readonly (string Text, byte Obj)[] CfgVideoDepthShadowsItems;
    private static readonly (string Text, M2TW_UnitSize Obj)[] CfgGameUnitSizeItems;
    private static readonly (string Text, M2TW_Boolean Obj)[] CfgGameAiFactionsItems;
    private static readonly (string Text, M2TW_Boolean Obj)[] CfgGameUiFactionsItems;
    private static readonly (string Text, M2TW_BattleCameraStyle Obj)[] CfgControlsDefaultInBattleItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgControlsKeysetItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgVideoUnitDetailItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgVideoTerrainQualityItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgVideoVegetationQualityItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgVideoShaderItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgVideoGrassDistanceItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgVideoEffectQualityItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgVideoBuildingDetailItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgVideoAntialiasingItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgVideoAntiAliasModeItems;
    private static readonly (string Text, M2TW_QualityLevel Obj)[] CfgVideoAnisotropicLevelItems;
    private static readonly (string Text, M2TW_DisplayResolution Obj)[] CfgVideoDisplayResolutionItems;
    private static readonly (string Text, M2TW_LoggingLevel Obj)[] CfgLoggingLevelItems;

    private readonly GameModificationInfo currentGameModificationInfo;
    private readonly GameConfigProfile currentGameConfigProfile;
    private readonly GameConfigProfileCreateForm? currentCallingForm;

    private readonly M2TWGameConfigStateView gameConfigStateView;

    static ModConfigSettingsForm()
    {
        CfgVideoWaterBuffersPerNodeItems =
        [
            (Text: "0", Obj: 0),
            (Text: "1", Obj: 1),
            (Text: "2", Obj: 2),
            (Text: "3", Obj: 3),
            (Text: "4", Obj: 4),
        ];

        CfgVideoTextureFilteringItems =
        [
            (Text: "0", Obj: 0),
            (Text: "1", Obj: 1),
            (Text: "2", Obj: 2),
        ];

        CfgVideoSpriteBuffersPerNodeItems =
        [
            (Text: "0", Obj: 0),
            (Text: "1", Obj: 1),
            (Text: "2", Obj: 2),
            (Text: "3", Obj: 3),
            (Text: "4", Obj: 4),
        ];

        CfgVideoModelBuffersPerNodeItems =
        [
            (Text: "0", Obj: 0),
            (Text: "1", Obj: 1),
            (Text: "2", Obj: 2),
            (Text: "3", Obj: 3),
            (Text: "4", Obj: 4),
        ];

        CfgVideoGroundCoverBuffersPerNodeItems =
        [
            (Text: "0", Obj: 0),
            (Text: "1", Obj: 1),
            (Text: "2", Obj: 2),
            (Text: "3", Obj: 3),
            (Text: "4", Obj: 4),
        ];

        CfgVideoGroundBuffersPerNodeItems =
        [
            (Text: "0", Obj: 0),
            (Text: "1", Obj: 1),
            (Text: "2", Obj: 2),
            (Text: "3", Obj: 3),
            (Text: "4", Obj: 4),
        ];

        CfgVideoDepthShadowsResolutionItems =
        [
            (Text: "0", Obj: 0),
            (Text: "1", Obj: 1),
            (Text: "2", Obj: 2),
            (Text: "3", Obj: 3),
            (Text: "4", Obj: 4),
        ];

        CfgVideoDepthShadowsItems =
        [
            (Text: "0", Obj: 0),
            (Text: "1", Obj: 1),
            (Text: "2", Obj: 2),
            (Text: "3", Obj: 3),
            (Text: "4", Obj: 4),
        ];

        CfgGameUnitSizeItems =
        [
            (M2TW_UnitSize.Small, new M2TW_UnitSize(M2TW_Size.Small)),
            (M2TW_UnitSize.Normal, new M2TW_UnitSize(M2TW_Size.Normal)),
            (M2TW_UnitSize.Large, new M2TW_UnitSize(M2TW_Size.Large)),
            (M2TW_UnitSize.Huge, new M2TW_UnitSize(M2TW_Size.Huge)),
        ];

        CfgGameAiFactionsItems =
        [
            (M2TW_Boolean.M2TW_Deprecated_AI_False, new M2TW_Boolean(M2TW_Deprecated_AI_Boolean.Skip)),
            (M2TW_Boolean.M2TW_Deprecated_AI_True, new M2TW_Boolean(M2TW_Deprecated_AI_Boolean.Follow)),
        ];

        CfgGameUiFactionsItems =
        [
            (M2TW_Boolean.M2TW_Deprecated_UI_False, new M2TW_Boolean(M2TW_Deprecated_UI_Boolean.Hide)),
            (M2TW_Boolean.M2TW_Deprecated_UI_True, new M2TW_Boolean(M2TW_Deprecated_UI_Boolean.Show)),
        ];

        CfgControlsDefaultInBattleItems =
        [
            (M2TW_BattleCameraStyle.Default_Camera, new M2TW_BattleCameraStyle(M2TW_BattleCamera.Default)),
            (M2TW_BattleCameraStyle.Generals_Camera, new M2TW_BattleCameraStyle(M2TW_BattleCamera.Generals)),
            (M2TW_BattleCameraStyle.RTS_Camera, new M2TW_BattleCameraStyle(M2TW_BattleCamera.RTS)),
        ];

        CfgControlsKeysetItems =
        [
            (M2TW_QualityLevel.M2TW_KeySet_0, new M2TW_QualityLevel(M2TW_KeySet.KeySet_0)),
            (M2TW_QualityLevel.M2TW_KeySet_1, new M2TW_QualityLevel(M2TW_KeySet.KeySet_1)),
            (M2TW_QualityLevel.M2TW_KeySet_2, new M2TW_QualityLevel(M2TW_KeySet.KeySet_2)),
            (M2TW_QualityLevel.M2TW_KeySet_3, new M2TW_QualityLevel(M2TW_KeySet.KeySet_3)),
        ];

        CfgVideoUnitDetailItems =
        [
            (M2TW_QualityLevel.Low, new M2TW_QualityLevel(M2TW_Quality.Low)),
            (M2TW_QualityLevel.Medium, new M2TW_QualityLevel(M2TW_Quality.Medium)),
            (M2TW_QualityLevel.High, new M2TW_QualityLevel(M2TW_Quality.High)),
            (M2TW_QualityLevel.Highest, new M2TW_QualityLevel(M2TW_Quality.Highest)),
        ];

        CfgVideoTerrainQualityItems =
        [
            (M2TW_QualityLevel.Low, new M2TW_QualityLevel(M2TW_Quality.Low)),
            (M2TW_QualityLevel.Medium, new M2TW_QualityLevel(M2TW_Quality.Medium)),
            (M2TW_QualityLevel.High, new M2TW_QualityLevel(M2TW_Quality.High)),
            (M2TW_QualityLevel.Highest, new M2TW_QualityLevel(M2TW_Quality.Highest)),
        ];

        CfgVideoVegetationQualityItems =
        [
            (M2TW_QualityLevel.Low, new M2TW_QualityLevel(M2TW_Quality.Low)),
            (M2TW_QualityLevel.Medium, new M2TW_QualityLevel(M2TW_Quality.Medium)),
            (M2TW_QualityLevel.High, new M2TW_QualityLevel(M2TW_Quality.High)),
            (M2TW_QualityLevel.Highest, new M2TW_QualityLevel(M2TW_Quality.Highest)),
        ];

        CfgVideoShaderItems =
        [
            (M2TW_QualityLevel.M2TW_ShaderVersion_v1, new M2TW_QualityLevel(M2TW_ShaderLevel.ShaderVersion_v1)),
            (M2TW_QualityLevel.M2TW_ShaderVersion_v2, new M2TW_QualityLevel(M2TW_ShaderLevel.ShaderVersion_v2)),
        ];

        CfgVideoGrassDistanceItems =
        [
            (M2TW_QualityLevel.M2TW_GrassDistanceLevel_0, new M2TW_QualityLevel(M2TW_GrassDistance.Level_0)),
            (M2TW_QualityLevel.M2TW_GrassDistanceLevel_1, new M2TW_QualityLevel(M2TW_GrassDistance.Level_1)),
            (M2TW_QualityLevel.M2TW_GrassDistanceLevel_2, new M2TW_QualityLevel(M2TW_GrassDistance.Level_2)),
            (M2TW_QualityLevel.M2TW_GrassDistanceLevel_3, new M2TW_QualityLevel(M2TW_GrassDistance.Level_3)),
        ];

        CfgVideoEffectQualityItems =
        [
            (M2TW_QualityLevel.Low, new M2TW_QualityLevel(M2TW_Quality.Low)),
            (M2TW_QualityLevel.Medium, new M2TW_QualityLevel(M2TW_Quality.Medium)),
            (M2TW_QualityLevel.High, new M2TW_QualityLevel(M2TW_Quality.High)),
            (M2TW_QualityLevel.Highest, new M2TW_QualityLevel(M2TW_Quality.Highest)),
        ];

        CfgVideoBuildingDetailItems =
        [
            (M2TW_QualityLevel.Low, new M2TW_QualityLevel(M2TW_Quality.Low)),
            (M2TW_QualityLevel.Medium, new M2TW_QualityLevel(M2TW_Quality.Medium)),
            (M2TW_QualityLevel.High, new M2TW_QualityLevel(M2TW_Quality.High)),
            (M2TW_QualityLevel.Highest, new M2TW_QualityLevel(M2TW_Quality.Highest)),
        ];

        CfgVideoAntialiasingItems =
        [
            (M2TW_QualityLevel.M2TW_AntiAliasing_None, new M2TW_QualityLevel(M2TW_AntiAliasing.AntiAliasMode_None)),
            (M2TW_QualityLevel.M2TW_AntiAliasing_x2, new M2TW_QualityLevel(M2TW_AntiAliasing.AntiAliasMode_x2)),
            (M2TW_QualityLevel.M2TW_AntiAliasing_x4, new M2TW_QualityLevel(M2TW_AntiAliasing.AntiAliasMode_x4)),
        ];

        CfgVideoAntiAliasModeItems =
        [
            (M2TW_QualityLevel.M2TW_AntiAliasing_OffMode, new M2TW_QualityLevel(M2TW_AntiAliasMode.AntiAliasMode_Off)),
            (M2TW_QualityLevel.M2TW_AntiAliasing_x2, new M2TW_QualityLevel(M2TW_AntiAliasMode.AntiAliasMode_x2)),
            (M2TW_QualityLevel.M2TW_AntiAliasing_x4, new M2TW_QualityLevel(M2TW_AntiAliasMode.AntiAliasMode_x4)),
        ];

        CfgVideoAnisotropicLevelItems =
        [
            (M2TW_QualityLevel.M2TW_AF_Bilinear, new M2TW_QualityLevel(M2TW_AnisotropicFilteringLevel.Bilinear)),
            (M2TW_QualityLevel.M2TW_AF_Trilinear, new M2TW_QualityLevel(M2TW_AnisotropicFilteringLevel.Trilinear)),
            (M2TW_QualityLevel.M2TW_AF_x2, new M2TW_QualityLevel(M2TW_AnisotropicFilteringLevel.AF_x2)),
            (M2TW_QualityLevel.M2TW_AF_x4, new M2TW_QualityLevel(M2TW_AnisotropicFilteringLevel.AF_x4)),
            (M2TW_QualityLevel.M2TW_AF_x8, new M2TW_QualityLevel(M2TW_AnisotropicFilteringLevel.AF_x8)),
            (M2TW_QualityLevel.M2TW_AF_x16, new M2TW_QualityLevel(M2TW_AnisotropicFilteringLevel.AF_x16)),
        ];

        CfgVideoDisplayResolutionItems =
        [
            (M2TW_DisplayResolution.W640_H480, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_640x480)),
            (M2TW_DisplayResolution.W800_H600, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_800x600)),
            (M2TW_DisplayResolution.W1024_H768, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1024x768)),
            (M2TW_DisplayResolution.W1280_H720, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1280x720)),
            (M2TW_DisplayResolution.W1280_H1024, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1280x1024)),
            (M2TW_DisplayResolution.W1366_H768, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1366x768)),
            (M2TW_DisplayResolution.W1600_H900, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1600x900)),
            (M2TW_DisplayResolution.W1600_H1200, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1600x1200)),
            (M2TW_DisplayResolution.W1920_H1080, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_1920x1080)),
            (M2TW_DisplayResolution.W2048_H1536, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_2048x1536)),
            (M2TW_DisplayResolution.W2560_H1440, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_2560x1440)),
            (M2TW_DisplayResolution.W3072_H1728, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_3072x1728)),
            (M2TW_DisplayResolution.W3200_H1800, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_3200x1800)),
            (M2TW_DisplayResolution.W3840_H2160, new M2TW_DisplayResolution(M2TW_DisplayResolution.Display_3840x2160)),
        ];

        CfgLoggingLevelItems =
        [
            (M2TW_LoggingLevel.LogLevelError, new M2TW_LoggingLevel(M2TW_LoggingMode.Error)),
            (M2TW_LoggingLevel.LogLevelTrace, new M2TW_LoggingLevel(M2TW_LoggingMode.Trace)),
            (M2TW_LoggingLevel.LogLevelScriptTrace, new M2TW_LoggingLevel(M2TW_LoggingMode.ScriptTrace)),
        ];
    }

    public ModConfigSettingsForm(GameModificationInfo gameModificationInfo)
    {
        this.currentGameModificationInfo = gameModificationInfo;
        this.currentGameConfigProfile = GameConfigProfile.CreateDefaultTemplate(this.currentGameModificationInfo);
        this.currentCallingForm = null;

        this.gameConfigStateView = M2TWGameConfigStateView.CreateByDefault(this.currentGameModificationInfo);

        this.InitializeComponent();
        this.InitializeConfigControls();
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

        this.InitializeComponent();
        this.InitializeConfigControls();
    }

    private static void InitializeComboBoxControl<T>(ComboBox control, (string Text, T Obj)[] items, int selectedIndex)
    {
        control.Items.Clear();

        foreach ((string Text, T Obj) item in items)
        {
            control.Items.Add(item.Text);
        }

        control.SelectedIndex = (selectedIndex < control.Items.Count) ? selectedIndex : 0;
    }

    private static T GetPredefinedItemByIndex<T>((string Text, T Obj)[] items, int index)
    {
        T defaultItem = items[0].Obj;

        if (items.Length < index)
        {
            return defaultItem;
        }

        T targetItem = items[index].Obj;

        return (targetItem != null) ? targetItem : defaultItem;
    }

    private void SaveConfigSettingsButton_Click(object sender, EventArgs e)
    {
        M2TWGameConfigStateView gameConfigStateView = this.CreateGameConfigStateView();
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
#if EXPERIMENTAL_FEATURES
        MessageBox.Show("RESET CONFIG SETTINGS");
#endif
    }

    private void ExitConfigSettingsButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void ExportConfigSettingsButton_Click(object sender, EventArgs e)
    {
        const string exportFileName = "config.json";

        M2TWGameConfigStateView gameConfigStateView = this.CreateGameConfigStateView();
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
#if EXPERIMENTAL_FEATURES
        OpenFileDialog importFileDialog = new ();
        importFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        DialogResult result = importFileDialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            string importFileFullName = importFileDialog.FileName;

            // TODO: Fix an exception when deserialization GameCfgSection objects!
            GameCfgSection[] gameCfgSections = BrowserKernel.ImportConfigSettingsFromFile(importFileFullName);
            this.InitializeConfigControls(gameCfgSections); // TODO: Implement this method in future.

            MessageBox.Show(
                text: $"Config settings were imported from the file:\n{importFileFullName}",
                caption: "<IMPORT CFG [TESTING]>",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Information);
        }
#endif
    }

    private M2TWGameConfigStateView CreateGameConfigStateView()
    {
        M2TWGameConfigStateView gameConfigStateView = new (this.gameConfigStateView);

        // [GAME]
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
        gameConfigStateView.ModGameplaySection.GameCampaignMapSpeedUp = new M2TW_Integer(Convert.ToByte(this.cfgGameCampaignMapSpeedUpNumericUpDown.Text));
        gameConfigStateView.ModGameplaySection.GameCampaignMapGameSpeed = new M2TW_Integer(Convert.ToByte(this.cfgGameCampaignMapGameSpeedNumericUpDown.Text));
        gameConfigStateView.ModGameplaySection.GamePrefFactionsPlayed = Convert.ToInt32(this.cfgGamePrefFactionsPlayedTextBox.Text);
        gameConfigStateView.ModGameplaySection.GameTutorialBattlePlayed = new M2TW_Boolean(this.cfgGameTutorialBattlePlayedCheckBox.Checked);
        gameConfigStateView.ModGameplaySection.GameTutorialPath = this.cfgGameTutorialPathTextBox.Text;
        gameConfigStateView.ModGameplaySection.GameCampaignNumTimePlay = new M2TW_Integer(Convert.ToByte(this.cfgGameCampaignNumTimePlayTextBox.Text));
        gameConfigStateView.ModGameplaySection.GameChatMsgDuration = new M2TW_Integer(Convert.ToUInt16(this.cfgGameChatMsgDurationNumericUpDown.Value));

        gameConfigStateView.ModGameplaySection.GameUnitSize = GetPredefinedItemByIndex(
            items: CfgGameUnitSizeItems, index: this.cfgGameUnitSizeComboBox.SelectedIndex);

        gameConfigStateView.ModGameplaySection.GameAiFactions = GetPredefinedItemByIndex(
            items: CfgGameAiFactionsItems, index: this.cfgGameAiFactionsComboBox.SelectedIndex);

        // [AUDIO]
        gameConfigStateView.GameAudioCfgSection!.SpeechVolume = new M2TW_Integer(Convert.ToByte(this.cfgAudioSpeechNumericUpDown.Text));
        gameConfigStateView.GameAudioCfgSection.SoundEffectsVolume = new M2TW_Integer(Convert.ToByte(this.cfgAudioSfxNumericUpDown.Text));
        gameConfigStateView.GameAudioCfgSection.SpeechVolume = new M2TW_Integer(Convert.ToByte(this.cfgAudioSoundCardProviderNumericUpDown.Text));
        gameConfigStateView.GameAudioCfgSection.AudioMusicVolume = new M2TW_Integer(Convert.ToByte(this.cfgAudioMusicVolumeNumericUpDown.Text));
        gameConfigStateView.GameAudioCfgSection.AudioMasterVolume = new M2TW_Integer(Convert.ToByte(this.cfgAudioMasterVolumeNumericUpDown.Text));
        gameConfigStateView.GameAudioCfgSection.SpeechEnable = new M2TW_Boolean(this.cfgAudioSpeechEnableCheckBox.Checked);
        gameConfigStateView.GameAudioCfgSection.AudioEnable = new M2TW_Boolean(this.cfgAudioEnableCheckBox.Checked);
        gameConfigStateView.GameAudioCfgSection.SubFactionAccents = new M2TW_Boolean(this.cfgAudioSubFactionAccentsEnableCheckBox.Checked);

        // [CAMERA]
        gameConfigStateView.GameCameraCfgSection!.CameraDefaultInBattle = GetPredefinedItemByIndex(
            items: CfgControlsDefaultInBattleItems, index: this.cfgControlsDefaultInBattleComboBox.SelectedIndex);

        gameConfigStateView.GameCameraCfgSection.CameraRotate = new M2TW_Integer(Convert.ToByte(this.cfgCameraRotateNumericUpDown.Text));
        gameConfigStateView.GameCameraCfgSection.CameraMove = new M2TW_Integer(Convert.ToByte(this.cfgCameraMoveNumericUpDown.Text));
        gameConfigStateView.GameCameraCfgSection.CameraRestrict = new M2TW_Boolean(this.cfgCameraRestrictCheckBox.Checked);

        // [CONTROLS]
        gameConfigStateView.GameControlsCfgSection!.KeySet = GetPredefinedItemByIndex(
            items: CfgControlsKeysetItems, index: this.cfgControlsKeysetComboBox.SelectedIndex);

        gameConfigStateView.GameControlsCfgSection.CampaignScrollMinZoom = Convert.ToByte(this.cfgControlsScrollMinZoomNumericUpDown.Text);
        gameConfigStateView.GameControlsCfgSection.CampaignScrollMaxZoom = Convert.ToByte(this.cfgControlsScrollMaxZoomNumericUpDown.Text);

        // [HOTSEAT]
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

        // [MULTIPLAYER]
        gameConfigStateView.HotseatSection.MultiplayerPlayable = new M2TW_Boolean(this.cfgMultiplayerPlayableCheckBox.Checked);

        // [NETWORK]
        gameConfigStateView.HotseatSection.NetworkUsePort = Convert.ToUInt16(this.cfgNetworkUsePortTextBox.Text); // TODO: Check the port is valid.
        gameConfigStateView.HotseatSection.NetworkUseIp = new M2TW_IpAddress(127, 0, 0, 1); // TODO: Check the IP address is valid.

        // [MISC]
#if DISABLED_CFG_OPTIONS
        gameConfigStateView.HotseatSection.BypassToStrategySave = this.cfgMiscBypassToStrategySaveTextBox.Text;
#endif
        gameConfigStateView.ModGameplaySection.UnlockCampaign = new M2TW_Boolean(this.cfgMiscUnlockCampaignCheckBox.Checked);

        // [IO]
        gameConfigStateView.ModCoreSettingsSection!.FileFirst = new M2TW_Boolean(this.cfgIOFileFirstCheckBox.Checked);
        gameConfigStateView.ModCoreSettingsSection.Editor = new M2TW_Boolean(this.cfgFeaturesEditorCheckBox.Checked);

        // [LOG]
        gameConfigStateView.ModDiagnosticSection!.LogTo = this.cfgLogLocationTextBox.Text;

        gameConfigStateView.ModDiagnosticSection!.LogLevel = GetPredefinedItemByIndex(
            items: CfgLoggingLevelItems, index: this.cfgLogLevelComboBox.SelectedIndex);

        // [UI]
        gameConfigStateView.GameUICfgSection!.UiUnitCards = new M2TW_Boolean(this.cfgUiUnitCardsCheckBox.Checked);
        gameConfigStateView.GameUICfgSection.UiShowTooltips = new M2TW_Boolean(this.cfgUiShowTooltipsCheckBox.Checked);
        gameConfigStateView.GameUICfgSection.UiRadar = new M2TW_Boolean(this.cfgUiRadarCheckBox.Checked);
        gameConfigStateView.GameUICfgSection.UiFullBattleHud = new M2TW_Boolean(this.cfgUiFullBattleHudCheckBox.Checked);
        gameConfigStateView.GameUICfgSection.UiButtons = new M2TW_Boolean(this.cfgUiButtonsCheckBox.Checked);
        gameConfigStateView.GameUICfgSection.UiSaCards = new M2TW_Boolean(this.cfgUiSaCardsCheckBox.Checked);

        // [VIDEO]
        gameConfigStateView.GameVideoCfgSection!.VideoGamma = new M2TW_Integer(Convert.ToByte(this.cfgVideoGammaNumericUpDown.Text));

        gameConfigStateView.GameVideoCfgSection.VideoWaterBuffersPerNode = new M2TW_Integer(GetPredefinedItemByIndex(
            items: CfgVideoWaterBuffersPerNodeItems, index: this.cfgVideoWaterBuffersPerNodeComboBox.SelectedIndex));

        gameConfigStateView.GameVideoCfgSection.VideoTextureFiltering = new M2TW_Integer(GetPredefinedItemByIndex(
            items: CfgVideoTextureFilteringItems, index: this.cfgVideoTextureFilteringComboBox.SelectedIndex));

        gameConfigStateView.GameVideoCfgSection.VideoSpriteBuffersPerNode = new M2TW_Integer(GetPredefinedItemByIndex(
            items: CfgVideoSpriteBuffersPerNodeItems, index: this.cfgVideoSpriteBuffersPerNodeComboBox.SelectedIndex));

        gameConfigStateView.GameVideoCfgSection.VideoModelBuffersPerNode = new M2TW_Integer(GetPredefinedItemByIndex(
            items: CfgVideoModelBuffersPerNodeItems, index: this.cfgVideoModelBuffersPerNodeComboBox.SelectedIndex));

        gameConfigStateView.GameVideoCfgSection.VideoGroundCoverBuffersPerNode = new M2TW_Integer(GetPredefinedItemByIndex(
            items: CfgVideoGroundCoverBuffersPerNodeItems, index: this.cfgVideoGroundCoverBuffersPerNodeComboBox.SelectedIndex));

        gameConfigStateView.GameVideoCfgSection.VideoGroundBuffersPerNode = new M2TW_Integer(GetPredefinedItemByIndex(
            items: CfgVideoGroundBuffersPerNodeItems, index: this.cfgVideoGroundBuffersPerNodeComboBox.SelectedIndex));

        gameConfigStateView.GameVideoCfgSection.VideoDepthShadowsResolution = new M2TW_Integer(GetPredefinedItemByIndex(
            items: CfgVideoDepthShadowsResolutionItems, index: this.cfgVideoDepthShadowsResolutionComboBox.SelectedIndex));

        gameConfigStateView.GameVideoCfgSection.VideoDepthShadows = new M2TW_Integer(GetPredefinedItemByIndex(
            items: CfgVideoDepthShadowsItems, index: this.cfgVideoDepthShadowsComboBox.SelectedIndex));

        gameConfigStateView.GameVideoCfgSection.VideoBorderlessWindow = new M2TW_Boolean(this.cfgVideoBorderlessWindowCheckBox.Checked);
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

        gameConfigStateView.GameVideoCfgSection.VideoCampaignResolution = GetPredefinedItemByIndex(
            items: CfgVideoDisplayResolutionItems, index: this.cfgVideoCampaignResolutionComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoBattleResolution = GetPredefinedItemByIndex(
            items: CfgVideoDisplayResolutionItems, index: this.cfgVideoBattleResolutionComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoUnitDetail = GetPredefinedItemByIndex(
            items: CfgVideoUnitDetailItems, index: this.cfgVideoUnitDetailComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoTerrainQuality = GetPredefinedItemByIndex(
            items: CfgVideoTerrainQualityItems, index: this.cfgVideoTerrainQualityComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoVegetationQuality = GetPredefinedItemByIndex(
            items: CfgVideoVegetationQualityItems, index: this.cfgVideoVegetationQualityComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoShader = GetPredefinedItemByIndex(
            items: CfgVideoShaderItems, index: this.cfgVideoShaderComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoGrassDistance = GetPredefinedItemByIndex(
            items: CfgVideoGrassDistanceItems, index: this.cfgVideoGrassDistanceComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoEffectQuality = GetPredefinedItemByIndex(
            items: CfgVideoEffectQualityItems, index: this.cfgVideoEffectQualityComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoBuildingDetail = GetPredefinedItemByIndex(
            items: CfgVideoBuildingDetailItems, index: this.cfgVideoBuildingDetailComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoAntialiasing = GetPredefinedItemByIndex(
            items: CfgVideoAntialiasingItems, index: this.cfgVideoAntialiasingComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoAntiAliasMode = GetPredefinedItemByIndex(
            items: CfgVideoAntiAliasModeItems, index: this.cfgVideoAntiAliasModeComboBox.SelectedIndex);

        gameConfigStateView.GameVideoCfgSection.VideoAnisotropicLevel = GetPredefinedItemByIndex(
            items: CfgVideoAnisotropicLevelItems, index: this.cfgVideoAnisotropicLevelComboBox.SelectedIndex);

        return gameConfigStateView;
    }

    private void InitializeConfigControls()
    {
        this.Text = $"M2TW Config Settings: \"{this.currentGameConfigProfile.Name}\" [ {this.currentGameModificationInfo.Location} ]";

        this.InitializeAllCheckBoxControls();
        this.InitializeAllComboBoxControls();
        this.InitializeAllNumericUpDownControls();
        this.InitializeAllTextBoxControls();
    }

#if EXPERIMENTAL_FEATURES
    private void InitializeConfigControls(GameCfgSection[] gameCfgSections)
    {
    }
#endif

    private void InitializeAllCheckBoxControls()
    {
        // [GAME]
        this.cfgGameUseQuickchatCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameUseQuickchat!.GetValue();
        this.cfgGameUnlimitedMenOnBattlefieldCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameUnlimitedMenOnBattlefield!.GetValue();
        this.cfgGameNoCampaignBattleTimeLimitCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameNoCampaignBattleTimeLimit!.GetValue();
        this.cfgGameMuteAdvisorCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameMuteAdvisor!.GetValue();
        this.cfgGameMoraleCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameMorale!.GetValue();
        this.cfgGameMicromanageAllSettlementsCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameMicromanageAllSettlements!.GetValue();
        this.cfgGameLabelSettlementsCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameLabelSettlements!.GetValue();
        this.cfgGameLabelCharactersCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameLabelCharacters!.GetValue();
        this.cfgGameGamespySavePasswrdCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameGamespySavePasswrd!.GetValue();
        this.cfgGameFirstTimePlayCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameFirstTimePlay!.GetValue();
        this.cfgGameFatigueCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameFatigue!.GetValue();
        this.cfgGameEventCutscenesCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameEventCutscenes!.GetValue();
        this.cfgGameEnglishCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameEnglish!.GetValue();
        this.cfgGameDisableEventsCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameDisableEvents!.GetValue();
        this.cfgGameDisableArrowMarkersCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameDisableArrowMarkers!.GetValue();
        this.cfgGameBlindAdvisorCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameBlindAdvisor!.GetValue();
        this.cfgGameAutoSaveCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameAutoSave!.GetValue();
        this.cfgGameAllUsersCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameAllUsers!.GetValue();
        this.cfgGameAdvisorVerbosityCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameAdvisorVerbosity!.GetValue();
        this.cfgGameAdvancedStatsAlwaysCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameAdvancedStatsAlways!.GetValue();
        this.cfgGameTutorialBattlePlayedCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.GameTutorialBattlePlayed!.GetValue();

        // [AUDIO]
        this.cfgAudioSpeechEnableCheckBox.Checked = this.gameConfigStateView.GameAudioCfgSection!.SpeechEnable!.GetValue();
        this.cfgAudioEnableCheckBox.Checked = this.gameConfigStateView.GameAudioCfgSection!.AudioEnable!.GetValue();
        this.cfgAudioSubFactionAccentsEnableCheckBox.Checked = this.gameConfigStateView.GameAudioCfgSection!.SubFactionAccents!.GetValue();

        // [CAMERA]
        this.cfgCameraRestrictCheckBox.Checked = this.gameConfigStateView.GameCameraCfgSection!.CameraRestrict!.GetValue();

        // [HOTSEAT]
        this.cfgHotseatAdminPasswordCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatAdminPassword!.GetValue();
        this.cfgHotseatPasswordsCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatPasswords!.GetValue();
        this.cfgHotseatValidateDiplomacyCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatValidateDiplomacy!.GetValue();
        this.cfgHotseatAllowValidationFailuresCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatAllowValidationFailures!.GetValue();
        this.cfgHotseatValidateDataCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatValidateData!.GetValue();
        this.cfgHotseatCloseAfterSaveCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatCloseAfterSave!.GetValue();
        this.cfgHotseatSaveConfigCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatSaveConfig!.GetValue();
        this.cfgHotseatAutosaveCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatAutoSave!.GetValue();
        this.cfgHotseatUpdateAiCameraCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatUpdateAiCamera!.GetValue();
        this.cfgHotseatSavePrefsCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatSavePrefs!.GetValue();
        this.cfgHotseatDisablePapalElectionsCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatDisablePapalElections!.GetValue();
        this.cfgHotseatDisableConsoleCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatDisableConsole!.GetValue();
        this.cfgHotseatTurnsCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatTurns!.GetValue();
        this.cfgHotseatScrollCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatScroll!.GetValue();
        this.cfgHotseatAutoresolveBattlesCheckBox.Checked = this.gameConfigStateView.HotseatSection!.HotseatAutoresolveBattles!.GetValue();

        // [MULTIPLAYER]
        this.cfgMultiplayerPlayableCheckBox.Checked = this.gameConfigStateView.HotseatSection!.MultiplayerPlayable!.GetValue();

        // [MISC]
        this.cfgMiscUnlockCampaignCheckBox.Checked = this.gameConfigStateView.ModGameplaySection!.UnlockCampaign!.GetValue();

        // [IO]
        this.cfgIOFileFirstCheckBox.Checked = this.gameConfigStateView.ModCoreSettingsSection!.FileFirst!.GetValue();

        // [FEATURES]
        this.cfgFeaturesEditorCheckBox.Checked = this.gameConfigStateView.ModCoreSettingsSection!.Editor!.GetValue();

        // [UI]
        this.cfgUiUnitCardsCheckBox.Checked = this.gameConfigStateView.GameUICfgSection!.UiUnitCards!.GetValue();
        this.cfgUiShowTooltipsCheckBox.Checked = this.gameConfigStateView.GameUICfgSection!.UiShowTooltips!.GetValue();
        this.cfgUiRadarCheckBox.Checked = this.gameConfigStateView.GameUICfgSection!.UiRadar!.GetValue();
        this.cfgUiFullBattleHudCheckBox.Checked = this.gameConfigStateView.GameUICfgSection!.UiFullBattleHud!.GetValue();
        this.cfgUiButtonsCheckBox.Checked = this.gameConfigStateView.GameUICfgSection!.UiButtons!.GetValue();
        this.cfgUiSaCardsCheckBox.Checked = this.gameConfigStateView.GameUICfgSection!.UiSaCards!.GetValue();

        // [VIDEO]
        this.cfgVideoBorderlessWindowCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoBorderlessWindow!.GetValue();
        this.cfgVideoWindowedCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoWindowedMode!.GetValue();
        this.cfgVideoWidescreenCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoWidescreenMode!.GetValue();
        this.cfgVideoVsyncCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoVsync!.GetValue();
        this.cfgVideoVegetationCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoVegetation!.GetValue();
        this.cfgVideoSubtitlesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoSubtitles!.GetValue();
        this.cfgVideoStencilShadowsCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoStencilShadows!.GetValue();
        this.cfgVideoSplashesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoSplashes!.GetValue();
        this.cfgVideoSkipMipLevelsChecBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoSkipMipLevels!.GetValue();
        this.cfgVideoShowPackageLitterCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoShowPackageLitter!.GetValue();
        this.cfgVideoShowBannersCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoShowBanners!.GetValue();
        this.cfgVideoSabotageMoviesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoSabotageMovies!.GetValue();
        this.cfgVideoReflectionCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoReflection!.GetValue();
        this.cfgVideoNoBackgroundFmvCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoNoBackgroundFmv!.GetValue();
        this.cfgVideoMoviesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoMovies!.GetValue();
        this.cfgVideoInfiltrationMoviesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoInfiltrationMovies!.GetValue();
        this.cfgVideoEventMoviesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoEventMovies!.GetValue();
        this.cfgVideoBloomCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoBloom!.GetValue();
        this.cfgVideoAutodetectCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoAutodetect!.GetValue();
        this.cfgVideoAssassinationMoviesCheckBox.Checked = this.gameConfigStateView.GameVideoCfgSection!.VideoAssassinationMovies!.GetValue();
    }

    private void InitializeAllComboBoxControls()
    {
        InitializeComboBoxControl(this.cfgGameUnitSizeComboBox, CfgGameUnitSizeItems, Convert.ToInt32(M2TW_Size.Huge));
        InitializeComboBoxControl(this.cfgGameAiFactionsComboBox, CfgGameAiFactionsItems, Convert.ToInt32(M2TW_Deprecated_AI_Boolean.Follow));
        InitializeComboBoxControl(this.cfgControlsDefaultInBattleComboBox, CfgControlsDefaultInBattleItems, Convert.ToInt32(M2TW_BattleCamera.RTS));
        InitializeComboBoxControl(this.cfgControlsKeysetComboBox, CfgControlsKeysetItems, Convert.ToInt32(M2TW_KeySet.KeySet_3));

        int selectedIndexByDefault = 4; // select maximum values for config options
        InitializeComboBoxControl(this.cfgVideoWaterBuffersPerNodeComboBox, CfgVideoWaterBuffersPerNodeItems, selectedIndexByDefault);
        InitializeComboBoxControl(this.cfgVideoUnitDetailComboBox, CfgVideoUnitDetailItems, selectedIndexByDefault);
        InitializeComboBoxControl(this.cfgVideoSpriteBuffersPerNodeComboBox, CfgVideoSpriteBuffersPerNodeItems, selectedIndexByDefault);
        InitializeComboBoxControl(this.cfgVideoModelBuffersPerNodeComboBox, CfgVideoModelBuffersPerNodeItems, selectedIndexByDefault);
        InitializeComboBoxControl(this.cfgVideoGroundCoverBuffersPerNodeComboBox, CfgVideoGroundCoverBuffersPerNodeItems, selectedIndexByDefault);
        InitializeComboBoxControl(this.cfgVideoGroundBuffersPerNodeComboBox, CfgVideoGroundBuffersPerNodeItems, selectedIndexByDefault);
        InitializeComboBoxControl(this.cfgVideoDepthShadowsResolutionComboBox, CfgVideoDepthShadowsResolutionItems, selectedIndexByDefault);
        InitializeComboBoxControl(this.cfgVideoDepthShadowsComboBox, CfgVideoDepthShadowsItems, selectedIndexByDefault);

        selectedIndexByDefault = 2; // select maximum values for 'texture_filtering' config option
        InitializeComboBoxControl(this.cfgVideoTextureFilteringComboBox, CfgVideoTextureFilteringItems, selectedIndexByDefault);

        InitializeComboBoxControl(this.cfgVideoAntialiasingComboBox, CfgVideoAntialiasingItems, Convert.ToInt32(M2TW_AntiAliasing.AntiAliasMode_x4));
        InitializeComboBoxControl(this.cfgVideoAntiAliasModeComboBox, CfgVideoAntiAliasModeItems, Convert.ToInt32(M2TW_AntiAliasMode.AntiAliasMode_x4));
        InitializeComboBoxControl(this.cfgVideoAnisotropicLevelComboBox, CfgVideoAnisotropicLevelItems, Convert.ToInt32(M2TW_AnisotropicFilteringLevel.AF_x16));
        InitializeComboBoxControl(this.cfgVideoGrassDistanceComboBox, CfgVideoGrassDistanceItems, Convert.ToInt32(M2TW_GrassDistance.Level_3));
        InitializeComboBoxControl(this.cfgVideoShaderComboBox, CfgVideoShaderItems, Convert.ToInt32(M2TW_ShaderLevel.ShaderVersion_v2));
        InitializeComboBoxControl(this.cfgVideoBuildingDetailComboBox, CfgVideoBuildingDetailItems, Convert.ToInt32(M2TW_Quality.Medium));
        InitializeComboBoxControl(this.cfgVideoEffectQualityComboBox, CfgVideoEffectQualityItems, Convert.ToInt32(M2TW_Quality.Medium));
        InitializeComboBoxControl(this.cfgVideoTerrainQualityComboBox, CfgVideoTerrainQualityItems, Convert.ToInt32(M2TW_Quality.Medium));
        InitializeComboBoxControl(this.cfgVideoVegetationQualityComboBox, CfgVideoVegetationQualityItems, Convert.ToInt32(M2TW_Quality.Medium));

        selectedIndexByDefault = 2; // select the '1024 x 768' display resolution by default from CfgVideoDisplayResolutionItems
        InitializeComboBoxControl(this.cfgVideoBattleResolutionComboBox, CfgVideoDisplayResolutionItems, selectedIndexByDefault);
        InitializeComboBoxControl(this.cfgVideoCampaignResolutionComboBox, CfgVideoDisplayResolutionItems, selectedIndexByDefault);

        InitializeComboBoxControl(this.cfgLogLevelComboBox, CfgLoggingLevelItems, Convert.ToInt32(M2TW_LoggingMode.Error));
    }

    private void InitializeAllNumericUpDownControls()
    {
        this.cfgGameChatMsgDurationNumericUpDown.Maximum = M2TW_Integer.ExtendedMaxValue;
        this.cfgGameChatMsgDurationNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgGameChatMsgDurationNumericUpDown.Text = this.gameConfigStateView.ModGameplaySection!.GameChatMsgDuration!.Value;

        this.cfgGameCampaignMapSpeedUpNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgGameCampaignMapSpeedUpNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgGameCampaignMapSpeedUpNumericUpDown.Text = this.gameConfigStateView.ModGameplaySection!.GameCampaignMapSpeedUp!.Value;

        this.cfgGameCampaignMapGameSpeedNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgGameCampaignMapGameSpeedNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgGameCampaignMapGameSpeedNumericUpDown.Text = this.gameConfigStateView.ModGameplaySection!.GameCampaignMapGameSpeed!.Value;

        this.cfgAudioSpeechNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgAudioSpeechNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgAudioSpeechNumericUpDown.Text = this.gameConfigStateView.GameAudioCfgSection!.SpeechVolume!.Value;

        this.cfgAudioSfxNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgAudioSfxNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgAudioSfxNumericUpDown.Text = this.gameConfigStateView.GameAudioCfgSection!.SoundEffectsVolume!.Value;

        this.cfgAudioSoundCardProviderNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgAudioSoundCardProviderNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgAudioSoundCardProviderNumericUpDown.Text = this.gameConfigStateView.GameAudioCfgSection!.SpeechVolume!.Value;

        this.cfgAudioMusicVolumeNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgAudioMusicVolumeNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgAudioMusicVolumeNumericUpDown.Text = this.gameConfigStateView.GameAudioCfgSection!.AudioMusicVolume!.Value;

        this.cfgAudioMasterVolumeNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgAudioMasterVolumeNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgAudioMasterVolumeNumericUpDown.Text = this.gameConfigStateView.GameAudioCfgSection!.AudioMasterVolume!.Value;

        this.cfgCameraRotateNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgCameraRotateNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgCameraRotateNumericUpDown.Text = this.gameConfigStateView.GameCameraCfgSection!.CameraRotate!.Value;

        this.cfgCameraMoveNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgCameraMoveNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgCameraMoveNumericUpDown.Text = this.gameConfigStateView.GameCameraCfgSection!.CameraMove!.Value;

        this.cfgControlsScrollMinZoomNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgControlsScrollMinZoomNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgControlsScrollMinZoomNumericUpDown.Text = this.gameConfigStateView.GameControlsCfgSection!.CampaignScrollMinZoom!.ToString();

        this.cfgControlsScrollMaxZoomNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgControlsScrollMaxZoomNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgControlsScrollMaxZoomNumericUpDown.Text = this.gameConfigStateView.GameControlsCfgSection!.CampaignScrollMaxZoom!.ToString();

        this.cfgVideoGammaNumericUpDown.Maximum = M2TW_Integer.MaxValue;
        this.cfgVideoGammaNumericUpDown.Minimum = M2TW_Integer.MinValue;
        this.cfgVideoGammaNumericUpDown.Text = this.gameConfigStateView.GameVideoCfgSection!.VideoGamma!.Value;
    }

    private void InitializeAllTextBoxControls()
    {
        this.cfgGamePrefFactionsPlayedTextBox.Text = this.gameConfigStateView.ModGameplaySection!.GamePrefFactionsPlayed!.ToString();
        this.cfgGameTutorialPathTextBox.Text = this.gameConfigStateView.ModGameplaySection!.GameTutorialPath!;
        this.cfgGameCampaignNumTimePlayTextBox.Text = this.gameConfigStateView.ModGameplaySection!.GameCampaignNumTimePlay!.Value;
        this.cfgHotseatGameNameTextBox.Text = this.gameConfigStateView.HotseatSection!.HotseatGameName!;
        this.cfgNetworkUsePortTextBox.Text = this.gameConfigStateView.HotseatSection!.NetworkUsePort!.ToString(); // TODO: Init the default IP port.
        this.cfgNetworkUseIpTextBox.Text = this.gameConfigStateView.HotseatSection!.NetworkUseIp!.Value; // TODO: Init the default IP address.
        this.cfgLogLocationTextBox.Text = this.gameConfigStateView.ModDiagnosticSection!.LogTo!;
#if DISABLED_CFG_OPTIONS
        this.cfgMiscBypassToStrategySaveTextBox.Text = this.gameConfigStateView.HotseatSection!.BypassToStrategySave!;
#endif
    }
}
