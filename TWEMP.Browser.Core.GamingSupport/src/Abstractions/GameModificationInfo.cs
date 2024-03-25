// <copyright file="GameModificationInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis

namespace TWEMP.Browser.Core.GamingSupport.Abstractions; // TODO: Replace to imported abstractions from TWEMP.Browser.Core.CommonLibrary

public class GameModificationInfo
{
    public string? Location { get; set; }

    public string? ModCfgRelativePath { get; set; }

    public string? LogFileRelativePath { get; set; }
}
