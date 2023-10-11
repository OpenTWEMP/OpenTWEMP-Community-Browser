// <copyright file="LocalizationManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary;

using Newtonsoft.Json;

public class GuiLocale
{
    public const string LOCALE_NAME_ENG = "ENG";
    public const string LOCALE_NAME_RUS = "RUS";
    public const string LOCALE_TEXT_ENG = "English";
    public const string LOCALE_TEXT_RUS = "Russian";

    private static List<FormLocaleDescription> supportedGuiLocaleDescriptions;

    static GuiLocale()
    {
        supportedGuiLocaleDescriptions = new List<FormLocaleDescription>()
        {
            new GuiLocaleDescr_MainBrowser(),
            new GuiLocaleDescr_AppSettings(),
            new GuiLocaleDescr_GameSetupConfig(),
            new GuiLocaleDescr_AddNewGameSetup(),
            new GuiLocaleDescr_CollectionManageForm(),
            new GuiLocaleDescr_CollectionCreateForm(),
            new GuiLocaleDescr_ModConfigSettings(),
            new GuiLocaleDescr_ModQuickNavigator(),
            new GuiLocaleDescr_AboutProject(),
        };
    }

    public GuiLocale(string name, string text, List<FormLocaleSnapshot> content)
    {
        Name = name;
        Text = text;
        Content = content;
    }

    public string Name { get; }

    public string Text { get; }

    public List<FormLocaleSnapshot> Content { get; }

    public static GuiLocale GenerateGuiLocaleFor_ENG()
    {
        var localeContent_ENG = new List<FormLocaleSnapshot>();
        foreach (var description in supportedGuiLocaleDescriptions)
        {
            FormLocaleSnapshot snapshot = description.CreateLocaleSnapshotFor_ENG();
            localeContent_ENG.Add(snapshot);
        }

        return new GuiLocale(LOCALE_NAME_ENG, LOCALE_TEXT_ENG, localeContent_ENG);
    }

    public static GuiLocale GenerateGuiLocaleFor_RUS()
    {
        var localeContent_RUS = new List<FormLocaleSnapshot>();
        foreach (var description in supportedGuiLocaleDescriptions)
        {
            FormLocaleSnapshot snapshot = description.CreateLocaleSnapshotFor_RUS();
            localeContent_RUS.Add(snapshot);
        }

        return new GuiLocale(LOCALE_NAME_RUS, LOCALE_TEXT_RUS, localeContent_RUS);
    }

    public static GuiLocale FromJsonText(string targetObjectJsonText)
    {
        return JsonConvert.DeserializeObject<GuiLocale>(targetObjectJsonText) !;
    }

    public string ToJsonText()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public FormLocaleSnapshot GetFormLocaleSnapshotByKey(string targetKey)
    {
        foreach (FormLocaleSnapshot snapshot in Content)
        {
            if (snapshot.FormName == targetKey)
            {
                return snapshot;
            }
        }

        return new FormLocaleSnapshot(targetKey, new Dictionary<string, string>());
    }
}

public class FormLocaleSnapshot
{
    public FormLocaleSnapshot(string formName, Dictionary<string, string> formContent)
    {
        FormName = formName;
        FormContent = formContent;
    }

    public string FormName { get; }

    public Dictionary<string, string> FormContent { get; }

    public string GetLocalizedValueByKey(string targetKey)
    {
        if (FormContent.ContainsKey(targetKey))
        {
            return FormContent[targetKey];
        }

        return string.Empty;
    }
}

public interface ICanChangeMyLocalization
{
    public void SetupCurrentLocalizationForGUIControls();
}

public static class LocalizationManager
{
    private const string GuiLocaleFolderName = "locale";
    private const string GuiLocaleFileExtension = ".json";

    private static readonly string GuiLocalesHomeDirectoryPath;
    private static List<GuiLocale> availableLocalizations;

    static LocalizationManager()
    {
        GuiLocalesHomeDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), GuiLocaleFolderName);

        if (!Directory.Exists(GuiLocalesHomeDirectoryPath))
        {
            Directory.CreateDirectory(GuiLocalesHomeDirectoryPath);
        }

        availableLocalizations = new List<GuiLocale>();
    }

    public static bool IsCurrentLocalizationName(string guiLocaleName)
    {
        return Settings.CurrentLocalization.Name.Equals(guiLocaleName);
    }

    public static List<GuiLocale> GetSupportedLocalizations()
    {
        List<string> currentLocaleFiles = FindAvailableLocalizationFiles();

        if (currentLocaleFiles.Count == 0)
        {
            CreateStandardLocalizations();
        }
        else
        {
            List<GuiLocale> localeObjects = ReadObjectsFromLocaleFiles(currentLocaleFiles);
            availableLocalizations = localeObjects;
        }

        return availableLocalizations;
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

        availableLocalizations.Add(guiLocale_ENG);
        availableLocalizations.Add(guiLocale_RUS);

        foreach (var localization in availableLocalizations)
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
