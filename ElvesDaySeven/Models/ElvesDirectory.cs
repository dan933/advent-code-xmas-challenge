// See https://aka.ms/new-console-template for more information
internal class ElvesDirectory
{
    public int DirectoryIndex { get; set; }
    public string DirectoryName { get; set; }
    public List<ChildDirectory> ChildDirectoryList { get; set; }
    public int DirectorySize { get; set; }
    public int DirectoryLevel { get; set; }
    public int ParentIndex { get; set; }
    public bool IsUsed { get; set; }

    public ElvesDirectory()
    {
        DirectoryName = "";
        ChildDirectoryList = new List<ChildDirectory>();
        DirectoryLevel = 0;
        DirectorySize = 0;
        ParentIndex = 0;
        IsUsed = false;
    }

    public ElvesDirectory(string directoryName, int directoryLevel, List<ChildDirectory> childDirectoryList, int directorySize, int ParentIndex, int directoryIndex)
    {
        DirectoryLevel = directoryLevel;
        ChildDirectoryList = childDirectoryList;
        DirectorySize = directorySize;
        this.ParentIndex = ParentIndex;
        DirectoryName = directoryName;
        DirectoryIndex = directoryIndex;
        IsUsed = false;
    }
}