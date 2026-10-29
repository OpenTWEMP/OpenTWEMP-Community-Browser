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
}
