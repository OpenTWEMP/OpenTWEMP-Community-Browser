// <copyright file="GuiLocaleDescr_CollectionManageForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization.Controls;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

// Derived class for 'CollectionManageForm' form.
public class GuiLocaleDescr_CollectionManageForm : LocaleDescription
{
    private const string KEY_CollectionManageForm = "CollectionManageForm";
    private const string KEY_groupBoxCollectionsDelete = "groupBoxCollectionsDelete";
    private const string KEY_collectionsSelectionLabel = "collectionsSelectionLabel";
    private const string KEY_buttonCollectionsDelete = "buttonCollectionsDelete";
    private const string KEY_buttonCollectionsSelectAll = "buttonCollectionsSelectAll";
    private const string KEY_buttonCollectionsDeselectAll = "buttonCollectionsDeselectAll";

    public GuiLocaleDescr_CollectionManageForm()
    {
        this.FormName = "CollectionManageForm";
        this.LocalizedControls = new List<string>
        {
            KEY_CollectionManageForm,
            KEY_groupBoxCollectionsDelete,
            KEY_collectionsSelectionLabel,
            KEY_buttonCollectionsDelete,
            KEY_buttonCollectionsSelectAll,
            KEY_buttonCollectionsDeselectAll,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override LocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new LocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_CollectionManageForm, "Manage Your Collections" },
            { KEY_groupBoxCollectionsDelete, "Select Collections to Delete" },
            { KEY_collectionsSelectionLabel, "Delete Selected" },
            { KEY_buttonCollectionsDelete, "Delete Selected" },
            { KEY_buttonCollectionsSelectAll, "Select All" },
            { KEY_buttonCollectionsDeselectAll, "Deselect All" },
        });
    }

    public override LocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new LocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_CollectionManageForm, "Управление Коллекциями" },
            { KEY_groupBoxCollectionsDelete, "Удаление существующих коллекций" },
            { KEY_collectionsSelectionLabel, "Выберите коллекции для удаления" },
            { KEY_buttonCollectionsDelete, "Удалить Выбранное" },
            { KEY_buttonCollectionsSelectAll, "Выбрать ВСЕ" },
            { KEY_buttonCollectionsDeselectAll, "Отменить ВСЕ" },
        });
    }
}
