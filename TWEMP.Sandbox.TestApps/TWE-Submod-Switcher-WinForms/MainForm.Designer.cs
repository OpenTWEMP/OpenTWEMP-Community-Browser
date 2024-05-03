namespace TWE_Submod_Switcher_WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gameLaunchButton = new Button();
            gameCampaignComboBox = new ComboBox();
            gameLocalizationComboBox = new ComboBox();
            gameCampaignLabel = new Label();
            gameLocalizationLabel = new Label();
            exitButton = new Button();
            SuspendLayout();
            // 
            // gameLaunchButton
            // 
            gameLaunchButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            gameLaunchButton.Location = new Point(12, 358);
            gameLaunchButton.Name = "gameLaunchButton";
            gameLaunchButton.Size = new Size(506, 51);
            gameLaunchButton.TabIndex = 0;
            gameLaunchButton.Text = "LAUNCH";
            gameLaunchButton.UseVisualStyleBackColor = true;
            gameLaunchButton.Click += gameLaunchButton_Click;
            // 
            // gameCampaignComboBox
            // 
            gameCampaignComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gameCampaignComboBox.FormattingEnabled = true;
            gameCampaignComboBox.Items.AddRange(new object[] { "CAMPAIGN_TYPE_0", "CAMPAIGN_TYPE_1", "CAMPAIGN_TYPE_2", "CAMPAIGN_TYPE_3", "CAMPAIGN_TYPE_4", "CAMPAIGN_TYPE_5", "CAMPAIGN_TYPE_6", "CAMPAIGN_TYPE_7", "CAMPAIGN_TYPE_8", "CAMPAIGN_TYPE_9" });
            gameCampaignComboBox.Location = new Point(12, 12);
            gameCampaignComboBox.Name = "gameCampaignComboBox";
            gameCampaignComboBox.Size = new Size(250, 23);
            gameCampaignComboBox.TabIndex = 1;
            gameCampaignComboBox.SelectedValueChanged += gameCampaignComboBox_SelectedValueChanged;
            gameCampaignComboBox.Click += gameCampaignComboBox_Click;
            // 
            // gameLocalizationComboBox
            // 
            gameLocalizationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gameLocalizationComboBox.FormattingEnabled = true;
            gameLocalizationComboBox.Items.AddRange(new object[] { "LOCALIZATION_TYPE_0", "LOCALIZATION_TYPE_1", "LOCALIZATION_TYPE_2", "LOCALIZATION_TYPE_3", "LOCALIZATION_TYPE_4", "LOCALIZATION_TYPE_5", "LOCALIZATION_TYPE_6", "LOCALIZATION_TYPE_7", "LOCALIZATION_TYPE_8", "LOCALIZATION_TYPE_9" });
            gameLocalizationComboBox.Location = new Point(268, 12);
            gameLocalizationComboBox.Name = "gameLocalizationComboBox";
            gameLocalizationComboBox.Size = new Size(250, 23);
            gameLocalizationComboBox.TabIndex = 2;
            gameLocalizationComboBox.SelectedValueChanged += gameLocalizationComboBox_SelectedValueChanged;
            gameLocalizationComboBox.Click += gameLocalizationComboBox_Click;
            // 
            // gameCampaignLabel
            // 
            gameCampaignLabel.BorderStyle = BorderStyle.FixedSingle;
            gameCampaignLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            gameCampaignLabel.Location = new Point(12, 55);
            gameCampaignLabel.Name = "gameCampaignLabel";
            gameCampaignLabel.Size = new Size(506, 121);
            gameCampaignLabel.TabIndex = 3;
            gameCampaignLabel.Text = "CAMPAIGN";
            gameCampaignLabel.TextAlign = ContentAlignment.MiddleCenter;
            gameCampaignLabel.Click += gameCampaignLabel_Click;
            gameCampaignLabel.MouseEnter += gameCampaignLabel_MouseEnter;
            gameCampaignLabel.MouseLeave += gameCampaignLabel_MouseLeave;
            // 
            // gameLocalizationLabel
            // 
            gameLocalizationLabel.BorderStyle = BorderStyle.FixedSingle;
            gameLocalizationLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            gameLocalizationLabel.Location = new Point(12, 191);
            gameLocalizationLabel.Name = "gameLocalizationLabel";
            gameLocalizationLabel.Size = new Size(506, 56);
            gameLocalizationLabel.TabIndex = 4;
            gameLocalizationLabel.Text = "LOCALIZATION";
            gameLocalizationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(12, 415);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(506, 23);
            exitButton.TabIndex = 6;
            exitButton.Text = "EXIT";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(531, 450);
            Controls.Add(exitButton);
            Controls.Add(gameLocalizationLabel);
            Controls.Add(gameCampaignLabel);
            Controls.Add(gameLocalizationComboBox);
            Controls.Add(gameCampaignComboBox);
            Controls.Add(gameLaunchButton);
            MaximizeBox = false;
            MaximumSize = new Size(547, 489);
            MinimumSize = new Size(547, 489);
            Name = "MainForm";
            Text = "TWE-Submod-Switcher-WinForms";
            ResumeLayout(false);
        }

        #endregion

        private Button gameLaunchButton;
        private ComboBox gameCampaignComboBox;
        private ComboBox gameLocalizationComboBox;
        private Label gameCampaignLabel;
        private Label gameLocalizationLabel;
        private Button exitButton;
    }
}
