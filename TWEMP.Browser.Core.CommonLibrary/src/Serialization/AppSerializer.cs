// <copyright file="AppSerializer.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.Serialization;

using Newtonsoft.Json;

public static class AppSerializer
{
    public static void SerializeToJson(object obj, string file)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        File.WriteAllText(file, json);
    }

    public static T DeserializeFromJson<T>(string file)
    {
        string json = File.ReadAllText(file);
        return JsonConvert.DeserializeObject<T>(json) !;
    }
}
