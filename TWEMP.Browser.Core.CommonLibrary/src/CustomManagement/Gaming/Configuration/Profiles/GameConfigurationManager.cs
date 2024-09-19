// <copyright file="GameConfigurationManager.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#define GAME_CFG_PROFILES_READING
#undef GAME_CFG_PROFILES_READING

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.Profiles;

using System.Collections.Generic;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.Serialization;

/// <summary>
/// Represents the static device to manage game configuration profiles.
/// </summary>
public static class GameConfigurationManager
{
    private const string UserProfilesConfigFileName = "configuration_profiles.json";

    private static readonly FileInfo UserProfilesConfigFileInfo;

    /// <summary>
    /// Initializes static members of the <see cref="GameConfigurationManager"/> class.
    /// </summary>
    static GameConfigurationManager()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), UserProfilesConfigFileName);
        UserProfilesConfigFileInfo = new FileInfo(path);

        AvailableProfiles = new List<GameConfigProfile>() { };
    }

    /// <summary>
    /// Gets available game configuration profiles.
    /// </summary>
    public static List<GameConfigProfile> AvailableProfiles { get; private set; }

    /// <summary>
    ///  Initializes the global device to manage game configuration profiles.
    /// </summary>
    public static void Initialize()
    {
        if (UserProfilesConfigFileInfo.Exists)
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
            AvailableProfiles = ReadAllGameConfigProfiles();
#endif
        }
        else
        {
            AvailableProfiles = CreateDefaultGameConfigProfiles();
        }
    }

    /// <summary>
    /// Creates a new game configuration profile.
    /// </summary>
    /// <param name="provider">A target game support provider type.</param>
    /// <param name="info">Information about a target game modification.</param>
    /// <param name="state">A target custom game configuration state.</param>
    public static void CreateNewProfile(GameSupportProvider provider, GameModificationInfo info, ICustomConfigState state)
    {
        GameConfigProfile profile = new (provider, info, state);
        AvailableProfiles.Add(profile);
        RefreshAllGameConfigProfiles();
    }

    /// <summary>
    /// Creates a new game configuration profile via copying an existing game configuration profile.
    /// </summary>
    /// <param name="templateProfile">A template game configuration profile.</param>
    public static void CopyProfile(GameConfigProfile templateProfile)
    {
        GameConfigProfile profile = new (templateProfile);
        AvailableProfiles.Add(profile);
        RefreshAllGameConfigProfiles();
    }

    /// <summary>
    /// Selects an existing game configuration profile by its GUID.
    /// </summary>
    /// <param name="id">The GUID of a target game configuration profile.</param>
    /// <returns>A target instanse of the <see cref="GameConfigProfile"/> class.</returns>
    public static GameConfigProfile SelectProfileById(Guid id)
    {
        foreach (GameConfigProfile profile in AvailableProfiles)
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
    public static void UpdateProfile(Guid id, string name, GameConfigState state)
    {
        GameConfigProfile profile = SelectProfileById(id);

        profile.Name = name;
        profile.ConfigState = state;

        RefreshAllGameConfigProfiles();
    }

    /// <summary>
    /// Deletes an existing game configuration profile.
    /// </summary>
    /// <param name="id">The GUID of an existing game configuration profile.</param>
    public static void DeleteProfile(Guid id)
    {
        GameConfigProfile profile = SelectProfileById(id);
        AvailableProfiles.Remove(profile);
        RefreshAllGameConfigProfiles();
    }

    /// <summary>
    /// Deletes all existing game configuration profiles.
    /// </summary>
    public static void DeleteAllProfiles()
    {
        AvailableProfiles.Clear();
        RefreshAllGameConfigProfiles();
    }

    /// <summary>
    /// Exports all available game configuration profiles to a target directory.
    /// </summary>
    /// <param name="exportDirectoryInfo">Information about a target directory to export.</param>
    public static void ExportAllProfiles(DirectoryInfo exportDirectoryInfo)
    {
        const string exportFileName = "export_profiles.json";
        string exportFilePath = Path.Combine(exportDirectoryInfo.FullName, exportFileName);

        AppSerializer.SerializeToJson(AvailableProfiles, exportFilePath);
    }

    /// <summary>
    ///  Imports game configuration profiles from a target file.
    /// </summary>
    /// <param name="importFileInfo">Information about a target file to import.</param>
    public static void ImportAllProfiles(FileInfo importFileInfo)
    {
        try
        {
            List<GameConfigProfile> profiles =
                AppSerializer.DeserializeFromJson<List<GameConfigProfile>>(importFileInfo.FullName);

            if (profiles.Count > 0)
            {
                AvailableProfiles = profiles;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static List<GameConfigProfile> ReadAllGameConfigProfiles()
    {
        return AppSerializer.DeserializeFromJson<List<GameConfigProfile>>(UserProfilesConfigFileInfo.FullName);
    }

    private static void RefreshAllGameConfigProfiles()
    {
        AppSerializer.SerializeToJson(AvailableProfiles, UserProfilesConfigFileName);
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
}
