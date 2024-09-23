// <copyright file="BrowserKernel.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

/// <summary>
/// Defines the kernel of any OpenTWEMP Community Browser implementation.
/// </summary>
public static class BrowserKernel
{
    public static bool IsEnabledLocalizationOnEnglish()
    {
        return AppLocalizationManager.IsCurrentLocalizationName(AppLocalization.LOCALE_NAME_ENG);
    }

    public static bool IsEnabledLocalizationOnRussian()
    {
        return AppLocalizationManager.IsCurrentLocalizationName(AppLocalization.LOCALE_NAME_RUS);
    }
}
