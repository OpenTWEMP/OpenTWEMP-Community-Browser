// <copyright file="M2TW_AnisotropicFilteringLevel.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1602 // Enumeration items should be documented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public enum M2TW_AnisotropicFilteringLevel
{
    Bilinear,

    Trilinear,

    AF_x2,

    AF_x4,

    AF_x8,

    AF_x16,
}
