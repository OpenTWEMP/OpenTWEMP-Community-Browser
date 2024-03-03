// <copyright file="AppLocalizationManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

public static class AppLocalizationManager
{
    private const string GuiLocaleFolderName = "locale";
    private const string GuiLocaleFileExtension = ".json";

    private static readonly string GuiLocalesHomeDirectoryPath;

    static AppLocalizationManager()
    {
        GuiLocalesHomeDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), GuiLocaleFolderName);

        if (!Directory.Exists(GuiLocalesHomeDirectoryPath))
        {
            Directory.CreateDirectory(GuiLocalesHomeDirectoryPath);
        }

        AvailableLocalizations = InitializeSupportedLocalizations();
        CurrentLocalization = InitializeLocalizationByDefault();
    }

    public static List<AppLocalization> AvailableLocalizations { get; private set; }

    public static AppLocalization CurrentLocalization { get; private set; }

    public static void SetCurrentLocalizationByName(string guiLocaleName)
    {
        if (CurrentLocalization.Name != guiLocaleName)
        {
            foreach (AppLocalization localization in AvailableLocalizations)
            {
                if (localization.Name == guiLocaleName)
                {
                    CurrentLocalization = localization;
                    break;
                }
            }
        }
    }

    public static bool IsCurrentLocalizationName(string guiLocaleName)
    {
        return CurrentLocalization.Name.Equals(guiLocaleName);
    }

    private static List<AppLocalization> InitializeSupportedLocalizations()
    {
        List<AppLocalization> supportedLocalizations = new ();

        List<string> currentLocaleFiles = FindAvailableLocalizationFiles();

        if (currentLocaleFiles.Count == 0)
        {
            CreateStandardLocalizations(supportedLocalizations);
        }
        else
        {
            supportedLocalizations = ReadObjectsFromLocaleFiles(currentLocaleFiles);
        }

        return supportedLocalizations;
    }

    private static AppLocalization InitializeLocalizationByDefault()
    {
        const string guiLocaleNameByDefault = "ENG";

        foreach (AppLocalization localization in AvailableLocalizations)
        {
            if (localization.Name == guiLocaleNameByDefault)
            {
                return localization;
            }
        }

        return AppLocalization.GenerateGuiLocaleFor_ENG();
    }

    private static List<string> FindAvailableLocalizationFiles()
    {
        var guiLocaleFiles = new List<string>();

        string[] detectedFiles = Directory.GetFiles(GuiLocalesHomeDirectoryPath);
        foreach (var file in detectedFiles)
        {
            if (file.EndsWith(GuiLocaleFileExtension))
            {
                guiLocaleFiles.Add(file);
            }
        }

        return guiLocaleFiles;
    }

    private static List<AppLocalization> ReadObjectsFromLocaleFiles(List<string> files)
    {
        var guiLocaleObjects = new List<AppLocalization>();

        foreach (var file in files)
        {
            string objectJsonText = File.ReadAllText(file);
            AppLocalization localeObject = AppLocalization.FromJsonText(objectJsonText);
            guiLocaleObjects.Add(localeObject);
        }

        return guiLocaleObjects;
    }

    private static void CreateStandardLocalizations(List<AppLocalization> localizations)
    {
        AppLocalization guiLocale_ENG = AppLocalization.GenerateGuiLocaleFor_ENG();
        AppLocalization guiLocale_RUS = AppLocalization.GenerateGuiLocaleFor_RUS();

        localizations.Add(guiLocale_ENG);
        localizations.Add(guiLocale_RUS);

        foreach (AppLocalization localization in localizations)
        {
            SerializeLocalization(localization);
        }
    }

    private static void SerializeLocalization(AppLocalization localization)
    {
        string outputFileName = GuiLocaleFolderName + '_' + localization.Name.ToLower() + GuiLocaleFileExtension;
        string outputFilePath = Path.Combine(GuiLocalesHomeDirectoryPath, outputFileName);

        using (var localeWriter = new StreamWriter(outputFilePath))
        {
            string localeObjectDump = localization.ToJsonText();
            localeWriter.WriteLine(localeObjectDump);
        }
    }
}
