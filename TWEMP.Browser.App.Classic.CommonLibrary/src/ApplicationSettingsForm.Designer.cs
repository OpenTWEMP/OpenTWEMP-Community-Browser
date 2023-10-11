namespace TWEMP.Browser.App.Classic.CommonLibrary
{
    partial class AppSettingsForm
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
            saveAppSettingsButton = new Button();
            appLocalizationGroupBox = new GroupBox();
            enableEngLocaleRadioButton = new RadioButton();
            enableRusLocaleRadioButton = new RadioButton();
            appColorThemeGroupBox = new GroupBox();
            uiStyleByDarkThemeRadioButton = new RadioButton();
            uiStyleByLightThemeRadioButton = new RadioButton();
            uiStyleByDefaultThemeRadioButton = new RadioButton();
            exitAppSettingsButton = new Button();
            appFeaturesGroupBox = new GroupBox();
            activatePresetsCheckBox = new CheckBox();
            appLocalizationGroupBox.SuspendLayout();
            appColorThemeGroupBox.SuspendLayout();
            appFeaturesGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // saveAppSettingsButton
            // 
            saveAppSettingsButton.Location = new Point(12, 197);
            saveAppSettingsButton.Name = "saveAppSettingsButton";
            saveAppSettingsButton.Size = new Size(560, 23);
            saveAppSettingsButton.TabIndex = 0;
            saveAppSettingsButton.Text = "OK";
            saveAppSettingsButton.UseVisualStyleBackColor = true;
            saveAppSettingsButton.Click += SaveAppSettingsButton_Click;
            // 
            // appLocalizationGroupBox
            // 
            appLocalizationGroupBox.BackColor = Color.Transparent;
            appLocalizationGroupBox.Controls.Add(enableEngLocaleRadioButton);
            appLocalizationGroupBox.Controls.Add(enableRusLocaleRadioButton);
            appLocalizationGroupBox.Location = new Point(297, 12);
            appLocalizationGroupBox.Name = "appLocalizationGroupBox";
            appLocalizationGroupBox.Size = new Size(275, 101);
            appLocalizationGroupBox.TabIndex = 16;
            appLocalizationGroupBox.TabStop = false;
            appLocalizationGroupBox.Text = "Select GUI language";
            // 
            // enableEngLocaleRadioButton
            // 
            enableEngLocaleRadioButton.AutoSize = true;
            enableEngLocaleRadioButton.Checked = true;
            enableEngLocaleRadioButton.Location = new Point(6, 22);
            enableEngLocaleRadioButton.Name = "enableEngLocaleRadioButton";
            enableEngLocaleRadioButton.Size = new Size(136, 19);
            enableEngLocaleRadioButton.TabIndex = 1;
            enableEngLocaleRadioButton.TabStop = true;
            enableEngLocaleRadioButton.Text = "ENGLISH (by default)";
            enableEngLocaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // enableRusLocaleRadioButton
            // 
            enableRusLocaleRadioButton.AutoSize = true;
            enableRusLocaleRadioButton.Location = new Point(6, 47);
            enableRusLocaleRadioButton.Name = "enableRusLocaleRadioButton";
            enableRusLocaleRadioButton.Size = new Size(141, 19);
            enableRusLocaleRadioButton.TabIndex = 0;
            enableRusLocaleRadioButton.Text = "RUSSIAN (in progress)";
            enableRusLocaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // appColorThemeGroupBox
            // 
            appColorThemeGroupBox.BackColor = Color.Transparent;
            appColorThemeGroupBox.Controls.Add(uiStyleByDarkThemeRadioButton);
            appColorThemeGroupBox.Controls.Add(uiStyleByLightThemeRadioButton);
            appColorThemeGroupBox.Controls.Add(uiStyleByDefaultThemeRadioButton);
            appColorThemeGroupBox.Location = new Point(12, 12);
            appColorThemeGroupBox.Name = "appColorThemeGroupBox";
            appColorThemeGroupBox.Size = new Size(279, 101);
            appColorThemeGroupBox.TabIndex = 15;
            appColorThemeGroupBox.TabStop = false;
            appColorThemeGroupBox.Text = "Select GUI style theme";
            // 
            // uiStyleByDarkThemeRadioButton
            // 
            uiStyleByDarkThemeRadioButton.AutoSize = true;
            uiStyleByDarkThemeRadioButton.Location = new Point(6, 72);
            uiStyleByDarkThemeRadioButton.Name = "uiStyleByDarkThemeRadioButton";
            uiStyleByDarkThemeRadioButton.Size = new Size(88, 19);
            uiStyleByDarkThemeRadioButton.TabIndex = 2;
            uiStyleByDarkThemeRadioButton.Text = "Dark Theme";
            uiStyleByDarkThemeRadioButton.UseVisualStyleBackColor = true;
            uiStyleByDarkThemeRadioButton.Click += UiStyleByDarkThemeRadioButton_Click;
            // 
            // uiStyleByLightThemeRadioButton
            // 
            uiStyleByLightThemeRadioButton.AutoSize = true;
            uiStyleByLightThemeRadioButton.Location = new Point(6, 47);
            uiStyleByLightThemeRadioButton.Name = "uiStyleByLightThemeRadioButton";
            uiStyleByLightThemeRadioButton.Size = new Size(91, 19);
            uiStyleByLightThemeRadioButton.TabIndex = 1;
            uiStyleByLightThemeRadioButton.Text = "Light Theme";
            uiStyleByLightThemeRadioButton.UseVisualStyleBackColor = true;
            uiStyleByLightThemeRadioButton.Click += UiStyleByLightThemeRadioButton_Click;
            // 
            // uiStyleByDefaultThemeRadioButton
            // 
            uiStyleByDefaultThemeRadioButton.AutoSize = true;
            uiStyleByDefaultThemeRadioButton.Checked = true;
            uiStyleByDefaultThemeRadioButton.Location = new Point(6, 22);
            uiStyleByDefaultThemeRadioButton.Name = "uiStyleByDefaultThemeRadioButton";
            uiStyleByDefaultThemeRadioButton.Size = new Size(175, 19);
            uiStyleByDefaultThemeRadioButton.TabIndex = 0;
            uiStyleByDefaultThemeRadioButton.TabStop = true;
            uiStyleByDefaultThemeRadioButton.Text = "Standard Theme (by default)";
            uiStyleByDefaultThemeRadioButton.UseVisualStyleBackColor = true;
            uiStyleByDefaultThemeRadioButton.Click += UiStyleByDefaultThemeRadioButton_Click;
            // 
            // exitAppSettingsButton
            // 
            exitAppSettingsButton.Location = new Point(12, 226);
            exitAppSettingsButton.Name = "exitAppSettingsButton";
            exitAppSettingsButton.Size = new Size(560, 23);
            exitAppSettingsButton.TabIndex = 2;
            exitAppSettingsButton.Text = "CANCEL";
            exitAppSettingsButton.UseVisualStyleBackColor = true;
            exitAppSettingsButton.Click += ExitAppSettingsButton_Click;
            // 
            // appFeaturesGroupBox
            // 
            appFeaturesGroupBox.Controls.Add(activatePresetsCheckBox);
            appFeaturesGroupBox.Location = new Point(12, 119);
            appFeaturesGroupBox.Name = "appFeaturesGroupBox";
            appFeaturesGroupBox.Size = new Size(560, 72);
            appFeaturesGroupBox.TabIndex = 17;
            appFeaturesGroupBox.TabStop = false;
            appFeaturesGroupBox.Text = "Experimental Settings";
            // 
            // activatePresetsCheckBox
            // 
            activatePresetsCheckBox.AutoSize = true;
            activatePresetsCheckBox.Checked = true;
            activatePresetsCheckBox.CheckState = CheckState.Checked;
            activatePresetsCheckBox.Location = new Point(6, 31);
            activatePresetsCheckBox.Name = "activatePresetsCheckBox";
            activatePresetsCheckBox.Size = new Size(250, 19);
            activatePresetsCheckBox.TabIndex = 0;
            activatePresetsCheckBox.Text = "Use Custom Presets to Initialize Your Mods";
            activatePresetsCheckBox.UseVisualStyleBackColor = true;
            // 
            // AppSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 261);
            Controls.Add(appFeaturesGroupBox);
            Controls.Add(appLocalizationGroupBox);
            Controls.Add(exitAppSettingsButton);
            Controls.Add(appColorThemeGroupBox);
            Controls.Add(saveAppSettingsButton);
            MaximizeBox = false;
            MaximumSize = new Size(600, 300);
            MinimizeBox = false;
            MinimumSize = new Size(600, 300);
            Name = "AppSettingsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Application Settings";
            appLocalizationGroupBox.ResumeLayout(false);
            appLocalizationGroupBox.PerformLayout();
            appColorThemeGroupBox.ResumeLayout(false);
            appColorThemeGroupBox.PerformLayout();
            appFeaturesGroupBox.ResumeLayout(false);
            appFeaturesGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button saveAppSettingsButton;
        private Button exitAppSettingsButton;
        private GroupBox appColorThemeGroupBox;
        private RadioButton uiStyleByDarkThemeRadioButton;
        private RadioButton uiStyleByLightThemeRadioButton;
        private RadioButton uiStyleByDefaultThemeRadioButton;
        private GroupBox appLocalizationGroupBox;
        private RadioButton enableEngLocaleRadioButton;
        private RadioButton enableRusLocaleRadioButton;
        private GroupBox appFeaturesGroupBox;
        private CheckBox activatePresetsCheckBox;
    }
}
