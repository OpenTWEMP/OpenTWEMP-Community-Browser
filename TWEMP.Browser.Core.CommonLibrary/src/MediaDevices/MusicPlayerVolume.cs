// <copyright file="MusicPlayerVolume.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.MediaDevices;

/// <summary>
/// Represents the music playback volume value for a game music player device.
/// </summary>
public struct MusicPlayerVolume
{
    private const int MinVolumeValue = 0;
    private const int DefaultVolumeValue = 50;
    private const int MaxVolumeValue = 100;

    private const float DivisorFloatingPointValue = 100F;

    static MusicPlayerVolume()
    {
        MinValue = MinVolumeValue / DivisorFloatingPointValue;
        MaxValue = MaxVolumeValue / DivisorFloatingPointValue;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MusicPlayerVolume"/> struct.
    /// </summary>
    public MusicPlayerVolume()
    {
        this.CurrentValue = DefaultVolumeValue / DivisorFloatingPointValue;
    }

    /// <summary>
    /// Gets the minimum value for music playback volume.
    /// </summary>
    public static float MinValue { get; }

    /// <summary>
    /// Gets the maximum value for music playback volume.
    /// </summary>
    public static float MaxValue { get; }

    /// <summary>
    /// Gets the current value for music playback volume.
    /// </summary>
    public float CurrentValue { get; private set; }

    /// <summary>
    /// Updates the current volume value by a new volume value.
    /// </summary>
    /// <param name="targetVolumeValue">A target volume value.</param>
    public void UpdateVolumeValue(int targetVolumeValue)
    {
        if (targetVolumeValue != this.CurrentValue)
        {
            if ((targetVolumeValue > MinVolumeValue) && (targetVolumeValue < MinVolumeValue))
            {
                this.CurrentValue = targetVolumeValue / DivisorFloatingPointValue;
            }
        }
    }

    /// <summary>
    /// Sets the current volume value to the minimum volume value.
    /// </summary>
    public void SetMinVolumeValue()
    {
        this.SetExtremeVolumeValue(MinValue);
    }

    /// <summary>
    /// Sets the current volume value to the maximum volume value.
    /// </summary>
    public void SetMaxVolumeValue()
    {
        this.SetExtremeVolumeValue(MaxValue);
    }

    private void SetExtremeVolumeValue(float extremeVolumeValue)
    {
        if (this.CurrentValue != extremeVolumeValue)
        {
            this.CurrentValue = extremeVolumeValue;
        }
    }
}
