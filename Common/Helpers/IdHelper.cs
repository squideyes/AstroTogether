using System.Security.Cryptography;
using System.Text;

namespace AstroTogether.Common;

public static class IdHelper
{
    internal static string GetRandomId(char[] charSet, int size)
    {
        var data = new byte[4 * size];

        using (var rng = RandomNumberGenerator.Create())
            rng.GetBytes(data);

        var result = new StringBuilder(size);

        for (int i = 0; i < size; i++)
        {
            var value = BitConverter.ToUInt32(data, i * 4);

            result.Append(charSet[value % charSet.Length]);
        }

        return result.ToString();
    }
}