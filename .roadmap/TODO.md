# OpenTWEMP Community Browser 2025+

---

## 2025: GAME MODS SUPPORT

### **⭐ Share Summary for Support of M2TW Mods**

Обязательные задачи:

* Составить полный список поддерживаемых программой модификаций M2TW с указанием ссылок на проекты модов
* Опубликовать указанный список поддержки модов (официальный сайт и форумные представительства)

Необязательные задачи:

* Предоставить информацию об обратной связи для разработчиков модификаций M2TW

Примечания:

* Рассмотреть возможность генерации вышеуказанной документации на основе мод-пресетов (использовать как русский и английский языки)

### **⭐ Mod Preset Management for M2TW Mods**

Обязательные задачи:

* Реализовать интерфейс для создания собственных пользовательских предустановок для любых модификаций из игровых установок
* Реализовать интерфейс для ручного конфигурирования предустановок для модов существующих игровых установок пользователя

Необязательные задачи:

* Реализовать автоматический подбор рекомендаций по выбору предустановок по умолчанию для обнаруженных модификаций

### **⭐ Mod Support Expansion 2025+**

Существенно расширить пакет предустановок по умолчанию для популярных модификаций M2TW (желательно создать от 100 до 200 мод-пресетов).

---

## 2025!: NEW FEATURES - PART I

### **⭐ 2025! - Mod Configuration via Custom Profiles**

Обязательные задачи:

* Реализовать интерфейс для управления профилями игровых конфигураций пользователя для запуска модификаций средствами браузера
* Обеспечить пользователя средствами для создания, обновления, удаления, импорта, экспорта и бэкапа профилей игровой конфигурации

Необязательные задачи:

* Подготовить стандартные профили конфигурации, рекомендуемые пользователям браузера (как минимум, профили для гейминга и моддинга)

### **⭐ 2025! - Mod Management via Custom Collections**

Обязательные задачи:

* Протестировать механизм пользовательских коллекций и устранить обнаруженные дефекты и ошибки в программе
* Расширить функциональность коллекций функцией изменения содержимого существующей коллекции
* Расширить функциональность коллекций функцией просмотра содержимого существующей коллекции

Необязательные задачи:

* Реализовать отображение уникального названия модификации из предустановки вместо технического идентификатора
* Реализовать отображение иконок модификаций слева от названия мода в каждом элементе списка коллекции

---

## 2025?: NEW FEATURES - PART II

### **Встраивание OpenTWEMP-Toolbox-Dashboard**

Подумать о том, как подойти к встраиванию набора инструментов TWE-MDK в панель приборов данного приложения.

### **Встраивание OpenTWEMP-Software-Manager**

Сделать OpenTWEMP-Software-Manager частью текущего проекта.

### **Интеграция расширения M2TW-Addons-Setup-Framework**

Подробное описание задачи: [.roadmap\TODO-SubmodSwitcherExtension.md](.roadmap\TODO-SubmodSwitcherExtension.md)

### *Быстрая упаковка игровых сохранений и журналов для обмена пользователями*

Реализовать механизм для быстрой упаковки в архив игровых файлов сохранений и журналов для удобства обмена между пользователями.

### *Быстрый бэкап всех указанных файлов выбранного мода*

Сделать быстрый снимок-бэкап всех текстовых файлов выбранного мода.

### *Быстрое вычисление игровых лимитов выбранного мода*

Показать статистику использования игровых лимитов выбранного мода.

---

## 2025+: NEW FEATURES - PART III

### **:star: Design Modern Cross-Platform GUI**

* Принять решение о модернизации классического графического интерфейса для Windows (Windows Forms => WPF)
* Выбрать кросс-платформенный GUI-фреймворк (MAUI/Blazor Hybrid/Edge WebView2/Avalonia UI/Uno Platform)
* Реализовать базовые элементы управления GUI на основе существующего интерфейса классического приложения
* Реализовать механизм изменения цветовой схемы в новом графическом интерфейсе на основе существующего кода
* Реализовать механизм изменения языка локализации в новом графическом интерфейсе на основе существующего кода
* Подготовить несколько различных виртуальных машин для тестирования обновленного графического интерфейса

### *Эксперимент: Локальная база данных приложения*

Попробовать сохранять наиболее важные пользовательские параметры в локальной базе данных (SQLite или NoSQL-решение).

### *Эксперимент: Служба-работник приложения*

Попробовать задействовать экспериментальную службу-работник приложения (обдумать потенциальные варианты использования).

---

## 2025: IMPROVEMENTS + FIXES

### **⭐ Improved GameSetup Detecting**

Обязательные задачи:

* Перепроектировать механизм чтения/записи конфигурации игровых установок пользователя на основе сериализации
* Исправить проблему синхронизации пресетов при изменении содержимого игровой установки/модцентра

Необязательные задачи:

* Подумать о возможности реализовать автоматическое обнаружение игровых установок на компьютере пользователя
* Реализовать автоматический подбор рекомендаций по выбору предустановок по умолчанию для обнаруженных модификаций

### **⭐ Full Support of M2TW Config Settings**

* Необходимо выделить опции конфигурации игры, которые являются известными и которые являются непонятными
* Определиться, какие значения опций конфигурации игры будут предлагаться в качестве значений по умолчанию
* Улучшить интерфейс для ручной установки значений опций конфигурации мода перед запуском из браузера
* Загружать состояние настроек конфигурации для текущего профиля конфигурации пользователя

### **⭐ Change App's Localization Language**

* Перепроектировать способ изменения языка локализации графического интерфейса программы (использовать файлы ресурсов)
* Приложение должно поддерживать 2 языка локализации программы (английский по умолчанию + обязательно русский)
* Реализовать способ для внедрения поддержки новых языков локализации программы (на усмотрение сообщества)

Примечание: Следует использовать английский язык по умолчанию, остальные локализации вынести во внешние файлы.

### **⭐ Background Music Playing Support**

* Доработать функцию изменения уровня громкости воспроизведения фоновой музыки
* Улучшить интерфейс для управления воспроизведением фоновой музыки в браузере
* Добавить возможность отключить воспроизведение музыки в настройках программы

### **⭐ Change App's Color Style Theme**

* Разработать надежный способ изменения цветовой темы графического интерфейса программы во время выполнения
* Приложение должно поддерживать 3 темы по умолчанию - стандартная тема, дневная (светлая) тема и ночная (темная) тема
* Расширить стартовый набор цветовых тем вспомогательными темами в стиле игровой цветовой гаммы меню M2TW и RTW
* Реализовать способ для создания новых пользовательских цветовых тем графического интерфейса программы

---

## 2025: SOFTWARE QUALITY ASSURANCE

### **Add Logging to the Project**

* Определить наиболее важные события и ошибки, которые следует регистрировать в журнале программы
* Определиться с параметрами журнала регистрации сообщений (размер журнала, расположение, название и т.д.)
* Реализовать унифицированный механизм регистратора сообщений программы (независимый от сторонних реализаций)
* Внедрить сообщения регистратора событий программы в базовую функциональность приложения браузера
* Выбрать оптимальное стороннее решение от существующих поставщиков библиотек журналирования

Примечание: Typical events for loggings are the following:

* Scanning game setup
* Detecting modifications
* Attaching mod presets
* Collection management
* Config profile management
* Launching modifications

### **Create Unit Tests for Code Libraries**

* Необходимо покрыть модульными тестами фундаментальную функциональность приложения браузера
* Необходимо покрыть модульными тестами функциональность игровой поддержки модификаций M2TW

Стартовая точка: [TWEMP.Browser.QA.UnitTesting\TODO-TWEMP.Browser.Core.CommonLibrary.md](TWEMP.Browser.QA.UnitTesting\TODO-TWEMP.Browser.Core.CommonLibrary.md)

### **Add Benchmarking the Project**

* Необходимо реализовать измерение производительности для функциональности обнаружения игровых установок, мод-центров и модификаций
* Необходимо реализовать измерение производительности для автоматической установки пресетов для обнаруженных модификаций пользователя
* Подумать, какие возможности программы могут требовать измерения производительности и какие метрики могут потребоваться для этих целей.

### **Create CI Pipeline via GitHub Actions**

* Необходимо автоматизировать запуск процесса построения приложения из исходного кода
* Необходимо автоматизировать запуск процессов автоматизированного тестирования проекта
* Необходимо автоматизировать процесс построения инсталляционных пакетов приложения
* Необходимо автоматизировать процесс обработки результатов запуска CI/CD конвейера проекта

### **Automate App Deployment Configuration**

* Определиться со списком поддерживаемых приложением целевых платформ и операционных систем
* Принять решение о способе развертывания приложения на компьютере конечного пользователя

Automate configurations for deployment the application for the following scenarios:

* Development (Debug/Release)
* Production (Publish)

Use PowerShell as an automation tool.

### **Provide Delivery for App Builds**

Принять решение о способе поставки артефактов приложения конечному пользователю (как распространять приложение в Интернете?)

Investigate ways how to implement delivery new application builds via the following:

* Creating artifacts via GitHub Actions
* Creating MSI installers
* Creating archives via CLI
* Using third-party installers
* Chocolatey, WinGet and other package managers.

As a result, end users will have ability to download app's releases from this repo on the releases page.

### Рефакторинг Кодовой Базы

TWEMP.Browser.App.Classic.WinForms

* [ ] MainBrowserForm.GameCollections.cs : Simplify the ButtonMarkFavoriteMod_Click() procedure.
* [ ] MainBrowserForm.GameLauncher.cs : Simplify the ButtonLaunch_Click() procedure.
* [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the UpdateAllModificationsInTreeView() method.
* [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the TreeViewGameMods_AfterSelect() procedure.
* [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the IsNotModificationNode() method.
* [ ] MainBrowserForm.GameModsTreeView.cs : Simplify the FindModificationBySelectedTreeNode() method.
* [ ] MainBrowserForm.GameModsTreeView.cs : Use an enumeration type for available tree node levels instead of hard code literal values.
* [ ] MainBrowserForm.GuiStyles.cs : Simplify the UpdateGUIStyle() method.
* [ ] MainBrowserForm.Localization.cs : Simplify the SetupCurrentLocalizationForGUIControls() method.

TWEMP.Browser.App.Classic.CommonLibrary

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

### Качество Кодовой Базы

* Проверить исходный код на соответствие ширины текста 80 символам (в лучшем случае).
* Проверить исходный код на соответствие текста набору символов из кодировки ASCII.

---
