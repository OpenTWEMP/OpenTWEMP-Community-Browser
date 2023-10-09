namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;

public partial class CollectionManageForm : Form
{
	private readonly IUpdatableBrowser currentBrowser;

	public CollectionManageForm(IUpdatableBrowser browser)
	{
		InitializeComponent();

		currentBrowser = browser;

		foreach (CustomModsCollection mod in Settings.UserCollections)
		{
			collectionsCheckedListBox.Items.Add(mod.Name);
		}
	}

	private void ButtonOK_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void ButtonCollectionsSelectAll_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < collectionsCheckedListBox.Items.Count; i++)
		{
			collectionsCheckedListBox.SetItemChecked(i, true);
		}
	}

	private void ButtonCollectionsDeselectAll_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < collectionsCheckedListBox.Items.Count; i++)
		{
			collectionsCheckedListBox.SetItemChecked(i, false);
		}
	}

	private void ButtonCollectionsDelete_Click(object sender, EventArgs e)
	{
		var selectedCollections = new List<string>();

		for (int i = 0; i < collectionsCheckedListBox.CheckedIndices.Count; i++)
		{
			string selectedCollectionName = collectionsCheckedListBox.CheckedItems[i]!.ToString()!;
			CustomModsCollection selectedCollection = Settings.UserCollections.Find(collection => collection.Name == selectedCollectionName)!;
			Settings.UserCollections.Remove(selectedCollection);
		}

		CustomModsCollection.WriteExistingCollections(Settings.UserCollections);
		currentBrowser.UpdateCustomCollectionsInTreeView();
		Close();
	}
}
