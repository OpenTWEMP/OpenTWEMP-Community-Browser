// <copyright file="BrowserKernel.API.AppGuiStyle.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

public static partial class BrowserKernel
{
    public static GuiStyle CurrentGUIStyle
    {
        get
        {
            return AppGuiStyleManagerInstance.CurrentStyle;
        }

        set
        {
            AppGuiStyleManagerInstance.CurrentStyle = value;
        }
    }

    public static ColorTheme SelectCurrentColorTheme()
    {
        return AppGuiStyleManagerInstance.GetCurrentColorTheme();
    }

    public static ColorTheme UpdateCurrentColorTheme(GuiStyle style)
    {
        if (CurrentGUIStyle != style)
        {
            CurrentGUIStyle = style;
        }

        return AppGuiStyleManagerInstance.GetCurrentColorTheme();
    }
}
