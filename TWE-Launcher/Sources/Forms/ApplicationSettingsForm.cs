using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TWE_Launcher.Sources.Forms
{
	public partial class ApplicationSettingsForm : Form
	{
		public ApplicationSettingsForm()
		{
			InitializeComponent();
		}

		private void saveAppSettingsButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("SAVE APP SETTINGS");
		}

		private void exitAppSettingsButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
