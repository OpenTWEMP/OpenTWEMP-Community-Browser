// <copyright file="CollectionManageForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;

public partial class CollectionManageForm : Form, ICanChangeMyLocalization
{
    private readonly IUpdatableBrowser currentBrowser;

    public CollectionManageForm(IUpdatableBrowser browser)
    {
        InitializeComponent();

        SetupCurrentLocalizationForGUIControls();

        currentBrowser = browser;

        foreach (CustomModsCollection mod in Settings.UserCollections)
        {
            collectionsCheckedListBox.Items.Add(mod.Name);
        }
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        FormLocaleSnapshot snapshot = Settings.CurrentLocalization.GetFormLocaleSnapshotByKey(Name);

        Text = snapshot.GetLocalizedValueByKey(Name);
        groupBoxCollectionsDelete.Text = snapshot.GetLocalizedValueByKey(groupBoxCollectionsDelete.Name);
        collectionsSelectionLabel.Text = snapshot.GetLocalizedValueByKey(collectionsSelectionLabel.Name);
        buttonCollectionsDelete.Text = snapshot.GetLocalizedValueByKey(buttonCollectionsDelete.Name);
        buttonCollectionsSelectAll.Text = snapshot.GetLocalizedValueByKey(buttonCollectionsSelectAll.Name);
        buttonCollectionsDeselectAll.Text = snapshot.GetLocalizedValueByKey(buttonCollectionsDeselectAll.Name);
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
