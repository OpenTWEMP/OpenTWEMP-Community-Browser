// <copyright file="GameConfigurationManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#define GAME_CFG_PROFILES_READING
#undef GAME_CFG_PROFILES_READING

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;

using System.Collections.Generic;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;
using TWEMP.Browser.Core.CommonLibrary.Serialization;

/// <summary>
/// Represents a device to manage game configuration profiles.
/// </summary>
public class GameConfigurationManager
{
    private const string UserProfilesConfigFileName = "configuration_profiles.json";

    private readonly FileInfo userProfilesConfigFileInfo;

    private GameConfigurationManager()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), UserProfilesConfigFileName);
        this.userProfilesConfigFileInfo = new FileInfo(path);

        this.AvailableProfiles = new List<GameConfigProfile>() { };

        if (this.userProfilesConfigFileInfo.Exists)
        {
            /* Reading game config profiles should be disabled!
             * Currently, cannot (de)serialize objects of the GameConfigProfile type safely.
             * The following steps is recommended to fix the System.TypeInitializationException
             * exception raised when application debugging:
             * 1. Create a view entity for the GameConfigProfile type.
             * 2. Create a view entity for the GameConfigState type.
             * 3. Implement constructors for GameConfigProfile and GameConfigState types
             * using its view entities as constructor's parameter.
             * 4. Implement (de)serialization of view entities and further create
             * GameConfigProfile and GameConfigState objects via its view entities.
             * 5. Enable and test reading game config profiles.
             */
#if GAME_CFG_PROFILES_READING
            this.AvailableProfiles = ReadAllGameConfigProfiles();
#endif
        }
        else
        {
            this.AvailableProfiles = CreateDefaultGameConfigProfiles();
        }

        this.CurrentGameModView = null;
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
    /// Creates a custom instance of the <see cref="GameConfigurationManager"/> class.
    /// </summary>
    /// <returns>Instance of the <see cref="GameConfigurationManager"/> class.</returns>
    public static GameConfigurationManager Create()
    {
        return new GameConfigurationManager();
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
        this.RefreshAllGameConfigProfiles();
    }

    /// <summary>
    /// Creates a new game configuration profile via copying an existing game configuration profile.
    /// </summary>
    /// <param name="templateProfile">A template game configuration profile.</param>
    public void CopyProfile(GameConfigProfile templateProfile)
    {
        GameConfigProfile profile = new (templateProfile);
        this.AvailableProfiles.Add(profile);
        this.RefreshAllGameConfigProfiles();
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

    // change a profile

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

        this.RefreshAllGameConfigProfiles();
    }

    /// <summary>
    /// Deletes an existing game configuration profile.
    /// </summary>
    /// <param name="id">The GUID of an existing game configuration profile.</param>
    public void DeleteProfile(Guid id)
    {
        GameConfigProfile profile = this.SelectProfileById(id);
        this.AvailableProfiles.Remove(profile);
        this.RefreshAllGameConfigProfiles();
    }

    /// <summary>
    /// Deletes all existing game configuration profiles.
    /// </summary>
    public void DeleteAllProfiles()
    {
        this.AvailableProfiles.Clear();
        this.RefreshAllGameConfigProfiles();
    }

    /// <summary>
    /// Exports all available game configuration profiles to a target directory.
    /// </summary>
    /// <param name="exportDirectoryInfo">Information about a target directory to export.</param>
    public void ExportAllProfiles(DirectoryInfo exportDirectoryInfo)
    {
        const string exportFileName = "export_profiles.json";
        string exportFilePath = Path.Combine(exportDirectoryInfo.FullName, exportFileName);

        AppSerializer.SerializeToJson(this.AvailableProfiles, exportFilePath);
    }

    /// <summary>
    ///  Imports game configuration profiles from a target file.
    /// </summary>
    /// <param name="importFileInfo">Information about a target file to import.</param>
    public void ImportAllProfiles(FileInfo importFileInfo)
    {
        try
        {
            List<GameConfigProfile> profiles =
                AppSerializer.DeserializeFromJson<List<GameConfigProfile>>(importFileInfo.FullName);

            if (profiles.Count > 0)
            {
                this.AvailableProfiles = profiles;
            }
        }
        catch (Exception)
        {
            throw;
        }
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

        AppSerializer.SerializeToJson(profiles, UserProfilesConfigFileName);

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

    private List<GameConfigProfile> ReadAllGameConfigProfiles()
    {
        return AppSerializer.DeserializeFromJson<List<GameConfigProfile>>(this.userProfilesConfigFileInfo.FullName);
    }

    private void RefreshAllGameConfigProfiles()
    {
        AppSerializer.SerializeToJson(this.AvailableProfiles, UserProfilesConfigFileName);
    }
}
