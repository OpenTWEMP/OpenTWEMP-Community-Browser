// <copyright file="IBrowserMessageProvider.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1602 // Enumeration items should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

public interface IBrowserMessageProvider
{
    public abstract void Show(string msgText, string msgCaption, BrowserMessageType msgType);
}

public enum BrowserMessageType
{
    Information,
    Warning,
    Error,
}
