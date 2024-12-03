// <copyright file="ColorTheme.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;

using System.Drawing;

public readonly struct ColorTheme
{
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

    public static ColorTheme CreateColorThemeByStyle(GuiStyle style)
    {
        if (style != GuiStyle.Default)
        {
            if (style == GuiStyle.Dark)
            {
                return CreateDarkColorTheme();
            }

            if (style == GuiStyle.Light)
            {
                return CreateLightColorTheme();
            }
        }

        return CreateDefaultColorTheme();
    }

    private static ColorTheme CreateDefaultColorTheme() => new (
        formBack: Color.DarkSeaGreen,
        panelsBack: Color.MediumAquamarine,
        modUIBack: Color.MediumSeaGreen,
        commonUIBack: Color.LightGreen,
        commonUIFore: Color.Black);

    private static ColorTheme CreateDarkColorTheme() => new (
        formBack: Color.DarkSlateGray,
        panelsBack: Color.LightSlateGray,
        modUIBack: Color.SlateGray,
        commonUIBack: Color.DarkGray,
        commonUIFore: Color.Snow);

    private static ColorTheme CreateLightColorTheme() => new (
        formBack: Color.SeaShell,
        panelsBack: Color.Azure,
        modUIBack: Color.AliceBlue,
        commonUIBack: Color.GhostWhite,
        commonUIFore: Color.Black);
}
