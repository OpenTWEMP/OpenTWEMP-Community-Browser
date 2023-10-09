namespace TWEMP.Browser.App.Classic.CommonLibrary;

public partial class ModConfigSettingsForm : Form
{
	public ModConfigSettingsForm()
	{
		InitializeComponent();
	}

	private void SaveConfigSettingsButton_Click(object sender, EventArgs e)
	{
		MessageBox.Show("SAVE CONFIG SETTINGS");
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
		MessageBox.Show("EXPORT CONFIG SETTINGS");
	}

	private void ImportConfigSettingsButton_Click(object sender, EventArgs e)
	{
		MessageBox.Show("IMPORT CONFIG SETTINGS");
	}
}
