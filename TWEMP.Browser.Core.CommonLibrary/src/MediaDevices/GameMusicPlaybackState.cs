// <copyright file="GameMusicPlaybackState.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.MediaDevices;

/// <summary>
/// Represents possible states for game music playback.
/// </summary>
public enum GameMusicPlaybackState
{
    /// <summary>
    /// An audio file is successfully loaded to the music player device.
    /// </summary>
    Cued,

    /// <summary>
    /// An audio file is currently playing into the music player device.
    /// </summary>
    Playing,

    /// <summary>
    /// An audio file is currently paused into the music player device.
    /// </summary>
    Paused,

    /// <summary>
    /// An audio file is currently stopped into the music player device.
    /// </summary>
    Stopped,

    /// <summary>
    /// An audio file is successfully unloaded from the music player device.
    /// </summary>
    Uncued,
}
