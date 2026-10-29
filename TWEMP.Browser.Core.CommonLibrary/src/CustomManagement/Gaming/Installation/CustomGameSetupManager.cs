// <copyright file="CustomGameSetupManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

#define LEGACY_XML_SERIALIZATION
#define MODERN_JSON_SERIALIZATION
#undef MODERN_JSON_SERIALIZATION

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;

using System.Text;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;
using TWEMP.Browser.Core.CommonLibrary.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

/// <summary>
/// Represents a device to manage custom game setup installations into the application.
/// </summary>
public class CustomGameSetupManager
{
    private const string ObsoleteMethodMessage = "This method will be removed in BETA 2027 release!";

    private const string ConfigFileName = "setup.json";

    private readonly string gameSetupConfigFilePath;

    private CustomGameSetupManager()
    {
#if LEGACY_XML_SERIALIZATION
        this.gameSetupConfigFilePath = GameSetupConfFileBuilder.GetSetupConfFileName();
#endif

#if MODERN_JSON_SERIALIZATION
        this.gameSetupConfigFilePath = Path.Combine(Directory.GetCurrentDirectory(), ConfigFileName);
#endif

        this.GameInstallations = new List<GameSetupInfo>();
        this.TotalModificationsList = new List<GameModificationInfo>();
    }

    /// <summary>
    /// Gets user's game setup installations.
    /// </summary>
    public List<GameSetupInfo> GameInstallations { get; private set; }

    /// <summary>
    /// Gets all game modifications from user's game setup installations.
    /// </summary>
    public List<GameModificationInfo> TotalModificationsList { get; private set; }

    /// <summary>
    /// Creates a custom instance of the <see cref="CustomGameSetupManager"/> class.
    /// </summary>
    /// <returns>Instance of the <see cref="CustomGameSetupManager"/> class.</returns>
    public static CustomGameSetupManager Create()
    {
        return new CustomGameSetupManager();
    }

    public GameSetupInfo RegistrateGameInstallation(string setupName, string executableFullPath, List<string> modcenterPaths)
    {
#if LEGACY_XML_SERIALIZATION
        this.SaveNewGameSetupConfig(setupName, executableFullPath, modcenterPaths.ToArray());
#endif

        GameSetupInfo gameSetupInfo = GameSetupInfo.Create(setupName, executableFullPath, modcenterPaths);
        this.GameInstallations.Add(gameSetupInfo);

#if MODERN_JSON_SERIALIZATION
        this.WriteGameSetupObjectsToConfigFile(this.GameInstallations);
#endif

        return gameSetupInfo;
    }

    public List<GameSetupInfo> SynchronizeGameSetupSettings()
    {
#if LEGACY_XML_SERIALIZATION
        if (this.ShouldGameSetupConfigFileBeCreated())
        {
            this.CreateSetupConfigFile();
        }
        else
        {
            if (this.GameInstallations.Count == 0)
            {
                int gameSetupObjectsCount = this.ReadTotalGameSetupCount();

                if (gameSetupObjectsCount > 0)
                {
                    GameSetupInfo[] gameSetupObjects = this.ReadAllSetupConfFile();
                    this.GameInstallations.AddRange(gameSetupObjects);
                }
            }
        }
#endif

#if MODERN_JSON_SERIALIZATION
        this.GameInstallations = this.ReadGameSetupObjectsFromConfigFile();
#endif

        return this.GameInstallations;
    }

    public void DeleteGameSetupByIndex(int gameSetupIndex)
    {
#if LEGACY_XML_SERIALIZATION
        GameSetupInfo gameSetupInfo = this.GameInstallations[gameSetupIndex];
        this.DeleteGameSetupFromConfFile(gameSetupInfo);
#endif

        this.GameInstallations.RemoveAt(gameSetupIndex);

#if MODERN_JSON_SERIALIZATION
        this.WriteGameSetupObjectsToConfigFile(this.GameInstallations);
#endif
    }

    public void UpdateTotalModificationsList()
    {
        this.TotalModificationsList.Clear();

        foreach (var installation in this.GameInstallations)
        {
            List<GameModificationInfo> mods = installation.GetInstalledMods();
            this.TotalModificationsList.AddRange(mods);
        }
    }

    public GameModificationInfo GetActiveModificationInfo(string modShortName)
    {
        foreach (GameModificationInfo modInfo in this.TotalModificationsList)
        {
            if (modInfo.ShortName.Equals(modShortName))
            {
                return modInfo;
            }
        }

        return null!;
    }

    public void ClearAllSettings()
    {
        this.TotalModificationsList.Clear();
        this.GameInstallations.Clear();

        if (File.Exists(this.gameSetupConfigFilePath))
        {
            File.Delete(this.gameSetupConfigFilePath);

#if LEGACY_XML_SERIALIZATION
            this.CreateSetupConfigFile();
#endif
        }
    }

#if MODERN_JSON_SERIALIZATION
    private List<GameSetupInfo> ReadGameSetupObjectsFromConfigFile()
    {
        List<GameSetupInfo> gameSetupObjects = new ();

        GameSetupView[] gameSetupViews = AppSerializer.DeserializeFromJson<GameSetupView[]>(this.gameSetupConfigFilePath);

        foreach (GameSetupView view in gameSetupViews)
        {
            GameSetupInfo gameSetupInfo = GameSetupInfo.Create(view);
            gameSetupObjects.Add(gameSetupInfo);
        }

        return gameSetupObjects;
    }

    private void WriteGameSetupObjectsToConfigFile(ICollection<GameSetupInfo> gameSetupObjects)
    {
        List<GameSetupView> gameSetupViews = new ();

        foreach (GameSetupInfo gameSetupInfo in gameSetupObjects)
        {
            gameSetupViews.Add(new GameSetupView(gameSetupInfo));
        }

        AppSerializer.SerializeToJson(gameSetupViews, this.gameSetupConfigFilePath);
    }
#endif

#if LEGACY_XML_SERIALIZATION

    private static bool IsGameSetupCfgNode(string cfgStr)
    {
        const string begCfgSubStr = "<GameSetupInfo Name=\"";
        const string endCfgSubStr = "\">";

        return cfgStr.StartsWith(begCfgSubStr) && cfgStr.EndsWith(endCfgSubStr);
    }

    [Obsolete(ObsoleteMethodMessage)]
    private void SaveNewGameSetupConfig(string name, string executable, string[] modcenters)
    {
        var cfgNode = new GameSetupConfFileBuilder.CustomConfigNode(name, executable, modcenters);
        string cfgMarkup = GameSetupConfFileBuilder.GetSingleGameSetupInfoConfigMarkup(cfgNode);

        using (var sw = new StreamWriter(this.gameSetupConfigFilePath, true, Encoding.UTF8))
        {
            sw.WriteLine(cfgMarkup);
        }
    }

    [Obsolete(ObsoleteMethodMessage)]
    private bool ShouldGameSetupConfigFileBeCreated()
    {
        if (File.Exists(this.gameSetupConfigFilePath))
        {
            return false;
        }

        return true;
    }

    [Obsolete(ObsoleteMethodMessage)]
    private void CreateSetupConfigFile()
    {
        string metadataCfgNodeMarkup = GameSetupConfFileBuilder.GetConfigMetadataMarkupElement();
        File.WriteAllText(this.gameSetupConfigFilePath, metadataCfgNodeMarkup, Encoding.UTF8);
    }

    [Obsolete(ObsoleteMethodMessage)]
    private int ReadTotalGameSetupCount()
    {
        int totalGameSetupCount = 0;

        string[] cfgStrArr = File.ReadAllLines(this.gameSetupConfigFilePath, Encoding.UTF8);

        foreach (string cfgStr in cfgStrArr)
        {
            if (IsGameSetupCfgNode(cfgStr))
            {
                totalGameSetupCount++;
            }
        }

        return totalGameSetupCount;
    }

    [Obsolete(ObsoleteMethodMessage)]
    private GameSetupInfo[] ReadAllSetupConfFile()
    {
        string executableCfgMarkupElementBegTag = GameSetupConfFileBuilder.GetConfigMarkupOpeningTag(
            GameSetupConfFileBuilder.ExecutableMarkupElement);
        string executableCfgMarkupElementEndTag = GameSetupConfFileBuilder.GetConfigMarkupClosingTag(
            GameSetupConfFileBuilder.ExecutableMarkupElement);

        string modcenterCfgMarkupElementBegTag = GameSetupConfFileBuilder.GetConfigMarkupOpeningTag(
            GameSetupConfFileBuilder.ModCenterMarkupChildElement);
        string modcenterCfgMarkupElementEndTag = GameSetupConfFileBuilder.GetConfigMarkupClosingTag(
            GameSetupConfFileBuilder.ModCenterMarkupChildElement);

        string[] configStrings = File.ReadAllLines(this.gameSetupConfigFilePath, Encoding.UTF8);

        return RetrieveAllGameSetupInfoObjectsFromCfgMarkup(configStrings);

        GameSetupInfo[] RetrieveAllGameSetupInfoObjectsFromCfgMarkup(string[] cfgStrArr)
        {
            var gameSetupInfoObjects = new List<GameSetupInfo>();

            int[] gameSetupObjectsStartEntryIndexes = FindGameSetupCfgNodeStartIndexes(cfgStrArr);

            for (int entryIndex = 0; entryIndex < gameSetupObjectsStartEntryIndexes.Length; entryIndex++)
            {
                int begEntryIndex = gameSetupObjectsStartEntryIndexes[entryIndex];

                int endEntryIndex = FindGameSetupCfgNodeEndIndex(
                    cfgStrArr.Length, gameSetupObjectsStartEntryIndexes, entryIndex);

                GameSetupInfo gameSetupInfo = RetrieveGameSetupInfoObjectFromCfgMarkup(
                    cfgStrArr, begEntryIndex, endEntryIndex);

                gameSetupInfoObjects.Add(gameSetupInfo);
            }

            return gameSetupInfoObjects.ToArray();
        }

        static int[] FindGameSetupCfgNodeStartIndexes(string[] cfgStrArr)
        {
            var targetIndexes = new List<int>();

            for (int index = 0; index < cfgStrArr.Length; index++)
            {
                if (IsGameSetupCfgNode(cfgStrArr[index]))
                {
                    targetIndexes.Add(index);
                }
            }

            return targetIndexes.ToArray();
        }

        int FindGameSetupCfgNodeEndIndex(
            int cfgStrArrLen, int[] gameSetupCfgNodeStartIndexes, int gameSetupCfgNodeCurrentIndex)
        {
            int targetIndex;

            if (gameSetupCfgNodeCurrentIndex == (gameSetupCfgNodeStartIndexes.Length - 1))
            {
                // We don't know the end entry index of the last GameSetupInfo object.
                targetIndex = cfgStrArrLen - 1;
            }
            else
            {
                // We know the begin entry index of the next GameSetupInfo object.
                targetIndex = gameSetupCfgNodeStartIndexes[gameSetupCfgNodeCurrentIndex + 1];
            }

            return targetIndex;
        }

        bool IsExecutableCfgMarkupElement(string cfgStr) =>
            cfgStr.StartsWith(executableCfgMarkupElementBegTag) &&
            cfgStr.EndsWith(executableCfgMarkupElementEndTag);

        bool IsModCenterCfgMarkupChildElement(string cfgStr) =>
            cfgStr.StartsWith(modcenterCfgMarkupElementBegTag) &&
            cfgStr.EndsWith(modcenterCfgMarkupElementEndTag);

        GameSetupInfo RetrieveGameSetupInfoObjectFromCfgMarkup(
            string[] cfgStrArr, int cfgNodeStartIndex, int cfgNodeEndIndex)
        {
            string gameSetupName = RetrieveGameSetupCfgMarkupElementValue(configStrings[cfgNodeStartIndex]);

            string executableFullPath = string.Empty;
            var attachedModCenters = new List<string>();

            for (int dataIndex = cfgNodeStartIndex; dataIndex < cfgNodeEndIndex; dataIndex++)
            {
                string data = cfgStrArr[dataIndex].TrimStart();

                if (IsExecutableCfgMarkupElement(data))
                {
                    executableFullPath = RetrieveExecutableCfgMarkupElementValue(data);
                    continue;
                }

                if (IsModCenterCfgMarkupChildElement(data))
                {
                    string modcenter = RetrieveModCenterCfgMarkupChildElementValue(data);
                    attachedModCenters.Add(modcenter);
                }
            }

            return GameSetupInfo.Create(gameSetupName, executableFullPath, attachedModCenters);
        }

        string RetrieveGameSetupCfgMarkupElementValue(string cfgStr)
        {
            const string gameSetupOpeningTagBeg =
                $"<{GameSetupConfFileBuilder.GameSetupInfoMarkupElement} " +
                $"{GameSetupConfFileBuilder.GameSetupNameMarkupAttribute}=\"";
            const string gameSetupOpeningTagEnd = "\">";

            return cfgStr
                .Replace(gameSetupOpeningTagBeg, string.Empty)
                .Replace(gameSetupOpeningTagEnd, string.Empty);
        }

        string RetrieveExecutableCfgMarkupElementValue(string cfgStr) => cfgStr
            .Replace(executableCfgMarkupElementBegTag, string.Empty)
            .Replace(executableCfgMarkupElementEndTag, string.Empty);

        string RetrieveModCenterCfgMarkupChildElementValue(string cfgStr) => cfgStr
            .Replace(modcenterCfgMarkupElementBegTag, string.Empty)
            .Replace(modcenterCfgMarkupElementEndTag, string.Empty);
    }

    [Obsolete(ObsoleteMethodMessage)]
    private void DeleteGameSetupFromConfFile(GameSetupInfo gameSetupInfo)
    {
        string[] initialCfgStrArr = File.ReadAllLines(this.gameSetupConfigFilePath, Encoding.UTF8);

        int gameSetupCfgNodeStartIndex = FindGameSetupCfgNodeStartIndex(initialCfgStrArr, gameSetupInfo.Name);
        int gameSetupCfgNodeEndIndex = FindGameSetupCfgNodeEndIndex(initialCfgStrArr, gameSetupCfgNodeStartIndex);

        string[] updatedCfgStrArr = ExcludeGameSetupCfgNodeFromConfigStrings(
            initialCfgStrArr, gameSetupCfgNodeStartIndex, gameSetupCfgNodeEndIndex);

        File.WriteAllLines(this.gameSetupConfigFilePath, updatedCfgStrArr, Encoding.UTF8);

        static int FindGameSetupCfgNodeStartIndex(string[] srcCfgStrArr, string destGameSetupName)
        {
            int targetCfgNodeIndex = 0;

            string gameSetupOpeningTag = GameSetupConfFileBuilder.GetGameSetupInfoOpeningTag(destGameSetupName);

            for (int cfgStrIndex = 0; cfgStrIndex < srcCfgStrArr.Length; cfgStrIndex++)
            {
                if (srcCfgStrArr[cfgStrIndex].StartsWith(gameSetupOpeningTag))
                {
                    targetCfgNodeIndex = cfgStrIndex;
                    break;
                }
            }

            return targetCfgNodeIndex;
        }

        static int FindGameSetupCfgNodeEndIndex(string[] srcCfgStrArr, int destGameSetupStartIndex)
        {
            int targetCfgNodeIndex = destGameSetupStartIndex;

            string gameSetupClosingTag = GameSetupConfFileBuilder.GetGameSetupInfoClosingTag();

            for (int cfgStrIndex = destGameSetupStartIndex; cfgStrIndex < srcCfgStrArr.Length; cfgStrIndex++)
            {
                if (srcCfgStrArr[cfgStrIndex].StartsWith(gameSetupClosingTag))
                {
                    targetCfgNodeIndex = cfgStrIndex;
                    break;
                }
            }

            return targetCfgNodeIndex;
        }

        static string[] ExcludeGameSetupCfgNodeFromConfigStrings(
            string[] srcCfgStrArr, int destGameSetupStartIndex, int destGameSetupEndIndex)
        {
            var updatedConfigStrArr = new List<string>();

            for (int index = 0; index < srcCfgStrArr.Length; index++)
            {
                bool moreOrEqualBegIndex = index >= destGameSetupStartIndex;
                bool lessOrEqualEndIndex = index <= destGameSetupEndIndex;

                if (moreOrEqualBegIndex && lessOrEqualEndIndex)
                {
                    continue;
                }

                updatedConfigStrArr.Add(srcCfgStrArr[index]);
            }

            return updatedConfigStrArr.ToArray();
        }
    }

#endif
}
