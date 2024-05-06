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
}
