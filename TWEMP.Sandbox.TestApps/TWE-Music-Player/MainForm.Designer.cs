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
			this.mediaListBox = new System.Windows.Forms.ListBox();
			this.mediaFileNameLabel = new System.Windows.Forms.Label();
			this.mediaPlayButton = new System.Windows.Forms.Button();
			this.mediaStopButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mediaListBox
			// 
			this.mediaListBox.FormattingEnabled = true;
			this.mediaListBox.ItemHeight = 15;
			this.mediaListBox.Location = new System.Drawing.Point(12, 57);
			this.mediaListBox.Name = "mediaListBox";
			this.mediaListBox.Size = new System.Drawing.Size(204, 139);
			this.mediaListBox.TabIndex = 0;
			this.mediaListBox.SelectedIndexChanged += new System.EventHandler(this.mediaListBox_SelectedIndexChanged);
			// 
			// mediaFileNameLabel
			// 
			this.mediaFileNameLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.mediaFileNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mediaFileNameLabel.Location = new System.Drawing.Point(12, 17);
			this.mediaFileNameLabel.Name = "mediaFileNameLabel";
			this.mediaFileNameLabel.Size = new System.Drawing.Size(385, 36);
			this.mediaFileNameLabel.TabIndex = 1;
			// 
			// mediaPlayButton
			// 
			this.mediaPlayButton.Location = new System.Drawing.Point(222, 56);
			this.mediaPlayButton.Name = "mediaPlayButton";
			this.mediaPlayButton.Size = new System.Drawing.Size(175, 68);
			this.mediaPlayButton.TabIndex = 2;
			this.mediaPlayButton.Text = "PLAY";
			this.mediaPlayButton.UseVisualStyleBackColor = true;
			this.mediaPlayButton.Click += new System.EventHandler(this.mediaPlayButton_Click);
			// 
			// mediaStopButton
			// 
			this.mediaStopButton.Location = new System.Drawing.Point(222, 130);
			this.mediaStopButton.Name = "mediaStopButton";
			this.mediaStopButton.Size = new System.Drawing.Size(175, 68);
			this.mediaStopButton.TabIndex = 3;
			this.mediaStopButton.Text = "STOP";
			this.mediaStopButton.UseVisualStyleBackColor = true;
			this.mediaStopButton.Click += new System.EventHandler(this.mediaStopButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(409, 206);
			this.Controls.Add(this.mediaStopButton);
			this.Controls.Add(this.mediaPlayButton);
			this.Controls.Add(this.mediaFileNameLabel);
			this.Controls.Add(this.mediaListBox);
			this.Name = "MainForm";
			this.Text = "TWE-Music-Player";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox mediaListBox;
		private System.Windows.Forms.Label mediaFileNameLabel;
		private System.Windows.Forms.Button mediaPlayButton;
		private System.Windows.Forms.Button mediaStopButton;
	}
}
