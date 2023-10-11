// <copyright file="ModQuickNavigatorForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using M2TW = TWEMP.Browser.Core.GamingSupport.TotalWarEngineSupportProvider;

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
        InitializeComponent();

        SetupCurrentLocalizationForGUIControls();

        currentMessageProvider = BrowserMessageProvider.CurrentProvider;

        Text = $"Mod Quick Navigation: {modHomeDirectory}";

        currentModHomeDirectory = modHomeDirectory;
        modDataFolderName = M2TW.ModDataFolderName;
        modSavesFolderName = M2TW.ModSavesFolderName;
        modLogsFolderName = M2TW.ModLogsFolderName;
        dataTextFolderName = M2TW.DataTextFolderName;
        dataLoadingScreenFolderName = M2TW.DataLoadingScreenFolderName;
        dataUiFolderName = M2TW.DataUiFolderName;
        dataFmvFolderName = M2TW.DataFmvFolderName;
        dataSoundsFolderName = M2TW.DataSoundsFolderName;
        dataUnitModelsFolderName = M2TW.DataUnitModelsFolderName;
        dataUnitSpritesFolderName = M2TW.DataUnitSpritesFolderName;
        dataAnimationsFolderName = M2TW.DataAnimationsFolderName;
        dataBannersFolderName = M2TW.DataBannersFolderName;
        dataModelsStratFolderName = M2TW.DataModelsStratFolderName;
        worldMapsBaseFolderName = M2TW.WorldMapsBaseFolderName;
        worldMapsCampaignFolderName = M2TW.WorldMapsCampaignFolderName;

        modDataNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}";
        modSavesNavigateButton.Text = $"{ModLocationPrefix}\\{modSavesFolderName}";
        modLogsNavigateButton.Text = $"{ModLocationPrefix}\\{modLogsFolderName}";
        dataTextNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{dataTextFolderName}";
        dataLoadingScreenNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{dataLoadingScreenFolderName}";
        dataUiNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{dataUiFolderName}";
        dataFmvNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{dataFmvFolderName}";
        dataSoundsNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{dataSoundsFolderName}";
        dataUnitModelsNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{dataUnitModelsFolderName}";
        dataUnitSpritesNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{dataUnitSpritesFolderName}";
        dataAnimationsNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{dataAnimationsFolderName}";
        dataBannersNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{dataBannersFolderName}";
        dataModelsStratNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{dataModelsStratFolderName}";
        worldMapsBaseNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{worldMapsBaseFolderName}";
        worldMapsCampaignNavigateButton.Text = $"{ModLocationPrefix}\\{modDataFolderName}\\{worldMapsCampaignFolderName}";
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        FormLocaleSnapshot snapshot = Settings.CurrentLocalization.GetFormLocaleSnapshotByKey(Name);

        Text = snapshot.GetLocalizedValueByKey(Name);
        labelCommonInfo.Text = snapshot.GetLocalizedValueByKey(labelCommonInfo.Name);
        formExitButton.Text = snapshot.GetLocalizedValueByKey(formExitButton.Name);
    }

    private void NavigateToModDirectory(string directoryPath)
    {
        SystemToolbox.ShowFileSystemDirectory(directoryPath, currentMessageProvider);
    }

    private void FormExitButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void ModDataNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void ModSavesNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modSavesFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void ModLogsNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modLogsFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void DataTextNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataTextFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void DataLoadingScreenNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataLoadingScreenFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void DataUiNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataUiFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void DataFmvNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataFmvFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void DataSoundsNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataSoundsFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void DataUnitModelsNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataUnitModelsFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void DataUnitSpritesNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataUnitSpritesFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void DataAnimationsNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataAnimationsFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void DataBannersNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataBannersFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void DataModelsStratNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataModelsStratFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void WorldMapsBaseNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, worldMapsBaseFolderName);
        NavigateToModDirectory(targetFolderPath);
    }

    private void WorldMapsCampaignNavigateButton_Click(object sender, EventArgs e)
    {
        string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, worldMapsCampaignFolderName);
        NavigateToModDirectory(targetFolderPath);
    }
}
