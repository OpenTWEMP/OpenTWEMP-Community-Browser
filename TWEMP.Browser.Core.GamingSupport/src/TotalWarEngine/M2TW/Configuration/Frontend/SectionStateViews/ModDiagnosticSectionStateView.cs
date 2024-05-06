// <copyright file="ModDiagnosticSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;

public record ModDiagnosticSectionStateView : ICustomConfigState
{
    public string? LogTo { get; set; } // "to";

    public bool ValidatorLogLevel1 { get; set; }

    public bool ValidatorLogLevel2 { get; set; }

    public bool ValidatorLogLevel3 { get; set; }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }

    private static M2TWGameCfgSection GetLogSubSet(GameModificationInfo mod, M2TWGameConfigStateView cfg)
    {
        string subsetName = "log";

        var subsetOptions = new List<M2TWGameCfgOption>();
        subsetOptions.Add(new M2TWGameCfgOption("to", mod.LogFileRelativePath!, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("level", SetLogLevel(cfg), subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static string SetLogLevel(M2TWGameConfigStateView cfg)
    {
        const string strLogLevelError = "* error";
        const string strLogLevelTrace = "* trace";
        const string strLogLevelScriptTrace = "*script* trace";

        string strLogLevel = string.Empty;

        if (cfg.ModDiagnosticSection!.ValidatorLogLevel1)
        {
            strLogLevel = strLogLevelError;
        }

        if (cfg.ModDiagnosticSection!.ValidatorLogLevel2)
        {
            strLogLevel = strLogLevelTrace;
        }

        if (cfg.ModDiagnosticSection!.ValidatorLogLevel3)
        {
            strLogLevel = strLogLevelScriptTrace;
        }

        return strLogLevel;
    }
}
