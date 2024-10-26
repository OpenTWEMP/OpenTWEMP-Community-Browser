// <copyright file="AddonsSetupConfiguration.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Extension.AddonsSetupFramework;

using System.Xml.Serialization;

/// <summary>
/// Defines the configuration format for any Addons-Setup-Framework application.
/// </summary>
public class AddonsSetupConfiguration
{
    /// <summary>
    /// The file name for the main configuration of the current Addons-Setup-Framework application.
    /// </summary>
    public const string MainConfigFileName = "OpenTWEMP.Addons-Setup-Framework.cfg";

    /// <summary>
    /// Initializes a new instance of the <see cref="AddonsSetupConfiguration"/> class.
    /// </summary>
    public AddonsSetupConfiguration()
    {
    }

    private AddonsSetupConfiguration(string cfgFileName, string modName, string modVersion)
    {
        this.CustomConfigFileName = cfgFileName;
        this.CustomGameModificationName = modName;
        this.CustomGameModificationVersion = modVersion;
    }

    /// <summary>
    /// Gets or sets a custom configuration file path.
    /// </summary>
    [XmlElement("CustomConfigFileName")]
    public string CustomConfigFileName { get; set; }

    /// <summary>
    /// Gets or sets a name of the custom game modification.
    /// </summary>
    [XmlElement("ModName")]
    public string CustomGameModificationName { get; set; }

    /// <summary>
    /// Gets or sets a version of the custom game modification.
    /// </summary>
    [XmlElement("ModVersion")]
    public string CustomGameModificationVersion { get; set; }

    /// <summary>
    /// Creates an instanse of the <see cref="AddonsSetupConfiguration"/> class by default.
    /// </summary>
    /// <returns>Returns a new instance of the <see cref="AddonsSetupConfiguration"/> class with default values of properties.</returns>
    public static AddonsSetupConfiguration CreateByDefault()
    {
        const string customConfigFileName = ModSubmodsConfiguration.ConfigFileName;
        const string customGameModificationName = "M2TW_MODIFICATION_CUSTOM_NAME";
        const string customGameModificationVersion = "M2TW_MODIFICATION_CUSTOM_VERSION";

        return new AddonsSetupConfiguration(customConfigFileName, customGameModificationName, customGameModificationVersion);
    }
}
