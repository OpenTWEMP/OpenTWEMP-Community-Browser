// <copyright file="IUpdatableBrowser.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;

public interface IUpdatableBrowser
{
    public abstract bool Enabled { get; set; }

    public abstract bool Visible { get; set; }

    public abstract void CreateModsCollectionTreeView(CustomModsCollection collection);

    public abstract void UpdateCustomCollectionsInTreeView();

    public abstract void UpdateModificationsTreeView();

    public abstract void UpdateGUIStyle(GuiStyle style);

    public abstract void UpdateExperimentalGUIChanges(bool enabled);

    public abstract void UpdateLocalizationForGUIControls();
}
