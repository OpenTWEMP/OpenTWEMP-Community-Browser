// <copyright file="AppSystemSettingsManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement;

/// <summary>
/// Represents a device to manage application's system settings.
/// </summary>
public static class AppSystemSettingsManager
{
    private const string APP_SUPPORT_DIRECTORY_NAME = "support";
    private const string APP_SUPPORT_NODE1_M2TW = "M2TWK";
    private const string APP_SUPPORT_NODE2_LOGO = "images";

    private static readonly DirectoryInfo AppSupportNode_M2TW_LOGO_DirectoryInfo;

    static AppSystemSettingsManager()
    {
        string appSupportDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), APP_SUPPORT_DIRECTORY_NAME);
        AppSupportDirectoryInfo = new DirectoryInfo(appSupportDirectoryPath);

        // Initialize app's file system.
        if (!AppSupportDirectoryInfo.Exists)
        {
            AppSupportDirectoryInfo.Create();
        }

        string appSupportNode_M2TW_LOGO_DirectoryPath = Path.Combine(appSupportDirectoryPath, APP_SUPPORT_NODE1_M2TW, APP_SUPPORT_NODE2_LOGO);
        AppSupportNode_M2TW_LOGO_DirectoryInfo = new DirectoryInfo(appSupportNode_M2TW_LOGO_DirectoryPath);

        if (!AppSupportNode_M2TW_LOGO_DirectoryInfo.Exists)
        {
            AppSupportNode_M2TW_LOGO_DirectoryInfo.Create();
        }

        // Initialize extra flags by default.
        UseExperimentalFeatures = true;
    }

    public static DirectoryInfo AppSupportDirectoryInfo { get; }

    public static bool UseExperimentalFeatures { get; set; }
}
