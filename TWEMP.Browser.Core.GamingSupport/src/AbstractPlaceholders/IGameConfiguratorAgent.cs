// <copyright file="IGameConfiguratorAgent.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

// TODO: Replace to the imported type - TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.IGameConfiguratorAgent.
public interface IGameConfiguratorAgent
{
    public abstract string GetDefaultSettingsString();

    public abstract string GetCustomSettingsString(ICustomConfigState state);
}
