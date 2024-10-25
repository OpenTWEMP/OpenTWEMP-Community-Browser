// <copyright file="TwempExtensionStartupForm.Designer.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.App.Utilities_GUI.M2TW_Addons_Setup
{
    partial class TwempExtensionStartupForm
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
            startupButton = new Button();
            SuspendLayout();
            // 
            // startupButton
            // 
            startupButton.Location = new Point(12, 12);
            startupButton.Name = "startupButton";
            startupButton.Size = new Size(225, 126);
            startupButton.TabIndex = 0;
            startupButton.Text = "LAUNCH";
            startupButton.UseVisualStyleBackColor = true;
            startupButton.Click += StartupButton_Click;
            // 
            // TwempExtensionStartupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(249, 150);
            Controls.Add(startupButton);
            Name = "TwempExtensionStartupForm";
            Text = "M2TW Addons Setup";
            ResumeLayout(false);
        }

        #endregion

        private Button startupButton;
    }
}
