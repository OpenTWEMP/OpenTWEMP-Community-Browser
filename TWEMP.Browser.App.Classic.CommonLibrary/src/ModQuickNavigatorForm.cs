// <copyright file="ModQuickNavigatorForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using TWEMP.Browser.Core.CommonLibrary.Utilities;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Modding;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class ModQuickNavigatorForm : Form, ICanChangeMyLocalization
{
    private const string ModLocationPrefix = "[MOD]";

    private readonly BrowserMessageProvider currentMessageProvider;

    private readonly string currentModHomeDirectory;
    private readonly string modDataFolderName;
    private readonly string modSavesFolderName;
    private readonly string modLogsFolderName;
    private readonly string dataTextFolderName;
    private readonly string dataLoadingScreenFolderName;
    private readonly string dataUiFolderName;
    private readonly string dataFmvFolderName;
    private readonly string dataSoundsFolderName;
    private readonly string dataUnitModelsFolderName;
    private readonly string dataUnitSpritesFolderName;
    private readonly string dataAnimationsFolderName;
    private readonly string dataBannersFolderName;
    private readonly string dataModelsStratFolderName;
    private readonly string worldMapsBaseFolderName;
    private readonly string worldMapsCampaignFolderName;

    public ModQuickNavigatorForm(string modHomeDirectory)
    {
        this.InitializeComponent();

        this.SetupCurrentLocalizationForGUIControls();

        this.currentMessageProvider = BrowserMessageProvider.CurrentProvider;

        this.Text += $": {modHomeDirectory}";

        this.currentModHomeDirectory = modHomeDirectory;
        this.modDataFolderName = M2TWFileSystemInfo.ModDataFolderName;
        this.modSavesFolderName = M2TWFileSystemInfo.ModSavesFolderName;
        this.modLogsFolderName = M2TWFileSystemInfo.ModLogsFolderName;
        this.dataTextFolderName = M2TWFileSystemInfo.DataTextFolderName;
        this.dataLoadingScreenFolderName = M2TWFileSystemInfo.DataLoadingScreenFolderName;
        this.dataUiFolderName = M2TWFileSystemInfo.DataUiFolderName;
        this.dataFmvFolderName = M2TWFileSystemInfo.DataFmvFolderName;
        this.dataSoundsFolderName = M2TWFileSystemInfo.DataSoundsFolderName;
        this.dataUnitModelsFolderName = M2TWFileSystemInfo.DataUnitModelsFolderName;
        this.dataUnitSpritesFolderName = M2TWFileSystemInfo.DataUnitSpritesFolderName;
        this.dataAnimationsFolderName = M2TWFileSystemInfo.DataAnimationsFolderName;
        this.dataBannersFolderName = M2TWFileSystemInfo.DataBannersFolderName;
        this.dataModelsStratFolderName = M2TWFileSystemInfo.DataModelsStratFolderName;
        this.worldMapsBaseFolderName = M2TWFileSystemInfo.WorldMapsBaseFolderName;
        this.worldMapsCampaignFolderName = M2TWFileSystemInfo.WorldMapsCampaignFolderName;

        this.modDataNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}";
        this.modSavesNavigateButton.Text = $"{ModLocationPrefix}\\{this.modSavesFolderName}";
        this.modLogsNavigateButton.Text = $"{ModLocationPrefix}\\{this.modLogsFolderName}";
        this.dataTextNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.dataTextFolderName}";
        this.dataLoadingScreenNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.dataLoadingScreenFolderName}";
        this.dataUiNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.dataUiFolderName}";
        this.dataFmvNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.dataFmvFolderName}";
        this.dataSoundsNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.dataSoundsFolderName}";
        this.dataUnitModelsNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.dataUnitModelsFolderName}";
        this.dataUnitSpritesNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.dataUnitSpritesFolderName}";
        this.dataAnimationsNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.dataAnimationsFolderName}";
        this.dataBannersNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.dataBannersFolderName}";
        this.dataModelsStratNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.dataModelsStratFolderName}";
        this.worldMapsBaseNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.worldMapsBaseFolderName}";
        this.worldMapsCampaignNavigateButton.Text = $"{ModLocationPrefix}\\{this.modDataFolderName}\\{this.worldMapsCampaignFolderName}";
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        this.Text = GetTextInCurrentLocalization(this.Name, this.Name);
        this.labelCommonInfo.Text = GetTextInCurrentLocalization(this.Name, this.labelCommonInfo.Name);
        this.formExitButton.Text = GetTextInCurrentLocalization(this.Name, this.formExitButton.Name);
    }

    private void NavigateToModDirectory(string directoryPath)
    {
        SystemToolbox.ShowFileSystemDirectory(directoryPath, this.currentMessageProvider);
    }

    private void FormExitButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void ModDataNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void ModSavesNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modSavesFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void ModLogsNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modLogsFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void DataTextNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.dataTextFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void DataLoadingScreenNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.dataLoadingScreenFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void DataUiNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.dataUiFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void DataFmvNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.dataFmvFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void DataSoundsNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.dataSoundsFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void DataUnitModelsNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.dataUnitModelsFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void DataUnitSpritesNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.dataUnitSpritesFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void DataAnimationsNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.dataAnimationsFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void DataBannersNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.dataBannersFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void DataModelsStratNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.dataModelsStratFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void WorldMapsBaseNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.worldMapsBaseFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }

    private void WorldMapsCampaignNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(this.currentModHomeDirectory, this.modDataFolderName, this.worldMapsCampaignFolderName);
        this.NavigateToModDirectory(targetFolderPath);
    }
}
