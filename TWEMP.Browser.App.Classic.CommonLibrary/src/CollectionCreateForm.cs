// <copyright file="CollectionCreateForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.AppGuiAbstractions;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Localization;
using static TWEMP.Browser.Core.CommonLibrary.BrowserKernel;

public partial class CollectionCreateForm : Form, ICanChangeMyLocalization
{
    private readonly IUpdatableBrowser currentBrowser;

    public CollectionCreateForm(IUpdatableBrowser browser)
    {
        this.InitializeComponent();

        this.SetupCurrentLocalizationForGUIControls();

        this.currentBrowser = browser;
        this.collectionNameTextBox.Text = "My New Collection";

        foreach (GameModificationInfo mod in BrowserKernel.TotalModificationsList)
        {
            this.modsSelectionCheckedListBox.Items.Add(mod.ShortName);
        }
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        this.Text = GetTextInCurrentLocalization(this.Name, this.Name);
        this.collectionNameLabel.Text = GetTextInCurrentLocalization(this.Name, this.collectionNameLabel.Name);
        this.modsSelectionLabel.Text = GetTextInCurrentLocalization(this.Name, this.modsSelectionLabel.Name);
        this.buttonOK.Text = GetTextInCurrentLocalization(this.Name, this.buttonOK.Name);
        this.buttonCancel.Text = GetTextInCurrentLocalization(this.Name, this.buttonCancel.Name);
    }

    private static void ShowMessageAboutEmptyCollectionCreation()
    {
        const string msgText = "Cannot create an empty collection.";
        const string msgCaption = "WARNING: Empty Collection";
        const MessageBoxButtons buttons = MessageBoxButtons.OK;
        const MessageBoxIcon icon = MessageBoxIcon.Warning;

        MessageBox.Show(msgText, msgCaption, buttons, icon);
    }

    private static void ShowMessageAboutExistingCollectionCreation()
    {
        const string msgText = "Cannot create collection with an existing name.";
        const string msgCaption = "WARNING: Existing Collection Name";
        const MessageBoxButtons buttons = MessageBoxButtons.OK;
        const MessageBoxIcon icon = MessageBoxIcon.Warning;

        MessageBox.Show(msgText, msgCaption, buttons, icon);
    }

    private static void ShowMessageAboutSuccessfulCollectionCreation(string createdCollectionName)
    {
        string msgText = "Collection " + createdCollectionName + " is created and ready to use!";
        const string msgCaption = "SUCCESS: Successful Creating a New Collection";
        const MessageBoxButtons buttons = MessageBoxButtons.OK;
        const MessageBoxIcon icon = MessageBoxIcon.Information;

        MessageBox.Show(msgText, msgCaption, buttons, icon);
    }

    private bool IsCollectionAlreadyExist()
    {
        foreach (CustomModsCollection existingCollection in BrowserKernel.UserCollections)
        {
            if (existingCollection.Name.Equals(this.collectionNameTextBox.Text))
            {
                return true;
            }
        }

        return false;
    }

    private void ButtonOK_Click(object sender, EventArgs e)
    {
        if (this.modsSelectionCheckedListBox.CheckedIndices.Count == 0)
        {
            ShowMessageAboutEmptyCollectionCreation();
        }
        else if (this.IsCollectionAlreadyExist())
        {
            ShowMessageAboutExistingCollectionCreation();
        }
        else
        {
            var selectedModifications = new Dictionary<string, string>();

            for (int i = 0; i < this.modsSelectionCheckedListBox.CheckedIndices.Count; i++)
            {
                string selectedModName = this.modsSelectionCheckedListBox.CheckedItems[i]!.ToString()!;
                GameModificationInfo selecteModInfo = BrowserKernel.GetActiveModificationInfo(selectedModName);
                selectedModifications.Add(selecteModInfo.Location, selecteModInfo.ShortName);
            }

            var collection = new CustomModsCollection(this.collectionNameTextBox.Text, selectedModifications);
            BrowserKernel.UserCollections.Add(collection);
            BrowserKernel.WriteExistingCollections();

            this.currentBrowser.CreateModsCollectionTreeView(collection);

            ShowMessageAboutSuccessfulCollectionCreation(this.collectionNameTextBox.Text);
            this.Close();
        }
    }

    private void ButtonCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
