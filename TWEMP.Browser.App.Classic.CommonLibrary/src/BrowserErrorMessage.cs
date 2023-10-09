namespace TWEMP.Browser.App.Classic.CommonLibrary;

public static class BrowserErrorMessage
{
    public static void ShowAboutDirectoryNotFound()
    {
        string msgText = "The specified directory is not found.";
        string msgCaption = "ERROR";
        MessageBoxButtons msgButtons = MessageBoxButtons.OK;
        MessageBoxIcon msgIcon = MessageBoxIcon.Error;

        MessageBox.Show(
            text: msgText,
            caption: msgCaption,
            buttons: msgButtons,
            icon: msgIcon);
    }
}
