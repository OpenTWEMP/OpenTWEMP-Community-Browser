namespace TWEMP.Browser.App.Classic.CommonLibrary
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
            aboutProjectNameLabel1 = new Label();
            aboutProjectNameLabel2 = new Label();
            aboutProjectNameLabel4 = new Label();
            aboutProjectNameLabel3 = new Label();
            SuspendLayout();
            // 
            // aboutProjectNameLabel1
            // 
            aboutProjectNameLabel1.BackColor = Color.Transparent;
            aboutProjectNameLabel1.Font = new Font("Dungeon", 48F, FontStyle.Bold);
            aboutProjectNameLabel1.ForeColor = Color.LimeGreen;
            aboutProjectNameLabel1.Location = new Point(12, 9);
            aboutProjectNameLabel1.Name = "aboutProjectNameLabel1";
            aboutProjectNameLabel1.Size = new Size(486, 101);
            aboutProjectNameLabel1.TabIndex = 10;
            aboutProjectNameLabel1.Text = "OpenTWEMP";
            aboutProjectNameLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // aboutProjectNameLabel2
            // 
            aboutProjectNameLabel2.BackColor = Color.Transparent;
            aboutProjectNameLabel2.Font = new Font("Gadugi", 24F, FontStyle.Bold);
            aboutProjectNameLabel2.ForeColor = Color.LemonChiffon;
            aboutProjectNameLabel2.Location = new Point(12, 101);
            aboutProjectNameLabel2.Name = "aboutProjectNameLabel2";
            aboutProjectNameLabel2.Size = new Size(486, 52);
            aboutProjectNameLabel2.TabIndex = 11;
            aboutProjectNameLabel2.Text = "Community Browser";
            aboutProjectNameLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // aboutProjectNameLabel4
            // 
            aboutProjectNameLabel4.Font = new Font("Segoe UI", 14F);
            aboutProjectNameLabel4.ForeColor = Color.Azure;
            aboutProjectNameLabel4.Location = new Point(12, 198);
            aboutProjectNameLabel4.Name = "aboutProjectNameLabel4";
            aboutProjectNameLabel4.Size = new Size(486, 38);
            aboutProjectNameLabel4.TabIndex = 12;
            aboutProjectNameLabel4.Text = "is Master_TW_DAR's initiative for M2TW community";
            aboutProjectNameLabel4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // aboutProjectNameLabel3
            // 
            aboutProjectNameLabel3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            aboutProjectNameLabel3.ForeColor = Color.Honeydew;
            aboutProjectNameLabel3.Location = new Point(12, 153);
            aboutProjectNameLabel3.Name = "aboutProjectNameLabel3";
            aboutProjectNameLabel3.Size = new Size(486, 45);
            aboutProjectNameLabel3.TabIndex = 13;
            aboutProjectNameLabel3.Text = "Version BETA 2024";
            aboutProjectNameLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AboutProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(510, 248);
            Controls.Add(aboutProjectNameLabel3);
            Controls.Add(aboutProjectNameLabel4);
            Controls.Add(aboutProjectNameLabel2);
            Controls.Add(aboutProjectNameLabel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutProjectForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About Program";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label aboutProjectNameLabel1;
		private System.Windows.Forms.Label aboutProjectNameLabel2;
		private System.Windows.Forms.Label aboutProjectNameLabel4;
		private System.Windows.Forms.Label aboutProjectNameLabel3;
	}
}