// <copyright file="GameMusicPlayer.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.MediaDevices;

/// <summary>
/// Represents a device implementing browser's game music player.
/// </summary>
public class GameMusicPlayer
{
    private readonly IAudioPlaybackDevice currentAudioPlaybackDevice;

    private FileInfo currentAudioFileInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameMusicPlayer"/> class.
    /// </summary>
    /// <param name="audioPlaybackDevice">An instance of a target audio playback device.</param>
    /// <param name="audioFileInfo">The information about a target audio file.</param>
    public GameMusicPlayer(IAudioPlaybackDevice audioPlaybackDevice, FileInfo audioFileInfo)
    {
        this.currentAudioPlaybackDevice = audioPlaybackDevice;

        this.currentAudioFileInfo = audioFileInfo;

        this.State = GameMusicPlaybackState.Cued;
        this.Volume = default;
    }

    /// <summary>
    /// Gets the current playback state for this game music player.
    /// </summary>
    public GameMusicPlaybackState State { get; private set; }

    /// <summary>
    /// Gets the current music playback volume for this game music player.
    /// </summary>
    public MusicPlayerVolume Volume { get; }

    /// <summary>
    /// Plays the loaded audio file via this game music player.
    /// </summary>
    public void Play()
    {
        if (this.State == GameMusicPlaybackState.Paused || this.State == GameMusicPlaybackState.Stopped)
        {
            this.StartPlayback();
        }
    }

    /// <summary>
    /// Plays a target audio file via this game music player.
    /// </summary>
    /// <param name="targetAudioFileInfo">Information about an audio file.</param>
    public void Play(FileInfo targetAudioFileInfo)
    {
        if (this.State != GameMusicPlaybackState.Uncued)
        {
            this.UnloadAudio();
        }

        this.LoadAudio(targetAudioFileInfo);

        if (this.State == GameMusicPlaybackState.Cued)
        {
            this.StartPlayback();
        }
    }

    /// <summary>
    /// Stops the playing audio file in this game music player.
    /// </summary>
    public void Stop()
    {
        if (this.State == GameMusicPlaybackState.Playing || this.State == GameMusicPlaybackState.Paused)
        {
            this.StopPlayback();
        }
    }

    /// <summary>
    /// Pauses the playing audio file in this game music player.
    /// </summary>
    public void Pause()
    {
        if (this.State == GameMusicPlaybackState.Playing)
        {
            this.PausePlayback();
        }
    }

    /// <summary>
    /// Rewinds the playing audio file in this game music player.
    /// </summary>
    public void Rewind()
    {
        if (this.State == GameMusicPlaybackState.Playing || this.State == GameMusicPlaybackState.Paused)
        {
            this.RewindPlayback();
        }
    }

    /// <summary>
    /// Updates the music playback volume value by a target volume value.
    /// </summary>
    /// <param name="targetVolumeValue">A target volume integer value.</param>
    public void UpdateVolume(int targetVolumeValue)
    {
        if (this.Volume.UpdateVolumeValue(targetVolumeValue))
        {
            this.currentAudioPlaybackDevice.UpdateVolume(this.Volume.CurrentValue);
        }
    }

    /// <summary>
    /// Updates the music playback volume value by a target volume value.
    /// </summary>
    /// <param name="targetVolumeValue">A target volume floating point value.</param>
    public void UpdateVolume(float targetVolumeValue)
    {
        if (this.Volume.UpdateVolumeValue((float)targetVolumeValue))
        {
            this.currentAudioPlaybackDevice.UpdateVolume(this.Volume.CurrentValue);
        }
    }

    /// <summary>
    /// Mutes the music playback volume (use its minimum value).
    /// </summary>
    public void MuteVolume()
    {
        this.UpdateVolume(MusicPlayerVolume.MinValue);
    }

    /// <summary>
    /// Charges the music playback volume (use its maximum value).
    /// </summary>
    public void ChargeVolume()
    {
        this.UpdateVolume(MusicPlayerVolume.MaxValue);
    }

    private void LoadAudio(FileInfo audioFileInfo)
    {
        this.currentAudioFileInfo = audioFileInfo;
        this.currentAudioPlaybackDevice.Cue(this.currentAudioFileInfo.FullName);
        this.State = GameMusicPlaybackState.Cued;
    }

    private void UnloadAudio()
    {
        this.currentAudioPlaybackDevice.Uncue();
        this.State = GameMusicPlaybackState.Uncued;
    }

    private void StartPlayback()
    {
        this.currentAudioPlaybackDevice.Play(this.Volume.CurrentValue);
        this.State = GameMusicPlaybackState.Playing;
    }

    private void StopPlayback()
    {
        this.currentAudioPlaybackDevice.Stop();
        this.State = GameMusicPlaybackState.Stopped;
    }

    private void PausePlayback()
    {
        this.currentAudioPlaybackDevice.Pause();
        this.State = GameMusicPlaybackState.Paused;
    }

    private void RewindPlayback()
    {
        this.currentAudioPlaybackDevice.Rewind();
        this.State = GameMusicPlaybackState.Playing;
    }
}
