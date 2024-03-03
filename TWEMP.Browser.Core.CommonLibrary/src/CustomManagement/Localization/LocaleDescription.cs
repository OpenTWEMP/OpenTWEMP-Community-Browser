// <copyright file="FormLocaleDescription.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

/// <summary>
/// Represents an abstract base class for any derived classes of UI controls' locale descriptions.
/// </summary>
public abstract class LocaleDescription
{
    /// <summary>
    /// Gets the name of the target UI control element.
    /// </summary>
    public abstract string FormName { get; }

    /// <summary>
    /// Gets the collection of localized UI controls of the target UI control element.
    /// </summary>
    public abstract List<string> LocalizedControls { get; }

    /// <summary>
    /// Creates the standard locale snapshot for the English localization.
    /// </summary>
    /// <returns>The locale snapshot for the target UI control element.</returns>
    public abstract LocaleSnapshot CreateLocaleSnapshotFor_ENG();

    /// <summary>
    /// Creates the standard locale snapshot for the Russian localization.
    /// </summary>
    /// <returns>The locale snapshot for the target UI control element.</returns>
    public abstract LocaleSnapshot CreateLocaleSnapshotFor_RUS();
}
