// <copyright file="LocalizationManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

public static class LocalizationManager
{
    private const string GuiLocaleFolderName = "locale";
    private const string GuiLocaleFileExtension = ".json";

    private static readonly string GuiLocalesHomeDirectoryPath;

    static LocalizationManager()
    {
        GuiLocalesHomeDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), GuiLocaleFolderName);

        if (!Directory.Exists(GuiLocalesHomeDirectoryPath))
        {
            Directory.CreateDirectory(GuiLocalesHomeDirectoryPath);
        }

        AvailableLocalizations = InitializeSupportedLocalizations();
        CurrentLocalization = InitializeLocalizationByDefault();
    }

    public static List<GuiLocale> AvailableLocalizations { get; private set; }

    public static GuiLocale CurrentLocalization { get; private set; }

    public static void SetCurrentLocalizationByName(string guiLocaleName)
    {
        if (CurrentLocalization.Name != guiLocaleName)
        {
            foreach (GuiLocale localization in AvailableLocalizations)
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
        return Settings.CurrentLocalization.Name.Equals(guiLocaleName);
    }

    private static List<GuiLocale> InitializeSupportedLocalizations()
    {
        var supportedLocalizations = new List<GuiLocale>();

        List<string> currentLocaleFiles = FindAvailableLocalizationFiles();

        if (currentLocaleFiles.Count == 0)
        {
            CreateStandardLocalizations();
        }
        else
        {
            supportedLocalizations = ReadObjectsFromLocaleFiles(currentLocaleFiles);
        }

        return supportedLocalizations;
    }

    private static GuiLocale InitializeLocalizationByDefault()
    {
        const string guiLocaleNameByDefault = "ENG";

        foreach (GuiLocale localization in AvailableLocalizations)
        {
            if (localization.Name == guiLocaleNameByDefault)
            {
                return localization;
            }
        }

        return GuiLocale.GenerateGuiLocaleFor_ENG();
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

    private static List<GuiLocale> ReadObjectsFromLocaleFiles(List<string> files)
    {
        var guiLocaleObjects = new List<GuiLocale>();

        foreach (var file in files)
        {
            string objectJsonText = File.ReadAllText(file);
            GuiLocale localeObject = GuiLocale.FromJsonText(objectJsonText);
            guiLocaleObjects.Add(localeObject);
        }

        return guiLocaleObjects;
    }

    private static void CreateStandardLocalizations()
    {
        GuiLocale guiLocale_ENG = GuiLocale.GenerateGuiLocaleFor_ENG();
        GuiLocale guiLocale_RUS = GuiLocale.GenerateGuiLocaleFor_RUS();

        AvailableLocalizations.Add(guiLocale_ENG);
        AvailableLocalizations.Add(guiLocale_RUS);

        foreach (var localization in AvailableLocalizations)
        {
            SerializeLocalization(localization);
        }
    }

    private static void SerializeLocalization(GuiLocale localization)
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
