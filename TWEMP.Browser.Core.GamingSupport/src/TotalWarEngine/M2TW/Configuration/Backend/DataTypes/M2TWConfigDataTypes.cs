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

    public M2TW_Boolean(bool value)
    {
        this.BooleanValue = value ? BooleanTrue : BooleanFalse;
        this.IntegerValue = value ? IntegerTrue : IntegerFalse;
    }

    public string BooleanValue { get; }

    public string IntegerValue { get; }
}

public class M2TW_Integer
{
    public const byte MinValue = 0;

    public const byte MaxValue = 100;

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

    public string Value { get; }
}

public class M2TW_QualityLevel
{
    public const string Low = "low";
    public const string Medium = "medium";
    public const string High = "high";
    public const string Highest = "highest";

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

    public string Value { get; }
}

public enum M2TW_Quality
{
    Low,

    Medium,

    High,

    Highest,
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
