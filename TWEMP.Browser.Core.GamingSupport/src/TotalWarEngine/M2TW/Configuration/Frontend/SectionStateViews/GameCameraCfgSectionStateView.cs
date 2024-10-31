// <copyright file="GameCameraCfgSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;

public record GameCameraCfgSectionStateView : ICustomConfigState
{
    private const string CameraConfigSwitch = "camera";

    public const string CameraDefaultInBattleTextId = "default_in_battle";
    public const string CameraMoveTextId = "move";
    public const string CameraRestrictTextId = "restrict";
    public const string CameraRotateTextId = "rotate";

    public GameCameraCfgSectionStateView()
    {
    }

    public M2TW_BattleCameraStyle? CameraDefaultInBattle { get; set; } // "default_in_battle"

    public M2TW_Integer? CameraMove { get; set; } // "move"

    public M2TW_Boolean? CameraRestrict { get; set; } // "restrict"

    public M2TW_Integer? CameraRotate { get; set; } // "rotate"

    public static GameCameraCfgSectionStateView CreateByDefault()
    {
        return new GameCameraCfgSectionStateView
        {
            CameraDefaultInBattle = new M2TW_BattleCameraStyle(M2TW_BattleCamera.RTS),
            CameraMove = new M2TW_Integer(70),
            CameraRestrict = new M2TW_Boolean(false),
            CameraRotate = new M2TW_Integer(30),
        };
    }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        M2TWGameCfgOption cameraDefaultInBattleOption = new (
            name: CameraDefaultInBattleTextId, value: this.CameraDefaultInBattle!.Value, section: CameraConfigSwitch);

        M2TWGameCfgOption cameraMoveOption = new (
            name: CameraMoveTextId, value: this.CameraMove!.Value, section: CameraConfigSwitch);

        M2TWGameCfgOption cameraRestrictOption = new (
            name: CameraRestrictTextId, value: this.CameraRestrict!.BooleanValue, section: CameraConfigSwitch);

        M2TWGameCfgOption cameraRotateOption = new (
            name: CameraRotateTextId, value: this.CameraRotate!.Value, section: CameraConfigSwitch);

        M2TWGameCfgOption[] cameraCfgOptions =
        {
            cameraDefaultInBattleOption,
            cameraMoveOption,
            cameraRestrictOption,
            cameraRotateOption,
        };

        GameCfgSection cameraCfgSection = new M2TWGameCfgSection(CameraConfigSwitch, cameraCfgOptions);
        return new GameCfgSection[] { cameraCfgSection };
    }
}
