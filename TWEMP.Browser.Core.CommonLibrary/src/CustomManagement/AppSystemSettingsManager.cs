// <copyright file="AppSystemSettingsManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement;

/// <summary>
/// Represents a device to manage application's system settings.
/// </summary>
public class AppSystemSettingsManager
{
    private AppSystemSettingsManager()
    {
        this.UseExperimentalFeatures = true;
    }

    /// <summary>
    /// Gets or sets a value indicating whether application uses experimental features.
    /// </summary>
    public bool UseExperimentalFeatures { get; set; }

    /// <summary>
    /// Creates a custom instance of the <see cref="AppSystemSettingsManager"/> class.
    /// </summary>
    /// <returns>Instance of the <see cref="AppSystemSettingsManager"/> class.</returns>
    public static AppSystemSettingsManager Create()
    {
        return new AppSystemSettingsManager();
    }
}
