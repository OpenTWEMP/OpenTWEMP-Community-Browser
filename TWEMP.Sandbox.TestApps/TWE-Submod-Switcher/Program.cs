namespace TWE_Submod_Switcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string homeDirectoryPath = Directory.GetCurrentDirectory();
            PrepareTestAssets(homeDirectoryPath);

            //const string cfgFileName = "mod_locale.json";
        }

        private static void PrepareTestAssets(string homeDirectoryPath)
        {
            // 1. Create Default Locale Files

            const string modFolderName = "data";
            const string modLocaleFolderName = "text";

            string modLocaleDirectoryPath = Path.Combine(
                path1: homeDirectoryPath,
                path2: modFolderName,
                path3: modLocaleFolderName);

            if (!Directory.Exists(modLocaleDirectoryPath))
            {
                Directory.CreateDirectory(modLocaleDirectoryPath);
            }

            CreateDefaultLocaleFiles(modLocaleDirectoryPath);

            // 2. Create Submod Locale Files

            const string submodFolderName = "submods";

            string modSubmodDirectoryPath = Path.Combine(
                path1: homeDirectoryPath,
                path2: submodFolderName);

            if (!Directory.Exists(modSubmodDirectoryPath))
            {
                Directory.CreateDirectory(modSubmodDirectoryPath);
            }

            CreateSubmodLocaleFiles(modSubmodDirectoryPath);
        }

        private static void CreateDefaultLocaleFiles(string modLocaleDirectoryPath)
        {
            string[] modLocaleDefaultFileNames = GetDefaultLocaleFileNames();

            foreach (var defaultFileName in modLocaleDefaultFileNames)
            {
                string testFilePath = Path.Combine(path1: modLocaleDirectoryPath, path2: defaultFileName);

                if (!File.Exists(testFilePath))
                {
                    File.Create(testFilePath);
                }
            }
        }

        private static string[] GetDefaultLocaleFileNames()
        {
            const string testLocaleFileBaseName = "text_default_";
            const string testLocaleFileExtension = ".txt";
            const byte testLocaleFilesCount = 10;

            string[] testLocaleFileNames = new string[testLocaleFilesCount];

            for (byte fileIndex = 0; fileIndex < testLocaleFilesCount; fileIndex++)
            {
                testLocaleFileNames[fileIndex] = testLocaleFileBaseName + fileIndex.ToString() + testLocaleFileExtension;
            }

            return testLocaleFileNames;
        }

        private static void CreateSubmodLocaleFiles(string modSubmodDirectoryPath)
        {
            const string testLocaleFolderName_1 = "RU";
            const string testLocaleFolderName_2 = "EN";
            const string testLocaleFolderName_3 = "FR";
            const string testLocaleFolderName_4 = "SP";
            const string testLocaleFolderName_5 = "DE";

            const string testLocaleFileBaseName = "text_";
            const string testLocaleFileExtension = ".txt";
            const byte testLocaleFilesCount = 10;

            string[] testCustomLocaleFolderNames = new string[]
            {
                testLocaleFolderName_1,
                testLocaleFolderName_2,
                testLocaleFolderName_3,
                testLocaleFolderName_4,
                testLocaleFolderName_5
            };

            foreach (var customLocaleFolderName in testCustomLocaleFolderNames)
            {
                string customLocaleDirectoryPath = Path.Combine(
                    path1: modSubmodDirectoryPath,
                    path2: customLocaleFolderName);

                if (!Directory.Exists(customLocaleDirectoryPath))
                {
                    Directory.CreateDirectory(customLocaleDirectoryPath);
                }

                for (byte fileIndex = 0; fileIndex < testLocaleFilesCount; fileIndex++)
                {
                    string customLocaleFileName = testLocaleFileBaseName
                        + customLocaleFolderName
                        + "_" + fileIndex.ToString()
                        + testLocaleFileExtension;

                    string customLocaleFilePath = Path.Combine(
                        path1: customLocaleDirectoryPath,
                        path2: customLocaleFileName);

                    if (!File.Exists(customLocaleFilePath))
                    {
                        File.Create(customLocaleFilePath);
                    }
                }
            }
        }
    }

    //
}
