namespace TWEMP.Browser.App.Classic.CommonLibrary
{
    partial class CollectionCreateForm
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
            buttonOK = new Button();
            buttonCancel = new Button();
            collectionNameTextBox = new TextBox();
            collectionNameLabel = new Label();
            modsSelectionCheckedListBox = new CheckedListBox();
            modsSelectionLabel = new Label();
            SuspendLayout();
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(12, 293);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(360, 25);
            buttonOK.TabIndex = 0;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(12, 324);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(360, 25);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // collectionNameTextBox
            // 
            collectionNameTextBox.Location = new Point(12, 37);
            collectionNameTextBox.Name = "collectionNameTextBox";
            collectionNameTextBox.Size = new Size(360, 23);
            collectionNameTextBox.TabIndex = 2;
            // 
            // collectionNameLabel
            // 
            collectionNameLabel.Location = new Point(12, 9);
            collectionNameLabel.Name = "collectionNameLabel";
            collectionNameLabel.Size = new Size(360, 25);
            collectionNameLabel.TabIndex = 3;
            collectionNameLabel.Text = "Input a Name of a New Collection:";
            collectionNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // modsSelectionCheckedListBox
            // 
            modsSelectionCheckedListBox.FormattingEnabled = true;
            modsSelectionCheckedListBox.Location = new Point(12, 105);
            modsSelectionCheckedListBox.Name = "modsSelectionCheckedListBox";
            modsSelectionCheckedListBox.ScrollAlwaysVisible = true;
            modsSelectionCheckedListBox.Size = new Size(360, 184);
            modsSelectionCheckedListBox.TabIndex = 4;
            // 
            // modsSelectionLabel
            // 
            modsSelectionLabel.Location = new Point(12, 72);
            modsSelectionLabel.Name = "modsSelectionLabel";
            modsSelectionLabel.Size = new Size(360, 30);
            modsSelectionLabel.TabIndex = 5;
            modsSelectionLabel.Text = "Select Mods for a New Collection:";
            modsSelectionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CollectionCreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(modsSelectionLabel);
            Controls.Add(modsSelectionCheckedListBox);
            Controls.Add(collectionNameLabel);
            Controls.Add(collectionNameTextBox);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(400, 400);
            MinimizeBox = false;
            MinimumSize = new Size(400, 400);
            Name = "CollectionCreateForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create a New Collection";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonOK;
        private Button buttonCancel;
        private TextBox collectionNameTextBox;
        private Label collectionNameLabel;
        private CheckedListBox modsSelectionCheckedListBox;
        private Label modsSelectionLabel;
    }
}