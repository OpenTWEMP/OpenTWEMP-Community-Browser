// <copyright file="IAudioPlaybackDevice.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.MediaDevices;

/// <summary>
/// Defines the compatible interface which should be supported
/// by third-party implementations of an audio playback device.
/// </summary>
public interface IAudioPlaybackDevice
{
    /// <summary>
    /// Cues a target audio file to this audio playback device.
    /// </summary>
    /// <param name="audioFilePath">The absolute path to a target audio file.</param>
    public abstract void Cue(string audioFilePath);

    /// <summary>
    /// Uncues the current audio file from this audio playback device.
    /// </summary>
    public abstract void Uncue();

    /// <summary>
    ///  Plays the loaded audio file via this audio playback device.
    /// </summary>
    public abstract void Play();

    /// <summary>
    ///  Stops playing the audio file into this audio playback device.
    /// </summary>
    public abstract void Stop();

    /// <summary>
    ///  Pauses playing the audio file into this audio playback device.
    /// </summary>
    public abstract void Pause();

    /// <summary>
    ///  Rewinds playing the audio file into this audio playback device.
    /// </summary>
    public abstract void Rewind();

    /// <summary>
    /// Updates the sound playback volume value by a target volume value.
    /// </summary>
    /// <param name="targetVolumeValue">A target volume value.</param>
    public abstract void UpdateVolume(float targetVolumeValue);
}
