// <copyright file="ModHotseatSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public record ModHotseatSectionStateView : ICustomConfigState
{
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

    public M2TW_Boolean? HotseatGameName { get; set; } // "gamename"; | use a boolean value ?

    public M2TW_Boolean? HotseatValidateData { get; set; } // "validate_data" | use a boolean value ?

    public M2TW_Boolean? HotseatAllowValidationFailures { get; set; } // "allow_validation_failures";

    public M2TW_Boolean? HotseatValidateDiplomacy { get; set; } // "validate_diplomacy";

    public string? BypassToStrategySave { get; set; } // "bypass_to_strategy_save"

    public M2TW_IpAddress? NetworkUseIp { get; set; } // "use_ip" | use the 'xxx.xxx.xxx.xxx' format

    public ushort NetworkUsePort { get; set; } // "use_port" | 27750 by default

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        return new GameCfgSection[] { };
    }

    private static M2TWGameCfgSection GetHotseatSubSet()
    {
        string subsetName = "hotseat";

        var subsetOptions = new List<M2TWGameCfgOption>();

        subsetOptions.Add(new M2TWGameCfgOption("scroll", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("turns", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("disable_console", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("admin_password", "qwerty", subsetName)); // resolve password !!!
        subsetOptions.Add(new M2TWGameCfgOption("update_ai_camera", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("disable_papal_elections", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("autoresolve_battles", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("validate_diplomacy", false, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("save_prefs", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("autosave", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("save_config", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("close_after_save", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("gamename", "hotseat_gamename", subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("validate_data", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("allow_validation_failures", false, subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static M2TWGameCfgSection GetMultiplayerSubSet()
    {
        string subsetName = "multiplayer";

        var subsetOptions = new List<M2TWGameCfgOption>();

        subsetOptions.Add(new M2TWGameCfgOption("playable", true, subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }

    private static M2TWGameCfgSection GetMiscSubSet()
    {
        string subsetName = "misc";

        var subsetOptions = new List<M2TWGameCfgOption>();

        subsetOptions.Add(new M2TWGameCfgOption("show_hud_date", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("bypass_sprite_script", true, subsetName));
        subsetOptions.Add(new M2TWGameCfgOption("bypass_to_strategy_save", "game_name.sav", subsetName));

        return new M2TWGameCfgSection(subsetName, subsetOptions.ToArray());
    }
}
