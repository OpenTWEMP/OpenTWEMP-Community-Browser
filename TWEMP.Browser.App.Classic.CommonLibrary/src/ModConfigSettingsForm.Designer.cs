namespace TWEMP.Browser.App.Classic.CommonLibrary
{
	partial class ModConfigSettingsForm
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
            saveConfigSettingsButton = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label1 = new Label();
            tabPage2 = new TabPage();
            cfgAudioSpeechVolumePanel = new Panel();
            cfgAudioSpeechNumericUpDown = new NumericUpDown();
            cfgAudioSpeechVolumeLabel = new Label();
            cfgAudioSfxVolumePanel = new Panel();
            cfgAudioSfxNumericUpDown = new NumericUpDown();
            cfgAudioSfxVolumeLabel = new Label();
            cfgAudioSoundCardProviderPanel = new Panel();
            cfgAudioSoundCardProviderNumericUpDown = new NumericUpDown();
            cfgAudioSoundCardProviderLabel = new Label();
            cfgAudioMusicVolumePanel = new Panel();
            cfgAudioMusicVolumeNumericUpDown = new NumericUpDown();
            cfgAudioMusicVolumeLabel = new Label();
            cfgAudioMasterVolumePanel = new Panel();
            cfgAudioMasterVolumeNumericUpDown = new NumericUpDown();
            cfgAudioMasterVolumeLabel = new Label();
            cfgAudioOptionsPanel = new Panel();
            cfgAudioSpeechEnableCheckBox = new CheckBox();
            cfgAudioEnableCheckBox = new CheckBox();
            cfgAudioSubFactionAccentsEnableCheckBox = new CheckBox();
            label2 = new Label();
            tabPage3 = new TabPage();
            label3 = new Label();
            tabPage4 = new TabPage();
            label4 = new Label();
            tabPage5 = new TabPage();
            label5 = new Label();
            tabPage6 = new TabPage();
            label6 = new Label();
            resetConfigSettingsButton = new Button();
            importConfigSettingsButton = new Button();
            exportConfigSettingsButton = new Button();
            settingDescriptionLabel = new Label();
            exitConfigSettingsButton = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            cfgAudioSpeechVolumePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cfgAudioSpeechNumericUpDown).BeginInit();
            cfgAudioSfxVolumePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cfgAudioSfxNumericUpDown).BeginInit();
            cfgAudioSoundCardProviderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cfgAudioSoundCardProviderNumericUpDown).BeginInit();
            cfgAudioMusicVolumePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cfgAudioMusicVolumeNumericUpDown).BeginInit();
            cfgAudioMasterVolumePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cfgAudioMasterVolumeNumericUpDown).BeginInit();
            cfgAudioOptionsPanel.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            SuspendLayout();
            // 
            // saveConfigSettingsButton
            // 
            saveConfigSettingsButton.Location = new Point(16, 498);
            saveConfigSettingsButton.Name = "saveConfigSettingsButton";
            saveConfigSettingsButton.Size = new Size(276, 51);
            saveConfigSettingsButton.TabIndex = 0;
            saveConfigSettingsButton.Text = "SAVE CONFIG SETTINGS";
            saveConfigSettingsButton.UseVisualStyleBackColor = true;
            saveConfigSettingsButton.Click += SaveConfigSettingsButton_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(760, 428);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(752, 400);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Game Play Settings";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 14);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 0;
            label1.Text = "GAME PLAY SETTINGS";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cfgAudioSpeechVolumePanel);
            tabPage2.Controls.Add(cfgAudioSfxVolumePanel);
            tabPage2.Controls.Add(cfgAudioSoundCardProviderPanel);
            tabPage2.Controls.Add(cfgAudioMusicVolumePanel);
            tabPage2.Controls.Add(cfgAudioMasterVolumePanel);
            tabPage2.Controls.Add(cfgAudioOptionsPanel);
            tabPage2.Controls.Add(label2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(752, 400);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Video & Audio";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // cfgAudioSpeechVolumePanel
            // 
            cfgAudioSpeechVolumePanel.BackColor = Color.Gray;
            cfgAudioSpeechVolumePanel.Controls.Add(cfgAudioSpeechNumericUpDown);
            cfgAudioSpeechVolumePanel.Controls.Add(cfgAudioSpeechVolumeLabel);
            cfgAudioSpeechVolumePanel.Location = new Point(311, 191);
            cfgAudioSpeechVolumePanel.Name = "cfgAudioSpeechVolumePanel";
            cfgAudioSpeechVolumePanel.Size = new Size(325, 30);
            cfgAudioSpeechVolumePanel.TabIndex = 23;
            // 
            // cfgAudioSpeechNumericUpDown
            // 
            cfgAudioSpeechNumericUpDown.Location = new Point(202, 3);
            cfgAudioSpeechNumericUpDown.Name = "cfgAudioSpeechNumericUpDown";
            cfgAudioSpeechNumericUpDown.Size = new Size(120, 23);
            cfgAudioSpeechNumericUpDown.TabIndex = 9;
            // 
            // cfgAudioSpeechVolumeLabel
            // 
            cfgAudioSpeechVolumeLabel.Location = new Point(3, 3);
            cfgAudioSpeechVolumeLabel.Name = "cfgAudioSpeechVolumeLabel";
            cfgAudioSpeechVolumeLabel.Size = new Size(193, 23);
            cfgAudioSpeechVolumeLabel.TabIndex = 4;
            cfgAudioSpeechVolumeLabel.Text = "speech_vol";
            // 
            // cfgAudioSfxVolumePanel
            // 
            cfgAudioSfxVolumePanel.BackColor = Color.Gray;
            cfgAudioSfxVolumePanel.Controls.Add(cfgAudioSfxNumericUpDown);
            cfgAudioSfxVolumePanel.Controls.Add(cfgAudioSfxVolumeLabel);
            cfgAudioSfxVolumePanel.Location = new Point(311, 154);
            cfgAudioSfxVolumePanel.Name = "cfgAudioSfxVolumePanel";
            cfgAudioSfxVolumePanel.Size = new Size(325, 30);
            cfgAudioSfxVolumePanel.TabIndex = 24;
            // 
            // cfgAudioSfxNumericUpDown
            // 
            cfgAudioSfxNumericUpDown.Location = new Point(202, 3);
            cfgAudioSfxNumericUpDown.Name = "cfgAudioSfxNumericUpDown";
            cfgAudioSfxNumericUpDown.Size = new Size(120, 23);
            cfgAudioSfxNumericUpDown.TabIndex = 9;
            // 
            // cfgAudioSfxVolumeLabel
            // 
            cfgAudioSfxVolumeLabel.Location = new Point(3, 3);
            cfgAudioSfxVolumeLabel.Name = "cfgAudioSfxVolumeLabel";
            cfgAudioSfxVolumeLabel.Size = new Size(193, 23);
            cfgAudioSfxVolumeLabel.TabIndex = 4;
            cfgAudioSfxVolumeLabel.Text = "sfx_vol";
            // 
            // cfgAudioSoundCardProviderPanel
            // 
            cfgAudioSoundCardProviderPanel.BackColor = Color.Gray;
            cfgAudioSoundCardProviderPanel.Controls.Add(cfgAudioSoundCardProviderNumericUpDown);
            cfgAudioSoundCardProviderPanel.Controls.Add(cfgAudioSoundCardProviderLabel);
            cfgAudioSoundCardProviderPanel.Location = new Point(311, 118);
            cfgAudioSoundCardProviderPanel.Name = "cfgAudioSoundCardProviderPanel";
            cfgAudioSoundCardProviderPanel.Size = new Size(325, 30);
            cfgAudioSoundCardProviderPanel.TabIndex = 25;
            // 
            // cfgAudioSoundCardProviderNumericUpDown
            // 
            cfgAudioSoundCardProviderNumericUpDown.Location = new Point(202, 3);
            cfgAudioSoundCardProviderNumericUpDown.Name = "cfgAudioSoundCardProviderNumericUpDown";
            cfgAudioSoundCardProviderNumericUpDown.Size = new Size(120, 23);
            cfgAudioSoundCardProviderNumericUpDown.TabIndex = 9;
            // 
            // cfgAudioSoundCardProviderLabel
            // 
            cfgAudioSoundCardProviderLabel.Location = new Point(3, 3);
            cfgAudioSoundCardProviderLabel.Name = "cfgAudioSoundCardProviderLabel";
            cfgAudioSoundCardProviderLabel.Size = new Size(193, 23);
            cfgAudioSoundCardProviderLabel.TabIndex = 4;
            cfgAudioSoundCardProviderLabel.Text = "provider";
            // 
            // cfgAudioMusicVolumePanel
            // 
            cfgAudioMusicVolumePanel.BackColor = Color.Gray;
            cfgAudioMusicVolumePanel.Controls.Add(cfgAudioMusicVolumeNumericUpDown);
            cfgAudioMusicVolumePanel.Controls.Add(cfgAudioMusicVolumeLabel);
            cfgAudioMusicVolumePanel.Location = new Point(311, 82);
            cfgAudioMusicVolumePanel.Name = "cfgAudioMusicVolumePanel";
            cfgAudioMusicVolumePanel.Size = new Size(325, 30);
            cfgAudioMusicVolumePanel.TabIndex = 26;
            // 
            // cfgAudioMusicVolumeNumericUpDown
            // 
            cfgAudioMusicVolumeNumericUpDown.Location = new Point(202, 3);
            cfgAudioMusicVolumeNumericUpDown.Name = "cfgAudioMusicVolumeNumericUpDown";
            cfgAudioMusicVolumeNumericUpDown.Size = new Size(120, 23);
            cfgAudioMusicVolumeNumericUpDown.TabIndex = 9;
            // 
            // cfgAudioMusicVolumeLabel
            // 
            cfgAudioMusicVolumeLabel.Location = new Point(3, 3);
            cfgAudioMusicVolumeLabel.Name = "cfgAudioMusicVolumeLabel";
            cfgAudioMusicVolumeLabel.Size = new Size(193, 23);
            cfgAudioMusicVolumeLabel.TabIndex = 4;
            cfgAudioMusicVolumeLabel.Text = "music_vol";
            // 
            // cfgAudioMasterVolumePanel
            // 
            cfgAudioMasterVolumePanel.BackColor = Color.Gray;
            cfgAudioMasterVolumePanel.Controls.Add(cfgAudioMasterVolumeNumericUpDown);
            cfgAudioMasterVolumePanel.Controls.Add(cfgAudioMasterVolumeLabel);
            cfgAudioMasterVolumePanel.Location = new Point(311, 41);
            cfgAudioMasterVolumePanel.Name = "cfgAudioMasterVolumePanel";
            cfgAudioMasterVolumePanel.Size = new Size(325, 30);
            cfgAudioMasterVolumePanel.TabIndex = 22;
            // 
            // cfgAudioMasterVolumeNumericUpDown
            // 
            cfgAudioMasterVolumeNumericUpDown.Location = new Point(202, 3);
            cfgAudioMasterVolumeNumericUpDown.Name = "cfgAudioMasterVolumeNumericUpDown";
            cfgAudioMasterVolumeNumericUpDown.Size = new Size(120, 23);
            cfgAudioMasterVolumeNumericUpDown.TabIndex = 9;
            // 
            // cfgAudioMasterVolumeLabel
            // 
            cfgAudioMasterVolumeLabel.Location = new Point(3, 3);
            cfgAudioMasterVolumeLabel.Name = "cfgAudioMasterVolumeLabel";
            cfgAudioMasterVolumeLabel.Size = new Size(193, 23);
            cfgAudioMasterVolumeLabel.TabIndex = 4;
            cfgAudioMasterVolumeLabel.Text = "master_vol";
            // 
            // cfgAudioOptionsPanel
            // 
            cfgAudioOptionsPanel.BackColor = Color.Gray;
            cfgAudioOptionsPanel.Controls.Add(cfgAudioSpeechEnableCheckBox);
            cfgAudioOptionsPanel.Controls.Add(cfgAudioEnableCheckBox);
            cfgAudioOptionsPanel.Controls.Add(cfgAudioSubFactionAccentsEnableCheckBox);
            cfgAudioOptionsPanel.Location = new Point(20, 53);
            cfgAudioOptionsPanel.Name = "cfgAudioOptionsPanel";
            cfgAudioOptionsPanel.Size = new Size(224, 122);
            cfgAudioOptionsPanel.TabIndex = 21;
            // 
            // cfgAudioSpeechEnableCheckBox
            // 
            cfgAudioSpeechEnableCheckBox.AutoSize = true;
            cfgAudioSpeechEnableCheckBox.Location = new Point(18, 43);
            cfgAudioSpeechEnableCheckBox.Name = "cfgAudioSpeechEnableCheckBox";
            cfgAudioSpeechEnableCheckBox.Size = new Size(103, 19);
            cfgAudioSpeechEnableCheckBox.TabIndex = 2;
            cfgAudioSpeechEnableCheckBox.Text = "speech_enable";
            cfgAudioSpeechEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // cfgAudioEnableCheckBox
            // 
            cfgAudioEnableCheckBox.AutoSize = true;
            cfgAudioEnableCheckBox.Location = new Point(18, 18);
            cfgAudioEnableCheckBox.Name = "cfgAudioEnableCheckBox";
            cfgAudioEnableCheckBox.Size = new Size(61, 19);
            cfgAudioEnableCheckBox.TabIndex = 1;
            cfgAudioEnableCheckBox.Text = "enable";
            cfgAudioEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // cfgAudioSubFactionAccentsEnableCheckBox
            // 
            cfgAudioSubFactionAccentsEnableCheckBox.AutoSize = true;
            cfgAudioSubFactionAccentsEnableCheckBox.Location = new Point(18, 68);
            cfgAudioSubFactionAccentsEnableCheckBox.Name = "cfgAudioSubFactionAccentsEnableCheckBox";
            cfgAudioSubFactionAccentsEnableCheckBox.Size = new Size(132, 19);
            cfgAudioSubFactionAccentsEnableCheckBox.TabIndex = 3;
            cfgAudioSubFactionAccentsEnableCheckBox.Text = "sub_faction_accents";
            cfgAudioSubFactionAccentsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 13);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 0;
            label2.Text = "VIDEO + AUDIO";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(752, 400);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Camera & Controls";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 14);
            label3.Name = "label3";
            label3.Size = new Size(129, 15);
            label3.TabIndex = 0;
            label3.Text = "CAMERA + CONTROLS";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(label4);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(752, 400);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Multiplayer & Hotseat";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 17);
            label4.Name = "label4";
            label4.Size = new Size(142, 15);
            label4.TabIndex = 0;
            label4.Text = "MULTIPLAYER + HOTSEAT";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(label5);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(752, 400);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Game Settings";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 16);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 0;
            label5.Text = "GAME SETTINGS";
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(label6);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(752, 400);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Diagnostics & Logging";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 15);
            label6.Name = "label6";
            label6.Size = new Size(146, 15);
            label6.TabIndex = 0;
            label6.Text = "DIAGNOSTICS + LOGGING";
            // 
            // resetConfigSettingsButton
            // 
            resetConfigSettingsButton.Location = new Point(298, 498);
            resetConfigSettingsButton.Name = "resetConfigSettingsButton";
            resetConfigSettingsButton.Size = new Size(216, 23);
            resetConfigSettingsButton.TabIndex = 2;
            resetConfigSettingsButton.Text = "RESET CONFIG SETTINGS";
            resetConfigSettingsButton.UseVisualStyleBackColor = true;
            resetConfigSettingsButton.Click += ResetConfigSettingsButton_Click;
            // 
            // importConfigSettingsButton
            // 
            importConfigSettingsButton.Location = new Point(520, 527);
            importConfigSettingsButton.Name = "importConfigSettingsButton";
            importConfigSettingsButton.Size = new Size(248, 23);
            importConfigSettingsButton.TabIndex = 3;
            importConfigSettingsButton.Text = "IMPORT CONFIG SETTINGS";
            importConfigSettingsButton.UseVisualStyleBackColor = true;
            importConfigSettingsButton.Click += ImportConfigSettingsButton_Click;
            // 
            // exportConfigSettingsButton
            // 
            exportConfigSettingsButton.Location = new Point(520, 498);
            exportConfigSettingsButton.Name = "exportConfigSettingsButton";
            exportConfigSettingsButton.Size = new Size(248, 23);
            exportConfigSettingsButton.TabIndex = 4;
            exportConfigSettingsButton.Text = "EXPORT CONFIG SETTINGS";
            exportConfigSettingsButton.UseVisualStyleBackColor = true;
            exportConfigSettingsButton.Click += ExportConfigSettingsButton_Click;
            // 
            // settingDescriptionLabel
            // 
            settingDescriptionLabel.BackColor = SystemColors.ActiveBorder;
            settingDescriptionLabel.Location = new Point(12, 447);
            settingDescriptionLabel.Name = "settingDescriptionLabel";
            settingDescriptionLabel.Size = new Size(756, 37);
            settingDescriptionLabel.TabIndex = 5;
            settingDescriptionLabel.Text = "SETTING DESCRIPTION LABEL";
            // 
            // exitConfigSettingsButton
            // 
            exitConfigSettingsButton.Location = new Point(298, 527);
            exitConfigSettingsButton.Name = "exitConfigSettingsButton";
            exitConfigSettingsButton.Size = new Size(216, 23);
            exitConfigSettingsButton.TabIndex = 6;
            exitConfigSettingsButton.Text = "RETURN TO MAIN WINDOW";
            exitConfigSettingsButton.UseVisualStyleBackColor = true;
            exitConfigSettingsButton.Click += ExitConfigSettingsButton_Click;
            // 
            // ModConfigSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(exitConfigSettingsButton);
            Controls.Add(settingDescriptionLabel);
            Controls.Add(exportConfigSettingsButton);
            Controls.Add(importConfigSettingsButton);
            Controls.Add(resetConfigSettingsButton);
            Controls.Add(tabControl1);
            Controls.Add(saveConfigSettingsButton);
            MaximizeBox = false;
            MaximumSize = new Size(800, 600);
            MinimizeBox = false;
            MinimumSize = new Size(800, 600);
            Name = "ModConfigSettingsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mod Configuration Settings";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            cfgAudioSpeechVolumePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cfgAudioSpeechNumericUpDown).EndInit();
            cfgAudioSfxVolumePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cfgAudioSfxNumericUpDown).EndInit();
            cfgAudioSoundCardProviderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cfgAudioSoundCardProviderNumericUpDown).EndInit();
            cfgAudioMusicVolumePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cfgAudioMusicVolumeNumericUpDown).EndInit();
            cfgAudioMasterVolumePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cfgAudioMasterVolumeNumericUpDown).EndInit();
            cfgAudioOptionsPanel.ResumeLayout(false);
            cfgAudioOptionsPanel.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button saveConfigSettingsButton;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.Button resetConfigSettingsButton;
		private System.Windows.Forms.Button importConfigSettingsButton;
		private System.Windows.Forms.Button exportConfigSettingsButton;
		private System.Windows.Forms.Label settingDescriptionLabel;
		private System.Windows.Forms.Button exitConfigSettingsButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
        private Panel cfgAudioSpeechVolumePanel;
        private NumericUpDown cfgAudioSpeechNumericUpDown;
        private Label cfgAudioSpeechVolumeLabel;
        private Panel cfgAudioSfxVolumePanel;
        private NumericUpDown cfgAudioSfxNumericUpDown;
        private Label cfgAudioSfxVolumeLabel;
        private Panel cfgAudioSoundCardProviderPanel;
        private NumericUpDown cfgAudioSoundCardProviderNumericUpDown;
        private Label cfgAudioSoundCardProviderLabel;
        private Panel cfgAudioMusicVolumePanel;
        private NumericUpDown cfgAudioMusicVolumeNumericUpDown;
        private Label cfgAudioMusicVolumeLabel;
        private Panel cfgAudioMasterVolumePanel;
        private NumericUpDown cfgAudioMasterVolumeNumericUpDown;
        private Label cfgAudioMasterVolumeLabel;
        private Panel cfgAudioOptionsPanel;
        private CheckBox cfgAudioSpeechEnableCheckBox;
        private CheckBox cfgAudioEnableCheckBox;
        private CheckBox cfgAudioSubFactionAccentsEnableCheckBox;
    }
}
