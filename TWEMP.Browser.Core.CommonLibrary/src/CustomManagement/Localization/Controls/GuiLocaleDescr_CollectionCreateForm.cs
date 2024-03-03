// <copyright file="GuiLocaleDescr_CollectionCreateForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization.Controls;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

// Derived class for 'CollectionCreateForm' form.
public class GuiLocaleDescr_CollectionCreateForm : FormLocaleDescription
{
    private const string KEY_CollectionCreateForm = "CollectionCreateForm";
    private const string KEY_collectionNameLabel = "collectionNameLabel";
    private const string KEY_modsSelectionLabel = "modsSelectionLabel";
    private const string KEY_buttonOK = "buttonOK";
    private const string KEY_buttonCancel = "buttonCancel";

    public GuiLocaleDescr_CollectionCreateForm()
    {
        this.FormName = "CollectionCreateForm";
        this.LocalizedControls = new List<string>
        {
            KEY_CollectionCreateForm,
            KEY_collectionNameLabel,
            KEY_modsSelectionLabel,
            KEY_buttonOK,
            KEY_buttonCancel,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_CollectionCreateForm, "Create a New Collection" },
            { KEY_collectionNameLabel, "Input a Name of a New Collection:" },
            { KEY_modsSelectionLabel, "Select Mods for a New Collection:" },
            { KEY_buttonOK, "OK" },
            { KEY_buttonCancel, "Cancel" },
        });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_CollectionCreateForm, "Создать Новую Коллекцию" },
            { KEY_collectionNameLabel, "Введите имя новой коллекции:" },
            { KEY_modsSelectionLabel, "Выберите моды для новой коллекции:" },
            { KEY_buttonOK, "Создать" },
            { KEY_buttonCancel, "Отмена" },
        });
    }
}
