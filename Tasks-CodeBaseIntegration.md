# Tasks - Code Base Integration

---

## Code Base Integration

### TWEMP.Browser.Core.CommonLibrary + TWEMP.Browser.App.Classic.WinForms

* [x] MainBrowserForm.GameProfiles.cs : Integrate new features from TWEMP.Browser.Core.CommonLibrary class library.
* [x] MainBrowserForm.GameModsTreeView.cs : Integrate new features from TWEMP.Browser.Core.CommonLibrary class library.
* [x] MainBrowserForm.GameLauncher.cs : Integrate new features from TWEMP.Browser.Core.CommonLibrary class library.
* [x] MainBrowserForm.GameConfigState.cs : Integrate new features from TWEMP.Browser.Core.CommonLibrary class library.
* [ ] MainBrowserForm.GameCollections.cs : Integrate new features from TWEMP.Browser.Core.CommonLibrary class library.

### TWEMP.Browser.Core.CommonLibrary + TWEMP.Browser.App.Classic.CommonLibrary

* [x] GameConfigProfileCreateForm.cs : Integrate new features from TWEMP.Browser.Core.CommonLibrary class library instead of test placeholders.
* [x] GameConfigProfilesForm.cs : Integrate new features from TWEMP.Browser.Core.CommonLibrary class library instead of test placeholders.
* [x] GameMusicPlayerForm.cs : Integrate new features from TWEMP.Browser.Core.CommonLibrary class library instead of test placeholders.
* [x] ModSupportPresetSettingsForm.cs : Integrate new features from TWEMP.Browser.Core.CommonLibrary class library instead of test placeholders.
* [x] RedistributablePresetSelectionForm.cs : Integrate new features from TWEMP.Browser.Core.CommonLibrary class library instead of test placeholders.

### TWEMP.Browser.Core.CommonLibrary + TWEMP.Browser.Core.GamingSupport

* [x] Move all classes from TWEMP.Browser.Core.CommonLibrary.GameLauncherFeatures.Plugins namespace to TWEMP.Browser.Core.GamingSupport class library.
* [x] TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders : Move the GameCfgOption class to the TWEMP.Browser.Core.CommonLibrary class library.
* [x] TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders : Move the GameCfgSection class to the TWEMP.Browser.Core.CommonLibrary class library.
* [x] TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders : Replace the GameModificationInfo placeholder class to the imported type - TWEMP.Browser.Core.CommonLibrary.GameModificationInfo.
* [x] TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders : Replace the ICustomConfigState placeholder interface to the imported type - TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.ICustomConfigState.
* [x] TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders : Replace the IGameConfiguratorAgent placeholder interface to the imported type - TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration.IGameConfiguratorAgent.
* [x] TWEMP.Browser.Core.GamingSupport.AbstractPlaceholders : Replace IBrowserMessageProvider and BrowserMessageType placeholder types to the same imported types from TWEMP.Browser.Core.CommonLibrary.
* [x] GameAudioCfgSectionStateView : Implement the RetrieveCurrentSettings() interface method.
* [x] GameCameraCfgSectionStateView : Implement the RetrieveCurrentSettings() interface method.
* [x] GameControlsCfgSectionStateView : Implement the RetrieveCurrentSettings() interface method.
* [x] GameUICfgSectionStateView : Implement the RetrieveCurrentSettings() interface method.
* [x] GameVideoCfgSectionStateView : Implement the RetrieveCurrentSettings() interface method.
* [x] ModDiagnosticSectionStateView : Implement the RetrieveCurrentSettings() interface method.
* [x] ModGameplaySectionStateView : Implement the RetrieveCurrentSettings() interface method.
* [x] ModHotseatSectionStateView : Implement the RetrieveCurrentSettings() interface method.
* [x] ModSettingsSectionStateView : Implement the RetrieveCurrentSettings() interface method.
* [x] Use the TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.M2TWGameConfigurator class instead of the same double type from the TWEMP.Browser.Core.CommonLibrary class library.
* [x] Change the M2TWGameConfigurator class definition to use the M2TWGameConfigStateView record type to configure M2TW mods.

### TWEMP.Browser.Core.GamingSupport + TWEMP.Browser.App.Classic.WinForms

* [x] MainBrowserForm.GameConfigState.cs : Use new definitions of M2TW game types.
* [x] MainBrowserForm.GameLauncher.cs : Use new definitions of M2TW game types.
* [x] MainBrowserForm.GameProfiles.cs : Use new definitions of M2TW game types.

### TWEMP.Browser.Core.GamingSupport + TWEMP.Browser.App.Classic.CommonLibrary

* [ ] Use new definitions of M2TW game types into the AddNewGameSetupForm form class.
* [x] Use new definitions of M2TW game types into the ModConfigSettingsForm form class.
* [x] Use new definitions of M2TW game types into the ModQuickNavigatorForm form class.

---

## Extra Refactoring

### TWEMP.Browser.App.Classic.WinForms

* [ ] MainBrowserForm.GameCollections.cs : Simplify the ButtonMarkFavoriteMod_Click() procedure.
* [ ] MainBrowserForm.GameLauncher.cs : Simplify the ButtonLaunch_Click() procedure.
* [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the UpdateAllModificationsInTreeView() method.
* [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the TreeViewGameMods_AfterSelect() procedure.
* [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the IsNotModificationNode() method.
* [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the FindModificationBySelectedTreeNode() method.
* [ ] MainBrowserForm.GameModsTreeView.cs : Use an enumeration type for available tree node levels instead of hard code literal values.
* [ ] MainBrowserForm.GuiStyles.cs : Simplify the UpdateGUIStyle() method.
* [ ] MainBrowserForm.Localization.cs : Simplify the SetupCurrentLocalizationForGUIControls() method.

### TWEMP.Browser.App.Classic.CommonLibrary

* [ ] AddNewGameSetupForm.cs : Simplify the CanSaveNewGameSetup() method.
* [ ] AppSettingsForm.cs : Simplify the SetupCurrentLocalizationForGUIControls() method.
* [ ] AppSettingsForm.cs : Simplify the InitializeCurrentGUIStyle() method.
* [ ] CollectionCreateForm.cs : Simplify the ButtonOK_Click() procedure.
* [ ] Simplify the ModQuickNavigatorForm class.
* [ ] ModSupportPresetSettingsForm.cs : Simplify the InitializeModSupportPresetsDataGridView() method.
* [ ] ModSupportPresetSettingsForm.cs : Simplify the InitializeModSupportPresetDataGridViewRow() method.
* [ ] ModSupportPresetSettingsForm.cs : Simplify the ModSupportPresetsDataGridView_CellContentClick() procedure.
* [ ] ModSupportPresetSettingsForm.cs : Simplify the ApplyButton_Click() procedure.
* [ ] GameConfigProfileCreateForm.cs : Simplify the LoadGameConfigSettingsForm() method.
* [ ] GameConfigProfileCreateForm.cs : Simplify the FormOkButton_Click() procedure.
* [x] GameConfigProfileCreateForm.cs : Move the GameCfgType enumeration to the TWEMP.Browser.Core.CommonLibrary class library.
* [x] Move the IConfigurableGameModificationView interface to the TWEMP.Browser.Core.CommonLibrary class library.

### TWEMP.Browser.Core.CommonLibrary

* [x] Move the ICanChangeMyLocalization interface to the TWEMP.Browser.Core.CommonLibrary.Abstractions namespace.
* [x] Move the IGameConfigState interface to the TWEMP.Browser.Core.CommonLibrary.Abstractions namespace.
* [x] Move the IUpdatableBrowser interface to the TWEMP.Browser.Core.CommonLibrary.Abstractions namespace.
* [x] Move the IBrowserMessageProvider interface to the TWEMP.Browser.Core.CommonLibrary.Abstractions namespace.
* [x] Move the BrowserMessageType enumeration to the TWEMP.Browser.Core.CommonLibrary.Logging namespace.
* [x] Move the ShowFileSystemDirectory class to the TWEMP.Browser.Core.CommonLibrary.Utilities namespace.
* [x] Create the BrowserCore class to expose a facade API for any clients of the TWEMP.Browser.Core.CommonLibrary class library.
* [x] Move the TWEMP.Browser.Core.CommonLibrary.Settings class  definition to the BrowserCore and replace all external references.
* [x] Create design where the CustomGameCollectionsManager class is a part of the BrowserCore class.
* [x] Create design where the GameConfigurationManager class is a part of the BrowserCore class.
* [x] Create design where the GameSupportManager class is a part of the BrowserCore class.
* [x] Create design where the CustomGameSetupManager class is a part of the BrowserCore class.
* [x] Create design where the AppGuiStyleManager class is a part of the BrowserCore class.
* [x] Create design where the AppLocalizationManager class is a part of the BrowserCore class.
* [x] Create design where the AppSystemSettingsManager class is a part of the BrowserCore class.
* [x] Create design where the MediaDeviceManager class is a part of the BrowserCore class.
* [x] Move the TWEMP.Browser.Core.CommonLibrary.LocalizationManager wrapper to the BrowserCore class.
* [x] Move the TWEMP.Browser.Core.CommonLibrary.GameLaunchConfigurator wrapper to the BrowserCore class.
* [x] Deprecate the GuiLocale class and use the BrowserCore class instead it in external clients.
* [x] Deprecate the FormLocaleSnapshot class and use a new similar abstract class instead it in external clients.

### TWEMP.Browser.Core.GamingSupport

* [x] Use only the GameConfigRoutines class from the TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Automation namespace (remove all doubles from the TWEMP.Browser.Core.CommonLibrary class library).
* [x] Move string constants from the TotalWarEngineSupportProvider class to the GameFileSystem class.
* [x] GameFileSystem.cs : Simplify the GameFileSystem class definition.
* [x] TotalWarEngineSupportProvider.cs : Simplify the static IsCompatibleModification() method.
* [x] Change semantics of the TotalWarEngineSupportProvider class to relate it with M2TW game engine only.

---
