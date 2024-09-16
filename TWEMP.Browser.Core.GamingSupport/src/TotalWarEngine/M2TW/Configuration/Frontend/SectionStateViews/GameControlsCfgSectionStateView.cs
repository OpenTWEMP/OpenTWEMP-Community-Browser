// <copyright file="GameControlsCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using ICustomConfigState = AbstractPlaceholders.ICustomConfigState;

public record GameControlsCfgSectionStateView : ICustomConfigState
{
    public GameControlsCfgSectionStateView()
    {
    }

    public byte CampaignScrollMaxZoom { get; set; } // "campaign_scroll_max_zoom"
    public byte CampaignScrollMinZoom { get; set; } // "campaign_scroll_min_zoom"

    public M2TW_QualityLevel? KeySet { get; set; } // "keyset" | Possible values: '0', '1', '2', '3'

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }
}
