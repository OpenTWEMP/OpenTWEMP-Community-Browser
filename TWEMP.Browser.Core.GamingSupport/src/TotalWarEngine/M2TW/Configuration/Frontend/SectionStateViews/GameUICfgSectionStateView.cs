// <copyright file="GameUICfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public record GameUICfgSectionStateView : ICustomConfigState
{
    private const string UIConfigSwitch = "ui";

    public const string UiSaCardsTextId = "SA_cards";
    public const string UiButtonsTextId = "buttons";
    public const string UiFullBattleHudTextId = "full_battle_HUD";
    public const string UiRadarTextId = "radar";
    public const string UiShowTooltipsTextId = "show_tooltips";
    public const string UiUnitCardsTextId = "unit_cards";

    public GameUICfgSectionStateView()
    {
    }

    public M2TW_Boolean? UiSaCards { get; set; } // "SA_cards" | 'show' or 'hide'

    public M2TW_Boolean? UiButtons { get; set; } // "buttons" | 'show' or 'hide'

    public M2TW_Boolean? UiFullBattleHud { get; set; } // "full_battle_HUD"

    public M2TW_Boolean? UiRadar { get; set; } // "radar" | 'show' or 'hide'

    public M2TW_Boolean? UiShowTooltips { get; set; } // "show_tooltips"

    public M2TW_Boolean? UiUnitCards { get; set; } // "unit_cards" | 'show' or 'hide'

    public static GameUICfgSectionStateView CreateByDefault()
    {
        return new GameUICfgSectionStateView
        {
            UiSaCards = new M2TW_Boolean(M2TW_Deprecated_UI_Boolean.Show),
            UiButtons = new M2TW_Boolean(M2TW_Deprecated_UI_Boolean.Show),
            UiFullBattleHud = new M2TW_Boolean(true),
            UiRadar = new M2TW_Boolean(M2TW_Deprecated_UI_Boolean.Show),
            UiShowTooltips = new M2TW_Boolean(true),
            UiUnitCards = new M2TW_Boolean(M2TW_Deprecated_UI_Boolean.Show),
        };
    }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        M2TWGameCfgOption uiSaCardsOption = new (
            name: UiSaCardsTextId, value: this.UiSaCards!, section: UIConfigSwitch);

        M2TWGameCfgOption uiButtonsOption = new (
            name: UiButtonsTextId, value: this.UiButtons!, section: UIConfigSwitch);

        M2TWGameCfgOption uiFullBattleHudOption = new (
            name: UiFullBattleHudTextId, value: this.UiFullBattleHud!, section: UIConfigSwitch);

        M2TWGameCfgOption uiRadarOption = new (
            name: UiRadarTextId, value: this.UiRadar!, section: UIConfigSwitch);

        M2TWGameCfgOption uiShowTooltipsOption = new (
            name: UiShowTooltipsTextId, value: this.UiShowTooltips!, section: UIConfigSwitch);

        M2TWGameCfgOption uiUnitCardsOption = new (
            name: UiUnitCardsTextId, value: this.UiUnitCards!, section: UIConfigSwitch);

        M2TWGameCfgOption[] uiCfgOptions =
        {
            uiSaCardsOption,
            uiButtonsOption,
            uiFullBattleHudOption,
            uiRadarOption,
            uiShowTooltipsOption,
            uiUnitCardsOption,
        };

        GameCfgSection uiCfgSection = new M2TWGameCfgSection(UIConfigSwitch, uiCfgOptions);
        return new GameCfgSection[] { uiCfgSection };
    }
}
