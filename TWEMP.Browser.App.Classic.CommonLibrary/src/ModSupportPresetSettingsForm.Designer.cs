namespace TWEMP.Browser.App.Classic.CommonLibrary
{
    partial class ModSupportPresetSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            customizablePresetCheckBoxColumn = new DataGridViewCheckBoxColumn();
            modsGridPanel = new Panel();
            modSupportPresetsDataGridView = new DataGridView();
            idColumn = new DataGridViewTextBoxColumn();
            modNameColumn = new DataGridViewTextBoxColumn();
            gameSetupColumn = new DataGridViewTextBoxColumn();
            modcenterColumn = new DataGridViewTextBoxColumn();
            redistributablePresetStatusButtonColumn = new DataGridViewButtonColumn();
            presetActionsPanel = new Panel();
            openRedistributablePresetDirectoryButton = new Button();
            openCustomizablePresetDirectoryButton = new Button();
            allChangesResetButton = new Button();
            allChangesDiscardButton = new Button();
            applyButton = new Button();
            exitButton = new Button();
            modsGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)modSupportPresetsDataGridView).BeginInit();
            presetActionsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // customizablePresetCheckBoxColumn
            // 
            customizablePresetCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            customizablePresetCheckBoxColumn.HeaderText = "USE CUSTOMIZABLE PRESET";
            customizablePresetCheckBoxColumn.Name = "customizablePresetCheckBoxColumn";
            // 
            // modsGridPanel
            // 
            modsGridPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modsGridPanel.Controls.Add(modSupportPresetsDataGridView);
            modsGridPanel.Location = new Point(12, 12);
            modsGridPanel.Name = "modsGridPanel";
            modsGridPanel.Size = new Size(776, 352);
            modsGridPanel.TabIndex = 0;
            // 
            // modSupportPresetsDataGridView
            // 
            modSupportPresetsDataGridView.AllowUserToAddRows = false;
            modSupportPresetsDataGridView.AllowUserToDeleteRows = false;
            modSupportPresetsDataGridView.AllowUserToResizeColumns = false;
            modSupportPresetsDataGridView.AllowUserToResizeRows = false;
            modSupportPresetsDataGridView.BorderStyle = BorderStyle.Fixed3D;
            modSupportPresetsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            modSupportPresetsDataGridView.Columns.AddRange(new DataGridViewColumn[] { idColumn, modNameColumn, gameSetupColumn, modcenterColumn, redistributablePresetStatusButtonColumn, customizablePresetCheckBoxColumn });
            modSupportPresetsDataGridView.Dock = DockStyle.Fill;
            modSupportPresetsDataGridView.EnableHeadersVisualStyles = false;
            modSupportPresetsDataGridView.Location = new Point(0, 0);
            modSupportPresetsDataGridView.Name = "modSupportPresetsDataGridView";
            dataGridViewCellStyle1.SelectionBackColor = Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            modSupportPresetsDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            modSupportPresetsDataGridView.Size = new Size(776, 352);
            modSupportPresetsDataGridView.TabIndex = 0;
            modSupportPresetsDataGridView.CellContentClick += ModSupportPresetsDataGridView_CellContentClick;
            modSupportPresetsDataGridView.RowEnter += ModSupportPresetsDataGridView_RowEnter;
            modSupportPresetsDataGridView.RowLeave += ModSupportPresetsDataGridView_RowLeave;
            // 
            // idColumn
            // 
            idColumn.HeaderText = "ID";
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            idColumn.Resizable = DataGridViewTriState.True;
            idColumn.Width = 50;
            // 
            // modNameColumn
            // 
            modNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            modNameColumn.HeaderText = "MOD NAME";
            modNameColumn.MinimumWidth = 50;
            modNameColumn.Name = "modNameColumn";
            // 
            // gameSetupColumn
            // 
            gameSetupColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gameSetupColumn.HeaderText = "GAME SETUP";
            gameSetupColumn.MinimumWidth = 50;
            gameSetupColumn.Name = "gameSetupColumn";
            // 
            // modcenterColumn
            // 
            modcenterColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            modcenterColumn.HeaderText = "MODCENTER";
            modcenterColumn.MinimumWidth = 50;
            modcenterColumn.Name = "modcenterColumn";
            // 
            // redistributablePresetStatusButtonColumn
            // 
            redistributablePresetStatusButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            redistributablePresetStatusButtonColumn.HeaderText = "USE REDISTRIBUTABLE PRESET";
            redistributablePresetStatusButtonColumn.Name = "redistributablePresetStatusButtonColumn";
            redistributablePresetStatusButtonColumn.Resizable = DataGridViewTriState.True;
            // 
            // presetActionsPanel
            // 
            presetActionsPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            presetActionsPanel.Controls.Add(openRedistributablePresetDirectoryButton);
            presetActionsPanel.Controls.Add(openCustomizablePresetDirectoryButton);
            presetActionsPanel.Controls.Add(allChangesResetButton);
            presetActionsPanel.Controls.Add(allChangesDiscardButton);
            presetActionsPanel.Controls.Add(applyButton);
            presetActionsPanel.Controls.Add(exitButton);
            presetActionsPanel.Location = new Point(12, 370);
            presetActionsPanel.Name = "presetActionsPanel";
            presetActionsPanel.Size = new Size(776, 68);
            presetActionsPanel.TabIndex = 1;
            // 
            // openRedistributablePresetDirectoryButton
            // 
            openRedistributablePresetDirectoryButton.Location = new Point(3, 32);
            openRedistributablePresetDirectoryButton.Name = "openRedistributablePresetDirectoryButton";
            openRedistributablePresetDirectoryButton.Size = new Size(244, 23);
            openRedistributablePresetDirectoryButton.TabIndex = 5;
            openRedistributablePresetDirectoryButton.Text = "Open Redistributable Preset Directory";
            openRedistributablePresetDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // openCustomizablePresetDirectoryButton
            // 
            openCustomizablePresetDirectoryButton.Location = new Point(3, 3);
            openCustomizablePresetDirectoryButton.Name = "openCustomizablePresetDirectoryButton";
            openCustomizablePresetDirectoryButton.Size = new Size(244, 23);
            openCustomizablePresetDirectoryButton.TabIndex = 4;
            openCustomizablePresetDirectoryButton.Text = "Open Customizable Preset Directory";
            openCustomizablePresetDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // allChangesResetButton
            // 
            allChangesResetButton.Location = new Point(311, 32);
            allChangesResetButton.Name = "allChangesResetButton";
            allChangesResetButton.Size = new Size(142, 23);
            allChangesResetButton.TabIndex = 3;
            allChangesResetButton.Text = "Reset All Changes";
            allChangesResetButton.UseVisualStyleBackColor = true;
            // 
            // allChangesDiscardButton
            // 
            allChangesDiscardButton.Location = new Point(311, 3);
            allChangesDiscardButton.Name = "allChangesDiscardButton";
            allChangesDiscardButton.Size = new Size(142, 23);
            allChangesDiscardButton.TabIndex = 2;
            allChangesDiscardButton.Text = "Discard All Changes";
            allChangesDiscardButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(616, 3);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(157, 23);
            applyButton.TabIndex = 1;
            applyButton.Text = "Apply Changes";
            applyButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(616, 32);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(157, 23);
            exitButton.TabIndex = 0;
            exitButton.Text = "Exit from the Window";
            exitButton.UseVisualStyleBackColor = true;
            // 
            // ModSupportPresetSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(presetActionsPanel);
            Controls.Add(modsGridPanel);
            Name = "ModSupportPresetSettingsForm";
            Text = "ModSupportPresetSettingsForm";
            modsGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)modSupportPresetsDataGridView).EndInit();
            presetActionsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel modsGridPanel;
        private DataGridView modSupportPresetsDataGridView;
        private Panel presetActionsPanel;
        private Button openRedistributablePresetDirectoryButton;
        private Button openCustomizablePresetDirectoryButton;
        private Button allChangesResetButton;
        private Button allChangesDiscardButton;
        private Button applyButton;
        private Button exitButton;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn modNameColumn;
        private DataGridViewTextBoxColumn gameSetupColumn;
        private DataGridViewTextBoxColumn modcenterColumn;
        private DataGridViewButtonColumn redistributablePresetStatusButtonColumn;
        private DataGridViewCheckBoxColumn customizablePresetCheckBoxColumn;
    }
}