// <copyright file="SystemToolbox.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.Utilities;

using System.Diagnostics;
using TWEMP.Browser.Core.CommonLibrary.Messaging;

public static class SystemToolbox
{
    public static void ShowFileSystemDirectory(string directory, IBrowserMessageProvider messageProvider)
    {
        if (Directory.Exists(directory))
        {
            var explorerProcInfo = new ProcessStartInfo();

            string execFileName = "explorer.exe"; // Windows Explorer
            explorerProcInfo.FileName = execFileName;
            explorerProcInfo.Arguments = directory;

            Process.Start(explorerProcInfo);
        }
        else
        {
            messageProvider.Show(
                msgText: "ERROR: Specified directory does not exist.",
                msgCaption: "Error Message",
                msgType: BrowserMessageType.Error);
        }
    }
}
