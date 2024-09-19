// <copyright file="MainBrowserForm.Experiments.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic;

using System.Linq;
using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

internal partial class MainBrowserForm : IUpdatableBrowser, IConfigurableGameModificationView
{
    public void UpdateExperimentalGUIChanges(bool enabled)
    {
        groupBoxLauncherProviders.Visible = enabled;
        radioButtonLauncherProvider_TWEMP.Checked = true;
    }

    public void UpdateGameModificationViewAfterChangingPresetSettings(Dictionary<int, string> presetSettings)
    {
        foreach (KeyValuePair<int, string> presetSetting in presetSettings)
        {
            GameModificationInfo gameModInfo = Settings.TotalModificationsList.ElementAt(presetSetting.Key);

            gameModInfo.CurrentPreset.ModTitle = $"{presetSetting.Value}.ModName";
            gameModInfo.CurrentPreset.ModVersion = $"{presetSetting.Value}.ModVersion";
        }
    }
}
