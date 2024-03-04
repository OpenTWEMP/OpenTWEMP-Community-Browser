// <copyright file="AppSystemSettingsManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement;

/// <summary>
/// Represents a device to manage application's system settings.
/// </summary>
public static class AppSystemSettingsManager
{
    static AppSystemSettingsManager()
    {
        UseExperimentalFeatures = true;
    }

    /// <summary>
    /// Gets or sets a value indicating whether application uses experimental features.
    /// </summary>
    public static bool UseExperimentalFeatures { get; set; }
}
