// <copyright file="AppLocalization.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

using Newtonsoft.Json;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization.Controls;

public class AppLocalization
{
    public const string LOCALE_NAME_ENG = "ENG";
    public const string LOCALE_NAME_RUS = "RUS";

    public const string LOCALE_TEXT_ENG = "English";
    public const string LOCALE_TEXT_RUS = "Russian";

    private static List<LocaleDescription> supportedGuiLocaleDescriptions;

    static AppLocalization()
    {
        supportedGuiLocaleDescriptions = new List<LocaleDescription>()
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

    public AppLocalization(string name, string text, List<LocaleSnapshot> content)
    {
        this.Name = name;
        this.Text = text;
        this.Content = content;
    }

    public string Name { get; }

    public string Text { get; }

    public List<LocaleSnapshot> Content { get; }

    public static AppLocalization GenerateGuiLocaleFor_ENG()
    {
        var localeContent_ENG = new List<LocaleSnapshot>();
        foreach (var description in supportedGuiLocaleDescriptions)
        {
            LocaleSnapshot snapshot = description.CreateLocaleSnapshotFor_ENG();
            localeContent_ENG.Add(snapshot);
        }

        return new AppLocalization(LOCALE_NAME_ENG, LOCALE_TEXT_ENG, localeContent_ENG);
    }

    public static AppLocalization GenerateGuiLocaleFor_RUS()
    {
        var localeContent_RUS = new List<LocaleSnapshot>();
        foreach (var description in supportedGuiLocaleDescriptions)
        {
            LocaleSnapshot snapshot = description.CreateLocaleSnapshotFor_RUS();
            localeContent_RUS.Add(snapshot);
        }

        return new AppLocalization(LOCALE_NAME_RUS, LOCALE_TEXT_RUS, localeContent_RUS);
    }

    public static AppLocalization FromJsonText(string targetObjectJsonText)
    {
        return JsonConvert.DeserializeObject<AppLocalization>(targetObjectJsonText)!;
    }

    public string ToJsonText()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public LocaleSnapshot GetFormLocaleSnapshotByKey(string targetKey)
    {
        foreach (LocaleSnapshot snapshot in this.Content)
        {
            if (snapshot.FormName == targetKey)
            {
                return snapshot;
            }
        }

        return new LocaleSnapshot(targetKey, new Dictionary<string, string>());
    }
}
