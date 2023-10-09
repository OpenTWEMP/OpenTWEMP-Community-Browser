namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary;

internal partial class MainBrowserForm : IUpdatableBrowser
{
    public void UpdateExperimentalGUIChanges()
    {
#if DISABLE_WHEN_MIGRATION
        groupBoxLauncherProviders.Visible = isEnabledChangesStatus;
        radioButtonLauncherProvider_TWEMP.Checked = true;
#endif
    }
}
