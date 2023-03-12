namespace TWE_Launcher.Sources.Forms
{
	partial class AboutProjectForm
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
			aboutProjectPanel = new System.Windows.Forms.Panel();
			aboutProjectNameLabel1 = new System.Windows.Forms.Label();
			aboutProjectNameLabel2 = new System.Windows.Forms.Label();
			aboutProjectPanel.SuspendLayout();
			SuspendLayout();
			// 
			// aboutProjectPanel
			// 
			aboutProjectPanel.BackColor = System.Drawing.Color.Black;
			aboutProjectPanel.Controls.Add(aboutProjectNameLabel1);
			aboutProjectPanel.Controls.Add(aboutProjectNameLabel2);
			aboutProjectPanel.Location = new System.Drawing.Point(12, 12);
			aboutProjectPanel.Name = "aboutProjectPanel";
			aboutProjectPanel.Size = new System.Drawing.Size(1051, 284);
			aboutProjectPanel.TabIndex = 13;
			// 
			// aboutProjectNameLabel1
			// 
			aboutProjectNameLabel1.BackColor = System.Drawing.Color.Transparent;
			aboutProjectNameLabel1.Font = new System.Drawing.Font("Dungeon", 96F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			aboutProjectNameLabel1.ForeColor = System.Drawing.Color.LimeGreen;
			aboutProjectNameLabel1.Location = new System.Drawing.Point(29, 12);
			aboutProjectNameLabel1.Name = "aboutProjectNameLabel1";
			aboutProjectNameLabel1.Size = new System.Drawing.Size(1009, 188);
			aboutProjectNameLabel1.TabIndex = 10;
			aboutProjectNameLabel1.Text = "OpenTWEMP";
			aboutProjectNameLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// aboutProjectNameLabel2
			// 
			aboutProjectNameLabel2.BackColor = System.Drawing.Color.Transparent;
			aboutProjectNameLabel2.Font = new System.Drawing.Font("Gadugi", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			aboutProjectNameLabel2.ForeColor = System.Drawing.Color.LemonChiffon;
			aboutProjectNameLabel2.Location = new System.Drawing.Point(215, 180);
			aboutProjectNameLabel2.Name = "aboutProjectNameLabel2";
			aboutProjectNameLabel2.Size = new System.Drawing.Size(649, 93);
			aboutProjectNameLabel2.TabIndex = 11;
			aboutProjectNameLabel2.Text = "Community Browser";
			// 
			// AboutProjectForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoSize = true;
			ClientSize = new System.Drawing.Size(1080, 312);
			Controls.Add(aboutProjectPanel);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AboutProjectForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "AboutProjectForm";
			aboutProjectPanel.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Panel aboutProjectPanel;
		private System.Windows.Forms.Label aboutProjectNameLabel1;
		private System.Windows.Forms.Label aboutProjectNameLabel2;
	}
}