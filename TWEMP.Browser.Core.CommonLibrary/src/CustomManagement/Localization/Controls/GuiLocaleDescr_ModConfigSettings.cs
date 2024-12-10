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
    public GuiLocaleDescr_ModConfigSettings()
    {
        this.FormName = "ModConfigSettingsForm";
        this.LocalizedControls = new List<string>();
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override LocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new LocaleSnapshot(this.FormName, new Dictionary<string, string>()); // test
    }

    public override LocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new LocaleSnapshot(this.FormName, new Dictionary<string, string>()); // test
    }
}
