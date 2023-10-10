// <copyright file="ColorTheme.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1602 // EnumerationItemsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.Core.CommonLibrary;

using System.Drawing;

public readonly struct ColorTheme
{
    public ColorTheme()
    {
        // Initialize description for the default color theme.
        MainFormBackColor = Color.DarkSeaGreen;
        PanelsBackColor = Color.MediumAquamarine;
        ModControlsBackColor = Color.MediumSeaGreen;
        CommonControlsBackColor = Color.LightGreen;
        CommonControlsForeColor = Color.Black;
    }

    public ColorTheme(
        Color formBack,
        Color panelsBack,
        Color modUIBack,
        Color commonUIBack,
        Color commonUIFore)
    {
        // Initialize description for a custom color theme.
        MainFormBackColor = formBack;
        PanelsBackColor = panelsBack;
        ModControlsBackColor = modUIBack;
        CommonControlsBackColor = commonUIBack;
        CommonControlsForeColor = commonUIFore;
    }

    public Color MainFormBackColor { get; }

    public Color PanelsBackColor { get; }

    public Color ModControlsBackColor { get; }

    public Color CommonControlsBackColor { get; }

    public Color CommonControlsForeColor { get; }

    public static ColorTheme SelectColorThemeByStyle(GuiStyle style)
    {
        // Initialize description for a pre-defined color theme style.
        if (style == GuiStyle.Default)
        {
            return default;
        }

        if (style == GuiStyle.Light)
        {
            return new ColorTheme(
                formBack: Color.SeaShell,
                panelsBack: Color.Azure,
                modUIBack: Color.AliceBlue,
                commonUIBack: Color.GhostWhite,
                commonUIFore: Color.Black);
        }

        if (style == GuiStyle.Dark)
        {
            return new ColorTheme(
                formBack: Color.DarkSlateGray,
                panelsBack: Color.LightSlateGray,
                modUIBack: Color.SlateGray,
                commonUIBack: Color.DarkGray,
                commonUIFore: Color.Snow);
        }

        return default;
    }
}

public enum GuiStyle
{
    Default,
    Light,
    Dark,
}
