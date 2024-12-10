// <copyright file="LocaleSnapshot.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

/// <summary>
/// Represents a locale snapshot for a target UI control element.
/// </summary>
public class LocaleSnapshot
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LocaleSnapshot"/> class.
    /// </summary>
    /// <param name="formName">The name of a target UI control element.</param>
    /// <param name="formContent">The localized content of UI controls for a target UI control element.</param>
    public LocaleSnapshot(string formName, Dictionary<string, string> formContent)
    {
        this.FormName = formName;
        this.FormContent = formContent;
    }

    /// <summary>
    /// Gets the name of a target UI control element.
    /// </summary>
    public string FormName { get; }

    /// <summary>
    /// Gets the localized content of UI controls for a target UI control element.
    /// </summary>
    public Dictionary<string, string> FormContent { get; }

    /// <summary>
    /// Retrieves the localized value of the 'Text' property for a UI control within the target UI control element by its name-key.
    /// </summary>
    /// <param name="targetKey">The name-key of a localized UI control within the target UI control element.</param>
    /// <returns>The value of the 'Text' property for a localized UI control within the target UI control element.</returns>
    public string GetLocalizedValueByKey(string targetKey)
    {
        if (this.FormContent.ContainsKey(targetKey))
        {
            return this.FormContent[targetKey];
        }

        return string.Empty;
    }
}
