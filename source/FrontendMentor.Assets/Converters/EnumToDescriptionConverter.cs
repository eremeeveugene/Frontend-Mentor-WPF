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

using FrontendMentor.Assets.MarkupExtensions;
using FrontendMentor.Core.Attributes;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace FrontendMentor.Assets.Converters;

/// <summary>
///     Converts an enum value to its localized or plain description.
/// </summary>
public sealed class EnumToDescriptionConverter : ConverterMarkupExtension<EnumToDescriptionConverter>
{
    private static readonly ConcurrentDictionary<object, string> Descriptions = [];

    /// <inheritdoc />
    public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value == null ? null : Descriptions.GetOrAdd(value, GetDescription);
    }

    /// <inheritdoc />
    public override object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    ///     Reads the description of an enum value from its attributes. Reflection creates new attribute
    ///     instances on every call, so the result is cached by <see cref="Convert" />.
    /// </summary>
    /// <param name="value">The enum value.</param>
    /// <returns>The localized description, the plain description, or the name of the value.</returns>
    private static string GetDescription(object value)
    {
        var fieldName = value.ToString() ?? throw new InvalidOperationException();

        var fieldInfo = value.GetType().GetField(fieldName);

        if (fieldInfo == null)
        {
            return fieldName;
        }

        var localizedDescription = fieldInfo.GetCustomAttribute<LocalizedDescriptionAttribute>(false);

        if (localizedDescription != null)
        {
            return localizedDescription.Description;
        }

        var description = fieldInfo.GetCustomAttribute<DescriptionAttribute>(false);

        if (description != null)
        {
            return description.Description;
        }

        return fieldName;
    }
}