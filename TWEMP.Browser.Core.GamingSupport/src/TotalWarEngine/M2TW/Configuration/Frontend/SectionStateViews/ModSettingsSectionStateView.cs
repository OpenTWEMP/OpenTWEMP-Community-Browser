// <copyright file="ModSettingsSectionStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend.SectionStateViews;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;
using TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Backend.DataTypes;

public record ModSettingsSectionStateView : ICustomConfigState
{
    private const string FeaturesConfigSwitch = "features";
    private const string IOConfigSwitch = "io";

    public const string ModTextId = "mod";
    public const string EditorTextId = "editor";
    public const string FileFirstTextId = "file_first";

    public ModSettingsSectionStateView()
    {
    }

    public string? Mod { get; set; } // "mod"

    public M2TW_Boolean? Editor { get; set; } // "editor"

    public M2TW_Boolean? FileFirst { get; set; } // "file_first"

    public static ModSettingsSectionStateView CreateByDefault(GameModificationInfo mod)
    {
        return new ModSettingsSectionStateView
        {
            Mod = mod.ModCfgRelativePath,
            Editor = new M2TW_Boolean(true),
            FileFirst = new M2TW_Boolean(true),
        };
    }

    public GameCfgSection[] RetrieveCurrentSettings()
    {
        M2TWGameCfgOption featuresModOption = new (
            name: ModTextId, value: this.Mod!, section: FeaturesConfigSwitch);

        M2TWGameCfgOption featuresEditorOption = new (
            name: EditorTextId, value: this.Editor!.BooleanValue, section: FeaturesConfigSwitch);

        M2TWGameCfgOption ioFileFirstOption = new (
            name: FileFirstTextId, value: this.FileFirst!.BooleanValue, section: IOConfigSwitch);

        M2TWGameCfgOption[] featuresCfgOptions = { featuresModOption, featuresEditorOption };
        M2TWGameCfgOption[] ioCfgOptions = { ioFileFirstOption };

        GameCfgSection featuresCfgSection = new M2TWGameCfgSection(FeaturesConfigSwitch, featuresCfgOptions);
        GameCfgSection ioCfgSection = new M2TWGameCfgSection(IOConfigSwitch, ioCfgOptions);

        return new GameCfgSection[] { featuresCfgSection, ioCfgSection };
    }
}
