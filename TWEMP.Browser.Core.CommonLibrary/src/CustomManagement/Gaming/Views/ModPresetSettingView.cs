// <copyright file="ModPresetSettingView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

/// <summary>
/// Defines a mod preset setting entity as a shared view which should be used when creating more complex view entities.
/// </summary>
public record ModPresetSettingView
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModPresetSettingView"/> class.
    /// </summary>
    /// <param name="idView">The mod preset setting identifier entity for this view.</param>
    /// <param name="redistributablePresetGuid">The GUID of a redistributable preset
    /// attached to the current mod preset setting.</param>
    /// <param name="useCustomizablePreset">The value indicating whether
    /// the current mod preset setting uses a customizable preset.</param>
    public ModPresetSettingView(GameModificationIdView idView, Guid redistributablePresetGuid, bool useCustomizablePreset)
    {
        this.Id = idView;
        this.RedistributablePresetGuid = redistributablePresetGuid;
        this.UseCustomizablePreset = useCustomizablePreset;
    }

    /// <summary>
    /// Gets the mod preset setting identifier.
    /// </summary>
    public GameModificationIdView Id { get; }

    /// <summary>
    /// Gets the GUID of a redistributable preset attached to the current mod preset setting.
    /// </summary>
    public Guid RedistributablePresetGuid { get; }

    /// <summary>
    /// Gets a value indicating whether the current mod preset setting uses a customizable preset.
    /// </summary>
    public bool UseCustomizablePreset { get; }
}
