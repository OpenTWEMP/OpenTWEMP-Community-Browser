// <copyright file="GuiLocaleDescr_AddNewGameSetup.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization.Controls;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

// Derived class for 'AddNewGameSetupForm' form.
public class GuiLocaleDescr_AddNewGameSetup : FormLocaleDescription
{
    private const string KEY_AddNewGameSetupForm = "AddNewGameSetupForm";
    private const string KEY_gameSetupGroupBox = "gameSetupGroupBox";
    private const string KEY_gameSetupNameLabel = "gameSetupNameLabel";
    private const string KEY_setupNameResetButton = "setupNameResetButton";
    private const string KEY_gameExecutablePathLabel = "gameExecutablePathLabel";
    private const string KEY_gameExecutableSelectPathButton = "gameExecutableSelectPathButton";
    private const string KEY_modcentersGroupBox = "modcentersGroupBox";
    private const string KEY_modcenterAppendButton = "modcenterAppendButton";
    private const string KEY_modcenterRemoveButton = "modcenterRemoveButton";
    private const string KEY_saveButton = "saveButton";
    private const string KEY_cancelButton = "cancelButton";

    public GuiLocaleDescr_AddNewGameSetup()
    {
        this.FormName = "AddNewGameSetupForm";
        this.LocalizedControls = new List<string>
        {
            KEY_AddNewGameSetupForm,
            KEY_gameSetupGroupBox,
            KEY_gameSetupNameLabel,
            KEY_setupNameResetButton,
            KEY_gameExecutablePathLabel,
            KEY_gameExecutableSelectPathButton,
            KEY_modcentersGroupBox,
            KEY_modcenterAppendButton,
            KEY_modcenterRemoveButton,
            KEY_saveButton,
            KEY_cancelButton,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_AddNewGameSetupForm, "Add New Game Setup" },
            { KEY_gameSetupGroupBox, "Game Setup Main Settings" },
            { KEY_gameSetupNameLabel, "Define Game Setup Name" },
            { KEY_setupNameResetButton, "Reset" },
            { KEY_gameExecutablePathLabel, "Set Game Executable Path" },
            { KEY_gameExecutableSelectPathButton, "Select" },
            { KEY_modcentersGroupBox, "Configure Paths to Your ModCenter" },
            { KEY_modcenterAppendButton, "Append ModCenter" },
            { KEY_modcenterRemoveButton, "Remove ModCenter" },
            { KEY_saveButton, "OK" },
            { KEY_cancelButton, "Cancel" },
        });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_AddNewGameSetupForm, "Добавить Новую Игровую Установку" },
            { KEY_gameSetupGroupBox, "Главные Настройки Игровой Установки" },
            { KEY_gameSetupNameLabel, "Имя Установки" },
            { KEY_setupNameResetButton, "Сброс" },
            { KEY_gameExecutablePathLabel, "EXE-файл Установки" },
            { KEY_gameExecutableSelectPathButton, "Выбрать" },
            { KEY_modcentersGroupBox, "Конфигурировать Пути Мод-Центров" },
            { KEY_modcenterAppendButton, "Добавить Мод-Центр" },
            { KEY_modcenterRemoveButton, "Удалить Мод-Центр" },
            { KEY_saveButton, "Добавить" },
            { KEY_cancelButton, "Отмена" },
        });
    }
}
