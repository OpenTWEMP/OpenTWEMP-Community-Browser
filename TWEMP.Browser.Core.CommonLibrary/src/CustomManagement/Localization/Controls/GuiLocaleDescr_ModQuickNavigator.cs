// <copyright file="GuiLocaleDescr_ModQuickNavigator.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization.Controls;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

// Derived class for 'ModQuickNavigatorForm' form.
public class GuiLocaleDescr_ModQuickNavigator : LocaleDescription
{
    private const string KEY_ModQuickNavigatorForm = "ModQuickNavigatorForm";
    private const string KEY_labelCommonInfo = "labelCommonInfo";
    private const string KEY_formExitButton = "formExitButton";

    public GuiLocaleDescr_ModQuickNavigator()
    {
        this.FormName = "ModQuickNavigatorForm";

        this.LocalizedControls = new List<string>
        {
            KEY_ModQuickNavigatorForm,
            KEY_labelCommonInfo,
            KEY_formExitButton,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override LocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new LocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_ModQuickNavigatorForm, "Mod Quick Navigation" },
            { KEY_labelCommonInfo, "Navigate to specified mod folder by pressing the following buttons" },
            { KEY_formExitButton, "CLOSE" },
        });
    }

    public override LocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new LocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_ModQuickNavigatorForm, "Быстрая Мод-Навигация" },
            { KEY_labelCommonInfo, "Перейти в указанную мод-директорию с помощью следующих кнопок" },
            { KEY_formExitButton, "ЗАКРЫТЬ" },
        });
    }
}
