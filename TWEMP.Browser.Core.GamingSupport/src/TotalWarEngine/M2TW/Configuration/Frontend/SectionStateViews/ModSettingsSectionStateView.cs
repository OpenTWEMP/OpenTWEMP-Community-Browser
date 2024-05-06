// <copyright file="ModSettingsSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

public record ModSettingsSectionStateView : ICustomConfigState
{
    public string? Mod { get; set; } // "mod"

    public bool Editor { get; set; } // "editor"

    public bool FileFirst { get; set; } // "file_first"

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }
}
