namespace TWEMP.Browser.App.Classic.CommonLibrary
{
    partial class GameConfigProfilesForm
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
            gameConfigProfilesListBox = new ListBox();
            cfgProfileCreateButton = new Button();
            cfgProfileDeleteButton = new Button();
            cfgProfilesDeleteAllButton = new Button();
            cfgProfileUpdateButton = new Button();
            cfgProfilesExportButton = new Button();
            cfgProfilesImportButton = new Button();
            cfgProfileSelectButton = new Button();
            cfgProfileCopyButton = new Button();
            formCloseButton = new Button();
            cfgProfileCurrentLabel = new Label();
            SuspendLayout();
            // 
            // gameConfigProfilesListBox
            // 
            gameConfigProfilesListBox.FormattingEnabled = true;
            gameConfigProfilesListBox.ItemHeight = 15;
            gameConfigProfilesListBox.Location = new Point(12, 72);
            gameConfigProfilesListBox.Name = "gameConfigProfilesListBox";
            gameConfigProfilesListBox.Size = new Size(600, 199);
            gameConfigProfilesListBox.TabIndex = 0;
            gameConfigProfilesListBox.SelectedIndexChanged += GameConfigProfilesListBoxSelectedIndexChanged;
            // 
            // cfgProfileCreateButton
            // 
            cfgProfileCreateButton.Location = new Point(222, 277);
            cfgProfileCreateButton.Name = "cfgProfileCreateButton";
            cfgProfileCreateButton.Size = new Size(180, 23);
            cfgProfileCreateButton.TabIndex = 1;
            cfgProfileCreateButton.Text = "Create a New Config Profile";
            cfgProfileCreateButton.UseVisualStyleBackColor = true;
            cfgProfileCreateButton.Click += ConfigProfileCreateButtonClick;
            // 
            // cfgProfileDeleteButton
            // 
            cfgProfileDeleteButton.Location = new Point(408, 291);
            cfgProfileDeleteButton.Name = "cfgProfileDeleteButton";
            cfgProfileDeleteButton.Size = new Size(180, 23);
            cfgProfileDeleteButton.TabIndex = 2;
            cfgProfileDeleteButton.Text = "Delete a Config Profile";
            cfgProfileDeleteButton.UseVisualStyleBackColor = true;
            cfgProfileDeleteButton.Click += ConfigProfileDeleteButtonClick;
            // 
            // cfgProfilesDeleteAllButton
            // 
            cfgProfilesDeleteAllButton.Location = new Point(408, 320);
            cfgProfilesDeleteAllButton.Name = "cfgProfilesDeleteAllButton";
            cfgProfilesDeleteAllButton.Size = new Size(180, 23);
            cfgProfilesDeleteAllButton.TabIndex = 3;
            cfgProfilesDeleteAllButton.Text = "Delete All Config Profiles";
            cfgProfilesDeleteAllButton.UseVisualStyleBackColor = true;
            cfgProfilesDeleteAllButton.Click += ConfigProfilesDeleteAllButtonClick;
            // 
            // cfgProfileUpdateButton
            // 
            cfgProfileUpdateButton.Location = new Point(222, 335);
            cfgProfileUpdateButton.Name = "cfgProfileUpdateButton";
            cfgProfileUpdateButton.Size = new Size(180, 23);
            cfgProfileUpdateButton.TabIndex = 4;
            cfgProfileUpdateButton.Text = "Update a Config Profile";
            cfgProfileUpdateButton.UseVisualStyleBackColor = true;
            cfgProfileUpdateButton.Click += ConfigProfileUpdateButtonClick;
            // 
            // cfgProfilesExportButton
            // 
            cfgProfilesExportButton.Location = new Point(36, 291);
            cfgProfilesExportButton.Name = "cfgProfilesExportButton";
            cfgProfilesExportButton.Size = new Size(180, 23);
            cfgProfilesExportButton.TabIndex = 5;
            cfgProfilesExportButton.Text = "Export Config Profiles";
            cfgProfilesExportButton.UseVisualStyleBackColor = true;
            cfgProfilesExportButton.Click += ConfigProfilesExportButtonClick;
            // 
            // cfgProfilesImportButton
            // 
            cfgProfilesImportButton.Location = new Point(36, 320);
            cfgProfilesImportButton.Name = "cfgProfilesImportButton";
            cfgProfilesImportButton.Size = new Size(180, 23);
            cfgProfilesImportButton.TabIndex = 6;
            cfgProfilesImportButton.Text = "Import Config Profiles";
            cfgProfilesImportButton.UseVisualStyleBackColor = true;
            cfgProfilesImportButton.Click += ConfigProfilesImportButtonClick;
            // 
            // cfgProfileSelectButton
            // 
            cfgProfileSelectButton.Location = new Point(12, 377);
            cfgProfileSelectButton.Name = "cfgProfileSelectButton";
            cfgProfileSelectButton.Size = new Size(600, 23);
            cfgProfileSelectButton.TabIndex = 7;
            cfgProfileSelectButton.Text = "Select a Config Profile";
            cfgProfileSelectButton.UseVisualStyleBackColor = true;
            cfgProfileSelectButton.Click += ConfigProfileSelectButtonClick;
            // 
            // cfgProfileCopyButton
            // 
            cfgProfileCopyButton.Location = new Point(222, 306);
            cfgProfileCopyButton.Name = "cfgProfileCopyButton";
            cfgProfileCopyButton.Size = new Size(180, 23);
            cfgProfileCopyButton.TabIndex = 8;
            cfgProfileCopyButton.Text = "Copy a Config Profile";
            cfgProfileCopyButton.UseVisualStyleBackColor = true;
            cfgProfileCopyButton.Click += ConfigProfileCopyButtonClick;
            // 
            // formCloseButton
            // 
            formCloseButton.Location = new Point(12, 406);
            formCloseButton.Name = "formCloseButton";
            formCloseButton.Size = new Size(600, 23);
            formCloseButton.TabIndex = 9;
            formCloseButton.Text = "Close";
            formCloseButton.UseVisualStyleBackColor = true;
            formCloseButton.Click += FormCloseButtonClick;
            // 
            // cfgProfileCurrentLabel
            // 
            cfgProfileCurrentLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            cfgProfileCurrentLabel.Location = new Point(12, 9);
            cfgProfileCurrentLabel.Name = "cfgProfileCurrentLabel";
            cfgProfileCurrentLabel.Size = new Size(600, 60);
            cfgProfileCurrentLabel.TabIndex = 10;
            cfgProfileCurrentLabel.Text = "Select a Game Config Profile";
            cfgProfileCurrentLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameConfigProfilesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 441);
            Controls.Add(cfgProfileCurrentLabel);
            Controls.Add(formCloseButton);
            Controls.Add(cfgProfileCopyButton);
            Controls.Add(cfgProfileSelectButton);
            Controls.Add(cfgProfilesImportButton);
            Controls.Add(cfgProfilesExportButton);
            Controls.Add(cfgProfileUpdateButton);
            Controls.Add(cfgProfilesDeleteAllButton);
            Controls.Add(cfgProfileDeleteButton);
            Controls.Add(cfgProfileCreateButton);
            Controls.Add(gameConfigProfilesListBox);
            MaximizeBox = false;
            MaximumSize = new Size(640, 480);
            MinimizeBox = false;
            MinimumSize = new Size(640, 480);
            Name = "GameConfigProfilesForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Manage Config Profiles";
            ResumeLayout(false);
        }

        #endregion

        private ListBox gameConfigProfilesListBox;
        private Button cfgProfileCreateButton;
        private Button cfgProfileDeleteButton;
        private Button cfgProfilesDeleteAllButton;
        private Button cfgProfileUpdateButton;
        private Button cfgProfilesExportButton;
        private Button cfgProfilesImportButton;
        private Button cfgProfileSelectButton;
        private Button cfgProfileCopyButton;
        private Button formCloseButton;
        private Label cfgProfileCurrentLabel;
    }
}