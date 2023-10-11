// <copyright file="FormLocaleDescription.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1101 // PrefixLocalCallsWithThis
#pragma warning disable SA1310 // FieldNamesMustNotContainUnderscore

namespace TWEMP.Browser.Core.CommonLibrary;

public abstract class FormLocaleDescription
{
    public abstract string FormName { get; }

    public abstract List<string> LocalizedControls { get; }

    public abstract FormLocaleSnapshot CreateLocaleSnapshotFor_ENG();

    public abstract FormLocaleSnapshot CreateLocaleSnapshotFor_RUS();
}

// Derived class for 'MainBrowserForm' form.
public class GuiLocaleDescr_MainBrowser : FormLocaleDescription
{
    private const string KEY_buttonLaunch = "buttonLaunch";
    private const string KEY_modQuickNavigationButton = "modQuickNavigationButton";
    private const string KEY_buttonExplore = "buttonExplore";

    private const string KEY_groupBoxConfigCleanerMode = "groupBoxConfigCleanerMode";
    private const string KEY_checkBoxCleaner_MapRWM = "checkBoxCleaner_MapRWM";
    private const string KEY_checkBoxCleaner_textBIN = "checkBoxCleaner_textBIN";
    private const string KEY_checkBoxCleaner_soundPacks = "checkBoxCleaner_soundPacks";

    private const string KEY_groupBoxConfigLogMode = "groupBoxConfigLogMode";
    private const string KEY_radioButtonLogOnlyError = "radioButtonLogOnlyError";
    private const string KEY_radioButtonLogOnlyTrace = "radioButtonLogOnlyTrace";
    private const string KEY_radioButtonLogErrorAndTrace = "radioButtonLogErrorAndTrace";
    private const string KEY_checkBoxLogHistory = "checkBoxLogHistory";

    private const string KEY_groupBoxConfigLaunchMode = "groupBoxConfigLaunchMode";
    private const string KEY_radioButtonLaunchWindowScreen = "radioButtonLaunchWindowScreen";
    private const string KEY_radioButtonLaunchFullScreen = "radioButtonLaunchFullScreen";
    private const string KEY_checkBoxVideo = "checkBoxVideo";
    private const string KEY_checkBoxBorderless = "checkBoxBorderless";

    private const string KEY_toolStripAppItem = "toolStripAppItem";
    private const string KEY_gameSetupSettingsToolStripMenuItem = "gameSetupSettingsToolStripMenuItem";
    private const string KEY_applicationSettingsToolStripMenuItem = "applicationSettingsToolStripMenuItem";
    private const string KEY_applicationHomeFolderToolStripMenuItem = "applicationHomeFolderToolStripMenuItem";
    private const string KEY_exitFromApplicationToolStripMenuItem = "exitFromApplicationToolStripMenuItem";

    private const string KEY_toolStripHelpItem = "toolStripHelpItem";
    private const string KEY_aboutProgramToolStripMenuItem = "aboutProgramToolStripMenuItem";

    private const string KEY_groupBoxConfigProfiles = "groupBoxConfigProfiles";
    private const string KEY_radioButtonConfigProfile_Gaming = "radioButtonConfigProfile_Gaming";
    private const string KEY_radioButtonConfigProfile_Modding = "radioButtonConfigProfile_Modding";

    private const string KEY_groupBoxLauncherProviders = "groupBoxLauncherProviders";
    private const string KEY_radioButtonLauncherProvider_TWEMP = "radioButtonLauncherProvider_TWEMP";
    private const string KEY_radioButtonLauncherProvider_BatchScript = "radioButtonLauncherProvider_BatchScript";
    private const string KEY_radioButtonLauncherProvider_NativeSetup = "radioButtonLauncherProvider_NativeSetup";
    private const string KEY_radioButtonLauncherProvider_M2TWEOP = "radioButtonLauncherProvider_M2TWEOP";

    private const string KEY_buttonCollectionManage = "buttonCollectionManage";
    private const string KEY_buttonCollectionCreate = "buttonCollectionCreate";
    private const string KEY_buttonMarkFavoriteMod = "buttonMarkFavoriteMod";

    public GuiLocaleDescr_MainBrowser()
    {
        FormName = "MainBrowserForm";

        LocalizedControls = new List<string>()
        {
            KEY_buttonLaunch,
            KEY_modQuickNavigationButton,
            KEY_buttonExplore,

            KEY_groupBoxConfigCleanerMode,
            KEY_checkBoxCleaner_MapRWM,
            KEY_checkBoxCleaner_textBIN,
            KEY_checkBoxCleaner_soundPacks,

            KEY_groupBoxConfigLogMode,
            KEY_radioButtonLogOnlyError,
            KEY_radioButtonLogOnlyTrace,
            KEY_radioButtonLogErrorAndTrace,
            KEY_checkBoxLogHistory,

            KEY_groupBoxConfigLaunchMode,
            KEY_radioButtonLaunchWindowScreen,
            KEY_radioButtonLaunchFullScreen,
            KEY_checkBoxVideo,
            KEY_checkBoxBorderless,

            KEY_toolStripAppItem,
            KEY_gameSetupSettingsToolStripMenuItem,
            KEY_applicationSettingsToolStripMenuItem,
            KEY_applicationHomeFolderToolStripMenuItem,
            KEY_exitFromApplicationToolStripMenuItem,

            KEY_toolStripHelpItem,
            KEY_aboutProgramToolStripMenuItem,

            KEY_groupBoxConfigProfiles,
            KEY_radioButtonConfigProfile_Gaming,
            KEY_radioButtonConfigProfile_Modding,

            KEY_groupBoxLauncherProviders,
            KEY_radioButtonLauncherProvider_TWEMP,
            KEY_radioButtonLauncherProvider_BatchScript,
            KEY_radioButtonLauncherProvider_NativeSetup,
            KEY_radioButtonLauncherProvider_M2TWEOP,

            KEY_buttonCollectionManage,
            KEY_buttonCollectionCreate,
            KEY_buttonMarkFavoriteMod,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
            {
                { KEY_buttonLaunch, "LAUNCH" },
                { KEY_modQuickNavigationButton, "MOD QUICK NAVIGATION" },
                { KEY_buttonExplore, "MOD HOME FOLDER" },
                { KEY_groupBoxConfigCleanerMode, "Select mod clean routines" },
                { KEY_checkBoxCleaner_MapRWM, "Delete map.rwm file" },
                { KEY_checkBoxCleaner_textBIN, "Delete localization *strings.bin files" },
                { KEY_checkBoxCleaner_soundPacks, "Delete sound pack files (*.DAT + *.IDX)" },
                { KEY_groupBoxConfigLogMode, "Select a mode of creating system.log file" },
                { KEY_radioButtonLogOnlyError, "Only Errors" },
                { KEY_radioButtonLogOnlyTrace, "Only Trace" },
                { KEY_radioButtonLogErrorAndTrace, "Errors + Trace" },
                { KEY_checkBoxLogHistory, "Save game system.log files" },
                { KEY_groupBoxConfigLaunchMode, "Select game launch mode" },
                { KEY_radioButtonLaunchWindowScreen, "Windowed Mode" },
                { KEY_radioButtonLaunchFullScreen, "Full-Screen Mode" },
                { KEY_checkBoxVideo, "Enable Game Video" },
                { KEY_checkBoxBorderless, "Borderless Windowed Mode" },
                { KEY_toolStripAppItem, "BROWSER" },
                { KEY_gameSetupSettingsToolStripMenuItem, "Game Setup Settings" },
                { KEY_applicationSettingsToolStripMenuItem, "Application Settings" },
                { KEY_applicationHomeFolderToolStripMenuItem, "Go to Home Directory" },
                { KEY_exitFromApplicationToolStripMenuItem, "Exit form Program" },
                { KEY_toolStripHelpItem, "HELP" },
                { KEY_aboutProgramToolStripMenuItem, "About Program" },
                { KEY_groupBoxConfigProfiles, "Configuration Profiles" },
                { KEY_radioButtonConfigProfile_Gaming, "GAMING MODE" },
                { KEY_radioButtonConfigProfile_Modding, "MODDING MODE" },
                { KEY_groupBoxLauncherProviders, "Launcher Providers" },
                { KEY_radioButtonLauncherProvider_TWEMP, "Launch Game via TWEMP Launcher" },
                { KEY_radioButtonLauncherProvider_BatchScript, "Launch Game via Batch Script" },
                { KEY_radioButtonLauncherProvider_NativeSetup, "Launch Game via Native Setup" },
                { KEY_radioButtonLauncherProvider_M2TWEOP, "Launch Game via M2TWEOP GUI" },
                { KEY_buttonCollectionManage, "MANAGE YOUR COLLECTIONS" },
                { KEY_buttonCollectionCreate, "CREATE A NEW COLLECTION" },
                { KEY_buttonMarkFavoriteMod, "MARK or UNMARK THIS MOD as FAVORITE" },
            });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
            {
                { KEY_buttonLaunch, "ИГРАТЬ" },
                { KEY_modQuickNavigationButton, "БЫСТРАЯ МОД-НАВИГАЦИЯ" },
                { KEY_buttonExplore, "РАЗМЕЩЕНИЕ МОДИФИКАЦИИ" },
                { KEY_groupBoxConfigCleanerMode, "Выберите операции очистки для мода" },
                { KEY_checkBoxCleaner_MapRWM, "Удалять файл map.rwm" },
                { KEY_checkBoxCleaner_textBIN, "Удалять файлы *strings.bin" },
                { KEY_checkBoxCleaner_soundPacks, "Удалять pack-файлы (*.DAT + *.IDX)" },
                { KEY_groupBoxConfigLogMode, "Выберите режим записи журнала" },
                { KEY_radioButtonLogOnlyError, "Только ошибки" },
                { KEY_radioButtonLogOnlyTrace, "Только трассировка" },
                { KEY_radioButtonLogErrorAndTrace, "Ошибки + трассировка" },
                { KEY_checkBoxLogHistory, "Сохранять журналы system.log" },
                { KEY_groupBoxConfigLaunchMode, "Выберите режим запуска игры" },
                { KEY_radioButtonLaunchWindowScreen, "Оконный режим" },
                { KEY_radioButtonLaunchFullScreen, "Полноэкранный режим" },
                { KEY_checkBoxVideo, "Игровое видео" },
                { KEY_checkBoxBorderless, "Оконный режим без границ" },
                { KEY_toolStripAppItem, "БРАУЗЕР" },
                { KEY_gameSetupSettingsToolStripMenuItem, "Игровые Установки" },
                { KEY_applicationSettingsToolStripMenuItem, "Настройки Программы" },
                { KEY_applicationHomeFolderToolStripMenuItem, "Домашняя Директория" },
                { KEY_exitFromApplicationToolStripMenuItem, "Выйти из Программы" },
                { KEY_toolStripHelpItem, "ПОМОЩЬ" },
                { KEY_aboutProgramToolStripMenuItem, "О Программе" },
                { KEY_groupBoxConfigProfiles, "Выберите профиль конфигурации" },
                { KEY_radioButtonConfigProfile_Gaming, "РЕЖИМ ИГРЫ" },
                { KEY_radioButtonConfigProfile_Modding, "МОДДИНГ-РЕЖИМ" },
                { KEY_groupBoxLauncherProviders, "Выберите средство запуска мода" },
                { KEY_radioButtonLauncherProvider_TWEMP, "Встроенный лаунчер TWEMP" },
                { KEY_radioButtonLauncherProvider_BatchScript, "Пакетный сценарий запуска мода" },
                { KEY_radioButtonLauncherProvider_NativeSetup, "Нативная программа запуска мода" },
                { KEY_radioButtonLauncherProvider_M2TWEOP, "Лаунчер проекта M2TWEOP" },
                { KEY_buttonCollectionManage, "УПРАВЛЕНИЕ КОЛЛЕКЦИЯМИ" },
                { KEY_buttonCollectionCreate, "СОЗДАТЬ НОВУЮ КОЛЛЕКЦИЮ" },
                { KEY_buttonMarkFavoriteMod, "ИЗБРАННОЕ (ДОБАВИТЬ/УДАЛИТЬ МОД)" },
            });
    }
}

// Derived class for 'ApplicationSettingsForm' form.
public class GuiLocaleDescr_AppSettings : FormLocaleDescription
{
    private const string KEY_This = "AppSettingsForm";

    private const string KEY_appColorThemeGroupBox = "appColorThemeGroupBox";
    private const string KEY_uiStyleByDefaultThemeRadioButton = "uiStyleByDefaultThemeRadioButton";
    private const string KEY_uiStyleByLightThemeRadioButton = "uiStyleByLightThemeRadioButton";
    private const string KEY_uiStyleByDarkThemeRadioButton = "uiStyleByDarkThemeRadioButton";

    private const string KEY_appLocalizationGroupBox = "appLocalizationGroupBox";
    private const string KEY_enableEngLocaleRadioButton = "enableEngLocaleRadioButton";
    private const string KEY_enableRusLocaleRadioButton = "enableRusLocaleRadioButton";

    private const string KEY_appFeaturesGroupBox = "appFeaturesGroupBox";
    private const string KEY_activatePresetsCheckBox = "activatePresetsCheckBox";

    private const string KEY_saveAppSettingsButton = "saveAppSettingsButton";
    private const string KEY_exitAppSettingsButton = "exitAppSettingsButton";

    public GuiLocaleDescr_AppSettings()
    {
        FormName = "AppSettingsForm";

        LocalizedControls = new List<string>()
        {
            KEY_This,
            KEY_appColorThemeGroupBox,
            KEY_uiStyleByDefaultThemeRadioButton,
            KEY_uiStyleByLightThemeRadioButton,
            KEY_uiStyleByDarkThemeRadioButton,

            KEY_appLocalizationGroupBox,
            KEY_enableEngLocaleRadioButton,
            KEY_enableRusLocaleRadioButton,

            KEY_appFeaturesGroupBox,
            KEY_activatePresetsCheckBox,

            KEY_saveAppSettingsButton,
            KEY_exitAppSettingsButton,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
            {
                { KEY_This, "Application Settings" },
                { KEY_appColorThemeGroupBox, "Select GUI style theme" },
                { KEY_uiStyleByDefaultThemeRadioButton, "Standard Theme (by default)" },
                { KEY_uiStyleByLightThemeRadioButton, "Light Theme" },
                { KEY_uiStyleByDarkThemeRadioButton, "Dark Theme" },
                { KEY_appLocalizationGroupBox, "Select GUI language" },
                { KEY_enableEngLocaleRadioButton, "ENGLISH (by default)" },
                { KEY_enableRusLocaleRadioButton, "RUSSIAN (in progress)" },
                { KEY_appFeaturesGroupBox, "Experimental Settings" },
                { KEY_activatePresetsCheckBox, "Use Custom Presets to Initialize Your Mods" },
                { KEY_saveAppSettingsButton, "OK" },
                { KEY_exitAppSettingsButton, "CANCEL" },
            });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
            {
                { KEY_This, "Настройки Программы" },
                { KEY_appColorThemeGroupBox, "Выберите тему GUI программы" },
                { KEY_uiStyleByDefaultThemeRadioButton, "Стандартная тема (по умолчанию)" },
                { KEY_uiStyleByLightThemeRadioButton, "Светлая тема" },
                { KEY_uiStyleByDarkThemeRadioButton, "Темная тема" },
                { KEY_appLocalizationGroupBox, "Выберите язык GUI программы" },
                { KEY_enableEngLocaleRadioButton, "Английский (по умолчанию)" },
                { KEY_enableRusLocaleRadioButton, "Русский (в процессе)" },
                { KEY_appFeaturesGroupBox, "Экспериментальные настройки программы" },
                { KEY_activatePresetsCheckBox, "Использовать пользовательские предустановки для инициализации Ваших модификаций" },
                { KEY_saveAppSettingsButton, "СОХРАНИТЬ" },
                { KEY_exitAppSettingsButton, "ОТМЕНА" },
            });
    }
}

// Derived class for 'GameSetupConfigForm' form.
public class GuiLocaleDescr_GameSetupConfig : FormLocaleDescription
{
    private const string KEY_GameSetupConfigForm = "GameSetupConfigForm";
    private const string KEY_setupViewButton = "setupViewButton";
    private const string KEY_setupPathAddButton = "setupPathAddButton";
    private const string KEY_setupPathDeleteButton = "setupPathDeleteButton";
    private const string KEY_allPathsClearButton = "allPathsClearButton";
    private const string KEY_formOkButton = "formOkButton";

    public GuiLocaleDescr_GameSetupConfig()
    {
        FormName = "GameSetupConfigForm";
        LocalizedControls = new List<string>
        {
            KEY_GameSetupConfigForm,
            KEY_setupViewButton,
            KEY_setupPathAddButton,
            KEY_setupPathDeleteButton,
            KEY_allPathsClearButton,
            KEY_formOkButton,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_GameSetupConfigForm, "Game Setup Settings" },
            { KEY_setupViewButton, "VIEW GAME SETUP INFO" },
            { KEY_setupPathAddButton, "ADD SETUP PATH" },
            { KEY_setupPathDeleteButton, "DELETE SETUP PATH" },
            { KEY_allPathsClearButton, "CLEAR ALL PATHS" },
            { KEY_formOkButton, "OK" },
        });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_GameSetupConfigForm, "Настройка Игровой Установки" },
            { KEY_setupViewButton, "Сведения об Установке" },
            { KEY_setupPathAddButton, "Добавить Установку" },
            { KEY_setupPathDeleteButton, "Удалить Установку" },
            { KEY_allPathsClearButton, "Очистить Список Установок" },
            { KEY_formOkButton, "СОХРАНИТЬ" },
        });
    }
}

// Derived class for 'AddNewGameSetupForm' form.
public class GuiLocaleDescr_AddNewGameSetup : FormLocaleDescription
{
    private const string KEY_AddNewGameSetupForm = "AddNewGameSetupForm";
    private const string KEY_gameSetupGroupBox = "gameSetupGroupBox";
    private const string KEY_gameSetupNameLabel = "gameSetupNameLabel";
    private const string KEY_setupNameResetButton = "setupNameResetButton";
    private const string KEY_gameExecutablePathLabel = "gameExecutablePathLabel";
    private const string KEY_gameExecutableSelectPathButton = "gameExecutableSelectPathButton";
    private const string KEY_modcentersGroupBox = "modcentersGroupBox";
    private const string KEY_modcenterAppendButton = "modcenterAppendButton";
    private const string KEY_modcenterRemoveButton = "modcenterRemoveButton";
    private const string KEY_saveButton = "saveButton";
    private const string KEY_cancelButton = "cancelButton";

    public GuiLocaleDescr_AddNewGameSetup()
    {
        FormName = "AddNewGameSetupForm";
        LocalizedControls = new List<string>
        {
            KEY_AddNewGameSetupForm,
            KEY_gameSetupGroupBox,
            KEY_gameSetupNameLabel,
            KEY_setupNameResetButton,
            KEY_gameExecutablePathLabel,
            KEY_gameExecutableSelectPathButton,
            KEY_modcentersGroupBox,
            KEY_modcenterAppendButton,
            KEY_modcenterRemoveButton,
            KEY_saveButton,
            KEY_cancelButton,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_AddNewGameSetupForm, "Add New Game Setup" },
            { KEY_gameSetupGroupBox, "Game Setup Main Settings" },
            { KEY_gameSetupNameLabel, "Define Game Setup Name" },
            { KEY_setupNameResetButton, "Reset" },
            { KEY_gameExecutablePathLabel, "Set Game Executable Path" },
            { KEY_gameExecutableSelectPathButton, "Select" },
            { KEY_modcentersGroupBox, "Configure Paths to Your ModCenter" },
            { KEY_modcenterAppendButton, "Append ModCenter" },
            { KEY_modcenterRemoveButton, "Remove ModCenter" },
            { KEY_saveButton, "OK" },
            { KEY_cancelButton, "Cancel" },
        });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_AddNewGameSetupForm, "Добавить Новую Игровую Установку" },
            { KEY_gameSetupGroupBox, "Главные Настройки Игровой Установки" },
            { KEY_gameSetupNameLabel, "Имя Установки" },
            { KEY_setupNameResetButton, "Сброс" },
            { KEY_gameExecutablePathLabel, "EXE-файл Установки" },
            { KEY_gameExecutableSelectPathButton, "Выбрать" },
            { KEY_modcentersGroupBox, "Конфигурировать Пути Мод-Центров" },
            { KEY_modcenterAppendButton, "Добавить Мод-Центр" },
            { KEY_modcenterRemoveButton, "Удалить Мод-Центр" },
            { KEY_saveButton, "Добавить" },
            { KEY_cancelButton, "Отмена" },
        });
    }
}

// Derived class for 'CollectionCreateForm' form.
public class GuiLocaleDescr_CollectionCreateForm : FormLocaleDescription
{
    private const string KEY_CollectionCreateForm = "CollectionCreateForm";
    private const string KEY_collectionNameLabel = "collectionNameLabel";
    private const string KEY_modsSelectionLabel = "modsSelectionLabel";
    private const string KEY_buttonOK = "buttonOK";
    private const string KEY_buttonCancel = "buttonCancel";

    public GuiLocaleDescr_CollectionCreateForm()
    {
        FormName = "CollectionCreateForm";
        LocalizedControls = new List<string>
        {
            KEY_CollectionCreateForm,
            KEY_collectionNameLabel,
            KEY_modsSelectionLabel,
            KEY_buttonOK,
            KEY_buttonCancel
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_CollectionCreateForm, "Create a New Collection" },
            { KEY_collectionNameLabel, "Input a Name of a New Collection:" },
            { KEY_modsSelectionLabel, "Select Mods for a New Collection:" },
            { KEY_buttonOK, "OK" },
            { KEY_buttonCancel, "Cancel" },
        });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_CollectionCreateForm, "Создать Новую Коллекцию" },
            { KEY_collectionNameLabel, "Введите имя новой коллекции:" },
            { KEY_modsSelectionLabel, "Выберите моды для новой коллекции:" },
            { KEY_buttonOK, "Создать" },
            { KEY_buttonCancel, "Отмена" },
        });
    }
}

// Derived class for 'CollectionManageForm' form.
public class GuiLocaleDescr_CollectionManageForm : FormLocaleDescription
{
    private const string KEY_CollectionManageForm = "CollectionManageForm";
    private const string KEY_groupBoxCollectionsDelete = "groupBoxCollectionsDelete";
    private const string KEY_collectionsSelectionLabel = "collectionsSelectionLabel";
    private const string KEY_buttonCollectionsDelete = "buttonCollectionsDelete";
    private const string KEY_buttonCollectionsSelectAll = "buttonCollectionsSelectAll";
    private const string KEY_buttonCollectionsDeselectAll = "buttonCollectionsDeselectAll";

    public GuiLocaleDescr_CollectionManageForm()
    {
        FormName = "CollectionManageForm";
        LocalizedControls = new List<string>
        {
            KEY_CollectionManageForm,
            KEY_groupBoxCollectionsDelete,
            KEY_collectionsSelectionLabel,
            KEY_buttonCollectionsDelete,
            KEY_buttonCollectionsSelectAll,
            KEY_buttonCollectionsDeselectAll,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_CollectionManageForm, "Manage Your Collections" },
            { KEY_groupBoxCollectionsDelete, "Select Collections to Delete" },
            { KEY_collectionsSelectionLabel, "Delete Selected" },
            { KEY_buttonCollectionsDelete, "Delete Selected" },
            { KEY_buttonCollectionsSelectAll, "Select All" },
            { KEY_buttonCollectionsDeselectAll, "Deselect All" },
        });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_CollectionManageForm, "Управление Коллекциями" },
            { KEY_groupBoxCollectionsDelete, "Удаление существующих коллекций" },
            { KEY_collectionsSelectionLabel, "Выберите коллекции для удаления" },
            { KEY_buttonCollectionsDelete, "Удалить Выбранное" },
            { KEY_buttonCollectionsSelectAll, "Выбрать ВСЕ" },
            { KEY_buttonCollectionsDeselectAll, "Отменить ВСЕ" },
        });
    }
}

// Derived class for 'ModConfigSettingsForm' form.
public class GuiLocaleDescr_ModConfigSettings : FormLocaleDescription
{
    public GuiLocaleDescr_ModConfigSettings()
    {
        FormName = "ModConfigSettingsForm";
        LocalizedControls = new List<string>();
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()); // test
    }
}

// Derived class for 'ModQuickNavigatorForm' form.
public class GuiLocaleDescr_ModQuickNavigator : FormLocaleDescription
{
    private const string KEY_ModQuickNavigatorForm = "ModQuickNavigatorForm";
    private const string KEY_labelCommonInfo = "labelCommonInfo";
    private const string KEY_formExitButton = "formExitButton";

    public GuiLocaleDescr_ModQuickNavigator()
    {
        FormName = "ModQuickNavigatorForm";

        LocalizedControls = new List<string>
        {
            KEY_ModQuickNavigatorForm,
            KEY_labelCommonInfo,
            KEY_formExitButton,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_ModQuickNavigatorForm, "Mod Quick Navigation" },
            { KEY_labelCommonInfo, "Navigate to specified mod folder by pressing the following buttons" },
            { KEY_formExitButton, "CLOSE" },
        });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_ModQuickNavigatorForm, "Быстрая Мод-Навигация" },
            { KEY_labelCommonInfo, "Перейти в указанную мод-директорию с помощью следующих кнопок" },
            { KEY_formExitButton, "ЗАКРЫТЬ" },
        });
    }
}

// Derived class for 'AboutProjectForm' form.
public class GuiLocaleDescr_AboutProject : FormLocaleDescription
{
    private const string KEY_AboutProjectForm = "AboutProjectForm";
    private const string KEY_aboutProjectNameLabel3 = "aboutProjectNameLabel3";
    private const string KEY_aboutProjectNameLabel4 = "aboutProjectNameLabel4";

    public GuiLocaleDescr_AboutProject()
    {
        FormName = "AboutProjectForm";
        LocalizedControls = new List<string>
        {
            KEY_AboutProjectForm,
            KEY_aboutProjectNameLabel3,
            KEY_aboutProjectNameLabel4,
        };
    }

    public override string FormName { get; }

    public override List<string> LocalizedControls { get; }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_ENG()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_AboutProjectForm, "About Program" },
            { KEY_aboutProjectNameLabel3, "Version Preview 2023.3" },
            { KEY_aboutProjectNameLabel4, "is Master_TW_DAR's initiative for M2TW community" },
        });
    }

    public override FormLocaleSnapshot CreateLocaleSnapshotFor_RUS()
    {
        return new FormLocaleSnapshot(FormName, new Dictionary<string, string>()
        {
            { KEY_AboutProjectForm, "О программе" },
            { KEY_aboutProjectNameLabel3, "Альфа-Версия 2023.3" },
            { KEY_aboutProjectNameLabel4, "новый проект Master_TW_DAR в сообществе M2TW" },
        });
    }
}
