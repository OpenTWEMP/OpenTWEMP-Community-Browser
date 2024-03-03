// <copyright file="GuiLocaleDescr_AppSettings.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization.Controls;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

// Derived class for 'ApplicationSettingsForm' form.
public class GuiLocaleDescr_AppSettings : LocaleDescription
{
    private const string KEY_This = "AppSettingsForm";

    private const string KEY_appColorThemeGroupBox = "appColorThemeGroupBox";
    private const string KEY_uiStyleByDefaultThemeRadioButton = "uiStyleByDefaultThemeRadioButton";
    private const string KEY_uiStyleByLightThemeRadioButton = "uiStyleByLightThemeRadioButton";
    private const string KEY_uiStyleByDarkThemeRadioButton = "uiStyleByDarkThemeRadioButton";

    private const string KEY_appLocalizationGroupBox = "appLocalizationGroupBox";
    private const string KEY_enableEngLocaleRadioButton = "enableEngLocaleRadioButton";
    private const string KEY_enableRusLocaleRadioButton = "enableRusLocaleRadioButton";

    private const string KEY_appFeaturesGroupBox = "appFeaturesGroupBox";
    private const string KEY_activatePresetsCheckBox = "activatePresetsCheckBox";

    private const string KEY_saveAppSettingsButton = "saveAppSettingsButton";
    private const string KEY_exitAppSettingsButton = "exitAppSettingsButton";

    public GuiLocaleDescr_AppSettings()
    {
        this.FormName = "AppSettingsForm";

        this.LocalizedControls = new List<string>()
        {
            KEY_This,
            KEY_appColorThemeGroupBox,
            KEY_uiStyleByDefaultThemeRadioButton,
            KEY_uiStyleByLightThemeRadioButton,
            KEY_uiStyleByDarkThemeRadioButton,

            KEY_appLocalizationGroupBox,
            KEY_enableEngLocaleRadioButton,
            KEY_enableRusLocaleRadioButton,

            KEY_appFeaturesGroupBox,
            KEY_activatePresetsCheckBox,

            KEY_saveAppSettingsButton,
            KEY_exitAppSettingsButton,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override LocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new LocaleSnapshot(this.FormName, new Dictionary<string, string>()
            {
                { KEY_This, "Application Settings" },
                { KEY_appColorThemeGroupBox, "Select GUI style theme" },
                { KEY_uiStyleByDefaultThemeRadioButton, "Standard Theme (by default)" },
                { KEY_uiStyleByLightThemeRadioButton, "Light Theme" },
                { KEY_uiStyleByDarkThemeRadioButton, "Dark Theme" },
                { KEY_appLocalizationGroupBox, "Select GUI language" },
                { KEY_enableEngLocaleRadioButton, "ENGLISH (by default)" },
                { KEY_enableRusLocaleRadioButton, "RUSSIAN (in progress)" },
                { KEY_appFeaturesGroupBox, "Experimental Settings" },
                { KEY_activatePresetsCheckBox, "Use Custom Presets to Initialize Your Mods" },
                { KEY_saveAppSettingsButton, "OK" },
                { KEY_exitAppSettingsButton, "CANCEL" },
            });
    }

    public override LocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new LocaleSnapshot(this.FormName, new Dictionary<string, string>()
            {
                { KEY_This, "Настройки Программы" },
                { KEY_appColorThemeGroupBox, "Выберите тему GUI программы" },
                { KEY_uiStyleByDefaultThemeRadioButton, "Стандартная тема (по умолчанию)" },
                { KEY_uiStyleByLightThemeRadioButton, "Светлая тема" },
                { KEY_uiStyleByDarkThemeRadioButton, "Темная тема" },
                { KEY_appLocalizationGroupBox, "Выберите язык GUI программы" },
                { KEY_enableEngLocaleRadioButton, "Английский (по умолчанию)" },
                { KEY_enableRusLocaleRadioButton, "Русский (в процессе)" },
                { KEY_appFeaturesGroupBox, "Экспериментальные настройки программы" },
                { KEY_activatePresetsCheckBox, "Использовать пользовательские предустановки для инициализации Ваших модификаций" },
                { KEY_saveAppSettingsButton, "СОХРАНИТЬ" },
                { KEY_exitAppSettingsButton, "ОТМЕНА" },
            });
    }
}
