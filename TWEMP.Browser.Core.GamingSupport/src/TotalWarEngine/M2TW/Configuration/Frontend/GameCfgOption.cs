// <copyright file="GameCfgOption.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

public class GameCfgOption : ICfgOption
{
    private readonly string name;
    private readonly object value;

    public GameCfgOption(string option_name, object option_value)
    {
        this.name = option_name;
        this.value = option_value;
    }

    public string GetOutputConfigFormat()
    {
        return this.name + " = " + this.value.ToString();
    }
}
