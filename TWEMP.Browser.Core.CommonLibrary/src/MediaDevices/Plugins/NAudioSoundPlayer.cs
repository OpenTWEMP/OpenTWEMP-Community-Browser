// <copyright file="NAudioSoundPlayer.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.MediaDevices.Plugins;

using NAudio.Wave;
using TWEMP.Browser.Core.CommonLibrary.MediaDevices;

/// <summary>
/// Represents an audio playback device based on the NAudio third-party library.
/// </summary>
public class NAudioSoundPlayer : IAudioPlaybackDevice
{
    private WaveOutEvent outputDevice;
    private AudioFileReader audioFile;

    /// <summary>
    /// Initializes a new instance of the <see cref="NAudioSoundPlayer"/> class.
    /// </summary>
    public NAudioSoundPlayer()
    {
        this.outputDevice = new WaveOutEvent();
        this.audioFile = null!;
    }

    /// <summary>
    /// Cues a target audio file to this audio playback device.
    /// </summary>
    /// <param name="audioFilePath">The absolute path to a target audio file.</param>
    public void Cue(string audioFilePath)
    {
        if (this.outputDevice != null)
        {
            this.Uncue();
        }

        this.outputDevice = new WaveOutEvent();
        this.audioFile = new AudioFileReader(audioFilePath);
        this.outputDevice.Init(this.audioFile);
    }

    /// <summary>
    /// Uncues the current audio file from this audio playback device.
    /// </summary>
    public void Uncue()
    {
        this.outputDevice.Dispose();
    }

    /// <summary>
    ///  Plays the loaded audio file via this audio playback device.
    /// </summary>
    /// <param name="audioVolumeValue">A target audio volume value.</param>
    public void Play(float audioVolumeValue)
    {
        this.outputDevice.Volume = audioVolumeValue;
        this.outputDevice.Play();
    }

    /// <summary>
    ///  Stops playing the audio file into this audio playback device.
    /// </summary>
    public void Stop()
    {
        this.outputDevice.Stop();
    }

    /// <summary>
    ///  Pauses playing the audio file into this audio playback device.
    /// </summary>
    public void Pause()
    {
        this.outputDevice.Pause();
    }

    /// <summary>
    ///  Rewinds playing the audio file into this audio playback device.
    /// </summary>
    public void Rewind()
    {
        this.audioFile.Position = 0;
        this.outputDevice.Play();
    }

    /// <summary>
    /// Updates the sound playback volume value by a target volume value.
    /// </summary>
    /// <param name="targetVolumeValue">A target volume value.</param>
    public void UpdateVolume(float targetVolumeValue)
    {
        this.outputDevice.Volume = targetVolumeValue;
    }
}
