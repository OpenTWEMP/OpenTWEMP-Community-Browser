namespace TWEMP.Browser.App.Classic;

using TWEMP.Browser.Core.CommonLibrary;

internal partial class MainBrowserForm : Form, IGameConfigState
{
    internal RadioButton LauncherProviderControl_M2TWEOP { get; set; }

    internal RadioButton LauncherProviderControl_NativeSetup { get; set; }

    internal RadioButton LauncherProviderControl_BatchScript { get; set; }

    internal RadioButton LauncherProviderControl_TWEMP { get; set; }

    internal RadioButton RadioButton_FullScreenMode { get; set; }

    internal RadioButton RadioButton_WindowedMode { get; set; }

    internal CheckBox CheckBox_Video { get; set; }

    internal CheckBox CheckBox_Borderless { get; set; }

    internal RadioButton RadioButton_LogErrorAndTrace { get; set; }

    internal RadioButton RadioButton_LogOnlyTrace { get; set; }

    internal RadioButton RadioButton_LogOnlyError { get; set; }

    internal CheckBox CheckBox_Cleaner_MapRWM { get; set; }

    internal CheckBox CheckBox_Cleaner_textBIN { get; set; }

    internal CheckBox CheckBox_Cleaner_soundPacks { get; set; }

    internal CheckBox CheckBox_LogHistory { get; set; }

    public CustomConfigState GetCurrentGameConfigState()
    {
        return new CustomConfigState()
        {
            UseLauncherProvider_M2TWEOP = this.LauncherProviderControl_M2TWEOP.Checked,
            UseLauncherProvider_M2TWEOP_NativeSetup = this.LauncherProviderControl_NativeSetup.Checked,
            UseLauncherProvider_M2TWEOP_NativeBatch = this.LauncherProviderControl_BatchScript.Checked,
            UseLauncherProvider_TWEMP = this.LauncherProviderControl_TWEMP.Checked,

            IsEnabledFullScreenMode = this.RadioButton_FullScreenMode.Checked,
            IsEnabledWindowedMode = this.RadioButton_WindowedMode.Checked,

            ValidatorVideo = this.CheckBox_Video.Checked,
            ValidatorBorderless = this.CheckBox_Borderless.Checked,

            ValidatorLogLevel1 = this.RadioButton_LogOnlyError.Checked,
            ValidatorLogLevel2 = this.RadioButton_LogOnlyTrace.Checked,
            ValidatorLogLevel3 = this.RadioButton_LogErrorAndTrace.Checked,

            IsShouldBeDeleted_MapRWM = this.CheckBox_Cleaner_MapRWM.Checked,
            IsShouldBeDeleted_TextBin = this.CheckBox_Cleaner_textBIN.Checked,
            IsShouldBeDeleted_SoundPacks = this.CheckBox_Cleaner_soundPacks.Checked,

            EnabledLogsHistorySaving = this.CheckBox_LogHistory.Checked,
        };
    }
}
