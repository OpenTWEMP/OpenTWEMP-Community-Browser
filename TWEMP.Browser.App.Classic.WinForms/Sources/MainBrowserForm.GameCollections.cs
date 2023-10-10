// <copyright file="MainBrowserForm.GameCollections.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.App.Classic.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary;

internal partial class MainBrowserForm : IUpdatableBrowser
{
    public void CreateModsCollectionTreeView(CustomModsCollection collection)
    {
        TreeNode customCollectionsRootNode = treeViewGameMods.Nodes[1];
        TreeNode createdCollectionNode = customCollectionsRootNode.Nodes.Add(collection.Name);

        foreach (KeyValuePair<string, string> modification in collection.Modifications)
        {
            TreeNode modChildNode = CreateCollectionChildNode(modification.Value);
            createdCollectionNode.Nodes.Add(modChildNode);
        }
    }

    public void UpdateCustomCollectionsInTreeView()
    {
        TreeNode customCollectionsNode = treeViewGameMods.Nodes[1];
        customCollectionsNode.Nodes.Clear();

        foreach (CustomModsCollection collection in Settings.UserCollections)
        {
            CreateCollectionNodeWithChilds(collection, customCollectionsNode);
        }
    }

    private void CreateCollectionNodeWithChilds(CustomModsCollection collection, TreeNode collectionsParentNode)
    {
        var collectionNode = CreateCollectionParentNode(collection);

        foreach (KeyValuePair<string, string> modPair in collection.Modifications)
        {
            var modNode = CreateCollectionChildNode(modPair.Value);
            collectionNode.Nodes.Add(modNode);
        }

        collectionsParentNode.Nodes.Add(collectionNode);
    }

    private TreeNode CreateCollectionParentNode(CustomModsCollection collection)
    {
        return new TreeNode(collection.Name);
    }

    private TreeNode CreateCollectionChildNode(string childNodeText)
    {
        var childNode = new TreeNode(childNodeText);
        childNode.NodeFont = new Font("Segoe UI Historic", 10F, FontStyle.Regular, GraphicsUnit.Point);
        return childNode;
    }

    // MODS COLLECTIONS MANAGEMENT
    private void ButtonMarkFavoriteMod_Click(object sender, EventArgs e)
    {
        TreeNode modNode = treeViewGameMods.SelectedNode;
        GameModificationInfo selectedModInfo = FindModBySelectedNodeFromCollection(modNode);

        if (IsNodeOfModificationFromAllModsCollection(modNode) || IsNodeOfModificationFromCustomCollection(modNode))
        {
            if (selectedModInfo.IsFavoriteMod)
            {
                MessageBox.Show("This mod is already added to Favorite Mods!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                TreeNode favoriteModNode = CreateCollectionChildNode(selectedModInfo.ShortName);

                TreeNode allFavoriteModsNode = treeViewGameMods.Nodes[0];
                allFavoriteModsNode.Nodes.Add(favoriteModNode);

                selectedModInfo.IsFavoriteMod = true;
                Settings.FavoriteModsCollection.Modifications.Add(selectedModInfo.Location, selectedModInfo.ShortName);
                CustomModsCollection.WriteFavoriteCollection();

                MessageBox.Show("This mod was successfully ADDED to Favorite Mods!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        if (IsNodeOfFavoriteCollection(modNode))
        {
            TreeNode favoriteModsNode = treeViewGameMods.Nodes[0];

            foreach (TreeNode node in favoriteModsNode.Nodes)
            {
                if (node.Text.Equals(modNode.Text))
                {
                    favoriteModsNode.Nodes.Remove(node);

                    selectedModInfo.IsFavoriteMod = false;
                    Settings.FavoriteModsCollection.Modifications.Remove(selectedModInfo.Location);
                    CustomModsCollection.WriteFavoriteCollection();

                    MessageBox.Show("This mod was successfully REMOVED from Favorite Mods!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
        }
    }

    private void ButtonCollectionCreate_Click(object sender, EventArgs e)
    {
        var collectionCreateForm = new CollectionCreateForm(this);
        collectionCreateForm.Show();
    }

    private void ButtonCollectionManage_Click(object sender, EventArgs e)
    {
        var collectionManageForm = new CollectionManageForm(this);
        collectionManageForm.Show();
    }
}
