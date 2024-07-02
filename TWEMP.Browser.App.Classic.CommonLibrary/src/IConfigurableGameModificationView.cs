// <copyright file="IConfigurableGameModificationView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

public interface IConfigurableGameModificationView
{
    public abstract void UpdateGameModificationViewAfterChangingPresetSettings(Dictionary<int, string> presetSettings);
}
