// <copyright file="AddonsSetupConfigurationReader.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Extension.AddonsSetupFramework;

using System.Xml.Serialization;

public static class AddonsSetupConfigurationReader
{
    public static AddonsSetupConfiguration ReadAddonsSetupConfiguration(string appHomeDirectoryPath)
    {
        AddonsSetupConfiguration targetConfiguration = new ();
        string targetConfigurationFilePath = Path.Combine(appHomeDirectoryPath, AddonsSetupConfiguration.MainConfigFileName);

        if (File.Exists(targetConfigurationFilePath))
        {
            using (FileStream xmlCfgFile = File.Open(targetConfigurationFilePath, FileMode.Open))
            {
                XmlSerializer serializer = new (type: targetConfiguration.GetType());
                targetConfiguration = serializer.Deserialize(xmlCfgFile) as AddonsSetupConfiguration;
            }
        }

        return targetConfiguration;
    }
}
