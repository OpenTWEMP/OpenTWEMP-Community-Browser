// <copyright file="ModHotseatSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

public record ModHotseatSectionStateView
{
    public bool HotseatAutoresolveBattles { get; set; } // "autoresolve_battles";

    public bool HotseatScroll { get; set; } // "scroll"; | use a boolean value ?

    public bool HotseatPasswords { get; set; } // "passwords"; | use a boolean value ?

    public bool HotseatTurns { get; set; } // "turns"; | use a boolean value ?

    public bool HotseatDisableConsole { get; set; } // "disable_console";

    public string? HotseatAdminPassword { get; set; } // "admin_password";

    public bool HotseatDisablePapalElections { get; set; } // "disable_papal_elections";

    public bool HotseatSavePrefs { get; set; } // "save_prefs";

    public bool HotseatUpdateAiCamera { get; set; } // "update_ai_camera";

    public bool HotseatAutoSave { get; set; } // "autosave"; | use a boolean value ?

    public bool HotseatSaveConfig { get; set; } // "save_config"; | use a boolean value ?

    public bool HotseatCloseAfterSave { get; set; } // "close_after_save"; | use a boolean value ?

    public bool HotseatGameName { get; set; } // "gamename"; | use a boolean value ?

    public bool HotseatValidateData { get; set; } // "validate_data" | use a boolean value ?

    public bool HotseatAllowValidationFailures { get; set; } // "allow_validation_failures";

    public bool HotseatValidateDiplomacy { get; set; } // "validate_diplomacy";

    public string? BypassToStrategySave { get; set; } // "bypass_to_strategy_save"

    public string? NetworkUseIp { get; set; } // "use_ip" | use the 'xxx.xxx.xxx.xxx' format

    public ushort NetworkUsePort { get; set; } // "use_port" | 27750 by default
}
