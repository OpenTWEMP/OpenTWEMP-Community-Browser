// <copyright file="M2TWConfigDataTypes.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1602 // Enumeration items should be documented
#pragma warning disable SA1310 // Field names should not contain underscore

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public class M2TW_Boolean
{
    public const string BooleanFalse = "false";
    public const string BooleanTrue = "true";

    public const string IntegerFalse = "0";
    public const string IntegerTrue = "1";

    public const string M2TW_Deprecated_UI_False = "hide";
    public const string M2TW_Deprecated_UI_True = "show";

    public const string M2TW_Deprecated_AI_False = "skip";
    public const string M2TW_Deprecated_AI_True = "follow";

    public M2TW_Boolean(bool value)
    {
        this.BooleanValue = value ? BooleanTrue : BooleanFalse;
        this.IntegerValue = value ? IntegerTrue : IntegerFalse;
    }

    public M2TW_Boolean(M2TW_Deprecated_UI_Boolean value)
    {
        switch (value)
        {
            case M2TW_Deprecated_UI_Boolean.Hide:
                this.BooleanValue = M2TW_Deprecated_UI_False;
                this.IntegerValue = IntegerFalse;
                break;
            case M2TW_Deprecated_UI_Boolean.Show:
                this.BooleanValue = M2TW_Deprecated_UI_True;
                this.IntegerValue = IntegerTrue;
                break;
            default:
                this.BooleanValue = M2TW_Deprecated_UI_False;
                this.IntegerValue = IntegerFalse;
                break;
        }
    }

    public M2TW_Boolean(M2TW_Deprecated_AI_Boolean value)
    {
        switch (value)
        {
            case M2TW_Deprecated_AI_Boolean.Skip:
                this.BooleanValue = M2TW_Deprecated_AI_False;
                this.IntegerValue = IntegerFalse;
                break;
            case M2TW_Deprecated_AI_Boolean.Follow:
                this.BooleanValue = M2TW_Deprecated_AI_True;
                this.IntegerValue = IntegerTrue;
                break;
            default:
                this.BooleanValue = M2TW_Deprecated_AI_False;
                this.IntegerValue = IntegerFalse;
                break;
        }
    }

    public string BooleanValue { get; }

    public string IntegerValue { get; }
}

public enum M2TW_Deprecated_UI_Boolean // options from the [ui] section
{
    Hide,

    Show,
}

public enum M2TW_Deprecated_AI_Boolean // the 'ai_factions' option
{
    Skip,

    Follow,
}

public class M2TW_Integer
{
    public const byte MinValue = 0;

    public const byte MaxValue = 100;

    public const ushort ExtendedMaxValue = 10_000;

    public M2TW_Integer(byte value)
    {
        if (value > MaxValue)
        {
            this.Value = MaxValue.ToString();
        }
        else
        {
            this.Value = value.ToString();
        }
    }

    public M2TW_Integer(ushort value)
    {
        if (value > ExtendedMaxValue)
        {
            this.Value = ExtendedMaxValue.ToString();
        }
        else
        {
            this.Value = value.ToString();
        }
    }

    public string Value { get; }
}

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

public enum M2TW_Quality
{
    Low,

    Medium,

    High,

    Highest,
}

public enum M2TW_GrassDistance
{
    Level_0,

    Level_1,

    Level_2,

    Level_3,
}

public enum M2TW_AnisotropicFilteringLevel
{
    Bilinear,

    Trilinear,

    AF_x2,

    AF_x4,

    AF_x8,

    AF_x16,
}

public enum M2TW_AntiAliasMode
{
    AntiAliasMode_Off,

    AntiAliasMode_x2,

    AntiAliasMode_x4,
}

public enum M2TW_AntiAliasing
{
    AntiAliasMode_None,

    AntiAliasMode_x2,

    AntiAliasMode_x4,
}

public enum M2TW_ShaderLevel
{
    ShaderVersion_v1,

    ShaderVersion_v2,
}

public enum M2TW_KeySet
{
    KeySet_0,

    KeySet_1,

    KeySet_2,

    KeySet_3,
}

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

public enum M2TW_Size
{
    Small,

    Normal,

    Large,

    Huge,
}

public class M2TW_DisplayResolution
{
    public static readonly DisplayResolution Display_640x480;
    public static readonly DisplayResolution Display_800x600;
    public static readonly DisplayResolution Display_1024x768;
    public static readonly DisplayResolution Display_1280x720;
    public static readonly DisplayResolution Display_1280x1024;
    public static readonly DisplayResolution Display_1366x768;
    public static readonly DisplayResolution Display_1600x900;
    public static readonly DisplayResolution Display_1600x1200;
    public static readonly DisplayResolution Display_1920x1080;
    public static readonly DisplayResolution Display_2048x1536;
    public static readonly DisplayResolution Display_2560x1440;
    public static readonly DisplayResolution Display_3072x1728;
    public static readonly DisplayResolution Display_3200x1800;
    public static readonly DisplayResolution Display_3840x2160;

    private static readonly DisplayResolution[] SupportedDisplayResolutions;

    static M2TW_DisplayResolution()
    {
        Display_640x480 = new DisplayResolution(640, 480);
        Display_800x600 = new DisplayResolution(800, 600);
        Display_1024x768 = new DisplayResolution(1024, 768);
        Display_1280x720 = new DisplayResolution(1280, 720);
        Display_1280x1024 = new DisplayResolution(1280, 1024);
        Display_1366x768 = new DisplayResolution(1366, 768);
        Display_1600x900 = new DisplayResolution(1600, 900);
        Display_1600x1200 = new DisplayResolution(1600, 1200);
        Display_1920x1080 = new DisplayResolution(1920, 1080);
        Display_2048x1536 = new DisplayResolution(2048, 1536);
        Display_2560x1440 = new DisplayResolution(2560, 1440);
        Display_3072x1728 = new DisplayResolution(3072, 1728);
        Display_3200x1800 = new DisplayResolution(3200, 1800);
        Display_3840x2160 = new DisplayResolution(3840, 2160);

        SupportedDisplayResolutions = new DisplayResolution[]
        {
            Display_640x480,
            Display_800x600,
            Display_1024x768,
            Display_1280x720,
            Display_1280x1024,
            Display_1366x768,
            Display_1600x900,
            Display_1600x1200,
            Display_1920x1080,
            Display_2048x1536,
            Display_2560x1440,
            Display_3072x1728,
            Display_3200x1800,
            Display_3840x2160,
        };
    }

    public M2TW_DisplayResolution()
    {
        this.Value = $"{Display_1024x768.Width} {Display_1024x768.Height}";
    }

    public M2TW_DisplayResolution(DisplayResolution resolution)
        : this()
    {
        if (SupportedDisplayResolutions.Contains(resolution))
        {
            this.Value = $"{resolution.Width} {resolution.Height}";
        }
    }

    public string Value { get; }
}

public struct DisplayResolution
{
    public DisplayResolution(ushort width, ushort height)
    {
        this.Width = width;
        this.Height = height;
    }

    public ushort Width { get; }

    public ushort Height { get; }
}

public class M2TW_IpAddress
{
    public const string DefaultPort = "27750";

    public M2TW_IpAddress(byte octet_1, byte octet_2, byte octet_3, byte octet_4)
    {
        this.Value = $"{octet_1}.{octet_2}.{octet_3}.{octet_4}";
    }

    public string Value { get; }
}

public class M2TW_LoggingLevel
{
    public const string LogLevelError = "* error";
    public const string LogLevelTrace = "* trace";
    public const string LogLevelScriptTrace = "*script* trace";

    public M2TW_LoggingLevel(M2TW_LoggingMode value)
    {
        switch (value)
        {
            case M2TW_LoggingMode.Error:
                this.Value = LogLevelError;
                break;
            case M2TW_LoggingMode.Trace:
                this.Value = LogLevelTrace;
                break;
            case M2TW_LoggingMode.ScriptTrace:
                this.Value = LogLevelScriptTrace;
                break;
            default:
                this.Value = LogLevelError;
                break;
        }
    }

    public string Value { get; }
}

public enum M2TW_LoggingMode
{
    Error,

    Trace,

    ScriptTrace,
}

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

public enum M2TW_BattleCamera
{
    Default,

    Generals,

    RTS,
}
