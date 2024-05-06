// <copyright file="GameCfgSection.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

// TODO: Use this type definition instead of the TWEMP.Browser.Core.CommonLibrary.CfgOptionsSubSet (after merging beta24* branches).
public abstract class GameCfgSection
{
    public GameCfgSection(string name, GameCfgOption[] options)
    {
        this.Name = name;
        this.Options = options;
    }

    public string Name { get; }

    public GameCfgOption[] Options { get; }

    public abstract string GetOutputConfigFormat();
}
