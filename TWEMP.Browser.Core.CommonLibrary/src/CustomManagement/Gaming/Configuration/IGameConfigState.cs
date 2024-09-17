// <copyright file="IGameConfigState.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

public interface IGameConfigState
{
    public abstract CustomConfigState GetCurrentGameConfigState();
}
