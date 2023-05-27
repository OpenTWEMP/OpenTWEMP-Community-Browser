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
	public partial class CollectionManageForm : Form
	{
		private MainLauncherForm currentCallingForm;

		public CollectionManageForm(MainLauncherForm callingForm)
		{
			InitializeComponent();

			currentCallingForm = callingForm;

			foreach (CustomModsCollection mod in Settings.UserCollections)
			{
				collectionsCheckedListBox.Items.Add(mod.Name);
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonCollectionsSelectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < collectionsCheckedListBox.Items.Count; i++)
			{
				collectionsCheckedListBox.SetItemChecked(i, true);
			}
		}

		private void buttonCollectionsDeselectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < collectionsCheckedListBox.Items.Count; i++)
			{
				collectionsCheckedListBox.SetItemChecked(i, false);
			}
		}

		private void buttonCollectionsDelete_Click(object sender, EventArgs e)
		{
			var selectedCollections = new List<string>();

			for (int i = 0; i < collectionsCheckedListBox.CheckedIndices.Count; i++)
			{
				string selectedCollectionName = collectionsCheckedListBox.CheckedItems[i].ToString();
				CustomModsCollection selectedCollection = Settings.UserCollections.Find(collection => collection.Name == selectedCollectionName);
				Settings.UserCollections.Remove(selectedCollection);
			}

			CustomModsCollection.WriteExistingCollections(Settings.UserCollections);
			currentCallingForm.UpdateCustomCollectionsInTreeView();
			Close();
		}
	}
}
