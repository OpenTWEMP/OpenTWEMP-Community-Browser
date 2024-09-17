// <copyright file="IBrowserMessageProvider.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.Messaging;

public interface IBrowserMessageProvider
{
    public abstract void Show(string msgText, string msgCaption, BrowserMessageType msgType);
}
