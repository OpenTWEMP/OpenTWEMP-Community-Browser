using TWE_Launcher.Forms;

namespace TWE_Launcher.Models
{
	public class CustomConfigState
	{
		private readonly bool useLauncherProvider_M2TWEOP;
		private readonly bool useLauncherProvider_M2TWEOP_NativeSetup;
		private readonly bool useLauncherProvider_M2TWEOP_NativeBatch;
		private readonly bool useLauncherProvider_TWEMP;

		private readonly bool isEnabledWindowedMode;
		private readonly bool validatorVideo;
		private readonly bool validatorBorderless;
		private readonly bool validatorLogLevel1;
		private readonly bool validatorLogLevel2;
		private readonly bool validatorLogLevel3;
		private readonly bool isShouldBeDeleted_MapRWM;
		private readonly bool isShouldBeDeleted_TextBin;
		private readonly bool isShouldBeDeleted_SoundPacks;
		private readonly bool enabledLogsHistorySaving;


		public bool UseLauncherProvider_M2TWEOP => useLauncherProvider_M2TWEOP;
		public bool UseLauncherProvider_M2TWEOP_NativeSetup => useLauncherProvider_M2TWEOP_NativeSetup;
		public bool UseLauncherProvider_M2TWEOP_NativeBatch => useLauncherProvider_M2TWEOP_NativeBatch;
		public bool UseLauncherProvider_TWEMP => useLauncherProvider_TWEMP;


		public bool IsEnabledWindowedMode => isEnabledWindowedMode;
		public bool ValidatorVideo => validatorVideo;
		public bool ValidatorBorderless => validatorBorderless;
		public bool ValidatorLogLevel1 => validatorLogLevel1;
		public bool ValidatorLogLevel2 => validatorLogLevel2;
		public bool ValidatorLogLevel3 => validatorLogLevel3;
		public bool IsShouldBeDeleted_MapRWM => isShouldBeDeleted_MapRWM;
		public bool IsShouldBeDeleted_TextBin => isShouldBeDeleted_TextBin;
		public bool IsShouldBeDeleted_SoundPacks => isShouldBeDeleted_SoundPacks;
		public bool EnabledLogsHistorySaving => enabledLogsHistorySaving;


		public CustomConfigState(MainLauncherForm form)
		{
			useLauncherProvider_M2TWEOP = form.LauncherProviderControl_M2TWEOP.Checked;
			useLauncherProvider_M2TWEOP_NativeSetup = form.LauncherProviderControl_NativeSetup.Checked;
			useLauncherProvider_M2TWEOP_NativeBatch = form.LauncherProviderControl_BatchScript.Checked;
			useLauncherProvider_TWEMP = form.LauncherProviderControl_TWEMP.Checked;
		
			if (form.RadioButton_FullScreenMode.Checked)
			{
				isEnabledWindowedMode = false;
			}
			else
			{
				isEnabledWindowedMode = true;
			}

			if (form.RadioButton_WindowedMode.Checked)
			{
				isEnabledWindowedMode = true;
			}
			else
			{
				isEnabledWindowedMode = false;
			}

			if (form.CheckBox_Video.Checked)
			{
				validatorVideo = true;
			}
			else
			{
				validatorVideo = false;
			}

			if (form.CheckBox_Borderless.Checked)
			{
				validatorBorderless = true;
			}
			else
			{
				validatorBorderless = false;
			}

			if (form.RadioButton_LogOnlyError.Checked)
			{
				validatorLogLevel1 = true;
				validatorLogLevel2 = false;
				validatorLogLevel3 = false;
			}

			if (form.RadioButton_LogOnlyTrace.Checked)
			{
				validatorLogLevel1 = false;
				validatorLogLevel2 = true;
				validatorLogLevel3 = false;
			}

			if (form.RadioButton_LogErrorAndTrace.Checked)
			{
				validatorLogLevel1 = false;
				validatorLogLevel2 = false;
				validatorLogLevel3 = true;
			}


			if (form.CheckBox_Cleaner_MapRWM.Checked)
			{
				isShouldBeDeleted_MapRWM = true;
			}
			else
			{
				isShouldBeDeleted_MapRWM = false;
			}


			if (form.CheckBox_Cleaner_textBIN.Checked)
			{
				isShouldBeDeleted_TextBin = true;
			}
			else
			{
				isShouldBeDeleted_TextBin = false;
			}

			if (form.CheckBox_Cleaner_soundPacks.Checked)
			{
				isShouldBeDeleted_SoundPacks = true;
			}
			else
			{
				isShouldBeDeleted_SoundPacks = false;
			}

			enabledLogsHistorySaving = form.CheckBox_LogHistory.Checked;
		}
	}
}
