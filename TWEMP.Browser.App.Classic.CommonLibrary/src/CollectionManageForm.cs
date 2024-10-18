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
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class CollectionManageForm : Form, ICanChangeMyLocalization
{
    private readonly IUpdatableBrowser currentBrowser;

    public CollectionManageForm(IUpdatableBrowser browser)
    {
        InitializeComponent();

        SetupCurrentLocalizationForGUIControls();

        currentBrowser = browser;

        foreach (CustomModsCollection mod in BrowserKernel.UserCollections)
        {
            collectionsCheckedListBox.Items.Add(mod.Name);
        }
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        Text = GetTextInCurrentLocalization(Name, Name);
        groupBoxCollectionsDelete.Text = GetTextInCurrentLocalization(Name, groupBoxCollectionsDelete.Name);
        collectionsSelectionLabel.Text = GetTextInCurrentLocalization(Name, collectionsSelectionLabel.Name);
        buttonCollectionsDelete.Text = GetTextInCurrentLocalization(Name, buttonCollectionsDelete.Name);
        buttonCollectionsSelectAll.Text = GetTextInCurrentLocalization(Name, buttonCollectionsSelectAll.Name);
        buttonCollectionsDeselectAll.Text = GetTextInCurrentLocalization(Name, buttonCollectionsDeselectAll.Name);
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
            CustomModsCollection selectedCollection = BrowserKernel.UserCollections.Find(collection => collection.Name == selectedCollectionName)!;
            BrowserKernel.UserCollections.Remove(selectedCollection);
        }

        BrowserKernel.WriteExistingCollections();
        currentBrowser.UpdateCustomCollectionsInTreeView();
        Close();
    }
}
