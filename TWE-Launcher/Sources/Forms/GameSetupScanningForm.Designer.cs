namespace TWE_Launcher.Forms
{
	partial class GameSetupScanningForm
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
			setupScanningProgressBar = new System.Windows.Forms.ProgressBar();
			setupScanningLabel = new System.Windows.Forms.Label();
			SuspendLayout();
			// 
			// setupScanningProgressBar
			// 
			setupScanningProgressBar.BackColor = System.Drawing.SystemColors.ControlText;
			setupScanningProgressBar.Location = new System.Drawing.Point(12, 107);
			setupScanningProgressBar.MarqueeAnimationSpeed = 1;
			setupScanningProgressBar.Maximum = 3;
			setupScanningProgressBar.Name = "setupScanningProgressBar";
			setupScanningProgressBar.Size = new System.Drawing.Size(600, 42);
			setupScanningProgressBar.Step = 3;
			setupScanningProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			setupScanningProgressBar.TabIndex = 0;
			setupScanningProgressBar.UseWaitCursor = true;
			setupScanningProgressBar.Value = 3;
			// 
			// setupScanningLabel
			// 
			setupScanningLabel.BackColor = System.Drawing.Color.Transparent;
			setupScanningLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			setupScanningLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			setupScanningLabel.Location = new System.Drawing.Point(12, 9);
			setupScanningLabel.Name = "setupScanningLabel";
			setupScanningLabel.Size = new System.Drawing.Size(600, 81);
			setupScanningLabel.TabIndex = 1;
			setupScanningLabel.Text = "The application is executing scanning your game setup folders. Please wait for finishing this process...";
			setupScanningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GameSetupScanningForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(624, 161);
			ControlBox = false;
			Controls.Add(setupScanningLabel);
			Controls.Add(setupScanningProgressBar);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(640, 200);
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(640, 200);
			Name = "GameSetupScanningForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "GameSetupScanningForm";
			TopMost = true;
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.ProgressBar setupScanningProgressBar;
		private System.Windows.Forms.Label setupScanningLabel;
	}
}