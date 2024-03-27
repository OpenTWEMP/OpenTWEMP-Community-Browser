// <copyright file="ICustomConfigState.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

/// <summary>
/// Defines the custom game configuration state creation interface
/// which shoud be implemented by any compatible game configurator.
/// </summary>
public interface ICustomConfigState
{
    /// <summary>
    /// Retrieves current settings from this custom configuration state.
    /// </summary>
    /// <returns>The array of current configuration settings.</returns>
    public abstract CfgOptionsSubSet[] RetrieveCurrentSettings();
}
