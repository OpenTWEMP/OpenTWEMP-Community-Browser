// <copyright file="M2TW_Integer.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public class M2TW_Integer
{
    public const byte MinValue = 0;

    public const byte MaxValue = 100;

    public const ushort ExtendedMaxValue = 10_000;

    public M2TW_Integer(byte value)
    {
        if (value > MaxValue)
        {
            this.Value = MaxValue.ToString();
        }
        else
        {
            this.Value = value.ToString();
        }
    }

    public M2TW_Integer(ushort value)
    {
        if (value > ExtendedMaxValue)
        {
            this.Value = ExtendedMaxValue.ToString();
        }
        else
        {
            this.Value = value.ToString();
        }
    }

    public string Value { get; }
}
