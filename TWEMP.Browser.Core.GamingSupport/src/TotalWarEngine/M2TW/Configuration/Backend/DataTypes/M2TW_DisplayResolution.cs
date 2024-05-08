// <copyright file="M2TW_DisplayResolution.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // Field names should not contain underscore

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

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
