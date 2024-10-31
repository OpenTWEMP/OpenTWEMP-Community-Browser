// <copyright file="ModDiagnosticSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;

public record ModDiagnosticSectionStateView : ICustomConfigState
{
    private const string LogConfigSwitch = "log";

    public const string LogToTextId = "to";
    public const string LogLevelTextId = "level";

    public ModDiagnosticSectionStateView()
    {
    }

    public string? LogTo { get; set; } // "to";

    public M2TW_LoggingLevel? LogLevel { get; set; } // "level";

    public static ModDiagnosticSectionStateView CreateByDefault(GameModificationInfo mod)
    {
        return new ModDiagnosticSectionStateView
        {
            LogTo = mod.LogFileRelativePath,
            LogLevel = new M2TW_LoggingLevel(M2TW_LoggingMode.Error),
        };
    }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        M2TWGameCfgOption[] gameLogCfgOptions =
        {
            new (name: LogToTextId, value: this.LogTo!, section: LogConfigSwitch),
            new (name: LogLevelTextId, value: this.LogLevel!.Value, section: LogConfigSwitch),
        };

        GameCfgSection gameLogCfgSection = new M2TWGameCfgSection(LogConfigSwitch, gameLogCfgOptions);
        return new GameCfgSection[] { gameLogCfgSection };
    }
}
