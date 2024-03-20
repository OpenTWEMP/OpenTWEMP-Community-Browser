// <copyright file="MediaDeviceManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.MediaDevices;

using TWEMP.Browser.Core.CommonLibrary.MediaDevices.Plugins;

/// <summary>
/// Represents a manager for available media devices of the application.
/// </summary>
public class MediaDeviceManager
{
    private static readonly FileInfo DefaultAudioFileInfo;

    private static MediaDeviceManager? activeManagerInstance;

    private readonly IAudioPlaybackDevice audioPlaybackDevice;

    /// <summary>
    /// Initializes static members of the <see cref="MediaDeviceManager"/> class.
    /// </summary>
    static MediaDeviceManager()
    {
        DefaultAudioFileInfo = InitializeAudioFileInfoByDefault();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaDeviceManager"/> class.
    /// </summary>
    /// <param name="audioPlaybackDevice">An instance of a target audio playback device.</param>
    private MediaDeviceManager(IAudioPlaybackDevice audioPlaybackDevice)
    {
        this.audioPlaybackDevice = audioPlaybackDevice;

        this.MusicPlayerDevice = new GameMusicPlayer(this.audioPlaybackDevice, DefaultAudioFileInfo);
    }

    /// <summary>
    /// Gets the current game music player device.
    /// </summary>
    public GameMusicPlayer MusicPlayerDevice { get; }

    /// <summary>
    /// Creates a new configured instance of the <see cref="MediaDeviceManager"/> class by default.
    /// </summary>
    /// <returns>A new configured instance of the <see cref="MediaDeviceManager"/> class.</returns>
    public static MediaDeviceManager Create()
    {
        if (activeManagerInstance == null)
        {
            IAudioPlaybackDevice defaultPlaybackDevice = new NAudioSoundPlayer();
            MediaDeviceManager mediaDeviceManager = new (defaultPlaybackDevice);
            activeManagerInstance = mediaDeviceManager;
        }

        return activeManagerInstance;
    }

    private static FileInfo InitializeAudioFileInfoByDefault()
    {
        return new FileInfo("TEST.mp3"); // TODO: Define the default audio file for the game music player.
    }
}
