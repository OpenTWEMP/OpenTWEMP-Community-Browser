// <copyright file="ModDiagnosticSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

public record ModDiagnosticSectionStateView
{
    public string? LogTo { get; set; } // "to";

    public bool ValidatorLogLevel1 { get; set; }

    public bool ValidatorLogLevel2 { get; set; }

    public bool ValidatorLogLevel3 { get; set; }
}
