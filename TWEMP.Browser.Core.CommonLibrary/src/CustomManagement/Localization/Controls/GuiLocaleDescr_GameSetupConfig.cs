// <copyright file="GuiLocaleDescr_GameSetupConfig.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization.Controls;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

// Derived class for 'GameSetupConfigForm' form.
public class GuiLocaleDescr_GameSetupConfig : FormLocaleDescription
{
    private const string KEY_GameSetupConfigForm = "GameSetupConfigForm";
    private const string KEY_setupViewButton = "setupViewButton";
    private const string KEY_setupPathAddButton = "setupPathAddButton";
    private const string KEY_setupPathDeleteButton = "setupPathDeleteButton";
    private const string KEY_allPathsClearButton = "allPathsClearButton";
    private const string KEY_formOkButton = "formOkButton";

    public GuiLocaleDescr_GameSetupConfig()
    {
        this.FormName = "GameSetupConfigForm";
        this.LocalizedControls = new List<string>
        {
            KEY_GameSetupConfigForm,
            KEY_setupViewButton,
            KEY_setupPathAddButton,
            KEY_setupPathDeleteButton,
            KEY_allPathsClearButton,
            KEY_formOkButton,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_GameSetupConfigForm, "Game Setup Settings" },
            { KEY_setupViewButton, "VIEW GAME SETUP INFO" },
            { KEY_setupPathAddButton, "ADD SETUP PATH" },
            { KEY_setupPathDeleteButton, "DELETE SETUP PATH" },
            { KEY_allPathsClearButton, "CLEAR ALL PATHS" },
            { KEY_formOkButton, "OK" },
        });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_GameSetupConfigForm, "Настройка Игровой Установки" },
            { KEY_setupViewButton, "Сведения об Установке" },
            { KEY_setupPathAddButton, "Добавить Установку" },
            { KEY_setupPathDeleteButton, "Удалить Установку" },
            { KEY_allPathsClearButton, "Очистить Список Установок" },
            { KEY_formOkButton, "СОХРАНИТЬ" },
        });
    }
}
