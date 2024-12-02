// <copyright file="ModHeaderInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public record ModHeaderInfo
{
    public ModHeaderInfo(string title, string version)
    {
        this.ModTitle = title;
        this.ModVersion = version;
    }

    public string ModTitle { get; set; }

    public string ModVersion { get; set; }
}
