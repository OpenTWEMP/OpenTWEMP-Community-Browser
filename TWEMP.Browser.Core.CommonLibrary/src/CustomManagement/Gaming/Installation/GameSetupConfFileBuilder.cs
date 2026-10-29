// <copyright file="GameSetupConfFileBuilder.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;

using System.Text;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;

public class GameSetupConfFileBuilder
{
    public const string AppVersionMarkupElement = "ApplicationVersion";
    public const string GameSetupInfoMarkupElement = "GameSetupInfo";
    public const string GameSetupNameMarkupAttribute = "Name";
    public const string ExecutableMarkupElement = "Executable";
    public const string ModCenterMarkupParentElement = "AttachedModCenters";
    public const string ModCenterMarkupChildElement = "ModCenter";

    private const string OpeningTagFirstBrace = "<";
    private const string ClosingTagFirstBrace = "</";
    private const string TagLastBrace = ">";
    private const string AttributeValueAssignmentSymbol = "=";
    private const string AttributeValueSurroundSymbol = "\"";

    private const string ObsoleteStaticMethodMessage = "This static method will be removed in BETA 2027 release!";

    private const string ConfigFileBaseName = "setup";
    private const string ConfigFileExtension = ".conf";

    private const string DefaultConfigVersion = "BETA_2027";

    private GameSetupConfFileBuilder(string configDirectoryPath)
    {
        string configFileName = ConfigFileBaseName + ConfigFileExtension;
        ConfigFilePath = Path.Combine(configDirectoryPath, configFileName);
    }

    public string ConfigFilePath { get; }

    public record CustomConfigNode
    {
        public CustomConfigNode(string name, string executable, string[] modcenters)
        {
            Name = name;
            Executable = executable;
            ModCenters = modcenters;
        }

        public string Name { get; }
        public string Executable { get; }
        public string[] ModCenters { get; }
    }

    public static GameSetupConfFileBuilder Create() =>
        Create(Directory.GetCurrentDirectory());

    public static GameSetupConfFileBuilder Create(string configDirectoryPath) =>
        new GameSetupConfFileBuilder(configDirectoryPath);

    public static string GetConfigMetadataMarkupElement() =>
        $"{GetElementWithValue(AppVersionMarkupElement, DefaultConfigVersion)}\n";

    public static string GetSingleGameSetupInfoConfigMarkup(CustomConfigNode node)
    {
        string gameSetupInfoOpeningTag = GetGameSetupInfoOpeningTag(node.Name);
        string gameSetupInfoClosingTag = GetGameSetupInfoClosingTag();

        string executableMarkupElement = GetExecutableConfigMarkup(node.Executable);
        string modcentersMarkupElement = GetAttachedModCentersConfigMarkup(node.ModCenters);

        return $"{gameSetupInfoOpeningTag}\n" +
            $"{executableMarkupElement}\n" +
            $"{modcentersMarkupElement}\n" +
            $"{gameSetupInfoClosingTag}";

        static string GetExecutableConfigMarkup(string executableFilePath) =>
            $"\t{GetExecutableMarkupElement(executableFilePath)}";

        static string GetAttachedModCentersConfigMarkup(string[] modcenters)
        {
            string markup = $"\t{GetModCenterParentOpeningTag()}\n";

            foreach (string modcenter in modcenters)
            {
                string element = GetModCenterMarkupChildElement(modcenter);
                markup += $"\t\t{element}\n";
            }

            markup += $"\t{GetModCenterParentClosingTag()}";

            return markup;
        }
    }

    public static string GetMultipleGameSetupInfoConfigMarkup(CustomConfigNode[] configNodes)
    {
        string markup = string.Empty;

        foreach (CustomConfigNode node in configNodes)
        {
            string nodeMarkup = GetSingleGameSetupInfoConfigMarkup(node);
            markup += $"{nodeMarkup}\n";
        }

        return markup;
    }

    public static string GetConfigMarkupOpeningTag(string element) =>
        $"{OpeningTagFirstBrace}{element}{TagLastBrace}";

    public static string GetConfigMarkupClosingTag(string element) =>
        $"{ClosingTagFirstBrace}{element}{TagLastBrace}";

    public static string GetGameSetupInfoOpeningTag(string gameSetupName)
    {
        string gameSetupNameAttribute = GetAttribute(GameSetupNameMarkupAttribute, gameSetupName);
        string gameSetupInfoElement = $"{GameSetupInfoMarkupElement} {gameSetupNameAttribute}";

        return GetConfigMarkupOpeningTag(gameSetupInfoElement);
    }

    public static string GetGameSetupInfoClosingTag() =>
        GetConfigMarkupClosingTag(GameSetupInfoMarkupElement);

    public static string GetExecutableMarkupElement(string executableFilePath) =>
        GetElementWithValue(ExecutableMarkupElement, executableFilePath);

    public static string GetModCenterParentOpeningTag() =>
        GetConfigMarkupOpeningTag(ModCenterMarkupParentElement);

    public static string GetModCenterParentClosingTag() =>
        GetConfigMarkupClosingTag(ModCenterMarkupParentElement);

    public static string GetModCenterMarkupChildElement(string modcenterDirectoryPath) =>
        GetElementWithValue(ModCenterMarkupChildElement, modcenterDirectoryPath);

    private static string GetElementWithValue(string elemName, string elemValue) =>
        $"{GetConfigMarkupOpeningTag(elemName)}{elemValue}{GetConfigMarkupClosingTag(elemName)}";

    private static string GetAttribute(string attributeName, string attributeValue) =>
        $"{attributeName}{AttributeValueAssignmentSymbol}" +
            $"{AttributeValueSurroundSymbol}{attributeValue}{AttributeValueSurroundSymbol}";

    [Obsolete(ObsoleteStaticMethodMessage)]
    public static string GetSetupConfFileName() => Create().ConfigFilePath;

    public static List<GameSetupInfo> ReadAllSetupConfFile(string setupConfFileName)
    {
        var readGameSetupObjects = new List<GameSetupInfo>();

        string setupElemEntryBeg = "<GameSetupInfo Name=\"";
        string setupElemEntryEnd = "\">";

        string[] readDataStrings = File.ReadAllLines(setupConfFileName, Encoding.UTF8);

        // 1. Define GameSetupInfo objects coordinates into the config file via indexes.
        var gameSetupObjectsStartEntryIndexes = new List<int>();
        for (int index = 0; index < readDataStrings.Length; index++)
        {
            if (readDataStrings[index].StartsWith(setupElemEntryBeg))
            {
                gameSetupObjectsStartEntryIndexes.Add(index);
            }
        }

        // 2. Read GameSetupInfo objects from the config file by detected coordinates.
        for (int entryIndex = 0; entryIndex < gameSetupObjectsStartEntryIndexes.Count; entryIndex++)
        {
            int begEntryIndex = gameSetupObjectsStartEntryIndexes[entryIndex];

            int endEntryIndex;
            if (entryIndex == (gameSetupObjectsStartEntryIndexes.Count - 1))
            {
                // We don't know the end entry index of the last GameSetupInfo object.
                endEntryIndex = readDataStrings.Length - 1;
            }
            else
            {
                // We know the begin entry index of the next GameSetupInfo object.
                endEntryIndex = gameSetupObjectsStartEntryIndexes[entryIndex + 1];
            }

            // 3. Read the GameSetupInfo object.

            // 3.1. 'Name'
            string gameSetupName = readDataStrings[begEntryIndex];
            gameSetupName = gameSetupName.Replace(setupElemEntryBeg, string.Empty);
            gameSetupName = gameSetupName.Replace(setupElemEntryEnd, string.Empty);

            var executableFullPath = string.Empty;
            var attachedModCenters = new List<string>();

            for (int dataIndex = begEntryIndex; dataIndex < endEntryIndex; dataIndex++)
            {
                string data = readDataStrings[dataIndex].TrimStart();

                // 3.2. 'Executable'
                string executableElemEntryBeg = "<Executable>";
                string executableElemEntryEnd = "</Executable>";

                if (data.StartsWith(executableElemEntryBeg) && data.EndsWith(executableElemEntryEnd))
                {
                    executableFullPath = data.Replace(executableElemEntryBeg, string.Empty);
                    executableFullPath = executableFullPath.Replace(executableElemEntryEnd, string.Empty);
                    continue;
                }

                // 3.3. 'AttachedModCenters'
                string modcenterElemEntryBeg = "<ModCenter>";
                string modcenterElemEntryEnd = "</ModCenter>";

                if (data.StartsWith(modcenterElemEntryBeg) && data.EndsWith(modcenterElemEntryEnd))
                {
                    string modcenter = data.Replace(modcenterElemEntryBeg, string.Empty);
                    modcenter = modcenter.Replace(modcenterElemEntryEnd, string.Empty);

                    attachedModCenters.Add(modcenter);
                }
            }

            // 4. Generate a new GameSetupInfo object.
            GameSetupInfo gameSetupInfo = GameSetupInfo.Create(gameSetupName, executableFullPath, attachedModCenters);
            readGameSetupObjects.Add(gameSetupInfo);
        }

        return readGameSetupObjects;
    }
}
