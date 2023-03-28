namespace TWE_Launcher.Sources.Forms
{
	partial class ApplicationSettingsForm
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
			exitAppSettingsButton = new System.Windows.Forms.Button();
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
			saveAppSettingsButton.Click += saveAppSettingsButton_Click;
			// 
			// appSettingsPanel
			// 
			appSettingsPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			appSettingsPanel.Location = new System.Drawing.Point(12, 12);
			appSettingsPanel.Name = "appSettingsPanel";
			appSettingsPanel.Size = new System.Drawing.Size(760, 487);
			appSettingsPanel.TabIndex = 1;
			// 
			// exitAppSettingsButton
			// 
			exitAppSettingsButton.Location = new System.Drawing.Point(610, 526);
			exitAppSettingsButton.Name = "exitAppSettingsButton";
			exitAppSettingsButton.Size = new System.Drawing.Size(162, 23);
			exitAppSettingsButton.TabIndex = 2;
			exitAppSettingsButton.Text = "EXIT APP SETTINGS";
			exitAppSettingsButton.UseVisualStyleBackColor = true;
			exitAppSettingsButton.Click += exitAppSettingsButton_Click;
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
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button saveAppSettingsButton;
		private System.Windows.Forms.Panel appSettingsPanel;
		private System.Windows.Forms.Button exitAppSettingsButton;
	}
}