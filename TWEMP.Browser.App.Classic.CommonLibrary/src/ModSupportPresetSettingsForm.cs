// <copyright file="ModSupportPresetSettingsForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using System.Windows.Forms;
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

                for (int modIndex = 0; modIndex < mods.Count; modIndex++)
                {
                    this.modSupportPresetsDataGridView.Rows.Add(new DataGridViewRow());
                }
            }
        }

        DataGridViewRowCollection currentRows = this.modSupportPresetsDataGridView.Rows;

        for (int rowIndex = 0; rowIndex < currentRows.Count; rowIndex++)
        {
            int idColumnIndex = this.modSupportPresetsDataGridView.Columns[0].Index;
            DataGridViewCell idCell = currentRows[rowIndex].Cells[idColumnIndex];
            idCell.Value = rowIndex;

            int modNameColumnIndex = this.modSupportPresetsDataGridView.Columns[1].Index;
            DataGridViewCell modNameCell = currentRows[rowIndex].Cells[modNameColumnIndex];
            modNameCell.Value = $"Mod Name # {rowIndex}";

            int gameSetupColumnIndex = this.modSupportPresetsDataGridView.Columns[2].Index;
            DataGridViewCell gameSetupCell = currentRows[rowIndex].Cells[gameSetupColumnIndex];
            gameSetupCell.Value = $"Game Setup Name";

            int modCenterColumnIndex = this.modSupportPresetsDataGridView.Columns[3].Index;
            DataGridViewCell modCenterCell = currentRows[rowIndex].Cells[modCenterColumnIndex];
            modCenterCell.Value = $"Mod Center Name";

            int redistributablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[4].Index;
            DataGridViewCell redistributablePresetCell = currentRows[rowIndex].Cells[redistributablePresetColumnIndex];
            redistributablePresetCell.Value = $"Redistributable Mod Support Preset Name # {rowIndex}";
        }
    }

    private void ModSupportPresetsDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
        for (int rowIndex = 0; rowIndex < this.modSupportPresetsDataGridView.Rows[e.RowIndex].Cells.Count; rowIndex++)
        {
            this.modSupportPresetsDataGridView[rowIndex, e.RowIndex].Selected = true;
        }
    }

    private void ModSupportPresetsDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
        for (int rowIndex = 0; rowIndex < this.modSupportPresetsDataGridView.Rows[e.RowIndex].Cells.Count; rowIndex++)
        {
            this.modSupportPresetsDataGridView[rowIndex, e.RowIndex].Selected = false;
        }
    }
}
