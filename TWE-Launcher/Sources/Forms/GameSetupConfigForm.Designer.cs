namespace TWE_Launcher.Forms
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
			setupPathAddButton = new System.Windows.Forms.Button();
			setupPathDeleteButton = new System.Windows.Forms.Button();
			gameSetupPathsListBox = new System.Windows.Forms.ListBox();
			allPathsClearButton = new System.Windows.Forms.Button();
			setupViewButton = new System.Windows.Forms.Button();
			formOkButton = new System.Windows.Forms.Button();
			SuspendLayout();
			// 
			// setupPathAddButton
			// 
			setupPathAddButton.Location = new System.Drawing.Point(162, 314);
			setupPathAddButton.Name = "setupPathAddButton";
			setupPathAddButton.Size = new System.Drawing.Size(138, 23);
			setupPathAddButton.TabIndex = 0;
			setupPathAddButton.Text = "ADD SETUP PATH";
			setupPathAddButton.UseVisualStyleBackColor = true;
			setupPathAddButton.Click += setupPathAddButton_Click;
			// 
			// setupPathDeleteButton
			// 
			setupPathDeleteButton.Enabled = false;
			setupPathDeleteButton.Location = new System.Drawing.Point(162, 343);
			setupPathDeleteButton.Name = "setupPathDeleteButton";
			setupPathDeleteButton.Size = new System.Drawing.Size(138, 23);
			setupPathDeleteButton.TabIndex = 2;
			setupPathDeleteButton.Text = "DELETE SETUP PATH";
			setupPathDeleteButton.UseVisualStyleBackColor = true;
			setupPathDeleteButton.Click += setupPathDeleteButton_Click;
			// 
			// gameSetupPathsListBox
			// 
			gameSetupPathsListBox.FormattingEnabled = true;
			gameSetupPathsListBox.ItemHeight = 15;
			gameSetupPathsListBox.Location = new System.Drawing.Point(12, 12);
			gameSetupPathsListBox.Name = "gameSetupPathsListBox";
			gameSetupPathsListBox.Size = new System.Drawing.Size(583, 289);
			gameSetupPathsListBox.TabIndex = 4;
			gameSetupPathsListBox.Click += gameSetupPathsListBox_Click;
			gameSetupPathsListBox.SelectedIndexChanged += gameSetupPathsListBox_SelectedIndexChanged;
			// 
			// allPathsClearButton
			// 
			allPathsClearButton.Location = new System.Drawing.Point(306, 314);
			allPathsClearButton.Name = "allPathsClearButton";
			allPathsClearButton.Size = new System.Drawing.Size(138, 52);
			allPathsClearButton.TabIndex = 5;
			allPathsClearButton.Text = "CLEAR ALL PATHS";
			allPathsClearButton.UseVisualStyleBackColor = true;
			allPathsClearButton.Click += allPathsClearButton_Click;
			// 
			// setupViewButton
			// 
			setupViewButton.Enabled = false;
			setupViewButton.Location = new System.Drawing.Point(12, 314);
			setupViewButton.Name = "setupViewButton";
			setupViewButton.Size = new System.Drawing.Size(144, 52);
			setupViewButton.TabIndex = 6;
			setupViewButton.Text = "VIEW GAME SETUP INFO";
			setupViewButton.UseVisualStyleBackColor = true;
			setupViewButton.Click += setupViewButton_Click;
			// 
			// formOkButton
			// 
			formOkButton.Location = new System.Drawing.Point(457, 314);
			formOkButton.Name = "formOkButton";
			formOkButton.Size = new System.Drawing.Size(138, 52);
			formOkButton.TabIndex = 7;
			formOkButton.Text = "OK";
			formOkButton.UseVisualStyleBackColor = true;
			formOkButton.Click += formOkButton_Click;
			// 
			// GameSetupConfigForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(607, 378);
			Controls.Add(formOkButton);
			Controls.Add(setupViewButton);
			Controls.Add(allPathsClearButton);
			Controls.Add(gameSetupPathsListBox);
			Controls.Add(setupPathDeleteButton);
			Controls.Add(setupPathAddButton);
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(623, 417);
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(623, 417);
			Name = "GameSetupConfigForm";
			ShowIcon = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Game Setup Settings";
			FormClosed += GameSetupConfigForm_FormClosed;
			Load += GameSetupConfigForm_Load;
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button setupPathAddButton;
		private System.Windows.Forms.Button setupPathDeleteButton;
		private System.Windows.Forms.ListBox gameSetupPathsListBox;
		private System.Windows.Forms.Button allPathsClearButton;
		private System.Windows.Forms.Button setupViewButton;
		private System.Windows.Forms.Button formOkButton;
	}
}