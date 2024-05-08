// <copyright file="M2TW_LoggingLevel.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes.Enums;

public class M2TW_LoggingLevel
{
    public const string LogLevelError = "* error";
    public const string LogLevelTrace = "* trace";
    public const string LogLevelScriptTrace = "*script* trace";

    public M2TW_LoggingLevel(M2TW_LoggingMode value)
    {
        switch (value)
        {
            case M2TW_LoggingMode.Error:
                this.Value = LogLevelError;
                break;
            case M2TW_LoggingMode.Trace:
                this.Value = LogLevelTrace;
                break;
            case M2TW_LoggingMode.ScriptTrace:
                this.Value = LogLevelScriptTrace;
                break;
            default:
                this.Value = LogLevelError;
                break;
        }
    }

    public string Value { get; }
}
