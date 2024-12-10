// <copyright file="M2TWGameCfgOption.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

public class M2TWGameCfgOption : GameCfgOption
{
    public M2TWGameCfgOption(string name, object value, string section)
        : base(name: name, value: value, section: section)
    {
    }

    public override string GetOutputConfigFormat() =>
        base.GetOutputConfigFormat();
}
