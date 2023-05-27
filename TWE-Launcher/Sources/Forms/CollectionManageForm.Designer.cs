namespace TWE_Launcher.Forms
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
			buttonCollectionsSelectAll = new System.Windows.Forms.Button();
			collectionsCheckedListBox = new System.Windows.Forms.CheckedListBox();
			collectionsSelectionLabel = new System.Windows.Forms.Label();
			buttonCollectionsDelete = new System.Windows.Forms.Button();
			groupBoxCollectionsDelete = new System.Windows.Forms.GroupBox();
			buttonCollectionsDeselectAll = new System.Windows.Forms.Button();
			groupBoxCollectionsDelete.SuspendLayout();
			SuspendLayout();
			// 
			// buttonCollectionsSelectAll
			// 
			buttonCollectionsSelectAll.Location = new System.Drawing.Point(7, 306);
			buttonCollectionsSelectAll.Name = "buttonCollectionsSelectAll";
			buttonCollectionsSelectAll.Size = new System.Drawing.Size(88, 25);
			buttonCollectionsSelectAll.TabIndex = 1;
			buttonCollectionsSelectAll.Text = "Select All";
			buttonCollectionsSelectAll.UseVisualStyleBackColor = true;
			buttonCollectionsSelectAll.Click += buttonCollectionsSelectAll_Click;
			// 
			// collectionsCheckedListBox
			// 
			collectionsCheckedListBox.FormattingEnabled = true;
			collectionsCheckedListBox.Location = new System.Drawing.Point(7, 49);
			collectionsCheckedListBox.Name = "collectionsCheckedListBox";
			collectionsCheckedListBox.ScrollAlwaysVisible = true;
			collectionsCheckedListBox.Size = new System.Drawing.Size(206, 220);
			collectionsCheckedListBox.TabIndex = 4;
			// 
			// collectionsSelectionLabel
			// 
			collectionsSelectionLabel.AutoSize = true;
			collectionsSelectionLabel.Location = new System.Drawing.Point(27, 19);
			collectionsSelectionLabel.Name = "collectionsSelectionLabel";
			collectionsSelectionLabel.Size = new System.Drawing.Size(150, 15);
			collectionsSelectionLabel.TabIndex = 5;
			collectionsSelectionLabel.Text = "Select Collections to Delete";
			// 
			// buttonCollectionsDelete
			// 
			buttonCollectionsDelete.Location = new System.Drawing.Point(7, 275);
			buttonCollectionsDelete.Name = "buttonCollectionsDelete";
			buttonCollectionsDelete.Size = new System.Drawing.Size(206, 25);
			buttonCollectionsDelete.TabIndex = 6;
			buttonCollectionsDelete.Text = "Delete Selected";
			buttonCollectionsDelete.UseVisualStyleBackColor = true;
			buttonCollectionsDelete.Click += buttonCollectionsDelete_Click;
			// 
			// groupBoxCollectionsDelete
			// 
			groupBoxCollectionsDelete.Controls.Add(buttonCollectionsDeselectAll);
			groupBoxCollectionsDelete.Controls.Add(buttonCollectionsSelectAll);
			groupBoxCollectionsDelete.Controls.Add(collectionsSelectionLabel);
			groupBoxCollectionsDelete.Controls.Add(buttonCollectionsDelete);
			groupBoxCollectionsDelete.Controls.Add(collectionsCheckedListBox);
			groupBoxCollectionsDelete.Location = new System.Drawing.Point(12, 12);
			groupBoxCollectionsDelete.Name = "groupBoxCollectionsDelete";
			groupBoxCollectionsDelete.Size = new System.Drawing.Size(219, 337);
			groupBoxCollectionsDelete.TabIndex = 7;
			groupBoxCollectionsDelete.TabStop = false;
			groupBoxCollectionsDelete.Text = "Delete Existing Collections";
			// 
			// buttonCollectionsDeselectAll
			// 
			buttonCollectionsDeselectAll.Location = new System.Drawing.Point(125, 306);
			buttonCollectionsDeselectAll.Name = "buttonCollectionsDeselectAll";
			buttonCollectionsDeselectAll.Size = new System.Drawing.Size(88, 25);
			buttonCollectionsDeselectAll.TabIndex = 7;
			buttonCollectionsDeselectAll.Text = "Deselect All";
			buttonCollectionsDeselectAll.UseVisualStyleBackColor = true;
			buttonCollectionsDeselectAll.Click += buttonCollectionsDeselectAll_Click;
			// 
			// CollectionManageForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(244, 361);
			Controls.Add(groupBoxCollectionsDelete);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(260, 400);
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(260, 400);
			Name = "CollectionManageForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Manage Your Collections";
			groupBoxCollectionsDelete.ResumeLayout(false);
			groupBoxCollectionsDelete.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private System.Windows.Forms.Button buttonCollectionsSelectAll;
		private System.Windows.Forms.CheckedListBox collectionsCheckedListBox;
		private System.Windows.Forms.Label collectionsSelectionLabel;
		private System.Windows.Forms.Button buttonCollectionsDelete;
		private System.Windows.Forms.GroupBox groupBoxCollectionsDelete;
		private System.Windows.Forms.Button buttonCollectionsDeselectAll;
	}
}