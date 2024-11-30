// <copyright file="MainBrowserForm.MediaDevice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

internal partial class MainBrowserForm
{
    private void StartGameModBackgroundMusic(UpdatableGameModificationView gameModView)
    {
        FileInfo backgroundSoundTrack = BrowserKernel.GetActivePresetBackgroundSoundTrackFileInfo(gameModView);
        BrowserKernel.StartAudioPlayback(backgroundSoundTrack);
    }

    private void InterruptGameModBackgroundMusic()
    {
        BrowserKernel.InterruptAudioPlayback();
    }
}
