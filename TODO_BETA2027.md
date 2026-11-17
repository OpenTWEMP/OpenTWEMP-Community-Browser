# :bomb: OpenTWEMP Community Browser BETA 2027

This document contains description of tasks for the **BETA 2027** release.

I use the following tags to mark current priorities for each idea in this draft:

- `[NOW]` - to be done in the current release
- `[LATER]` - to be done in future releases
- `[MAYBE]` - not sure if it should be implemented

I use the following tags to mark current estimations for every idea in this draft:

- `[EASY]` - straightforward, no obvious difficulties
- `[NORM]` - feasible, but involves unknown risks
- `[HARD]` - feasible, but requires significant effort

I combine these tags as follows:

`[NOW:EASY]` - This idea should be implemented in this release and can be done easily.

---

## :zap: BETA 2027 RELEASE - "Housekeeping" Update 2026/12

### :dart: `[BETA2027_001]` `[NOW:NORM]` Read and Write Game Setup Information via Serialization

- [ ] Re-design the TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation.GameSetupConfFileBuilder class implementation to read and write setup.conf config file via XML/JSON serialization.

### :dart: `[BETA2027_002]` `[NOW:NORM]` Incorrect Assigning Mod Presets after Adding or Deleting a Mod Distro to a Game Mod Center

- [ ] Fix wrong behavior when mod presets are attached incorrectly to items of collections after modifying physical directory content of a game mod center (after manually adding a new mod distro to a mod center or deleting an existing mod distro from a mod center).

### :dart: `[BETA2027_003]` `[NOW:NORM]` Beta 2027 Release Engineering Preparations

See details: [TWEMP.Browser.QA.UnitTesting\TODO-TWEMP.Browser.Core.CommonLibrary.md](TWEMP.Browser.QA.UnitTesting\TODO-TWEMP.Browser.Core.CommonLibrary.md)

- [ ] **Create unit tests for existing features**:
  - [ ] *Unit tests for classes from TWEMP.Browser.App.Classic.CommonLibrary*
  - [ ] *Unit tests for classes from TWEMP.Browser.App.Classic.CommonLibrary*
  - [ ] *Unit tests for classes from TWEMP.Browser.App.Classic.GamingSupport*

- [ ] **Refactoring for classes from TWEMP.Browser.App.Classic.WinForms**:
  - [ ] MainBrowserForm.GameCollections.cs : Simplify the ButtonMarkFavoriteMod_Click() procedure.
  - [ ] MainBrowserForm.GameLauncher.cs : Simplify the ButtonLaunch_Click() procedure.
  - [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the UpdateAllModificationsInTreeView() method.
  - [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the TreeViewGameMods_AfterSelect() procedure.
  - [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the IsNotModificationNode() method.
  - [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the FindModificationBySelectedTreeNode() method.
  - [ ] MainBrowserForm.GameModsTreeView.cs : Use an enumeration type for available tree node levels instead of hard code literal values.
  - [ ] MainBrowserForm.GuiStyles.cs : Simplify the UpdateGUIStyle() method.
  - [ ] MainBrowserForm.Localization.cs : Simplify the SetupCurrentLocalizationForGUIControls() method.

- [ ] **Refactoring for classes from TWEMP.Browser.App.Classic.CommonLibrary**:
  - [ ] AddNewGameSetupForm.cs : Simplify the CanSaveNewGameSetup() method.
  - [ ] AppSettingsForm.cs : Simplify the SetupCurrentLocalizationForGUIControls() method.
  - [ ] AppSettingsForm.cs : Simplify the InitializeCurrentGUIStyle() method.
  - [ ] CollectionCreateForm.cs : Simplify the ButtonOK_Click() procedure.
  - [ ] Simplify the ModQuickNavigatorForm class.
  - [ ] ModSupportPresetSettingsForm.cs : Simplify the InitializeModSupportPresetsDataGridView() method.
  - [ ] ModSupportPresetSettingsForm.cs : Simplify the InitializeModSupportPresetDataGridViewRow() method.
  - [ ] ModSupportPresetSettingsForm.cs : Simplify the ModSupportPresetsDataGridView_CellContentClick() procedure.
  - [ ] ModSupportPresetSettingsForm.cs : Simplify the ApplyButton_Click() procedure.
  - [ ] GameConfigProfileCreateForm.cs : Simplify the LoadGameConfigSettingsForm() method.
  - [ ] GameConfigProfileCreateForm.cs : Simplify the FormOkButton_Click() procedure.

---

## :notebook: BETA 2027 RELEASE - ALL TASKS ( DRAFTS | RU )

### :star: `[BETA2027_SCOPE1]` Внедрение частично реализованных функциональных возможностей программы

#### :dart: `[LATER:NORM]` Добавить функциональность конфигурирования мода через пользовательские профили

- [ ] Реализовать функционал для создания, обновления, удаления, импорта, экспорта и бэкапа профилей игровой конфигурации.
- [ ] Создать интерфейс управления профилями игровых конфигураций пользователя (выбор профиля конфигурации для запуска мода).
- [ ] Подготовить стандартные профили конфигурации для пользователей браузера (как минимум, профили для гейминга и моддинга).

#### :dart: `[LATER:NORM]` Расширить функциональность пользовательских коллекций для управления библиотекой модов

- [ ] Заменить отображение технического идентификатора на уникальное название модификации из предустановки.
- [ ] Протестировать механизм пользовательских коллекций и устранить обнаруженные дефекты и ошибки в программе.
- [ ] Расширить функциональность коллекций функцией просмотра текущего содержимого существующей коллекции.
- [ ] Расширить функциональность коллекций функцией изменения текущего содержимого существующей коллекции.
- [ ] Реализовать отображение иконок модификаций слева от названия мода в каждом элементе списка коллекции.

### :star: `[BETA2027_SCOPE2]` Улучшение существующих функциональных возможностей программы

#### :dart: `[LATER:NORM]` Изменить текущую тему персонализации графического интерфейса программы

- [ ] Разработать надежный способ изменения цветовой темы графического интерфейса программы во время выполнения.
- [ ] Реализовать стартовую поддержку 3 встроенных графических тем - стандартная, дневная (светлая) и ночная (темная).
- [ ] Расширить стартовый набор цветовых тем вспомогательными темами в стиле игровой цветовой гаммы меню M2TW и RTW.

#### :dart: `[MAYBE:HARD]` Изменить текущий язык локализации пользовательского интерфейса программы

- [ ] Перепроектировать способ изменения языка локализации графического интерфейса программы (использовать файлы ресурсов).
- [ ] Использовать английский язык по умолчанию в программе, остальные локализации вынести во внешние файлы ресурсов.
- [ ] Реализовать исходную поддержку 2 языков локализации программы (английский по умолчанию + обязательно русский).

#### :dart: `[MAYBE:HARD]` Усовершенствовать поддержку опций игровой конфигурации M2TW

- [ ] Улучшить интерфейс для ручной установки значений опций конфигурации мода перед запуском из браузера.
- [ ] Загружать состояние настроек конфигурации для текущего выбранного профиля конфигурации пользователя.
- [ ] Необходимо выделить опции конфигурации игры, которые являются известными и которые являются непонятными.
- [ ] Определиться, какие значения опций конфигурации игры будут предлагаться в качестве значений по умолчанию.

#### :dart: `[MAYBE:HARD]` Усовершенствовать поддержку воспроизведения фоновой музыки

- [ ] Доработать функциональную возможность изменения текущего уровня громкости воспроизведения фоновой музыки.
- [ ] Улучшить пользовательский интерфейс для управления процессом воспроизведения фоновой музыки в браузере.
- [ ] Реализовать опцию включения/отключения функции воспроизведения фоновой музыки в настройках программы.

#### :dart: `[MAYBE:HARD]` Усовершенствовать механизм обнаружения игровой установки M2TW

- [ ] Реализовать функцию автоматического обнаружения уже установленных экземпляров игры на компьютере пользователя.
- [ ] Реализовать автоматический подбор рекомендаций по выбору предустановок по умолчанию для обнаруженных модификаций.

### :star: `[BETA2027_SCOPE3]` Разработка новых функциональных возможностей программы

#### :dart: `[LATER:NORM]` Создать инструмент вычисления игровых лимитов выбранного мода

Реализовать функциональность сбора и показа технической статистики выбранного мода для получения оценки об использовании игровых лимитов мода.

#### :dart: `[LATER:NORM]` Создать инструмент просмотра и анализа лог-файлов выбранного мода

Реализовать функциональность чтения/анализа/вывода информации из лог-журналов игры для получения всей необходимой информации об ошибках и трассировке.

#### :dart: `[LATER:NORM]` Создать инструмент резервного копирования указанных файлов мода

Реализовать функциональность создания снимка-бэкапа всех текстовых файлов выбранного мода для моментального создания резервной копии.

#### :dart: `[LATER:NORM]` Создать инструмент упаковки игровых сохранений и журналов

Реализовать функциональность быстрой упаковки в архив файлов сохранений и журналов для удобства обмена между пользователями.

#### :dart: `[MAYBE:HARD]` Создать стандартное средство нативного конфигуратора для модов M2TW

Перепроектировать автономное расширение M2TW-Addons-Setup-Framework в универсально применимый конфигуратор наиболее часто используемых игровых настроек модификаций M2TW.

Подробнее: [.roadmap\TODO-SubmodSwitcherExtension.md](.roadmap\TODO-SubmodSwitcherExtension.md)

#### :dart: `[MAYBE:HARD]` Разработка экспериментального менеджера плагинов для расширения функциональности программы

**Создать базовую функциональность менеджера плагинов:**

- [ ] Подготовить стартовые проекты менеджера плагинов на основе каркаса OpenTWEMP-Software-Manager.
- [ ] Реализовать основные функции менеджера плагинов (типичные команды любого менеджера пакетов ПО).
- [ ] Обустроить локальный репозиторий встроенных плагинов в корневой директории данной программы.

**Сформировать стартовый репозиторий встроенных плагинов:**

- [ ] Выбрать несколько популярных инструментов TWE-MDK для адаптации в качестве плагинов.
- [ ] Провести эксперимент по адаптации избранных инструментов TWE-MDK в локальный репозиторий.
- [ ] Попробовать запустить адаптированные инструменты из-под браузера для некоторого мода.

### :star: `[BETA2027_SCOPE4]` Усовершенствовать поддержку программой существующих модификаций M2TW

#### :dart: `[LATER:HARD]` Разработать базовую функциональность управления пресетами модификаций M2TW

- [ ] Реализовать интерфейс создания пользовательских мод-пресетов для любых модификаций из игровых установок.
- [ ] Реализовать интерфейс для ручного конфигурирования мод-пресетов для модов существующих из игровых установок.
- [ ] Реализовать автоматический подбор рекомендаций по установке мод-пресетов для обнаруженных модификаций.

#### :dart: `[LATER:HARD]` Подготовить сводную информацию о поддержке существующих модификаций M2TW

- [ ] Расширить пакет мод-пресетов для отсутствующих модификаций M2TW (желательно создать 100-200 мод-пресетов).
- [ ] Составить полный список поддерживаемых программой модификаций M2TW с указанием ссылок на данные проекты.
- [ ] Генерировать список поддерживаемых программой модификаций M2TW на основе существующих мод-пресетов.
- [ ] Опубликовать составленный список поддерживаемых модов (официальный сайт и форумные представительства).
- [ ] Предоставить необходимую информацию для получения обратной связи от разработчиков модификаций M2TW.

### :star: `[BETA2027_SCOPE5]` Усовершенствование нефункциональных возможностей программы

#### :dart: `[LATER:NORM]` Добавить функциональность журналирования в программу

- [ ] Определить наиболее важные события и ошибки, которые следует регистрировать в журнале программы.
- [ ] Определиться с параметрами журнала регистрации сообщений (размер журнала, расположение, название и т.д.).
- [ ] Реализовать унифицированный механизм регистратора сообщений программы (независимый от сторонних реализаций).
- [ ] Внедрить сообщения регистратора событий программы в базовую функциональность приложения браузера.
- [ ] Выбрать оптимальное стороннее решение от существующих поставщиков библиотек журналирования.

*Типичными событиями для регистрации записей в файлы журнала могут быть выполнение следующих действий:*

- *Сканирование игровых установок*
- *Обнаружение установленных модификаций*
- *Прикрепление мод-пресетов к модификациям*
- *Управление модификациями в коллекциях*
- *Управление профилями конфигурации*
- *Запуск модификаций тем или иным способом*

#### :dart: `[MAYBE:HARD]` Добавить тесты измерения производительности для наиболее критичных участков кода

- [ ] Реализовать измерение производительности для функциональности обнаружения игровых установок, мод-центров и модификаций
- [ ] Реализовать измерение производительности для автоматической установки пресетов для обнаруженных модификаций пользователя
- [ ] Подумать, какие возможности программы могут требовать измерения производительности и какие метрики могут потребоваться для этих целей.

---
