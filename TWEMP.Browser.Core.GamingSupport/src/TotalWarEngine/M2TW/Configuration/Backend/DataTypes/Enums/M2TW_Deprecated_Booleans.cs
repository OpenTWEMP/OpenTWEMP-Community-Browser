// <copyright file="M2TW_Deprecated_Booleans.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1602 // Enumeration items should be documented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public enum M2TW_Deprecated_UI_Boolean // options from the [ui] section
{
    Hide,

    Show,
}

public enum M2TW_Deprecated_AI_Boolean // the 'ai_factions' option
{
    Skip,

    Follow,
}
