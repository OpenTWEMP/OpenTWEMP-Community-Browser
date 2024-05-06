// <copyright file="GameControlsCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

public record GameControlsCfgSectionStateView
{
    public byte CampaignScrollMaxZoom { get; set; } // "campaign_scroll_max_zoom"
    public byte CampaignScrollMinZoom { get; set; } // "campaign_scroll_min_zoom"

/*
    Possible values: '0', '1', '2', '3'
    public const string KeySet { get; set; } // "keyset"
*/
}
