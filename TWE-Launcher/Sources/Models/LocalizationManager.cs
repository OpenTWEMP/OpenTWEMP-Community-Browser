using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using TWE_Launcher.Forms.Localization;
using TWE_Launcher.Sources.Models.Localizations;


namespace TWE_Launcher.Sources.Models
{
	namespace Localizations
	{
		public class GuiLocale
		{
			private static List<FormLocaleDescription> supportedGuiLocaleDescriptions;

			public string Name { get; }
			public string Text { get; }
			public List<FormLocaleSnapshot> Content { get; }

			static GuiLocale()
			{
				supportedGuiLocaleDescriptions = new List<FormLocaleDescription>()
				{
					new GuiLocaleDescr_MainLauncher(),
					new GuiLocaleDescr_AppSettings(),
					new GuiLocaleDescr_GameSetupConfig(),
					new GuiLocaleDescr_AddNewGameSetup(),
					new GuiLocaleDescr_ModConfigSettings(),
					new GuiLocaleDescr_ModQuickNavigator(),
					new GuiLocaleDescr_AboutProject()
				};
			}

			public GuiLocale(string name, string text, List<FormLocaleSnapshot> content)
			{
				Name = name;
				Text = text;
				Content = content;
			}

			public static GuiLocale GenerateGuiLocaleFor_ENG()
			{
				const string LOCALE_NAME_ENG = "ENG";
				const string LOCALE_TEXT_ENG = "English";

				var localeContent_ENG = new List<FormLocaleSnapshot>();
				foreach (var description in supportedGuiLocaleDescriptions)
				{
					FormLocaleSnapshot snapshot = description.CreateLocaleSnapshotFor_ENG();
					localeContent_ENG.Add(snapshot);
				}

				return new GuiLocale(LOCALE_NAME_ENG, LOCALE_TEXT_ENG, localeContent_ENG);
			}

			public static GuiLocale GenerateGuiLocaleFor_RUS()
			{
				const string LOCALE_NAME_RUS = "RUS";
				const string LOCALE_TEXT_RUS = "Russian";

				var localeContent_RUS = new List<FormLocaleSnapshot>();
				foreach (var description in supportedGuiLocaleDescriptions)
				{
					FormLocaleSnapshot snapshot = description.CreateLocaleSnapshotFor_RUS();
					localeContent_RUS.Add(snapshot);
				}

				return new GuiLocale(LOCALE_NAME_RUS, LOCALE_TEXT_RUS, localeContent_RUS);
			}

			public static GuiLocale FromJsonText(string targetObjectJsonText)
			{
				return JsonConvert.DeserializeObject<GuiLocale>(targetObjectJsonText);
			}

			public string ToJsonText()
			{
				return JsonConvert.SerializeObject(this, Formatting.Indented);
			}
		}

		public class FormLocaleSnapshot
		{
			public string FormName { get; }
			public Dictionary<string, string> FormContent { get; }

			public FormLocaleSnapshot(string formName, Dictionary<string, string> formContent)
			{
				FormName = formName;
				FormContent = formContent;
			}
		}


		public interface ICanChangeMyLocalization
		{
			public Dictionary<string, string> GetLocalizableGUIControls();
		}
	}


	public static class LocalizationManager
	{
		private const string guiLocaleFolderName = "locale";
		private const string guiLocaleFileExtension = ".json";

		private static readonly string guiLocalesHomeDirectoryPath;
		private static List<GuiLocale> availableLocalizations;

		static LocalizationManager()
		{
			guiLocalesHomeDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), guiLocaleFolderName);

			if (!Directory.Exists(guiLocalesHomeDirectoryPath))
			{
				Directory.CreateDirectory(guiLocalesHomeDirectoryPath);
			}

			availableLocalizations = new List<GuiLocale>();
		}

		public static List<GuiLocale> GetSupportedLocalizations()
		{
			List<string> currentLocaleFiles = FindAvailableLocalizationFiles();

			if (currentLocaleFiles.Count == 0)
			{
				CreateStandardLocalizations();
			}
			else
			{
				List<GuiLocale> localeObjects = ReadObjectsFromLocaleFiles(currentLocaleFiles);
				availableLocalizations = localeObjects;
			}

			return availableLocalizations;
		}

		private static List<string> FindAvailableLocalizationFiles()
		{
			var guiLocaleFiles = new List<string>();

			string[] detectedFiles = Directory.GetFiles(guiLocalesHomeDirectoryPath);
			foreach (var file in detectedFiles)
			{
				if (file.EndsWith(guiLocaleFileExtension))
				{
					guiLocaleFiles.Add(file);
				}
			}

			return guiLocaleFiles;
		}

		private static List<GuiLocale> ReadObjectsFromLocaleFiles(List<string> files)
		{
			var guiLocaleObjects = new List<GuiLocale>();

			foreach (var file in files)
			{
				string objectJsonText = File.ReadAllText(file);
				GuiLocale localeObject = GuiLocale.FromJsonText(objectJsonText);
				guiLocaleObjects.Add(localeObject);
			}

			return guiLocaleObjects;
		}

		private static void CreateStandardLocalizations()
		{
			GuiLocale guiLocale_ENG = GuiLocale.GenerateGuiLocaleFor_ENG();
			GuiLocale guiLocale_RUS = GuiLocale.GenerateGuiLocaleFor_RUS();

			availableLocalizations.Add(guiLocale_ENG);
			availableLocalizations.Add(guiLocale_RUS);

			foreach (var localization in availableLocalizations)
			{
				SerializeLocalization(localization);
			}
		}

		private static void SerializeLocalization(GuiLocale localization)
		{
			string outputFileName = guiLocaleFolderName + '_' + localization.Name.ToLower() + guiLocaleFileExtension;
			string outputFilePath = Path.Combine(guiLocalesHomeDirectoryPath, outputFileName);

			using (var localeWriter = new StreamWriter(outputFilePath))
			{
				string localeObjectDump = localization.ToJsonText();
				localeWriter.WriteLine(localeObjectDump);
			}
		}

		internal static void ChangeLocalization(GuiLocale targetLocale)
		{
			//
		}
	}
}
