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

    private void ModSupportPresetsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        const byte redistributablePresetButtonColumnIndex = 4;
        const byte customizablePresetCheckBoxColumnIndex = 5;

        DataGridViewRow row = this.modSupportPresetsDataGridView.Rows[e.RowIndex];

        this.modSupportPresetsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

        if (e.ColumnIndex == redistributablePresetButtonColumnIndex)
        {
            DataGridViewButtonCell cell = (DataGridViewButtonCell)row.Cells[e.ColumnIndex];
            MessageBox.Show($"{cell.Value}");

            var form = new RedistributablePresetSelectionForm();
            form.Show();
        }

        if (e.ColumnIndex == customizablePresetCheckBoxColumnIndex)
        {
            DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex];
            bool value = Convert.ToBoolean(cell.Value);

            if (value)
            {
                this.ChangeDataGridViewRowBackgroundColor(row, Color.Green);
            }
            else
            {
                this.ChangeDataGridViewRowBackgroundColor(row, Color.Red);
            }
        }
    }

    private void ChangeDataGridViewRowBackgroundColor(DataGridViewRow row, Color color)
    {
        int idColumnIndex = this.modSupportPresetsDataGridView.Columns[0].Index;
        DataGridViewCell idCell = row.Cells[idColumnIndex];
        idCell.Style.BackColor = color;

        int modNameColumnIndex = this.modSupportPresetsDataGridView.Columns[1].Index;
        DataGridViewCell modNameCell = row.Cells[modNameColumnIndex];
        modNameCell.Style.BackColor = color;

        int gameSetupColumnIndex = this.modSupportPresetsDataGridView.Columns[2].Index;
        DataGridViewCell gameSetupCell = row.Cells[gameSetupColumnIndex];
        gameSetupCell.Style.BackColor = color;

        int modCenterColumnIndex = this.modSupportPresetsDataGridView.Columns[3].Index;
        DataGridViewCell modCenterCell = row.Cells[modCenterColumnIndex];
        modCenterCell.Style.BackColor = color;

        int redistributablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[4].Index;
        DataGridViewCell redistributablePresetCell = row.Cells[redistributablePresetColumnIndex];
        redistributablePresetCell.Style.BackColor = color;

        int customizablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[5].Index;
        DataGridViewCell customizablePresetCell = row.Cells[customizablePresetColumnIndex];
        customizablePresetCell.Style.BackColor = color;
    }

    private void OpenCustomizablePresetDirectoryButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("OpenCustomizablePresetDirectoryButton_Click");
    }

    private void OpenRedistributablePresetDirectoryButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("OpenRedistributablePresetDirectoryButton_Click");
    }

    private void AllChangesDiscardButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("AllChangesDiscardButton_Click");
    }

    private void AllChangesResetButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("AllChangesResetButton_Click");
    }

    private void ApplyButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("ApplyButton_Click");
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
