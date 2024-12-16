// <copyright file="GuiLocaleDescr_ModConfigSettings.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization.Controls;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

// Derived class for 'ModConfigSettingsForm' form.
public class GuiLocaleDescr_ModConfigSettings : LocaleDescription
{
    private const string KEY_settingDescriptionLabel = "settingDescriptionLabel";
    private const string KEY_saveConfigSettingsButton = "saveConfigSettingsButton";
    private const string KEY_exportConfigSettingsButton = "exportConfigSettingsButton";
    private const string KEY_exitConfigSettingsButton = "exitConfigSettingsButton";

    public GuiLocaleDescr_ModConfigSettings()
    {
        this.FormName = "ModConfigSettingsForm";

        this.LocalizedControls = new List<string>()
        {
            KEY_settingDescriptionLabel,
            KEY_saveConfigSettingsButton,
            KEY_exportConfigSettingsButton,
            KEY_exitConfigSettingsButton,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override LocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new LocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_settingDescriptionLabel, "Configure Your Mod via Available Options" },
            { KEY_saveConfigSettingsButton, "SAVE CONFIG SETTINGS" },
            { KEY_exportConfigSettingsButton, "EXPORT CONFIG SETTINGS" },
            { KEY_exitConfigSettingsButton, "RETURN TO MAIN WINDOW" },
        });
    }

    public override LocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new LocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_settingDescriptionLabel, "Конфигурируйте Ваш мод с помощью доступных опций" },
            { KEY_saveConfigSettingsButton, "СОХРАНИТЬ КОНФИГУРАЦИЮ" },
            { KEY_exportConfigSettingsButton, "Экспортировать Конфигурацию" },
            { KEY_exitConfigSettingsButton, "Вернуться в главное окно" },
        });
    }
}
