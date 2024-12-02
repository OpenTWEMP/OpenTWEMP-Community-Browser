// <copyright file="ModSocialMediaInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public record ModSocialMediaInfo
{
    public ModSocialMediaInfo(Dictionary<string, string> urlPairs)
    {
        this.ModURLs = urlPairs;
    }

    public Dictionary<string, string> ModURLs { get; set; }
}
