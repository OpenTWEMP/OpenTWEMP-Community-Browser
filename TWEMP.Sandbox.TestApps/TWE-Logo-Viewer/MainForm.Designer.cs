namespace TWE.LogoViewer
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.contentPictureBox = new System.Windows.Forms.PictureBox();
			this.appExitButton = new System.Windows.Forms.Button();
			this.contentLoadButton = new System.Windows.Forms.Button();
			this.contentClearButton = new System.Windows.Forms.Button();
			this.contentListBox = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.contentPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// contentPictureBox
			// 
			this.contentPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.contentPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.contentPictureBox.Location = new System.Drawing.Point(12, 12);
			this.contentPictureBox.MaximumSize = new System.Drawing.Size(1024, 768);
			this.contentPictureBox.MinimumSize = new System.Drawing.Size(1024, 768);
			this.contentPictureBox.Name = "contentPictureBox";
			this.contentPictureBox.Size = new System.Drawing.Size(1024, 768);
			this.contentPictureBox.TabIndex = 0;
			this.contentPictureBox.TabStop = false;
			// 
			// appExitButton
			// 
			this.appExitButton.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.appExitButton.Location = new System.Drawing.Point(1042, 787);
			this.appExitButton.Name = "appExitButton";
			this.appExitButton.Size = new System.Drawing.Size(210, 122);
			this.appExitButton.TabIndex = 1;
			this.appExitButton.Text = "EXIT";
			this.appExitButton.UseVisualStyleBackColor = true;
			this.appExitButton.Click += new System.EventHandler(this.appExitButton_Click);
			// 
			// contentLoadButton
			// 
			this.contentLoadButton.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.contentLoadButton.Location = new System.Drawing.Point(12, 786);
			this.contentLoadButton.Name = "contentLoadButton";
			this.contentLoadButton.Size = new System.Drawing.Size(496, 123);
			this.contentLoadButton.TabIndex = 2;
			this.contentLoadButton.Text = "LOAD";
			this.contentLoadButton.UseVisualStyleBackColor = true;
			this.contentLoadButton.Click += new System.EventHandler(this.contentLoadButton_Click);
			// 
			// contentClearButton
			// 
			this.contentClearButton.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.contentClearButton.Location = new System.Drawing.Point(514, 786);
			this.contentClearButton.Name = "contentClearButton";
			this.contentClearButton.Size = new System.Drawing.Size(522, 123);
			this.contentClearButton.TabIndex = 3;
			this.contentClearButton.Text = "CLEAR";
			this.contentClearButton.UseVisualStyleBackColor = true;
			this.contentClearButton.Click += new System.EventHandler(this.contentClearButton_Click);
			// 
			// contentListBox
			// 
			this.contentListBox.FormattingEnabled = true;
			this.contentListBox.ItemHeight = 15;
			this.contentListBox.Location = new System.Drawing.Point(1042, 12);
			this.contentListBox.Name = "contentListBox";
			this.contentListBox.Size = new System.Drawing.Size(210, 769);
			this.contentListBox.TabIndex = 4;
			this.contentListBox.SelectedIndexChanged += new System.EventHandler(this.contentListBox_SelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 921);
			this.Controls.Add(this.contentListBox);
			this.Controls.Add(this.contentClearButton);
			this.Controls.Add(this.contentLoadButton);
			this.Controls.Add(this.appExitButton);
			this.Controls.Add(this.contentPictureBox);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1280, 960);
			this.MinimumSize = new System.Drawing.Size(1280, 960);
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TWE Logo Viewer";
			((System.ComponentModel.ISupportInitialize)(this.contentPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox contentPictureBox;
		private System.Windows.Forms.Button appExitButton;
		private System.Windows.Forms.Button contentLoadButton;
		private System.Windows.Forms.Button contentClearButton;
		private System.Windows.Forms.ListBox contentListBox;
	}
}
