// <copyright file="GameUICfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

public record GameUICfgSectionStateView : ICustomConfigState
{
    public bool UiSaCards { get; set; } // "SA_cards" | 'show' or 'hide'

    public bool UiButtons { get; set; } // "buttons" | 'show' or 'hide'

    public bool UiFullBattleHud { get; set; } // "full_battle_HUD"

    public bool UiRadar { get; set; } // "radar" | 'show' or 'hide'

    public bool UiShowTooltips { get; set; } // "show_tooltips"

    public bool UiUnitCards { get; set; } // "unit_cards" | 'show' or 'hide'

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }

    private static M2TWGameCfgSection GetUISubSet()
    {
        string subsetName = "ui";

        var subsetOptions = new List<M2TWGameCfgOption>();

        subsetOptions.Add(new M2TWGameCfgOption("full_battle_HUD", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("show_tooltips", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("buttons", "slide", subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("radar", "slide", subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("unit_cards", "slide", subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("SA_cards", "slide", subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }
}
