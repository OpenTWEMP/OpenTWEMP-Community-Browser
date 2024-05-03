namespace TWE_Submod_Switcher_WinForms
{
    public partial class MainForm : Form
    {
        private const string gameCampaignByDefault = "CAMPAIGN_TYPE_0";
        private const string gameLocalizationByDefault = "LOCALIZATION_TYPE_0";

        private string currentGameCampaign;
        private string currentGameLocalization;

        public MainForm()
        {
            InitializeComponent();
            InitializeControlsByDefault();

            currentGameCampaign = gameCampaignByDefault;
            currentGameLocalization = gameLocalizationByDefault;
        }

        private void InitializeControlsByDefault()
        {
            gameCampaignComboBox.SelectedItem = gameCampaignByDefault;
            gameLocalizationComboBox.SelectedItem = gameLocalizationByDefault;

            gameCampaignLabel.Text = gameCampaignByDefault;
            gameLocalizationLabel.Text = gameLocalizationByDefault;
        }

        private void gameLaunchButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                text: $"{gameCampaignLabel.Text}\n{gameLocalizationLabel.Text}",
                caption: "Launching the Game ...",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Information);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gameCampaignComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            currentGameCampaign = gameCampaignComboBox.SelectedItem.ToString()!;
            gameCampaignLabel.Text = currentGameCampaign;
        }

        private void gameLocalizationComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            currentGameLocalization = gameLocalizationComboBox.SelectedItem.ToString()!;
            gameLocalizationLabel.Text = currentGameLocalization;
        }

        private void gameCampaignComboBox_Click(object sender, EventArgs e)
        {
            gameCampaignComboBox.DroppedDown = true;
        }

        private void gameLocalizationComboBox_Click(object sender, EventArgs e)
        {
            gameLocalizationComboBox.DroppedDown = true;
        }

        private void gameCampaignLabel_Click(object sender, EventArgs e)
        {
            var form = new CampaignConfigForm(currentGameCampaign, currentGameLocalization);
            form.Show();
        }

        private void gameCampaignLabel_MouseEnter(object sender, EventArgs e)
        {
            gameCampaignLabel.Text = $"Click to configure the campaign:\n{currentGameCampaign}";
            gameCampaignLabel.BackColor = Color.Yellow;
        }

        private void gameCampaignLabel_MouseLeave(object sender, EventArgs e)
        {
            gameCampaignLabel.Text = currentGameCampaign;
            gameCampaignLabel.BackColor = Color.Honeydew;
        }
    }
}
