// --------------------------------------------------------------------------------
// Copyright (C) 2026 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.Assets.Enums;
using FrontendMentor.Assets.ResourceDictionaries;
using System.IO;
using System.Windows.Media;

namespace FrontendMentor.Assets.Tests.ResourceDictionaries;

[TestClass]
public sealed class ThemeResourceDictionaryTests
{
    private const string BrushKey = "Test.Brush";

    private static string _directory = null!;

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        _directory = Path.Combine(Path.GetTempPath(), $"{nameof(ThemeResourceDictionaryTests)}-{Guid.NewGuid():N}");

        Directory.CreateDirectory(_directory);
        WriteDictionary("Light.xaml", "#FFFFFF");
        WriteDictionary("Dark.xaml", "#000000");
    }

    // The registry of the dictionaries is static, so a dictionary of these tests can still be switched by a later
    // test. Its files are kept until all tests have run.
    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        if (_directory != null)
        {
            Directory.Delete(_directory, true);
        }
    }

    [STATestMethod]
    public void SetTheme_LoadsTheSourceOfTheTheme()
    {
        var dictionary = CreateDictionary();

        ThemeResourceDictionary.SetTheme(Theme.Dark);

        Assert.AreEqual(Colors.Black, ((SolidColorBrush)dictionary[BrushKey]).Color);

        ThemeResourceDictionary.SetTheme(Theme.Light);

        Assert.AreEqual(Colors.White, ((SolidColorBrush)dictionary[BrushKey]).Color);
    }

    [STATestMethod]
    public void SetTheme_SameThemeAgain_DoesNotLoadTheSourceAgain()
    {
        var dictionary = CreateDictionary();

        ThemeResourceDictionary.SetTheme(Theme.Dark);

        var brush = dictionary[BrushKey];

        ThemeResourceDictionary.SetTheme(Theme.Dark);

        Assert.AreSame(brush, dictionary[BrushKey]);
    }

    private static ThemeResourceDictionary CreateDictionary()
    {
        return new ThemeResourceDictionary
        {
            LightThemeSource = new Uri(Path.Combine(_directory, "Light.xaml")),
            DarkThemeSource = new Uri(Path.Combine(_directory, "Dark.xaml"))
        };
    }

    private static void WriteDictionary(string fileName, string color)
    {
        File.WriteAllText(
            Path.Combine(_directory, fileName),
            $"""
             <ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
                 <SolidColorBrush x:Key="{BrushKey}" Color="{color}" />
             </ResourceDictionary>
             """);
    }
}