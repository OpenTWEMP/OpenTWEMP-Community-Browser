using System;
using System.IO;
using System.Windows.Forms;
using TWE_Launcher.Models;

namespace TWE_Launcher.Forms
{
	public partial class ModQuickNavigatorForm : Form
	{
		private string currentModHomeDirectory;

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

			currentModHomeDirectory = modHomeDirectory;

			string modLocationPrefix = "[MOD]";
			Text = $"Mod Quick Navigation: {modHomeDirectory}";

			modDataFolderName = "data";
			modSavesFolderName = "saves";
			modLogsFolderName = "logs";
			dataTextFolderName = "text";
			dataLoadingScreenFolderName = "loading_screen";
			dataUiFolderName = "ui";
			dataFmvFolderName = "fmv";
			dataSoundsFolderName = "sounds";
			dataUnitModelsFolderName = "unit_models";
			dataUnitSpritesFolderName = "unit_sprites";
			dataAnimationsFolderName = "animations";
			dataBannersFolderName = "banners";
			dataModelsStratFolderName = "models_strat";
			worldMapsBaseFolderName = "world\\maps\\base";
			worldMapsCampaignFolderName = "world\\maps\\campaign\\imperial_campaign";

			modDataNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}";
			modSavesNavigateButton.Text = $"{modLocationPrefix}\\{modSavesFolderName}";
			modLogsNavigateButton.Text = $"{modLocationPrefix}\\{modLogsFolderName}";
			dataTextNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{dataTextFolderName}";
			dataLoadingScreenNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{dataLoadingScreenFolderName}";
			dataUiNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{dataUiFolderName}";
			dataFmvNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{dataFmvFolderName}";
			dataSoundsNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{dataSoundsFolderName}";
			dataUnitModelsNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{dataUnitModelsFolderName}";
			dataUnitSpritesNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{dataUnitSpritesFolderName}";
			dataAnimationsNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{dataAnimationsFolderName}";
			dataBannersNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{dataBannersFolderName}";
			dataModelsStratNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{dataModelsStratFolderName}";
			worldMapsBaseNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{worldMapsBaseFolderName}";
			worldMapsCampaignNavigateButton.Text = $"{modLocationPrefix}\\{modDataFolderName}\\{worldMapsCampaignFolderName}";
		}

		private void formExitButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void modDataNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void modSavesNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modSavesFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void modLogsNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modLogsFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void dataTextNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataTextFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void dataLoadingScreenNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataLoadingScreenFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void dataUiNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataUiFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void dataFmvNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataFmvFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void dataSoundsNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataSoundsFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void dataUnitModelsNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataUnitModelsFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void dataUnitSpritesNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataUnitSpritesFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void dataAnimationsNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataAnimationsFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void dataBannersNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataBannersFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void dataModelsStratNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataModelsStratFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void worldMapsBaseNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, worldMapsBaseFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}

		private void worldMapsCampaignNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, worldMapsCampaignFolderName);
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
		}
	}
}
