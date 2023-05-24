namespace TWE_Launcher.Forms
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
			saveAppSettingsButton = new System.Windows.Forms.Button();
			appLocalizationGroupBox = new System.Windows.Forms.GroupBox();
			enableEngLocaleRadioButton = new System.Windows.Forms.RadioButton();
			enableRusLocaleRadioButton = new System.Windows.Forms.RadioButton();
			appColorThemeGroupBox = new System.Windows.Forms.GroupBox();
			uiStyleByDarkThemeRadioButton = new System.Windows.Forms.RadioButton();
			uiStyleByLightThemeRadioButton = new System.Windows.Forms.RadioButton();
			uiStyleByDefaultThemeRadioButton = new System.Windows.Forms.RadioButton();
			exitAppSettingsButton = new System.Windows.Forms.Button();
			appLocalizationGroupBox.SuspendLayout();
			appColorThemeGroupBox.SuspendLayout();
			SuspendLayout();
			// 
			// saveAppSettingsButton
			// 
			saveAppSettingsButton.Location = new System.Drawing.Point(12, 198);
			saveAppSettingsButton.Name = "saveAppSettingsButton";
			saveAppSettingsButton.Size = new System.Drawing.Size(360, 23);
			saveAppSettingsButton.TabIndex = 0;
			saveAppSettingsButton.Text = "SAVE APP SETTINGS";
			saveAppSettingsButton.UseVisualStyleBackColor = true;
			saveAppSettingsButton.Click += SaveAppSettingsButton_Click;
			// 
			// appLocalizationGroupBox
			// 
			appLocalizationGroupBox.BackColor = System.Drawing.Color.Transparent;
			appLocalizationGroupBox.Controls.Add(enableEngLocaleRadioButton);
			appLocalizationGroupBox.Controls.Add(enableRusLocaleRadioButton);
			appLocalizationGroupBox.Location = new System.Drawing.Point(12, 119);
			appLocalizationGroupBox.Name = "appLocalizationGroupBox";
			appLocalizationGroupBox.Size = new System.Drawing.Size(360, 73);
			appLocalizationGroupBox.TabIndex = 16;
			appLocalizationGroupBox.TabStop = false;
			appLocalizationGroupBox.Text = "Select GUI language";
			// 
			// enableEngLocaleRadioButton
			// 
			enableEngLocaleRadioButton.AutoSize = true;
			enableEngLocaleRadioButton.Checked = true;
			enableEngLocaleRadioButton.Location = new System.Drawing.Point(97, 22);
			enableEngLocaleRadioButton.Name = "enableEngLocaleRadioButton";
			enableEngLocaleRadioButton.Size = new System.Drawing.Size(136, 19);
			enableEngLocaleRadioButton.TabIndex = 1;
			enableEngLocaleRadioButton.TabStop = true;
			enableEngLocaleRadioButton.Text = "ENGLISH (by default)";
			enableEngLocaleRadioButton.UseVisualStyleBackColor = true;
			// 
			// enableRusLocaleRadioButton
			// 
			enableRusLocaleRadioButton.AutoSize = true;
			enableRusLocaleRadioButton.Location = new System.Drawing.Point(97, 47);
			enableRusLocaleRadioButton.Name = "enableRusLocaleRadioButton";
			enableRusLocaleRadioButton.Size = new System.Drawing.Size(141, 19);
			enableRusLocaleRadioButton.TabIndex = 0;
			enableRusLocaleRadioButton.Text = "RUSSIAN (in progress)";
			enableRusLocaleRadioButton.UseVisualStyleBackColor = true;
			// 
			// appColorThemeGroupBox
			// 
			appColorThemeGroupBox.BackColor = System.Drawing.Color.Transparent;
			appColorThemeGroupBox.Controls.Add(uiStyleByDarkThemeRadioButton);
			appColorThemeGroupBox.Controls.Add(uiStyleByLightThemeRadioButton);
			appColorThemeGroupBox.Controls.Add(uiStyleByDefaultThemeRadioButton);
			appColorThemeGroupBox.Location = new System.Drawing.Point(12, 12);
			appColorThemeGroupBox.Name = "appColorThemeGroupBox";
			appColorThemeGroupBox.Size = new System.Drawing.Size(360, 101);
			appColorThemeGroupBox.TabIndex = 15;
			appColorThemeGroupBox.TabStop = false;
			appColorThemeGroupBox.Text = "Select GUI style theme";
			// 
			// uiStyleByDarkThemeRadioButton
			// 
			uiStyleByDarkThemeRadioButton.AutoSize = true;
			uiStyleByDarkThemeRadioButton.Location = new System.Drawing.Point(97, 72);
			uiStyleByDarkThemeRadioButton.Name = "uiStyleByDarkThemeRadioButton";
			uiStyleByDarkThemeRadioButton.Size = new System.Drawing.Size(88, 19);
			uiStyleByDarkThemeRadioButton.TabIndex = 2;
			uiStyleByDarkThemeRadioButton.Text = "Dark Theme";
			uiStyleByDarkThemeRadioButton.UseVisualStyleBackColor = true;
			uiStyleByDarkThemeRadioButton.Click += uiStyleByDarkThemeRadioButton_Click;
			// 
			// uiStyleByLightThemeRadioButton
			// 
			uiStyleByLightThemeRadioButton.AutoSize = true;
			uiStyleByLightThemeRadioButton.Location = new System.Drawing.Point(97, 47);
			uiStyleByLightThemeRadioButton.Name = "uiStyleByLightThemeRadioButton";
			uiStyleByLightThemeRadioButton.Size = new System.Drawing.Size(91, 19);
			uiStyleByLightThemeRadioButton.TabIndex = 1;
			uiStyleByLightThemeRadioButton.Text = "Light Theme";
			uiStyleByLightThemeRadioButton.UseVisualStyleBackColor = true;
			uiStyleByLightThemeRadioButton.Click += uiStyleByLightThemeRadioButton_Click;
			// 
			// uiStyleByDefaultThemeRadioButton
			// 
			uiStyleByDefaultThemeRadioButton.AutoSize = true;
			uiStyleByDefaultThemeRadioButton.Checked = true;
			uiStyleByDefaultThemeRadioButton.Location = new System.Drawing.Point(97, 22);
			uiStyleByDefaultThemeRadioButton.Name = "uiStyleByDefaultThemeRadioButton";
			uiStyleByDefaultThemeRadioButton.Size = new System.Drawing.Size(175, 19);
			uiStyleByDefaultThemeRadioButton.TabIndex = 0;
			uiStyleByDefaultThemeRadioButton.TabStop = true;
			uiStyleByDefaultThemeRadioButton.Text = "Standard Theme (by default)";
			uiStyleByDefaultThemeRadioButton.UseVisualStyleBackColor = true;
			uiStyleByDefaultThemeRadioButton.Click += uiStyleByDefaultThemeRadioButton_Click;
			// 
			// exitAppSettingsButton
			// 
			exitAppSettingsButton.Location = new System.Drawing.Point(12, 226);
			exitAppSettingsButton.Name = "exitAppSettingsButton";
			exitAppSettingsButton.Size = new System.Drawing.Size(360, 23);
			exitAppSettingsButton.TabIndex = 2;
			exitAppSettingsButton.Text = "EXIT APP SETTINGS";
			exitAppSettingsButton.UseVisualStyleBackColor = true;
			exitAppSettingsButton.Click += ExitAppSettingsButton_Click;
			// 
			// AppSettingsForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(384, 261);
			Controls.Add(appLocalizationGroupBox);
			Controls.Add(exitAppSettingsButton);
			Controls.Add(appColorThemeGroupBox);
			Controls.Add(saveAppSettingsButton);
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(400, 300);
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(400, 300);
			Name = "AppSettingsForm";
			ShowIcon = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Application Settings";
			appLocalizationGroupBox.ResumeLayout(false);
			appLocalizationGroupBox.PerformLayout();
			appColorThemeGroupBox.ResumeLayout(false);
			appColorThemeGroupBox.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button saveAppSettingsButton;
		private System.Windows.Forms.Button exitAppSettingsButton;
		private System.Windows.Forms.GroupBox appColorThemeGroupBox;
		private System.Windows.Forms.RadioButton uiStyleByDarkThemeRadioButton;
		private System.Windows.Forms.RadioButton uiStyleByLightThemeRadioButton;
		private System.Windows.Forms.RadioButton uiStyleByDefaultThemeRadioButton;
		private System.Windows.Forms.GroupBox appLocalizationGroupBox;
		private System.Windows.Forms.RadioButton enableEngLocaleRadioButton;
		private System.Windows.Forms.RadioButton enableRusLocaleRadioButton;
	}
}