namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;

public partial class GameSetupConfigForm : Form
{
	private readonly IUpdatableBrowser currentBrowser;

	public GameSetupConfigForm(IUpdatableBrowser browser)
	{
		InitializeComponent();
		currentBrowser = browser;
	}

	public void UpdateGameSetupListBox()
	{
		gameSetupPathsListBox.Items.Clear();
		setupViewButton.Enabled = false;
		setupPathDeleteButton.Enabled = false;

		InitializeGameSetupListBox(Settings.GameInstallations);
	}


	private static string InitializeGameSetupObjectItem(GameSetupInfo gameSetupObject)
	{
		return gameSetupObject.Name +
			" [" + gameSetupObject.HomeDirectory + "] " +
				"(" + gameSetupObject.ExecutableFileName + ")";
	}

	private void GameSetupConfigForm_Load(object sender, EventArgs e)
	{
		Settings.SynchronizeGameSetupSettings();
		InitializeGameSetupListBox(Settings.GameInstallations);
	}

	private void InitializeGameSetupListBox(List<GameSetupInfo> gameSetupsObjects)
	{
		foreach (var gameSetup in gameSetupsObjects)
		{
			string gameSetupInfoText = InitializeGameSetupObjectItem(gameSetup);
			gameSetupPathsListBox.Items.Add(gameSetupInfoText);
		}
	}

	private void GameSetupConfigForm_FormClosed(object sender, FormClosedEventArgs e)
	{
		UpdateCallingFormState();
	}

	private void SetupPathAddButton_Click(object sender, EventArgs e)
	{
		var gameSetupConfigForm = new AddNewGameSetupForm(this);
		Enabled = false;
		gameSetupConfigForm.Show();
	}

	private void SetupPathDeleteButton_Click(object sender, EventArgs e)
	{
		int selectedIndex = gameSetupPathsListBox.SelectedIndex;
		gameSetupPathsListBox.Items.RemoveAt(selectedIndex);
		Settings.DeleteGameSetupByIndex(selectedIndex);

		setupViewButton.Enabled = false;
		setupPathDeleteButton.Enabled = false;
	}

	private void AllPathsClearButton_Click(object sender, EventArgs e)
	{
		gameSetupPathsListBox.Items.Clear();
		Settings.ClearAllSettings();
        currentBrowser.UpdateModificationsTreeView();
	}

	private void FormOkButton_Click(object sender, EventArgs e)
	{
		UpdateCallingFormState();
		Close();
	}

	private void UpdateCallingFormState()
	{
        currentBrowser.UpdateModificationsTreeView();
        currentBrowser.Visible = true;
        currentBrowser.Enabled = true;
	}

	private void SetupViewButton_Click(object sender, EventArgs e)
	{
		int selectedGameSetupIndex = gameSetupPathsListBox.SelectedIndex;
		GameSetupInfo editableGameSetup = Settings.GameInstallations[selectedGameSetupIndex];
		var gameSetupConfigForm = new AddNewGameSetupForm(this, editableGameSetup);
		Enabled = false;
		gameSetupConfigForm.Show();
	}

	private void GameSetupPathsListBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		setupViewButton.Enabled = true;
		setupPathDeleteButton.Enabled = true;
	}

	private void GameSetupPathsListBox_Click(object sender, EventArgs e)
	{
		if (gameSetupPathsListBox.SelectedItems.Count > 0)
		{
			setupViewButton.Enabled = true;
			setupPathDeleteButton.Enabled = true;
		}
	}
}
