// <copyright file="CustomConfigState.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

public record CustomConfigState : ICustomConfigState
{
    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return Array.Empty<GameCfgSection>(); // TODO: Implement retrieving existing M2TW config settings from properties!
    }
}
