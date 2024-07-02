// <copyright file="M2TWGameCfgSection.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

public class M2TWGameCfgSection : GameCfgSection
{
    public M2TWGameCfgSection(string name, M2TWGameCfgOption[] options)
        : base(name: name, options: options)
    {
    }

    public override string GetOutputConfigFormat()
    {
        string optionsSubSet;

        optionsSubSet = this.FormatNameToCfg() + "\n";

        foreach (var option in this.Options)
        {
            optionsSubSet += option.GetOutputConfigFormat() + "\n";
        }

        return optionsSubSet;
    }

    private string FormatNameToCfg()
    {
        return "[" + this.Name + "]";
    }
}
