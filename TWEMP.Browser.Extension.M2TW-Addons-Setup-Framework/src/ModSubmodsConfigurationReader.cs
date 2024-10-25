// <copyright file="ModSubmodsConfigurationReader.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Extension.AddonsSetupFramework;

using System.Xml.Serialization;

public static class ModSubmodsConfigurationReader
{
    public static ModSubmodsConfiguration ReadCustomConfiguration(string customConfigFilePath)
    {
        ModSubmodsConfiguration configuration = new ();

        if (File.Exists(customConfigFilePath))
        {
            using (FileStream xmlCfgFile = File.Open(customConfigFilePath, FileMode.Open))
            {
                XmlSerializer serializer = new (type: configuration.GetType());
                configuration = serializer.Deserialize(xmlCfgFile) as ModSubmodsConfiguration;
            }
        }

        return configuration;
    }
}
