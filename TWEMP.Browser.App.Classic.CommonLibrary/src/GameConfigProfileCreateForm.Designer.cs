namespace TWEMP.Browser.App.Classic.CommonLibrary
{
    partial class GameConfigProfileCreateForm
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
            cfgNewProfileNameLabel = new Label();
            cfgNewProfileNameTextBox = new TextBox();
            cfgNewProfileTypeLabel = new Label();
            cfgNewProfileTypeComboBox = new ComboBox();
            cfgNewProfileTemplateCheckBox = new CheckBox();
            cfgNewProfileTemplateComboBox = new ComboBox();
            formOkButton = new Button();
            formCancelButton = new Button();
            SuspendLayout();
            // 
            // cfgNewProfileNameLabel
            // 
            cfgNewProfileNameLabel.Location = new Point(12, 16);
            cfgNewProfileNameLabel.Name = "cfgNewProfileNameLabel";
            cfgNewProfileNameLabel.Size = new Size(219, 27);
            cfgNewProfileNameLabel.TabIndex = 0;
            cfgNewProfileNameLabel.Text = "Enter the Name for a New Config Profile";
            // 
            // cfgNewProfileNameTextBox
            // 
            cfgNewProfileNameTextBox.Location = new Point(237, 16);
            cfgNewProfileNameTextBox.Name = "cfgNewProfileNameTextBox";
            cfgNewProfileNameTextBox.Size = new Size(372, 23);
            cfgNewProfileNameTextBox.TabIndex = 1;
            cfgNewProfileNameTextBox.Text = "NEW_GAME_CONFIG_PROFILE";
            // 
            // cfgNewProfileTypeLabel
            // 
            cfgNewProfileTypeLabel.Location = new Point(12, 60);
            cfgNewProfileTypeLabel.Name = "cfgNewProfileTypeLabel";
            cfgNewProfileTypeLabel.Size = new Size(219, 27);
            cfgNewProfileTypeLabel.TabIndex = 2;
            cfgNewProfileTypeLabel.Text = "Select the Type of a New Config Profile";
            // 
            // cfgNewProfileTypeComboBox
            // 
            cfgNewProfileTypeComboBox.Enabled = false;
            cfgNewProfileTypeComboBox.FormattingEnabled = true;
            cfgNewProfileTypeComboBox.Items.AddRange(new object[] { "TWEMP", "M2TW", "RTW" });
            cfgNewProfileTypeComboBox.Location = new Point(237, 60);
            cfgNewProfileTypeComboBox.Name = "cfgNewProfileTypeComboBox";
            cfgNewProfileTypeComboBox.Size = new Size(372, 23);
            cfgNewProfileTypeComboBox.TabIndex = 3;
            cfgNewProfileTypeComboBox.Text = "M2TW";
            // 
            // cfgNewProfileTemplateCheckBox
            // 
            cfgNewProfileTemplateCheckBox.AutoSize = true;
            cfgNewProfileTemplateCheckBox.Location = new Point(12, 100);
            cfgNewProfileTemplateCheckBox.Name = "cfgNewProfileTemplateCheckBox";
            cfgNewProfileTemplateCheckBox.Size = new Size(216, 19);
            cfgNewProfileTemplateCheckBox.TabIndex = 4;
            cfgNewProfileTemplateCheckBox.Text = "Use an Existing Profile as a Template";
            cfgNewProfileTemplateCheckBox.UseVisualStyleBackColor = true;
            cfgNewProfileTemplateCheckBox.CheckedChanged += CfgNewProfileTemplateCheckBox_CheckedChanged;
            // 
            // cfgNewProfileTemplateComboBox
            // 
            cfgNewProfileTemplateComboBox.Enabled = false;
            cfgNewProfileTemplateComboBox.FormattingEnabled = true;
            cfgNewProfileTemplateComboBox.Items.AddRange(new object[] { "profile_0", "profile_1", "profile_2", "profile_3", "profile_4", "profile_5", "profile_6", "profile_7", "profile_8", "profile_9" });
            cfgNewProfileTemplateComboBox.Location = new Point(237, 100);
            cfgNewProfileTemplateComboBox.Name = "cfgNewProfileTemplateComboBox";
            cfgNewProfileTemplateComboBox.Size = new Size(372, 23);
            cfgNewProfileTemplateComboBox.TabIndex = 5;
            // 
            // formOkButton
            // 
            formOkButton.Location = new Point(12, 153);
            formOkButton.Name = "formOkButton";
            formOkButton.Size = new Size(600, 23);
            formOkButton.TabIndex = 6;
            formOkButton.Text = "OK";
            formOkButton.UseVisualStyleBackColor = true;
            formOkButton.Click += FormOkButton_Click;
            // 
            // formCancelButton
            // 
            formCancelButton.Location = new Point(12, 182);
            formCancelButton.Name = "formCancelButton";
            formCancelButton.Size = new Size(600, 23);
            formCancelButton.TabIndex = 7;
            formCancelButton.Text = "CANCEL";
            formCancelButton.UseVisualStyleBackColor = true;
            formCancelButton.Click += FormCancelButton_Click;
            // 
            // GameConfigProfileCreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 217);
            Controls.Add(formCancelButton);
            Controls.Add(formOkButton);
            Controls.Add(cfgNewProfileTemplateComboBox);
            Controls.Add(cfgNewProfileTemplateCheckBox);
            Controls.Add(cfgNewProfileTypeComboBox);
            Controls.Add(cfgNewProfileTypeLabel);
            Controls.Add(cfgNewProfileNameTextBox);
            Controls.Add(cfgNewProfileNameLabel);
            MaximizeBox = false;
            MaximumSize = new Size(640, 256);
            MinimizeBox = false;
            MinimumSize = new Size(640, 256);
            Name = "GameConfigProfileCreateForm";
            ShowIcon = false;
            Text = "Create a Game Config Profile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cfgNewProfileNameLabel;
        private TextBox cfgNewProfileNameTextBox;
        private Label cfgNewProfileTypeLabel;
        private ComboBox cfgNewProfileTypeComboBox;
        private CheckBox cfgNewProfileTemplateCheckBox;
        private ComboBox cfgNewProfileTemplateComboBox;
        private Button formOkButton;
        private Button formCancelButton;
    }
}