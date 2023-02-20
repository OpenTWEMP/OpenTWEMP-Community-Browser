namespace TWE_Launcher.Forms
{
	partial class AddNewGameSetupForm
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
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.gameSetupNameTextBox = new System.Windows.Forms.TextBox();
			this.gameExecutablePathTextBox = new System.Windows.Forms.TextBox();
			this.modcentersGroupBox = new System.Windows.Forms.GroupBox();
			this.modcentersListBox = new System.Windows.Forms.ListBox();
			this.modcenterAppendButton = new System.Windows.Forms.Button();
			this.modcenterRemoveButton = new System.Windows.Forms.Button();
			this.gameExecutableSelectPathButton = new System.Windows.Forms.Button();
			this.gameExecutablePathLabel = new System.Windows.Forms.Label();
			this.gameSetupNameLabel = new System.Windows.Forms.Label();
			this.gameSetupGroupBox = new System.Windows.Forms.GroupBox();
			this.panelGameExecutable = new System.Windows.Forms.Panel();
			this.panelGameSetupName = new System.Windows.Forms.Panel();
			this.setupNameResetButton = new System.Windows.Forms.Button();
			this.panelGameSetupButtons = new System.Windows.Forms.Panel();
			this.modcentersGroupBox.SuspendLayout();
			this.gameSetupGroupBox.SuspendLayout();
			this.panelGameExecutable.SuspendLayout();
			this.panelGameSetupName.SuspendLayout();
			this.panelGameSetupButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(3, 2);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(265, 23);
			this.saveButton.TabIndex = 0;
			this.saveButton.Text = "OK";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(335, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(258, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// gameSetupNameTextBox
			// 
			this.gameSetupNameTextBox.Location = new System.Drawing.Point(155, 5);
			this.gameSetupNameTextBox.Name = "gameSetupNameTextBox";
			this.gameSetupNameTextBox.Size = new System.Drawing.Size(347, 23);
			this.gameSetupNameTextBox.TabIndex = 2;
			this.gameSetupNameTextBox.Text = "MyGameSetupName";
			// 
			// gameExecutablePathTextBox
			// 
			this.gameExecutablePathTextBox.Enabled = false;
			this.gameExecutablePathTextBox.Location = new System.Drawing.Point(153, 3);
			this.gameExecutablePathTextBox.Name = "gameExecutablePathTextBox";
			this.gameExecutablePathTextBox.Size = new System.Drawing.Size(346, 23);
			this.gameExecutablePathTextBox.TabIndex = 3;
			this.gameExecutablePathTextBox.Text = "\'kingdoms.exe\' (Classic) or \'medieval2.exe\' (Steam)";
			// 
			// modcentersGroupBox
			// 
			this.modcentersGroupBox.Controls.Add(this.modcentersListBox);
			this.modcentersGroupBox.Controls.Add(this.modcenterAppendButton);
			this.modcentersGroupBox.Controls.Add(this.modcenterRemoveButton);
			this.modcentersGroupBox.Location = new System.Drawing.Point(26, 161);
			this.modcentersGroupBox.Name = "modcentersGroupBox";
			this.modcentersGroupBox.Size = new System.Drawing.Size(596, 251);
			this.modcentersGroupBox.TabIndex = 10;
			this.modcentersGroupBox.TabStop = false;
			this.modcentersGroupBox.Text = "Configure Paths to Your ModCenter";
			// 
			// modcentersListBox
			// 
			this.modcentersListBox.FormattingEnabled = true;
			this.modcentersListBox.ItemHeight = 15;
			this.modcentersListBox.Location = new System.Drawing.Point(6, 22);
			this.modcentersListBox.Name = "modcentersListBox";
			this.modcentersListBox.Size = new System.Drawing.Size(396, 214);
			this.modcentersListBox.TabIndex = 24;
			this.modcentersListBox.SelectedIndexChanged += new System.EventHandler(this.modcentersListBox_SelectedIndexChanged);
			// 
			// modcenterAppendButton
			// 
			this.modcenterAppendButton.Location = new System.Drawing.Point(408, 22);
			this.modcenterAppendButton.Name = "modcenterAppendButton";
			this.modcenterAppendButton.Size = new System.Drawing.Size(182, 23);
			this.modcenterAppendButton.TabIndex = 14;
			this.modcenterAppendButton.Text = "Append ModCenter";
			this.modcenterAppendButton.UseVisualStyleBackColor = true;
			this.modcenterAppendButton.Click += new System.EventHandler(this.modcenterAppendButton_Click);
			// 
			// modcenterRemoveButton
			// 
			this.modcenterRemoveButton.Enabled = false;
			this.modcenterRemoveButton.Location = new System.Drawing.Point(408, 51);
			this.modcenterRemoveButton.Name = "modcenterRemoveButton";
			this.modcenterRemoveButton.Size = new System.Drawing.Size(182, 23);
			this.modcenterRemoveButton.TabIndex = 15;
			this.modcenterRemoveButton.Text = "Remove ModCenter";
			this.modcenterRemoveButton.UseVisualStyleBackColor = true;
			this.modcenterRemoveButton.Click += new System.EventHandler(this.modcenterRemoveButton_Click);
			// 
			// gameExecutableSelectPathButton
			// 
			this.gameExecutableSelectPathButton.Location = new System.Drawing.Point(505, 5);
			this.gameExecutableSelectPathButton.Name = "gameExecutableSelectPathButton";
			this.gameExecutableSelectPathButton.Size = new System.Drawing.Size(75, 23);
			this.gameExecutableSelectPathButton.TabIndex = 11;
			this.gameExecutableSelectPathButton.Text = "Select";
			this.gameExecutableSelectPathButton.UseVisualStyleBackColor = true;
			this.gameExecutableSelectPathButton.Click += new System.EventHandler(this.gameExecutableSelectPathButton_Click);
			// 
			// gameExecutablePathLabel
			// 
			this.gameExecutablePathLabel.AutoSize = true;
			this.gameExecutablePathLabel.Location = new System.Drawing.Point(3, 5);
			this.gameExecutablePathLabel.Name = "gameExecutablePathLabel";
			this.gameExecutablePathLabel.Size = new System.Drawing.Size(144, 15);
			this.gameExecutablePathLabel.TabIndex = 12;
			this.gameExecutablePathLabel.Text = "Set Game Executable Path";
			// 
			// gameSetupNameLabel
			// 
			this.gameSetupNameLabel.AutoSize = true;
			this.gameSetupNameLabel.Location = new System.Drawing.Point(6, 8);
			this.gameSetupNameLabel.Name = "gameSetupNameLabel";
			this.gameSetupNameLabel.Size = new System.Drawing.Size(143, 15);
			this.gameSetupNameLabel.TabIndex = 13;
			this.gameSetupNameLabel.Text = "Define Game Setup Name";
			// 
			// gameSetupGroupBox
			// 
			this.gameSetupGroupBox.Controls.Add(this.panelGameExecutable);
			this.gameSetupGroupBox.Controls.Add(this.panelGameSetupName);
			this.gameSetupGroupBox.Location = new System.Drawing.Point(21, 16);
			this.gameSetupGroupBox.Name = "gameSetupGroupBox";
			this.gameSetupGroupBox.Size = new System.Drawing.Size(601, 139);
			this.gameSetupGroupBox.TabIndex = 14;
			this.gameSetupGroupBox.TabStop = false;
			this.gameSetupGroupBox.Text = "Game Setup Main Settings";
			// 
			// panelGameExecutable
			// 
			this.panelGameExecutable.Controls.Add(this.gameExecutablePathLabel);
			this.panelGameExecutable.Controls.Add(this.gameExecutablePathTextBox);
			this.panelGameExecutable.Controls.Add(this.gameExecutableSelectPathButton);
			this.panelGameExecutable.Location = new System.Drawing.Point(12, 79);
			this.panelGameExecutable.Name = "panelGameExecutable";
			this.panelGameExecutable.Size = new System.Drawing.Size(583, 40);
			this.panelGameExecutable.TabIndex = 15;
			// 
			// panelGameSetupName
			// 
			this.panelGameSetupName.Controls.Add(this.setupNameResetButton);
			this.panelGameSetupName.Controls.Add(this.gameSetupNameLabel);
			this.panelGameSetupName.Controls.Add(this.gameSetupNameTextBox);
			this.panelGameSetupName.Location = new System.Drawing.Point(9, 22);
			this.panelGameSetupName.Name = "panelGameSetupName";
			this.panelGameSetupName.Size = new System.Drawing.Size(586, 36);
			this.panelGameSetupName.TabIndex = 14;
			// 
			// setupNameResetButton
			// 
			this.setupNameResetButton.Location = new System.Drawing.Point(508, 4);
			this.setupNameResetButton.Name = "setupNameResetButton";
			this.setupNameResetButton.Size = new System.Drawing.Size(75, 23);
			this.setupNameResetButton.TabIndex = 14;
			this.setupNameResetButton.Text = "Reset";
			this.setupNameResetButton.UseVisualStyleBackColor = true;
			this.setupNameResetButton.Click += new System.EventHandler(this.setupNameResetButton_Click);
			// 
			// panelGameSetupButtons
			// 
			this.panelGameSetupButtons.Controls.Add(this.saveButton);
			this.panelGameSetupButtons.Controls.Add(this.cancelButton);
			this.panelGameSetupButtons.Location = new System.Drawing.Point(26, 418);
			this.panelGameSetupButtons.Name = "panelGameSetupButtons";
			this.panelGameSetupButtons.Size = new System.Drawing.Size(596, 28);
			this.panelGameSetupButtons.TabIndex = 15;
			// 
			// AddNewGameSetupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 461);
			this.Controls.Add(this.panelGameSetupButtons);
			this.Controls.Add(this.gameSetupGroupBox);
			this.Controls.Add(this.modcentersGroupBox);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(650, 500);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(650, 500);
			this.Name = "AddNewGameSetupForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add New Game Setup";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddNewGameSetupForm_FormClosed);
			this.modcentersGroupBox.ResumeLayout(false);
			this.gameSetupGroupBox.ResumeLayout(false);
			this.panelGameExecutable.ResumeLayout(false);
			this.panelGameExecutable.PerformLayout();
			this.panelGameSetupName.ResumeLayout(false);
			this.panelGameSetupName.PerformLayout();
			this.panelGameSetupButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TextBox gameSetupNameTextBox;
		private System.Windows.Forms.TextBox gameExecutablePathTextBox;
		private System.Windows.Forms.GroupBox modcentersGroupBox;
		private System.Windows.Forms.Button modcenterRemoveButton;
		private System.Windows.Forms.Button modcenterAppendButton;
		private System.Windows.Forms.Button gameExecutableSelectPathButton;
		private System.Windows.Forms.Label gameExecutablePathLabel;
		private System.Windows.Forms.Label gameSetupNameLabel;
		private System.Windows.Forms.GroupBox gameSetupGroupBox;
		private System.Windows.Forms.Panel panelGameExecutable;
		private System.Windows.Forms.Panel panelGameSetupName;
		private System.Windows.Forms.Panel panelGameSetupButtons;
		private System.Windows.Forms.ListBox modcentersListBox;
		private System.Windows.Forms.Button setupNameResetButton;
	}
}