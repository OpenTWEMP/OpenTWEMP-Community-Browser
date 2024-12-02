// <copyright file="ModLauncherInfo.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

public record ModLauncherInfo
{
    public ModLauncherInfo(string batch, string setup, string eop)
    {
        this.LauncherProvider_NativeBatch = batch;
        this.LauncherProvider_NativeSetup = setup;
        this.LauncherProvider_M2TWEOP = eop;
    }

    public string LauncherProvider_NativeBatch { get; set; }

    public string LauncherProvider_NativeSetup { get; set; }

    public string LauncherProvider_M2TWEOP { get; set; }

    public static ModLauncherInfo CreateByDefault()
    {
        const string modLauncherNativeBatch = "My_Batch_Script.bat";
        const string modLauncherNativeSetup = "My_Setup_Program.exe";
        const string modLauncherM2TWEOP = "M2TWEOP GUI.exe";

        return new ModLauncherInfo(
            batch: modLauncherNativeBatch,
            setup: modLauncherNativeSetup,
            eop: modLauncherM2TWEOP);
    }
}
