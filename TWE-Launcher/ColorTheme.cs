using System.Drawing;

namespace TWE_Launcher
{
	public enum GuiStyle
	{
		Default,
		Light,
		Dark
	}

    public class ColorTheme
    {
		public ColorTheme()
		{
			// Initialize description for the default color theme.
			MainFormBackColor = Color.DarkSeaGreen;
			PanelsBackColor = Color.MediumAquamarine;
			ModControlsBackColor = Color.MediumSeaGreen;
			CommonControlsBackColor = Color.LightGreen;
			CommonControlsForeColor = Color.Black;
		}

		public ColorTheme(Color formBack, Color panelsBack, Color modUIBack, Color commonUIBack, Color commonUIFore)
		{
			// Initialize description for a custom color theme.
			MainFormBackColor = formBack;
			PanelsBackColor = panelsBack;
			ModControlsBackColor = modUIBack;
			CommonControlsBackColor = commonUIBack;
			CommonControlsForeColor = commonUIFore;
		}

		public Color MainFormBackColor { get; }
		public Color PanelsBackColor { get; }
		public Color ModControlsBackColor { get; }
		public Color CommonControlsBackColor { get; }
		public Color CommonControlsForeColor { get; }

		public static ColorTheme SelectColorThemeByStyle(GuiStyle style)
		{
			// Initialize description for a pre-defined color theme style.

			if (style == GuiStyle.Default)
			{
				return new ColorTheme();
			}

			if (style == GuiStyle.Light)
			{
				return uiLightTheme;
			}

			if (style == GuiStyle.Dark)
			{
				return uiDarkTheme;
			}

			return new ColorTheme();
		}

		private readonly static ColorTheme uiLightTheme = new ColorTheme(Color.SeaShell, Color.Azure, Color.AliceBlue, Color.GhostWhite, Color.Black);
		private readonly static ColorTheme uiDarkTheme = new ColorTheme(Color.DarkSlateGray, Color.LightSlateGray, Color.SlateGray, Color.DarkGray, Color.Snow);
	}
}
