using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TWE_Launcher.Models;

namespace TWE_Launcher.Forms
{
	public partial class CollectionCreateForm : Form
	{
		private MainLauncherForm currentCallingForm;

		public CollectionCreateForm(MainLauncherForm callingForm)
		{
			InitializeComponent();

			currentCallingForm = callingForm;
			collectionNameTextBox.Text = "My New Collection";

			foreach (GameModificationInfo mod in Settings.TotalModificationsList)
			{
				modsSelectionCheckedListBox.Items.Add(mod.ShortName);
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			var namesOfSelectedMods = new List<string>();

			for (int i = 0; i < modsSelectionCheckedListBox.CheckedIndices.Count; i++)
			{
				namesOfSelectedMods.Add(modsSelectionCheckedListBox.CheckedItems[i].ToString());
			}

			currentCallingForm.CreateModsCollection(collectionNameTextBox.Text, namesOfSelectedMods);
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
