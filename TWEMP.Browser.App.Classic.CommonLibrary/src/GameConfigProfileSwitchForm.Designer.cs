namespace TWEMP.Browser.App.Classic.CommonLibrary
{
    partial class GameConfigProfileSwitchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxConfigProfiles = new GroupBox();
            currentProfileComboBox = new ComboBox();
            currentProfileNameLabel = new Label();
            formCloseButton = new Button();
            groupBoxConfigProfiles.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxConfigProfiles
            // 
            groupBoxConfigProfiles.BackColor = Color.Transparent;
            groupBoxConfigProfiles.Controls.Add(currentProfileComboBox);
            groupBoxConfigProfiles.Controls.Add(currentProfileNameLabel);
            groupBoxConfigProfiles.Location = new Point(12, 12);
            groupBoxConfigProfiles.Name = "groupBoxConfigProfiles";
            groupBoxConfigProfiles.Size = new Size(283, 93);
            groupBoxConfigProfiles.TabIndex = 8;
            groupBoxConfigProfiles.TabStop = false;
            groupBoxConfigProfiles.Text = "Select the Current Game Config Profile";
            // 
            // currentProfileComboBox
            // 
            currentProfileComboBox.FormattingEnabled = true;
            currentProfileComboBox.Items.AddRange(new object[] { "CONFIG_PROFILE_0", "CONFIG_PROFILE_1", "CONFIG_PROFILE_2", "CONFIG_PROFILE_3", "CONFIG_PROFILE_4", "CONFIG_PROFILE_5", "CONFIG_PROFILE_6", "CONFIG_PROFILE_7", "CONFIG_PROFILE_8", "CONFIG_PROFILE_9" });
            currentProfileComboBox.Location = new Point(6, 57);
            currentProfileComboBox.Name = "currentProfileComboBox";
            currentProfileComboBox.Size = new Size(271, 23);
            currentProfileComboBox.TabIndex = 1;
            currentProfileComboBox.SelectedValueChanged += CurrentProfileComboBox_SelectedValueChanged;
            // 
            // currentProfileNameLabel
            // 
            currentProfileNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            currentProfileNameLabel.Location = new Point(6, 19);
            currentProfileNameLabel.Name = "currentProfileNameLabel";
            currentProfileNameLabel.Size = new Size(271, 35);
            currentProfileNameLabel.TabIndex = 0;
            currentProfileNameLabel.Text = "CURRENT GAME CONFIG PROFILE";
            currentProfileNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // formCloseButton
            // 
            formCloseButton.Location = new Point(12, 111);
            formCloseButton.Name = "formCloseButton";
            formCloseButton.Size = new Size(283, 23);
            formCloseButton.TabIndex = 9;
            formCloseButton.Text = "CLOSE";
            formCloseButton.UseVisualStyleBackColor = true;
            formCloseButton.Click += FormCloseButton_Click;
            // 
            // GameConfigProfileSwitchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 145);
            Controls.Add(formCloseButton);
            Controls.Add(groupBoxConfigProfiles);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "GameConfigProfileSwitchForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameConfigProfileSwitchForm";
            groupBoxConfigProfiles.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxConfigProfiles;
        private ComboBox currentProfileComboBox;
        private Label currentProfileNameLabel;
        private Button formCloseButton;
    }
}