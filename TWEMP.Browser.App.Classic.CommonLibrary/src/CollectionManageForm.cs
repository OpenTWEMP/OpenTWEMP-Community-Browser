// <copyright file="CollectionManageForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class CollectionManageForm : Form, ICanChangeMyLocalization
{
    private readonly IUpdatableBrowser currentBrowser;

    public CollectionManageForm(IUpdatableBrowser browser)
    {
        this.InitializeComponent();

        this.SetupCurrentLocalizationForGUIControls();

        this.currentBrowser = browser;

        foreach (CustomModsCollection mod in BrowserKernel.UserCollections)
        {
            this.collectionsCheckedListBox.Items.Add(mod.Name);
        }
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        this.Text = GetTextInCurrentLocalization(this.Name, this.Name);
        this.groupBoxCollectionsDelete.Text = GetTextInCurrentLocalization(this.Name, this.groupBoxCollectionsDelete.Name);
        this.collectionsSelectionLabel.Text = GetTextInCurrentLocalization(this.Name, this.collectionsSelectionLabel.Name);
        this.buttonCollectionsDelete.Text = GetTextInCurrentLocalization(this.Name, this.buttonCollectionsDelete.Name);
        this.buttonCollectionsSelectAll.Text = GetTextInCurrentLocalization(this.Name, this.buttonCollectionsSelectAll.Name);
        this.buttonCollectionsDeselectAll.Text = GetTextInCurrentLocalization(this.Name, this.buttonCollectionsDeselectAll.Name);
    }

    private void ButtonOK_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void ButtonCollectionsSelectAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.collectionsCheckedListBox.Items.Count; i++)
        {
            this.collectionsCheckedListBox.SetItemChecked(i, true);
        }
    }

    private void ButtonCollectionsDeselectAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.collectionsCheckedListBox.Items.Count; i++)
        {
            this.collectionsCheckedListBox.SetItemChecked(i, false);
        }
    }

    private void ButtonCollectionsDelete_Click(object sender, EventArgs e)
    {
        var selectedCollections = new List<string>();

        for (int i = 0; i < this.collectionsCheckedListBox.CheckedIndices.Count; i++)
        {
            string selectedCollectionName = this.collectionsCheckedListBox.CheckedItems[i] !.ToString() !;
            CustomModsCollection selectedCollection = BrowserKernel.UserCollections.Find(collection => collection.Name == selectedCollectionName) !;
            BrowserKernel.UserCollections.Remove(selectedCollection);
        }

        BrowserKernel.WriteExistingCollections();
        this.currentBrowser.UpdateCustomCollectionsInTreeView();
        this.Close();
    }
}
