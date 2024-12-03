// <copyright file="BrowserKernel.API.CustomGameCollections.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Collections;

public static partial class BrowserKernel
{
    public static CustomModsCollection FavoriteModsCollection
    {
        get
        {
            return CustomGameCollectionsManagerInstance.FavoriteModsCollection;
        }
    }

    public static List<CustomModsCollection> UserCollections
    {
        get
        {
            return CustomGameCollectionsManagerInstance.UserCollections;
        }
    }

    public static void WriteExistingCollections()
    {
        CustomGameCollectionsManagerInstance.WriteExistingCollections();
    }

    public static void WriteFavoriteCollection()
    {
        CustomGameCollectionsManagerInstance.WriteFavoriteCollection();
    }
}
