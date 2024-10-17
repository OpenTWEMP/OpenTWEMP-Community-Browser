// <copyright file="GameSupportConfiguration.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

/// <summary>
/// Represents a general game support configuration.
/// </summary>
public class GameSupportConfiguration
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameSupportConfiguration"/> class.
    /// </summary>
    public GameSupportConfiguration()
    {
        this.TargetGameSupportProvider = new GameSupportProvider(GameEngineSupportType.M2TW);
        this.RedistributablePackages = new List<ModSupportPresetPackage>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameSupportConfiguration"/> class.
    /// </summary>
    /// <param name="provider">The game support provider type.</param>
    /// <param name="packages">The collection of mod support preset packages.</param>
    public GameSupportConfiguration(
        GameSupportProvider provider, ICollection<ModSupportPresetPackage> packages)
    {
        this.TargetGameSupportProvider = provider;
        this.RedistributablePackages = packages.ToList();
    }

    /// <summary>
    /// Gets or sets a target type of the game support provider for this configuration.
    /// </summary>
    public GameSupportProvider TargetGameSupportProvider { get; set; }

    /// <summary>
    /// Gets or sets a list of redistributable packages for this configuration.
    /// </summary>
    public List<ModSupportPresetPackage> RedistributablePackages { get; set; }

    /// <summary>
    /// Creates a test game support configuration object by default.
    /// </summary>
    /// <returns>The default instance of the <see cref="GameSupportConfiguration"/> class.</returns>
    public static GameSupportConfiguration CreateTestConfigurationByDefault()
    {
        List<ModSupportPresetPackage> packages = ModSupportPresetPackage.CreateTestPackages();
        return new GameSupportConfiguration(new GameSupportProvider(), packages);
    }

    /// <summary>
    /// Gets all redistributable mod presets from all available packages of the configuration.
    /// </summary>
    /// <returns>The list of redistributable mod preset objects.</returns>
    public List<RedistributableModPreset> GetAllRedistributablePresets()
    {
        List<RedistributableModPreset> presets = new ();

        var redistributablePackages = this.RedistributablePackages;

        foreach (ModSupportPresetPackage package in redistributablePackages)
        {
            List<RedistributableModPreset> attachedPresets = package.GetAttachedPresets();
            presets.AddRange(attachedPresets);
        }

        return presets;
    }
}
