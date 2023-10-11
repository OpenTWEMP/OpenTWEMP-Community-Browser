namespace TWEMP.Browser.App.Classic.CommonLibrary
{
    partial class CollectionManageForm
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
            buttonCollectionsSelectAll = new Button();
            collectionsCheckedListBox = new CheckedListBox();
            collectionsSelectionLabel = new Label();
            buttonCollectionsDelete = new Button();
            groupBoxCollectionsDelete = new GroupBox();
            buttonCollectionsDeselectAll = new Button();
            groupBoxCollectionsDelete.SuspendLayout();
            SuspendLayout();
            // 
            // buttonCollectionsSelectAll
            // 
            buttonCollectionsSelectAll.Location = new Point(7, 306);
            buttonCollectionsSelectAll.Name = "buttonCollectionsSelectAll";
            buttonCollectionsSelectAll.Size = new Size(150, 25);
            buttonCollectionsSelectAll.TabIndex = 1;
            buttonCollectionsSelectAll.Text = "Select All";
            buttonCollectionsSelectAll.UseVisualStyleBackColor = true;
            buttonCollectionsSelectAll.Click += ButtonCollectionsSelectAll_Click;
            // 
            // collectionsCheckedListBox
            // 
            collectionsCheckedListBox.FormattingEnabled = true;
            collectionsCheckedListBox.Location = new Point(7, 67);
            collectionsCheckedListBox.Name = "collectionsCheckedListBox";
            collectionsCheckedListBox.ScrollAlwaysVisible = true;
            collectionsCheckedListBox.Size = new Size(347, 202);
            collectionsCheckedListBox.TabIndex = 4;
            // 
            // collectionsSelectionLabel
            // 
            collectionsSelectionLabel.Location = new Point(7, 19);
            collectionsSelectionLabel.Name = "collectionsSelectionLabel";
            collectionsSelectionLabel.Size = new Size(347, 45);
            collectionsSelectionLabel.TabIndex = 5;
            collectionsSelectionLabel.Text = "Select Collections to Delete";
            collectionsSelectionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonCollectionsDelete
            // 
            buttonCollectionsDelete.Location = new Point(7, 275);
            buttonCollectionsDelete.Name = "buttonCollectionsDelete";
            buttonCollectionsDelete.Size = new Size(347, 25);
            buttonCollectionsDelete.TabIndex = 6;
            buttonCollectionsDelete.Text = "Delete Selected";
            buttonCollectionsDelete.UseVisualStyleBackColor = true;
            buttonCollectionsDelete.Click += ButtonCollectionsDelete_Click;
            // 
            // groupBoxCollectionsDelete
            // 
            groupBoxCollectionsDelete.Controls.Add(buttonCollectionsDeselectAll);
            groupBoxCollectionsDelete.Controls.Add(buttonCollectionsSelectAll);
            groupBoxCollectionsDelete.Controls.Add(collectionsSelectionLabel);
            groupBoxCollectionsDelete.Controls.Add(buttonCollectionsDelete);
            groupBoxCollectionsDelete.Controls.Add(collectionsCheckedListBox);
            groupBoxCollectionsDelete.Location = new Point(12, 12);
            groupBoxCollectionsDelete.Name = "groupBoxCollectionsDelete";
            groupBoxCollectionsDelete.Size = new Size(360, 337);
            groupBoxCollectionsDelete.TabIndex = 7;
            groupBoxCollectionsDelete.TabStop = false;
            groupBoxCollectionsDelete.Text = "Delete Existing Collections";
            // 
            // buttonCollectionsDeselectAll
            // 
            buttonCollectionsDeselectAll.Location = new Point(204, 306);
            buttonCollectionsDeselectAll.Name = "buttonCollectionsDeselectAll";
            buttonCollectionsDeselectAll.Size = new Size(150, 25);
            buttonCollectionsDeselectAll.TabIndex = 7;
            buttonCollectionsDeselectAll.Text = "Deselect All";
            buttonCollectionsDeselectAll.UseVisualStyleBackColor = true;
            buttonCollectionsDeselectAll.Click += ButtonCollectionsDeselectAll_Click;
            // 
            // CollectionManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(groupBoxCollectionsDelete);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(400, 400);
            MinimizeBox = false;
            MinimumSize = new Size(400, 400);
            Name = "CollectionManageForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Your Collections";
            groupBoxCollectionsDelete.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button buttonCollectionsSelectAll;
        private CheckedListBox collectionsCheckedListBox;
        private Label collectionsSelectionLabel;
        private Button buttonCollectionsDelete;
        private GroupBox groupBoxCollectionsDelete;
        private Button buttonCollectionsDeselectAll;
    }
}