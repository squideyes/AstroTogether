namespace AstroTogether.Common;

public static class MiscExtenders
{
    public static void Action<T>(this T value, 
        Action<T> action) => action(value);

    public static R Get<T, R>(this T value, 
        Func<T, R> func) => func(value);
}
