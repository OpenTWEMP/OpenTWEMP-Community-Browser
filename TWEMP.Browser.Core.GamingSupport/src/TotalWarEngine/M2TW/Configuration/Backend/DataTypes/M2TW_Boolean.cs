// <copyright file="M2TW_Boolean.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // Field names should not contain underscore

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public class M2TW_Boolean
{
    public const string BooleanFalse = "false";
    public const string BooleanTrue = "true";

    public const string IntegerFalse = "0";
    public const string IntegerTrue = "1";

    public const string M2TW_Deprecated_UI_False = "hide";
    public const string M2TW_Deprecated_UI_True = "show";

    public const string M2TW_Deprecated_AI_False = "skip";
    public const string M2TW_Deprecated_AI_True = "follow";

    public M2TW_Boolean(bool value)
    {
        this.BooleanValue = value ? BooleanTrue : BooleanFalse;
        this.IntegerValue = value ? IntegerTrue : IntegerFalse;
    }

    public M2TW_Boolean(M2TW_Deprecated_UI_Boolean value)
    {
        switch (value)
        {
            case M2TW_Deprecated_UI_Boolean.Hide:
                this.BooleanValue = M2TW_Deprecated_UI_False;
                this.IntegerValue = IntegerFalse;
                break;
            case M2TW_Deprecated_UI_Boolean.Show:
                this.BooleanValue = M2TW_Deprecated_UI_True;
                this.IntegerValue = IntegerTrue;
                break;
            default:
                this.BooleanValue = M2TW_Deprecated_UI_False;
                this.IntegerValue = IntegerFalse;
                break;
        }
    }

    public M2TW_Boolean(M2TW_Deprecated_AI_Boolean value)
    {
        switch (value)
        {
            case M2TW_Deprecated_AI_Boolean.Skip:
                this.BooleanValue = M2TW_Deprecated_AI_False;
                this.IntegerValue = IntegerFalse;
                break;
            case M2TW_Deprecated_AI_Boolean.Follow:
                this.BooleanValue = M2TW_Deprecated_AI_True;
                this.IntegerValue = IntegerTrue;
                break;
            default:
                this.BooleanValue = M2TW_Deprecated_AI_False;
                this.IntegerValue = IntegerFalse;
                break;
        }
    }

    public string BooleanValue { get; }

    public string IntegerValue { get; }
}
