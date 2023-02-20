
namespace TWE_Launcher.Forms
{
	public partial class MainLauncherForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonLaunch = new System.Windows.Forms.Button();
			this.panelLauncherOptions = new System.Windows.Forms.Panel();
			this.groupBoxConfigCleanerMode = new System.Windows.Forms.GroupBox();
			this.checkBoxCleaner_soundPacks = new System.Windows.Forms.CheckBox();
			this.checkBoxCleaner_textBIN = new System.Windows.Forms.CheckBox();
			this.checkBoxCleaner_MapRWM = new System.Windows.Forms.CheckBox();
			this.groupBoxConfigLogMode = new System.Windows.Forms.GroupBox();
			this.checkBoxLogHistory = new System.Windows.Forms.CheckBox();
			this.radioButtonLogErrorAndTrace = new System.Windows.Forms.RadioButton();
			this.radioButtonLogOnlyTrace = new System.Windows.Forms.RadioButton();
			this.radioButtonLogOnlyError = new System.Windows.Forms.RadioButton();
			this.groupBoxConfigLaunchMode = new System.Windows.Forms.GroupBox();
			this.checkBoxBorderless = new System.Windows.Forms.CheckBox();
			this.checkBoxVideo = new System.Windows.Forms.CheckBox();
			this.radioButtonLaunchFullScreen = new System.Windows.Forms.RadioButton();
			this.radioButtonLaunchWindowScreen = new System.Windows.Forms.RadioButton();
			this.appColorThemeGroupBox = new System.Windows.Forms.GroupBox();
			this.uiStyleByDarkThemeRadioButton = new System.Windows.Forms.RadioButton();
			this.uiStyleByLightThemeRadioButton = new System.Windows.Forms.RadioButton();
			this.uiStyleByDefaultThemeRadioButton = new System.Windows.Forms.RadioButton();
			this.appLocalizationGroupBox = new System.Windows.Forms.GroupBox();
			this.enableEngLocaleRadioButton = new System.Windows.Forms.RadioButton();
			this.enableRusLocaleRadioButton = new System.Windows.Forms.RadioButton();
			this.importGameSetupButton = new System.Windows.Forms.Button();
			this.buttonExit = new System.Windows.Forms.Button();
			this.panelLauncherActions = new System.Windows.Forms.Panel();
			this.buttonShowHomeDirectory = new System.Windows.Forms.Button();
			this.buttonAboutProject = new System.Windows.Forms.Button();
			this.buttonExplore = new System.Windows.Forms.Button();
			this.modQuickNavigationButton = new System.Windows.Forms.Button();
			this.panelLauncherToolkit = new System.Windows.Forms.Panel();
			this.listBoxMODS = new System.Windows.Forms.ListBox();
			this.modMainTitleLabel = new System.Windows.Forms.Label();
			this.modLogoPictureBox = new System.Windows.Forms.PictureBox();
			this.aboutProjectNameLabel1 = new System.Windows.Forms.Label();
			this.aboutProjectNameLabel2 = new System.Windows.Forms.Label();
			this.aboutProjectPanel = new System.Windows.Forms.Panel();
			this.errorModLogotypeNotFoundLabel = new System.Windows.Forms.Label();
			this.aboutProjectReleaseLabel = new System.Windows.Forms.Label();
			this.appStatusStrip = new System.Windows.Forms.StatusStrip();
			this.panelLauncherOptions.SuspendLayout();
			this.groupBoxConfigCleanerMode.SuspendLayout();
			this.groupBoxConfigLogMode.SuspendLayout();
			this.groupBoxConfigLaunchMode.SuspendLayout();
			this.appColorThemeGroupBox.SuspendLayout();
			this.appLocalizationGroupBox.SuspendLayout();
			this.panelLauncherActions.SuspendLayout();
			this.panelLauncherToolkit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.modLogoPictureBox)).BeginInit();
			this.aboutProjectPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonLaunch
			// 
			this.buttonLaunch.BackColor = System.Drawing.Color.LightGreen;
			this.buttonLaunch.Enabled = false;
			this.buttonLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.buttonLaunch.ForeColor = System.Drawing.SystemColors.ControlText;
			this.buttonLaunch.Location = new System.Drawing.Point(7, 562);
			this.buttonLaunch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonLaunch.Name = "buttonLaunch";
			this.buttonLaunch.Size = new System.Drawing.Size(314, 85);
			this.buttonLaunch.TabIndex = 0;
			this.buttonLaunch.Text = "LAUNCH";
			this.buttonLaunch.UseVisualStyleBackColor = false;
			this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
			// 
			// panelLauncherOptions
			// 
			this.panelLauncherOptions.BackColor = System.Drawing.Color.MediumAquamarine;
			this.panelLauncherOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelLauncherOptions.Controls.Add(this.groupBoxConfigCleanerMode);
			this.panelLauncherOptions.Controls.Add(this.groupBoxConfigLogMode);
			this.panelLauncherOptions.Controls.Add(this.groupBoxConfigLaunchMode);
			this.panelLauncherOptions.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelLauncherOptions.Enabled = false;
			this.panelLauncherOptions.Location = new System.Drawing.Point(1378, 90);
			this.panelLauncherOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panelLauncherOptions.Name = "panelLauncherOptions";
			this.panelLauncherOptions.Size = new System.Drawing.Size(310, 399);
			this.panelLauncherOptions.TabIndex = 2;
			// 
			// groupBoxConfigCleanerMode
			// 
			this.groupBoxConfigCleanerMode.BackColor = System.Drawing.Color.Transparent;
			this.groupBoxConfigCleanerMode.Controls.Add(this.checkBoxCleaner_soundPacks);
			this.groupBoxConfigCleanerMode.Controls.Add(this.checkBoxCleaner_textBIN);
			this.groupBoxConfigCleanerMode.Controls.Add(this.checkBoxCleaner_MapRWM);
			this.groupBoxConfigCleanerMode.Location = new System.Drawing.Point(4, 285);
			this.groupBoxConfigCleanerMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxConfigCleanerMode.Name = "groupBoxConfigCleanerMode";
			this.groupBoxConfigCleanerMode.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxConfigCleanerMode.Size = new System.Drawing.Size(300, 103);
			this.groupBoxConfigCleanerMode.TabIndex = 5;
			this.groupBoxConfigCleanerMode.TabStop = false;
			this.groupBoxConfigCleanerMode.Text = "Select mod clean routines";
			// 
			// checkBoxCleaner_soundPacks
			// 
			this.checkBoxCleaner_soundPacks.AutoSize = true;
			this.checkBoxCleaner_soundPacks.Location = new System.Drawing.Point(10, 75);
			this.checkBoxCleaner_soundPacks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.checkBoxCleaner_soundPacks.Name = "checkBoxCleaner_soundPacks";
			this.checkBoxCleaner_soundPacks.Size = new System.Drawing.Size(227, 19);
			this.checkBoxCleaner_soundPacks.TabIndex = 2;
			this.checkBoxCleaner_soundPacks.Text = "Delete sound pack files (*.DAT + *.IDX)";
			this.checkBoxCleaner_soundPacks.UseVisualStyleBackColor = true;
			// 
			// checkBoxCleaner_textBIN
			// 
			this.checkBoxCleaner_textBIN.AutoSize = true;
			this.checkBoxCleaner_textBIN.Location = new System.Drawing.Point(10, 48);
			this.checkBoxCleaner_textBIN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.checkBoxCleaner_textBIN.Name = "checkBoxCleaner_textBIN";
			this.checkBoxCleaner_textBIN.Size = new System.Drawing.Size(209, 19);
			this.checkBoxCleaner_textBIN.TabIndex = 1;
			this.checkBoxCleaner_textBIN.Text = "Delete localization *strings.bin files";
			this.checkBoxCleaner_textBIN.UseVisualStyleBackColor = true;
			// 
			// checkBoxCleaner_MapRWM
			// 
			this.checkBoxCleaner_MapRWM.AutoSize = true;
			this.checkBoxCleaner_MapRWM.Location = new System.Drawing.Point(10, 22);
			this.checkBoxCleaner_MapRWM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.checkBoxCleaner_MapRWM.Name = "checkBoxCleaner_MapRWM";
			this.checkBoxCleaner_MapRWM.Size = new System.Drawing.Size(132, 19);
			this.checkBoxCleaner_MapRWM.TabIndex = 0;
			this.checkBoxCleaner_MapRWM.Text = "Delete map.rwm file";
			this.checkBoxCleaner_MapRWM.UseVisualStyleBackColor = true;
			// 
			// groupBoxConfigLogMode
			// 
			this.groupBoxConfigLogMode.BackColor = System.Drawing.Color.Transparent;
			this.groupBoxConfigLogMode.Controls.Add(this.checkBoxLogHistory);
			this.groupBoxConfigLogMode.Controls.Add(this.radioButtonLogErrorAndTrace);
			this.groupBoxConfigLogMode.Controls.Add(this.radioButtonLogOnlyTrace);
			this.groupBoxConfigLogMode.Controls.Add(this.radioButtonLogOnlyError);
			this.groupBoxConfigLogMode.Location = new System.Drawing.Point(4, 143);
			this.groupBoxConfigLogMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxConfigLogMode.Name = "groupBoxConfigLogMode";
			this.groupBoxConfigLogMode.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxConfigLogMode.Size = new System.Drawing.Size(300, 136);
			this.groupBoxConfigLogMode.TabIndex = 1;
			this.groupBoxConfigLogMode.TabStop = false;
			this.groupBoxConfigLogMode.Text = "Select a mode of creating system.log file";
			// 
			// checkBoxLogHistory
			// 
			this.checkBoxLogHistory.AutoSize = true;
			this.checkBoxLogHistory.Checked = true;
			this.checkBoxLogHistory.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxLogHistory.Location = new System.Drawing.Point(10, 105);
			this.checkBoxLogHistory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.checkBoxLogHistory.Name = "checkBoxLogHistory";
			this.checkBoxLogHistory.Size = new System.Drawing.Size(167, 19);
			this.checkBoxLogHistory.TabIndex = 3;
			this.checkBoxLogHistory.Text = "Save game system.log files";
			this.checkBoxLogHistory.UseVisualStyleBackColor = true;
			// 
			// radioButtonLogErrorAndTrace
			// 
			this.radioButtonLogErrorAndTrace.AutoSize = true;
			this.radioButtonLogErrorAndTrace.Checked = true;
			this.radioButtonLogErrorAndTrace.Location = new System.Drawing.Point(10, 77);
			this.radioButtonLogErrorAndTrace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.radioButtonLogErrorAndTrace.Name = "radioButtonLogErrorAndTrace";
			this.radioButtonLogErrorAndTrace.Size = new System.Drawing.Size(96, 19);
			this.radioButtonLogErrorAndTrace.TabIndex = 2;
			this.radioButtonLogErrorAndTrace.TabStop = true;
			this.radioButtonLogErrorAndTrace.Text = "Errors + Trace";
			this.radioButtonLogErrorAndTrace.UseVisualStyleBackColor = true;
			// 
			// radioButtonLogOnlyTrace
			// 
			this.radioButtonLogOnlyTrace.AutoSize = true;
			this.radioButtonLogOnlyTrace.Location = new System.Drawing.Point(10, 50);
			this.radioButtonLogOnlyTrace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.radioButtonLogOnlyTrace.Name = "radioButtonLogOnlyTrace";
			this.radioButtonLogOnlyTrace.Size = new System.Drawing.Size(80, 19);
			this.radioButtonLogOnlyTrace.TabIndex = 1;
			this.radioButtonLogOnlyTrace.Text = "Only Trace";
			this.radioButtonLogOnlyTrace.UseVisualStyleBackColor = true;
			// 
			// radioButtonLogOnlyError
			// 
			this.radioButtonLogOnlyError.AutoSize = true;
			this.radioButtonLogOnlyError.Location = new System.Drawing.Point(10, 22);
			this.radioButtonLogOnlyError.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.radioButtonLogOnlyError.Name = "radioButtonLogOnlyError";
			this.radioButtonLogOnlyError.Size = new System.Drawing.Size(83, 19);
			this.radioButtonLogOnlyError.TabIndex = 0;
			this.radioButtonLogOnlyError.Text = "Only Errors";
			this.radioButtonLogOnlyError.UseVisualStyleBackColor = true;
			// 
			// groupBoxConfigLaunchMode
			// 
			this.groupBoxConfigLaunchMode.BackColor = System.Drawing.Color.Transparent;
			this.groupBoxConfigLaunchMode.Controls.Add(this.checkBoxBorderless);
			this.groupBoxConfigLaunchMode.Controls.Add(this.checkBoxVideo);
			this.groupBoxConfigLaunchMode.Controls.Add(this.radioButtonLaunchFullScreen);
			this.groupBoxConfigLaunchMode.Controls.Add(this.radioButtonLaunchWindowScreen);
			this.groupBoxConfigLaunchMode.Location = new System.Drawing.Point(4, 3);
			this.groupBoxConfigLaunchMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxConfigLaunchMode.Name = "groupBoxConfigLaunchMode";
			this.groupBoxConfigLaunchMode.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBoxConfigLaunchMode.Size = new System.Drawing.Size(300, 134);
			this.groupBoxConfigLaunchMode.TabIndex = 0;
			this.groupBoxConfigLaunchMode.TabStop = false;
			this.groupBoxConfigLaunchMode.Text = "Select game launch mode";
			// 
			// checkBoxBorderless
			// 
			this.checkBoxBorderless.AutoSize = true;
			this.checkBoxBorderless.Location = new System.Drawing.Point(10, 103);
			this.checkBoxBorderless.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.checkBoxBorderless.Name = "checkBoxBorderless";
			this.checkBoxBorderless.Size = new System.Drawing.Size(174, 19);
			this.checkBoxBorderless.TabIndex = 2;
			this.checkBoxBorderless.Text = "Borderless Windowed Mode";
			this.checkBoxBorderless.UseVisualStyleBackColor = true;
			// 
			// checkBoxVideo
			// 
			this.checkBoxVideo.AutoSize = true;
			this.checkBoxVideo.Location = new System.Drawing.Point(10, 77);
			this.checkBoxVideo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.checkBoxVideo.Name = "checkBoxVideo";
			this.checkBoxVideo.Size = new System.Drawing.Size(128, 19);
			this.checkBoxVideo.TabIndex = 0;
			this.checkBoxVideo.Text = "Enable Game Video";
			this.checkBoxVideo.UseVisualStyleBackColor = true;
			// 
			// radioButtonLaunchFullScreen
			// 
			this.radioButtonLaunchFullScreen.AutoSize = true;
			this.radioButtonLaunchFullScreen.Location = new System.Drawing.Point(10, 51);
			this.radioButtonLaunchFullScreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.radioButtonLaunchFullScreen.Name = "radioButtonLaunchFullScreen";
			this.radioButtonLaunchFullScreen.Size = new System.Drawing.Size(118, 19);
			this.radioButtonLaunchFullScreen.TabIndex = 1;
			this.radioButtonLaunchFullScreen.Text = "Full-Screen Mode";
			this.radioButtonLaunchFullScreen.UseVisualStyleBackColor = true;
			// 
			// radioButtonLaunchWindowScreen
			// 
			this.radioButtonLaunchWindowScreen.AutoSize = true;
			this.radioButtonLaunchWindowScreen.Checked = true;
			this.radioButtonLaunchWindowScreen.Location = new System.Drawing.Point(10, 24);
			this.radioButtonLaunchWindowScreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.radioButtonLaunchWindowScreen.Name = "radioButtonLaunchWindowScreen";
			this.radioButtonLaunchWindowScreen.Size = new System.Drawing.Size(116, 19);
			this.radioButtonLaunchWindowScreen.TabIndex = 0;
			this.radioButtonLaunchWindowScreen.TabStop = true;
			this.radioButtonLaunchWindowScreen.Text = "Windowed Mode";
			this.radioButtonLaunchWindowScreen.UseVisualStyleBackColor = true;
			// 
			// appColorThemeGroupBox
			// 
			this.appColorThemeGroupBox.BackColor = System.Drawing.Color.Transparent;
			this.appColorThemeGroupBox.Controls.Add(this.uiStyleByDarkThemeRadioButton);
			this.appColorThemeGroupBox.Controls.Add(this.uiStyleByLightThemeRadioButton);
			this.appColorThemeGroupBox.Controls.Add(this.uiStyleByDefaultThemeRadioButton);
			this.appColorThemeGroupBox.Location = new System.Drawing.Point(4, 102);
			this.appColorThemeGroupBox.Name = "appColorThemeGroupBox";
			this.appColorThemeGroupBox.Size = new System.Drawing.Size(301, 100);
			this.appColorThemeGroupBox.TabIndex = 14;
			this.appColorThemeGroupBox.TabStop = false;
			this.appColorThemeGroupBox.Text = "Select GUI style theme";
			// 
			// uiStyleByDarkThemeRadioButton
			// 
			this.uiStyleByDarkThemeRadioButton.AutoSize = true;
			this.uiStyleByDarkThemeRadioButton.Location = new System.Drawing.Point(12, 74);
			this.uiStyleByDarkThemeRadioButton.Name = "uiStyleByDarkThemeRadioButton";
			this.uiStyleByDarkThemeRadioButton.Size = new System.Drawing.Size(88, 19);
			this.uiStyleByDarkThemeRadioButton.TabIndex = 2;
			this.uiStyleByDarkThemeRadioButton.Text = "Dark Theme";
			this.uiStyleByDarkThemeRadioButton.UseVisualStyleBackColor = true;
			this.uiStyleByDarkThemeRadioButton.Click += new System.EventHandler(this.uiStyleByDarkThemeRadioButton_Click);
			// 
			// uiStyleByLightThemeRadioButton
			// 
			this.uiStyleByLightThemeRadioButton.AutoSize = true;
			this.uiStyleByLightThemeRadioButton.Location = new System.Drawing.Point(12, 49);
			this.uiStyleByLightThemeRadioButton.Name = "uiStyleByLightThemeRadioButton";
			this.uiStyleByLightThemeRadioButton.Size = new System.Drawing.Size(91, 19);
			this.uiStyleByLightThemeRadioButton.TabIndex = 1;
			this.uiStyleByLightThemeRadioButton.Text = "Light Theme";
			this.uiStyleByLightThemeRadioButton.UseVisualStyleBackColor = true;
			this.uiStyleByLightThemeRadioButton.Click += new System.EventHandler(this.uiStyleByLightThemeRadioButton_Click);
			// 
			// uiStyleByDefaultThemeRadioButton
			// 
			this.uiStyleByDefaultThemeRadioButton.AutoSize = true;
			this.uiStyleByDefaultThemeRadioButton.Checked = true;
			this.uiStyleByDefaultThemeRadioButton.Location = new System.Drawing.Point(12, 24);
			this.uiStyleByDefaultThemeRadioButton.Name = "uiStyleByDefaultThemeRadioButton";
			this.uiStyleByDefaultThemeRadioButton.Size = new System.Drawing.Size(175, 19);
			this.uiStyleByDefaultThemeRadioButton.TabIndex = 0;
			this.uiStyleByDefaultThemeRadioButton.TabStop = true;
			this.uiStyleByDefaultThemeRadioButton.Text = "Standard Theme (by default)";
			this.uiStyleByDefaultThemeRadioButton.UseVisualStyleBackColor = true;
			this.uiStyleByDefaultThemeRadioButton.Click += new System.EventHandler(this.uiStyleByDefaultThemeRadioButton_Click);
			// 
			// appLocalizationGroupBox
			// 
			this.appLocalizationGroupBox.BackColor = System.Drawing.Color.Transparent;
			this.appLocalizationGroupBox.Controls.Add(this.enableEngLocaleRadioButton);
			this.appLocalizationGroupBox.Controls.Add(this.enableRusLocaleRadioButton);
			this.appLocalizationGroupBox.Location = new System.Drawing.Point(4, 3);
			this.appLocalizationGroupBox.Name = "appLocalizationGroupBox";
			this.appLocalizationGroupBox.Size = new System.Drawing.Size(300, 93);
			this.appLocalizationGroupBox.TabIndex = 15;
			this.appLocalizationGroupBox.TabStop = false;
			this.appLocalizationGroupBox.Text = "Select GUI language";
			// 
			// enableEngLocaleRadioButton
			// 
			this.enableEngLocaleRadioButton.AutoSize = true;
			this.enableEngLocaleRadioButton.Checked = true;
			this.enableEngLocaleRadioButton.Location = new System.Drawing.Point(10, 22);
			this.enableEngLocaleRadioButton.Name = "enableEngLocaleRadioButton";
			this.enableEngLocaleRadioButton.Size = new System.Drawing.Size(136, 19);
			this.enableEngLocaleRadioButton.TabIndex = 1;
			this.enableEngLocaleRadioButton.TabStop = true;
			this.enableEngLocaleRadioButton.Text = "ENGLISH (by default)";
			this.enableEngLocaleRadioButton.UseVisualStyleBackColor = true;
			this.enableEngLocaleRadioButton.Click += new System.EventHandler(this.enableEngLocaleRadioButton_Click);
			// 
			// enableRusLocaleRadioButton
			// 
			this.enableRusLocaleRadioButton.AutoSize = true;
			this.enableRusLocaleRadioButton.Location = new System.Drawing.Point(10, 47);
			this.enableRusLocaleRadioButton.Name = "enableRusLocaleRadioButton";
			this.enableRusLocaleRadioButton.Size = new System.Drawing.Size(141, 19);
			this.enableRusLocaleRadioButton.TabIndex = 0;
			this.enableRusLocaleRadioButton.Text = "RUSSIAN (in progress)";
			this.enableRusLocaleRadioButton.UseVisualStyleBackColor = true;
			this.enableRusLocaleRadioButton.Click += new System.EventHandler(this.enableRusLocaleRadioButton_Click);
			// 
			// importGameSetupButton
			// 
			this.importGameSetupButton.BackColor = System.Drawing.Color.LightGreen;
			this.importGameSetupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.importGameSetupButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.importGameSetupButton.Location = new System.Drawing.Point(12, 12);
			this.importGameSetupButton.Name = "importGameSetupButton";
			this.importGameSetupButton.Size = new System.Drawing.Size(328, 68);
			this.importGameSetupButton.TabIndex = 11;
			this.importGameSetupButton.Text = "GAME SETUP SETTINGS";
			this.importGameSetupButton.UseVisualStyleBackColor = false;
			this.importGameSetupButton.Click += new System.EventHandler(this.importGameSetupButton_Click);
			// 
			// buttonExit
			// 
			this.buttonExit.BackColor = System.Drawing.Color.LightGreen;
			this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.buttonExit.Location = new System.Drawing.Point(4, 304);
			this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(300, 42);
			this.buttonExit.TabIndex = 3;
			this.buttonExit.Text = "EXIT";
			this.buttonExit.UseVisualStyleBackColor = false;
			this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
			// 
			// panelLauncherActions
			// 
			this.panelLauncherActions.BackColor = System.Drawing.Color.MediumAquamarine;
			this.panelLauncherActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelLauncherActions.Controls.Add(this.appColorThemeGroupBox);
			this.panelLauncherActions.Controls.Add(this.buttonShowHomeDirectory);
			this.panelLauncherActions.Controls.Add(this.appLocalizationGroupBox);
			this.panelLauncherActions.Controls.Add(this.buttonExit);
			this.panelLauncherActions.Controls.Add(this.buttonAboutProject);
			this.panelLauncherActions.Location = new System.Drawing.Point(1378, 498);
			this.panelLauncherActions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panelLauncherActions.Name = "panelLauncherActions";
			this.panelLauncherActions.Size = new System.Drawing.Size(310, 360);
			this.panelLauncherActions.TabIndex = 5;
			// 
			// buttonShowHomeDirectory
			// 
			this.buttonShowHomeDirectory.BackColor = System.Drawing.Color.LightGreen;
			this.buttonShowHomeDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonShowHomeDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.buttonShowHomeDirectory.Location = new System.Drawing.Point(4, 256);
			this.buttonShowHomeDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonShowHomeDirectory.Name = "buttonShowHomeDirectory";
			this.buttonShowHomeDirectory.Size = new System.Drawing.Size(300, 42);
			this.buttonShowHomeDirectory.TabIndex = 12;
			this.buttonShowHomeDirectory.Text = "APP HOME FOLDER";
			this.buttonShowHomeDirectory.UseVisualStyleBackColor = false;
			this.buttonShowHomeDirectory.Click += new System.EventHandler(this.buttonShowHomeDirectory_Click);
			// 
			// buttonAboutProject
			// 
			this.buttonAboutProject.BackColor = System.Drawing.Color.LightGreen;
			this.buttonAboutProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAboutProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.buttonAboutProject.Location = new System.Drawing.Point(4, 208);
			this.buttonAboutProject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.buttonAboutProject.Name = "buttonAboutProject";
			this.buttonAboutProject.Size = new System.Drawing.Size(300, 42);
			this.buttonAboutProject.TabIndex = 13;
			this.buttonAboutProject.Text = "ABOUT";
			this.buttonAboutProject.UseVisualStyleBackColor = false;
			this.buttonAboutProject.Click += new System.EventHandler(this.buttonAboutProject_Click);
			// 
			// buttonExplore
			// 
			this.buttonExplore.BackColor = System.Drawing.Color.LightGreen;
			this.buttonExplore.Enabled = false;
			this.buttonExplore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExplore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.buttonExplore.Location = new System.Drawing.Point(7, 707);
			this.buttonExplore.Name = "buttonExplore";
			this.buttonExplore.Size = new System.Drawing.Size(314, 52);
			this.buttonExplore.TabIndex = 8;
			this.buttonExplore.Text = "MOD HOME FOLDER";
			this.buttonExplore.UseVisualStyleBackColor = false;
			this.buttonExplore.Click += new System.EventHandler(this.buttonExplore_Click);
			// 
			// modQuickNavigationButton
			// 
			this.modQuickNavigationButton.BackColor = System.Drawing.Color.LightGreen;
			this.modQuickNavigationButton.Enabled = false;
			this.modQuickNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.modQuickNavigationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.modQuickNavigationButton.Location = new System.Drawing.Point(7, 653);
			this.modQuickNavigationButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.modQuickNavigationButton.Name = "modQuickNavigationButton";
			this.modQuickNavigationButton.Size = new System.Drawing.Size(314, 48);
			this.modQuickNavigationButton.TabIndex = 7;
			this.modQuickNavigationButton.Text = "MOD QUICK NAVIGATION";
			this.modQuickNavigationButton.UseVisualStyleBackColor = false;
			this.modQuickNavigationButton.Click += new System.EventHandler(this.modQuickNavigationButton_Click);
			// 
			// panelLauncherToolkit
			// 
			this.panelLauncherToolkit.BackColor = System.Drawing.Color.MediumAquamarine;
			this.panelLauncherToolkit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelLauncherToolkit.Controls.Add(this.modQuickNavigationButton);
			this.panelLauncherToolkit.Controls.Add(this.buttonExplore);
			this.panelLauncherToolkit.Controls.Add(this.buttonLaunch);
			this.panelLauncherToolkit.Controls.Add(this.listBoxMODS);
			this.panelLauncherToolkit.Location = new System.Drawing.Point(13, 90);
			this.panelLauncherToolkit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panelLauncherToolkit.Name = "panelLauncherToolkit";
			this.panelLauncherToolkit.Size = new System.Drawing.Size(327, 768);
			this.panelLauncherToolkit.TabIndex = 6;
			// 
			// listBoxMODS
			// 
			this.listBoxMODS.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.listBoxMODS.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listBoxMODS.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.listBoxMODS.ForeColor = System.Drawing.SystemColors.WindowText;
			this.listBoxMODS.FormattingEnabled = true;
			this.listBoxMODS.ItemHeight = 17;
			this.listBoxMODS.Location = new System.Drawing.Point(7, 3);
			this.listBoxMODS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.listBoxMODS.Name = "listBoxMODS";
			this.listBoxMODS.Size = new System.Drawing.Size(314, 548);
			this.listBoxMODS.TabIndex = 9;
			this.listBoxMODS.SelectedIndexChanged += new System.EventHandler(this.listBoxMODS_SelectedIndexChanged);
			// 
			// modMainTitleLabel
			// 
			this.modMainTitleLabel.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.modMainTitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.modMainTitleLabel.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.modMainTitleLabel.Location = new System.Drawing.Point(347, 12);
			this.modMainTitleLabel.Name = "modMainTitleLabel";
			this.modMainTitleLabel.Size = new System.Drawing.Size(1024, 68);
			this.modMainTitleLabel.TabIndex = 8;
			this.modMainTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// modLogoPictureBox
			// 
			this.modLogoPictureBox.Location = new System.Drawing.Point(347, 90);
			this.modLogoPictureBox.MaximumSize = new System.Drawing.Size(1024, 768);
			this.modLogoPictureBox.MinimumSize = new System.Drawing.Size(1024, 768);
			this.modLogoPictureBox.Name = "modLogoPictureBox";
			this.modLogoPictureBox.Size = new System.Drawing.Size(1024, 768);
			this.modLogoPictureBox.TabIndex = 9;
			this.modLogoPictureBox.TabStop = false;
			// 
			// aboutProjectNameLabel1
			// 
			this.aboutProjectNameLabel1.BackColor = System.Drawing.Color.Transparent;
			this.aboutProjectNameLabel1.Font = new System.Drawing.Font("Dungeon", 96F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.aboutProjectNameLabel1.ForeColor = System.Drawing.Color.LimeGreen;
			this.aboutProjectNameLabel1.Location = new System.Drawing.Point(26, 265);
			this.aboutProjectNameLabel1.Name = "aboutProjectNameLabel1";
			this.aboutProjectNameLabel1.Size = new System.Drawing.Size(973, 188);
			this.aboutProjectNameLabel1.TabIndex = 10;
			this.aboutProjectNameLabel1.Text = "OpenTWEMP";
			this.aboutProjectNameLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// aboutProjectNameLabel2
			// 
			this.aboutProjectNameLabel2.BackColor = System.Drawing.Color.Transparent;
			this.aboutProjectNameLabel2.Font = new System.Drawing.Font("Gadugi", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.aboutProjectNameLabel2.ForeColor = System.Drawing.Color.LemonChiffon;
			this.aboutProjectNameLabel2.Location = new System.Drawing.Point(205, 453);
			this.aboutProjectNameLabel2.Name = "aboutProjectNameLabel2";
			this.aboutProjectNameLabel2.Size = new System.Drawing.Size(649, 93);
			this.aboutProjectNameLabel2.TabIndex = 11;
			this.aboutProjectNameLabel2.Text = "Community Browser";
			// 
			// aboutProjectPanel
			// 
			this.aboutProjectPanel.BackColor = System.Drawing.Color.Black;
			this.aboutProjectPanel.Controls.Add(this.errorModLogotypeNotFoundLabel);
			this.aboutProjectPanel.Controls.Add(this.aboutProjectNameLabel1);
			this.aboutProjectPanel.Controls.Add(this.aboutProjectNameLabel2);
			this.aboutProjectPanel.Location = new System.Drawing.Point(347, 90);
			this.aboutProjectPanel.Name = "aboutProjectPanel";
			this.aboutProjectPanel.Size = new System.Drawing.Size(1024, 768);
			this.aboutProjectPanel.TabIndex = 12;
			// 
			// errorModLogotypeNotFoundLabel
			// 
			this.errorModLogotypeNotFoundLabel.BackColor = System.Drawing.Color.Transparent;
			this.errorModLogotypeNotFoundLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.errorModLogotypeNotFoundLabel.ForeColor = System.Drawing.Color.LightCoral;
			this.errorModLogotypeNotFoundLabel.Location = new System.Drawing.Point(3, 629);
			this.errorModLogotypeNotFoundLabel.Name = "errorModLogotypeNotFoundLabel";
			this.errorModLogotypeNotFoundLabel.Size = new System.Drawing.Size(1018, 114);
			this.errorModLogotypeNotFoundLabel.TabIndex = 12;
			this.errorModLogotypeNotFoundLabel.Text = "ERROR: Mod logotype image was not found. Probably, caching was finished with fail" +
    "ure.";
			this.errorModLogotypeNotFoundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.errorModLogotypeNotFoundLabel.Visible = false;
			// 
			// aboutProjectReleaseLabel
			// 
			this.aboutProjectReleaseLabel.BackColor = System.Drawing.Color.MediumAquamarine;
			this.aboutProjectReleaseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.aboutProjectReleaseLabel.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.aboutProjectReleaseLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.aboutProjectReleaseLabel.Location = new System.Drawing.Point(1378, 12);
			this.aboutProjectReleaseLabel.Name = "aboutProjectReleaseLabel";
			this.aboutProjectReleaseLabel.Size = new System.Drawing.Size(310, 68);
			this.aboutProjectReleaseLabel.TabIndex = 13;
			this.aboutProjectReleaseLabel.Text = "Version Preview 2023.1";
			this.aboutProjectReleaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// appStatusStrip
			// 
			this.appStatusStrip.Location = new System.Drawing.Point(0, 865);
			this.appStatusStrip.Name = "appStatusStrip";
			this.appStatusStrip.Size = new System.Drawing.Size(1701, 22);
			this.appStatusStrip.TabIndex = 13;
			this.appStatusStrip.Text = "statusStrip1";
			// 
			// MainLauncherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(1701, 887);
			this.Controls.Add(this.aboutProjectReleaseLabel);
			this.Controls.Add(this.appStatusStrip);
			this.Controls.Add(this.aboutProjectPanel);
			this.Controls.Add(this.modMainTitleLabel);
			this.Controls.Add(this.importGameSetupButton);
			this.Controls.Add(this.panelLauncherToolkit);
			this.Controls.Add(this.panelLauncherActions);
			this.Controls.Add(this.panelLauncherOptions);
			this.Controls.Add(this.modLogoPictureBox);
			this.DoubleBuffered = true;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(16, 698);
			this.Name = "MainLauncherForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OpenTWEMP Community Browser";
			this.panelLauncherOptions.ResumeLayout(false);
			this.groupBoxConfigCleanerMode.ResumeLayout(false);
			this.groupBoxConfigCleanerMode.PerformLayout();
			this.groupBoxConfigLogMode.ResumeLayout(false);
			this.groupBoxConfigLogMode.PerformLayout();
			this.groupBoxConfigLaunchMode.ResumeLayout(false);
			this.groupBoxConfigLaunchMode.PerformLayout();
			this.appColorThemeGroupBox.ResumeLayout(false);
			this.appColorThemeGroupBox.PerformLayout();
			this.appLocalizationGroupBox.ResumeLayout(false);
			this.appLocalizationGroupBox.PerformLayout();
			this.panelLauncherActions.ResumeLayout(false);
			this.panelLauncherToolkit.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.modLogoPictureBox)).EndInit();
			this.aboutProjectPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Panel panelLauncherActions;
		private System.Windows.Forms.Panel panelLauncherToolkit;
		private System.Windows.Forms.GroupBox groupBoxConfigCleanerMode;
		private System.Windows.Forms.CheckBox checkBoxCleaner_soundPacks;
		private System.Windows.Forms.CheckBox checkBoxCleaner_textBIN;
		private System.Windows.Forms.CheckBox checkBoxCleaner_MapRWM;
		private System.Windows.Forms.CheckBox checkBoxLogHistory;
		private System.Windows.Forms.CheckBox checkBoxBorderless;
		private System.Windows.Forms.Button modQuickNavigationButton;
		private System.Windows.Forms.Button importGameSetupButton;
		private System.Windows.Forms.Button buttonExplore;
		private System.Windows.Forms.Label modMainTitleLabel;
		private System.Windows.Forms.PictureBox modLogoPictureBox;
		private System.Windows.Forms.Button buttonShowHomeDirectory;
		private System.Windows.Forms.Button buttonAboutProject;
		private System.Windows.Forms.GroupBox appColorThemeGroupBox;
		private System.Windows.Forms.RadioButton uiStyleByDarkThemeRadioButton;
		private System.Windows.Forms.RadioButton uiStyleByLightThemeRadioButton;
		private System.Windows.Forms.RadioButton uiStyleByDefaultThemeRadioButton;
		private System.Windows.Forms.GroupBox appLocalizationGroupBox;
		private System.Windows.Forms.RadioButton enableEngLocaleRadioButton;
		private System.Windows.Forms.RadioButton enableRusLocaleRadioButton;
		private System.Windows.Forms.Label aboutProjectNameLabel1;
		private System.Windows.Forms.Label aboutProjectNameLabel2;
		private System.Windows.Forms.Panel aboutProjectPanel;
		private System.Windows.Forms.Label errorModLogotypeNotFoundLabel;
		private System.Windows.Forms.Label aboutProjectReleaseLabel;
		private System.Windows.Forms.ListBox listBoxMODS;
		private System.Windows.Forms.StatusStrip appStatusStrip;
	}
}