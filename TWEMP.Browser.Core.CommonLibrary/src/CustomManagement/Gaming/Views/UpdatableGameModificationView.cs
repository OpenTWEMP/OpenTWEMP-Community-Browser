// <copyright file="UpdatableGameModificationView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Views;

using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.GameSupportPresets;

/// <summary>
/// Defines a game modification entity as a shared view which can be displayed via UI and updated on demand.
/// </summary>
public class UpdatableGameModificationView
{
    private static readonly RedistributableModPreset RedistributablePresetByDefault;

    private CustomizableModPreset customizableModPreset;
    private RedistributableModPreset redistributableModPreset;

    /// <summary>
    /// Initializes static members of the <see cref="UpdatableGameModificationView"/> class.
    /// </summary>
    static UpdatableGameModificationView()
    {
        RedistributablePresetByDefault = RedistributableModPreset.CreateDefaultTemplate();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdatableGameModificationView"/> class.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="modInfo">The game modification info entity for this view.</param>
    private UpdatableGameModificationView(GameModificationIdView idView, GameModificationInfo modInfo)
    {
        this.IdView = idView;
        this.CurrentInfo = modInfo;

        this.redistributableModPreset = RedistributablePresetByDefault;
        this.customizableModPreset = GetCustomizableModPreset(this.CurrentInfo);
        this.UseCustomizablePreset = false;

        this.ActivePreset = this.redistributableModPreset.Data;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdatableGameModificationView"/> class.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="modInfo">The game modification info entity for this view.</param>
    /// <param name="modPreset">The attached redistributable mod preset for this game modification view.</param>
    private UpdatableGameModificationView(
        GameModificationIdView idView, GameModificationInfo modInfo, RedistributableModPreset modPreset)
    {
        this.IdView = idView;
        this.CurrentInfo = modInfo;

        this.redistributableModPreset = modPreset;
        this.customizableModPreset = GetCustomizableModPreset(this.CurrentInfo);
        this.UseCustomizablePreset = false;

        this.ActivePreset = this.redistributableModPreset.Data;
    }

    /// <summary>
    /// Gets the game modification identifier entity for this view.
    /// </summary>
    public GameModificationIdView IdView { get; }

    /// <summary>
    /// Gets the current game modification info entity for this view.
    /// </summary>
    public GameModificationInfo CurrentInfo { get; }

    /// <summary>
    /// Gets the active mod support preset entity for this view.
    /// </summary>
    public ModSupportPreset ActivePreset { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the current game modification uses a customizable preset.
    /// This property is 'true' for a customizable preset and 'false' for a redistributable preset.
    /// </summary>
    public bool UseCustomizablePreset { get; private set; }

    /// <summary>
    /// Gets the redistributable mod preset by default.
    /// </summary>
    /// <returns>The default instance of the <see cref="RedistributableModPreset"/> class.</returns>
    public static RedistributableModPreset GetRedistributablePresetByDefault()
    {
        return RedistributablePresetByDefault;
    }

    /// <summary>
    /// Gets the <see cref="Guid"/> value for the default redistributable preset.
    /// </summary>
    /// <returns>The value of the <see cref="Guid"/> type.</returns>
    public static Guid GetDefaultPresetId()
    {
        return RedistributablePresetByDefault.Metadata.Guid;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="UpdatableGameModificationView"/> record
    /// using an object of <see cref="RedistributableModPreset"/> class.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="info">The game modification info entity for this view.</param>
    /// <param name="preset">The redistributable preset for this game modification.</param>
    /// <returns>A new configured instance of the <see cref="UpdatableGameModificationView"/> record.</returns>
    public static UpdatableGameModificationView CreateGameModificationViewByRedistributablePreset(
        GameModificationIdView idView,
        GameModificationInfo info,
        RedistributableModPreset preset)
    {
        UpdatableGameModificationView gameModificationView;

        if (preset != null)
        {
            gameModificationView = new UpdatableGameModificationView(idView, info, preset);
        }
        else
        {
            gameModificationView = new UpdatableGameModificationView(idView, info);
        }

        return gameModificationView;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="UpdatableGameModificationView"/> record
    /// using an object of <see cref="CustomizableModPreset"/> class.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="info">The game modification info entity for this view.</param>
    /// <returns>A new configured instance of the <see cref="UpdatableGameModificationView"/> record.</returns>
    public static UpdatableGameModificationView CreateGameModificationViewByCustomizablePreset(
        GameModificationIdView idView, GameModificationInfo info)
    {
        UpdatableGameModificationView gameModificationView = new (idView, info);
        gameModificationView.SelectCustomizableModPreset();
        return gameModificationView;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="UpdatableGameModificationView"/> record by default preset settings.
    /// </summary>
    /// <param name="idView">The game modification identifier entity for this view.</param>
    /// <param name="info">The game modification info entity for this view.</param>
    /// <returns>A new configured instance of the <see cref="UpdatableGameModificationView"/> record.</returns>
    public static UpdatableGameModificationView CreateGameModificationViewByDefaultPreset(
        GameModificationIdView idView, GameModificationInfo info)
    {
        return new UpdatableGameModificationView(idView, info);
    }

    /// <summary>
    /// Gets the <see cref="Guid"/> value for the currently attached redistributable preset.
    /// </summary>
    /// <returns>The value of the <see cref="Guid"/> type.</returns>
    public Guid GetRedistributablePresetId()
    {
        return this.redistributableModPreset.Metadata.Guid;
    }

    /// <summary>
    /// Gets the full name of the attached redistributable preset.
    /// </summary>
    /// <returns>The full name of the current redistributable preset.</returns>
    public string GetRedistributablePresetFullName()
    {
        ModHeaderInfo headerInfo = this.redistributableModPreset.Data.HeaderInfo;
        return $"{headerInfo.ModTitle} [{headerInfo.ModVersion}]";
    }

    /// <summary>
    /// Gets description of the current customizable preset as a text string.
    /// </summary>
    /// <returns>The string description of the current customizable preset.</returns>
    public string GetCustomizablePresetDescription()
    {
        const string welcomeTextMessage = "Configure this game mod via your own customizable preset: ";
        return $"{welcomeTextMessage}{this.customizableModPreset.Config.FullName}";
    }

    /// <summary>
    /// Gets the full name of the current active preset.
    /// </summary>
    /// <returns>The full name of the current active preset.</returns>
    public string GetActivePresetFullName()
    {
        ModHeaderInfo headerInfo = this.ActivePreset.HeaderInfo;
        return $"{headerInfo.ModTitle} [{headerInfo.ModVersion}]";
    }

    /// <summary>
    /// Gets the logotype image file info for the current preset of the <see cref="RedistributableModPreset"/> type.
    /// </summary>
    /// <param name="presetHomeDirectoryInfo">The home directory info of this redistributable preset.</param>
    /// <returns>The <see cref="FileInfo"/> object for a logotype image file.</returns>
    public FileInfo GetLogoImageFromRedistributablePreset(DirectoryInfo presetHomeDirectoryInfo)
    {
        string presetLogoImageFilePath = Path.Combine(
            path1: presetHomeDirectoryInfo.FullName,
            path2: this.redistributableModPreset.Data.ContentInfo.LogotypeImage);

        return new FileInfo(presetLogoImageFilePath);
    }

    /// <summary>
    /// Gets the logotype image file info for the current preset of the <see cref="CustomizableModPreset"/> type.
    /// </summary>
    /// <returns>The <see cref="FileInfo"/> object for a logotype image file.</returns>
    public FileInfo GetLogoImageFromCustomizablePreset()
    {
        string presetLogoImageFilePath = Path.Combine(
            path1: this.customizableModPreset.Location.FullName,
            path2: this.customizableModPreset.Data.ContentInfo.LogotypeImage);

        return new FileInfo(presetLogoImageFilePath);
    }

    /// <summary>
    /// Selects the current preset of the <see cref="RedistributableModPreset"/> type
    /// as the active mod support preset for this game modification.
    /// </summary>
    public void SelectRedistributableModPreset()
    {
        this.ActivePreset = this.redistributableModPreset.Data;
        this.UseCustomizablePreset = false;
    }

    /// <summary>
    /// Selects the current preset of the <see cref="RedistributableModPreset"/> type
    /// as the active mod support preset for this game modification.
    /// </summary>
    /// <param name="preset">The redistributable preset for this game modification.</param>
    public void SelectRedistributableModPreset(RedistributableModPreset preset)
    {
        this.redistributableModPreset = preset;
        this.ActivePreset = preset.Data;
        this.UseCustomizablePreset = false;
    }

    /// <summary>
    /// Selects the current preset of the <see cref="CustomizableModPreset"/> type
    /// as the active mod support preset for this game modification.
    /// </summary>
    public void SelectCustomizableModPreset()
    {
        this.ActivePreset = this.customizableModPreset.Data;
        this.UseCustomizablePreset = true;
    }

    /// <summary>
    /// Resets both <see cref="CustomizableModPreset"/> and <see cref="RedistributableModPreset"/> presets
    /// to its default settings for this game modification.
    /// </summary>
    public void ResetAllModPresetsToDefaultSettings()
    {
        this.customizableModPreset = CustomizableModPreset.CreateDefaultTemplate(this.CurrentInfo.Location);
        this.redistributableModPreset = RedistributablePresetByDefault;
    }

    private static CustomizableModPreset GetCustomizableModPreset(GameModificationInfo info)
    {
        if (CustomizableModPreset.Exists(info.Location))
        {
            return CustomizableModPreset.ReadCurrentPreset(info.Location);
        }
        else
        {
            return CustomizableModPreset.CreateDefaultTemplate(info.Location);
        }
    }
}
