// <copyright file="ModContentInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public record ModContentInfo
{
    public ModContentInfo(string logoFilePath, string musicFilePath)
    {
        this.LogotypeImage = logoFilePath;
        this.BackgroundSoundTrack = musicFilePath;
    }

    public string LogotypeImage { get; set; }

    public string BackgroundSoundTrack { get; set; }
}
