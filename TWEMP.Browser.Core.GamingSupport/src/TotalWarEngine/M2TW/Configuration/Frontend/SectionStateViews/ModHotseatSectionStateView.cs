// <copyright file="ModHotseatSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public record ModHotseatSectionStateView : ICustomConfigState
{
    private const string HotseatConfigSwitch = "hotseat";
    private const string MultiplayerConfigSwitch = "multiplayer";
    private const string NetworkConfigSwitch = "network";

    public const string HotseatAutoresolveBattlesTextId = "autoresolve_battles";
    public const string HotseatScrollTextId = "scroll";
    public const string HotseatPasswordsTextId = "passwords";
    public const string HotseatTurnsTextId = "turns";
    public const string HotseatDisableConsoleTextId = "disable_console";
    public const string HotseatAdminPasswordTextId = "admin_password";
    public const string HotseatDisablePapalElectionsTextId = "disable_papal_elections";
    public const string HotseatSavePrefsTextId = "save_prefs";
    public const string HotseatUpdateAiCameraTextId = "update_ai_camera";
    public const string HotseatAutoSaveTextId = "autosave";
    public const string HotseatSaveConfigTextId = "save_config";
    public const string HotseatCloseAfterSaveTextId = "close_after_save";
    public const string HotseatGameNameTextId = "gamename";
    public const string HotseatValidateDataTextId = "validate_data";
    public const string HotseatAllowValidationFailuresTextId = "allow_validation_failures";
    public const string HotseatValidateDiplomacyTextId = "validate_diplomacy";
    public const string MultiplayerPlayableTextId = "playable";
    public const string NetworkUseIpTextId = "use_ip";
    public const string NetworkUsePortTextId = "use_port";

    public ModHotseatSectionStateView()
    {
    }

    public M2TW_Boolean? HotseatAutoresolveBattles { get; set; } // "autoresolve_battles";

    public M2TW_Boolean? HotseatScroll { get; set; } // "scroll"; | use a boolean value ?

    public M2TW_Boolean? HotseatPasswords { get; set; } // "passwords"; | use a boolean value ?

    public M2TW_Boolean? HotseatTurns { get; set; } // "turns"; | use a boolean value ?

    public M2TW_Boolean? HotseatDisableConsole { get; set; } // "disable_console";

    public string? HotseatAdminPassword { get; set; } // "admin_password";

    public M2TW_Boolean? HotseatDisablePapalElections { get; set; } // "disable_papal_elections";

    public M2TW_Boolean? HotseatSavePrefs { get; set; } // "save_prefs";

    public M2TW_Boolean? HotseatUpdateAiCamera { get; set; } // "update_ai_camera";

    public M2TW_Boolean? HotseatAutoSave { get; set; } // "autosave"; | use a boolean value ?

    public M2TW_Boolean? HotseatSaveConfig { get; set; } // "save_config"; | use a boolean value ?

    public M2TW_Boolean? HotseatCloseAfterSave { get; set; } // "close_after_save"; | use a boolean value ?

    public string? HotseatGameName { get; set; } // "gamename"

    public M2TW_Boolean? HotseatValidateData { get; set; } // "validate_data" | use a boolean value ?

    public M2TW_Boolean? HotseatAllowValidationFailures { get; set; } // "allow_validation_failures";

    public M2TW_Boolean? HotseatValidateDiplomacy { get; set; } // "validate_diplomacy";

    public string? BypassToStrategySave { get; set; } // "bypass_to_strategy_save"

    public M2TW_Boolean? MultiplayerPlayable { get; set; } // "playable"

    public M2TW_IpAddress? NetworkUseIp { get; set; } // "use_ip" | use the 'xxx.xxx.xxx.xxx' format

    public ushort? NetworkUsePort { get; set; } // "use_port" | 27750 by default

    public static ModHotseatSectionStateView CreateByDefault()
    {
        return new ModHotseatSectionStateView
        {
            HotseatAutoresolveBattles = new M2TW_Boolean(false),
            HotseatScroll = new M2TW_Boolean(false),
            HotseatPasswords = new M2TW_Boolean(false),
            HotseatTurns = new M2TW_Boolean(false),
            HotseatDisableConsole = new M2TW_Boolean(false),
            HotseatAdminPassword = string.Empty,
            HotseatDisablePapalElections = new M2TW_Boolean(true),
            HotseatSavePrefs = new M2TW_Boolean(true),
            HotseatUpdateAiCamera = new M2TW_Boolean(true),
            HotseatAutoSave = new M2TW_Boolean(true),
            HotseatSaveConfig = new M2TW_Boolean(true),
            HotseatCloseAfterSave = new M2TW_Boolean(false),
            HotseatGameName = "hotseat_gamename.sav",
            HotseatValidateData = new M2TW_Boolean(false),
            HotseatAllowValidationFailures = new M2TW_Boolean(false),
            HotseatValidateDiplomacy = new M2TW_Boolean(false),
            BypassToStrategySave = string.Empty,
            MultiplayerPlayable = new M2TW_Boolean(true),
            NetworkUseIp = new M2TW_IpAddress(127, 0, 0, 1),
            NetworkUsePort = Convert.ToUInt16(M2TW_IpAddress.DefaultPort),
        };
    }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        M2TWGameCfgOption[] hotseatCfgOptions =
        {
            new (name: HotseatAutoresolveBattlesTextId, value: this.HotseatAutoresolveBattles!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatScrollTextId, value: this.HotseatScroll!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatPasswordsTextId, value: this.HotseatPasswords!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatTurnsTextId, value: this.HotseatTurns!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatDisableConsoleTextId, value: this.HotseatDisableConsole!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatAdminPasswordTextId, value: this.HotseatAdminPassword!, section: HotseatConfigSwitch),
            new (name: HotseatDisablePapalElectionsTextId, value: this.HotseatDisablePapalElections!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatSavePrefsTextId, value: this.HotseatSavePrefs!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatUpdateAiCameraTextId, value: this.HotseatUpdateAiCamera!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatAutoSaveTextId, value: this.HotseatAutoSave!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatSaveConfigTextId, value: this.HotseatSaveConfig!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatCloseAfterSaveTextId, value: this.HotseatCloseAfterSave!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatGameNameTextId, value: this.HotseatGameName!, section: HotseatConfigSwitch),
            new (name: HotseatValidateDataTextId, value: this.HotseatValidateData!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatAllowValidationFailuresTextId, value: this.HotseatAllowValidationFailures!.BooleanValue, section: HotseatConfigSwitch),
            new (name: HotseatValidateDiplomacyTextId, value: this.HotseatValidateDiplomacy!.BooleanValue, section: HotseatConfigSwitch),
        };

        M2TWGameCfgOption[] multiplayerCfgOptions =
        {
            new (name: MultiplayerPlayableTextId, value: this.MultiplayerPlayable!.BooleanValue, section: MultiplayerConfigSwitch),
        };

        M2TWGameCfgOption[] networkCfgOptions =
        {
            new (name: NetworkUseIpTextId, value: this.NetworkUseIp!.Value, section: NetworkConfigSwitch),
            new (name: NetworkUsePortTextId, value: this.NetworkUsePort!, section: NetworkConfigSwitch),
        };

        GameCfgSection hotseatCfgSection = new M2TWGameCfgSection(HotseatConfigSwitch, hotseatCfgOptions);
        GameCfgSection multiplayerCfgSection = new M2TWGameCfgSection(MultiplayerConfigSwitch, multiplayerCfgOptions);
        GameCfgSection networkCfgSection = new M2TWGameCfgSection(NetworkConfigSwitch, networkCfgOptions);

        return new GameCfgSection[] { hotseatCfgSection, multiplayerCfgSection, networkCfgSection };
    }
}
