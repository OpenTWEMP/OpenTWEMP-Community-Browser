// <copyright file="ICustomQuickConfigState.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

/// <summary>
/// Defines the interface to create a custom quick game configuration state.
/// </summary>
public interface ICustomQuickConfigState
{
    /// <summary>
    /// Retrieves current settings from this custom configuration state.
    /// </summary>
    /// <returns>
    /// The dictionary of properties for
    /// a custom quick game configuration state view,
    /// where the key represents property name, and
    /// the value is the property value.
    /// </returns>
    public abstract Dictionary<string, bool> GetStateViewOfProperties();

    /// <summary>
    /// Sets the custom configuration state by a custom config state view.
    /// </summary>
    /// <param name="stateView">The dictionary of properties for
    /// a custom quick game configuration state,
    /// where the key represents property name,
    /// and the value is the property value.
    /// </param>
    public abstract void SetPropertiesByStateView(Dictionary<string, bool> stateView);
}
