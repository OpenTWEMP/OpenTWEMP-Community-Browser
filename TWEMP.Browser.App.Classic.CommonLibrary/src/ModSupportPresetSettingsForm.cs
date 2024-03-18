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

    private readonly IConfigurableGameModificationView currentGameModificationView;

    public ModSupportPresetSettingsForm(IConfigurableGameModificationView gameModificationView)
    {
        this.InitializeComponent();

        this.idColumnIndex = this.modSupportPresetsDataGridView.Columns[0].Index;
        this.modNameColumnIndex = this.modSupportPresetsDataGridView.Columns[1].Index;
        this.gameSetupColumnIndex = this.modSupportPresetsDataGridView.Columns[2].Index;
        this.modCenterColumnIndex = this.modSupportPresetsDataGridView.Columns[3].Index;
        this.redistributablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[4].Index;
        this.customizablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[5].Index;

        this.currentGameModificationView = gameModificationView;

        List<GameModificationInfo> gameInstallations = Settings.TotalModificationsList;
        this.InitializeModSupportPresetsDataGridView(gameInstallations);
    }

    public void AttachRedistributablePresetToGameModification(string presetPlaceholder, int gameModId)
    {
        int redistributablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[4].Index;
        DataGridViewCell redistributablePresetCell = this.modSupportPresetsDataGridView.Rows[gameModId].Cells[redistributablePresetColumnIndex];
        redistributablePresetCell.Value = $"Attached Preset: {presetPlaceholder}";
    }

    private void InitializeModSupportPresetsDataGridView(ICollection<GameModificationInfo> gameMods)
    {
        Dictionary<DataGridViewRow, GameModificationInfo> gameModInfoRows = new ();

        for (int modIndex = 0; modIndex < gameMods.Count; modIndex++)
        {
            DataGridViewRow row = new ();
            this.modSupportPresetsDataGridView.Rows.Add(row);

            GameModificationInfo gameModInfo = gameMods.ElementAt(modIndex);
            gameModInfoRows.Add(row, gameModInfo);
        }

        for (int rowIndex = 0; rowIndex < this.modSupportPresetsDataGridView.Rows.Count; rowIndex++)
        {
            this.InitializeModSupportPresetDataGridViewRowId(rowIndex);
        }

        foreach (KeyValuePair<DataGridViewRow, GameModificationInfo> gameModInfoRow in gameModInfoRows)
        {
            this.InitializeModSupportPresetDataGridViewRow(gameModInfoRow.Key, gameModInfoRow.Value);
        }
    }

    private void InitializeModSupportPresetDataGridViewRowId(int rowIndex)
    {
        DataGridViewRow row = this.modSupportPresetsDataGridView.Rows[rowIndex];
        DataGridViewCell idCell = row.Cells[this.idColumnIndex];
        idCell.Value = rowIndex;
    }

    private void InitializeModSupportPresetDataGridViewRow(DataGridViewRow row, GameModificationInfo gameModInfo)
    {
        DataGridViewCell modNameCell = row.Cells[this.modNameColumnIndex];
        modNameCell.Value = gameModInfo.ShortName;

        DataGridViewCell gameSetupCell = row.Cells[this.gameSetupColumnIndex];
        gameSetupCell.Value = gameModInfo.CurrentSetup.HomeDirectory;

        DataGridViewCell modCenterCell = row.Cells[this.modCenterColumnIndex];
        modCenterCell.Value = gameModInfo.Location;

        DataGridViewCell redistributablePresetCell = row.Cells[this.redistributablePresetColumnIndex];
        redistributablePresetCell.Value = $"{gameModInfo.CurrentPreset.ModTitle} [{gameModInfo.CurrentPreset.ModVersion}]";
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
        Dictionary<int, string> currentPresetSettings = new ();

        foreach (DataGridViewRow row in this.modSupportPresetsDataGridView.Rows)
        {
            var idObject = row.Cells[this.idColumnIndex].Value;
            int id = Convert.ToInt32(idObject);

            var presetObject = (DataGridViewCheckBoxCell)row.Cells[this.customizablePresetColumnIndex].Value;
            bool useCustomizablePreset = Convert.ToBoolean(presetObject);

            string preset = useCustomizablePreset ? "[CUSTOMIZABLE_PRESET]" : Convert.ToString(row.Cells[this.redistributablePresetColumnIndex].Value) !;

            KeyValuePair<int, string> presetSetting = new (id, preset);
            currentPresetSettings.Add(presetSetting.Key, presetSetting.Value);
        }

        this.currentGameModificationView.UpdateGameModificationViewAfterChangingPresetSettings(currentPresetSettings);

        MessageBox.Show("Your new preset settings were successfully applied!", "Update Preset Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);

        this.Close();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
