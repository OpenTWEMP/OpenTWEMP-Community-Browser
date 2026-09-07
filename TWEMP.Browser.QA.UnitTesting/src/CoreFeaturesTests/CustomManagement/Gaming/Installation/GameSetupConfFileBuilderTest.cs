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
