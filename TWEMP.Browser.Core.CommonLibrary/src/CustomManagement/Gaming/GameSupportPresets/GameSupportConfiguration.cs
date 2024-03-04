// <copyright file="GameSupportConfiguration.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

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
        this.CurrentGameSupportProvider = new GameSupportProvider();
        this.ModSupportPresetPackages = ModSupportPresetPackage.CreateTestPackages();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameSupportConfiguration"/> class.
    /// </summary>
    /// <param name="provider">The game support provider type.</param>
    /// <param name="packages">The collection of mod support preset packages.</param>
    public GameSupportConfiguration(
        GameSupportProvider provider, ICollection<ModSupportPresetPackage> packages)
    {
        this.CurrentGameSupportProvider = provider;
        this.ModSupportPresetPackages = packages;
    }

    public GameSupportProvider CurrentGameSupportProvider { get; set; }

    public ICollection<ModSupportPresetPackage> ModSupportPresetPackages { get; set; }
}
