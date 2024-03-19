// <copyright file="GameMusicPlayerForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

public partial class GameMusicPlayerForm : Form
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameMusicPlayerForm"/> class.
    /// </summary>
    public GameMusicPlayerForm()
    {
        this.InitializeComponent();

        this.musicVolumeLabel.Text = this.musicVolumeTrackBar.Value.ToString();
    }

    private void MusicPlayButton_Click(object sender, EventArgs e)
    {
        this.musicPlayButton.BackColor = Color.Green;

        this.musicStopButton.BackColor = Color.LightGray;
        this.musicPauseButton.BackColor = Color.LightGray;
        this.musicRewindButton.BackColor = Color.LightGray;
    }

    private void MusicStopButton_Click(object sender, EventArgs e)
    {
        this.musicStopButton.BackColor = Color.Red;

        this.musicPlayButton.BackColor = Color.LightGray;
        this.musicPauseButton.BackColor = Color.LightGray;
        this.musicRewindButton.BackColor = Color.LightGray;
    }

    private void MusicPauseButton_Click(object sender, EventArgs e)
    {
        this.musicPauseButton.BackColor = Color.Orange;

        this.musicPlayButton.BackColor = Color.LightGray;
        this.musicStopButton.BackColor = Color.LightGray;
        this.musicRewindButton.BackColor = Color.LightGray;
    }

    private void MusicRewindButton_Click(object sender, EventArgs e)
    {
        this.musicRewindButton.BackColor = Color.Blue;

        this.musicPlayButton.BackColor = Color.LightGray;
        this.musicStopButton.BackColor = Color.LightGray;
        this.musicPauseButton.BackColor = Color.LightGray;
    }

    private void MusicMuteVolumeButton_Click(object sender, EventArgs e)
    {
        this.musicVolumeTrackBar.Value = this.musicVolumeTrackBar.Minimum;
        this.musicVolumeLabel.Text = this.musicVolumeTrackBar.Minimum.ToString();
    }

    private void MusicChargeVolumeButton_Click(object sender, EventArgs e)
    {
        this.musicVolumeTrackBar.Value = this.musicVolumeTrackBar.Maximum;
        this.musicVolumeLabel.Text = this.musicVolumeTrackBar.Maximum.ToString();
    }

    private void MusicVolumeTrackBar_Scroll(object sender, EventArgs e)
    {
        this.musicVolumeLabel.Text = this.musicVolumeTrackBar.Value.ToString();
    }

    private void FormCloseButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
