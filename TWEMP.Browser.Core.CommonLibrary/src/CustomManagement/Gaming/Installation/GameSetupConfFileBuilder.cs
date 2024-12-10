// <copyright file="GameSetupConfFileBuilder.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;

using System.Text;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;

internal static class GameSetupConfFileBuilder
{
    internal static string GetSetupConfFileName()
    {
        string cfgFileExtension = ".conf";
        string cfgFileBaseName = "setup";

        string cfgFilename = cfgFileBaseName + cfgFileExtension;
        string cfgFileLocation = Directory.GetCurrentDirectory();

        return Path.Combine(cfgFileLocation, cfgFilename);
    }

    internal static void WriteNewSetupToConfFile(
        string setupConfFileName, string setupName, string executableFullPath, List<string> modcenterPaths)
    {
        var writer = new StreamWriter(setupConfFileName, true, Encoding.UTF8);

        string gameSetupElemName = "GameSetupInfo";
        string gameSetupNameAttrKey = "Name";
        string gameSetupNameAttrValue = setupName;
        string gameSetupNamePairAttribute = gameSetupNameAttrKey + "=\"" + gameSetupNameAttrValue + "\"";
        string gameSetupBegTag = "<" + gameSetupElemName + " " + gameSetupNamePairAttribute + ">";
        string gameSetupEndTag = "</" + gameSetupElemName + ">";

        string executableElemName = "Executable";
        string executableBegTag = "<" + executableElemName + ">";
        string executableEndTag = "</" + executableElemName + ">";
        string executableElemValue = executableFullPath;
        string executableElement = executableBegTag + executableElemValue + executableEndTag;

        string modcentersElemName = "AttachedModCenters";
        string modcentersBegTag = "<" + modcentersElemName + ">";
        string modcentersEndTag = "</" + modcentersElemName + ">";
        string modCenterElemName = "ModCenter";
        string modCenterBegTag = "<" + modCenterElemName + ">";
        string modCenterEndTag = "</" + modCenterElemName + ">";
        List<string> modCenterElements = new ();
        foreach (string modcenter in modcenterPaths)
        {
            string modCenterElement = modCenterBegTag + modcenter + modCenterEndTag;
            modCenterElements.Add(modCenterElement);
        }

        writer.WriteLine(gameSetupBegTag);
        writer.WriteLine("   {0}", executableElement);
        writer.WriteLine("   {0}", modcentersBegTag);
        foreach (string modCenter in modCenterElements)
        {
            writer.WriteLine("      {0}", modCenter);
        }

        writer.WriteLine("   {0}", modcentersEndTag);
        writer.WriteLine(gameSetupEndTag);

        writer.Close();
    }

    internal static bool ShouldGameSetupConfFileBeCreated(string setupConfFileName)
    {
        if (File.Exists(setupConfFileName))
        {
            return false;
        }

        return true;
    }

    internal static uint ReadTotalGameSetupCount(string setupConfFileName)
    {
        string[] readDataStrings = File.ReadAllLines(setupConfFileName, Encoding.UTF8);

        uint totalGameSetupCount = 0;
        string gameSetupObjectMarker = "<GameSetupInfo";

        for (int i = 0; i < readDataStrings.Length; i++)
        {
            if (readDataStrings[i].StartsWith(gameSetupObjectMarker))
            {
                totalGameSetupCount++;
            }
        }

        return totalGameSetupCount;
    }

    internal static List<GameSetupInfo> ReadAllSetupConfFile(string setupConfFileName)
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

    internal static void DeleteGameSetupFromConfFile(GameSetupInfo gameSetupInfo, string setupConfFileName)
    {
        // 1. Read all GameSetupInfo objects as an array of strings.
        string[] allReadData = File.ReadAllLines(setupConfFileName, Encoding.UTF8);

        // 2. Find the begin of the target GameSetupInfo object.
        int gameSetupObjectBegIndex = 0;
        string gameSetupElemBeg = "<GameSetupInfo Name=\"";
        string gameSetupElemEnd = "\">";
        string gameSetupOpeningTag = gameSetupElemBeg + gameSetupInfo.Name + gameSetupElemEnd;

        for (int i = 0; i < allReadData.Length; i++)
        {
            if (allReadData[i].StartsWith(gameSetupOpeningTag))
            {
                gameSetupObjectBegIndex = i;
                break;
            }
        }

        // 3. Find the end of the target GameSetupInfo object.
        int gameSetupObjectEndIndex = gameSetupObjectBegIndex;
        string gameSetupClosingTag = "</GameSetupInfo>";

        for (int j = gameSetupObjectBegIndex; j < allReadData.Length; j++)
        {
            if (allReadData[j].StartsWith(gameSetupClosingTag))
            {
                gameSetupObjectEndIndex = j;
                break;
            }
        }

        // 4. Update data about GameSetupInfo objects via deleting target GameSetupInfo object's data.
        var updatedDataStrings = new List<string>();

        for (int index = 0; index < allReadData.Length; index++)
        {
            bool moreOrEqualBegIndex = index >= gameSetupObjectBegIndex;
            bool lessOrEqualEndIndex = index <= gameSetupObjectEndIndex;

            if (moreOrEqualBegIndex && lessOrEqualEndIndex)
            {
                continue;
            }

            updatedDataStrings.Add(allReadData[index]);
        }

        // 5. Rewrite updated data to the configuration file.
        var writer = new StreamWriter(setupConfFileName, false, Encoding.UTF8);

        foreach (var dataString in updatedDataStrings)
        {
            writer.WriteLine(dataString);
        }

        writer.Close();
    }

    internal static void CreateSetupConfFile(string setupConfFileName)
    {
        var stream = new FileStream(setupConfFileName, FileMode.CreateNew);
        var writer = new StreamWriter(stream, Encoding.UTF8);

        string rootElementName = "ApplicationVersion";
        string elemBegTag = "<" + rootElementName + ">";
        string elemEndTag = "</" + rootElementName + ">";

        writer.WriteLine($"{elemBegTag}{rootElementName}{elemEndTag}"); // paste config version

        writer.Close();
        stream.Close();
    }
}
