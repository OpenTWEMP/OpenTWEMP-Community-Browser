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
			appSettingsPanel = new System.Windows.Forms.Panel();
			appColorThemeGroupBox = new System.Windows.Forms.GroupBox();
			uiStyleByDarkThemeRadioButton = new System.Windows.Forms.RadioButton();
			uiStyleByLightThemeRadioButton = new System.Windows.Forms.RadioButton();
			uiStyleByDefaultThemeRadioButton = new System.Windows.Forms.RadioButton();
			exitAppSettingsButton = new System.Windows.Forms.Button();
			appSettingsPanel.SuspendLayout();
			appColorThemeGroupBox.SuspendLayout();
			SuspendLayout();
			// 
			// saveAppSettingsButton
			// 
			saveAppSettingsButton.Location = new System.Drawing.Point(12, 526);
			saveAppSettingsButton.Name = "saveAppSettingsButton";
			saveAppSettingsButton.Size = new System.Drawing.Size(176, 23);
			saveAppSettingsButton.TabIndex = 0;
			saveAppSettingsButton.Text = "SAVE APP SETTINGS";
			saveAppSettingsButton.UseVisualStyleBackColor = true;
			saveAppSettingsButton.Click += SaveAppSettingsButton_Click;
			// 
			// appSettingsPanel
			// 
			appSettingsPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			appSettingsPanel.Controls.Add(appColorThemeGroupBox);
			appSettingsPanel.Location = new System.Drawing.Point(12, 12);
			appSettingsPanel.Name = "appSettingsPanel";
			appSettingsPanel.Size = new System.Drawing.Size(760, 487);
			appSettingsPanel.TabIndex = 1;
			// 
			// appColorThemeGroupBox
			// 
			appColorThemeGroupBox.BackColor = System.Drawing.Color.Transparent;
			appColorThemeGroupBox.Controls.Add(uiStyleByDarkThemeRadioButton);
			appColorThemeGroupBox.Controls.Add(uiStyleByLightThemeRadioButton);
			appColorThemeGroupBox.Controls.Add(uiStyleByDefaultThemeRadioButton);
			appColorThemeGroupBox.Location = new System.Drawing.Point(3, 3);
			appColorThemeGroupBox.Name = "appColorThemeGroupBox";
			appColorThemeGroupBox.Size = new System.Drawing.Size(238, 101);
			appColorThemeGroupBox.TabIndex = 15;
			appColorThemeGroupBox.TabStop = false;
			appColorThemeGroupBox.Text = "Select GUI style theme";
			// 
			// uiStyleByDarkThemeRadioButton
			// 
			uiStyleByDarkThemeRadioButton.AutoSize = true;
			uiStyleByDarkThemeRadioButton.Location = new System.Drawing.Point(12, 74);
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
			uiStyleByLightThemeRadioButton.Location = new System.Drawing.Point(12, 49);
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
			uiStyleByDefaultThemeRadioButton.Location = new System.Drawing.Point(12, 24);
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
			exitAppSettingsButton.Location = new System.Drawing.Point(610, 526);
			exitAppSettingsButton.Name = "exitAppSettingsButton";
			exitAppSettingsButton.Size = new System.Drawing.Size(162, 23);
			exitAppSettingsButton.TabIndex = 2;
			exitAppSettingsButton.Text = "EXIT APP SETTINGS";
			exitAppSettingsButton.UseVisualStyleBackColor = true;
			exitAppSettingsButton.Click += ExitAppSettingsButton_Click;
			// 
			// ApplicationSettingsForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(784, 561);
			Controls.Add(exitAppSettingsButton);
			Controls.Add(appSettingsPanel);
			Controls.Add(saveAppSettingsButton);
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(800, 600);
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(800, 600);
			Name = "ApplicationSettingsForm";
			ShowIcon = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ApplicationSettingsForm";
			appSettingsPanel.ResumeLayout(false);
			appColorThemeGroupBox.ResumeLayout(false);
			appColorThemeGroupBox.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button saveAppSettingsButton;
		private System.Windows.Forms.Panel appSettingsPanel;
		private System.Windows.Forms.Button exitAppSettingsButton;
		private System.Windows.Forms.GroupBox appColorThemeGroupBox;
		private System.Windows.Forms.RadioButton uiStyleByDarkThemeRadioButton;
		private System.Windows.Forms.RadioButton uiStyleByLightThemeRadioButton;
		private System.Windows.Forms.RadioButton uiStyleByDefaultThemeRadioButton;
	}
}