// <copyright file="M2TW_DisplayResolution.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // Field names should not contain underscore

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public class M2TW_DisplayResolution
{
    public const string W640_H480 = "640 x 480";
    public const string W800_H600 = "800 x 600";
    public const string W1024_H768 = "1024 x 768";
    public const string W1280_H720 = "1280 x 720";
    public const string W1280_H1024 = "1280 x 1024";
    public const string W1366_H768 = "1366 x 768";
    public const string W1600_H900 = "1600 x 900";
    public const string W1600_H1200 = "1600 x 1200";
    public const string W1920_H1080 = "1920 x 1080";
    public const string W2048_H1536 = "2048 x 1536";
    public const string W2560_H1440 = "2560 x 1440";
    public const string W3072_H1728 = "3072 x 1728";
    public const string W3200_H1800 = "3200 x 1800";
    public const string W3840_H2160 = "3840 x 2160";

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

    public M2TW_DisplayResolution(string resolution)
        : this()
    {
        foreach (DisplayResolution element in SupportedDisplayResolutions)
        {
            string value = $"{element.Width} {element.Height}";

            if (value.Equals(resolution))
            {
                this.Value = value;
                break;
            }
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
