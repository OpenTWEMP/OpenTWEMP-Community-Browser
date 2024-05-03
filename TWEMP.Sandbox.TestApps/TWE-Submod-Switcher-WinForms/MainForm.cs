namespace TWE_Submod_Switcher_WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeControlsByDefault();
        }

        private void InitializeControlsByDefault()
        {
            const string campaignByDefault = "CAMPAIGN_TYPE_0";
            const string localizationByDefault = "LOCALIZATION_TYPE_0";

            gameCampaignComboBox.SelectedItem = campaignByDefault;
            gameLocalizationComboBox.SelectedItem = localizationByDefault;

            gameCampaignLabel.Text = campaignByDefault;
            gameCampaignLabel.Text = localizationByDefault;
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
            gameCampaignLabel.Text = gameCampaignComboBox.SelectedItem.ToString();
        }

        private void gameLocalizationComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            gameLocalizationLabel.Text = gameLocalizationComboBox.SelectedItem.ToString();
        }

        private void gameCampaignComboBox_Click(object sender, EventArgs e)
        {
            gameCampaignComboBox.DroppedDown = true;
        }

        private void gameLocalizationComboBox_Click(object sender, EventArgs e)
        {
            gameLocalizationComboBox.DroppedDown = true;
        }
    }
}
