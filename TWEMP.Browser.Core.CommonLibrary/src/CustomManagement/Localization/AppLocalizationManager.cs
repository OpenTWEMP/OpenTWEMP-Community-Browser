// <copyright file="AppLocalizationManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

public class AppLocalizationManager
{
    private const string GuiLocaleFolderName = "locale";
    private const string GuiLocaleFileExtension = ".json";

    private readonly string guiLocalesHomeDirectoryPath;

    private AppLocalizationManager()
    {
        this.guiLocalesHomeDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), GuiLocaleFolderName);

        if (!Directory.Exists(this.guiLocalesHomeDirectoryPath))
        {
            Directory.CreateDirectory(this.guiLocalesHomeDirectoryPath);
        }

        this.AvailableLocalizations = this.InitializeSupportedLocalizations();
        this.CurrentLocalization = this.InitializeLocalizationByDefault();
    }

    public List<AppLocalization> AvailableLocalizations { get; private set; }

    public AppLocalization CurrentLocalization { get; private set; }

    /// <summary>
    /// Creates a custom instance of the <see cref="AppLocalizationManager"/> class.
    /// </summary>
    /// <returns>Instance of the <see cref="AppLocalizationManager"/> class.</returns>
    public static AppLocalizationManager Create()
    {
        return new AppLocalizationManager();
    }

    public void SetCurrentLocalizationByName(string guiLocaleName)
    {
        if (this.CurrentLocalization.Name != guiLocaleName)
        {
            foreach (AppLocalization localization in this.AvailableLocalizations)
            {
                if (localization.Name == guiLocaleName)
                {
                    this.CurrentLocalization = localization;
                    break;
                }
            }
        }
    }

    public bool IsCurrentLocalizationName(string guiLocaleName)
    {
        return this.CurrentLocalization.Name.Equals(guiLocaleName);
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

    private List<AppLocalization> InitializeSupportedLocalizations()
    {
        List<AppLocalization> supportedLocalizations = new ();

        List<string> currentLocaleFiles = this.FindAvailableLocalizationFiles();

        if (currentLocaleFiles.Count == 0)
        {
            this.CreateStandardLocalizations(supportedLocalizations);
        }
        else
        {
            supportedLocalizations = ReadObjectsFromLocaleFiles(currentLocaleFiles);
        }

        return supportedLocalizations;
    }

    private AppLocalization InitializeLocalizationByDefault()
    {
        const string guiLocaleNameByDefault = "ENG";

        foreach (AppLocalization localization in this.AvailableLocalizations)
        {
            if (localization.Name == guiLocaleNameByDefault)
            {
                return localization;
            }
        }

        return AppLocalization.GenerateGuiLocaleFor_ENG();
    }

    private List<string> FindAvailableLocalizationFiles()
    {
        var guiLocaleFiles = new List<string>();

        string[] detectedFiles = Directory.GetFiles(this.guiLocalesHomeDirectoryPath);
        foreach (var file in detectedFiles)
        {
            if (file.EndsWith(GuiLocaleFileExtension))
            {
                guiLocaleFiles.Add(file);
            }
        }

        return guiLocaleFiles;
    }

    private void CreateStandardLocalizations(List<AppLocalization> localizations)
    {
        AppLocalization guiLocale_ENG = AppLocalization.GenerateGuiLocaleFor_ENG();
        AppLocalization guiLocale_RUS = AppLocalization.GenerateGuiLocaleFor_RUS();

        localizations.Add(guiLocale_ENG);
        localizations.Add(guiLocale_RUS);

        foreach (AppLocalization localization in localizations)
        {
            this.SerializeLocalization(localization);
        }
    }

    private void SerializeLocalization(AppLocalization localization)
    {
        string outputFileName = GuiLocaleFolderName + '_' + localization.Name.ToLower() + GuiLocaleFileExtension;
        string outputFilePath = Path.Combine(this.guiLocalesHomeDirectoryPath, outputFileName);

        using (var localeWriter = new StreamWriter(outputFilePath))
        {
            string localeObjectDump = localization.ToJsonText();
            localeWriter.WriteLine(localeObjectDump);
        }
    }
}
