namespace TWE_Launcher.Forms
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
			buttonOK = new System.Windows.Forms.Button();
			buttonCancel = new System.Windows.Forms.Button();
			collectionNameTextBox = new System.Windows.Forms.TextBox();
			collectionNameLabel = new System.Windows.Forms.Label();
			modsSelectionCheckedListBox = new System.Windows.Forms.CheckedListBox();
			modsSelectionLabel = new System.Windows.Forms.Label();
			SuspendLayout();
			// 
			// buttonOK
			// 
			buttonOK.Location = new System.Drawing.Point(12, 324);
			buttonOK.Name = "buttonOK";
			buttonOK.Size = new System.Drawing.Size(100, 25);
			buttonOK.TabIndex = 0;
			buttonOK.Text = "OK";
			buttonOK.UseVisualStyleBackColor = true;
			buttonOK.Click += buttonOK_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new System.Drawing.Point(118, 326);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new System.Drawing.Size(100, 25);
			buttonCancel.TabIndex = 1;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += buttonCancel_Click;
			// 
			// collectionNameTextBox
			// 
			collectionNameTextBox.Location = new System.Drawing.Point(12, 37);
			collectionNameTextBox.Name = "collectionNameTextBox";
			collectionNameTextBox.Size = new System.Drawing.Size(206, 23);
			collectionNameTextBox.TabIndex = 2;
			// 
			// collectionNameLabel
			// 
			collectionNameLabel.AutoSize = true;
			collectionNameLabel.Location = new System.Drawing.Point(12, 19);
			collectionNameLabel.Name = "collectionNameLabel";
			collectionNameLabel.Size = new System.Drawing.Size(189, 15);
			collectionNameLabel.TabIndex = 3;
			collectionNameLabel.Text = "Input a Name of a New Collection:";
			// 
			// modsSelectionCheckedListBox
			// 
			modsSelectionCheckedListBox.FormattingEnabled = true;
			modsSelectionCheckedListBox.Location = new System.Drawing.Point(12, 87);
			modsSelectionCheckedListBox.Name = "modsSelectionCheckedListBox";
			modsSelectionCheckedListBox.ScrollAlwaysVisible = true;
			modsSelectionCheckedListBox.Size = new System.Drawing.Size(206, 220);
			modsSelectionCheckedListBox.TabIndex = 4;
			// 
			// modsSelectionLabel
			// 
			modsSelectionLabel.AutoSize = true;
			modsSelectionLabel.Location = new System.Drawing.Point(12, 69);
			modsSelectionLabel.Name = "modsSelectionLabel";
			modsSelectionLabel.Size = new System.Drawing.Size(185, 15);
			modsSelectionLabel.TabIndex = 5;
			modsSelectionLabel.Text = "Select Mods for a New Collection:";
			// 
			// CollectionCreateForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(234, 361);
			Controls.Add(modsSelectionLabel);
			Controls.Add(modsSelectionCheckedListBox);
			Controls.Add(collectionNameLabel);
			Controls.Add(collectionNameTextBox);
			Controls.Add(buttonCancel);
			Controls.Add(buttonOK);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(250, 400);
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(250, 400);
			Name = "CollectionCreateForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Create a New Collection";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox collectionNameTextBox;
		private System.Windows.Forms.Label collectionNameLabel;
		private System.Windows.Forms.CheckedListBox modsSelectionCheckedListBox;
		private System.Windows.Forms.Label modsSelectionLabel;
	}
}