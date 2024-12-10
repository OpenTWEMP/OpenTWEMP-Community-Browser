// <copyright file="DefaultLogger.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.Logging;

/// <summary>
/// Implements the default logger device for OpenTWEMP Community Browser.
/// </summary>
public class DefaultLogger : ILoggingDevice
{
    private readonly FileInfo currentLogFileInfo;
    private StreamWriter? currentLogFileWriter;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultLogger"/> class.
    /// </summary>
    /// <param name="logsDirectoryInfo">Information about the directory
    /// where the browser keeps its log files.</param>
    public DefaultLogger(DirectoryInfo logsDirectoryInfo)
    {
        this.currentLogFileInfo = InitializeLogFileInfo(logsDirectoryInfo);
        this.currentLogFileWriter = null;
    }

    /// <summary>
    /// Opens the default logging device.
    /// </summary>
    public void Open()
    {
        if (this.currentLogFileWriter == null)
        {
            this.currentLogFileWriter = new StreamWriter(
                path: this.currentLogFileInfo.FullName,
                append: this.currentLogFileInfo.Exists);

            this.WriteStartLogEventMessage();
        }
    }

    /// <summary>
    /// Logs a <see cref="BrowserEventMessage"/> event message via this logging device.
    /// </summary>
    /// <param name="eventMessage">An event message that should be logged by this device.</param>
    public void LogEventMessage(BrowserEventMessage eventMessage)
    {
        if (this.currentLogFileWriter != null)
        {
            this.WriteEventMessage(eventMessage);
        }
    }

    /// <summary>
    /// Closes the default logging device.
    /// </summary>
    public void Close()
    {
        if (this.currentLogFileWriter != null)
        {
            this.WriteEndLogEventMessage();
            this.currentLogFileWriter.Close();
        }
    }

    private static FileInfo InitializeLogFileInfo(DirectoryInfo logFilesDirectoryInfo)
    {
        string currentLogFileName = CreateLogFileName();
        string currentLogFilePath = Path.Combine(logFilesDirectoryInfo.FullName, currentLogFileName);

        return new FileInfo(currentLogFilePath);
    }

    private static string CreateLogFileName()
    {
        const string fileBaseName = "twemp-community-browser";
        const string fileExtension = "twemp.log";

        string fileDateTimeSuffix = CreateDateTimeSuffixText(DateTime.Now);

        return $"{fileBaseName}_{fileDateTimeSuffix}.{fileExtension}";
    }

    private static string CreateDateTimeSuffixText(DateTime dateTime)
    {
        return $"{dateTime.Year}-{dateTime.Month}-{dateTime.Day}";
    }

    private void WriteEventMessage(BrowserEventMessage eventMessage)
    {
        this.currentLogFileWriter?.Write(eventMessage.OccurrenceDateTime);
        this.currentLogFileWriter?.Write(eventMessage.Title);
        this.currentLogFileWriter?.WriteLine();

        this.currentLogFileWriter?.WriteLine(eventMessage.Description);
        this.currentLogFileWriter?.WriteLine();
    }

    private void WriteStartLogEventMessage()
    {
        this.WriteEventMessage(new BrowserEventMessage(
            title: "OPENING",
            description: "Opening the logger device...",
            occurrenceDateTime: DateTime.Now));
    }

    private void WriteEndLogEventMessage()
    {
        this.WriteEventMessage(new BrowserEventMessage(
            title: "CLOSING",
            description: "Closing the logger device...",
            occurrenceDateTime: DateTime.Now));
    }
}
