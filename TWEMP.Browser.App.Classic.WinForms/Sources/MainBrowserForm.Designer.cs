using TWEMP.Browser.App.Classic.WinForms.Properties;

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
            TreeNode treeNode1 = new TreeNode("My Favorite Mods");
            TreeNode treeNode2 = new TreeNode("My Mod Collections");
            TreeNode treeNode3 = new TreeNode("All Modifications");
            buttonLaunch = new Button();
            panelLauncherOptions = new Panel();
            groupBoxConfigProfiles = new GroupBox();
            configProfileSwitchButton = new Button();
            radioButtonConfigProfile_Modding = new RadioButton();
            radioButtonConfigProfile_Gaming = new RadioButton();
            groupBoxLauncherProviders = new GroupBox();
            radioButtonLauncherProvider_TWEMP = new RadioButton();
            radioButtonLauncherProvider_BatchScript = new RadioButton();
            radioButtonLauncherProvider_NativeSetup = new RadioButton();
            radioButtonLauncherProvider_M2TWEOP = new RadioButton();
            groupBoxConfigCleanerMode = new GroupBox();
            checkBoxCleaner_soundPacks = new CheckBox();
            checkBoxCleaner_textBIN = new CheckBox();
            checkBoxCleaner_MapRWM = new CheckBox();
            groupBoxConfigLogMode = new GroupBox();
            checkBoxLogHistory = new CheckBox();
            radioButtonLogErrorAndTrace = new RadioButton();
            radioButtonLogOnlyTrace = new RadioButton();
            radioButtonLogOnlyError = new RadioButton();
            groupBoxConfigLaunchMode = new GroupBox();
            checkBoxBorderless = new CheckBox();
            checkBoxVideo = new CheckBox();
            radioButtonLaunchFullScreen = new RadioButton();
            radioButtonLaunchWindowScreen = new RadioButton();
            buttonExplore = new Button();
            modQuickNavigationButton = new Button();
            panelLauncherToolkit = new Panel();
            modConfigProfilesButton = new Button();
            modConfigSettingsButton = new Button();
            modMainTitleLabel = new Label();
            modLogoPictureBox = new PictureBox();
            modStatusLabel = new Label();
            appStatusStrip = new StatusStrip();
            appMenuStrip = new MenuStrip();
            toolStripAppItem = new ToolStripMenuItem();
            gameSetupSettingsToolStripMenuItem = new ToolStripMenuItem();
            modSupportPresetSettingsToolStripMenuItem = new ToolStripMenuItem();
            gameMusicPlayerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            applicationSettingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            applicationHomeFolderToolStripMenuItem = new ToolStripMenuItem();
            exitFromApplicationToolStripMenuItem = new ToolStripMenuItem();
            toolStripModItem = new ToolStripMenuItem();
            gameConfigProfilesToolStripMenuItem = new ToolStripMenuItem();
            gameConfigProfilesSwitcherToolStripMenuItem = new ToolStripMenuItem();
            configSettingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripHelpItem = new ToolStripMenuItem();
            aboutProgramToolStripMenuItem = new ToolStripMenuItem();
            treeViewGameMods = new TreeView();
            buttonMarkFavoriteMod = new Button();
            buttonCollectionCreate = new Button();
            buttonCollectionManage = new Button();
            panelCollections = new Panel();
            panelMediaDevice = new Panel();
            buttonMusicRewind = new Button();
            buttonMusicPause = new Button();
            buttonMusicPlay = new Button();
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
            panelMediaDevice.SuspendLayout();
            SuspendLayout();
            // 
            // buttonLaunch
            // 
            buttonLaunch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonLaunch.BackColor = Color.LightGreen;
            buttonLaunch.Cursor = Cursors.Hand;
            buttonLaunch.Enabled = false;
            buttonLaunch.FlatStyle = FlatStyle.Flat;
            buttonLaunch.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
            buttonLaunch.ForeColor = SystemColors.ControlText;
            buttonLaunch.Location = new Point(4, 3);
            buttonLaunch.Margin = new Padding(4, 3, 4, 3);
            buttonLaunch.Name = "buttonLaunch";
            buttonLaunch.Size = new Size(362, 62);
            buttonLaunch.TabIndex = 0;
            buttonLaunch.Text = "LAUNCH";
            buttonLaunch.UseVisualStyleBackColor = false;
            buttonLaunch.Click += ButtonLaunch_Click;
            // 
            // panelLauncherOptions
            // 
            panelLauncherOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelLauncherOptions.AutoScroll = true;
            panelLauncherOptions.BackColor = Color.MediumAquamarine;
            panelLauncherOptions.BorderStyle = BorderStyle.FixedSingle;
            panelLauncherOptions.Controls.Add(groupBoxConfigProfiles);
            panelLauncherOptions.Controls.Add(groupBoxLauncherProviders);
            panelLauncherOptions.Controls.Add(groupBoxConfigCleanerMode);
            panelLauncherOptions.Controls.Add(groupBoxConfigLogMode);
            panelLauncherOptions.Controls.Add(groupBoxConfigLaunchMode);
            panelLauncherOptions.Cursor = Cursors.Hand;
            panelLauncherOptions.Location = new Point(719, 84);
            panelLauncherOptions.Margin = new Padding(4, 3, 4, 3);
            panelLauncherOptions.Name = "panelLauncherOptions";
            panelLauncherOptions.Size = new Size(276, 567);
            panelLauncherOptions.TabIndex = 2;
            // 
            // groupBoxConfigProfiles
            // 
            groupBoxConfigProfiles.BackColor = Color.Transparent;
            groupBoxConfigProfiles.Controls.Add(configProfileSwitchButton);
            groupBoxConfigProfiles.Controls.Add(radioButtonConfigProfile_Modding);
            groupBoxConfigProfiles.Controls.Add(radioButtonConfigProfile_Gaming);
            groupBoxConfigProfiles.Location = new Point(3, 3);
            groupBoxConfigProfiles.Name = "groupBoxConfigProfiles";
            groupBoxConfigProfiles.Size = new Size(267, 74);
            groupBoxConfigProfiles.TabIndex = 7;
            groupBoxConfigProfiles.TabStop = false;
            groupBoxConfigProfiles.Text = "Configuration Profiles";
            // 
            // configProfileSwitchButton
            // 
            configProfileSwitchButton.BackColor = Color.LightGreen;
            configProfileSwitchButton.FlatStyle = FlatStyle.Flat;
            configProfileSwitchButton.Font = new Font("Segoe UI", 9F);
            configProfileSwitchButton.Location = new Point(6, 45);
            configProfileSwitchButton.Name = "configProfileSwitchButton";
            configProfileSwitchButton.Size = new Size(255, 23);
            configProfileSwitchButton.TabIndex = 2;
            configProfileSwitchButton.Text = "CONFIG PROFILE SWITCHER";
            configProfileSwitchButton.UseVisualStyleBackColor = false;
            configProfileSwitchButton.Click += ConfigProfileSwitchButton_Click;
            // 
            // radioButtonConfigProfile_Modding
            // 
            radioButtonConfigProfile_Modding.AutoSize = true;
            radioButtonConfigProfile_Modding.BackColor = Color.Transparent;
            radioButtonConfigProfile_Modding.Checked = true;
            radioButtonConfigProfile_Modding.Location = new Point(119, 22);
            radioButtonConfigProfile_Modding.Name = "radioButtonConfigProfile_Modding";
            radioButtonConfigProfile_Modding.Size = new Size(118, 19);
            radioButtonConfigProfile_Modding.TabIndex = 1;
            radioButtonConfigProfile_Modding.TabStop = true;
            radioButtonConfigProfile_Modding.Text = "MODDING MODE";
            radioButtonConfigProfile_Modding.UseVisualStyleBackColor = false;
            radioButtonConfigProfile_Modding.CheckedChanged += RadioButtonConfigProfile_Modding_CheckedChanged;
            // 
            // radioButtonConfigProfile_Gaming
            // 
            radioButtonConfigProfile_Gaming.AutoSize = true;
            radioButtonConfigProfile_Gaming.BackColor = Color.Transparent;
            radioButtonConfigProfile_Gaming.Location = new Point(6, 22);
            radioButtonConfigProfile_Gaming.Name = "radioButtonConfigProfile_Gaming";
            radioButtonConfigProfile_Gaming.Size = new Size(109, 19);
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
            groupBoxLauncherProviders.Location = new Point(3, 431);
            groupBoxLauncherProviders.Name = "groupBoxLauncherProviders";
            groupBoxLauncherProviders.Size = new Size(267, 131);
            groupBoxLauncherProviders.TabIndex = 6;
            groupBoxLauncherProviders.TabStop = false;
            groupBoxLauncherProviders.Text = "Launcher Providers";
            // 
            // radioButtonLauncherProvider_TWEMP
            // 
            radioButtonLauncherProvider_TWEMP.AutoSize = true;
            radioButtonLauncherProvider_TWEMP.Checked = true;
            radioButtonLauncherProvider_TWEMP.Location = new Point(12, 20);
            radioButtonLauncherProvider_TWEMP.Name = "radioButtonLauncherProvider_TWEMP";
            radioButtonLauncherProvider_TWEMP.Size = new Size(212, 19);
            radioButtonLauncherProvider_TWEMP.TabIndex = 3;
            radioButtonLauncherProvider_TWEMP.TabStop = true;
            radioButtonLauncherProvider_TWEMP.Text = "Launch Game via TWEMP Launcher";
            radioButtonLauncherProvider_TWEMP.UseVisualStyleBackColor = true;
            radioButtonLauncherProvider_TWEMP.CheckedChanged += RadioButtonLauncherProvider_TWEMP_CheckedChanged;
            // 
            // radioButtonLauncherProvider_BatchScript
            // 
            radioButtonLauncherProvider_BatchScript.AutoSize = true;
            radioButtonLauncherProvider_BatchScript.Location = new Point(12, 47);
            radioButtonLauncherProvider_BatchScript.Name = "radioButtonLauncherProvider_BatchScript";
            radioButtonLauncherProvider_BatchScript.Size = new Size(182, 19);
            radioButtonLauncherProvider_BatchScript.TabIndex = 2;
            radioButtonLauncherProvider_BatchScript.Text = "Launch Game via Batch Script";
            radioButtonLauncherProvider_BatchScript.UseVisualStyleBackColor = true;
            radioButtonLauncherProvider_BatchScript.CheckedChanged += RadioButtonLauncherProvider_BatchScript_CheckedChanged;
            // 
            // radioButtonLauncherProvider_NativeSetup
            // 
            radioButtonLauncherProvider_NativeSetup.AutoSize = true;
            radioButtonLauncherProvider_NativeSetup.Location = new Point(12, 72);
            radioButtonLauncherProvider_NativeSetup.Name = "radioButtonLauncherProvider_NativeSetup";
            radioButtonLauncherProvider_NativeSetup.Size = new Size(186, 19);
            radioButtonLauncherProvider_NativeSetup.TabIndex = 1;
            radioButtonLauncherProvider_NativeSetup.Text = "Launch Game via Native Setup";
            radioButtonLauncherProvider_NativeSetup.UseVisualStyleBackColor = true;
            radioButtonLauncherProvider_NativeSetup.CheckedChanged += RadioButtonLauncherProvider_NativeSetup_CheckedChanged;
            // 
            // radioButtonLauncherProvider_M2TWEOP
            // 
            radioButtonLauncherProvider_M2TWEOP.AutoSize = true;
            radioButtonLauncherProvider_M2TWEOP.Location = new Point(12, 97);
            radioButtonLauncherProvider_M2TWEOP.Name = "radioButtonLauncherProvider_M2TWEOP";
            radioButtonLauncherProvider_M2TWEOP.Size = new Size(197, 19);
            radioButtonLauncherProvider_M2TWEOP.TabIndex = 0;
            radioButtonLauncherProvider_M2TWEOP.Text = "Launch Game via M2TWEOP GUI";
            radioButtonLauncherProvider_M2TWEOP.UseVisualStyleBackColor = true;
            radioButtonLauncherProvider_M2TWEOP.CheckedChanged += RadioButtonLauncherProvider_M2TWEOP_CheckedChanged;
            // 
            // groupBoxConfigCleanerMode
            // 
            groupBoxConfigCleanerMode.BackColor = Color.Transparent;
            groupBoxConfigCleanerMode.Controls.Add(checkBoxCleaner_soundPacks);
            groupBoxConfigCleanerMode.Controls.Add(checkBoxCleaner_textBIN);
            groupBoxConfigCleanerMode.Controls.Add(checkBoxCleaner_MapRWM);
            groupBoxConfigCleanerMode.Location = new Point(4, 322);
            groupBoxConfigCleanerMode.Margin = new Padding(4, 3, 4, 3);
            groupBoxConfigCleanerMode.Name = "groupBoxConfigCleanerMode";
            groupBoxConfigCleanerMode.Padding = new Padding(4, 3, 4, 3);
            groupBoxConfigCleanerMode.Size = new Size(266, 103);
            groupBoxConfigCleanerMode.TabIndex = 5;
            groupBoxConfigCleanerMode.TabStop = false;
            groupBoxConfigCleanerMode.Text = "Select mod clean routines";
            // 
            // checkBoxCleaner_soundPacks
            // 
            checkBoxCleaner_soundPacks.AutoSize = true;
            checkBoxCleaner_soundPacks.Location = new Point(10, 75);
            checkBoxCleaner_soundPacks.Margin = new Padding(4, 3, 4, 3);
            checkBoxCleaner_soundPacks.Name = "checkBoxCleaner_soundPacks";
            checkBoxCleaner_soundPacks.Size = new Size(227, 19);
            checkBoxCleaner_soundPacks.TabIndex = 2;
            checkBoxCleaner_soundPacks.Text = "Delete sound pack files (*.DAT + *.IDX)";
            checkBoxCleaner_soundPacks.UseVisualStyleBackColor = true;
            // 
            // checkBoxCleaner_textBIN
            // 
            checkBoxCleaner_textBIN.AutoSize = true;
            checkBoxCleaner_textBIN.Location = new Point(10, 48);
            checkBoxCleaner_textBIN.Margin = new Padding(4, 3, 4, 3);
            checkBoxCleaner_textBIN.Name = "checkBoxCleaner_textBIN";
            checkBoxCleaner_textBIN.Size = new Size(209, 19);
            checkBoxCleaner_textBIN.TabIndex = 1;
            checkBoxCleaner_textBIN.Text = "Delete localization *strings.bin files";
            checkBoxCleaner_textBIN.UseVisualStyleBackColor = true;
            // 
            // checkBoxCleaner_MapRWM
            // 
            checkBoxCleaner_MapRWM.AutoSize = true;
            checkBoxCleaner_MapRWM.Location = new Point(10, 22);
            checkBoxCleaner_MapRWM.Margin = new Padding(4, 3, 4, 3);
            checkBoxCleaner_MapRWM.Name = "checkBoxCleaner_MapRWM";
            checkBoxCleaner_MapRWM.Size = new Size(132, 19);
            checkBoxCleaner_MapRWM.TabIndex = 0;
            checkBoxCleaner_MapRWM.Text = "Delete map.rwm file";
            checkBoxCleaner_MapRWM.UseVisualStyleBackColor = true;
            // 
            // groupBoxConfigLogMode
            // 
            groupBoxConfigLogMode.BackColor = Color.Transparent;
            groupBoxConfigLogMode.Controls.Add(checkBoxLogHistory);
            groupBoxConfigLogMode.Controls.Add(radioButtonLogErrorAndTrace);
            groupBoxConfigLogMode.Controls.Add(radioButtonLogOnlyTrace);
            groupBoxConfigLogMode.Controls.Add(radioButtonLogOnlyError);
            groupBoxConfigLogMode.Location = new Point(4, 205);
            groupBoxConfigLogMode.Margin = new Padding(4, 3, 4, 3);
            groupBoxConfigLogMode.Name = "groupBoxConfigLogMode";
            groupBoxConfigLogMode.Padding = new Padding(4, 3, 4, 3);
            groupBoxConfigLogMode.Size = new Size(266, 111);
            groupBoxConfigLogMode.TabIndex = 1;
            groupBoxConfigLogMode.TabStop = false;
            groupBoxConfigLogMode.Text = "Select a mode of creating system.log file";
            // 
            // checkBoxLogHistory
            // 
            checkBoxLogHistory.AutoSize = true;
            checkBoxLogHistory.Checked = true;
            checkBoxLogHistory.CheckState = CheckState.Checked;
            checkBoxLogHistory.Location = new Point(8, 92);
            checkBoxLogHistory.Margin = new Padding(4, 3, 4, 3);
            checkBoxLogHistory.Name = "checkBoxLogHistory";
            checkBoxLogHistory.Size = new Size(167, 19);
            checkBoxLogHistory.TabIndex = 3;
            checkBoxLogHistory.Text = "Save game system.log files";
            checkBoxLogHistory.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogErrorAndTrace
            // 
            radioButtonLogErrorAndTrace.AutoSize = true;
            radioButtonLogErrorAndTrace.Checked = true;
            radioButtonLogErrorAndTrace.Location = new Point(7, 69);
            radioButtonLogErrorAndTrace.Margin = new Padding(4, 3, 4, 3);
            radioButtonLogErrorAndTrace.Name = "radioButtonLogErrorAndTrace";
            radioButtonLogErrorAndTrace.Size = new Size(96, 19);
            radioButtonLogErrorAndTrace.TabIndex = 2;
            radioButtonLogErrorAndTrace.TabStop = true;
            radioButtonLogErrorAndTrace.Text = "Errors + Trace";
            radioButtonLogErrorAndTrace.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogOnlyTrace
            // 
            radioButtonLogOnlyTrace.AutoSize = true;
            radioButtonLogOnlyTrace.Location = new Point(7, 46);
            radioButtonLogOnlyTrace.Margin = new Padding(4, 3, 4, 3);
            radioButtonLogOnlyTrace.Name = "radioButtonLogOnlyTrace";
            radioButtonLogOnlyTrace.Size = new Size(80, 19);
            radioButtonLogOnlyTrace.TabIndex = 1;
            radioButtonLogOnlyTrace.Text = "Only Trace";
            radioButtonLogOnlyTrace.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogOnlyError
            // 
            radioButtonLogOnlyError.AutoSize = true;
            radioButtonLogOnlyError.Location = new Point(7, 22);
            radioButtonLogOnlyError.Margin = new Padding(4, 3, 4, 3);
            radioButtonLogOnlyError.Name = "radioButtonLogOnlyError";
            radioButtonLogOnlyError.Size = new Size(83, 19);
            radioButtonLogOnlyError.TabIndex = 0;
            radioButtonLogOnlyError.Text = "Only Errors";
            radioButtonLogOnlyError.UseVisualStyleBackColor = true;
            // 
            // groupBoxConfigLaunchMode
            // 
            groupBoxConfigLaunchMode.BackColor = Color.Transparent;
            groupBoxConfigLaunchMode.Controls.Add(checkBoxBorderless);
            groupBoxConfigLaunchMode.Controls.Add(checkBoxVideo);
            groupBoxConfigLaunchMode.Controls.Add(radioButtonLaunchFullScreen);
            groupBoxConfigLaunchMode.Controls.Add(radioButtonLaunchWindowScreen);
            groupBoxConfigLaunchMode.Location = new Point(4, 83);
            groupBoxConfigLaunchMode.Margin = new Padding(4, 3, 4, 3);
            groupBoxConfigLaunchMode.Name = "groupBoxConfigLaunchMode";
            groupBoxConfigLaunchMode.Padding = new Padding(4, 3, 4, 3);
            groupBoxConfigLaunchMode.Size = new Size(266, 122);
            groupBoxConfigLaunchMode.TabIndex = 0;
            groupBoxConfigLaunchMode.TabStop = false;
            groupBoxConfigLaunchMode.Text = "Select game launch mode";
            // 
            // checkBoxBorderless
            // 
            checkBoxBorderless.AutoSize = true;
            checkBoxBorderless.Location = new Point(8, 97);
            checkBoxBorderless.Margin = new Padding(4, 3, 4, 3);
            checkBoxBorderless.Name = "checkBoxBorderless";
            checkBoxBorderless.Size = new Size(174, 19);
            checkBoxBorderless.TabIndex = 2;
            checkBoxBorderless.Text = "Borderless Windowed Mode";
            checkBoxBorderless.UseVisualStyleBackColor = true;
            // 
            // checkBoxVideo
            // 
            checkBoxVideo.AutoSize = true;
            checkBoxVideo.Location = new Point(8, 72);
            checkBoxVideo.Margin = new Padding(4, 3, 4, 3);
            checkBoxVideo.Name = "checkBoxVideo";
            checkBoxVideo.Size = new Size(128, 19);
            checkBoxVideo.TabIndex = 0;
            checkBoxVideo.Text = "Enable Game Video";
            checkBoxVideo.UseVisualStyleBackColor = true;
            // 
            // radioButtonLaunchFullScreen
            // 
            radioButtonLaunchFullScreen.AutoSize = true;
            radioButtonLaunchFullScreen.Location = new Point(8, 47);
            radioButtonLaunchFullScreen.Margin = new Padding(4, 3, 4, 3);
            radioButtonLaunchFullScreen.Name = "radioButtonLaunchFullScreen";
            radioButtonLaunchFullScreen.Size = new Size(118, 19);
            radioButtonLaunchFullScreen.TabIndex = 1;
            radioButtonLaunchFullScreen.Text = "Full-Screen Mode";
            radioButtonLaunchFullScreen.UseVisualStyleBackColor = true;
            // 
            // radioButtonLaunchWindowScreen
            // 
            radioButtonLaunchWindowScreen.AutoSize = true;
            radioButtonLaunchWindowScreen.Checked = true;
            radioButtonLaunchWindowScreen.Location = new Point(8, 22);
            radioButtonLaunchWindowScreen.Margin = new Padding(4, 3, 4, 3);
            radioButtonLaunchWindowScreen.Name = "radioButtonLaunchWindowScreen";
            radioButtonLaunchWindowScreen.Size = new Size(116, 19);
            radioButtonLaunchWindowScreen.TabIndex = 0;
            radioButtonLaunchWindowScreen.TabStop = true;
            radioButtonLaunchWindowScreen.Text = "Windowed Mode";
            radioButtonLaunchWindowScreen.UseVisualStyleBackColor = true;
            // 
            // buttonExplore
            // 
            buttonExplore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonExplore.BackColor = Color.LightGreen;
            buttonExplore.Cursor = Cursors.Hand;
            buttonExplore.Enabled = false;
            buttonExplore.FlatStyle = FlatStyle.Flat;
            buttonExplore.Font = new Font("Segoe UI", 9F);
            buttonExplore.Location = new Point(3, 176);
            buttonExplore.Name = "buttonExplore";
            buttonExplore.Size = new Size(363, 27);
            buttonExplore.TabIndex = 8;
            buttonExplore.Text = "MOD HOME FOLDER";
            buttonExplore.UseVisualStyleBackColor = false;
            buttonExplore.Click += ButtonExplore_Click;
            // 
            // modQuickNavigationButton
            // 
            modQuickNavigationButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modQuickNavigationButton.BackColor = Color.LightGreen;
            modQuickNavigationButton.Cursor = Cursors.Hand;
            modQuickNavigationButton.Enabled = false;
            modQuickNavigationButton.FlatStyle = FlatStyle.Flat;
            modQuickNavigationButton.Font = new Font("Microsoft Sans Serif", 9F);
            modQuickNavigationButton.Location = new Point(3, 144);
            modQuickNavigationButton.Margin = new Padding(4, 3, 4, 3);
            modQuickNavigationButton.Name = "modQuickNavigationButton";
            modQuickNavigationButton.Size = new Size(363, 27);
            modQuickNavigationButton.TabIndex = 7;
            modQuickNavigationButton.Text = "MOD QUICK NAVIGATION";
            modQuickNavigationButton.UseVisualStyleBackColor = false;
            modQuickNavigationButton.Click += ModQuickNavigationButton_Click;
            // 
            // panelLauncherToolkit
            // 
            panelLauncherToolkit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelLauncherToolkit.BackColor = Color.MediumAquamarine;
            panelLauncherToolkit.BorderStyle = BorderStyle.FixedSingle;
            panelLauncherToolkit.Controls.Add(modConfigProfilesButton);
            panelLauncherToolkit.Controls.Add(modConfigSettingsButton);
            panelLauncherToolkit.Controls.Add(modQuickNavigationButton);
            panelLauncherToolkit.Controls.Add(buttonExplore);
            panelLauncherToolkit.Controls.Add(buttonLaunch);
            panelLauncherToolkit.Location = new Point(340, 443);
            panelLauncherToolkit.Margin = new Padding(4, 3, 4, 3);
            panelLauncherToolkit.Name = "panelLauncherToolkit";
            panelLauncherToolkit.Size = new Size(372, 208);
            panelLauncherToolkit.TabIndex = 6;
            // 
            // modConfigProfilesButton
            // 
            modConfigProfilesButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            modConfigProfilesButton.BackColor = Color.LightGreen;
            modConfigProfilesButton.FlatStyle = FlatStyle.Flat;
            modConfigProfilesButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            modConfigProfilesButton.Location = new Point(5, 108);
            modConfigProfilesButton.Name = "modConfigProfilesButton";
            modConfigProfilesButton.Size = new Size(361, 30);
            modConfigProfilesButton.TabIndex = 10;
            modConfigProfilesButton.Text = "CONFIG PROFILES";
            modConfigProfilesButton.UseVisualStyleBackColor = false;
            modConfigProfilesButton.Click += ModConfigProfilesButton_Click;
            // 
            // modConfigSettingsButton
            // 
            modConfigSettingsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            modConfigSettingsButton.BackColor = Color.LightGreen;
            modConfigSettingsButton.FlatStyle = FlatStyle.Flat;
            modConfigSettingsButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            modConfigSettingsButton.Location = new Point(5, 71);
            modConfigSettingsButton.Name = "modConfigSettingsButton";
            modConfigSettingsButton.Size = new Size(361, 30);
            modConfigSettingsButton.TabIndex = 9;
            modConfigSettingsButton.Text = "CONFIG SETTINGS";
            modConfigSettingsButton.UseVisualStyleBackColor = false;
            modConfigSettingsButton.Click += ModConfigSettingsButton_Click;
            // 
            // modMainTitleLabel
            // 
            modMainTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            modMainTitleLabel.BackColor = Color.MediumSeaGreen;
            modMainTitleLabel.BorderStyle = BorderStyle.FixedSingle;
            modMainTitleLabel.Font = new Font("Palatino Linotype", 24F, FontStyle.Bold);
            modMainTitleLabel.Location = new Point(12, 35);
            modMainTitleLabel.Name = "modMainTitleLabel";
            modMainTitleLabel.Size = new Size(983, 46);
            modMainTitleLabel.TabIndex = 8;
            modMainTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // modLogoPictureBox
            // 
            modLogoPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modLogoPictureBox.BackColor = Color.Transparent;
            modLogoPictureBox.BorderStyle = BorderStyle.FixedSingle;
            modLogoPictureBox.Image = Resources.OPENTWEMP_LOGO;
            modLogoPictureBox.Location = new Point(340, 84);
            modLogoPictureBox.Name = "modLogoPictureBox";
            modLogoPictureBox.Size = new Size(372, 353);
            modLogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            modLogoPictureBox.TabIndex = 9;
            modLogoPictureBox.TabStop = false;
            // 
            // modStatusLabel
            // 
            modStatusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modStatusLabel.BackColor = Color.MediumSeaGreen;
            modStatusLabel.BorderStyle = BorderStyle.FixedSingle;
            modStatusLabel.Font = new Font("Segoe UI", 14F);
            modStatusLabel.ForeColor = Color.Black;
            modStatusLabel.Location = new Point(12, 654);
            modStatusLabel.Name = "modStatusLabel";
            modStatusLabel.Size = new Size(983, 42);
            modStatusLabel.TabIndex = 12;
            modStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // appStatusStrip
            // 
            appStatusStrip.Location = new Point(0, 707);
            appStatusStrip.Name = "appStatusStrip";
            appStatusStrip.Size = new Size(1008, 22);
            appStatusStrip.TabIndex = 13;
            appStatusStrip.Text = "statusStrip1";
            // 
            // appMenuStrip
            // 
            appMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripAppItem, toolStripModItem, toolStripHelpItem });
            appMenuStrip.Location = new Point(0, 0);
            appMenuStrip.Name = "appMenuStrip";
            appMenuStrip.Size = new Size(1008, 24);
            appMenuStrip.TabIndex = 15;
            appMenuStrip.Text = "menuStrip1";
            // 
            // toolStripAppItem
            // 
            toolStripAppItem.DropDownItems.AddRange(new ToolStripItem[] { gameSetupSettingsToolStripMenuItem, modSupportPresetSettingsToolStripMenuItem, gameMusicPlayerToolStripMenuItem, toolStripSeparator1, applicationSettingsToolStripMenuItem, toolStripSeparator2, applicationHomeFolderToolStripMenuItem, exitFromApplicationToolStripMenuItem });
            toolStripAppItem.Name = "toolStripAppItem";
            toolStripAppItem.Size = new Size(72, 20);
            toolStripAppItem.Text = "BROWSER";
            // 
            // gameSetupSettingsToolStripMenuItem
            // 
            gameSetupSettingsToolStripMenuItem.Name = "gameSetupSettingsToolStripMenuItem";
            gameSetupSettingsToolStripMenuItem.Size = new Size(257, 22);
            gameSetupSettingsToolStripMenuItem.Text = "Game Setup Settings";
            gameSetupSettingsToolStripMenuItem.Click += GameSetupSettingsToolStripMenuItem_Click;
            // 
            // modSupportPresetSettingsToolStripMenuItem
            // 
            modSupportPresetSettingsToolStripMenuItem.Name = "modSupportPresetSettingsToolStripMenuItem";
            modSupportPresetSettingsToolStripMenuItem.Size = new Size(257, 22);
            modSupportPresetSettingsToolStripMenuItem.Text = "Mod Support Preset Settings";
            modSupportPresetSettingsToolStripMenuItem.Click += ModSupportPresetSettingsToolStripMenuItem_Click;
            // 
            // gameMusicPlayerToolStripMenuItem
            // 
            gameMusicPlayerToolStripMenuItem.Name = "gameMusicPlayerToolStripMenuItem";
            gameMusicPlayerToolStripMenuItem.Size = new Size(257, 22);
            gameMusicPlayerToolStripMenuItem.Text = "Media Device - Game Music Player";
            gameMusicPlayerToolStripMenuItem.Click += GameMusicPlayerToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(254, 6);
            // 
            // applicationSettingsToolStripMenuItem
            // 
            applicationSettingsToolStripMenuItem.Name = "applicationSettingsToolStripMenuItem";
            applicationSettingsToolStripMenuItem.Size = new Size(257, 22);
            applicationSettingsToolStripMenuItem.Text = "Application Settings";
            applicationSettingsToolStripMenuItem.Click += ApplicationSettingsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(254, 6);
            // 
            // applicationHomeFolderToolStripMenuItem
            // 
            applicationHomeFolderToolStripMenuItem.Name = "applicationHomeFolderToolStripMenuItem";
            applicationHomeFolderToolStripMenuItem.Size = new Size(257, 22);
            applicationHomeFolderToolStripMenuItem.Text = "Go to Home Folder";
            applicationHomeFolderToolStripMenuItem.Click += ApplicationHomeFolderToolStripMenuItem_Click;
            // 
            // exitFromApplicationToolStripMenuItem
            // 
            exitFromApplicationToolStripMenuItem.Name = "exitFromApplicationToolStripMenuItem";
            exitFromApplicationToolStripMenuItem.Size = new Size(257, 22);
            exitFromApplicationToolStripMenuItem.Text = "Exit from Program";
            exitFromApplicationToolStripMenuItem.Click += ExitFromApplicationToolStripMenuItem_Click;
            // 
            // toolStripModItem
            // 
            toolStripModItem.DropDownItems.AddRange(new ToolStripItem[] { gameConfigProfilesToolStripMenuItem, gameConfigProfilesSwitcherToolStripMenuItem, configSettingsToolStripMenuItem });
            toolStripModItem.Name = "toolStripModItem";
            toolStripModItem.Size = new Size(101, 20);
            toolStripModItem.Text = "MODIFICATION";
            // 
            // gameConfigProfilesToolStripMenuItem
            // 
            gameConfigProfilesToolStripMenuItem.Name = "gameConfigProfilesToolStripMenuItem";
            gameConfigProfilesToolStripMenuItem.Size = new Size(234, 22);
            gameConfigProfilesToolStripMenuItem.Text = "Game Config Profiles";
            gameConfigProfilesToolStripMenuItem.Click += GameConfigProfilesToolStripMenuItem_Click;
            // 
            // gameConfigProfilesSwitcherToolStripMenuItem
            // 
            gameConfigProfilesSwitcherToolStripMenuItem.Name = "gameConfigProfilesSwitcherToolStripMenuItem";
            gameConfigProfilesSwitcherToolStripMenuItem.Size = new Size(234, 22);
            gameConfigProfilesSwitcherToolStripMenuItem.Text = "Game Config Profiles Switcher";
            gameConfigProfilesSwitcherToolStripMenuItem.Click += GameConfigProfilesSwitcherToolStripMenuItem_Click;
            // 
            // configSettingsToolStripMenuItem
            // 
            configSettingsToolStripMenuItem.Name = "configSettingsToolStripMenuItem";
            configSettingsToolStripMenuItem.Size = new Size(234, 22);
            configSettingsToolStripMenuItem.Text = "Configuration Settings";
            configSettingsToolStripMenuItem.Click += ConfigSettingsToolStripMenuItem_Click;
            // 
            // toolStripHelpItem
            // 
            toolStripHelpItem.DropDownItems.AddRange(new ToolStripItem[] { aboutProgramToolStripMenuItem });
            toolStripHelpItem.Name = "toolStripHelpItem";
            toolStripHelpItem.Size = new Size(47, 20);
            toolStripHelpItem.Text = "HELP";
            // 
            // aboutProgramToolStripMenuItem
            // 
            aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            aboutProgramToolStripMenuItem.Size = new Size(156, 22);
            aboutProgramToolStripMenuItem.Text = "About Program";
            aboutProgramToolStripMenuItem.Click += AboutProgramToolStripMenuItem_Click;
            // 
            // treeViewGameMods
            // 
            treeViewGameMods.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeViewGameMods.BackColor = Color.MediumSeaGreen;
            treeViewGameMods.BorderStyle = BorderStyle.FixedSingle;
            treeViewGameMods.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold | FontStyle.Underline);
            treeViewGameMods.FullRowSelect = true;
            treeViewGameMods.Indent = 15;
            treeViewGameMods.ItemHeight = 30;
            treeViewGameMods.Location = new Point(13, 84);
            treeViewGameMods.Name = "treeViewGameMods";
            treeNode1.Name = "Node0";
            treeNode1.Text = "My Favorite Mods";
            treeNode2.Name = "Node1";
            treeNode2.Text = "My Mod Collections";
            treeNode3.Name = "Node2";
            treeNode3.Text = "All Modifications";
            treeViewGameMods.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            treeViewGameMods.Size = new Size(320, 353);
            treeViewGameMods.TabIndex = 16;
            treeViewGameMods.AfterSelect += TreeViewGameMods_AfterSelect;
            // 
            // buttonMarkFavoriteMod
            // 
            buttonMarkFavoriteMod.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonMarkFavoriteMod.BackColor = Color.LightGreen;
            buttonMarkFavoriteMod.FlatStyle = FlatStyle.Flat;
            buttonMarkFavoriteMod.Font = new Font("Segoe UI", 10F);
            buttonMarkFavoriteMod.Location = new Point(3, 7);
            buttonMarkFavoriteMod.Name = "buttonMarkFavoriteMod";
            buttonMarkFavoriteMod.Size = new Size(313, 40);
            buttonMarkFavoriteMod.TabIndex = 18;
            buttonMarkFavoriteMod.Text = "MARK or UNMARK THIS MOD as FAVORITE";
            buttonMarkFavoriteMod.UseVisualStyleBackColor = false;
            buttonMarkFavoriteMod.Click += ButtonMarkFavoriteMod_Click;
            // 
            // buttonCollectionCreate
            // 
            buttonCollectionCreate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonCollectionCreate.BackColor = Color.LightGreen;
            buttonCollectionCreate.FlatStyle = FlatStyle.Flat;
            buttonCollectionCreate.Font = new Font("Segoe UI", 10F);
            buttonCollectionCreate.Location = new Point(3, 53);
            buttonCollectionCreate.Name = "buttonCollectionCreate";
            buttonCollectionCreate.Size = new Size(313, 40);
            buttonCollectionCreate.TabIndex = 19;
            buttonCollectionCreate.Text = "CREATE A NEW COLLECTION";
            buttonCollectionCreate.UseVisualStyleBackColor = false;
            buttonCollectionCreate.Click += ButtonCollectionCreate_Click;
            // 
            // buttonCollectionManage
            // 
            buttonCollectionManage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonCollectionManage.BackColor = Color.LightGreen;
            buttonCollectionManage.FlatStyle = FlatStyle.Flat;
            buttonCollectionManage.Font = new Font("Segoe UI", 10F);
            buttonCollectionManage.Location = new Point(3, 97);
            buttonCollectionManage.Name = "buttonCollectionManage";
            buttonCollectionManage.Size = new Size(313, 40);
            buttonCollectionManage.TabIndex = 20;
            buttonCollectionManage.Text = "MANAGE YOUR COLLECTIONS";
            buttonCollectionManage.UseVisualStyleBackColor = false;
            buttonCollectionManage.Click += ButtonCollectionManage_Click;
            // 
            // panelCollections
            // 
            panelCollections.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelCollections.BackColor = Color.MediumAquamarine;
            panelCollections.BorderStyle = BorderStyle.FixedSingle;
            panelCollections.Controls.Add(buttonCollectionManage);
            panelCollections.Controls.Add(buttonCollectionCreate);
            panelCollections.Controls.Add(buttonMarkFavoriteMod);
            panelCollections.Location = new Point(12, 443);
            panelCollections.Name = "panelCollections";
            panelCollections.Size = new Size(321, 146);
            panelCollections.TabIndex = 21;
            // 
            // panelMediaDevice
            // 
            panelMediaDevice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelMediaDevice.BackColor = Color.MediumAquamarine;
            panelMediaDevice.BorderStyle = BorderStyle.FixedSingle;
            panelMediaDevice.Controls.Add(buttonMusicRewind);
            panelMediaDevice.Controls.Add(buttonMusicPause);
            panelMediaDevice.Controls.Add(buttonMusicPlay);
            panelMediaDevice.Location = new Point(12, 595);
            panelMediaDevice.Name = "panelMediaDevice";
            panelMediaDevice.Size = new Size(321, 56);
            panelMediaDevice.TabIndex = 22;
            // 
            // buttonMusicRewind
            // 
            buttonMusicRewind.BackColor = Color.LightGreen;
            buttonMusicRewind.Font = new Font("Segoe UI", 9F);
            buttonMusicRewind.Location = new Point(216, 11);
            buttonMusicRewind.Name = "buttonMusicRewind";
            buttonMusicRewind.Size = new Size(100, 30);
            buttonMusicRewind.TabIndex = 2;
            buttonMusicRewind.Text = "REWIND";
            buttonMusicRewind.UseVisualStyleBackColor = false;
            buttonMusicRewind.Click += ButtonMusicRewind_Click;
            // 
            // buttonMusicPause
            // 
            buttonMusicPause.BackColor = Color.LightGreen;
            buttonMusicPause.Font = new Font("Segoe UI", 9F);
            buttonMusicPause.Location = new Point(110, 11);
            buttonMusicPause.Name = "buttonMusicPause";
            buttonMusicPause.Size = new Size(100, 30);
            buttonMusicPause.TabIndex = 1;
            buttonMusicPause.Text = "PAUSE";
            buttonMusicPause.UseVisualStyleBackColor = false;
            buttonMusicPause.Click += ButtonMusicPause_Click;
            // 
            // buttonMusicPlay
            // 
            buttonMusicPlay.BackColor = Color.LightGreen;
            buttonMusicPlay.Font = new Font("Segoe UI", 9F);
            buttonMusicPlay.Location = new Point(4, 12);
            buttonMusicPlay.Name = "buttonMusicPlay";
            buttonMusicPlay.Size = new Size(100, 30);
            buttonMusicPlay.TabIndex = 0;
            buttonMusicPlay.Text = "PLAY";
            buttonMusicPlay.UseVisualStyleBackColor = false;
            buttonMusicPlay.Click += ButtonMusicPlay_Click;
            // 
            // MainBrowserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1008, 729);
            Controls.Add(panelMediaDevice);
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
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1024, 768);
            Name = "MainBrowserForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
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
            panelMediaDevice.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLaunch;
        private Panel panelLauncherOptions;
        private CheckBox checkBoxVideo;
        private GroupBox groupBoxConfigLogMode;
        public RadioButton radioButtonLogErrorAndTrace;
        private RadioButton radioButtonLogOnlyTrace;
        private RadioButton radioButtonLogOnlyError;
        private GroupBox groupBoxConfigLaunchMode;
        private RadioButton radioButtonLaunchFullScreen;
        private RadioButton radioButtonLaunchWindowScreen;
        private Panel panelLauncherToolkit;
        private GroupBox groupBoxConfigCleanerMode;
        private CheckBox checkBoxCleaner_soundPacks;
        private CheckBox checkBoxCleaner_textBIN;
        private CheckBox checkBoxCleaner_MapRWM;
        private CheckBox checkBoxLogHistory;
        private CheckBox checkBoxBorderless;
        private Button modQuickNavigationButton;
        private Button buttonExplore;
        private Label modMainTitleLabel;
        private PictureBox modLogoPictureBox;
        private Label modStatusLabel;
        private StatusStrip appStatusStrip;
        private MenuStrip appMenuStrip;
        private ToolStripMenuItem toolStripAppItem;
        private ToolStripMenuItem toolStripModItem;
        private ToolStripMenuItem toolStripHelpItem;
        private ToolStripMenuItem gameSetupSettingsToolStripMenuItem;
        private ToolStripMenuItem applicationSettingsToolStripMenuItem;
        private ToolStripMenuItem exitFromApplicationToolStripMenuItem;
        private ToolStripMenuItem aboutProgramToolStripMenuItem;
        private ToolStripMenuItem configSettingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem applicationHomeFolderToolStripMenuItem;
        private GroupBox groupBoxLauncherProviders;
        private RadioButton radioButtonLauncherProvider_BatchScript;
        private RadioButton radioButtonLauncherProvider_NativeSetup;
        private RadioButton radioButtonLauncherProvider_M2TWEOP;
        private RadioButton radioButtonLauncherProvider_TWEMP;
        private GroupBox groupBoxConfigProfiles;
        private RadioButton radioButtonConfigProfile_Modding;
        private RadioButton radioButtonConfigProfile_Gaming;
        private TreeView treeViewGameMods;
        private Button buttonMarkFavoriteMod;
        private Button buttonCollectionCreate;
        private Button buttonCollectionManage;
        private Panel panelCollections;
        private ToolStripMenuItem modSupportPresetSettingsToolStripMenuItem;
        private ToolStripMenuItem gameMusicPlayerToolStripMenuItem;
        private ToolStripMenuItem gameConfigProfilesToolStripMenuItem;
        private ToolStripMenuItem gameConfigProfilesSwitcherToolStripMenuItem;
        private Panel panelMediaDevice;
        private Button buttonMusicRewind;
        private Button buttonMusicPause;
        private Button buttonMusicPlay;
        private Button modConfigSettingsButton;
        private Button modConfigProfilesButton;
        private Button configProfileSwitchButton;
    }
}