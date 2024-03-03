// <copyright file="GameConfigRoutines.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary.GameLauncherFeatures;

public static class GameConfigRoutines
{
    public static bool DeleteMapFile(GameModificationInfo gameMod, IBrowserMessageProvider messageProvider)
    {
        bool hasOperationSuccessExecutionStatus = false;

        string mapFileName = "map.rwm";
        string mapRelativePath = "data\\world\\maps\\base\\";

        string mapFullPath = Path.Combine(gameMod.Location, mapRelativePath, mapFileName);

        if (File.Exists(mapFullPath))
        {
            File.Delete(mapFullPath);
            hasOperationSuccessExecutionStatus = true;
        }
        else
        {
            messageProvider.Show(
                msgText: "ERROR: map.rwm does not exist",
                msgCaption: "Error Message",
                msgType: BrowserMessageType.Error);
        }

        return hasOperationSuccessExecutionStatus;
    }

    public static bool DeleteStringsBinFiles(GameModificationInfo gameMod, IBrowserMessageProvider messageProvider)
    {
        bool hasOperationSuccessExecutionStatus = false;

        string stringsBinFileExtension = ".strings.bin";
        string textFilesRelativePath = "data\\text";
        string textFilesFullPath = Path.Combine(gameMod.Location, textFilesRelativePath);

        if (Directory.Exists(textFilesFullPath))
        {
            string[] detectedFiles = Directory.GetFiles(textFilesFullPath);

            for (int i = 0; i < detectedFiles.Length; i++)
            {
                if (detectedFiles[i].EndsWith(stringsBinFileExtension))
                {
                    File.Delete(detectedFiles[i]);
                }
            }

            hasOperationSuccessExecutionStatus = true;
        }
        else
        {
            messageProvider.Show(
                msgText: "ERROR: *.strings.bin files' directory is not found",
                msgCaption: "Error Message",
                msgType: BrowserMessageType.Error);
        }

        return hasOperationSuccessExecutionStatus;
    }

    public static bool DeleteSoundPackFiles(GameModificationInfo gameMod, IBrowserMessageProvider messageProvider)
    {
        bool hasOperationSuccessExecutionStatus = false;

        string soundPacksRelativePath = "data\\sounds";
        string soundPacksFullPath = Path.Combine(gameMod.Location, soundPacksRelativePath);

        if (Directory.Exists(soundPacksFullPath))
        {
            string[] soundPacksFiles = Directory.GetFiles(soundPacksFullPath);

            for (int i = 0; i < soundPacksFiles.Length; i++)
            {
                string pack_file = soundPacksFiles[i];

                if (IsBinDatPack(pack_file) || IsBinIdxPack(pack_file))
                {
                    File.Delete(pack_file);
                }
            }

            hasOperationSuccessExecutionStatus = true;
        }
        else
        {
            messageProvider.Show(
                msgText: "ERROR: *.dat и *.idx files' directory is not found",
                msgCaption: "Error Message",
                msgType: BrowserMessageType.Error);
        }

        return hasOperationSuccessExecutionStatus;
    }

    private static bool IsBinDatPack(string filename)
    {
        string binDatFileExtension = ".dat";

        if (filename.EndsWith(binDatFileExtension))
        {
            return true;
        }

        return false;
    }

    private static bool IsBinIdxPack(string filename)
    {
        string binIdxFileExtension = ".idx";

        if (filename.EndsWith(binIdxFileExtension))
        {
            return true;
        }

        return false;
    }
}
