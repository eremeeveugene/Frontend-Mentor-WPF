// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

namespace FrontendMentor.Core.Constants;

/// <summary>
///     Provides standard and custom numeric format strings with various precision specifiers.
/// </summary>
public static class StandardNumericFormatStrings
{
    // Binary formats
    /// <summary>
    ///     Formats a number as a binary string.
    /// </summary>
    public const string Binary = "B";

    /// <summary>
    ///     Formats a number as a binary string with a precision specifier of 1.
    /// </summary>
    public const string Binary1 = "B1";

    /// <summary>
    ///     Formats a number as a binary string with a precision specifier of 2.
    /// </summary>
    public const string Binary2 = "B2";

    // Currency formats
    /// <summary>
    ///     Formats a number as a currency string with the default number of decimal places.
    /// </summary>
    public const string Currency = "C";

    /// <summary>
    ///     Formats a number as a currency string with one decimal place.
    /// </summary>
    public const string Currency1 = "C1";

    /// <summary>
    ///     Formats a number as a currency string with two decimal places.
    /// </summary>
    public const string Currency2 = "C2";

    // Decimal formats
    /// <summary>
    ///     Formats a number as a decimal string with no leading zeros.
    /// </summary>
    public const string Decimal = "D";

    /// <summary>
    ///     Formats a number as a decimal string with at least one digit.
    /// </summary>
    public const string Decimal1 = "D1";

    /// <summary>
    ///     Formats a number as a decimal string with at least two digits.
    /// </summary>
    public const string Decimal2 = "D2";

    /// <summary>
    ///     Formats a number as a decimal string with at least three digits.
    /// </summary>
    public const string Decimal3 = "D3";

    // Exponential (scientific) formats
    /// <summary>
    ///     Formats a number in exponential notation with the default number of decimal places.
    /// </summary>
    public const string Exponential = "E";

    /// <summary>
    ///     Formats a number in exponential notation with one decimal place.
    /// </summary>
    public const string Exponential1 = "E1";

    /// <summary>
    ///     Formats a number in exponential notation with two decimal places.
    /// </summary>
    public const string Exponential2 = "E2";

    // Fixed-point formats
    /// <summary>
    ///     Formats a number as a fixed-point string with the default number of decimal places.
    /// </summary>
    public const string FixedPoint = "F";

    /// <summary>
    ///     Formats a number as a fixed-point string with no decimal places.
    /// </summary>
    public const string FixedPoint0 = "F0";

    /// <summary>
    ///     Formats a number as a fixed-point string with one decimal place.
    /// </summary>
    public const string FixedPoint1 = "F1";

    /// <summary>
    ///     Formats a number as a fixed-point string with two decimal places.
    /// </summary>
    public const string FixedPoint2 = "F2";

    // General formats
    /// <summary>
    ///     Formats a number using the most compact representation (either fixed-point or exponential) with the default number
    ///     of significant digits.
    /// </summary>
    public const string General = "G";

    /// <summary>
    ///     Formats a number using the most compact representation (either fixed-point or exponential) with one significant
    ///     digit.
    /// </summary>
    public const string General1 = "G1";

    /// <summary>
    ///     Formats a number using the most compact representation (either fixed-point or exponential) with two significant
    ///     digits.
    /// </summary>
    public const string General2 = "G2";

    // Number formats
    /// <summary>
    ///     Formats a number as a number string with the default number of decimal places.
    /// </summary>
    public const string Number = "N";

    /// <summary>
    ///     Formats a number as a number string with no decimal places.
    /// </summary>
    public const string Number0 = "N0";

    /// <summary>
    ///     Formats a number as a number string with one decimal place.
    /// </summary>
    public const string Number1 = "N1";

    /// <summary>
    ///     Formats a number as a number string with two decimal places.
    /// </summary>
    public const string Number2 = "N2";

    // Percent formats
    /// <summary>
    ///     Formats a number as a percent string with the default number of decimal places.
    /// </summary>
    public const string Percent = "P";

    /// <summary>
    ///     Formats a number as a percent string with one decimal place.
    /// </summary>
    public const string Percent1 = "P1";

    /// <summary>
    ///     Formats a number as a percent string with two decimal places.
    /// </summary>
    public const string Percent2 = "P2";

    // Round-trip formats
    /// <summary>
    ///     Formats a number so that it can be converted to the same value using a round-trip conversion.
    /// </summary>
    public const string RoundTrip = "R";

    /// <summary>
    ///     Formats a number so that it can be converted to the same value using a round-trip conversion with two decimal
    ///     places.
    /// </summary>
    public const string RoundTrip2 = "R2";

    // Hexadecimal formats
    /// <summary>
    ///     Formats a number as a hexadecimal string with no leading zeros.
    /// </summary>
    public const string Hexadecimal = "X";

    /// <summary>
    ///     Formats a number as a hexadecimal string with at least one digit.
    /// </summary>
    public const string Hexadecimal1 = "X1";

    /// <summary>
    ///     Formats a number as a hexadecimal string with at least two digits.
    /// </summary>
    public const string Hexadecimal2 = "X2";
}