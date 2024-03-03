// <copyright file="GuiLocale.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary;

using Newtonsoft.Json;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization.Controls;

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
        this.Name = name;
        this.Text = text;
        this.Content = content;
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
        return JsonConvert.DeserializeObject<GuiLocale>(targetObjectJsonText)!;
    }

    public string ToJsonText()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public FormLocaleSnapshot GetFormLocaleSnapshotByKey(string targetKey)
    {
        foreach (FormLocaleSnapshot snapshot in this.Content)
        {
            if (snapshot.FormName == targetKey)
            {
                return snapshot;
            }
        }

        return new FormLocaleSnapshot(targetKey, new Dictionary<string, string>());
    }
}
