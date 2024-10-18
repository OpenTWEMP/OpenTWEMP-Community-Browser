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
    private const string MediaDeviceHomeFolderName = ".app-media";
    private const string DefaultAudioFileName = "TEST.mp3";

    private static MediaDeviceManager? activeManagerInstance;

    private readonly IAudioPlaybackDevice audioPlaybackDevice;

    private readonly DirectoryInfo mediaDeviceHomeDirectoryInfo;
    private readonly FileInfo defaultAudioFileInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaDeviceManager"/> class.
    /// </summary>
    /// <param name="audioPlaybackDevice">An instance of a target audio playback device.</param>
    private MediaDeviceManager(IAudioPlaybackDevice audioPlaybackDevice)
    {
        this.audioPlaybackDevice = audioPlaybackDevice;

        string mediaDeviceHomeDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), MediaDeviceHomeFolderName);
        this.mediaDeviceHomeDirectoryInfo = new DirectoryInfo(mediaDeviceHomeDirectoryPath);

        if (!this.mediaDeviceHomeDirectoryInfo.Exists)
        {
            this.mediaDeviceHomeDirectoryInfo.Create();
        }

        string defaultAudioFilePath = Path.Combine(this.mediaDeviceHomeDirectoryInfo.FullName, DefaultAudioFileName);
        this.defaultAudioFileInfo = new FileInfo(defaultAudioFilePath);

        this.MusicPlayerDevice = new GameMusicPlayer(this.audioPlaybackDevice, this.defaultAudioFileInfo);

        if (this.defaultAudioFileInfo.Exists)
        {
            this.MusicPlayerDevice.Play();
        }
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
}
