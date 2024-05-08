// <copyright file="GameCameraCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

public record GameCameraCfgSectionStateView : ICustomConfigState
{
    public GameCameraCfgSectionStateView()
    {
    }

    public M2TW_BattleCameraStyle? CameraDefaultInBattle { get; set; } // "default_in_battle"

    public M2TW_Integer? CameraMove { get; set; } // "move"

    public M2TW_Boolean? CameraRestrict { get; set; } // "restrict"

    public M2TW_Integer? CameraRotate { get; set; } // "rotate"

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }
}
