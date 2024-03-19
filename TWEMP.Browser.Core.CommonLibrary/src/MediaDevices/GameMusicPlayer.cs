// <copyright file="GameMusicPlayer.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.MediaDevices;

/// <summary>
/// Represents a device implementing browser's game music player.
/// </summary>
public class GameMusicPlayer
{
    private FileInfo currentAudioFileInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameMusicPlayer"/> class.
    /// </summary>
    /// <param name="audioFileInfo">Information about an audio file.</param>
    private GameMusicPlayer(FileInfo audioFileInfo)
    {
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
    /// Configures a new game music player to playback a target audio file.
    /// </summary>
    /// <param name="targetAudioFileInfo">Information about an audio file.</param>
    /// <returns>A new instance of the <see cref="GameMusicPlayer"/> class.</returns>
    public static GameMusicPlayer Configure(FileInfo targetAudioFileInfo)
    {
        return new GameMusicPlayer(targetAudioFileInfo);
    }

    /// <summary>
    /// Plays the loaded audio file via this game music player.
    /// </summary>
    public void Play()
    {
        this.State = GameMusicPlaybackState.Playing;

        // TODO: Add needed NAudio code
    }

    /// <summary>
    /// Stops the playing audio file in this game music player.
    /// </summary>
    public void Stop()
    {
        this.State = GameMusicPlaybackState.Stopped;

        // TODO: Add needed NAudio code
    }

    /// <summary>
    /// Pauses the playing audio file in this game music player.
    /// </summary>
    public void Pause()
    {
        this.State = GameMusicPlaybackState.Paused;

        // TODO: Add needed NAudio code
    }

    /// <summary>
    /// Rewinds the playing audio file in this game music player.
    /// </summary>
    public void Rewind()
    {
        this.State = GameMusicPlaybackState.Playing;

        // TODO: Add needed NAudio code
    }

    /// <summary>
    /// Updates the music playback volume value by a target volume value.
    /// </summary>
    /// <param name="targetVolumeValue">A target volume value.</param>
    public void UpdateVolume(int targetVolumeValue)
    {
        this.Volume.UpdateVolumeValue(targetVolumeValue);

        // TODO: Add needed NAudio code
    }

    /// <summary>
    /// Mutes the music playback volume (use its minimum value).
    /// </summary>
    public void MuteVolume()
    {
        this.Volume.SetMinVolumeValue();

        // TODO: Add needed NAudio code
    }

    /// <summary>
    /// Charges the music playback volume (use its maximum value).
    /// </summary>
    public void ChargeVolume()
    {
        this.Volume.SetMaxVolumeValue();

        // TODO: Add needed NAudio code
    }
}
