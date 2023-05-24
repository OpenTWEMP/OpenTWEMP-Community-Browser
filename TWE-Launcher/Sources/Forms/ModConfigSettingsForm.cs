using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TWE_Launcher.Forms
{
	public partial class ModConfigSettingsForm : Form
	{
		public ModConfigSettingsForm()
		{
			InitializeComponent();
		}

		private void saveConfigSettingsButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("SAVE CONFIG SETTINGS");
		}

		private void resetConfigSettingsButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("RESET CONFIG SETTINGS");
		}

		private void exitConfigSettingsButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void exportConfigSettingsButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("EXPORT CONFIG SETTINGS");
		}

		private void importConfigSettingsButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("IMPORT CONFIG SETTINGS");
		}
	}
}
