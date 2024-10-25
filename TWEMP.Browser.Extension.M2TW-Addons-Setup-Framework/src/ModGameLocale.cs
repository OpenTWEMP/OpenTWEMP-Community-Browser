// <copyright file="ModGameLocale.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Extension.AddonsSetupFramework;

using System.Xml.Serialization;

public record ModGameLocale
{
    public ModGameLocale()
    {
    }

    public ModGameLocale(string id, string title, string srcDirPath)
    {
        this.ID = id;
        this.Title = title;
        this.SourceDirectoryPath = srcDirPath;
    }

    [XmlAttribute("ID")]
    public string ID { get; set; }

    [XmlAttribute("Title")]
    public string Title { get; set; }

    [XmlAttribute("SourceDirectoryPath")]
    public string SourceDirectoryPath { get; set; }
}
