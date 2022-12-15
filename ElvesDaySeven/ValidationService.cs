// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

public class ValidationService
{
    public ValidationService()
    {
    }

    public static bool IsFile(string item)
    {
        string IsFile = @"^\d+ \S+";
        return Regex.IsMatch(item, IsFile);
    }

    public static bool IsList(string item)
    {
        string IsList = @"\$ ls";
        return Regex.IsMatch(item, IsList);
    }

    public static bool IsDir(string item)
    {
        string IsList = @"dir \S+";
        return Regex.IsMatch(item, IsList);
    }

    public static bool IsCDForward(string item)
    {
        string IsList = @"^\$ cd [^\.]+|cd \.[^\.]+";
        return Regex.IsMatch(item, IsList);
    }

    public static bool IsCDBackward(string item)
    {
        string IsList = @"^\$ cd \.\.";
        return Regex.IsMatch(item, IsList);
    }
}