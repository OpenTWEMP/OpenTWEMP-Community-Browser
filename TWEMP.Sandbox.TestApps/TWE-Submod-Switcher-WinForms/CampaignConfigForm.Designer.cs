namespace TWE_Submod_Switcher_WinForms
{
    partial class CampaignConfigForm
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
            campaignDescriptionLabel = new Label();
            formApplyButton = new Button();
            formCloseButton = new Button();
            submodDescriptionGroupBox = new GroupBox();
            submodDescriptionLabel = new Label();
            submodSelectorGroupBox = new GroupBox();
            groupBox2 = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton6 = new RadioButton();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            submodDescriptionGroupBox.SuspendLayout();
            submodSelectorGroupBox.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // campaignDescriptionLabel
            // 
            campaignDescriptionLabel.BackColor = SystemColors.GradientInactiveCaption;
            campaignDescriptionLabel.BorderStyle = BorderStyle.FixedSingle;
            campaignDescriptionLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            campaignDescriptionLabel.Location = new Point(12, 9);
            campaignDescriptionLabel.Name = "campaignDescriptionLabel";
            campaignDescriptionLabel.Size = new Size(776, 53);
            campaignDescriptionLabel.TabIndex = 0;
            campaignDescriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // formApplyButton
            // 
            formApplyButton.Location = new Point(298, 415);
            formApplyButton.Name = "formApplyButton";
            formApplyButton.Size = new Size(409, 23);
            formApplyButton.TabIndex = 1;
            formApplyButton.Text = "APPLY CHANGES";
            formApplyButton.UseVisualStyleBackColor = true;
            formApplyButton.Click += formApplyButton_Click;
            // 
            // formCloseButton
            // 
            formCloseButton.Location = new Point(713, 415);
            formCloseButton.Name = "formCloseButton";
            formCloseButton.Size = new Size(75, 23);
            formCloseButton.TabIndex = 2;
            formCloseButton.Text = "EXIT";
            formCloseButton.UseVisualStyleBackColor = true;
            formCloseButton.Click += formCloseButton_Click;
            // 
            // submodDescriptionGroupBox
            // 
            submodDescriptionGroupBox.Controls.Add(submodDescriptionLabel);
            submodDescriptionGroupBox.Location = new Point(298, 65);
            submodDescriptionGroupBox.Name = "submodDescriptionGroupBox";
            submodDescriptionGroupBox.Size = new Size(490, 344);
            submodDescriptionGroupBox.TabIndex = 3;
            submodDescriptionGroupBox.TabStop = false;
            submodDescriptionGroupBox.Text = "DESCRIPTION";
            // 
            // submodDescriptionLabel
            // 
            submodDescriptionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            submodDescriptionLabel.Location = new Point(6, 19);
            submodDescriptionLabel.Name = "submodDescriptionLabel";
            submodDescriptionLabel.Size = new Size(478, 322);
            submodDescriptionLabel.TabIndex = 0;
            submodDescriptionLabel.Text = "SUBMOD_DESCRIPTION";
            submodDescriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // submodSelectorGroupBox
            // 
            submodSelectorGroupBox.Controls.Add(groupBox2);
            submodSelectorGroupBox.Controls.Add(groupBox1);
            submodSelectorGroupBox.Controls.Add(checkBox5);
            submodSelectorGroupBox.Controls.Add(checkBox4);
            submodSelectorGroupBox.Controls.Add(checkBox3);
            submodSelectorGroupBox.Controls.Add(checkBox2);
            submodSelectorGroupBox.Controls.Add(checkBox1);
            submodSelectorGroupBox.Location = new Point(12, 65);
            submodSelectorGroupBox.Name = "submodSelectorGroupBox";
            submodSelectorGroupBox.Size = new Size(280, 373);
            submodSelectorGroupBox.TabIndex = 4;
            submodSelectorGroupBox.TabStop = false;
            submodSelectorGroupBox.Text = "SUBMODS";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton4);
            groupBox2.Controls.Add(radioButton5);
            groupBox2.Controls.Add(radioButton6);
            groupBox2.Location = new Point(6, 253);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(134, 100);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(14, 73);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(94, 19);
            radioButton4.TabIndex = 2;
            radioButton4.TabStop = true;
            radioButton4.Text = "radioButton4";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(14, 48);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(94, 19);
            radioButton5.TabIndex = 1;
            radioButton5.TabStop = true;
            radioButton5.Text = "radioButton5";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(14, 23);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(94, 19);
            radioButton6.TabIndex = 0;
            radioButton6.TabStop = true;
            radioButton6.Text = "radioButton6";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(6, 147);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(134, 100);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(14, 73);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(94, 19);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "radioButton3";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(14, 48);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(94, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(14, 23);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(94, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(6, 122);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(83, 19);
            checkBox5.TabIndex = 4;
            checkBox5.Text = "checkBox5";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(6, 97);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(83, 19);
            checkBox4.TabIndex = 3;
            checkBox4.Text = "checkBox4";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(6, 72);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(83, 19);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(6, 47);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(83, 19);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // CampaignConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(submodSelectorGroupBox);
            Controls.Add(submodDescriptionGroupBox);
            Controls.Add(formCloseButton);
            Controls.Add(formApplyButton);
            Controls.Add(campaignDescriptionLabel);
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "CampaignConfigForm";
            Text = "CampaignConfigForm";
            submodDescriptionGroupBox.ResumeLayout(false);
            submodSelectorGroupBox.ResumeLayout(false);
            submodSelectorGroupBox.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label campaignDescriptionLabel;
        private Button formApplyButton;
        private Button formCloseButton;
        private GroupBox submodDescriptionGroupBox;
        private Label submodDescriptionLabel;
        private GroupBox submodSelectorGroupBox;
        private GroupBox groupBox2;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
    }
}