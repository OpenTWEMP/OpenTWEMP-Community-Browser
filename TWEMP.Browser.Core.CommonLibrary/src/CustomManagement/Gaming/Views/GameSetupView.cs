// <copyright file="GameSetupView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

/// <summary>
/// Defines a view of a game setup which should be used by 
/// the configuration file of game installation settings.
/// </summary>
public record GameSetupView
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameSetupView"/> class.
    /// </summary>
    /// <param name="name">The name of the game setup.</param>
    /// <param name="executable">The absolute path to the executable file of the game setup.</param>
    /// <param name="modcenters">The array of absolute paths to modcenter directories of the game setup.</param>
    public GameSetupView(string name, string executable, string[] modcenters)
    {
        this.Name = name;
        this.ExecutableFilePath = executable;
        this.ModCenterDirectoryPaths = modcenters;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GameSetupView"/> class.
    /// </summary>
    /// <param name="gameSetupInfo">The view entity of the game setup.</param>
    public GameSetupView(GameSetupInfo gameSetupInfo)
    {
        this.Name = gameSetupInfo.Name;
        this.ExecutableFilePath = gameSetupInfo.ExecutableFileName!;

        List<string> modCenterDirectoryPaths = new ();

        foreach (ModCenterInfo modcenter in gameSetupInfo.AttachedModCenters)
        {
            modCenterDirectoryPaths.Add(modcenter.Location);
        }

        this.ModCenterDirectoryPaths = modCenterDirectoryPaths.ToArray();
    }

    /// <summary>
    /// Gets or sets the name of the game setup.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the absolute path to the executable file of the game setup.
    /// </summary>
    public string ExecutableFilePath { get; set; }

    /// <summary>
    /// Gets or sets the array of absolute paths to modcenter directories of the game setup.
    /// </summary>
    public string[] ModCenterDirectoryPaths { get; set; }
}
