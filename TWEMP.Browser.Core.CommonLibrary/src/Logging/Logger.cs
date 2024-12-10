// <copyright file="Logger.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.Logging;

/// <summary>
/// Represents a device to log events when the application works.
/// </summary>
public class Logger
{
    private const string LogFileFolderName = "logs";

    private static readonly DirectoryInfo CurrentLogsDirectoryInfo;

    private readonly ILoggingDevice currentLoggingDevice;

    private bool isReadyToListeningEventMessages;

    /// <summary>
    /// Initializes static members of the <see cref="Logger"/> class.
    /// </summary>
    static Logger()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), LogFileFolderName);
        CurrentLogsDirectoryInfo = new DirectoryInfo(path);

        if (!CurrentLogsDirectoryInfo.Exists)
        {
            CurrentLogsDirectoryInfo.Create();
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Logger"/> class.
    /// </summary>
    /// <param name="device">A concrete implementation of a logging device
    /// compatible with the <see cref="ILoggingDevice"/> interface.</param>
    private Logger(ILoggingDevice device)
    {
        this.currentLoggingDevice = device;
        this.isReadyToListeningEventMessages = false;
    }

    /// <summary>
    /// Gets the current instance of the <see cref="Logger"/> class used by the application.
    /// </summary>
    public static Logger? CurrentInstance { get; private set; }

    /// <summary>
    /// Initializes application's default event logging device.
    /// </summary>
    public static void InitializeByDefault()
    {
        ILoggingDevice defaultLogger = new DefaultLogger(CurrentLogsDirectoryInfo);
        Initialize(defaultLogger);
    }

    /// <summary>
    /// Initializes the current event logging device used by the application.
    /// </summary>
    /// <param name="device">A concrete implementation of a logging device
    /// compatible with the <see cref="ILoggingDevice"/> interface.</param>
    public static void Initialize(ILoggingDevice device)
    {
        if (CurrentInstance == null)
        {
            CurrentInstance = new Logger(device);
        }
    }

    /// <summary>
    /// Opens the logging device. Now the device is ready to log possible event messages.
    /// </summary>
    public void Open()
    {
        if (this.isReadyToListeningEventMessages)
        {
            return;
        }

        this.currentLoggingDevice.Open();
        this.isReadyToListeningEventMessages = true;
    }

    /// <summary>
    /// Logs a <see cref="BrowserEventMessage"/> event message via this logging device.
    /// </summary>
    /// <param name="eventMessage">An event message that should be logged by this device.</param>
    public void LogEventMessage(BrowserEventMessage eventMessage)
    {
        if (this.isReadyToListeningEventMessages)
        {
            this.currentLoggingDevice.LogEventMessage(eventMessage);
        }
    }

    /// <summary>
    /// Closes the logging device. Now the device cannot log event messages.
    /// </summary>
    public void Close()
    {
        if (this.isReadyToListeningEventMessages)
        {
            this.currentLoggingDevice.Close();
            this.isReadyToListeningEventMessages = false;
        }
    }
}
