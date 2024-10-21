// <copyright file="GameControlsCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;

public record GameControlsCfgSectionStateView : ICustomConfigState
{
    private const string ControlsConfigSwitch = "controls";

    public const string CampaignScrollMaxZoomTextId = "campaign_scroll_max_zoom";
    public const string CampaignScrollMinZoomTextId = "campaign_scroll_min_zoom";
    public const string KeySetTextId = "keyset";

    public GameControlsCfgSectionStateView()
    {
    }

    public byte CampaignScrollMaxZoom { get; set; } // "campaign_scroll_max_zoom"
    public byte CampaignScrollMinZoom { get; set; } // "campaign_scroll_min_zoom"

    public M2TW_QualityLevel? KeySet { get; set; } // "keyset" | Possible values: '0', '1', '2', '3'

    public static GameControlsCfgSectionStateView CreateByDefault()
    {
        return new GameControlsCfgSectionStateView
        {
            CampaignScrollMaxZoom = Convert.ToByte(30),
            CampaignScrollMinZoom = Convert.ToByte(30),
            KeySet = new M2TW_QualityLevel(M2TW_KeySet.KeySet_0),
        };
    }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        M2TWGameCfgOption campaignScrollMaxZoomOption = new (
            name: CampaignScrollMaxZoomTextId, value: this.CampaignScrollMaxZoom, section: ControlsConfigSwitch);

        M2TWGameCfgOption campaignScrollMinZoomOption = new (
            name: CampaignScrollMinZoomTextId, value: this.CampaignScrollMinZoom, section: ControlsConfigSwitch);

        M2TWGameCfgOption keySetOption = new (
            name: KeySetTextId, value: this.KeySet!, section: ControlsConfigSwitch);

        M2TWGameCfgOption[] controlsCfgOptions =
        {
            campaignScrollMaxZoomOption,
            campaignScrollMinZoomOption,
            keySetOption,
        };

        GameCfgSection controlsCfgSection = new M2TWGameCfgSection(ControlsConfigSwitch, controlsCfgOptions);
        return new GameCfgSection[] { controlsCfgSection };
    }
}
