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
			this.setupPathAddButton = new System.Windows.Forms.Button();
			this.setupPathDeleteButton = new System.Windows.Forms.Button();
			this.gameSetupPathsListBox = new System.Windows.Forms.ListBox();
			this.allPathsClearButton = new System.Windows.Forms.Button();
			this.setupViewButton = new System.Windows.Forms.Button();
			this.formOkButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// setupPathAddButton
			// 
			this.setupPathAddButton.Location = new System.Drawing.Point(162, 314);
			this.setupPathAddButton.Name = "setupPathAddButton";
			this.setupPathAddButton.Size = new System.Drawing.Size(138, 23);
			this.setupPathAddButton.TabIndex = 0;
			this.setupPathAddButton.Text = "ADD SETUP PATH";
			this.setupPathAddButton.UseVisualStyleBackColor = true;
			this.setupPathAddButton.Click += new System.EventHandler(this.setupPathAddButton_Click);
			// 
			// setupPathDeleteButton
			// 
			this.setupPathDeleteButton.Enabled = false;
			this.setupPathDeleteButton.Location = new System.Drawing.Point(162, 343);
			this.setupPathDeleteButton.Name = "setupPathDeleteButton";
			this.setupPathDeleteButton.Size = new System.Drawing.Size(138, 23);
			this.setupPathDeleteButton.TabIndex = 2;
			this.setupPathDeleteButton.Text = "DELETE SETUP PATH";
			this.setupPathDeleteButton.UseVisualStyleBackColor = true;
			this.setupPathDeleteButton.Click += new System.EventHandler(this.setupPathDeleteButton_Click);
			// 
			// gameSetupPathsListBox
			// 
			this.gameSetupPathsListBox.FormattingEnabled = true;
			this.gameSetupPathsListBox.ItemHeight = 15;
			this.gameSetupPathsListBox.Location = new System.Drawing.Point(12, 12);
			this.gameSetupPathsListBox.Name = "gameSetupPathsListBox";
			this.gameSetupPathsListBox.Size = new System.Drawing.Size(583, 289);
			this.gameSetupPathsListBox.TabIndex = 4;
			this.gameSetupPathsListBox.Click += new System.EventHandler(this.gameSetupPathsListBox_Click);
			this.gameSetupPathsListBox.SelectedIndexChanged += new System.EventHandler(this.gameSetupPathsListBox_SelectedIndexChanged);
			// 
			// allPathsClearButton
			// 
			this.allPathsClearButton.Location = new System.Drawing.Point(306, 314);
			this.allPathsClearButton.Name = "allPathsClearButton";
			this.allPathsClearButton.Size = new System.Drawing.Size(138, 52);
			this.allPathsClearButton.TabIndex = 5;
			this.allPathsClearButton.Text = "CLEAR ALL PATHS";
			this.allPathsClearButton.UseVisualStyleBackColor = true;
			this.allPathsClearButton.Click += new System.EventHandler(this.allPathsClearButton_Click);
			// 
			// setupViewButton
			// 
			this.setupViewButton.Enabled = false;
			this.setupViewButton.Location = new System.Drawing.Point(12, 314);
			this.setupViewButton.Name = "setupViewButton";
			this.setupViewButton.Size = new System.Drawing.Size(144, 52);
			this.setupViewButton.TabIndex = 6;
			this.setupViewButton.Text = "VIEW GAME SETUP INFO";
			this.setupViewButton.UseVisualStyleBackColor = true;
			this.setupViewButton.Click += new System.EventHandler(this.setupViewButton_Click);
			// 
			// formOkButton
			// 
			this.formOkButton.Location = new System.Drawing.Point(457, 314);
			this.formOkButton.Name = "formOkButton";
			this.formOkButton.Size = new System.Drawing.Size(138, 52);
			this.formOkButton.TabIndex = 7;
			this.formOkButton.Text = "OK";
			this.formOkButton.UseVisualStyleBackColor = true;
			this.formOkButton.Click += new System.EventHandler(this.formOkButton_Click);
			// 
			// GameSetupConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(607, 378);
			this.Controls.Add(this.formOkButton);
			this.Controls.Add(this.setupViewButton);
			this.Controls.Add(this.allPathsClearButton);
			this.Controls.Add(this.gameSetupPathsListBox);
			this.Controls.Add(this.setupPathDeleteButton);
			this.Controls.Add(this.setupPathAddButton);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(623, 417);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(623, 417);
			this.Name = "GameSetupConfigForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game Setup Settings";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameSetupConfigForm_FormClosed);
			this.Load += new System.EventHandler(this.GameSetupConfigForm_Load);
			this.ResumeLayout(false);

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