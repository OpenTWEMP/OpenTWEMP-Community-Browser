// <copyright file="GameCfgOptSubSet.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#define GENERATE_OPTIONS_SUBSET
#undef GENERATE_OPTIONS_SUBSET

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

public struct GameCfgOptSubSet : ICfgOptSubSet
{
    private readonly string name;
    private readonly List<M2TWGameCfgOption> options;

    public GameCfgOptSubSet(string subset_name, List<M2TWGameCfgOption> config_options)
    {
        this.name = subset_name;
        this.options = config_options;
    }

#if GENERATE_OPTIONS_SUBSET
    public static CfgOptionsSubSet GenerateOptsSubSet(string subsetName, Dictionary<string, object> settings)
    {
        var subsetOptions = new List<CfgOption>();

        foreach (var setting in settings)
        {
            subsetOptions.Add(new CfgOption(setting.Key, setting.Value));
        }

        return new CfgOptionsSubSet(subsetName, subsetOptions);
    }
#endif

    public string GetOutputConfigFormat()
    {
        string optionsSubSet;

        optionsSubSet = this.FormatNameToCfg() + "\n";

        foreach (var option in this.options)
        {
            optionsSubSet += option.GetOutputConfigFormat() + "\n";
        }

        return optionsSubSet;
    }

    private string FormatNameToCfg()
    {
        return "[" + this.name + "]";
    }
}
