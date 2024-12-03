// <copyright file="ModSubmodsConfiguration.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Extension.AddonsSetupFramework;

using System.Xml.Serialization;

public record ModSubmodsConfiguration
{
    private const string RelativePathToParentDirectoryInWinStyle = $"..\\";
    private const string RelativePathToParentDirectoryInUnixStyle = $"../";

    public const string ConfigFileName = "configuration.xml";

    public ModSubmodsConfiguration()
    {
    }

    public ModSubmodsConfiguration(string srcDirPath, string destDirPath, ModGameLocale[] modGameLocales)
    {
        this.SourceDirectoryRelativePath = srcDirPath;
        this.DestinationDirectoryRelativePath = destDirPath;
        this.SupportedLocalizations = modGameLocales;
    }

    [XmlElement("SourceDirectoryRelativePath")]
    public string SourceDirectoryRelativePath { get; set; }

    [XmlElement("DestinationDirectoryRelativePath")]
    public string DestinationDirectoryRelativePath { get; set; }

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

    public FileInfo GetDestinationFilePath(ModGameLocale modGameLocale, FileInfo fileInfo)
    {
        string sourceRelativePathToReplacement = Path.Combine(this.SourceDirectoryRelativePath, modGameLocale.ContentFolderName);
        while (IsRelativePathToParentDirectory(sourceRelativePathToReplacement))
        {
            sourceRelativePathToReplacement = GetRelativePathWithoutStartParentDirectoryLabel(sourceRelativePathToReplacement);
        }

        string targetRelativePathToReplacement = this.DestinationDirectoryRelativePath;
        while (IsRelativePathToParentDirectory(targetRelativePathToReplacement))
        {
            targetRelativePathToReplacement = GetRelativePathWithoutStartParentDirectoryLabel(targetRelativePathToReplacement);
        }

        string targetDirectoryPath = fileInfo.DirectoryName.Replace(
            oldValue: sourceRelativePathToReplacement, newValue: targetRelativePathToReplacement);
        string targetFileName = fileInfo.Name;

        string destinationFilePath = Path.Combine(targetDirectoryPath, targetFileName);
        return new FileInfo(destinationFilePath);
    }

    public DirectoryInfo GetSelectedLocalizationDirectoryInfo(ModGameLocale customLocale, string appHomeDirectoryPath)
    {
        string submodsSourceDirectoryPath = this.GetSubmodsSourceDirectoryPath(appHomeDirectoryPath);
        string customLocaleSourceDirectoryPath = Path.Combine(submodsSourceDirectoryPath, customLocale.ContentFolderName);

        return new DirectoryInfo(customLocaleSourceDirectoryPath);
    }

    private static bool IsRelativePathToParentDirectory(string path)
    {
        bool isWinPathToParentDirectory = path.StartsWith(RelativePathToParentDirectoryInWinStyle);
        bool isUnixPathToParentDirectory = path.StartsWith(RelativePathToParentDirectoryInUnixStyle);

        return isWinPathToParentDirectory || isUnixPathToParentDirectory;
    }

    private static string GetRelativePathWithoutStartParentDirectoryLabel(string path)
    {
        string startSubstringToDelete = string.Empty;

        if (path.StartsWith(RelativePathToParentDirectoryInWinStyle))
        {
            startSubstringToDelete = RelativePathToParentDirectoryInWinStyle;
        }

        if (path.StartsWith(RelativePathToParentDirectoryInUnixStyle))
        {
            startSubstringToDelete = RelativePathToParentDirectoryInUnixStyle;
        }

        return path.Remove(startIndex: 0, count: startSubstringToDelete.Length);
    }

    private string GetSubmodsSourceDirectoryPath(string appHomeDirectoryPath)
    {
        string submodsHomeDirectoryPath = appHomeDirectoryPath;
        string submodsFolderRelativePath = this.SourceDirectoryRelativePath;

        while (IsRelativePathToParentDirectory(submodsFolderRelativePath))
        {
            submodsHomeDirectoryPath = new DirectoryInfo(submodsHomeDirectoryPath).Parent.FullName;
            submodsFolderRelativePath = GetRelativePathWithoutStartParentDirectoryLabel(submodsFolderRelativePath);
        }

        return Path.Combine(submodsHomeDirectoryPath, submodsFolderRelativePath);
    }
}
