// <copyright file="ModCenterInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;

/// <summary>
/// Represents information about a modcenter within a game setup.
/// </summary>
public record ModCenterInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModCenterInfo"/> class.
    /// </summary>
    /// <param name="path">Modcenter's directory path.</param>
    public ModCenterInfo(string path)
    {
        DirectoryInfo directoryInfo = new (path);

        this.Location = directoryInfo.FullName;
        this.Name = directoryInfo.Name;

        this.InstalledModifications = new List<GameModificationInfo>();
    }

    /// <summary>
    /// Gets modcenter's name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets modcenter's directory path.
    /// </summary>
    public string Location { get; }

    /// <summary>
    /// Gets the list of installed game modifications for the modcenter.
    /// </summary>
    public List<GameModificationInfo> InstalledModifications { get; }
}
