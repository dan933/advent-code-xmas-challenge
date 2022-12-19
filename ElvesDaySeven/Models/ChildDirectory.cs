// See https://aka.ms/new-console-template for more information

public class ChildDirectory
{
    public int DirIndex { get; set; }
    public string DirName { get; set; }
    public int DirLevel { get; set; }
    public int ParentIndex { get; set; }
    public bool IsUsed { get; set; }

    public ChildDirectory(int dirIndex, string dirName, int dirLevel, int parentIndex = 0)
    {
        DirIndex = dirIndex;
        DirName = dirName;
        DirLevel = dirLevel;
        ParentIndex = parentIndex;
        IsUsed = false;
    }
}