namespace TWE_Save_Package
{
	partial class SavePackageForm
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
			this.buttonResulter = new System.Windows.Forms.Button();
			this.buttonCreator = new System.Windows.Forms.Button();
			this.labelInfo = new System.Windows.Forms.Label();
			this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
			this.labelMessage = new System.Windows.Forms.Label();
			this.comboBoxFactions = new System.Windows.Forms.ComboBox();
			this.labelFaction = new System.Windows.Forms.Label();
			this.comboBoxUsers = new System.Windows.Forms.ComboBox();
			this.labelUser = new System.Windows.Forms.Label();
			this.labelTooltips = new System.Windows.Forms.Label();
			this.listBoxSaves = new System.Windows.Forms.ListBox();
			this.groupBoxOptions = new System.Windows.Forms.GroupBox();
			this.labelVersion = new System.Windows.Forms.Label();
			this.comboBoxVersion = new System.Windows.Forms.ComboBox();
			this.labelTurnNumber = new System.Windows.Forms.Label();
			this.numericUpDownTurnNumber = new System.Windows.Forms.NumericUpDown();
			this.groupBoxSaves = new System.Windows.Forms.GroupBox();
			this.groupBoxOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTurnNumber)).BeginInit();
			this.groupBoxSaves.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonResulter
			// 
			this.buttonResulter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonResulter.Location = new System.Drawing.Point(618, 354);
			this.buttonResulter.Name = "buttonResulter";
			this.buttonResulter.Size = new System.Drawing.Size(354, 50);
			this.buttonResulter.TabIndex = 1;
			this.buttonResulter.Text = "Перейти в каталог сохранений";
			this.buttonResulter.UseVisualStyleBackColor = true;
			this.buttonResulter.Click += new System.EventHandler(this.ButtonResulter_Click);
			// 
			// buttonCreator
			// 
			this.buttonCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonCreator.Location = new System.Drawing.Point(12, 354);
			this.buttonCreator.Name = "buttonCreator";
			this.buttonCreator.Size = new System.Drawing.Size(600, 50);
			this.buttonCreator.TabIndex = 0;
			this.buttonCreator.Text = "Создать пакет сохранения";
			this.buttonCreator.UseVisualStyleBackColor = true;
			this.buttonCreator.Click += new System.EventHandler(this.ButtonCreator_Click);
			// 
			// labelInfo
			// 
			this.labelInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.labelInfo.Location = new System.Drawing.Point(6, 25);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(588, 77);
			this.labelInfo.TabIndex = 2;
			this.labelInfo.Text = "Выбранный файл сохранения ...";
			this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// richTextBoxMessage
			// 
			this.richTextBoxMessage.Location = new System.Drawing.Point(6, 112);
			this.richTextBoxMessage.Name = "richTextBoxMessage";
			this.richTextBoxMessage.Size = new System.Drawing.Size(342, 218);
			this.richTextBoxMessage.TabIndex = 6;
			this.richTextBoxMessage.Text = "Разместите текст комментария ...";
			// 
			// labelMessage
			// 
			this.labelMessage.AutoSize = true;
			this.labelMessage.Location = new System.Drawing.Point(6, 96);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(77, 13);
			this.labelMessage.TabIndex = 4;
			this.labelMessage.Text = "Комментарий";
			// 
			// comboBoxFactions
			// 
			this.comboBoxFactions.FormattingEnabled = true;
			this.comboBoxFactions.Items.AddRange(new object[] {});
			this.comboBoxFactions.Location = new System.Drawing.Point(6, 72);
			this.comboBoxFactions.Name = "comboBoxFactions";
			this.comboBoxFactions.Size = new System.Drawing.Size(236, 21);
			this.comboBoxFactions.TabIndex = 3;
			this.comboBoxFactions.Text = "указать название фракции ...";
			// 
			// labelFaction
			// 
			this.labelFaction.AutoSize = true;
			this.labelFaction.Location = new System.Drawing.Point(6, 56);
			this.labelFaction.Name = "labelFaction";
			this.labelFaction.Size = new System.Drawing.Size(54, 13);
			this.labelFaction.TabIndex = 2;
			this.labelFaction.Text = "Фракция";
			// 
			// comboBoxUsers
			// 
			this.comboBoxUsers.FormattingEnabled = true;
			this.comboBoxUsers.Items.AddRange(new object[] {});
			this.comboBoxUsers.Location = new System.Drawing.Point(6, 32);
			this.comboBoxUsers.Name = "comboBoxUsers";
			this.comboBoxUsers.Size = new System.Drawing.Size(236, 21);
			this.comboBoxUsers.TabIndex = 1;
			this.comboBoxUsers.Text = "указать Ваш никнейм ...";
			// 
			// labelUser
			// 
			this.labelUser.AutoSize = true;
			this.labelUser.Location = new System.Drawing.Point(6, 16);
			this.labelUser.Name = "labelUser";
			this.labelUser.Size = new System.Drawing.Size(80, 13);
			this.labelUser.TabIndex = 0;
			this.labelUser.Text = "Пользователь";
			// 
			// labelTooltips
			// 
			this.labelTooltips.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.labelTooltips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelTooltips.Location = new System.Drawing.Point(12, 407);
			this.labelTooltips.Name = "labelTooltips";
			this.labelTooltips.Size = new System.Drawing.Size(960, 45);
			this.labelTooltips.TabIndex = 3;
			this.labelTooltips.Text = "Подсказки для пользователя";
			this.labelTooltips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// listBoxSaves
			// 
			this.listBoxSaves.FormattingEnabled = true;
			this.listBoxSaves.Location = new System.Drawing.Point(6, 105);
			this.listBoxSaves.Name = "listBoxSaves";
			this.listBoxSaves.Size = new System.Drawing.Size(588, 225);
			this.listBoxSaves.TabIndex = 7;
			// 
			// groupBoxOptions
			// 
			this.groupBoxOptions.Controls.Add(this.labelVersion);
			this.groupBoxOptions.Controls.Add(this.comboBoxVersion);
			this.groupBoxOptions.Controls.Add(this.labelTurnNumber);
			this.groupBoxOptions.Controls.Add(this.numericUpDownTurnNumber);
			this.groupBoxOptions.Controls.Add(this.richTextBoxMessage);
			this.groupBoxOptions.Controls.Add(this.labelUser);
			this.groupBoxOptions.Controls.Add(this.labelMessage);
			this.groupBoxOptions.Controls.Add(this.comboBoxUsers);
			this.groupBoxOptions.Controls.Add(this.comboBoxFactions);
			this.groupBoxOptions.Controls.Add(this.labelFaction);
			this.groupBoxOptions.Location = new System.Drawing.Point(618, 12);
			this.groupBoxOptions.Name = "groupBoxOptions";
			this.groupBoxOptions.Size = new System.Drawing.Size(354, 336);
			this.groupBoxOptions.TabIndex = 9;
			this.groupBoxOptions.TabStop = false;
			this.groupBoxOptions.Text = "Дополнительная информация";
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(245, 16);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(75, 13);
			this.labelVersion.TabIndex = 10;
			this.labelVersion.Text = "Версия патча";
			// 
			// comboBoxVersion
			// 
			this.comboBoxVersion.FormattingEnabled = true;
			this.comboBoxVersion.Items.AddRange(new object[] {});
			this.comboBoxVersion.Location = new System.Drawing.Point(248, 32);
			this.comboBoxVersion.Name = "comboBoxVersion";
			this.comboBoxVersion.Size = new System.Drawing.Size(100, 21);
			this.comboBoxVersion.TabIndex = 9;
			this.comboBoxVersion.Text = "версия";
			// 
			// labelTurnNumber
			// 
			this.labelTurnNumber.AutoSize = true;
			this.labelTurnNumber.Location = new System.Drawing.Point(245, 56);
			this.labelTurnNumber.Name = "labelTurnNumber";
			this.labelTurnNumber.Size = new System.Drawing.Size(67, 13);
			this.labelTurnNumber.TabIndex = 8;
			this.labelTurnNumber.Text = "Номер хода";
			// 
			// numericUpDownTurnNumber
			// 
			this.numericUpDownTurnNumber.Location = new System.Drawing.Point(248, 72);
			this.numericUpDownTurnNumber.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			this.numericUpDownTurnNumber.Name = "numericUpDownTurnNumber";
			this.numericUpDownTurnNumber.Size = new System.Drawing.Size(100, 20);
			this.numericUpDownTurnNumber.TabIndex = 7;
			this.numericUpDownTurnNumber.Value = new decimal(new int[] {
			100,
			0,
			0,
			0});
			// 
			// groupBoxSaves
			// 
			this.groupBoxSaves.Controls.Add(this.labelInfo);
			this.groupBoxSaves.Controls.Add(this.listBoxSaves);
			this.groupBoxSaves.Location = new System.Drawing.Point(12, 12);
			this.groupBoxSaves.Name = "groupBoxSaves";
			this.groupBoxSaves.Size = new System.Drawing.Size(600, 336);
			this.groupBoxSaves.TabIndex = 8;
			this.groupBoxSaves.TabStop = false;
			this.groupBoxSaves.Text = "Выбор файла сохранения для создания архива";
			// 
			// FormApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 461);
			this.Controls.Add(this.buttonCreator);
			this.Controls.Add(this.buttonResulter);
			this.Controls.Add(this.groupBoxSaves);
			this.Controls.Add(this.groupBoxOptions);
			this.Controls.Add(this.labelTooltips);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1000, 500);
			this.MinimumSize = new System.Drawing.Size(1000, 500);
			this.Name = "FormApp";
			this.Text = "Save Package Form";
			this.groupBoxOptions.ResumeLayout(false);
			this.groupBoxOptions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTurnNumber)).EndInit();
			this.groupBoxSaves.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button buttonResulter;
		private System.Windows.Forms.Button buttonCreator;
		private System.Windows.Forms.Label labelInfo;
		private System.Windows.Forms.RichTextBox richTextBoxMessage;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.ComboBox comboBoxFactions;
		private System.Windows.Forms.Label labelFaction;
		private System.Windows.Forms.ComboBox comboBoxUsers;
		private System.Windows.Forms.Label labelUser;
		private System.Windows.Forms.Label labelTooltips;
		private System.Windows.Forms.ListBox listBoxSaves;
		private System.Windows.Forms.GroupBox groupBoxOptions;
		private System.Windows.Forms.GroupBox groupBoxSaves;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.ComboBox comboBoxVersion;
		private System.Windows.Forms.Label labelTurnNumber;
		private System.Windows.Forms.NumericUpDown numericUpDownTurnNumber;
	}
}