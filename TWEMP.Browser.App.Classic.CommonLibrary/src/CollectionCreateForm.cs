﻿// <copyright file="CollectionCreateForm.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary;

public partial class CollectionCreateForm : Form, ICanChangeMyLocalization
{
    private readonly IUpdatableBrowser currentBrowser;

    public CollectionCreateForm(IUpdatableBrowser browser)
    {
        InitializeComponent();

        SetupCurrentLocalizationForGUIControls();

        currentBrowser = browser;
        collectionNameTextBox.Text = "My New Collection";

        foreach (GameModificationInfo mod in Settings.TotalModificationsList)
        {
            modsSelectionCheckedListBox.Items.Add(mod.ShortName);
        }
    }

    public void SetupCurrentLocalizationForGUIControls()
    {
        FormLocaleSnapshot snapshot = Settings.CurrentLocalization.GetFormLocaleSnapshotByKey(Name);

        Text = snapshot.GetLocalizedValueByKey(Name);
        collectionNameLabel.Text = snapshot.GetLocalizedValueByKey(collectionNameLabel.Name);
        modsSelectionLabel.Text = snapshot.GetLocalizedValueByKey(modsSelectionLabel.Name);
        buttonOK.Text = snapshot.GetLocalizedValueByKey(buttonOK.Name);
        buttonCancel.Text = snapshot.GetLocalizedValueByKey(buttonCancel.Name);
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
        foreach (CustomModsCollection existingCollection in Settings.UserCollections)
        {
            if (existingCollection.Name.Equals(collectionNameTextBox.Text))
            {
                return true;
            }
        }

        return false;
    }

    private void ButtonOK_Click(object sender, EventArgs e)
    {
        if (modsSelectionCheckedListBox.CheckedIndices.Count == 0)
        {
            ShowMessageAboutEmptyCollectionCreation();
        }
        else if (IsCollectionAlreadyExist())
        {
            ShowMessageAboutExistingCollectionCreation();
        }
        else
        {
            var selectedModifications = new Dictionary<string, string>();

            for (int i = 0; i < modsSelectionCheckedListBox.CheckedIndices.Count; i++)
            {
                string selectedModName = modsSelectionCheckedListBox.CheckedItems[i]!.ToString()!;
                GameModificationInfo selecteModInfo = Settings.GetActiveModificationInfo(selectedModName);
                selectedModifications.Add(selecteModInfo.Location, selecteModInfo.ShortName);
            }

            var collection = new CustomModsCollection(collectionNameTextBox.Text, selectedModifications);
            Settings.UserCollections.Add(collection);
            CustomModsCollection.WriteExistingCollections(Settings.UserCollections);

            currentBrowser.CreateModsCollectionTreeView(collection);

            ShowMessageAboutSuccessfulCollectionCreation(collectionNameTextBox.Text);
            Close();
        }
    }

    private void ButtonCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}
