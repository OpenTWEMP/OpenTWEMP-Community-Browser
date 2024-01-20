// <copyright file="AppGuiStyleManagerTest.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TWEMP.Browser.QA.UnitTesting.CoreFeaturesTests.CustomManagement.GUI;

using TWEMP.Browser.Core.CommonLibrary;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.GUI;

/// <summary>
/// Contains unit tests for the <see cref="AppGuiStyleManager"/> class.
/// </summary>
public class AppGuiStyleManagerTest
{
    /// <summary>
    /// Tests creating the default instance of the <see cref="AppGuiStyleManager"/> class.
    /// </summary>
    [Test]
    public static void CreateAppGuiStyleManagerInstanceByDefault()
    {
        AppGuiStyleManager manager = AppGuiStyleManager.Create();

        Assert.That(
            actual: manager.CurrentStyle,
            expression: Is.EqualTo(expected: GuiStyle.Default));
    }

    /// <summary>
    /// Tests creating a custom instance of the <see cref="AppGuiStyleManager"/> class.
    /// </summary>
    /// <param name="style">Custom GUI style value.</param>
    [TestCase(GuiStyle.Light)]
    [TestCase(GuiStyle.Dark)]
    public static void CreateAppGuiStyleManagerInstanceWithCustomStyle(GuiStyle style)
    {
        AppGuiStyleManager manager = AppGuiStyleManager.Create(style);

        Assert.That(
            actual: manager.CurrentStyle,
            expression: Is.EqualTo(expected: style));
    }

    /// <summary>
    /// Tests changing the current GUI style from the default to a custom value.
    /// </summary>
    /// <param name="style">Custom GUI style value.</param>
    [TestCase(GuiStyle.Light)]
    [TestCase(GuiStyle.Dark)]
    public static void ChangeStyleFromDefaultToCustom(GuiStyle style)
    {
        AppGuiStyleManager manager = AppGuiStyleManager.Create();

        manager.CurrentStyle = style;

        Assert.That(
            actual: manager.CurrentStyle,
            expression: Is.EqualTo(expected: style));
    }

    /// <summary>
    /// Tests changing the current GUI style from the an initial to a target custom value.
    /// </summary>
    /// <param name="initialStyle">Initial GUI style value.</param>
    /// <param name="targetStyle">Target GUI style value.</param>
    [TestCase(GuiStyle.Light, GuiStyle.Default)]
    [TestCase(GuiStyle.Light, GuiStyle.Dark)]
    [TestCase(GuiStyle.Dark, GuiStyle.Default)]
    [TestCase(GuiStyle.Dark, GuiStyle.Light)]
    public static void ChangeStyleFromCustomToCustom(
        GuiStyle initialStyle, GuiStyle targetStyle)
    {
        AppGuiStyleManager manager = AppGuiStyleManager.Create(initialStyle);

        manager.CurrentStyle = targetStyle;

        Assert.That(
            actual: manager.CurrentStyle,
            expression: Is.EqualTo(expected: targetStyle));
    }

    /// <summary>
    /// Tests an attempt to set the current GUI style via the same custom value.
    /// </summary>
    /// <param name="style">Custom GUI style value.</param>
    [TestCase(GuiStyle.Default)]
    [TestCase(GuiStyle.Light)]
    [TestCase(GuiStyle.Dark)]
    public static void TryToSetTheSameStyle(GuiStyle style)
    {
        AppGuiStyleManager manager = AppGuiStyleManager.Create(style);

        manager.CurrentStyle = style;

        Assert.That(
            actual: manager.CurrentStyle,
            expression: Is.EqualTo(expected: style));
    }
}
