namespace TWEMP.Browser.App.Utilities_CLI.M2TW_AssetsGenerator_ModPresets;

using System.IO;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;
using TWEMP.Browser.Core.CommonLibrary.Serialization;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*** TWEMP.Browser.App.Utilities-CLI.M2TW-AssetsGenerator-ModPresets ***");

        const ushort countOfPresets = 1000;

        for (ushort index = 0; index < countOfPresets; index++)
        {
            GenerateModPresetByIndex(index);
        }

        Console.WriteLine("DONE!!!");
    }

    private static void GenerateModPresetByIndex(ushort index)
    {
        string presetFolderNamePrefix = GetPresetFolderNamePrefix();
        string presetFolderNamePostfix = GetPresetFolderNamePostfix(index);

        string preserFolderName = GetPresetFolderName(
            presetFolderNamePrefix, presetFolderNamePostfix);
        string presetDirectoryPath = GetPresetDirectoryPath(preserFolderName);

        if (Directory.Exists(presetDirectoryPath))
        {
            Console.WriteLine($"[PASSED] This Directory Exists: {presetDirectoryPath}");
            return;
        }
        else
        {
            Directory.CreateDirectory(presetDirectoryPath);
            string presetConfigFilePath = GetPresetConfigFilePath(presetDirectoryPath);

            if (File.Exists(presetConfigFilePath))
            {
                Console.WriteLine($"[PASSED] This File Exists: {presetConfigFilePath}");
                return;
            }
            else
            {
                RedistributableModPreset preset = RedistributableModPreset.CreateDefaultTemplate();
                AppSerializer.SerializeToJson(preset, presetConfigFilePath);
                Console.WriteLine($"[SUCCESS] Creating Preset Config File: {presetConfigFilePath}");
            }
        }
    }

    private static string GetPresetFolderNamePrefix() => "PRESET";

    private static string GetPresetFolderNamePostfix(ushort index)
    {
        if (index < 10)
        {
            return $"00{index}";
        }

        if (index < 100)
        {
            return $"0{index}";
        }

        return index.ToString();
    }

    private static string GetPresetFolderName(string prefix, string postfix) =>
        $"{prefix}_{postfix}";

    private static string GetPresetDirectoryPath(string presetFolderName) =>
        Path.Combine(Directory.GetCurrentDirectory(), presetFolderName);

    private static string GetPresetConfigFilePath(string presetDirectoryPath)
    {
        const string presetConfigFileName = "twemp-preset-config.json";
        return Path.Combine(presetDirectoryPath, presetConfigFileName);
    }
}
