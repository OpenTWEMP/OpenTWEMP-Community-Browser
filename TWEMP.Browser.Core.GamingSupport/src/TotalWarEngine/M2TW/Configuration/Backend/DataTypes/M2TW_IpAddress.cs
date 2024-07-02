// <copyright file="M2TW_IpAddress.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public class M2TW_IpAddress
{
    public const string DefaultPort = "27750";

    public M2TW_IpAddress(byte octet_1, byte octet_2, byte octet_3, byte octet_4)
    {
        this.Value = $"{octet_1}.{octet_2}.{octet_3}.{octet_4}";
    }

    public string Value { get; }
}
