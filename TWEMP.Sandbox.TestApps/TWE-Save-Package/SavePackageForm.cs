using System;
using System.Windows.Forms;

namespace TWE_Save_Package
{
	public partial class SavePackageForm : Form
	{
		public SavePackageForm()
		{
			InitializeComponent();

			// 1. Получить данные сохранений.
			// 2. Заполнить список сохранений.
		}

		private void ButtonCreator_Click(object sender, EventArgs e)
		{
			// 1. Скопировать файл сохранения.
			// 2. Скопировать файл журнала игры.
			// 3. Создать текстовый файл с комментариями.
			// 4. Произвести переименование файлов согласно времени.
			// 5. Создать архив.
			// 6. Уведомить пользователя.
			// 7. Перейти в каталог с результатами.

			// var formSavePackage = new ModSavePackageForm();
			// formSavePackage.Show();

			MessageBox.Show("SAVE PACKAGE IS READY !");
		}

		private void ButtonResulter_Click(object sender, EventArgs e)
		{
			MessageBox.Show("HOME DIRECTORY OF PACKAGES IS OPENED !");
		}
	}
}
