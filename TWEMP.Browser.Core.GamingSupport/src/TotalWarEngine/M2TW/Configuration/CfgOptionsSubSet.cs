// <copyright file="CfgOptionsSubSet.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#define GENERATE_OPTIONS_SUBSET
#undef GENERATE_OPTIONS_SUBSET

#pragma warning disable SA1600 // ElementsMustBeDocumented


// <copyright file="CfgOptionsSubSet.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#define GENERATE_OPTIONS_SUBSET
#undef GENERATE_OPTIONS_SUBSET

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration;

public struct CfgOptionsSubSet
{
    private readonly string name;
    private readonly List<CfgOption> options;

    public CfgOptionsSubSet(string subset_name, List<CfgOption> config_options)
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

    public string FormatToCfg()
    {
        string optionsSubSet;

        optionsSubSet = this.FormatNameToCfg() + "\n";

        foreach (var option in this.options)
        {
            optionsSubSet += option.ToConfigFormat() + "\n";
        }

        return optionsSubSet;
    }

    private string FormatNameToCfg()
    {
        return "[" + this.name + "]";
    }
}
