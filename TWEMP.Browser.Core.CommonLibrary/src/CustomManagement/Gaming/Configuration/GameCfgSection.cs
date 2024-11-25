// <copyright file="GameCfgSection.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

public class GameCfgSection
{
    private static readonly string NewLine = System.Environment.NewLine;

    public GameCfgSection(string name, GameCfgOption[] options)
    {
        this.Name = name;
        this.Options = options;
    }

    public string Name { get; }

    public GameCfgOption[] Options { get; }

    public virtual string GetOutputConfigFormat()
    {
        string optionsSubSet = $"[{this.Name}]{NewLine}";

        foreach (GameCfgOption option in this.Options)
        {
            string optionOutStr = $"{option.GetOutputConfigFormat()}{NewLine}";
            optionsSubSet += optionOutStr;
        }

        return optionsSubSet;
    }
}
