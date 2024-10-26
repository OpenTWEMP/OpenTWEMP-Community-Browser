// <copyright file="ModSubmodsConfiguration.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Extension.AddonsSetupFramework;

using System.Xml.Serialization;

public record ModSubmodsConfiguration
{
    public const string ConfigFileName = "configuration.xml";

    public ModSubmodsConfiguration()
    {
    }

    public ModSubmodsConfiguration(string srcDirPath, string destDirPath, ModGameLocale[] modGameLocales)
    {
        this.SourceDirectoryPath = srcDirPath;
        this.DestinationDirectoryPath = destDirPath;
        this.SupportedLocalizations = modGameLocales;
    }

    [XmlAttribute("SourceDirectoryRelativePath")]
    public string SourceDirectoryPath { get; set; }

    [XmlAttribute("DestinationDirectoryRelativePath")]
    public string DestinationDirectoryPath { get; set; }

    [XmlElement("Localization")]
    public ModGameLocale[] SupportedLocalizations { get; set; }

    public static string GetConfigurationFilePath(string appHomeDirectoryPath, string configFileName)
    {
        // Priority # 1: Custom Configuration File
        string appHomeParentDirectoryPath = new DirectoryInfo(appHomeDirectoryPath).Parent.FullName;
        string customConfigFilePath = Path.Combine(appHomeParentDirectoryPath, configFileName);

        if (File.Exists(customConfigFilePath))
        {
            return customConfigFilePath;
        }

        // Priority # 2: System Configuration File
        string systemConfigFilePath = Path.Combine(appHomeDirectoryPath, configFileName);

        if (File.Exists(systemConfigFilePath))
        {
            return systemConfigFilePath;
        }

        // Priority # 3: Default Configuration File
        string defaultConfigFilePath = Path.Combine(appHomeDirectoryPath, ConfigFileName);

        if (!File.Exists(defaultConfigFilePath))
        {
            TestConfigurationGenerator.CreateTestConfiguration(appHomeDirectoryPath, ConfigFileName);
        }

        return defaultConfigFilePath;
    }

    public static bool IsValidLocalizationID(string targetID, string[] validIDs)
    {
        foreach (string validID in validIDs)
        {
            if (targetID.Equals(validID))
            {
                return true;
            }
        }

        return false;
    }

    public string[] GetAvailableLocalizationIDs()
    {
        List<string> localeIDs = new List<string>();

        foreach (ModGameLocale localization in this.SupportedLocalizations)
        {
            localeIDs.Add(localization.ID);
        }

        return localeIDs.ToArray();
    }

    public ModGameLocale GetLocalizationByID(string id)
    {
        foreach (ModGameLocale localization in this.SupportedLocalizations)
        {
            if (localization.ID.Equals(id))
            {
                return localization;
            }
        }

        return null;
    }

    public FileInfo GetDestinationFilePath(ModGameLocale modGameLocale, FileInfo fileInfo) =>
        new FileInfo(fileInfo.FullName
            .Replace(oldValue: this.SourceDirectoryPath, newValue: this.DestinationDirectoryPath)
            .Replace(oldValue: modGameLocale.ID, newValue: string.Empty));
}
