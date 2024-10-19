// <copyright file="ModSupportPresetSetupManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public class ModSupportPresetSetupManager
{
    private ModSupportPresetSetupManager()
    {
    }

    /// <summary>
    /// Creates a custom instance of the <see cref="ModSupportPresetSetupManager"/> class.
    /// </summary>
    /// <returns>Instance of the <see cref="ModSupportPresetSetupManager"/> class.</returns>
    public static ModSupportPresetSetupManager Create()
    {
        return new ModSupportPresetSetupManager();
    }
}
