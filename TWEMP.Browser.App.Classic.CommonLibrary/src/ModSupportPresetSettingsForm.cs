// <copyright file="ModSupportPresetSettingsForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented

#define EXPERIMENTAL_FEATURES
#undef EXPERIMENTAL_FEATURES

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using System.Windows.Forms;
using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

public partial class ModSupportPresetSettingsForm : Form
{
    private readonly int idColumnIndex;
    private readonly int modNameColumnIndex;
    private readonly int gameSetupColumnIndex;
    private readonly int modCenterColumnIndex;
    private readonly int redistributablePresetColumnIndex;
    private readonly int customizablePresetColumnIndex;

    private readonly Color rowCellBackColorForNewAttachedPreset = Color.Orange;
    private readonly Color rowCellBackColorForDefaultPreset = Color.LightGray;
    private readonly Color rowCellBackColorForRedistributablePreset = Color.LightGreen;
    private readonly Color rowCellBackColorForCustomizablePreset = Color.LightBlue;

    private readonly List<ModPresetSettingView> currentPresetSettingViews;

    public ModSupportPresetSettingsForm()
    {
        this.InitializeComponent();

        this.idColumnIndex = this.modSupportPresetsDataGridView.Columns[0].Index;
        this.modNameColumnIndex = this.modSupportPresetsDataGridView.Columns[1].Index;
        this.gameSetupColumnIndex = this.modSupportPresetsDataGridView.Columns[2].Index;
        this.modCenterColumnIndex = this.modSupportPresetsDataGridView.Columns[3].Index;
        this.redistributablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[4].Index;
        this.customizablePresetColumnIndex = this.modSupportPresetsDataGridView.Columns[5].Index;

        FullGameModsCollectionView fullGameModsCollectionView = BrowserKernel.CurrentGameModsCollectionView;
        this.currentPresetSettingViews = fullGameModsCollectionView.GetModPresetSettings().ToList();

        this.InitializeModSupportPresetsDataGridView(fullGameModsCollectionView);
    }

    public void AttachRedistributablePresetToGameModification(int gameModId, RedistributableModPreset preset)
    {
        DataGridViewCell gameModPresetCell = this.modSupportPresetsDataGridView.Rows[gameModId].Cells[this.redistributablePresetColumnIndex];
        gameModPresetCell.Value = $"<{preset.Data.HeaderInfo.ModTitle} [{preset.Data.HeaderInfo.ModVersion}]>";

        DataGridViewRow gameModViewRow = this.modSupportPresetsDataGridView.Rows[gameModId];
        this.MarkModSupportPresetDataGridViewRowAsNewAttachedPreset(gameModViewRow);

        ModPresetSettingView presetSettingView = this.currentPresetSettingViews.ElementAt(gameModId);
        presetSettingView.RedistributablePresetGuid = preset.Metadata.Guid;
    }

    private void InitializeModSupportPresetsDataGridView(FullGameModsCollectionView fullGameModsCollectionView)
    {
        for (int index = 0; index < fullGameModsCollectionView.GameModificationViews.Length; index++)
        {
            this.modSupportPresetsDataGridView.Rows.Add(new DataGridViewRow());

            DataGridViewRow dataGridViewRow = this.modSupportPresetsDataGridView.Rows[index];
            UpdatableGameModificationView gameModView = fullGameModsCollectionView.GameModificationViews[index];

            this.InitializeModSupportPresetDataGridViewRow(dataGridViewRow, gameModView);
        }
    }

    private void InitializeModSupportPresetDataGridViewRow(DataGridViewRow dataGridViewRow, UpdatableGameModificationView gameModView)
    {
        DataGridViewCell idCell = dataGridViewRow.Cells[this.idColumnIndex];
        idCell.Value = gameModView.IdView.NumericId;

        DataGridViewCell modNameCell = dataGridViewRow.Cells[this.modNameColumnIndex];
        modNameCell.Value = gameModView.CurrentInfo.ShortName;

        DataGridViewCell gameSetupCell = dataGridViewRow.Cells[this.gameSetupColumnIndex];
        gameSetupCell.Value = gameModView.CurrentInfo.CurrentSetup.HomeDirectory;

        DataGridViewCell modCenterCell = dataGridViewRow.Cells[this.modCenterColumnIndex];
        modCenterCell.Value = gameModView.CurrentInfo.Location;

        DataGridViewCell redistributablePresetCell = dataGridViewRow.Cells[this.redistributablePresetColumnIndex];
        string redistributablePresetFullName = gameModView.GetRedistributablePresetFullName();
        redistributablePresetCell.Value = redistributablePresetFullName;

        DataGridViewCheckBoxCell customizablePresetCell = (DataGridViewCheckBoxCell)dataGridViewRow.Cells[this.customizablePresetColumnIndex];
        customizablePresetCell.Value = gameModView.UseCustomizablePreset;

        if (this.IsConfiguredByCustomizableModPreset(dataGridViewRow))
        {
            this.MarkModSupportPresetDataGridViewRowAsCustomizablePreset(dataGridViewRow);
        }
        else
        {
            if (redistributablePresetFullName.Equals(UpdatableGameModificationView.GetDefaultPresetFullName()))
            {
                this.MarkModSupportPresetDataGridViewRowAsDefaultPreset(dataGridViewRow);
            }
            else
            {
                this.MarkModSupportPresetDataGridViewRowAsRedistributablePreset(dataGridViewRow);
            }
        }
    }

    private bool IsConfiguredByCustomizableModPreset(DataGridViewRow dataGridViewRow)
    {
        bool useCustomizablePreset;

        try
        {
            var cell = (DataGridViewCheckBoxCell)dataGridViewRow.Cells[this.customizablePresetColumnIndex];
            useCustomizablePreset = Convert.ToBoolean(cell.Value);
        }
        catch (InvalidCastException)
        {
            useCustomizablePreset = false;
        }

        return useCustomizablePreset;
    }

    private void MarkModSupportPresetDataGridViewRowAsNewAttachedPreset(DataGridViewRow dataGridViewRow)
    {
        this.ChangeDataGridViewRowBackgroundColor(dataGridViewRow, this.rowCellBackColorForNewAttachedPreset);
    }

    private void MarkModSupportPresetDataGridViewRowAsDefaultPreset(DataGridViewRow dataGridViewRow)
    {
        this.ChangeDataGridViewRowBackgroundColor(dataGridViewRow, this.rowCellBackColorForDefaultPreset);
    }

    private void MarkModSupportPresetDataGridViewRowAsRedistributablePreset(DataGridViewRow dataGridViewRow)
    {
        this.ChangeDataGridViewRowBackgroundColor(dataGridViewRow, this.rowCellBackColorForRedistributablePreset);
    }

    private void MarkModSupportPresetDataGridViewRowAsCustomizablePreset(DataGridViewRow dataGridViewRow)
    {
        this.ChangeDataGridViewRowBackgroundColor(dataGridViewRow, this.rowCellBackColorForCustomizablePreset);
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
            RedistributablePresetSelectionForm form = new (this, e.RowIndex);
            form.Show();
        }

        if (e.ColumnIndex == this.customizablePresetColumnIndex)
        {
            DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex];
            bool value = Convert.ToBoolean(cell.Value);

            if (value)
            {
                this.MarkModSupportPresetDataGridViewRowAsCustomizablePreset(row);
            }
            else
            {
                DataGridViewCell redistributablePresetCell = row.Cells[this.redistributablePresetColumnIndex];
                string? redistributablePresetFullName = Convert.ToString(redistributablePresetCell.Value);

                if (redistributablePresetFullName!.Equals(UpdatableGameModificationView.GetDefaultPresetFullName()))
                {
                    this.MarkModSupportPresetDataGridViewRowAsDefaultPreset(row);
                }
                else
                {
                    this.MarkModSupportPresetDataGridViewRowAsRedistributablePreset(row);
                }
            }

            ModPresetSettingView presetSettingView = this.currentPresetSettingViews.ElementAt(row.Index);
            presetSettingView.UseCustomizablePreset = value;
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
#if EXPERIMENTAL_FEATURES
        MessageBox.Show("OpenCustomizablePresetDirectoryButton_Click");
#endif
    }

    private void OpenRedistributablePresetDirectoryButton_Click(object sender, EventArgs e)
    {
#if EXPERIMENTAL_FEATURES
        MessageBox.Show("OpenRedistributablePresetDirectoryButton_Click");
#endif
    }

    private void AllChangesDiscardButton_Click(object sender, EventArgs e)
    {
#if EXPERIMENTAL_FEATURES
        MessageBox.Show("AllChangesDiscardButton_Click");
#endif
    }

    private void AllChangesResetButton_Click(object sender, EventArgs e)
    {
#if EXPERIMENTAL_FEATURES
        MessageBox.Show("AllChangesResetButton_Click");
#endif
    }

    private void ApplyButton_Click(object sender, EventArgs e)
    {
        BrowserKernel.UpdatePresetSettings(this.currentPresetSettingViews);

        MessageBox.Show(
            text: "Your new preset settings were successfully applied!",
            caption: "Update Preset Settings",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Information);

        this.Close();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

#if EXPERIMENTAL_FEATURES
    private void RetrieveCurrentPresetSettings()
    {
        Dictionary<int, string> currentPresetSettings = new ();

        foreach (DataGridViewRow row in this.modSupportPresetsDataGridView.Rows)
        {
            var idObject = row.Cells[this.idColumnIndex].Value;
            int id = Convert.ToInt32(idObject);

            var presetObject = row.Cells[this.customizablePresetColumnIndex].Value;
            bool useCustomizablePreset = Convert.ToBoolean(presetObject);

            string preset = useCustomizablePreset ? "[CUSTOMIZABLE_PRESET]" : Convert.ToString(row.Cells[this.redistributablePresetColumnIndex].Value)!;

            KeyValuePair<int, string> presetSetting = new(id, preset);
            currentPresetSettings.Add(presetSetting.Key, presetSetting.Value);
        }
    }
#endif
}
