using System;
using System.Collections.Generic;
using System.IO;

namespace TWE_Save_Package
{
    public class SavePackageService
	{
		public string StorageDirectory { get; set; }
		public List<SavePackage> SavePackages { get; }

		public SavePackageService(string storageDirectory)
		{
			StorageDirectory = storageDirectory;
			SavePackages = InitializeStorage();
		}

		private List<SavePackage> InitializeStorage()
		{
			// 1. find save package files in StorageDirectory
			// 2. put all detected files in list

			return new List<SavePackage>();
		}

		public void Create(SavePackage savePackage)
		{
			// Создать комбинированную строку имени сэйв-покета.
			// Взять значения полей и составить строку.

			// 1. Вызов SaveCopy()
			// 2. Вызов LogCopy()

			// 4. Сделать архив и вернуть его имя.

			// 5. Проверить существование файла.

			// Сравнить strSavePocket с возвращаемым значением CreateZip.

			// true, если сэйв-покет создан успешно.
			// Сообщить об успехе.
			//return true;
		}

		private List<string> PreparePackage()
		{
			return new List<string>();
		}

		private string CreateZip(List<string> data)
		{
			//System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive()
			// Создать архив из содержимого content.
			// content - это массив имен файлов.

			// Создать архив из имен файлов в массиве.

			// Вернуть имя результирующего массива.
			return "";
		}

		/// <summary>
		/// Копировать сэйв в каталог.
		/// </summary>
		/// <returns></returns>
		private string SaveCopy()
		{
			// 1. Получить имя сэйва.
			// 2. Копировать сэйв в каталог.
			// 3. Переименовать сэйв.
			// 4. Проверить существование файла.
			// 5. Вернуть строку имени сэйва.

			return "";
		}

		/// <summary>
		/// Копировать файл лога в каталог.
		/// </summary>
		/// <returns></returns>
		private string LogCopy()
		{
			// 1. Найти файл лога.
			// 2. Копировать лог в каталог.
			// 4. Проверить существование файла.
			// 5. Вернуть строку имени лога.

			return "";
		}

		public static void SaveGameLogFile()
		{
			const string M2TW_DEFAULT_LOG_FOLDER_NAME = "logs";
			const string M2TW_DEFAULT_LOG_FILE_NAME = "system.log.txt";

			if (!Directory.Exists(M2TW_DEFAULT_LOG_FOLDER_NAME))
			{
				Directory.CreateDirectory(M2TW_DEFAULT_LOG_FOLDER_NAME);
			}

			if (File.Exists(M2TW_DEFAULT_LOG_FILE_NAME))
			{
				string stringTimeOfCopy =
					"[ " + DateTime.Now.Year.ToString() + "."
					+ DateTime.Now.Month.ToString() + "."
					+ DateTime.Now.Day.ToString() +
					" ] { "
					+ DateTime.Now.Hour.ToString() + "-"
					+ DateTime.Now.Minute.ToString() + "-"
					+ DateTime.Now.Second.ToString() + " }";

				string stringLogNewPath =
					$"{M2TW_DEFAULT_LOG_FOLDER_NAME}\\{M2TW_DEFAULT_LOG_FILE_NAME} "
						+ stringTimeOfCopy + ".txt";

				File.Copy(M2TW_DEFAULT_LOG_FILE_NAME, stringLogNewPath);
			}
		}
	}
}
