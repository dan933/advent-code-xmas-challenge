using System.Text.RegularExpressions;

internal class RowService
{
    public static bool IsEndOfLine(char charecter)
    {
        var pattern = @"\n";
        return Regex.IsMatch(charecter.ToString(), pattern);
    }
}