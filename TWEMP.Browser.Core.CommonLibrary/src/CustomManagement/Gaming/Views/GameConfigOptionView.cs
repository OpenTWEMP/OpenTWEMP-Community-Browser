// <copyright file="GameConfigOptionView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#define DEPRECATED_CONSTRUCTOR
#undef DEPRECATED_CONSTRUCTOR

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

/// <summary>
/// Defines a game config option entity as a shared view which should be used when creating more complex view entities.
/// </summary>
public record GameConfigOptionView
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigOptionView"/> class.
    /// </summary>
    public GameConfigOptionView()
    {
    }

#if DEPRECATED_CONSTRUCTOR
    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigOptionView"/> class.
    /// </summary>
    /*public GameConfigOptionView()
    {
        this.ConfigSection = string.Empty;
        this.CfgOptionName = string.Empty;
        this.CfgOptionValue = string.Empty;
    }
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="GameConfigOptionView"/> class.
    /// </summary>
    /// <param name="section">The section name.</param>
    /// <param name="optionName">The option name.</param>
    /// <param name="optionValue">The option value.</param>
    public GameConfigOptionView(string section, string optionName, object optionValue)
    {
        this.ConfigSection = section;
        this.CfgOptionName = optionName;
        this.CfgOptionValue = optionValue;
    }

    /// <summary>
    /// Gets or sets the section name for this game config option.
    /// </summary>
    public string? ConfigSection { get; set; }

    /// <summary>
    /// Gets or sets the name of this game config option.
    /// </summary>
    public string? CfgOptionName { get; set; }

    /// <summary>
    /// Gets or sets the section value of this game config option.
    /// </summary>
    public object? CfgOptionValue { get; set; }
}
