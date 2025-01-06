# TODO - Submod Switcher Extension

---

## Задача № 1 - Создать совместно используемую библиотеку классов для расширения

Название нового проекта: "TWEMP.Browser.Extension.M2TW-Addons-Setup-Framework"

Библиотека классов должна быть основана на определениях сущностей из следующих проектов:

* TWE-Submod-Switcher
* TWE-Submod-Switcher-WinForms

Данная библиотека будет совместно использоваться приложениями-конфигураторами сабмодов для M2TW.

## Задача № 2 - Создать библиотеку классов Windows Forms для расширения M2TW-Addons-Setup-Framework

Название нового проекта: "TWEMP.Browser.Extension.M2TW-Addons-Setup-Framework.WinForms"

Данная библиотека классов будет использовать следующим образом:

* как подключаемый модуль для автономной программы-конфигуратора (аналогично BS_Setup.exe)
* как подключаемый модуль для OpenTWEMP Community Browser (как расширение функциональности)

## Задача № 3 - Создать консольное приложение для быстрого переключения локализации мода

Название нового проекта: "TWEMP.Browser.App.Utilities-CLI.M2TW-Localization-Switcher"

Данное консольное приложение должно быть основано на библиотеке TWEMP.Browser.Extension.M2TW-Addons-Setup-Framework.

Необходимо адаптировать данную программу к частному случаю использования в проекте BULAT STEEL.

Это приложение является финальной версией программы TWE-Submod-Switcher и создается по запросу команды BULAT STEEL.

## Задача № 4 - Создать GUI-приложение конфигуратора сабмодов для мода M2TW

Название нового проекта: "TWEMP.Browser.App.Utilities-GUI.M2TW-Addons-Setup"

Данное консольное приложение должно быть основано на библиотеке TWEMP.Browser.Extension.M2TW-Addons-Setup-Framework.

Необходимо адаптировать данную программу к частному случаю использования в проекте BULAT STEEL (замена BS_Setup.exe).

Это приложение является финальной версией программы TWE-Submod-Switcher-WinForms и создается по запросу команды BULAT STEEL.

## Задача № 5 - Интеграция расширения M2TW-Addons-Setup-Framework в составе OpenTWEMP Community Browser

Осуществить встраивание расширения M2TW-Addons-Setup-Framework в приложение OpenTWEMP Community Browser.

Данная интеграция подразумевает взаимодействие следующих программных компонентов:

* TWEMP.Browser.Extension.M2TW-Addons-Setup-Framework внедряется как зависимость в TWEMP.Browser.App.Classic.WinForms
* TWEMP.Browser.Extension.M2TW-Addons-Setup-Framework.WinForms внедряется как зависимость в TWEMP.Browser.App.Classic.WinForms

Возможно, в подобных целях следует создать отдельную функциональность менеджера расширений для OpenTWEMP Community Browser.

---
