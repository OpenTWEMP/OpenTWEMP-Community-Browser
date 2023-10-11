namespace TWEMP.Browser.App.Classic.CommonLibrary
{
    partial class GameSetupConfigForm
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
            setupPathAddButton = new Button();
            setupPathDeleteButton = new Button();
            gameSetupPathsListBox = new ListBox();
            allPathsClearButton = new Button();
            formOkButton = new Button();
            SuspendLayout();
            // 
            // setupPathAddButton
            // 
            setupPathAddButton.Location = new Point(12, 314);
            setupPathAddButton.Name = "setupPathAddButton";
            setupPathAddButton.Size = new Size(144, 52);
            setupPathAddButton.TabIndex = 0;
            setupPathAddButton.Text = "ADD SETUP PATH";
            setupPathAddButton.UseVisualStyleBackColor = true;
            setupPathAddButton.Click += SetupPathAddButton_Click;
            // 
            // setupPathDeleteButton
            // 
            setupPathDeleteButton.Enabled = false;
            setupPathDeleteButton.Location = new Point(162, 314);
            setupPathDeleteButton.Name = "setupPathDeleteButton";
            setupPathDeleteButton.Size = new Size(138, 52);
            setupPathDeleteButton.TabIndex = 2;
            setupPathDeleteButton.Text = "DELETE SETUP PATH";
            setupPathDeleteButton.UseVisualStyleBackColor = true;
            setupPathDeleteButton.Click += SetupPathDeleteButton_Click;
            // 
            // gameSetupPathsListBox
            // 
            gameSetupPathsListBox.FormattingEnabled = true;
            gameSetupPathsListBox.ItemHeight = 15;
            gameSetupPathsListBox.Location = new Point(12, 12);
            gameSetupPathsListBox.Name = "gameSetupPathsListBox";
            gameSetupPathsListBox.Size = new Size(583, 289);
            gameSetupPathsListBox.TabIndex = 4;
            gameSetupPathsListBox.Click += GameSetupPathsListBox_Click;
            gameSetupPathsListBox.SelectedIndexChanged += GameSetupPathsListBox_SelectedIndexChanged;
            // 
            // allPathsClearButton
            // 
            allPathsClearButton.Location = new Point(313, 314);
            allPathsClearButton.Name = "allPathsClearButton";
            allPathsClearButton.Size = new Size(138, 52);
            allPathsClearButton.TabIndex = 5;
            allPathsClearButton.Text = "CLEAR ALL PATHS";
            allPathsClearButton.UseVisualStyleBackColor = true;
            allPathsClearButton.Click += AllPathsClearButton_Click;
            // 
            // formOkButton
            // 
            formOkButton.Location = new Point(457, 314);
            formOkButton.Name = "formOkButton";
            formOkButton.Size = new Size(138, 52);
            formOkButton.TabIndex = 7;
            formOkButton.Text = "OK";
            formOkButton.UseVisualStyleBackColor = true;
            formOkButton.Click += FormOkButton_Click;
            // 
            // GameSetupConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 378);
            Controls.Add(formOkButton);
            Controls.Add(allPathsClearButton);
            Controls.Add(gameSetupPathsListBox);
            Controls.Add(setupPathDeleteButton);
            Controls.Add(setupPathAddButton);
            MaximizeBox = false;
            MaximumSize = new Size(623, 417);
            MinimizeBox = false;
            MinimumSize = new Size(623, 417);
            Name = "GameSetupConfigForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Game Setup Settings";
            FormClosed += GameSetupConfigForm_FormClosed;
            Load += GameSetupConfigForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button setupPathAddButton;
        private Button setupPathDeleteButton;
        private ListBox gameSetupPathsListBox;
        private Button allPathsClearButton;
        private Button formOkButton;
    }
}
