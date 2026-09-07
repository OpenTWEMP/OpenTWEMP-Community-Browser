// <copyright file="GameSetupConfFileBuilderTest.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.QA.UnitTesting.CoreFeaturesTests.CustomManagement.Gaming.Installation;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Installation;

public class GameSetupConfFileBuilderTest
{
    [Test]
    public void CreateConfigFilePathWhenInitialization()
    {
        const string ConfigDirectoryPath = "C:\\Users\\User\\AppData\\TWEMP";
        const string ConfigFileName = "setup.conf";

        GameSetupConfFileBuilder sut = GameSetupConfFileBuilder.Create(ConfigDirectoryPath);

        Assert.That(sut.ConfigFilePath, Is.EqualTo($"{ConfigDirectoryPath}\\{ConfigFileName}"));
    }
}
