// <copyright file="ModSettingsSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public record ModSettingsSectionStateView : ICustomConfigState
{
    public ModSettingsSectionStateView()
    {
    }

    public string? Mod { get; set; } // "mod"

    public M2TW_Boolean? Editor { get; set; } // "editor"

    public M2TW_Boolean? FileFirst { get; set; } // "file_first"

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }

    private static M2TWGameCfgSection GetFeaturesSubSet(GameModificationInfo mod)
    {
        string subsetName = "features";

        var subsetOptions = new List<M2TWGameCfgOption>();

        subsetOptions.Add(new M2TWGameCfgOption("editor", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("mod", mod.ModCfgRelativePath!, subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static M2TWGameCfgSection GetIOSubSet()
    {
        string subsetName = "io";

        var subsetOptions = new List<M2TWGameCfgOption>();
        subsetOptions.Add(new M2TWGameCfgOption("file_first", true, subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }
}
