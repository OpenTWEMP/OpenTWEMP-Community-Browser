// <copyright file="Program.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.App.Utilities_GUI.M2TW_Addons_Setup;

/// <summary>
///  The root class of the application.
/// </summary>
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    internal static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new TwempExtensionStartupForm());
    }
}