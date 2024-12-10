// <copyright file="BrowserEventMessage.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.Logging;

/// <summary>
/// Represents information about a browser event message.
/// </summary>
public record BrowserEventMessage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BrowserEventMessage"/> class.
    /// </summary>
    /// <param name="title">The title of the event message.</param>
    /// <param name="description">The description of the event message.</param>
    /// <param name="occurrenceDateTime">The date and time of the event.</param>
    public BrowserEventMessage(string title, string description, DateTime occurrenceDateTime)
    {
        this.Title = title;
        this.Description = description;
        this.OccurrenceDateTime = occurrenceDateTime;
    }

    /// <summary>
    /// Gets the title of this event message.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the description of this event message.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the date and time of this event.
    /// </summary>
    public DateTime OccurrenceDateTime { get; }
}
