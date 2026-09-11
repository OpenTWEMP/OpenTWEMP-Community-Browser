// <copyright file="GameSetupConfFileBuilderTest.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.QA.UnitTesting.CoreFeaturesTests.CustomManagement.Gaming.Installation;

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
