// <copyright file="BrowserMessageProvider.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.App.Classic.CommonLibrary;

using TWEMP.Browser.Core.CommonLibrary.Messaging;

public class BrowserMessageProvider : IBrowserMessageProvider
{
    static BrowserMessageProvider()
    {
        if (CurrentProvider is null)
        {
            CurrentProvider = new BrowserMessageProvider();
        }
    }

    private BrowserMessageProvider()
    {
    }

    public static BrowserMessageProvider CurrentProvider { get; }

    public void Show(string msgText, string msgCaption, BrowserMessageType msgType)
    {
        MessageBoxButtons msgButtons;
        MessageBoxIcon msgIcon;

        switch (msgType)
        {
            case BrowserMessageType.Information:
                msgButtons = MessageBoxButtons.OK;
                msgIcon = MessageBoxIcon.Information;
                break;
            case BrowserMessageType.Warning:
                msgButtons = MessageBoxButtons.OK;
                msgIcon = MessageBoxIcon.Warning;
                break;
            case BrowserMessageType.Error:
                msgButtons = MessageBoxButtons.OK;
                msgIcon = MessageBoxIcon.Error;
                break;
            default:
                msgButtons = MessageBoxButtons.OK;
                msgIcon = MessageBoxIcon.Asterisk;
                break;
        }

        MessageBox.Show(
            text: msgText,
            caption: msgCaption,
            buttons: msgButtons,
            icon: msgIcon);
    }
}
