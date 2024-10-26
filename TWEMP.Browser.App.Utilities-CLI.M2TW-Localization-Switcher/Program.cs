// <copyright file="Program.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.App.Utilities_CLI.M2TW_Localization_Switcher;

using System;
using System.IO;
using TWEMP.Browser.Extension.AddonsSetupFramework;

internal class Program
{
    internal static void Main(string[] args)
    {
        Console.WriteLine("START");

        bool areDisplayedArguments = false;
        if (areDisplayedArguments)
        {
            PrintCommandLineArguments(args);
        }

        string homeDirectoryPath = Directory.GetCurrentDirectory();

        foreach (var arg in args)
        {
            if (arg.Equals("--test"))
            {
                GenerateDefaultConfiguration(homeDirectoryPath);
            }

            if (arg.Equals("--custom"))
            {
                ExecuteCustomConfiguration(homeDirectoryPath);
            }
        }

        Console.WriteLine("FINISH");
    }

    private static void PrintCommandLineArguments(string[] args)
    {
        for (int argIndex = 0; argIndex < args.Length; argIndex++)
        {
            Console.WriteLine($"arg[{argIndex}] = \"{args[argIndex]}\"");
        }

        Console.WriteLine();
    }

    private static void GenerateDefaultConfiguration(string targetDirectoryPath)
    {
        TestConfigurationGenerator.GenerateAddonsSetupConfiguration(targetDirectoryPath);

        ModSubmodsConfiguration customConfiguration = TestConfigurationGenerator.CreateTestConfiguration(targetDirectoryPath, ModSubmodsConfiguration.ConfigFileName);
        TestConfigurationGenerator.PrepareTestAssets(targetDirectoryPath, customConfiguration);

        Console.WriteLine("RESULT: Prepared test assets.");
    }

    private static void ExecuteCustomConfiguration(string targetDirectoryPath)
    {
        Console.WriteLine("0) Detect the App Configuration ...");
        AddonsSetupConfiguration appConfiguration = AddonsSetupConfigurationReader.ReadAddonsSetupConfiguration(targetDirectoryPath);
        Console.WriteLine($"Application Configuration: {appConfiguration.CustomConfigFileName}");

        Console.WriteLine("1) Detect a Custom Configuration ...");
        string configFilePath = ModSubmodsConfiguration.GetConfigurationFilePath(targetDirectoryPath, appConfiguration.CustomConfigFileName);
        ModSubmodsConfiguration configuration = ModSubmodsConfigurationReader.ReadCustomConfiguration(configFilePath);

        Console.WriteLine("2) Read Localizations from the Custom Configuration ...");
        PrintAllCustomLocalizations(configuration);

        Console.WriteLine("3) Select a Localization via User Input ...");
        ModGameLocale currentLocale = SelectCustomLocalizationByUserInput(configuration);
        Console.WriteLine($"Your selected game localization is '{currentLocale.Title}'");

        Console.WriteLine("4) Copy Game Assets Of the Custom Localization ...");
        CopyGameAssetsOfCustomLocalizationToTargetDirectory(configuration, currentLocale, targetDirectoryPath);
    }

    private static void PrintAllCustomLocalizations(ModSubmodsConfiguration configuration)
    {
        foreach (ModGameLocale localization in configuration.SupportedLocalizations)
        {
            Console.WriteLine($"[ID: {localization.ID}] {localization.Title} Locale");
        }
    }

    private static ModGameLocale SelectCustomLocalizationByUserInput(ModSubmodsConfiguration configuration)
    {
        string[] availableLocalizationIDs = configuration.GetAvailableLocalizationIDs();

        string id;
        do
        {
            Console.Write("Print a valid ID to select a game localization to install: ");
            id = Console.ReadLine();
        }
        while (!ModSubmodsConfiguration.IsValidLocalizationID(id, availableLocalizationIDs));

        return configuration.GetLocalizationByID(id);
    }

    private static void CopyGameAssetsOfCustomLocalizationToTargetDirectory(
        ModSubmodsConfiguration configuration, ModGameLocale customLocale, string targetDirectoryPath)
    {
        string currentLocalizationDirectoryPath = Path.Combine(
            targetDirectoryPath, configuration.SourceDirectoryPath, customLocale.SourceDirectoryPath);

        if (Directory.Exists(currentLocalizationDirectoryPath))
        {
            Console.WriteLine($"Directory Successfully Detected: '{currentLocalizationDirectoryPath}'");

            FileInfo[] files = TestConfigurationGenerator.GetAllFiles(new DirectoryInfo(currentLocalizationDirectoryPath));
            ExecuteCopyingAllFilesRoutine(configuration, customLocale, files);
        }
        else
        {
            Console.WriteLine($"Cannot Detect Directory: '{currentLocalizationDirectoryPath}'");
        }
    }

    private static void ExecuteCopyingAllFilesRoutine(ModSubmodsConfiguration configuration, ModGameLocale customLocale, FileInfo[] filesToCopy)
    {
        Console.WriteLine("Verbose Information About File Copying:");

        foreach (FileInfo fileInfo in filesToCopy)
        {
            FileInfo targetFileInfo = configuration.GetDestinationFilePath(customLocale, fileInfo);
            ExecuteCopyingFileRoutine(srcFileInfo: fileInfo, destFileInfo: targetFileInfo);
        }
    }

    private static void ExecuteCopyingFileRoutine(FileInfo srcFileInfo, FileInfo destFileInfo)
    {
        PrintDetailsAboutFilesCopying(srcFileInfo, destFileInfo);

        if (!destFileInfo.Directory.Exists)
        {
            Directory.CreateDirectory(destFileInfo.Directory.FullName);
        }

        File.Copy(sourceFileName: srcFileInfo.FullName, destFileName: destFileInfo.FullName, overwrite: true);

        PrintFileValidationResult(destFileInfo);
    }

    private static void PrintDetailsAboutFilesCopying(FileInfo srcFileInfo, FileInfo destFileInfo)
    {
        Console.WriteLine($"[SRC_FILE] {srcFileInfo.FullName}");
        Console.WriteLine($"[DST_FILE] {destFileInfo.FullName}");
    }

    private static void PrintFileValidationResult(FileInfo targetFileInfo)
    {
        if (File.Exists(targetFileInfo.FullName))
        {
            Console.WriteLine("[RESULT: SUCCESS] Destination File is successfully created!");
        }
        else
        {
            Console.WriteLine("[RESULT: FAILED] Error when copying the destination file!");
        }

        Console.WriteLine();
    }
}
