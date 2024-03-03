// <copyright file="GuiLocaleDescr_AboutProject.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization.Controls;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

// Derived class for 'AboutProjectForm' form.
public class GuiLocaleDescr_AboutProject : FormLocaleDescription
{
    private const string KEY_AboutProjectForm = "AboutProjectForm";
    private const string KEY_aboutProjectNameLabel3 = "aboutProjectNameLabel3";
    private const string KEY_aboutProjectNameLabel4 = "aboutProjectNameLabel4";

    public GuiLocaleDescr_AboutProject()
    {
        this.FormName = "AboutProjectForm";
        this.LocalizedControls = new List<string>
        {
            KEY_AboutProjectForm,
            KEY_aboutProjectNameLabel3,
            KEY_aboutProjectNameLabel4,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_AboutProjectForm, "About Program" },
            { KEY_aboutProjectNameLabel3, "Version Preview 2023.3" },
            { KEY_aboutProjectNameLabel4, "is Master_TW_DAR's initiative for M2TW community" },
        });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(this.FormName, new Dictionary<string, string>()
        {
            { KEY_AboutProjectForm, "О программе" },
            { KEY_aboutProjectNameLabel3, "Альфа-Версия 2023.3" },
            { KEY_aboutProjectNameLabel4, "новый проект Master_TW_DAR в сообществе M2TW" },
        });
    }
}
