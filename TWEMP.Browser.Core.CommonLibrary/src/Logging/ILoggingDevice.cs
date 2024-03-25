// <copyright file="ILoggingDevice.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.Logging;

/// <summary>
/// Defines the interface which should be implemented by any compatible device logging events.
/// </summary>
public interface ILoggingDevice
{
    /// <summary>
    /// Opens the logging device.
    /// </summary>
    public abstract void Open();

    /// <summary>
    /// Logs a <see cref="BrowserEventMessage"/> event message.
    /// </summary>
    /// <param name="eventMessage">An event message that should be logged by this device.</param>
    public abstract void LogEventMessage(BrowserEventMessage eventMessage);

    /// <summary>
    /// Closes the logging device.
    /// </summary>
    public abstract void Close();
}
