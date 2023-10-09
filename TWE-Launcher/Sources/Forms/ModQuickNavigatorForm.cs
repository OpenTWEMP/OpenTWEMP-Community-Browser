using System;
using System.IO;
using System.Windows.Forms;

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
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
        }

        private void modSavesNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modSavesFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void modLogsNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modLogsFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void dataTextNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataTextFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void dataLoadingScreenNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataLoadingScreenFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void dataUiNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataUiFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void dataFmvNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataFmvFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void dataSoundsNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataSoundsFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void dataUnitModelsNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataUnitModelsFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void dataUnitSpritesNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataUnitSpritesFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void dataAnimationsNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataAnimationsFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void dataBannersNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataBannersFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void dataModelsStratNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, dataModelsStratFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void worldMapsBaseNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, worldMapsBaseFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}

		private void worldMapsCampaignNavigateButton_Click(object sender, EventArgs e)
		{
			string targetFolderPath = Path.Combine(currentModHomeDirectory, modDataFolderName, worldMapsCampaignFolderName);
#if DISABLE_WHEN_MIGRATION
			SystemToolbox.ShowFileSystemDirectory(targetFolderPath);
#endif
		}
	}
}
