// <copyright file="GameSetupConfFileBuilderTest.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.QA.UnitTesting.CoreFeaturesTests.CustomManagement.Gaming.Installation;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;

public class GameSetupConfFileBuilderTest
{
    private const string ObsoleteTestMessage = "This test is aimed to verify legacy code. The test method will be deleted after re-design codebase !!!";

    [Test]
    public void CreateConfigFilePathWhenInitialization()
    {
        const string ConfigDirectoryPath = "C:\\Users\\User\\AppData\\TWEMP";
        const string ConfigFileName = "setup.conf";

        GameSetupConfFileBuilder sut = GameSetupConfFileBuilder.Create(ConfigDirectoryPath);

        Assert.That(sut.ConfigFilePath, Is.EqualTo($"{ConfigDirectoryPath}\\{ConfigFileName}"));
    }

    [TestCase(GameSetupConfFileBuilder.AppVersionMarkupElement)]
    [TestCase(GameSetupConfFileBuilder.GameSetupInfoMarkupElement)]
    [TestCase(GameSetupConfFileBuilder.ExecutableMarkupElement)]
    [TestCase(GameSetupConfFileBuilder.ModCenterMarkupParentElement)]
    [TestCase(GameSetupConfFileBuilder.ModCenterMarkupChildElement)]
    public void GetConfigMarkupOpeningTag(string element)
    {
        string expectedTag = "<" + element + ">";

        string actualTag = GameSetupConfFileBuilder.GetConfigMarkupOpeningTag(element);

        Assert.That(actualTag, Is.EqualTo(expectedTag));
    }

    [TestCase(GameSetupConfFileBuilder.AppVersionMarkupElement)]
    [TestCase(GameSetupConfFileBuilder.GameSetupInfoMarkupElement)]
    [TestCase(GameSetupConfFileBuilder.ExecutableMarkupElement)]
    [TestCase(GameSetupConfFileBuilder.ModCenterMarkupParentElement)]
    [TestCase(GameSetupConfFileBuilder.ModCenterMarkupChildElement)]
    public void GetConfigMarkupClosingTag(string element)
    {
        string expectedTag = "</" + element + ">";

        string actualTag = GameSetupConfFileBuilder.GetConfigMarkupClosingTag(element);

        Assert.That(actualTag, Is.EqualTo(expectedTag));
    }

    [Test]
    public void GetGameSetupInfoOpeningTag()
    {
        const string GameSetupName = "My Steam M2TW Setup";
        string expectedTag = "<GameSetupInfo Name=\"" + GameSetupName + "\">";

        string actualTag = GameSetupConfFileBuilder.GetGameSetupInfoOpeningTag(GameSetupName);

        Assert.That(actualTag, Is.EqualTo(expectedTag));
    }

    [Test]
    public void GetGameSetupInfoClosingTag()
    {
        string actualTag = GameSetupConfFileBuilder.GetGameSetupInfoClosingTag();
        Assert.That(actualTag, Is.EqualTo("</GameSetupInfo>"));
    }

    [TestCase(@"D:\SteamLibrary\steamapps\common\Medieval II Total War\medieval2.exe")]
    [TestCase(@"E:\Games\SEGA\Medieval II Total War\kingdoms.exe")]
    public void GetExecutableMarkupElement(string executableFilePath)
    {
        string expectedElement = $"<Executable>{executableFilePath}</Executable>";

        string actualElement = GameSetupConfFileBuilder.GetExecutableMarkupElement(executableFilePath);

        Assert.That(actualElement, Is.EqualTo(expectedElement));
    }

    [Test]
    public void GetModCenterParentOpeningTag()
    {
        string actualTag = GameSetupConfFileBuilder.GetModCenterParentOpeningTag();
        Assert.That(actualTag, Is.EqualTo("<AttachedModCenters>"));
    }

    [Test]
    public void GetModCenterParentClosingTag()
    {
        string actualTag = GameSetupConfFileBuilder.GetModCenterParentClosingTag();
        Assert.That(actualTag, Is.EqualTo("</AttachedModCenters>"));
    }

    [TestCase(@"D:\SteamLibrary\steamapps\common\Medieval II Total War\mods")]
    [TestCase(@"E:\Games\SEGA\Medieval II Total War\mods")]
    public void GetModCenterMarkupChildElement(string modcenterDirectoryPath)
    {
        string expectedElement = $"<ModCenter>{modcenterDirectoryPath}</ModCenter>";

        string actualElement = GameSetupConfFileBuilder.GetModCenterMarkupChildElement(modcenterDirectoryPath);

        Assert.That(actualElement, Is.EqualTo(expectedElement));
    }

    [Test]
    public void GetSingleGameSetupInfoConfigMarkup()
    {
        const string GameSetupName = "STEAM-M2TW";
        const string GameSetupExecutable = @"D:\SteamLibrary\steamapps\common\Medieval II Total War\medieval2.exe";
        const string ModCenterByDefault = @"D:\SteamLibrary\steamapps\common\Medieval II Total War\mods";
        const string ModCenterForModding = @"D:\SteamLibrary\steamapps\common\Medieval II Total War\mods_modding";
        const string ModCenterForTesting = @"D:\SteamLibrary\steamapps\common\Medieval II Total War\mods_testing";

        string expectedMarkup = $"<GameSetupInfo Name=\"{GameSetupName}\">\n" +
            $"\t<Executable>{GameSetupExecutable}</Executable>\n" +
            "\t<AttachedModCenters>\n" +
            $"\t\t<ModCenter>{ModCenterByDefault}</ModCenter>\n" +
            $"\t\t<ModCenter>{ModCenterForModding}</ModCenter>\n" +
            $"\t\t<ModCenter>{ModCenterForTesting}</ModCenter>\n" +
            "\t</AttachedModCenters>\n" +
            "</GameSetupInfo>";

        string actualMarkup = GameSetupConfFileBuilder.GetSingleGameSetupInfoConfigMarkup(
            GameSetupName, GameSetupExecutable, new string[] { ModCenterByDefault, ModCenterForModding, ModCenterForTesting });

        Assert.That(actualMarkup, Is.EqualTo(expectedMarkup));
    }

    [Obsolete(ObsoleteTestMessage)]
    [Test]
    public void TestsForLegacyCode_GetSetupConfFileName()
    {
        const string ConfigFileName = "setup.conf";
        string configDirectoryPath = Directory.GetCurrentDirectory();
        string configFilePath = Path.Combine(configDirectoryPath, ConfigFileName);

        string result = GameSetupConfFileBuilder.GetSetupConfFileName();

        Assert.That(result, Is.EqualTo(configFilePath));
    }
}
