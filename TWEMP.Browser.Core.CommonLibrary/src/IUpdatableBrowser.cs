namespace TWEMP.Browser.Core.CommonLibrary;

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
