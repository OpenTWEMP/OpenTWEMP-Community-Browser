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
    private readonly int idColumnIndex;
    private readonly int modNameColumnIndex;
    private readonly int gameSetupColumnIndex;
    private readonly int modCenterColumnIndex;
    private readonly int redistributablePresetColumnIndex;
    private readonly int customizablePresetColumnIndex;

    public ModSupportPresetSettingsForm()
    {
        this.InitializeComponent();

        this.idColumnIndex = this.modSupportPresetsDataGridView.Columns[0].Index;
        this.modNameColumnIndex = this.modSupportPresetsDataGridView.Columns[1].Index;
        this.gameSetupColumnIndex = this.modSupportPresetsDataGridView.Columns[2].Index;
        this.modCenterColumnIndex = this.modSupportPresetsDataGridView.Columns[3].Index;
        this.redistributablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[4].Index;
        this.customizablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[5].Index;

        List<GameSetupInfo> gameInstallations = Settings.GameInstallations;
        this.InitializeModSupportPresetsDataGridView(gameInstallations);
    }

    public void AttachRedistributablePresetToGameModification(string presetPlaceholder, int gameModId)
    {
        int redistributablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[4].Index;
        DataGridViewCell redistributablePresetCell = this.modSupportPresetsDataGridView.Rows[gameModId].Cells[redistributablePresetColumnIndex];
        redistributablePresetCell.Value = $"Attached Preset: {presetPlaceholder}";
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
            DataGridViewCell idCell = currentRows[rowIndex].Cells[this.idColumnIndex];
            idCell.Value = rowIndex;

            DataGridViewCell modNameCell = currentRows[rowIndex].Cells[this.modNameColumnIndex];
            modNameCell.Value = $"Mod Name # {rowIndex}";

            DataGridViewCell gameSetupCell = currentRows[rowIndex].Cells[this.gameSetupColumnIndex];
            gameSetupCell.Value = $"Game Setup Name";

            DataGridViewCell modCenterCell = currentRows[rowIndex].Cells[this.modCenterColumnIndex];
            modCenterCell.Value = $"Mod Center Name";

            DataGridViewCell redistributablePresetCell = currentRows[rowIndex].Cells[this.redistributablePresetColumnIndex];
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
        DataGridViewRow row = this.modSupportPresetsDataGridView.Rows[e.RowIndex];

        this.modSupportPresetsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

        if (e.ColumnIndex == this.redistributablePresetColumnIndex)
        {
            DataGridViewButtonCell cell = (DataGridViewButtonCell)row.Cells[e.ColumnIndex];
            MessageBox.Show($"{cell.Value}");

            RedistributablePresetSelectionForm form = new (this, e.RowIndex);
            form.Show();
        }

        if (e.ColumnIndex == this.customizablePresetColumnIndex)
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
        DataGridViewCell idCell = row.Cells[this.idColumnIndex];
        idCell.Style.BackColor = color;

        DataGridViewCell modNameCell = row.Cells[this.modNameColumnIndex];
        modNameCell.Style.BackColor = color;

        DataGridViewCell gameSetupCell = row.Cells[this.gameSetupColumnIndex];
        gameSetupCell.Style.BackColor = color;

        DataGridViewCell modCenterCell = row.Cells[this.modCenterColumnIndex];
        modCenterCell.Style.BackColor = color;

        DataGridViewCell redistributablePresetCell = row.Cells[this.redistributablePresetColumnIndex];
        redistributablePresetCell.Style.BackColor = color;

        DataGridViewCell customizablePresetCell = row.Cells[this.customizablePresetColumnIndex];
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
