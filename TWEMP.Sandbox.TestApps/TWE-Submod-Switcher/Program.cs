namespace TWE_Submod_Switcher;

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

        for (int argIndex = 0; argIndex < args.Length; argIndex++)
        {
            Console.WriteLine($"arg[{argIndex}] = \"{args[argIndex]}\"");
        }

        Console.WriteLine();

        foreach (var arg in args)
        {
            if (arg.Equals("--test"))
            {
                string homeDirectoryPath = Directory.GetCurrentDirectory();

                ModSubmodsConfiguration configuration = CreateTestConfiguration(homeDirectoryPath);
                PrepareTestAssets(homeDirectoryPath, configuration);

                Console.WriteLine("RESULT: Prepared test assets.");
            }

            if (arg.Equals("--custom"))
            {
                Console.WriteLine("1) Check the Game Mod Installation");
                Console.WriteLine("2) Detect All Config Files");
                Console.WriteLine("3) Read Data From Config Files");
                Console.WriteLine("4) Select a Custom Submod via User Input");
                Console.WriteLine("5) Clean Current Game Assets");
                Console.WriteLine("6) Copy Target Game Assets");
                Console.WriteLine("7) Display Result Information");
            }
        }

        Console.WriteLine("FINISH");
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

        string configFilePath = configuration.GetConfigurationFilePath(directoryPath);
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

        if (!Directory.Exists(gameLocaleDirectoryPath))
        {
            Directory.CreateDirectory(gameLocaleDirectoryPath);
        }

        for (byte fileIndex = 0; fileIndex < testLocaleFilesCount; fileIndex++)
        {
            string customLocaleFileName = testLocaleFileBaseName
                + gameLocale.ID
                + "_" + fileIndex.ToString()
                + testLocaleFileExtension;

            string customLocaleFilePath = Path.Combine(
                path1: gameLocaleDirectoryPath,
                path2: customLocaleFileName);

            if (!File.Exists(customLocaleFilePath))
            {
                File.Create(customLocaleFilePath);
            }
        }
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

    public string GetConfigurationFilePath(string directoryPath)
    {
        return Path.Combine(directoryPath, ConfigFileName);
    }
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
