namespace TWE_Submod_Switcher_WinForms
{
    public partial class CampaignConfigForm : Form
    {
        private readonly string currentGameCampaign;
        private readonly string currentGameLocalization;

        public CampaignConfigForm(string campaign, string localization)
        {
            InitializeComponent();

            currentGameCampaign = campaign;
            currentGameLocalization = localization;

            string campaignDescription = $"{currentGameCampaign} [ {currentGameLocalization} ]";
            this.Text = $"Campaign Configurator: {campaignDescription}";
            campaignDescriptionLabel.Text = campaignDescription;
        }

        private void formApplyButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                text: "Your Campaign is Ready to Game!",
                caption: "Applying Changes ...",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Asterisk);

            Close();
        }

        private void formCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
