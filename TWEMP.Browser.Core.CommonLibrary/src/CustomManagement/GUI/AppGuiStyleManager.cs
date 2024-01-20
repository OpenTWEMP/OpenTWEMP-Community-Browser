// <copyright file="AppGuiStyleManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;

/// <summary>
/// Represents a device to manage the current GUI style of the application.
/// </summary>
public class AppGuiStyleManager
{
    private const GuiStyle StyleByDefault = GuiStyle.Default;

    private GuiStyle currentStyle;

    private AppGuiStyleManager()
    {
        this.currentStyle = StyleByDefault;
    }

    private AppGuiStyleManager(GuiStyle style)
    {
        this.currentStyle = style;
    }

    /// <summary>
    /// Gets or sets the GUI style which the application uses currently.
    /// </summary>
    public GuiStyle CurrentStyle
    {
        get
        {
            return this.currentStyle;
        }

        set
        {
            if (value != this.currentStyle)
            {
                this.currentStyle = value;
            }
        }
    }

    /// <summary>
    /// Creates a custom instance of the <see cref="AppGuiStyleManager"/> class.
    /// </summary>
    /// <param name="style">Custom GUI style value.</param>
    /// <returns>Instance of the <see cref="AppGuiStyleManager"/> class.</returns>
    public static AppGuiStyleManager Create(GuiStyle style = StyleByDefault)
    {
        if (style != StyleByDefault)
        {
            return new AppGuiStyleManager(style);
        }

        return new AppGuiStyleManager();
    }
}
