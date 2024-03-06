// <copyright file="ModSupportPresetSettingsForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;

public partial class ModSupportPresetSettingsForm : Form
{
    public ModSupportPresetSettingsForm()
    {
        this.InitializeComponent();

        List<GameSetupInfo> gameInstallations = Settings.GameInstallations;
        this.InitializeModSupportPresetsDataGridView(gameInstallations);
    }

    private void InitializeModSupportPresetsDataGridView(ICollection<GameSetupInfo> gameInstallations)
    {
        foreach (GameSetupInfo gameInstallation in gameInstallations)
        {
            List<ModCenterInfo> modCenters = gameInstallation.AttachedModCenters;

            foreach (ModCenterInfo modcenter in modCenters)
            {
                List<GameModificationInfo> mods = modcenter.InstalledModifications;

                foreach (GameModificationInfo mod in mods)
                {
                    this.modSupportPresetsDataGridView.Rows.Add(new DataGridViewRow());
                }
            }
        }
    }
}
