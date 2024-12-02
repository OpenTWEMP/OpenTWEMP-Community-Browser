// <copyright file="BrowserKernel.API.MediaDevice.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

#define EXPERIMENTAL_FEATURES
#undef EXPERIMENTAL_FEATURES

namespace TWEMP.Browser.Core.CommonLibrary;

public static partial class BrowserKernel
{
    public static void StartAudioPlayback(FileInfo audioFileInfo)
    {
        MediaDeviceManagerInstance.StartAudioPlayback(audioFileInfo);
    }

    public static void InterruptAudioPlayback()
    {
        MediaDeviceManagerInstance.InterruptAudioPlayback();
    }

    public static void ContinueCurrentAudioPlayback()
    {
        MediaDeviceManagerInstance.MusicPlayerDevice.Play();
    }

    public static void PauseCurrentAudioPlayback()
    {
        MediaDeviceManagerInstance.MusicPlayerDevice.Pause();
    }

    public static void RewindCurrentAudioPlayback()
    {
        MediaDeviceManagerInstance.MusicPlayerDevice.Rewind();
    }

    public static void StopCurrentAudioPlayback()
    {
        MediaDeviceManagerInstance.MusicPlayerDevice.Stop();
    }

#if EXPERIMENTAL_FEATURES
    public static void ChargeVolumeCurrentAudioPlayback()
    {
        MediaDeviceManagerInstance.MusicPlayerDevice.ChargeVolume();
    }

    public static void MuteVolumeCurrentAudioPlayback()
    {
        MediaDeviceManagerInstance.MusicPlayerDevice.MuteVolume();
    }

    public static void UpdateVolumeCurrentAudioPlayback(int volumeValue)
    {
        MediaDeviceManagerInstance.MusicPlayerDevice.UpdateVolume(volumeValue);
    }
#endif
}
