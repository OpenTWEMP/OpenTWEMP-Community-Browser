namespace TWEMP.Browser.App.Classic.CommonLibrary
{
    partial class GameMusicPlayerForm
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
            musicPlayButton = new Button();
            musicStopButton = new Button();
            musicPauseButton = new Button();
            musicRewindButton = new Button();
            musicMuteVolumeButton = new Button();
            musicChargeVolumeButton = new Button();
            musicVolumeTrackBar = new TrackBar();
            musicVolumeLabel = new Label();
            formCloseButton = new Button();
            ((System.ComponentModel.ISupportInitialize)musicVolumeTrackBar).BeginInit();
            SuspendLayout();
            // 
            // musicPlayButton
            // 
            musicPlayButton.Location = new Point(258, 63);
            musicPlayButton.Name = "musicPlayButton";
            musicPlayButton.Size = new Size(75, 23);
            musicPlayButton.TabIndex = 0;
            musicPlayButton.Text = "PLAY";
            musicPlayButton.UseVisualStyleBackColor = true;
            musicPlayButton.Click += MusicPlayButton_Click;
            // 
            // musicStopButton
            // 
            musicStopButton.Location = new Point(177, 63);
            musicStopButton.Name = "musicStopButton";
            musicStopButton.Size = new Size(75, 23);
            musicStopButton.TabIndex = 1;
            musicStopButton.Text = "STOP";
            musicStopButton.UseVisualStyleBackColor = true;
            musicStopButton.Click += MusicStopButton_Click;
            // 
            // musicPauseButton
            // 
            musicPauseButton.Location = new Point(339, 63);
            musicPauseButton.Name = "musicPauseButton";
            musicPauseButton.Size = new Size(75, 23);
            musicPauseButton.TabIndex = 2;
            musicPauseButton.Text = "PAUSE";
            musicPauseButton.UseVisualStyleBackColor = true;
            musicPauseButton.Click += MusicPauseButton_Click;
            // 
            // musicRewindButton
            // 
            musicRewindButton.Location = new Point(420, 63);
            musicRewindButton.Name = "musicRewindButton";
            musicRewindButton.Size = new Size(75, 23);
            musicRewindButton.TabIndex = 3;
            musicRewindButton.Text = "REWIND";
            musicRewindButton.UseVisualStyleBackColor = true;
            musicRewindButton.Click += MusicRewindButton_Click;
            // 
            // musicMuteVolumeButton
            // 
            musicMuteVolumeButton.Location = new Point(12, 12);
            musicMuteVolumeButton.Name = "musicMuteVolumeButton";
            musicMuteVolumeButton.Size = new Size(103, 34);
            musicMuteVolumeButton.TabIndex = 4;
            musicMuteVolumeButton.Text = "MUTE VOLUME";
            musicMuteVolumeButton.UseVisualStyleBackColor = true;
            musicMuteVolumeButton.Click += MusicMuteVolumeButton_Click;
            // 
            // musicChargeVolumeButton
            // 
            musicChargeVolumeButton.Location = new Point(560, 12);
            musicChargeVolumeButton.Name = "musicChargeVolumeButton";
            musicChargeVolumeButton.Size = new Size(123, 34);
            musicChargeVolumeButton.TabIndex = 5;
            musicChargeVolumeButton.Text = "CHARGE VOLUME";
            musicChargeVolumeButton.UseVisualStyleBackColor = true;
            musicChargeVolumeButton.Click += MusicChargeVolumeButton_Click;
            // 
            // musicVolumeTrackBar
            // 
            musicVolumeTrackBar.AutoSize = false;
            musicVolumeTrackBar.Location = new Point(121, 12);
            musicVolumeTrackBar.Maximum = 100;
            musicVolumeTrackBar.Name = "musicVolumeTrackBar";
            musicVolumeTrackBar.Size = new Size(433, 45);
            musicVolumeTrackBar.TabIndex = 6;
            musicVolumeTrackBar.Value = 50;
            musicVolumeTrackBar.Scroll += MusicVolumeTrackBar_Scroll;
            // 
            // musicVolumeLabel
            // 
            musicVolumeLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            musicVolumeLabel.Location = new Point(240, 89);
            musicVolumeLabel.Name = "musicVolumeLabel";
            musicVolumeLabel.Size = new Size(193, 52);
            musicVolumeLabel.TabIndex = 7;
            musicVolumeLabel.Text = "musicVolumeLabel";
            musicVolumeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // formCloseButton
            // 
            formCloseButton.Location = new Point(12, 147);
            formCloseButton.Name = "formCloseButton";
            formCloseButton.Size = new Size(671, 23);
            formCloseButton.TabIndex = 8;
            formCloseButton.Text = "CLOSE";
            formCloseButton.UseVisualStyleBackColor = true;
            formCloseButton.Click += FormCloseButton_Click;
            // 
            // GameMusicPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(695, 182);
            ControlBox = false;
            Controls.Add(formCloseButton);
            Controls.Add(musicVolumeLabel);
            Controls.Add(musicVolumeTrackBar);
            Controls.Add(musicChargeVolumeButton);
            Controls.Add(musicMuteVolumeButton);
            Controls.Add(musicRewindButton);
            Controls.Add(musicPauseButton);
            Controls.Add(musicStopButton);
            Controls.Add(musicPlayButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GameMusicPlayerForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Game Music Player";
            ((System.ComponentModel.ISupportInitialize)musicVolumeTrackBar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button musicPlayButton;
        private Button musicStopButton;
        private Button musicPauseButton;
        private Button musicRewindButton;
        private Button musicMuteVolumeButton;
        private Button musicChargeVolumeButton;
        private TrackBar musicVolumeTrackBar;
        private Label musicVolumeLabel;
        private Button formCloseButton;
    }
}