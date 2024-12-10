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

    private void ButtonMusicPlay_Click(object sender, EventArgs e)
    {
        BrowserKernel.ContinueCurrentAudioPlayback();

        this.buttonMusicPlay.Enabled = false;
        this.buttonMusicPause.Enabled = true;
        this.buttonMusicRewind.Enabled = true;
    }

    private void ButtonMusicPause_Click(object sender, EventArgs e)
    {
        BrowserKernel.PauseCurrentAudioPlayback();

        this.buttonMusicPlay.Enabled = true;
        this.buttonMusicPause.Enabled = false;
        this.buttonMusicRewind.Enabled = true;
    }

    private void ButtonMusicRewind_Click(object sender, EventArgs e)
    {
        BrowserKernel.RewindCurrentAudioPlayback();

        this.buttonMusicPlay.Enabled = false;
        this.buttonMusicPause.Enabled = true;
        this.buttonMusicRewind.Enabled = true;
    }
}
