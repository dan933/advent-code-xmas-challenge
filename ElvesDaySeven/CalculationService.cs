// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

public class CalculationService
{
    public CalculationService()
    {
    }

    public static int GetFileSize(string item)
    {
        string IsFile = @"^\d+";
        int fileSize = int.Parse(Regex.Match(item, IsFile).Value);
        if (fileSize <= 0) 
        {
            throw new NullReferenceException("File size should be greater than 0");
        }
        return fileSize;
    }
}