// See https://aka.ms/new-console-template for more information
internal class ElvesDirectory
{
    public string DirectoryName { get; set; }
    public List<string> DirectoryList { get; set; }
    public int DirectorySize { get; set; }
    public int DirectoryLevel { get; set; }

    public ElvesDirectory()
    {
        DirectoryName = "";
        DirectoryList = new List<string>(); 
        DirectoryLevel = 0; 
        DirectorySize = 0;
    }

    public ElvesDirectory(string directoryName, int directoryLevel, List<string> directoryList, int directorySize)
    {
        DirectoryLevel = directoryLevel;
        DirectoryList = directoryList;
        DirectorySize = directorySize;
        DirectoryName = directoryName;
    }
}