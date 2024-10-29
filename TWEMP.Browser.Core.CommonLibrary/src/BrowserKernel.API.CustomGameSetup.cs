// <copyright file="BrowserKernel.API.CustomGameSetup.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // Partial elements should be documented

namespace TWEMP.Browser.Core.CommonLibrary;

public static partial class BrowserKernel
{
    public static List<GameSetupInfo> GameInstallations
    {
        get
        {
            return CustomGameSetupManagerInstance.GameInstallations;
        }
    }

    public static List<GameModificationInfo> TotalModificationsList
    {
        get
        {
            return CustomGameSetupManagerInstance.TotalModificationsList;
        }
    }

    public static List<GameSetupInfo> SynchronizeGameSetupSettings()
    {
        return CustomGameSetupManagerInstance.SynchronizeGameSetupSettings();
    }

    public static GameModificationInfo GetActiveModificationInfo(string modShortName)
    {
        return CustomGameSetupManagerInstance.GetActiveModificationInfo(modShortName);
    }

    public static GameSetupInfo RegistrateGameInstallation(string setupName, string executableFullPath, List<string> modcenterPaths)
    {
        return CustomGameSetupManagerInstance.RegistrateGameInstallation(setupName, executableFullPath, modcenterPaths);
    }

    public static void DeleteGameSetupByIndex(int gameSetupIndex)
    {
        CustomGameSetupManagerInstance.DeleteGameSetupByIndex(gameSetupIndex);
    }

    public static void ClearAllSettings()
    {
        CustomGameSetupManagerInstance.ClearAllSettings();
    }
}
