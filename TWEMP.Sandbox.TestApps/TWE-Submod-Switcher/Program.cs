#define ARGS
#undef ARGS

namespace TWE_Submod_Switcher;

using System.IO;
using System;
using System.Xml.Serialization;

internal class Program
{
    const string LocaleID_RUS = "RUS";
    const string LocaleID_ENG = "ENG";
    const string LocaleID_ITA = "ITA";
    const string LocaleID_SPA = "SPA";
    const string LocaleID_DEU = "DEU";
    const string LocaleID_FRA = "FRA";
    const string LocaleID_POL = "POL";
    const string LocaleID_CHI = "CHI";

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

    private static ModSubmodsConfiguration CreateTestConfiguration(string directoryPath)
    {
        string workingDirectoryPath = Directory.GetCurrentDirectory();

        List<ModGameLocale> supportedLocalizations = new ()
        {
            new (id: LocaleID_RUS, title: "Russian", srcDirPath: LocaleID_RUS),
            new (id: LocaleID_ENG, title: "English", srcDirPath: LocaleID_ENG),
            new (id: LocaleID_ITA, title: "Italian", srcDirPath: LocaleID_ITA),
            new (id: LocaleID_SPA, title: "Spanish", srcDirPath: LocaleID_SPA),
            new (id: LocaleID_DEU, title: "German", srcDirPath: LocaleID_DEU),
            new (id: LocaleID_FRA, title: "French", srcDirPath: LocaleID_FRA),
            new (id: LocaleID_POL, title: "Polish", srcDirPath: LocaleID_POL),
            new (id: LocaleID_CHI, title: "Chinese", srcDirPath: LocaleID_CHI),
        };

        ModSubmodsConfiguration configuration = new (
            srcDirPath: "submods", destDirPath: "data",
            modGameLocales: supportedLocalizations.ToArray());

        string configFilePath = ModSubmodsConfiguration.GetConfigurationFilePath(directoryPath);
        XmlSerializer serializer = new (configuration.GetType());

        using (FileStream stream = File.Create(configFilePath))
        {
            serializer.Serialize(stream, configuration);
        }

        return configuration;
    }

    private static void PrepareTestAssets(string directoryPath, ModSubmodsConfiguration configuration)
    {
        string submodsDirectoryPath = Path.Combine(
            path1: directoryPath, path2: configuration.SourceDirectoryPath);

        if (!Directory.Exists(submodsDirectoryPath))
        {
            Directory.CreateDirectory(submodsDirectoryPath);
        }

        CreateTestGameLocalizations(submodsDirectoryPath, configuration);
    }

    private static void CreateTestGameLocalizations(string gameLocalizationsDirectoryPath, ModSubmodsConfiguration configuration)
    {
        foreach (ModGameLocale localization in configuration.SupportedLocalizations)
        {
            string customLocaleDirectoryPath = Path.Combine(
                path1: gameLocalizationsDirectoryPath,
                path2: localization.SourceDirectoryPath);

            CreateTestGameLocale(customLocaleDirectoryPath, localization);
        }
    }

    private static void CreateTestGameLocale(string gameLocaleDirectoryPath, ModGameLocale gameLocale)
    {
        const string testLocaleFileBaseName = "text_";
        const string testLocaleFileExtension = ".txt";
        const byte testLocaleFilesCount = 10;

        string testLocaleAssetsPath = Path.Combine(gameLocaleDirectoryPath, "data", "text");

        if (!Directory.Exists(testLocaleAssetsPath))
        {
            Directory.CreateDirectory(testLocaleAssetsPath);
        }

        for (byte fileIndex = 0; fileIndex < testLocaleFilesCount; fileIndex++)
        {
            string customLocaleFileName = testLocaleFileBaseName
                + gameLocale.ID
                + "_" + fileIndex.ToString()
                + testLocaleFileExtension;

            string customLocaleFilePath = Path.Combine(
                path1: testLocaleAssetsPath,
                path2: customLocaleFileName);

            if (!File.Exists(customLocaleFilePath))
            {
                File.Create(customLocaleFilePath);
            }
        }
    }

    private static FileInfo[] GetAllFiles(DirectoryInfo targetDirectoryInfo)
    {
        List<FileInfo> targetFiles = new ();

        FileInfo[] files = targetDirectoryInfo.GetFiles();
        targetFiles.AddRange(files);

        DirectoryInfo[] directories = targetDirectoryInfo.GetDirectories();
        foreach (DirectoryInfo directory in directories)
        {
            FileInfo[] filesIntoDirectory = GetAllFiles(directory);
            targetFiles.AddRange(filesIntoDirectory);
        }

        return targetFiles.ToArray();
    }
}

public record ModSubmodsConfiguration
{
    public const string ConfigFileName = "configuration.xml";

    public ModSubmodsConfiguration()
    {
    }

    public ModSubmodsConfiguration(string srcDirPath, string destDirPath, ModGameLocale[] modGameLocales)
    {
        SourceDirectoryPath = srcDirPath;
        DestinationDirectoryPath = destDirPath;
        SupportedLocalizations = modGameLocales.ToArray();
    }

    [XmlAttribute("SourceDirectoryRelativePath")]
    public string SourceDirectoryPath { get; set; }

    [XmlAttribute("DestinationDirectoryRelativePath")]
    public string DestinationDirectoryPath { get; set; }

    [XmlElement("Localization")]
    public ModGameLocale[] SupportedLocalizations { get; set; }

    public static string GetConfigurationFilePath(string directoryPath)
    {
        return Path.Combine(directoryPath, ConfigFileName);
    }

    public static bool IsValidLocalizationID(string targetID, string[] validIDs)
    {
        foreach (string validID in validIDs)
        {
            if (targetID.Equals(validID))
            {
                return true;
            }
        }

        return false;
    }

    public string[] GetAvailableLocalizationIDs()
    {
        List<string> localeIDs = new List<string>();

        foreach (ModGameLocale localization in this.SupportedLocalizations)
        {
            localeIDs.Add(localization.ID);
        }

        return localeIDs.ToArray();
    }

    public ModGameLocale GetLocalizationByID(string id)
    {
        foreach (ModGameLocale localization in this.SupportedLocalizations)
        {
            if (localization.ID.Equals(id))
            {
                return localization;
            }
        }

        return null;
    }

    public FileInfo GetDestinationFilePath(ModGameLocale modGameLocale, FileInfo fileInfo) =>
        new FileInfo(fileInfo.FullName
            .Replace(oldValue: this.SourceDirectoryPath, newValue: this.DestinationDirectoryPath)
            .Replace(oldValue: modGameLocale.ID, newValue: string.Empty));
}

public record ModGameLocale
{
    public ModGameLocale()
    {
    }

    public ModGameLocale(string id, string title, string srcDirPath)
    {
        ID = id;
        Title = title;
        SourceDirectoryPath = srcDirPath;
    }

    [XmlAttribute("ID")]
    public string ID { get; set; }

    [XmlAttribute("Title")]
    public string Title { get; set; }

    [XmlAttribute("SourceDirectoryPath")]
    public string SourceDirectoryPath { get; set; }
}
