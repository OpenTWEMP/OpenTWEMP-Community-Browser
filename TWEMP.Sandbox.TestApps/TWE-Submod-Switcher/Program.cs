#define ARGS
#undef ARGS

namespace TWE_Submod_Switcher;

using System.IO;
using System;
using System.Xml.Serialization;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("START");

#if ARGS
        PrintCommandLineArguments(args);
#endif

        string homeDirectoryPath = Directory.GetCurrentDirectory();

        foreach (var arg in args)
        {
            if (arg.Equals("--test"))
            {
                ModSubmodsConfiguration configuration = CreateTestConfiguration(homeDirectoryPath);
                PrepareTestAssets(homeDirectoryPath, configuration);

                Console.WriteLine("RESULT: Prepared test assets.");
            }

            if (arg.Equals("--custom"))
            {
                Console.WriteLine("1) Check the Game Mod Installation");

                Console.WriteLine("2) Detect All Config Files");

                string configFilePath = ModSubmodsConfiguration.GetConfigurationFilePath(homeDirectoryPath);

                ModSubmodsConfiguration configuration = new ();

                if (File.Exists(configFilePath))
                {
                    using (FileStream xmlCfgFile = File.Open(configFilePath, FileMode.Open))
                    {
                        XmlSerializer serializer = new(type: configuration.GetType());
                        configuration = serializer.Deserialize(xmlCfgFile) as ModSubmodsConfiguration;
                    }
                }

                Console.WriteLine("3) Read Data From Config Files");

                foreach (ModGameLocale localization in configuration.SupportedLocalizations)
                {
                    Console.WriteLine($"[ID: {localization.ID}] {localization.Title} Locale");
                }

                Console.WriteLine("4) Select a Custom Submod via User Input");

                string id;
                string[] availableLocalizationIDs = configuration.GetAvailableLocalizationIDs();

                do
                {
                    Console.Write("Print a valid ID to select a game localization to install: ");
                    id = Console.ReadLine();
                } while (!ModSubmodsConfiguration.IsValidLocalizationID(id, availableLocalizationIDs));

                ModGameLocale currentLocale = configuration.GetLocalizationByID(id);

                Console.WriteLine($"Your selected game localization is '{currentLocale.Title}'");

                Console.WriteLine("5) Clean Current Game Assets");
                Console.WriteLine("6) Copy Target Game Assets");

                string currentLocalizationDirectoryPath = Path.Combine(
                    path1: homeDirectoryPath,
                    path2: configuration.SourceDirectoryPath,
                    path3: currentLocale.SourceDirectoryPath);

                if (Directory.Exists(currentLocalizationDirectoryPath))
                {
                    Console.WriteLine($"Directory Successfully Detected: '{currentLocalizationDirectoryPath}'");

                    DirectoryInfo currentLocalizationDirectoryInfo = new (currentLocalizationDirectoryPath);

                    FileInfo[] files = GetAllFiles(currentLocalizationDirectoryInfo);

                    Console.WriteLine("7) Display Result Information:");

                    foreach (FileInfo fileInfo in files)
                    {
                        Console.WriteLine($"[SRC_FILE] {fileInfo.FullName}");

                        FileInfo targetFileInfo = configuration.GetDestinationFilePath(currentLocale, fileInfo);
                        Console.WriteLine($"[DST_FILE] {targetFileInfo.FullName}");

                        if (!targetFileInfo.Directory.Exists)
                        {
                            Directory.CreateDirectory(targetFileInfo.Directory.FullName);
                        }

                        File.Copy(sourceFileName: fileInfo.FullName, destFileName: targetFileInfo.FullName, overwrite: true);

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
                else
                {
                    Console.WriteLine($"Cannot Detect Directory: '{currentLocalizationDirectoryPath}'");
                }
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
}
