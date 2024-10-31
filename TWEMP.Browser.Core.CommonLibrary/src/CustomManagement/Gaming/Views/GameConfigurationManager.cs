// <copyright file="GameConfigurationManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;
using TWEMP.Browser.Core.CommonLibrary.Serialization;

/// <summary>
/// Represents a device to manage game configuration profiles.
/// </summary>
public class GameConfigurationManager
{
    private const string UserProfilesConfigFileName = "configuration_profiles.json";

    private readonly CustomGameSetupManager gameSetupManager;

    private readonly GameSupportProvider gameSupportProviderByDefault;

    private readonly FileInfo userProfilesConfigFileInfo;

    private List<GameConfigProfileView> gameConfigProfileViews;

    private GameConfigurationManager(CustomGameSetupManager gameSetupManager)
    {
        this.gameSetupManager = gameSetupManager;

        this.gameSupportProviderByDefault = new GameSupportProvider(GameEngineSupportType.M2TW);

        string path = Path.Combine(Directory.GetCurrentDirectory(), UserProfilesConfigFileName);
        this.userProfilesConfigFileInfo = new FileInfo(path);

        if (this.userProfilesConfigFileInfo.Exists)
        {
            this.gameConfigProfileViews = this.ReadAllGameConfigProfileViews();
        }
        else
        {
            this.gameConfigProfileViews = CreateGameConfigProfileViewsByDefault(this.gameSetupManager.TotalModificationsList);
            this.WriteAllGameConfigProfileViews(this.gameConfigProfileViews);
        }

        this.AvailableProfiles = GetGameConfigProfilesByViews(
            gameConfigProfileViews: this.gameConfigProfileViews,
            gameMods: this.gameSetupManager.TotalModificationsList,
            provider: this.gameSupportProviderByDefault);

        this.CurrentGameModView = null;
        this.CurrentConfigProfile = null;
        this.CurrentConfigurator = null;
    }

    /// <summary>
    /// Gets available game configuration profiles.
    /// </summary>
    public List<GameConfigProfile> AvailableProfiles { get; private set; }

    /// <summary>
    /// Gets or sets the current game modification view for creation a game configuration.
    /// </summary>
    public UpdatableGameModificationView? CurrentGameModView { get; set; }

    /// <summary>
    /// Gets or sets the current game configuration profile for the selected game modification.
    /// </summary>
    public GameConfigProfile? CurrentConfigProfile { get; set; }

    /// <summary>
    /// Gets or sets the current game configurator agent.
    /// </summary>
    public IGameConfiguratorAgent? CurrentConfigurator { get; set; }

    /// <summary>
    /// Creates a custom instance of the <see cref="GameConfigurationManager"/> class.
    /// </summary>
    /// <param name="gameSetupManager">The instance of the <see cref="CustomGameSetupManager"/> class.</param>
    /// <returns>Instance of the <see cref="GameConfigurationManager"/> class.</returns>
    public static GameConfigurationManager Create(CustomGameSetupManager gameSetupManager)
    {
        return new GameConfigurationManager(gameSetupManager);
    }

    /// <summary>
    /// Gets a light-weight entity view for a game configuration profiles array for UI controls.
    /// </summary>
    /// <param name="gameConfigProfiles">The array of game configuration profiles.</param>
    /// <returns>
    /// A dictionary object where
    /// the key represents the UI control's item index, and
    /// the value is game configuration profile's ID.
    /// </returns>
    public static Dictionary<int, Guid> GetConfigProfilesToDisplay(GameConfigProfile[] gameConfigProfiles)
    {
        Dictionary<int, Guid> gameConfigProfilesDictionary = new ();

        for (int index = 0; index < gameConfigProfiles.Length; index++)
        {
            gameConfigProfilesDictionary.Add(key: index, value: gameConfigProfiles[index].Id);
        }

        return gameConfigProfilesDictionary;
    }

    /// <summary>
    /// Exports configuration settings to a target file.
    /// </summary>
    /// <param name="cfgSettingSections">The array of config settings.</param>
    /// <param name="exportFilePath">The export file path.</param>
    public static void ExportConfigSettingsToFile(GameCfgSection[] cfgSettingSections, string exportFilePath)
    {
        GameConfigOptionView[] gameConfigOptionViews = GetConfigOptionsBySections(cfgSettingSections);
        AppSerializer.SerializeToJson(gameConfigOptionViews, exportFilePath);
    }

    /// <summary>
    ///  Imports configuration settings from a target file.
    /// </summary>
    /// <param name="importFilePath">The import file path.</param>
    /// <returns>The array of config settings.</returns>
    public static GameCfgSection[] ImportConfigSettingsFromFile(string importFilePath)
    {
        GameCfgSection[] gameConfigSections;

        try
        {
            var gameConfigOptionViews = AppSerializer.DeserializeFromJson<GameConfigOptionView[]>(importFilePath);
            gameConfigSections = GetSectionsOfConfigOptions(gameConfigOptionViews);
        }
        catch (InvalidOperationException)
        {
            gameConfigSections = Array.Empty<GameCfgSection>();
        }

        return gameConfigSections;
    }

    /// <summary>
    /// Gets game config profile items for UI controls by game config profile views.
    /// </summary>
    /// <param name="viewOfGameConfigProfiles">A dictionary of game config profile views.</param>
    /// <returns>The array of game config profile items.</returns>
    public object[] GetNewConfigProfileItems(Dictionary<int, Guid> viewOfGameConfigProfiles)
    {
        object[] gameConfigProfileItems = new object[viewOfGameConfigProfiles.Count];

        for (int itemIndex = 0; itemIndex < gameConfigProfileItems.Length; itemIndex++)
        {
            Guid gameConfigProfileId = viewOfGameConfigProfiles[itemIndex];
            GameConfigProfile gameConfigProfile = this.SelectProfileById(gameConfigProfileId);

            gameConfigProfileItems[itemIndex] = gameConfigProfile.Name;
        }

        return gameConfigProfileItems;
    }

    /// <summary>
    /// Gets all available game configuration profiles for a target game modification.
    /// </summary>
    /// <param name="gameModView">The view entity for a target game modification.</param>
    /// <returns>The array of game configuration profiles.</returns>
    public GameConfigProfile[] GetAllConfigProfilesForSelectedGameMod(UpdatableGameModificationView gameModView)
    {
        List<GameConfigProfile> gameConfigProfiles = new List<GameConfigProfile>();

        string targetGameModLocation = gameModView.CurrentInfo.Location;

        foreach (GameConfigProfile gameConfigProfile in this.AvailableProfiles)
        {
            string currentGameModLocation = gameConfigProfile.TargetGameModInfo.Location;

            if (currentGameModLocation.Equals(targetGameModLocation))
            {
                gameConfigProfiles.Add(gameConfigProfile);
            }
        }

        return gameConfigProfiles.ToArray();
    }

    /// <summary>
    /// Creates a new game configuration profile.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    /// <param name="state">A target custom game configuration state.</param>
    public void CreateNewProfile(GameSupportProvider provider, GameModificationInfo info, ICustomConfigState state)
    {
        GameConfigProfile profile = new (provider, info, state);
        this.AvailableProfiles.Add(profile);

        this.SynchronizeGameConfigProfileViews();
    }

    /// <summary>
    /// Creates a new game configuration profile via copying an existing game configuration profile.
    /// </summary>
    /// <param name="profileTemplate">A template game configuration profile.</param>
    public void CopyProfile(GameConfigProfile profileTemplate)
    {
        Guid profileId = this.CreateNewIdForGameConfigProfile(profileTemplate);
        GameConfigProfile profile = new (profileId, profileTemplate);
        this.AvailableProfiles.Add(profile);

        this.SynchronizeGameConfigProfileViews();
    }

    /// <summary>
    /// Selects an existing game configuration profile by its GUID.
    /// </summary>
    /// <param name="id">The GUID of a target game configuration profile.</param>
    /// <returns>A target instanse of the <see cref="GameConfigProfile"/> class.</returns>
    public GameConfigProfile SelectProfileById(Guid id)
    {
        foreach (GameConfigProfile profile in this.AvailableProfiles)
        {
            if (profile.Id.Equals(id))
            {
                return profile;
            }
        }

        return CreateEmptyProfile();
    }

    /// <summary>
    /// Updates an existing game configuration profile.
    /// </summary>
    /// <param name="id">The GUID of an existing game configuration profile.</param>
    /// <param name="name">A new name of an existing game configuration profile.</param>
    /// <param name="state">A new state of an existing game configuration profile.</param>
    public void UpdateProfile(Guid id, string name, GameConfigState state)
    {
        GameConfigProfile profile = this.SelectProfileById(id);

        profile.Name = name;
        profile.ConfigState = state;

        this.SynchronizeGameConfigProfileViews();
    }

    /// <summary>
    /// Deletes an existing game configuration profile.
    /// </summary>
    /// <param name="id">The GUID of an existing game configuration profile.</param>
    public void DeleteProfile(Guid id)
    {
        GameConfigProfile profile = this.SelectProfileById(id);
        this.AvailableProfiles.Remove(profile);

        this.SynchronizeGameConfigProfileViews();
    }

    /// <summary>
    /// Deletes all existing game configuration profiles.
    /// </summary>
    public void DeleteAllProfiles()
    {
        this.AvailableProfiles.Clear();
        this.SynchronizeGameConfigProfileViews();
    }

    /// <summary>
    /// Exports all available game configuration profiles to a target file.
    /// </summary>
    /// <param name="exportFilePath">The export file path.</param>
    public void ExportAllProfilesToFile(string exportFilePath)
    {
        ExportGameConfigProfileViewsToFile(this.gameConfigProfileViews, exportFilePath);
    }

    /// <summary>
    ///  Imports game configuration profiles from a target file.
    /// </summary>
    /// <param name="importFilePath">The import file path.</param>
    public void ImportAllProfilesFromFile(string importFilePath)
    {
        try
        {
            GameConfigProfileView[] importedGameConfigProfileViews =
                AppSerializer.DeserializeFromJson<GameConfigProfileView[]>(importFilePath);

            foreach (GameConfigProfileView view in importedGameConfigProfileViews)
            {
                view.ConfigName = $" [IMPORT] {view.ConfigName}";
                view.ConfigId = this.CreateNewIdForGameConfigProfile(view);
            }

            List<GameConfigProfile> importedGameConfigProfiles = GetGameConfigProfilesByViews(
                gameConfigProfileViews: importedGameConfigProfileViews.ToList(),
                gameMods: this.gameSetupManager.TotalModificationsList,
                provider: this.gameSupportProviderByDefault);

            this.AvailableProfiles.AddRange(importedGameConfigProfiles);

            this.SynchronizeGameConfigProfileViews();
        }
        catch (InvalidOperationException)
        {
            return;
        }
    }

    private static List<GameConfigProfileView> GetViewsOfGameConfigProfiles(List<GameConfigProfile> gameConfigProfiles)
    {
        List<GameConfigProfileView> gameConfigProfileViews = new ();

        foreach (GameConfigProfile gameConfigProfile in gameConfigProfiles)
        {
            GameConfigOptionView[] gameConfigOptions = GetConfigOptionsBySections(gameConfigProfile.ConfigState.CurrentSettings);

            GameConfigProfileView gameConfigProfileView = new ()
            {
                ConfigId = gameConfigProfile.Id,
                ConfigName = gameConfigProfile.Name,
                ConfigType = gameConfigProfile.ConfigType,
                GameModLocation = gameConfigProfile.TargetGameModInfo.Location,
                ConfigOptions = gameConfigOptions,
            };

            gameConfigProfileViews.Add(gameConfigProfileView);
        }

        return gameConfigProfileViews;
    }

    private static List<GameConfigProfile> GetGameConfigProfilesByViews(
        List<GameConfigProfileView> gameConfigProfileViews, List<GameModificationInfo> gameMods, GameSupportProvider provider)
    {
        List<GameConfigProfile> gameConfigProfiles = new ();

        foreach (GameConfigProfileView gameConfigProfileView in gameConfigProfileViews)
        {
            GameModificationInfo? gameModInfo = GetGameModForConfigProfile(gameMods, gameConfigProfileView);

            if (gameModInfo == null)
            {
                continue;
            }

            GameConfigOptionView[] gameConfigOptions = gameConfigProfileView.ConfigOptions!;
            GameCfgSection[] gameConfigSettings = GetSectionsOfConfigOptions(gameConfigOptions);

            GameConfigProfile gameConfigProfile = new (
                id: gameConfigProfileView.ConfigId, name: gameConfigProfileView.ConfigName,
                provider: provider, info: gameModInfo, options: gameConfigSettings);

            gameConfigProfiles.Add(gameConfigProfile);
        }

        return gameConfigProfiles;
    }

    private static GameModificationInfo? GetGameModForConfigProfile(
        List<GameModificationInfo> gameMods, GameConfigProfileView gameConfigProfileView)
    {
        foreach (GameModificationInfo gameMod in gameMods)
        {
            if (gameMod.Location.Equals(gameConfigProfileView.GameModLocation))
            {
                return gameMod;
            }
        }

        return null;
    }

    private static GameConfigOptionView[] GetConfigOptionsBySections(ICollection<GameCfgSection> gameConfigSections)
    {
        List<GameConfigOptionView> gameConfigOptionViews = new ();

        foreach (GameCfgSection gameConfigSection in gameConfigSections)
        {
            GameCfgOption[] sectionOptions = gameConfigSection.Options;

            foreach (GameCfgOption option in sectionOptions)
            {
                GameConfigOptionView view = new ()
                {
                    ConfigSection = gameConfigSection.Name,
                    CfgOptionName = option.Name,
                    CfgOptionValue = option.Value,
                };

                gameConfigOptionViews.Add(view);
            }
        }

        return gameConfigOptionViews.ToArray();
    }

    private static GameCfgSection[] GetSectionsOfConfigOptions(ICollection<GameConfigOptionView> gameConfigOptionViews)
    {
        List<GameCfgSection> gameConfigSections = new ();

        string[] configSectionNames = GetConfigSectionNames(gameConfigOptionViews);
        GameCfgOption[] gameConfigOptions = GetConfigOptions(gameConfigOptionViews);

        foreach (string sectionName in configSectionNames)
        {
            GameCfgOption[] sectionOptions = GetConfigOptionsBySectionName(gameConfigOptions, sectionName);
            GameCfgSection gameConfigSection = new (sectionName, gameConfigOptions);
            gameConfigSections.Add(gameConfigSection);
        }

        return gameConfigSections.ToArray();
    }

    private static string[] GetConfigSectionNames(ICollection<GameConfigOptionView> gameConfigOptionViews)
    {
        List<string> configSectionNames = new ();

        foreach (GameConfigOptionView optionView in gameConfigOptionViews)
        {
            if (configSectionNames.Contains(optionView.ConfigSection))
            {
                continue;
            }
            else
            {
                configSectionNames.Add(optionView.ConfigSection);
            }
        }

        return configSectionNames.ToArray();
    }

    private static GameCfgOption[] GetConfigOptions(ICollection<GameConfigOptionView> gameConfigOptionViews)
    {
        List<GameCfgOption> gameConfigOptions = new ();

        foreach (GameConfigOptionView optionView in gameConfigOptionViews)
        {
            GameCfgOption gameConfigOption = new (optionView.CfgOptionName, optionView.CfgOptionValue, optionView.ConfigSection);
            gameConfigOptions.Add(gameConfigOption);
        }

        return gameConfigOptions.ToArray();
    }

    private static GameCfgOption[] GetConfigOptionsBySectionName(GameCfgOption[] gameConfigOptions, string sectionName)
    {
        List<GameCfgOption> sectionOptions = new ();

        foreach (GameCfgOption option in gameConfigOptions)
        {
            if (option.ConfigSectionName.Equals(sectionName))
            {
                sectionOptions.Add(option);
            }
        }

        return sectionOptions.ToArray();
    }

    private static List<GameConfigProfileView> CreateGameConfigProfileViewsByDefault(List<GameModificationInfo> gameMods)
    {
        List<GameConfigProfileView> gameConfigProfileViews = new ();

        for (int index = 0; index < gameMods.Count; index++)
        {
            GameConfigProfileView gameConfigProfileView = new (
                configId: Guid.NewGuid(),
                configName: $"M2TW Config Profile [{gameMods[index].ShortName}]",
                gameModLocation: gameMods[index].Location);

            gameConfigProfileViews.Add(gameConfigProfileView);
        }

        return gameConfigProfileViews;
    }

    private static List<GameConfigProfile> CreateDefaultGameConfigProfiles()
    {
        List<GameConfigProfile> profiles = new ();

        GameConfigProfile defaultTwempProfile = new GameConfigProfile(
            provider: new GameSupportProvider(GameEngineSupportType.TWEMP),
            info: new GameModificationInfo(
                gamesetup: GameSetupInfo.Create(),
                modcenter: new ModCenterInfo("mods"),
                path: "Default_Twemp_Modification"));

        GameConfigProfile defaultM2TWProfile = new GameConfigProfile(
            provider: new GameSupportProvider(GameEngineSupportType.M2TW),
            info: new GameModificationInfo(
                gamesetup: GameSetupInfo.Create(),
                modcenter: new ModCenterInfo("mods"),
                path: "Default_M2TW_Modification"));

        GameConfigProfile defaultRTWProfile = new GameConfigProfile(
            provider: new GameSupportProvider(GameEngineSupportType.RTW),
            info: new GameModificationInfo(
                gamesetup: GameSetupInfo.Create(),
                modcenter: new ModCenterInfo("mods"),
                path: "Default_RTW_Modification"));

        profiles.Add(defaultTwempProfile);
        profiles.Add(defaultM2TWProfile);
        profiles.Add(defaultRTWProfile);

        return profiles;
    }

    private static GameConfigProfile CreateEmptyProfile()
    {
        return new GameConfigProfile(
            provider: new GameSupportProvider(GameEngineSupportType.TWEMP),
            info: new GameModificationInfo(
                gamesetup: GameSetupInfo.Create(),
                modcenter: new ModCenterInfo("mods"),
                path: "TWEMP_Modification"));
    }

    private static void ExportGameConfigProfileViewsToFile(
        List<GameConfigProfileView> gameConfigProfileViews, string exportFilePath)
    {
        AppSerializer.SerializeToJson(gameConfigProfileViews, exportFilePath);
    }

    private Guid CreateNewIdForGameConfigProfile(GameConfigProfile gameConfigProfile)
    {
        return this.CreateNewIdForGameConfigProfile(gameConfigProfile.Id);
    }

    private Guid CreateNewIdForGameConfigProfile(GameConfigProfileView gameConfigProfileView)
    {
        return this.CreateNewIdForGameConfigProfile(gameConfigProfileView.ConfigId);
    }

    private Guid CreateNewIdForGameConfigProfile(Guid profileId)
    {
        Guid gameConfigProfileId = profileId;

        if (this.IsExistingProfileId(gameConfigProfileId))
        {
            gameConfigProfileId = this.CreateNewProfileId();
        }

        return gameConfigProfileId;
    }

    private bool IsExistingProfileId(Guid profileId)
    {
        foreach (GameConfigProfileView view in this.gameConfigProfileViews)
        {
            if (view.ConfigId.Equals(profileId))
            {
                return true;
            }
        }

        return false;
    }

    private Guid CreateNewProfileId()
    {
        Guid profileId = Guid.NewGuid();

        if (this.IsExistingProfileId(profileId))
        {
            profileId = this.CreateNewProfileId();
        }

        return profileId;
    }

    private void SynchronizeGameConfigProfileViews()
    {
        this.gameConfigProfileViews = GetViewsOfGameConfigProfiles(this.AvailableProfiles);
        this.WriteAllGameConfigProfileViews(this.gameConfigProfileViews);
    }

    private List<GameConfigProfileView> ReadAllGameConfigProfileViews()
    {
        return AppSerializer.DeserializeFromJson<List<GameConfigProfileView>>(this.userProfilesConfigFileInfo.FullName);
    }

    private void WriteAllGameConfigProfileViews(List<GameConfigProfileView> gameConfigProfileViews)
    {
        AppSerializer.SerializeToJson(gameConfigProfileViews, this.userProfilesConfigFileInfo.FullName);
    }
}
