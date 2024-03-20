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
    /// <param name="targetVolumeValue">A target volume integer value.</param>
    /// <returns>
    /// Returns 'true' if the current volume value was succesfully updated else 'false'.
    /// </returns>
    public bool UpdateVolumeValue(int targetVolumeValue)
    {
        return this.UpdateVolumeValue((float)targetVolumeValue);
    }

    /// <summary>
    /// Updates the current volume value by a new volume value.
    /// </summary>
    /// <param name="targetVolumeValue">A target volume floating point value.</param>
    /// <returns>
    /// Returns 'true' if the current volume value was succesfully updated else 'false'.
    /// </returns>
    public bool UpdateVolumeValue(float targetVolumeValue)
    {
        if (this.CurrentValue != targetVolumeValue)
        {
            if (IsValidVolumeValue(targetVolumeValue))
            {
                this.CurrentValue = targetVolumeValue;
                return true;
            }
        }

        return false;
    }

    private static bool IsValidVolumeValue(float value)
    {
        if ((value < MinVolumeValue) || (value > MaxVolumeValue))
        {
            return false;
        }

        return true;
    }
}
