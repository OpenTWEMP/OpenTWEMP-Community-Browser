// <copyright file="CfgOption.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.GameLauncherFeatures;

public struct CfgOption
{
    private readonly string name;
    private readonly object value;

    public CfgOption(string option_name, object option_value)
    {
        this.name = option_name;
        this.value = option_value;
    }

    public string ToConfigFormat()
    {
        return this.name + " = " + this.value.ToString();
    }
}
