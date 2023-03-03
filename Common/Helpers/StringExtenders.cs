// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

namespace SquidEyes.Basics;

public static partial class StringExtenders
{
    public static bool IsNonEmptyAndTrimmed(
        this string value, int minLength, int maxLength)
    {
        if (minLength < 1)
            throw new ArgumentOutOfRangeException(nameof(minLength));

        if (maxLength < minLength)
            throw new ArgumentOutOfRangeException(nameof(maxLength));

        return !string.IsNullOrWhiteSpace(value)
            && value.Length >= minLength
            && value.Length <= maxLength
            && !char.IsWhiteSpace(value[0])
            && !char.IsWhiteSpace(value[^1]);
    }
}