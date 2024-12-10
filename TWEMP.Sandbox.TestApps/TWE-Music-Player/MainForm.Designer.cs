namespace TWE.MusicPlayer
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
            mediaListBox = new System.Windows.Forms.ListBox();
            mediaFileNameLabel = new System.Windows.Forms.Label();
            mediaPlayButton = new System.Windows.Forms.Button();
            mediaStopButton = new System.Windows.Forms.Button();
            volumeTrackBar = new System.Windows.Forms.TrackBar();
            pauseButton = new System.Windows.Forms.Button();
            rewindButton = new System.Windows.Forms.Button();
            muteButton = new System.Windows.Forms.Button();
            volumeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)volumeTrackBar).BeginInit();
            SuspendLayout();
            // 
            // mediaListBox
            // 
            mediaListBox.FormattingEnabled = true;
            mediaListBox.ItemHeight = 15;
            mediaListBox.Location = new System.Drawing.Point(12, 57);
            mediaListBox.Name = "mediaListBox";
            mediaListBox.Size = new System.Drawing.Size(423, 139);
            mediaListBox.TabIndex = 0;
            mediaListBox.SelectedIndexChanged += mediaListBox_SelectedIndexChanged;
            // 
            // mediaFileNameLabel
            // 
            mediaFileNameLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            mediaFileNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mediaFileNameLabel.Location = new System.Drawing.Point(12, 17);
            mediaFileNameLabel.Name = "mediaFileNameLabel";
            mediaFileNameLabel.Size = new System.Drawing.Size(604, 36);
            mediaFileNameLabel.TabIndex = 1;
            // 
            // mediaPlayButton
            // 
            mediaPlayButton.Location = new System.Drawing.Point(441, 57);
            mediaPlayButton.Name = "mediaPlayButton";
            mediaPlayButton.Size = new System.Drawing.Size(175, 68);
            mediaPlayButton.TabIndex = 2;
            mediaPlayButton.Text = "PLAY";
            mediaPlayButton.UseVisualStyleBackColor = true;
            mediaPlayButton.Click += mediaPlayButton_Click;
            // 
            // mediaStopButton
            // 
            mediaStopButton.Location = new System.Drawing.Point(441, 128);
            mediaStopButton.Name = "mediaStopButton";
            mediaStopButton.Size = new System.Drawing.Size(175, 68);
            mediaStopButton.TabIndex = 3;
            mediaStopButton.Text = "STOP";
            mediaStopButton.UseVisualStyleBackColor = true;
            mediaStopButton.Click += mediaStopButton_Click;
            // 
            // volumeTrackBar
            // 
            volumeTrackBar.Location = new System.Drawing.Point(12, 202);
            volumeTrackBar.Maximum = 100;
            volumeTrackBar.Name = "volumeTrackBar";
            volumeTrackBar.Size = new System.Drawing.Size(604, 45);
            volumeTrackBar.TabIndex = 4;
            volumeTrackBar.Value = 50;
            volumeTrackBar.Scroll += volumeTrackBar_Scroll;
            // 
            // pauseButton
            // 
            pauseButton.Location = new System.Drawing.Point(29, 261);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new System.Drawing.Size(75, 23);
            pauseButton.TabIndex = 5;
            pauseButton.Text = "PAUSE";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // rewindButton
            // 
            rewindButton.Location = new System.Drawing.Point(29, 290);
            rewindButton.Name = "rewindButton";
            rewindButton.Size = new System.Drawing.Size(75, 23);
            rewindButton.TabIndex = 6;
            rewindButton.Text = "REWIND";
            rewindButton.UseVisualStyleBackColor = true;
            rewindButton.Click += rewindButton_Click;
            // 
            // muteButton
            // 
            muteButton.Location = new System.Drawing.Point(110, 261);
            muteButton.Name = "muteButton";
            muteButton.Size = new System.Drawing.Size(75, 23);
            muteButton.TabIndex = 7;
            muteButton.Text = "MUTE";
            muteButton.UseVisualStyleBackColor = true;
            muteButton.Click += muteButton_Click;
            // 
            // volumeLabel
            // 
            volumeLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            volumeLabel.Location = new System.Drawing.Point(239, 248);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new System.Drawing.Size(92, 51);
            volumeLabel.TabIndex = 8;
            volumeLabel.Text = "50";
            volumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(633, 343);
            Controls.Add(volumeLabel);
            Controls.Add(muteButton);
            Controls.Add(rewindButton);
            Controls.Add(pauseButton);
            Controls.Add(volumeTrackBar);
            Controls.Add(mediaStopButton);
            Controls.Add(mediaPlayButton);
            Controls.Add(mediaFileNameLabel);
            Controls.Add(mediaListBox);
            Name = "MainForm";
            Text = "TWE-Music-Player";
            ((System.ComponentModel.ISupportInitialize)volumeTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox mediaListBox;
		private System.Windows.Forms.Label mediaFileNameLabel;
		private System.Windows.Forms.Button mediaPlayButton;
		private System.Windows.Forms.Button mediaStopButton;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button rewindButton;
        private System.Windows.Forms.Button muteButton;
        private System.Windows.Forms.Label volumeLabel;
    }
}
