// <copyright file="BrowserErrorMessage.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

public static class BrowserErrorMessage
{
    public static void ShowAboutDirectoryNotFound()
    {
        string msgText = "The specified directory is not found.";
        string msgCaption = "ERROR";
        MessageBoxButtons msgButtons = MessageBoxButtons.OK;
        MessageBoxIcon msgIcon = MessageBoxIcon.Error;

        MessageBox.Show(
            text: msgText,
            caption: msgCaption,
            buttons: msgButtons,
            icon: msgIcon);
    }
}
