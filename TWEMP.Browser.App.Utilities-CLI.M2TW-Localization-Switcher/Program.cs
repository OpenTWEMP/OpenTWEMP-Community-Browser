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
        PrintBegMessage();

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

        PrintEndMessage();
    }

    private static void PrintBegMessage()
    {
        Console.WriteLine();
        Console.WriteLine("[BEG] Welcome to the Addons-Setup-Framework for M2TW !");
        Console.WriteLine();
    }

    private static void PrintEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("\n[END] This program successfully finished its work!");
        Console.WriteLine();
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
        Console.WriteLine("[READING] Detecting Configuration Files ...");
        AddonsSetupConfiguration appConfiguration = AddonsSetupConfigurationReader.ReadAddonsSetupConfiguration(targetDirectoryPath);
        string configFilePath = ModSubmodsConfiguration.GetConfigurationFilePath(targetDirectoryPath, appConfiguration.CustomConfigFileName);
        ModSubmodsConfiguration configuration = ModSubmodsConfigurationReader.ReadCustomConfiguration(configFilePath);
        Console.WriteLine($"[INFO] Custom Configuration: {appConfiguration.CustomConfigFileName}");

        Console.WriteLine($"\n***** {appConfiguration.CustomGameModificationName} [{appConfiguration.CustomGameModificationVersion}] *****\n");

        PrintAllCustomLocalizations(configuration);

        Console.WriteLine("\n[INPUT] Select a Localization via User Input ...\n");
        ModGameLocale currentLocale = SelectCustomLocalizationByUserInput(configuration);
        Console.WriteLine($"\n[RESULT] Your selected game localization is '{currentLocale.Title}'\n");

        Console.WriteLine("\n[PROCESSING] Copy Game Assets Of the Custom Localization ...\n");
        CopyGameAssetsOfCustomLocalizationToTargetDirectory(configuration, currentLocale, targetDirectoryPath);
    }

    private static void PrintAllCustomLocalizations(ModSubmodsConfiguration configuration)
    {
        Console.WriteLine("\n[READING] Read Localizations from the Custom Configuration ...\n");

        foreach (ModGameLocale localization in configuration.SupportedLocalizations)
        {
            Console.WriteLine($"   [ID: {localization.ID}] {localization.Title}");
        }

        Console.WriteLine();
    }

    private static ModGameLocale SelectCustomLocalizationByUserInput(ModSubmodsConfiguration configuration)
    {
        string[] availableLocalizationIDs = configuration.GetAvailableLocalizationIDs();

        string id;
        do
        {
            Console.Write("Print a valid ID to select a game localization to install:\n" +
                "  (Input ID and press 'Enter') >>> ");
            id = Console.ReadLine();
        }
        while (!ModSubmodsConfiguration.IsValidLocalizationID(id, availableLocalizationIDs));

        return configuration.GetLocalizationByID(id);
    }

    private static void CopyGameAssetsOfCustomLocalizationToTargetDirectory(
        ModSubmodsConfiguration configuration, ModGameLocale customLocale, string targetDirectoryPath)
    {
        DirectoryInfo customLocalizationDirectoryInfo =
            configuration.GetSelectedLocalizationDirectoryInfo(customLocale, targetDirectoryPath);

        if (customLocalizationDirectoryInfo.Exists)
        {
            Console.WriteLine($"\n[INFO] Directory Successfully Detected: '{customLocalizationDirectoryInfo.FullName}'\n");

            FileInfo[] files = TestConfigurationGenerator.GetAllFiles(customLocalizationDirectoryInfo);
            ExecuteCopyingAllFilesRoutine(configuration, customLocale, files);
        }
        else
        {
            Console.WriteLine($"\n[ERROR] Cannot Detect Directory: '{customLocalizationDirectoryInfo.FullName}'\n");
        }
    }

    private static void ExecuteCopyingAllFilesRoutine(ModSubmodsConfiguration configuration, ModGameLocale customLocale, FileInfo[] filesToCopy)
    {
        Console.WriteLine("\n[INFO] Verbose Information About File Copying:\n");

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
