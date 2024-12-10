# TODO - TWEMP.Browser.Core.CommonLibrary

---

## :pushpin: Custom Management - Gaming - Collections

### :pencil: CustomGameCollectionsManager

**Source File:** [CustomGameCollectionsManager.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Collections\CustomGameCollectionsManager.cs)

**Test Coverage:**

* [ ] The **FavoriteModsCollection** static property;
* [ ] The **UserCollections** static property;
* [ ] The **WriteExistingCollections()** static method;
* [ ] The **WriteFavoriteCollection()** static method;

### :pencil: GameModsCollectionHeader

**Source File:** [GameModsCollectionHeader.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Collections\GameModsCollectionHeader.cs)

**Test Coverage:**

* [ ] The **Name** instance property;

### :pencil: UpdatableGameModsCollection

**Source File:** [UpdatableGameModsCollection.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Collections\UpdatableGameModsCollection.cs)

**Test Coverage:**

* [ ] The **Metadata** instance property;
* [ ] The **Items** instance property;
* [ ] The **ToCustomModsCollection()** instance method;
* [ ] The **UpdateName()** instance method;
* [ ] The **UpdateItems()** instance method;
* [ ] The **ClearItems()** instance method;
* [ ] The **AddItem()** instance method;
* [ ] The **RemoveItem()** instance method;

---

## :pushpin: Custom Management - Gaming - Installation

### :pencil: CustomGameSetupManager

**Source File:** [CustomGameSetupManager.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Installation\CustomGameSetupManager.cs)

**Test Coverage:**

* [ ] The **GameInstallations** static property;
* [ ] The **TotalModificationsList** static property;
* [ ] The **RegistrateGameInstallation()** static method;
* [ ] The **SynchronizeGameSetupSettings()** static method;
* [ ] The **DeleteGameSetupByIndex()** static method;
* [ ] The **UpdateTotalModificationsList()** static method;
* [ ] The **GetActiveModificationInfo()** static method;
* [ ] The **ClearAllSettings()** static method;

### :pencil: GameSetupConfFileBuilder

**Source File:** [GameSetupConfFileBuilder.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Installation\GameSetupConfFileBuilder.cs)

This class should be deprecated because of planned replacement the XML-based builder's version to a new JSON-based version. So, unit tests should be created for a new redesigned version of this class.

---

## :pushpin: Custom Management - Gaming - Views

### :pencil: FullGameModsCollectionView

**Source File:** [FullGameModsCollectionView.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Views\FullGameModsCollectionView.cs)

**Test Coverage:**

* [ ] The **GameModificationViews** instance property;
* [ ] The **SelectGameModificationById()** instance method;
* [ ] The **ActivateCustomizablePresetsForAllMods()** instance method;
* [ ] The **ActivateRedistributablePresetsForAllMods()** instance method;
* [ ] The **ResetAllModPresetsToDefaultSettings()** instance method;

### :pencil: GameModificationIdView

**Source File:** [GameModificationIdView.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Views\GameModificationIdView.cs)

**Test Coverage:**

* [ ] The **NumericId** instance property;
* [ ] The **TextId** instance property;

### :pencil: GameSetupView

**Source File:** [GameSetupView.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Views\GameSetupView.cs)

**Test Coverage:**

* [ ] The **Name** instance property;
* [ ] The **ExecutableFilePath** instance property;
* [ ] The **ModCenterDirectoryPaths** instance property;

### :pencil: ModPresetSettingView

**Source File:** [ModPresetSettingView.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Views\ModPresetSettingView.cs)

**Test Coverage:**

* [ ] The **Id** instance property;
* [ ] The **RedistributablePresetGuid** instance property;
* [ ] The **UseCustomizablePreset** instance property;

### :pencil: UpdatableGameModificationView

**Source File:** [UpdatableGameModificationView.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Views\UpdatableGameModificationView.cs)

**Test Coverage:**

* [ ] The **IdView** instance property;
* [ ] The **CurrentInfo** instance property;
* [ ] The **ActivePreset** instance property;
* [ ] The **UseCustomizablePreset** instance property;
* [ ] The **CreateGameModificationViewByRedistributablePreset()** static method;
* [ ] The **CreateGameModificationViewByCustomizablePreset()** static method;
* [ ] The **SelectRedistributableModPreset()** instance method;
* [ ] The **SelectRedistributableModPreset()** instance method;
* [ ] The **SelectCustomizableModPreset()** instance method;
* [ ] The **ResetAllModPresetsToDefaultSettings()** instance method;

---

## :pushpin: Custom Management - Gaming - Configuration - Profiles

### :pencil: GameConfigProfile

**Source File:** [GameConfigProfile.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Configuration\Profiles\GameConfigProfile.cs)

**Test Coverage:**

* [ ] The **Id** instance property;
* [ ] The **ConfigType** instance property;
* [ ] The **Name** instance property;
* [ ] The **ConfigState** instance property;

### :pencil: GameConfigurationManager

**Source File:** [GameConfigurationManager.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\Configuration\Profiles\GameConfigurationManager.cs)

**Test Coverage:**

* [ ] The **AvailableProfiles** static property;
* [ ] The **Initialize()** static method;
* [ ] The **CreateNewProfile()** static method;
* [ ] The **CopyProfile()** static method;
* [ ] The **SelectProfileById()** static method;
* [ ] The **UpdateProfile()** static method;
* [ ] The **DeleteProfile()** static method;
* [ ] The **DeleteAllProfiles()** static method;
* [ ] The **ExportAllProfiles()** static method;
* [ ] The **ImportAllProfiles()** static method;

---

## :pushpin: Custom Management - Gaming - Game Support Presets

### :pencil: GameSupportConfiguration

**Source File:** [GameSupportConfiguration.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\GameSupportPresets\GameSupportConfiguration.cs)

**Test Coverage:**

* [ ] The **TargetGameSupportProvider** instance property;
* [ ] The **RedistributablePackages** instance property;
* [ ] The **CreateTestConfigurationByDefault()** static method;
* [ ] The **GetAllRedistributablePresets()** instance method;

### :pencil: GameSupportManager

**Source File:** [GameSupportManager.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\GameSupportPresets\GameSupportManager.cs)

**Test Coverage:**

* [ ] The **PresetsHomeDirectoryInfo** static property;
* [ ] The **AvailableModSupportPresets** static property;
* [ ] The **Initialize()** static method;
* [ ] The **CreateGameModsCollectionViewByPresetSettings()** static method;

### :pencil: GameSupportProvider

**Source File:** [GameSupportProvider.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\GameSupportPresets\GameSupportProvider.cs)

**Test Coverage:**

* [ ] The **GameEngine** instance property;

### :pencil: ModSupportPresetPackage

**Source File:** [ModSupportPresetPackage.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\GameSupportPresets\ModSupportPresetPackage.cs)

**Test Coverage:**

* [ ] The **Name** instance property;
* [ ] The **Presets** instance property;
* [ ] The **CreateTestPackages()** static method;

### :pencil: ModSupportPreset

**Source File:** [ModSupportPreset.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\GameSupportPresets\ModSupportPreset.cs)

**Test Coverage:**

* [ ] The **HeaderInfo** instance property;
* [ ] The **ContentInfo** instance property;
* [ ] The **LauncherInfo** instance property;
* [ ] The **SocialMediaInfo** instance property;
* [ ] The **CreateDefaultTemplate()** static method;

### :pencil: CustomizableModPreset

**Source File:** [ModSupportPreset.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\GameSupportPresets\ModSupportPreset.cs)

**Test Coverage:**

* [ ] The **Data** instance property;
* [ ] The **Location** instance property;
* [ ] The **Config** instance property;
* [ ] The **CreateDefaultTemplate()** static method;

### :pencil: RedistributableModPreset

**Source File:** [ModSupportPreset.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\GameSupportPresets\ModSupportPreset.cs)

**Test Coverage:**

* [ ] The **Data** instance property;
* [ ] The **Metadata** instance property;
* [ ] The **CreateDefaultTemplate()** static method;

### :pencil: ModPresetMetaInfo

**Source File:** [ModSupportPreset.cs](..\TWEMP.Browser.Core.CommonLibrary\src\CustomManagement\Gaming\GameSupportPresets\ModSupportPreset.cs)

**Test Coverage:**

* [ ] The **Version** instance property;
* [ ] The **PresetName** instance property;
* [ ] The **PackageName** instance property;
* [ ] The **Creator** instance property;
* [ ] The **CreateDefaultTemplate()** static method;

---

## :pushpin: Media Devices

### :pencil: MediaDeviceManager

**Source File:** [MediaDeviceManager.cs](..\TWEMP.Browser.Core.CommonLibrary\src\MediaDevices\MediaDeviceManager.cs)

**Test Coverage:**

* [ ] The **MusicPlayerDevice** instance property;
* [ ] The **Create()** static method;
* [ ] The **InitializeAudioFileInfoByDefault()** static method;

### :pencil: GameMusicPlayer

**Source File:** [GameMusicPlayer.cs](..\TWEMP.Browser.Core.CommonLibrary\src\MediaDevices\GameMusicPlayer.cs)

**Test Coverage:**

* [ ] The **State** instance property;
* [ ] The **Volume** instance property;
* [ ] The **Play()** instance method;
* [ ] The **Stop()** instance method;
* [ ] The **Pause()** instance method;
* [ ] The **Rewind()** instance method;
* [ ] The **UpdateVolume()** instance method;
* [ ] The **MuteVolume()** instance method;
* [ ] The **ChargeVolume()** instance method;

### :pencil: MusicPlayerVolume

**Source File:** [MusicPlayerVolume.cs](..\TWEMP.Browser.Core.CommonLibrary\src\MediaDevices\MusicPlayerVolume.cs)

**Test Coverage:**

* [ ] The **MinValue** static property;
* [ ] The **MaxValue** static property;
* [ ] The **CurrentValue** instance property;
* [ ] The **UpdateVolumeValue()** instance method;

---
