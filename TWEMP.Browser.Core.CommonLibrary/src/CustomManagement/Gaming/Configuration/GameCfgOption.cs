// <copyright file="GameCfgOption.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

public class GameCfgOption
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

    public virtual string GetOutputConfigFormat() =>
        $"{this.Name} = {this.Value}";
}
