namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary;

internal partial class MainBrowserForm : IUpdatableBrowser
{
    public void UpdateExperimentalGUIChanges(bool enabled)
    {
        groupBoxLauncherProviders.Visible = enabled;
        radioButtonLauncherProvider_TWEMP.Checked = true;
    }
}
