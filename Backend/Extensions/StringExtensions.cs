namespace Backend.Extensions;

public static class StringExtensions
{
    public static string Capitalize(this string str)
    {
        return char.ToUpper(str[0]) + str[1..];
    }
}
