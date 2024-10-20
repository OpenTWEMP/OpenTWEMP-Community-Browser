// <copyright file="BrowserKernel.API.AppLocalization.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

public static partial class BrowserKernel
{
    public static bool IsEnabledLocalizationOnEnglish()
    {
        return AppLocalizationManagerInstance.IsCurrentLocalizationName(AppLocalization.LOCALE_NAME_ENG);
    }

    public static bool IsEnabledLocalizationOnRussian()
    {
        return AppLocalizationManagerInstance.IsCurrentLocalizationName(AppLocalization.LOCALE_NAME_RUS);
    }

    public static void SetLocalizationOnEnglishAsCurrent()
    {
        AppLocalizationManagerInstance.SetCurrentLocalizationByName(AppLocalization.LOCALE_NAME_ENG);
    }

    public static void SetLocalizationOnRussianAsCurrent()
    {
        AppLocalizationManagerInstance.SetCurrentLocalizationByName(AppLocalization.LOCALE_NAME_RUS);
    }

    public static string GetTextInCurrentLocalization(string formName, string controlName)
    {
        LocaleSnapshot snapshot = AppLocalizationManagerInstance.CurrentLocalization.GetFormLocaleSnapshotByKey(formName);
        return snapshot.GetLocalizedValueByKey(controlName);
    }
}
