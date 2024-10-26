// <copyright file="TestConfigurationGenerator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Extension.AddonsSetupFramework;

using System.Xml.Serialization;

public static class TestConfigurationGenerator
{
    public static void GenerateAddonsSetupConfiguration(string appHomeDirectoryPath)
    {
        string targetConfigurationFilePath = Path.Combine(appHomeDirectoryPath, AddonsSetupConfiguration.MainConfigFileName);
        AddonsSetupConfiguration targetConfiguration = AddonsSetupConfiguration.CreateByDefault();
        XmlSerializer serializer = new (targetConfiguration.GetType());

        using (FileStream stream = File.Create(targetConfigurationFilePath))
        {
            serializer.Serialize(stream, targetConfiguration);
        }
    }

    public static ModSubmodsConfiguration CreateTestConfiguration(string homeDirectoryPath, string configFileName)
    {
        const string LocaleID_RUS = "RUS";
        const string LocaleID_ENG = "ENG";
        const string LocaleID_ITA = "ITA";
        const string LocaleID_SPA = "SPA";
        const string LocaleID_DEU = "DEU";
        const string LocaleID_FRA = "FRA";
        const string LocaleID_POL = "POL";
        const string LocaleID_CHI = "CHI";

        List<ModGameLocale> supportedLocalizations = new ()
        {
            new (id: LocaleID_RUS, title: "Russian", srcDirPath: LocaleID_RUS),
            new (id: LocaleID_ENG, title: "English", srcDirPath: LocaleID_ENG),
            new (id: LocaleID_ITA, title: "Italian", srcDirPath: LocaleID_ITA),
            new (id: LocaleID_SPA, title: "Spanish", srcDirPath: LocaleID_SPA),
            new (id: LocaleID_DEU, title: "German", srcDirPath: LocaleID_DEU),
            new (id: LocaleID_FRA, title: "French", srcDirPath: LocaleID_FRA),
            new (id: LocaleID_POL, title: "Polish", srcDirPath: LocaleID_POL),
            new (id: LocaleID_CHI, title: "Chinese", srcDirPath: LocaleID_CHI),
        };

        ModSubmodsConfiguration configuration = new (
            srcDirPath: "submods", destDirPath: "data",
            modGameLocales: supportedLocalizations.ToArray());

        string configFilePath = Path.Combine(homeDirectoryPath, configFileName);
        XmlSerializer serializer = new (configuration.GetType());

        using (FileStream stream = File.Create(configFilePath))
        {
            serializer.Serialize(stream, configuration);
        }

        return configuration;
    }

    public static FileInfo[] GetAllFiles(DirectoryInfo targetDirectoryInfo)
    {
        List<FileInfo> targetFiles = new ();

        FileInfo[] files = targetDirectoryInfo.GetFiles();
        targetFiles.AddRange(files);

        DirectoryInfo[] directories = targetDirectoryInfo.GetDirectories();
        foreach (DirectoryInfo directory in directories)
        {
            FileInfo[] filesIntoDirectory = GetAllFiles(directory);
            targetFiles.AddRange(filesIntoDirectory);
        }

        return targetFiles.ToArray();
    }

    public static void PrepareTestAssets(string directoryPath, ModSubmodsConfiguration configuration)
    {
        string submodsDirectoryPath = Path.Combine(
            path1: directoryPath, path2: configuration.SourceDirectoryPath);

        if (!Directory.Exists(submodsDirectoryPath))
        {
            Directory.CreateDirectory(submodsDirectoryPath);
        }

        CreateTestGameLocalizations(submodsDirectoryPath, configuration);
    }

    private static void CreateTestGameLocalizations(string gameLocalizationsDirectoryPath, ModSubmodsConfiguration configuration)
    {
        foreach (ModGameLocale localization in configuration.SupportedLocalizations)
        {
            string customLocaleDirectoryPath = Path.Combine(
                path1: gameLocalizationsDirectoryPath,
                path2: localization.SourceDirectoryPath);

            CreateTestGameLocale(customLocaleDirectoryPath, localization);
        }
    }

    private static void CreateTestGameLocale(string gameLocaleDirectoryPath, ModGameLocale gameLocale)
    {
        const string testLocaleFileBaseName = "text_";
        const string testLocaleFileExtension = ".txt";
        const byte testLocaleFilesCount = 10;

        string testLocaleAssetsPath = Path.Combine(gameLocaleDirectoryPath, "data", "text");

        if (!Directory.Exists(testLocaleAssetsPath))
        {
            Directory.CreateDirectory(testLocaleAssetsPath);
        }

        for (byte fileIndex = 0; fileIndex < testLocaleFilesCount; fileIndex++)
        {
            string customLocaleFileName = testLocaleFileBaseName
                + gameLocale.ID
                + "_" + fileIndex.ToString()
                + testLocaleFileExtension;

            string customLocaleFilePath = Path.Combine(
                path1: testLocaleAssetsPath,
                path2: customLocaleFileName);

            if (!File.Exists(customLocaleFilePath))
            {
                File.Create(customLocaleFilePath);
            }
        }
    }
}
