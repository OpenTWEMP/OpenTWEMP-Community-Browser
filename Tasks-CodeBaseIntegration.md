# Tasks - Code Base Integration

---

## Code Base Integration

### TWEMP.Browser.Core.CommonLibrary + TWEMP.Browser.App.Classic.WinForms

* [ ] 1
* [ ] 2
* [ ] 3
* [ ] 4
* [ ] 5

### TWEMP.Browser.Core.CommonLibrary + TWEMP.Browser.App.Classic.CommonLibrary

* [ ] 1
* [ ] 2
* [ ] 3
* [ ] 4
* [ ] 5

### TWEMP.Browser.Core.CommonLibrary + TWEMP.Browser.Core.GamingSupport

* [ ] Move all classes from TWEMP.Browser.Core.CommonLibrary.GameLauncherFeatures.Plugins namespace to TWEMP.Browser.Core.GamingSupport class library.
* [ ] 2
* [ ] 3
* [ ] 4
* [ ] 5

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
* [ ] GameConfigProfileCreateForm.cs : Move the GameCfgType enumeration to the TWEMP.Browser.Core.CommonLibrary class library.
* [ ] Move the IConfigurableGameModificationView interface to the TWEMP.Browser.Core.CommonLibrary class library.

### TWEMP.Browser.Core.CommonLibrary

* [ ] Move the ICanChangeMyLocalization interface to the TWEMP.Browser.Core.CommonLibrary.Abstractions namespace.
* [ ] Move the IGameConfigState interface to the TWEMP.Browser.Core.CommonLibrary.Abstractions namespace.
* [ ] Move the IUpdatableBrowser interface to the TWEMP.Browser.Core.CommonLibrary.Abstractions namespace.
* [ ] Move the IBrowserMessageProvider interface to the TWEMP.Browser.Core.CommonLibrary.Abstractions namespace.
* [ ] Move the BrowserMessageType enumeration to the TWEMP.Browser.Core.CommonLibrary.Logging namespace.
* [ ] Move the ShowFileSystemDirectory class to the TWEMP.Browser.Core.CommonLibrary.Utilities namespace.
* [ ] Create the BrowserCore class to expose a facade API for any clients of the TWEMP.Browser.Core.CommonLibrary class library.
* [ ] Move the TWEMP.Browser.Core.CommonLibrary.Settings class  definition to the BrowserCore and replace all external references.
* [ ] Create design where the CustomGameCollectionsManager class is a part of the BrowserCore class.
* [ ] Create design where the GameConfigurationManager class is a part of the BrowserCore class.
* [ ] Create design where the GameSupportManager class is a part of the BrowserCore class.
* [ ] Create design where the CustomGameSetupManager class is a part of the BrowserCore class.
* [ ] Create design where the AppGuiStyleManager class is a part of the BrowserCore class.
* [ ] Create design where the AppLocalizationManager class is a part of the BrowserCore class.
* [ ] Create design where the AppSystemSettingsManager class is a part of the BrowserCore class.
* [ ] Create design where the MediaDeviceManager class is a part of the BrowserCore class.
* [ ] Move the TWEMP.Browser.Core.CommonLibrary.LocalizationManager wrapper to the BrowserCore class.
* [ ] Move the TWEMP.Browser.Core.CommonLibrary.GameLaunchConfigurator wrapper to the BrowserCore class.
* [ ] Move the BrowserMessageProvider class the TWEMP.Browser.Core.CommonLibrary.Messaging namespace.
* [ ] Deprecate the GuiLocale class and use the BrowserCore class instead it in external clients.
* [ ] Deprecate the FormLocaleSnapshot class and use a new similar abstract class instead it in external clients.

### TWEMP.Browser.Core.GamingSupport

* [ ] 1
* [ ] 2
* [ ] 3
* [ ] 4
* [ ] 5

---
