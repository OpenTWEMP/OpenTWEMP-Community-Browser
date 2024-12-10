namespace TWEMP.Browser.App.Classic.CommonLibrary
{
    partial class RedistributablePresetSelectionForm
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
            presetSelectionButton = new Button();
            presetCancelButton = new Button();
            presetsListBox = new ListBox();
            presetMetadataGroupBox = new GroupBox();
            presetCreatorLabel = new Label();
            packageLabel = new Label();
            presetVersionLabel = new Label();
            presetNameLabel = new Label();
            presetGuidLabel = new Label();
            presetDataGroupBox = new GroupBox();
            modUrl3LinkLabel = new LinkLabel();
            modUrl2LinkLabel = new LinkLabel();
            modUrl1LinkLabel = new LinkLabel();
            modUrl3Label = new Label();
            modUrl2Label = new Label();
            modUrl1Label = new Label();
            modVersionLabel = new Label();
            modNameLabel = new Label();
            presetPreviewPictureBox = new PictureBox();
            modSupportPresetTitlelabel = new Label();
            presetMetadataGroupBox.SuspendLayout();
            presetDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)presetPreviewPictureBox).BeginInit();
            SuspendLayout();
            // 
            // presetSelectionButton
            // 
            presetSelectionButton.Enabled = false;
            presetSelectionButton.Location = new Point(12, 493);
            presetSelectionButton.Name = "presetSelectionButton";
            presetSelectionButton.Size = new Size(760, 25);
            presetSelectionButton.TabIndex = 0;
            presetSelectionButton.Text = "Select a Preset";
            presetSelectionButton.UseVisualStyleBackColor = true;
            presetSelectionButton.Click += PresetSelectionButton_Click;
            // 
            // presetCancelButton
            // 
            presetCancelButton.Location = new Point(12, 524);
            presetCancelButton.Name = "presetCancelButton";
            presetCancelButton.Size = new Size(760, 25);
            presetCancelButton.TabIndex = 1;
            presetCancelButton.Text = "Cancel";
            presetCancelButton.UseVisualStyleBackColor = true;
            presetCancelButton.Click += PresetCancelButton_Click;
            // 
            // presetsListBox
            // 
            presetsListBox.FormattingEnabled = true;
            presetsListBox.ItemHeight = 15;
            presetsListBox.Location = new Point(12, 87);
            presetsListBox.Name = "presetsListBox";
            presetsListBox.Size = new Size(243, 394);
            presetsListBox.TabIndex = 2;
            presetsListBox.SelectedIndexChanged += PresetsListBox_SelectedIndexChanged;
            // 
            // presetMetadataGroupBox
            // 
            presetMetadataGroupBox.Controls.Add(presetCreatorLabel);
            presetMetadataGroupBox.Controls.Add(packageLabel);
            presetMetadataGroupBox.Controls.Add(presetVersionLabel);
            presetMetadataGroupBox.Controls.Add(presetNameLabel);
            presetMetadataGroupBox.Controls.Add(presetGuidLabel);
            presetMetadataGroupBox.Location = new Point(261, 87);
            presetMetadataGroupBox.Name = "presetMetadataGroupBox";
            presetMetadataGroupBox.Size = new Size(511, 147);
            presetMetadataGroupBox.TabIndex = 3;
            presetMetadataGroupBox.TabStop = false;
            presetMetadataGroupBox.Text = "Preset Metadata";
            // 
            // presetCreatorLabel
            // 
            presetCreatorLabel.Location = new Point(6, 111);
            presetCreatorLabel.Name = "presetCreatorLabel";
            presetCreatorLabel.Size = new Size(494, 23);
            presetCreatorLabel.TabIndex = 4;
            presetCreatorLabel.Text = "Creator";
            // 
            // packageLabel
            // 
            packageLabel.Location = new Point(6, 88);
            packageLabel.Name = "packageLabel";
            packageLabel.Size = new Size(494, 23);
            packageLabel.TabIndex = 3;
            packageLabel.Text = "Package";
            // 
            // presetVersionLabel
            // 
            presetVersionLabel.Location = new Point(6, 65);
            presetVersionLabel.Name = "presetVersionLabel";
            presetVersionLabel.Size = new Size(494, 23);
            presetVersionLabel.TabIndex = 2;
            presetVersionLabel.Text = "Preset Version";
            // 
            // presetNameLabel
            // 
            presetNameLabel.Location = new Point(6, 42);
            presetNameLabel.Name = "presetNameLabel";
            presetNameLabel.Size = new Size(494, 23);
            presetNameLabel.TabIndex = 1;
            presetNameLabel.Text = "Preset Name";
            // 
            // presetGuidLabel
            // 
            presetGuidLabel.Location = new Point(6, 19);
            presetGuidLabel.Name = "presetGuidLabel";
            presetGuidLabel.Size = new Size(494, 23);
            presetGuidLabel.TabIndex = 0;
            presetGuidLabel.Text = "GUID";
            // 
            // presetDataGroupBox
            // 
            presetDataGroupBox.Controls.Add(modUrl3LinkLabel);
            presetDataGroupBox.Controls.Add(modUrl2LinkLabel);
            presetDataGroupBox.Controls.Add(modUrl1LinkLabel);
            presetDataGroupBox.Controls.Add(modUrl3Label);
            presetDataGroupBox.Controls.Add(modUrl2Label);
            presetDataGroupBox.Controls.Add(modUrl1Label);
            presetDataGroupBox.Controls.Add(modVersionLabel);
            presetDataGroupBox.Controls.Add(modNameLabel);
            presetDataGroupBox.Location = new Point(261, 240);
            presetDataGroupBox.Name = "presetDataGroupBox";
            presetDataGroupBox.Size = new Size(511, 211);
            presetDataGroupBox.TabIndex = 4;
            presetDataGroupBox.TabStop = false;
            presetDataGroupBox.Text = "Preset Data";
            // 
            // modUrl3LinkLabel
            // 
            modUrl3LinkLabel.AutoSize = true;
            modUrl3LinkLabel.Location = new Point(6, 183);
            modUrl3LinkLabel.Name = "modUrl3LinkLabel";
            modUrl3LinkLabel.Size = new Size(60, 15);
            modUrl3LinkLabel.TabIndex = 13;
            modUrl3LinkLabel.TabStop = true;
            modUrl3LinkLabel.Text = "linkLabel3";
            // 
            // modUrl2LinkLabel
            // 
            modUrl2LinkLabel.AutoSize = true;
            modUrl2LinkLabel.Location = new Point(6, 140);
            modUrl2LinkLabel.Name = "modUrl2LinkLabel";
            modUrl2LinkLabel.Size = new Size(60, 15);
            modUrl2LinkLabel.TabIndex = 12;
            modUrl2LinkLabel.TabStop = true;
            modUrl2LinkLabel.Text = "linkLabel2";
            // 
            // modUrl1LinkLabel
            // 
            modUrl1LinkLabel.AutoSize = true;
            modUrl1LinkLabel.Location = new Point(6, 96);
            modUrl1LinkLabel.Name = "modUrl1LinkLabel";
            modUrl1LinkLabel.Size = new Size(60, 15);
            modUrl1LinkLabel.TabIndex = 11;
            modUrl1LinkLabel.TabStop = true;
            modUrl1LinkLabel.Text = "linkLabel1";
            // 
            // modUrl3Label
            // 
            modUrl3Label.AutoSize = true;
            modUrl3Label.Font = new Font("Segoe UI", 9F);
            modUrl3Label.Location = new Point(6, 168);
            modUrl3Label.Name = "modUrl3Label";
            modUrl3Label.Size = new Size(75, 15);
            modUrl3Label.TabIndex = 10;
            modUrl3Label.Text = "Mod URL # 3";
            // 
            // modUrl2Label
            // 
            modUrl2Label.AutoSize = true;
            modUrl2Label.Font = new Font("Segoe UI", 9F);
            modUrl2Label.Location = new Point(6, 125);
            modUrl2Label.Name = "modUrl2Label";
            modUrl2Label.Size = new Size(75, 15);
            modUrl2Label.TabIndex = 9;
            modUrl2Label.Text = "Mod URL # 2";
            // 
            // modUrl1Label
            // 
            modUrl1Label.AutoSize = true;
            modUrl1Label.Font = new Font("Segoe UI", 9F);
            modUrl1Label.Location = new Point(6, 81);
            modUrl1Label.Name = "modUrl1Label";
            modUrl1Label.Size = new Size(75, 15);
            modUrl1Label.TabIndex = 8;
            modUrl1Label.Text = "Mod URL # 1";
            // 
            // modVersionLabel
            // 
            modVersionLabel.Location = new Point(6, 53);
            modVersionLabel.Name = "modVersionLabel";
            modVersionLabel.Size = new Size(499, 28);
            modVersionLabel.TabIndex = 7;
            modVersionLabel.Text = "Mod Version";
            // 
            // modNameLabel
            // 
            modNameLabel.Location = new Point(6, 24);
            modNameLabel.Name = "modNameLabel";
            modNameLabel.Size = new Size(505, 29);
            modNameLabel.TabIndex = 6;
            modNameLabel.Text = "Mod Name";
            // 
            // presetPreviewPictureBox
            // 
            presetPreviewPictureBox.BorderStyle = BorderStyle.FixedSingle;
            presetPreviewPictureBox.Enabled = false;
            presetPreviewPictureBox.Location = new Point(261, 457);
            presetPreviewPictureBox.Name = "presetPreviewPictureBox";
            presetPreviewPictureBox.Size = new Size(32, 24);
            presetPreviewPictureBox.TabIndex = 5;
            presetPreviewPictureBox.TabStop = false;
            presetPreviewPictureBox.Visible = false;
            // 
            // modSupportPresetTitlelabel
            // 
            modSupportPresetTitlelabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            modSupportPresetTitlelabel.Location = new Point(12, 18);
            modSupportPresetTitlelabel.Name = "modSupportPresetTitlelabel";
            modSupportPresetTitlelabel.Size = new Size(760, 51);
            modSupportPresetTitlelabel.TabIndex = 6;
            modSupportPresetTitlelabel.Text = "Mod Support Preset Title";
            modSupportPresetTitlelabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RedistributablePresetSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(modSupportPresetTitlelabel);
            Controls.Add(presetPreviewPictureBox);
            Controls.Add(presetDataGroupBox);
            Controls.Add(presetMetadataGroupBox);
            Controls.Add(presetsListBox);
            Controls.Add(presetCancelButton);
            Controls.Add(presetSelectionButton);
            MaximizeBox = false;
            MaximumSize = new Size(800, 600);
            MinimizeBox = false;
            MinimumSize = new Size(800, 600);
            Name = "RedistributablePresetSelectionForm";
            ShowIcon = false;
            Text = "Select a Redistributable Preset for Your Mod";
            presetMetadataGroupBox.ResumeLayout(false);
            presetDataGroupBox.ResumeLayout(false);
            presetDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)presetPreviewPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button presetSelectionButton;
        private Button presetCancelButton;
        private ListBox presetsListBox;
        private GroupBox presetMetadataGroupBox;
        private GroupBox presetDataGroupBox;
        private PictureBox presetPreviewPictureBox;
        private Label presetVersionLabel;
        private Label presetNameLabel;
        private Label presetGuidLabel;
        private Label presetCreatorLabel;
        private Label packageLabel;
        private Label modUrl3Label;
        private Label modUrl2Label;
        private Label modUrl1Label;
        private Label modVersionLabel;
        private Label modNameLabel;
        private LinkLabel modUrl3LinkLabel;
        private LinkLabel modUrl2LinkLabel;
        private LinkLabel modUrl1LinkLabel;
        private Label modSupportPresetTitlelabel;
    }
}