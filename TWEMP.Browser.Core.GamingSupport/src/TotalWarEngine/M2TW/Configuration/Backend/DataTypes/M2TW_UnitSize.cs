// <copyright file="M2TW_UnitSize.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;

public class M2TW_UnitSize
{
    public const string Small = "small";
    public const string Normal = "norma";
    public const string Large = "large";
    public const string Huge = "huge";

    public M2TW_UnitSize(M2TW_Size value)
    {
        switch (value)
        {
            case M2TW_Size.Small:
                this.Value = Small;
                break;
            case M2TW_Size.Normal:
                this.Value = Normal;
                break;
            case M2TW_Size.Large:
                this.Value = Large;
                break;
            case M2TW_Size.Huge:
                this.Value = Huge;
                break;
            default:
                this.Value = Normal;
                break;
        }
    }

    public string Value { get; }
}
