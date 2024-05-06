// <copyright file="GameCameraCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

public record GameCameraCfgSectionStateView
{
    /* Possible values: 'default', 'generals', 'rts'
    * public <M2TW_TYPE> CameraDefaultInBattle { get; set; } // "default_in_battle"
    */

    public byte CameraMove { get; set; } // "move"

    public bool CameraRestrict { get; set; } // "restrict"

    public byte CameraRotate { get; set; } // "rotate"
}
