// <copyright file="GameCfgOption.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

// TODO: Use this type definition instead of the TWEMP.Browser.Core.CommonLibrary.CfgOption (after merging beta24* branches).
public abstract class GameCfgOption
{
    public GameCfgOption(string name, object value, string section)
    {
        this.Name = name;
        this.Value = value;
        this.ConfigSectionName = section;
        this.Description = name;
    }

    public string Name { get; }

    public object Value { get; }

    public string ConfigSectionName { get; }

    public string Description { get; set; }

    public abstract string GetOutputConfigFormat();
}
