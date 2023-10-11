﻿using TWEMP.Browser.App.Classic.WinForms.Properties;

namespace TWEMP.Browser.App.Classic
{
    partial class MainBrowserForm
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
            this.components = new System.ComponentModel.Container();

            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("My Favorite Mods");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("My Mod Collections");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("All Modifications");
            buttonLaunch = new System.Windows.Forms.Button();
            panelLauncherOptions = new System.Windows.Forms.Panel();
            groupBoxConfigProfiles = new System.Windows.Forms.GroupBox();
            radioButtonConfigProfile_Modding = new System.Windows.Forms.RadioButton();
            radioButtonConfigProfile_Gaming = new System.Windows.Forms.RadioButton();
            groupBoxLauncherProviders = new System.Windows.Forms.GroupBox();
            radioButtonLauncherProvider_TWEMP = new System.Windows.Forms.RadioButton();
            radioButtonLauncherProvider_BatchScript = new System.Windows.Forms.RadioButton();
            radioButtonLauncherProvider_NativeSetup = new System.Windows.Forms.RadioButton();
            radioButtonLauncherProvider_M2TWEOP = new System.Windows.Forms.RadioButton();
            groupBoxConfigCleanerMode = new System.Windows.Forms.GroupBox();
            checkBoxCleaner_soundPacks = new System.Windows.Forms.CheckBox();
            checkBoxCleaner_textBIN = new System.Windows.Forms.CheckBox();
            checkBoxCleaner_MapRWM = new System.Windows.Forms.CheckBox();
            groupBoxConfigLogMode = new System.Windows.Forms.GroupBox();
            checkBoxLogHistory = new System.Windows.Forms.CheckBox();
            radioButtonLogErrorAndTrace = new System.Windows.Forms.RadioButton();
            radioButtonLogOnlyTrace = new System.Windows.Forms.RadioButton();
            radioButtonLogOnlyError = new System.Windows.Forms.RadioButton();
            groupBoxConfigLaunchMode = new System.Windows.Forms.GroupBox();
            checkBoxBorderless = new System.Windows.Forms.CheckBox();
            checkBoxVideo = new System.Windows.Forms.CheckBox();
            radioButtonLaunchFullScreen = new System.Windows.Forms.RadioButton();
            radioButtonLaunchWindowScreen = new System.Windows.Forms.RadioButton();
            buttonExplore = new System.Windows.Forms.Button();
            modQuickNavigationButton = new System.Windows.Forms.Button();
            panelLauncherToolkit = new System.Windows.Forms.Panel();
            modMainTitleLabel = new System.Windows.Forms.Label();
            modLogoPictureBox = new System.Windows.Forms.PictureBox();
            modStatusLabel = new System.Windows.Forms.Label();
            appStatusStrip = new System.Windows.Forms.StatusStrip();
            appMenuStrip = new System.Windows.Forms.MenuStrip();
            toolStripAppItem = new System.Windows.Forms.ToolStripMenuItem();
            gameSetupSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            applicationSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            applicationHomeFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitFromApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripHelpItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripModItem = new System.Windows.Forms.ToolStripMenuItem();
            configSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            treeViewGameMods = new System.Windows.Forms.TreeView();
            buttonMarkFavoriteMod = new System.Windows.Forms.Button();
            buttonCollectionCreate = new System.Windows.Forms.Button();
            buttonCollectionManage = new System.Windows.Forms.Button();
            panelCollections = new System.Windows.Forms.Panel();
            panelLauncherOptions.SuspendLayout();
            groupBoxConfigProfiles.SuspendLayout();
            groupBoxLauncherProviders.SuspendLayout();
            groupBoxConfigCleanerMode.SuspendLayout();
            groupBoxConfigLogMode.SuspendLayout();
            groupBoxConfigLaunchMode.SuspendLayout();
            panelLauncherToolkit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)modLogoPictureBox).BeginInit();
            appMenuStrip.SuspendLayout();
            panelCollections.SuspendLayout();
            SuspendLayout();
            // 
            // buttonLaunch
            // 
            buttonLaunch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonLaunch.BackColor = System.Drawing.Color.LightGreen;
            buttonLaunch.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonLaunch.Enabled = false;
            buttonLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonLaunch.ForeColor = System.Drawing.SystemColors.ControlText;
            buttonLaunch.Location = new System.Drawing.Point(4, 3);
            buttonLaunch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonLaunch.Name = "buttonLaunch";
            buttonLaunch.Size = new System.Drawing.Size(362, 88);
            buttonLaunch.TabIndex = 0;
            buttonLaunch.Text = "LAUNCH";
            buttonLaunch.UseVisualStyleBackColor = false;
            buttonLaunch.Click += ButtonLaunch_Click;
            // 
            // panelLauncherOptions
            // 
            panelLauncherOptions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            panelLauncherOptions.AutoScroll = true;
            panelLauncherOptions.BackColor = System.Drawing.Color.MediumAquamarine;
            panelLauncherOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelLauncherOptions.Controls.Add(groupBoxConfigProfiles);
            panelLauncherOptions.Controls.Add(groupBoxLauncherProviders);
            panelLauncherOptions.Controls.Add(groupBoxConfigCleanerMode);
            panelLauncherOptions.Controls.Add(groupBoxConfigLogMode);
            panelLauncherOptions.Controls.Add(groupBoxConfigLaunchMode);
            panelLauncherOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            panelLauncherOptions.Location = new System.Drawing.Point(719, 84);
            panelLauncherOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLauncherOptions.Name = "panelLauncherOptions";
            panelLauncherOptions.Size = new System.Drawing.Size(276, 567);
            panelLauncherOptions.TabIndex = 2;
            // 
            // groupBoxConfigProfiles
            // 
            groupBoxConfigProfiles.BackColor = System.Drawing.Color.Transparent;
            groupBoxConfigProfiles.Controls.Add(radioButtonConfigProfile_Modding);
            groupBoxConfigProfiles.Controls.Add(radioButtonConfigProfile_Gaming);
            groupBoxConfigProfiles.Location = new System.Drawing.Point(3, 3);
            groupBoxConfigProfiles.Name = "groupBoxConfigProfiles";
            groupBoxConfigProfiles.Size = new System.Drawing.Size(267, 53);
            groupBoxConfigProfiles.TabIndex = 7;
            groupBoxConfigProfiles.TabStop = false;
            groupBoxConfigProfiles.Text = "Configuration Profiles";
            // 
            // radioButtonConfigProfile_Modding
            // 
            radioButtonConfigProfile_Modding.AutoSize = true;
            radioButtonConfigProfile_Modding.BackColor = System.Drawing.Color.Transparent;
            radioButtonConfigProfile_Modding.Checked = true;
            radioButtonConfigProfile_Modding.Location = new System.Drawing.Point(119, 22);
            radioButtonConfigProfile_Modding.Name = "radioButtonConfigProfile_Modding";
            radioButtonConfigProfile_Modding.Size = new System.Drawing.Size(118, 19);
            radioButtonConfigProfile_Modding.TabIndex = 1;
            radioButtonConfigProfile_Modding.TabStop = true;
            radioButtonConfigProfile_Modding.Text = "MODDING MODE";
            radioButtonConfigProfile_Modding.UseVisualStyleBackColor = false;
            radioButtonConfigProfile_Modding.CheckedChanged += RadioButtonConfigProfile_Modding_CheckedChanged;
            // 
            // radioButtonConfigProfile_Gaming
            // 
            radioButtonConfigProfile_Gaming.AutoSize = true;
            radioButtonConfigProfile_Gaming.BackColor = System.Drawing.Color.Transparent;
            radioButtonConfigProfile_Gaming.Location = new System.Drawing.Point(6, 22);
            radioButtonConfigProfile_Gaming.Name = "radioButtonConfigProfile_Gaming";
            radioButtonConfigProfile_Gaming.Size = new System.Drawing.Size(109, 19);
            radioButtonConfigProfile_Gaming.TabIndex = 0;
            radioButtonConfigProfile_Gaming.Text = "GAMING MODE";
            radioButtonConfigProfile_Gaming.UseVisualStyleBackColor = false;
            radioButtonConfigProfile_Gaming.CheckedChanged += RadioButtonConfigProfile_Gaming_CheckedChanged;
            // 
            // groupBoxLauncherProviders
            // 
            groupBoxLauncherProviders.Controls.Add(radioButtonLauncherProvider_TWEMP);
            groupBoxLauncherProviders.Controls.Add(radioButtonLauncherProvider_BatchScript);
            groupBoxLauncherProviders.Controls.Add(radioButtonLauncherProvider_NativeSetup);
            groupBoxLauncherProviders.Controls.Add(radioButtonLauncherProvider_M2TWEOP);
            groupBoxLauncherProviders.Location = new System.Drawing.Point(3, 431);
            groupBoxLauncherProviders.Name = "groupBoxLauncherProviders";
            groupBoxLauncherProviders.Size = new System.Drawing.Size(267, 131);
            groupBoxLauncherProviders.TabIndex = 6;
            groupBoxLauncherProviders.TabStop = false;
            groupBoxLauncherProviders.Text = "Launcher Providers";
            // 
            // radioButtonLauncherProvider_TWEMP
            // 
            radioButtonLauncherProvider_TWEMP.AutoSize = true;
            radioButtonLauncherProvider_TWEMP.Checked = true;
            radioButtonLauncherProvider_TWEMP.Location = new System.Drawing.Point(12, 20);
            radioButtonLauncherProvider_TWEMP.Name = "radioButtonLauncherProvider_TWEMP";
            radioButtonLauncherProvider_TWEMP.Size = new System.Drawing.Size(212, 19);
            radioButtonLauncherProvider_TWEMP.TabIndex = 3;
            radioButtonLauncherProvider_TWEMP.TabStop = true;
            radioButtonLauncherProvider_TWEMP.Text = "Launch Game via TWEMP Launcher";
            radioButtonLauncherProvider_TWEMP.UseVisualStyleBackColor = true;
            radioButtonLauncherProvider_TWEMP.CheckedChanged += RadioButtonLauncherProvider_TWEMP_CheckedChanged;
            // 
            // radioButtonLauncherProvider_BatchScript
            // 
            radioButtonLauncherProvider_BatchScript.AutoSize = true;
            radioButtonLauncherProvider_BatchScript.Location = new System.Drawing.Point(12, 47);
            radioButtonLauncherProvider_BatchScript.Name = "radioButtonLauncherProvider_BatchScript";
            radioButtonLauncherProvider_BatchScript.Size = new System.Drawing.Size(182, 19);
            radioButtonLauncherProvider_BatchScript.TabIndex = 2;
            radioButtonLauncherProvider_BatchScript.Text = "Launch Game via Batch Script";
            radioButtonLauncherProvider_BatchScript.UseVisualStyleBackColor = true;
            radioButtonLauncherProvider_BatchScript.CheckedChanged += RadioButtonLauncherProvider_BatchScript_CheckedChanged;
            // 
            // radioButtonLauncherProvider_NativeSetup
            // 
            radioButtonLauncherProvider_NativeSetup.AutoSize = true;
            radioButtonLauncherProvider_NativeSetup.Location = new System.Drawing.Point(12, 72);
            radioButtonLauncherProvider_NativeSetup.Name = "radioButtonLauncherProvider_NativeSetup";
            radioButtonLauncherProvider_NativeSetup.Size = new System.Drawing.Size(186, 19);
            radioButtonLauncherProvider_NativeSetup.TabIndex = 1;
            radioButtonLauncherProvider_NativeSetup.Text = "Launch Game via Native Setup";
            radioButtonLauncherProvider_NativeSetup.UseVisualStyleBackColor = true;
            radioButtonLauncherProvider_NativeSetup.CheckedChanged += RadioButtonLauncherProvider_NativeSetup_CheckedChanged;
            // 
            // radioButtonLauncherProvider_M2TWEOP
            // 
            radioButtonLauncherProvider_M2TWEOP.AutoSize = true;
            radioButtonLauncherProvider_M2TWEOP.Location = new System.Drawing.Point(12, 97);
            radioButtonLauncherProvider_M2TWEOP.Name = "radioButtonLauncherProvider_M2TWEOP";
            radioButtonLauncherProvider_M2TWEOP.Size = new System.Drawing.Size(197, 19);
            radioButtonLauncherProvider_M2TWEOP.TabIndex = 0;
            radioButtonLauncherProvider_M2TWEOP.Text = "Launch Game via M2TWEOP GUI";
            radioButtonLauncherProvider_M2TWEOP.UseVisualStyleBackColor = true;
            radioButtonLauncherProvider_M2TWEOP.CheckedChanged += RadioButtonLauncherProvider_M2TWEOP_CheckedChanged;
            // 
            // groupBoxConfigCleanerMode
            // 
            groupBoxConfigCleanerMode.BackColor = System.Drawing.Color.Transparent;
            groupBoxConfigCleanerMode.Controls.Add(checkBoxCleaner_soundPacks);
            groupBoxConfigCleanerMode.Controls.Add(checkBoxCleaner_textBIN);
            groupBoxConfigCleanerMode.Controls.Add(checkBoxCleaner_MapRWM);
            groupBoxConfigCleanerMode.Location = new System.Drawing.Point(4, 322);
            groupBoxConfigCleanerMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxConfigCleanerMode.Name = "groupBoxConfigCleanerMode";
            groupBoxConfigCleanerMode.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxConfigCleanerMode.Size = new System.Drawing.Size(266, 103);
            groupBoxConfigCleanerMode.TabIndex = 5;
            groupBoxConfigCleanerMode.TabStop = false;
            groupBoxConfigCleanerMode.Text = "Select mod clean routines";
            // 
            // checkBoxCleaner_soundPacks
            // 
            checkBoxCleaner_soundPacks.AutoSize = true;
            checkBoxCleaner_soundPacks.Location = new System.Drawing.Point(10, 75);
            checkBoxCleaner_soundPacks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxCleaner_soundPacks.Name = "checkBoxCleaner_soundPacks";
            checkBoxCleaner_soundPacks.Size = new System.Drawing.Size(227, 19);
            checkBoxCleaner_soundPacks.TabIndex = 2;
            checkBoxCleaner_soundPacks.Text = "Delete sound pack files (*.DAT + *.IDX)";
            checkBoxCleaner_soundPacks.UseVisualStyleBackColor = true;
            // 
            // checkBoxCleaner_textBIN
            // 
            checkBoxCleaner_textBIN.AutoSize = true;
            checkBoxCleaner_textBIN.Location = new System.Drawing.Point(10, 48);
            checkBoxCleaner_textBIN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxCleaner_textBIN.Name = "checkBoxCleaner_textBIN";
            checkBoxCleaner_textBIN.Size = new System.Drawing.Size(209, 19);
            checkBoxCleaner_textBIN.TabIndex = 1;
            checkBoxCleaner_textBIN.Text = "Delete localization *strings.bin files";
            checkBoxCleaner_textBIN.UseVisualStyleBackColor = true;
            // 
            // checkBoxCleaner_MapRWM
            // 
            checkBoxCleaner_MapRWM.AutoSize = true;
            checkBoxCleaner_MapRWM.Location = new System.Drawing.Point(10, 22);
            checkBoxCleaner_MapRWM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxCleaner_MapRWM.Name = "checkBoxCleaner_MapRWM";
            checkBoxCleaner_MapRWM.Size = new System.Drawing.Size(132, 19);
            checkBoxCleaner_MapRWM.TabIndex = 0;
            checkBoxCleaner_MapRWM.Text = "Delete map.rwm file";
            checkBoxCleaner_MapRWM.UseVisualStyleBackColor = true;
            // 
            // groupBoxConfigLogMode
            // 
            groupBoxConfigLogMode.BackColor = System.Drawing.Color.Transparent;
            groupBoxConfigLogMode.Controls.Add(checkBoxLogHistory);
            groupBoxConfigLogMode.Controls.Add(radioButtonLogErrorAndTrace);
            groupBoxConfigLogMode.Controls.Add(radioButtonLogOnlyTrace);
            groupBoxConfigLogMode.Controls.Add(radioButtonLogOnlyError);
            groupBoxConfigLogMode.Location = new System.Drawing.Point(4, 190);
            groupBoxConfigLogMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxConfigLogMode.Name = "groupBoxConfigLogMode";
            groupBoxConfigLogMode.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxConfigLogMode.Size = new System.Drawing.Size(266, 126);
            groupBoxConfigLogMode.TabIndex = 1;
            groupBoxConfigLogMode.TabStop = false;
            groupBoxConfigLogMode.Text = "Select a mode of creating system.log file";
            // 
            // checkBoxLogHistory
            // 
            checkBoxLogHistory.AutoSize = true;
            checkBoxLogHistory.Checked = true;
            checkBoxLogHistory.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxLogHistory.Location = new System.Drawing.Point(11, 97);
            checkBoxLogHistory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxLogHistory.Name = "checkBoxLogHistory";
            checkBoxLogHistory.Size = new System.Drawing.Size(167, 19);
            checkBoxLogHistory.TabIndex = 3;
            checkBoxLogHistory.Text = "Save game system.log files";
            checkBoxLogHistory.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogErrorAndTrace
            // 
            radioButtonLogErrorAndTrace.AutoSize = true;
            radioButtonLogErrorAndTrace.Checked = true;
            radioButtonLogErrorAndTrace.Location = new System.Drawing.Point(10, 72);
            radioButtonLogErrorAndTrace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButtonLogErrorAndTrace.Name = "radioButtonLogErrorAndTrace";
            radioButtonLogErrorAndTrace.Size = new System.Drawing.Size(96, 19);
            radioButtonLogErrorAndTrace.TabIndex = 2;
            radioButtonLogErrorAndTrace.TabStop = true;
            radioButtonLogErrorAndTrace.Text = "Errors + Trace";
            radioButtonLogErrorAndTrace.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogOnlyTrace
            // 
            radioButtonLogOnlyTrace.AutoSize = true;
            radioButtonLogOnlyTrace.Location = new System.Drawing.Point(10, 47);
            radioButtonLogOnlyTrace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButtonLogOnlyTrace.Name = "radioButtonLogOnlyTrace";
            radioButtonLogOnlyTrace.Size = new System.Drawing.Size(80, 19);
            radioButtonLogOnlyTrace.TabIndex = 1;
            radioButtonLogOnlyTrace.Text = "Only Trace";
            radioButtonLogOnlyTrace.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogOnlyError
            // 
            radioButtonLogOnlyError.AutoSize = true;
            radioButtonLogOnlyError.Location = new System.Drawing.Point(10, 22);
            radioButtonLogOnlyError.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButtonLogOnlyError.Name = "radioButtonLogOnlyError";
            radioButtonLogOnlyError.Size = new System.Drawing.Size(83, 19);
            radioButtonLogOnlyError.TabIndex = 0;
            radioButtonLogOnlyError.Text = "Only Errors";
            radioButtonLogOnlyError.UseVisualStyleBackColor = true;
            // 
            // groupBoxConfigLaunchMode
            // 
            groupBoxConfigLaunchMode.BackColor = System.Drawing.Color.Transparent;
            groupBoxConfigLaunchMode.Controls.Add(checkBoxBorderless);
            groupBoxConfigLaunchMode.Controls.Add(checkBoxVideo);
            groupBoxConfigLaunchMode.Controls.Add(radioButtonLaunchFullScreen);
            groupBoxConfigLaunchMode.Controls.Add(radioButtonLaunchWindowScreen);
            groupBoxConfigLaunchMode.Location = new System.Drawing.Point(3, 62);
            groupBoxConfigLaunchMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxConfigLaunchMode.Name = "groupBoxConfigLaunchMode";
            groupBoxConfigLaunchMode.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxConfigLaunchMode.Size = new System.Drawing.Size(266, 122);
            groupBoxConfigLaunchMode.TabIndex = 0;
            groupBoxConfigLaunchMode.TabStop = false;
            groupBoxConfigLaunchMode.Text = "Select game launch mode";
            // 
            // checkBoxBorderless
            // 
            checkBoxBorderless.AutoSize = true;
            checkBoxBorderless.Location = new System.Drawing.Point(8, 97);
            checkBoxBorderless.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxBorderless.Name = "checkBoxBorderless";
            checkBoxBorderless.Size = new System.Drawing.Size(174, 19);
            checkBoxBorderless.TabIndex = 2;
            checkBoxBorderless.Text = "Borderless Windowed Mode";
            checkBoxBorderless.UseVisualStyleBackColor = true;
            // 
            // checkBoxVideo
            // 
            checkBoxVideo.AutoSize = true;
            checkBoxVideo.Location = new System.Drawing.Point(8, 72);
            checkBoxVideo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxVideo.Name = "checkBoxVideo";
            checkBoxVideo.Size = new System.Drawing.Size(128, 19);
            checkBoxVideo.TabIndex = 0;
            checkBoxVideo.Text = "Enable Game Video";
            checkBoxVideo.UseVisualStyleBackColor = true;
            // 
            // radioButtonLaunchFullScreen
            // 
            radioButtonLaunchFullScreen.AutoSize = true;
            radioButtonLaunchFullScreen.Location = new System.Drawing.Point(8, 47);
            radioButtonLaunchFullScreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButtonLaunchFullScreen.Name = "radioButtonLaunchFullScreen";
            radioButtonLaunchFullScreen.Size = new System.Drawing.Size(118, 19);
            radioButtonLaunchFullScreen.TabIndex = 1;
            radioButtonLaunchFullScreen.Text = "Full-Screen Mode";
            radioButtonLaunchFullScreen.UseVisualStyleBackColor = true;
            // 
            // radioButtonLaunchWindowScreen
            // 
            radioButtonLaunchWindowScreen.AutoSize = true;
            radioButtonLaunchWindowScreen.Checked = true;
            radioButtonLaunchWindowScreen.Location = new System.Drawing.Point(8, 22);
            radioButtonLaunchWindowScreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButtonLaunchWindowScreen.Name = "radioButtonLaunchWindowScreen";
            radioButtonLaunchWindowScreen.Size = new System.Drawing.Size(116, 19);
            radioButtonLaunchWindowScreen.TabIndex = 0;
            radioButtonLaunchWindowScreen.TabStop = true;
            radioButtonLaunchWindowScreen.Text = "Windowed Mode";
            radioButtonLaunchWindowScreen.UseVisualStyleBackColor = true;
            // 
            // buttonExplore
            // 
            buttonExplore.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonExplore.BackColor = System.Drawing.Color.LightGreen;
            buttonExplore.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonExplore.Enabled = false;
            buttonExplore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonExplore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonExplore.Location = new System.Drawing.Point(4, 151);
            buttonExplore.Name = "buttonExplore";
            buttonExplore.Size = new System.Drawing.Size(362, 52);
            buttonExplore.TabIndex = 8;
            buttonExplore.Text = "MOD HOME FOLDER";
            buttonExplore.UseVisualStyleBackColor = false;
            buttonExplore.Click += ButtonExplore_Click;
            // 
            // modQuickNavigationButton
            // 
            modQuickNavigationButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            modQuickNavigationButton.BackColor = System.Drawing.Color.LightGreen;
            modQuickNavigationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            modQuickNavigationButton.Enabled = false;
            modQuickNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            modQuickNavigationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            modQuickNavigationButton.Location = new System.Drawing.Point(4, 97);
            modQuickNavigationButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            modQuickNavigationButton.Name = "modQuickNavigationButton";
            modQuickNavigationButton.Size = new System.Drawing.Size(362, 48);
            modQuickNavigationButton.TabIndex = 7;
            modQuickNavigationButton.Text = "MOD QUICK NAVIGATION";
            modQuickNavigationButton.UseVisualStyleBackColor = false;
            modQuickNavigationButton.Click += ModQuickNavigationButton_Click;
            // 
            // panelLauncherToolkit
            // 
            panelLauncherToolkit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelLauncherToolkit.BackColor = System.Drawing.Color.MediumAquamarine;
            panelLauncherToolkit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelLauncherToolkit.Controls.Add(modQuickNavigationButton);
            panelLauncherToolkit.Controls.Add(buttonExplore);
            panelLauncherToolkit.Controls.Add(buttonLaunch);
            panelLauncherToolkit.Location = new System.Drawing.Point(340, 443);
            panelLauncherToolkit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLauncherToolkit.Name = "panelLauncherToolkit";
            panelLauncherToolkit.Size = new System.Drawing.Size(372, 208);
            panelLauncherToolkit.TabIndex = 6;
            // 
            // modMainTitleLabel
            // 
            modMainTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            modMainTitleLabel.BackColor = System.Drawing.Color.MediumSeaGreen;
            modMainTitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            modMainTitleLabel.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            modMainTitleLabel.Location = new System.Drawing.Point(12, 35);
            modMainTitleLabel.Name = "modMainTitleLabel";
            modMainTitleLabel.Size = new System.Drawing.Size(983, 46);
            modMainTitleLabel.TabIndex = 8;
            modMainTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // modLogoPictureBox
            // 
            modLogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            modLogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            modLogoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            modLogoPictureBox.Image = Resources.OPENTWEMP_LOGO;
            modLogoPictureBox.Location = new System.Drawing.Point(340, 84);
            modLogoPictureBox.Name = "modLogoPictureBox";
            modLogoPictureBox.Size = new System.Drawing.Size(372, 353);
            modLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            modLogoPictureBox.TabIndex = 9;
            modLogoPictureBox.TabStop = false;
            // 
            // modStatusLabel
            // 
            modStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            modStatusLabel.BackColor = System.Drawing.Color.MediumSeaGreen;
            modStatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            modStatusLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            modStatusLabel.ForeColor = System.Drawing.Color.Black;
            modStatusLabel.Location = new System.Drawing.Point(12, 654);
            modStatusLabel.Name = "modStatusLabel";
            modStatusLabel.Size = new System.Drawing.Size(983, 42);
            modStatusLabel.TabIndex = 12;
            modStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // appStatusStrip
            // 
            appStatusStrip.Location = new System.Drawing.Point(0, 707);
            appStatusStrip.Name = "appStatusStrip";
            appStatusStrip.Size = new System.Drawing.Size(1008, 22);
            appStatusStrip.TabIndex = 13;
            appStatusStrip.Text = "statusStrip1";
            // 
            // appMenuStrip
            // 
            appMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripAppItem, toolStripHelpItem, toolStripModItem });
            appMenuStrip.Location = new System.Drawing.Point(0, 0);
            appMenuStrip.Name = "appMenuStrip";
            appMenuStrip.Size = new System.Drawing.Size(1008, 24);
            appMenuStrip.TabIndex = 15;
            appMenuStrip.Text = "menuStrip1";
            // 
            // toolStripAppItem
            // 
            toolStripAppItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { gameSetupSettingsToolStripMenuItem, toolStripSeparator1, applicationSettingsToolStripMenuItem, toolStripSeparator2, applicationHomeFolderToolStripMenuItem, exitFromApplicationToolStripMenuItem });
            toolStripAppItem.Name = "toolStripAppItem";
            toolStripAppItem.Size = new System.Drawing.Size(72, 20);
            toolStripAppItem.Text = "BROWSER";
            // 
            // gameSetupSettingsToolStripMenuItem
            // 
            gameSetupSettingsToolStripMenuItem.Name = "gameSetupSettingsToolStripMenuItem";
            gameSetupSettingsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            gameSetupSettingsToolStripMenuItem.Text = "Game Setup Settings";
            gameSetupSettingsToolStripMenuItem.Click += GameSetupSettingsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // applicationSettingsToolStripMenuItem
            // 
            applicationSettingsToolStripMenuItem.Name = "applicationSettingsToolStripMenuItem";
            applicationSettingsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            applicationSettingsToolStripMenuItem.Text = "Application Settings";
            applicationSettingsToolStripMenuItem.Click += ApplicationSettingsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // applicationHomeFolderToolStripMenuItem
            // 
            applicationHomeFolderToolStripMenuItem.Name = "applicationHomeFolderToolStripMenuItem";
            applicationHomeFolderToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            applicationHomeFolderToolStripMenuItem.Text = "Go to Home Folder";
            applicationHomeFolderToolStripMenuItem.Click += ApplicationHomeFolderToolStripMenuItem_Click;
            // 
            // exitFromApplicationToolStripMenuItem
            // 
            exitFromApplicationToolStripMenuItem.Name = "exitFromApplicationToolStripMenuItem";
            exitFromApplicationToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            exitFromApplicationToolStripMenuItem.Text = "Exit from Program";
            exitFromApplicationToolStripMenuItem.Click += ExitFromApplicationToolStripMenuItem_Click;
            // 
            // toolStripHelpItem
            // 
            toolStripHelpItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aboutProgramToolStripMenuItem });
            toolStripHelpItem.Name = "toolStripHelpItem";
            toolStripHelpItem.Size = new System.Drawing.Size(47, 20);
            toolStripHelpItem.Text = "HELP";
            // 
            // aboutProgramToolStripMenuItem
            // 
            aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            aboutProgramToolStripMenuItem.Text = "About Program";
            aboutProgramToolStripMenuItem.Click += AboutProgramToolStripMenuItem_Click;
            // 
            // toolStripModItem
            // 
            toolStripModItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { configSettingsToolStripMenuItem });
            toolStripModItem.Name = "toolStripModItem";
            toolStripModItem.Size = new System.Drawing.Size(101, 20);
            toolStripModItem.Text = "MODIFICATION";
            // 
            // configSettingsToolStripMenuItem
            // 
            configSettingsToolStripMenuItem.Name = "configSettingsToolStripMenuItem";
            configSettingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            configSettingsToolStripMenuItem.Text = "Configuration Settings";
            configSettingsToolStripMenuItem.Click += ConfigSettingsToolStripMenuItem_Click;
            // 
            // treeViewGameMods
            // 
            treeViewGameMods.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            treeViewGameMods.BackColor = System.Drawing.Color.MediumSeaGreen;
            treeViewGameMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            treeViewGameMods.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            treeViewGameMods.FullRowSelect = true;
            treeViewGameMods.Indent = 15;
            treeViewGameMods.ItemHeight = 30;
            treeViewGameMods.Location = new System.Drawing.Point(13, 84);
            treeViewGameMods.Name = "treeViewGameMods";
            treeNode1.Name = "Node0";
            treeNode1.Text = "My Favorite Mods";
            treeNode2.Name = "Node1";
            treeNode2.Text = "My Mod Collections";
            treeNode3.Name = "Node2";
            treeNode3.Text = "All Modifications";
            treeViewGameMods.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2, treeNode3 });
            treeViewGameMods.Size = new System.Drawing.Size(320, 451);
            treeViewGameMods.TabIndex = 16;
            treeViewGameMods.AfterSelect += TreeViewGameMods_AfterSelect;
            // 
            // buttonMarkFavoriteMod
            // 
            buttonMarkFavoriteMod.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonMarkFavoriteMod.BackColor = System.Drawing.Color.LightGreen;
            buttonMarkFavoriteMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonMarkFavoriteMod.Location = new System.Drawing.Point(3, 14);
            buttonMarkFavoriteMod.Name = "buttonMarkFavoriteMod";
            buttonMarkFavoriteMod.Size = new System.Drawing.Size(313, 23);
            buttonMarkFavoriteMod.TabIndex = 18;
            buttonMarkFavoriteMod.Text = "MARK or UNMARK THIS MOD as FAVORITE";
            buttonMarkFavoriteMod.UseVisualStyleBackColor = false;
            buttonMarkFavoriteMod.Click += ButtonMarkFavoriteMod_Click;
            // 
            // buttonCollectionCreate
            // 
            buttonCollectionCreate.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCollectionCreate.BackColor = System.Drawing.Color.LightGreen;
            buttonCollectionCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCollectionCreate.Location = new System.Drawing.Point(3, 43);
            buttonCollectionCreate.Name = "buttonCollectionCreate";
            buttonCollectionCreate.Size = new System.Drawing.Size(313, 23);
            buttonCollectionCreate.TabIndex = 19;
            buttonCollectionCreate.Text = "CREATE A NEW COLLECTION";
            buttonCollectionCreate.UseVisualStyleBackColor = false;
            buttonCollectionCreate.Click += ButtonCollectionCreate_Click;
            // 
            // buttonCollectionManage
            // 
            buttonCollectionManage.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonCollectionManage.BackColor = System.Drawing.Color.LightGreen;
            buttonCollectionManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCollectionManage.Location = new System.Drawing.Point(3, 72);
            buttonCollectionManage.Name = "buttonCollectionManage";
            buttonCollectionManage.Size = new System.Drawing.Size(313, 23);
            buttonCollectionManage.TabIndex = 20;
            buttonCollectionManage.Text = "MANAGE YOUR COLLECTIONS";
            buttonCollectionManage.UseVisualStyleBackColor = false;
            buttonCollectionManage.Click += ButtonCollectionManage_Click;
            // 
            // panelCollections
            // 
            panelCollections.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            panelCollections.BackColor = System.Drawing.Color.MediumAquamarine;
            panelCollections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelCollections.Controls.Add(buttonCollectionManage);
            panelCollections.Controls.Add(buttonCollectionCreate);
            panelCollections.Controls.Add(buttonMarkFavoriteMod);
            panelCollections.Location = new System.Drawing.Point(12, 541);
            panelCollections.Name = "panelCollections";
            panelCollections.Size = new System.Drawing.Size(321, 110);
            panelCollections.TabIndex = 21;
            // 
            // MainLauncherForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DarkSeaGreen;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            ClientSize = new System.Drawing.Size(1008, 729);
            Controls.Add(panelCollections);
            Controls.Add(treeViewGameMods);
            Controls.Add(modMainTitleLabel);
            Controls.Add(modStatusLabel);
            Controls.Add(modLogoPictureBox);
            Controls.Add(panelLauncherOptions);
            Controls.Add(appStatusStrip);
            Controls.Add(panelLauncherToolkit);
            Controls.Add(appMenuStrip);
            DoubleBuffered = true;
            MainMenuStrip = appMenuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(1024, 768);
            Name = "MainLauncherForm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            panelLauncherOptions.ResumeLayout(false);
            groupBoxConfigProfiles.ResumeLayout(false);
            groupBoxConfigProfiles.PerformLayout();
            groupBoxLauncherProviders.ResumeLayout(false);
            groupBoxLauncherProviders.PerformLayout();
            groupBoxConfigCleanerMode.ResumeLayout(false);
            groupBoxConfigCleanerMode.PerformLayout();
            groupBoxConfigLogMode.ResumeLayout(false);
            groupBoxConfigLogMode.PerformLayout();
            groupBoxConfigLaunchMode.ResumeLayout(false);
            groupBoxConfigLaunchMode.PerformLayout();
            panelLauncherToolkit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)modLogoPictureBox).EndInit();
            appMenuStrip.ResumeLayout(false);
            appMenuStrip.PerformLayout();
            panelCollections.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.Panel panelLauncherOptions;
        private System.Windows.Forms.CheckBox checkBoxVideo;
        private System.Windows.Forms.GroupBox groupBoxConfigLogMode;
        public System.Windows.Forms.RadioButton radioButtonLogErrorAndTrace;
        private System.Windows.Forms.RadioButton radioButtonLogOnlyTrace;
        private System.Windows.Forms.RadioButton radioButtonLogOnlyError;
        private System.Windows.Forms.GroupBox groupBoxConfigLaunchMode;
        private System.Windows.Forms.RadioButton radioButtonLaunchFullScreen;
        private System.Windows.Forms.RadioButton radioButtonLaunchWindowScreen;
        private System.Windows.Forms.Panel panelLauncherToolkit;
        private System.Windows.Forms.GroupBox groupBoxConfigCleanerMode;
        private System.Windows.Forms.CheckBox checkBoxCleaner_soundPacks;
        private System.Windows.Forms.CheckBox checkBoxCleaner_textBIN;
        private System.Windows.Forms.CheckBox checkBoxCleaner_MapRWM;
        private System.Windows.Forms.CheckBox checkBoxLogHistory;
        private System.Windows.Forms.CheckBox checkBoxBorderless;
        private System.Windows.Forms.Button modQuickNavigationButton;
        private System.Windows.Forms.Button buttonExplore;
        private System.Windows.Forms.Label modMainTitleLabel;
        private System.Windows.Forms.PictureBox modLogoPictureBox;
        private System.Windows.Forms.Label modStatusLabel;
        private System.Windows.Forms.StatusStrip appStatusStrip;
        private System.Windows.Forms.MenuStrip appMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripAppItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripModItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripHelpItem;
        private System.Windows.Forms.ToolStripMenuItem gameSetupSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitFromApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem applicationHomeFolderToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxLauncherProviders;
        private System.Windows.Forms.RadioButton radioButtonLauncherProvider_BatchScript;
        private System.Windows.Forms.RadioButton radioButtonLauncherProvider_NativeSetup;
        private System.Windows.Forms.RadioButton radioButtonLauncherProvider_M2TWEOP;
        private System.Windows.Forms.RadioButton radioButtonLauncherProvider_TWEMP;
        private System.Windows.Forms.GroupBox groupBoxConfigProfiles;
        private System.Windows.Forms.RadioButton radioButtonConfigProfile_Modding;
        private System.Windows.Forms.RadioButton radioButtonConfigProfile_Gaming;
        private System.Windows.Forms.TreeView treeViewGameMods;
        private System.Windows.Forms.Button buttonMarkFavoriteMod;
        private System.Windows.Forms.Button buttonCollectionCreate;
        private System.Windows.Forms.Button buttonCollectionManage;
        private System.Windows.Forms.Panel panelCollections;
    }
}