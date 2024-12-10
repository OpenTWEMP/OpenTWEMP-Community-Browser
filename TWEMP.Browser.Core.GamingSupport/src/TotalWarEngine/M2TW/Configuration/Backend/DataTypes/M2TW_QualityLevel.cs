// <copyright file="M2TW_QualityLevel.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // Field names should not contain underscore

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;

public class M2TW_QualityLevel
{
    public const string Low = "low";
    public const string Medium = "medium";
    public const string High = "high";
    public const string Highest = "highest";

    public const string M2TW_GrassDistanceLevel_0 = "0";
    public const string M2TW_GrassDistanceLevel_1 = "25";
    public const string M2TW_GrassDistanceLevel_2 = "50";
    public const string M2TW_GrassDistanceLevel_3 = "75";

    public const string M2TW_AF_Bilinear = "bilinear";
    public const string M2TW_AF_Trilinear = "trilinear";
    public const string M2TW_AF_x2 = "2";
    public const string M2TW_AF_x4 = "4";
    public const string M2TW_AF_x8 = "8";
    public const string M2TW_AF_x16 = "16";

    public const string M2TW_AntiAliasing_OffMode = "off";
    public const string M2TW_AntiAliasing_None = "0";
    public const string M2TW_AntiAliasing_x2 = "2";
    public const string M2TW_AntiAliasing_x4 = "4";

    public const string M2TW_ShaderVersion_v1 = "1";
    public const string M2TW_ShaderVersion_v2 = "2";

    public const string M2TW_KeySet_0 = "0";
    public const string M2TW_KeySet_1 = "1";
    public const string M2TW_KeySet_2 = "2";
    public const string M2TW_KeySet_3 = "3";

    public M2TW_QualityLevel(M2TW_Quality value)
    {
        switch (value)
        {
            case M2TW_Quality.Low:
                this.Value = Low;
                break;
            case M2TW_Quality.Medium:
                this.Value = Medium;
                break;
            case M2TW_Quality.High:
                this.Value = High;
                break;
            case M2TW_Quality.Highest:
                this.Value = Highest;
                break;
            default:
                this.Value = Medium;
                break;
        }
    }

    public M2TW_QualityLevel(M2TW_GrassDistance value)
    {
        switch (value)
        {
            case M2TW_GrassDistance.Level_0:
                this.Value = M2TW_GrassDistanceLevel_0;
                break;
            case M2TW_GrassDistance.Level_1:
                this.Value = M2TW_GrassDistanceLevel_1;
                break;
            case M2TW_GrassDistance.Level_2:
                this.Value = M2TW_GrassDistanceLevel_2;
                break;
            case M2TW_GrassDistance.Level_3:
                this.Value = M2TW_GrassDistanceLevel_3;
                break;
            default:
                this.Value = M2TW_GrassDistanceLevel_1;
                break;
        }
    }

    public M2TW_QualityLevel(M2TW_AnisotropicFilteringLevel value)
    {
        switch (value)
        {
            case M2TW_AnisotropicFilteringLevel.Bilinear:
                this.Value = M2TW_AF_Bilinear;
                break;
            case M2TW_AnisotropicFilteringLevel.Trilinear:
                this.Value = M2TW_AF_Trilinear;
                break;
            case M2TW_AnisotropicFilteringLevel.AF_x2:
                this.Value = M2TW_AF_x2;
                break;
            case M2TW_AnisotropicFilteringLevel.AF_x4:
                this.Value = M2TW_AF_x4;
                break;
            case M2TW_AnisotropicFilteringLevel.AF_x8:
                this.Value = M2TW_AF_x8;
                break;
            case M2TW_AnisotropicFilteringLevel.AF_x16:
                this.Value = M2TW_AF_x16;
                break;
            default:
                this.Value = M2TW_AF_Trilinear;
                break;
        }
    }

    public M2TW_QualityLevel(M2TW_AntiAliasMode value)
    {
        switch (value)
        {
            case M2TW_AntiAliasMode.AntiAliasMode_Off:
                this.Value = M2TW_AntiAliasing_OffMode;
                break;
            case M2TW_AntiAliasMode.AntiAliasMode_x2:
                this.Value = M2TW_AntiAliasing_x2;
                break;
            case M2TW_AntiAliasMode.AntiAliasMode_x4:
                this.Value = M2TW_AntiAliasing_x4;
                break;
            default:
                this.Value = M2TW_AntiAliasing_x2;
                break;
        }
    }

    public M2TW_QualityLevel(M2TW_AntiAliasing value)
    {
        switch (value)
        {
            case M2TW_AntiAliasing.AntiAliasMode_None:
                this.Value = M2TW_AntiAliasing_None;
                break;
            case M2TW_AntiAliasing.AntiAliasMode_x2:
                this.Value = M2TW_AntiAliasing_x2;
                break;
            case M2TW_AntiAliasing.AntiAliasMode_x4:
                this.Value = M2TW_AntiAliasing_x4;
                break;
            default:
                this.Value = M2TW_AntiAliasing_x2;
                break;
        }
    }

    public M2TW_QualityLevel(M2TW_ShaderLevel value)
    {
        switch (value)
        {
            case M2TW_ShaderLevel.ShaderVersion_v1:
                this.Value = M2TW_ShaderVersion_v1;
                break;
            case M2TW_ShaderLevel.ShaderVersion_v2:
                this.Value = M2TW_ShaderVersion_v2;
                break;
            default:
                this.Value = M2TW_ShaderVersion_v1;
                break;
        }
    }

    public M2TW_QualityLevel(M2TW_KeySet value)
    {
        switch (value)
        {
            case M2TW_KeySet.KeySet_0:
                this.Value = M2TW_KeySet_0;
                break;
            case M2TW_KeySet.KeySet_1:
                this.Value = M2TW_KeySet_1;
                break;
            case M2TW_KeySet.KeySet_2:
                this.Value = M2TW_KeySet_2;
                break;
            case M2TW_KeySet.KeySet_3:
                this.Value = M2TW_KeySet_3;
                break;
            default:
                this.Value = M2TW_KeySet_0;
                break;
        }
    }

    public string Value { get; }
}
