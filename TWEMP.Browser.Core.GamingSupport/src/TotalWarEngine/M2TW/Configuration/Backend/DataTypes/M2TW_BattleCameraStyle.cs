// <copyright file="M2TW_BattleCameraStyle.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // Field names should not contain underscore

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;

public class M2TW_BattleCameraStyle
{
    public const string Default_Camera = "default";
    public const string Generals_Camera = "generals";
    public const string RTS_Camera = "rts";

    public M2TW_BattleCameraStyle(M2TW_BattleCamera value)
    {
        switch (value)
        {
            case M2TW_BattleCamera.Default:
                this.Value = Default_Camera;
                break;
            case M2TW_BattleCamera.Generals:
                this.Value = Generals_Camera;
                break;
            case M2TW_BattleCamera.RTS:
                this.Value = RTS_Camera;
                break;
            default:
                this.Value = Default_Camera;
                break;
        }
    }

    public string Value { get; }
}
