// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var elvesData = new ElvesData();

var linesArray = elvesData.puzzleInput.Split('\n');

int directoryLevel = 0;

int directoryIndex = 0;

var elvesDirectoryDictionary = new Dictionary<int, ElvesDirectory>();


//itterate through storage directories/files
for (var i = 0; i < linesArray.Length; i++)
{
    //add main directory to dictionary
    if (i == 0)
    {
        elvesDirectoryDictionary.Add(directoryIndex,
            new ElvesDirectory("mainDirectory", directoryLevel, new List<string>(), 0)
        );

        continue;
    }

    //if item is current directory is moving forward
    var directoryName = linesArray[i];
    var IsCDForward = ValidationService.IsCDForward(directoryName);

    if (IsCDForward)
    {
        //replace $ cd with the name of the directory
        var pattern = @"\$ cd";
        directoryName = Regex.Replace(directoryName, pattern, "dir");

        //increment directory level
        ++directoryLevel;

        //increment directory index
        ++directoryIndex;

        //add new ElvesDirectory to elvesDirectoryDictionary
        elvesDirectoryDictionary.Add(directoryIndex,
            new ElvesDirectory(directoryName, directoryLevel, new List<string>(), 0)
        );

    }

    //if item is current directory is moving back
    var IsCDBackward = ValidationService.IsCDBackward(linesArray[i]);
    if (IsCDBackward)
    {
        //decrement directory level
        --directoryLevel;
    }

    var IsDirectory = ValidationService.IsDir(linesArray[i]);

    //if item is a directory
    if (IsDirectory)
    {
        //get the currentDirectory values
        var currentDirectory = elvesDirectoryDictionary[directoryIndex];

        //add the new directory to the currentDirectory directory list
        currentDirectory.DirectoryList.Add(linesArray[i]);

        //update the dictionary
        elvesDirectoryDictionary[directoryIndex] = currentDirectory;

        continue;
    }

    //if item is a file
    var IsFile = ValidationService.IsFile(linesArray[i]);

    if (IsFile)
    {
        // update currentDirectory size total
        var currentDirectory = elvesDirectoryDictionary[directoryIndex];

        //get filesize
        var fileSize = CalculationService.GetFileSize(linesArray[i]);

        currentDirectory.DirectorySize += fileSize;

        elvesDirectoryDictionary[directoryIndex] = currentDirectory;
    }
}

var elvesDictionaryLength = elvesDirectoryDictionary.Count - 1;

//itterate in reverse key order
for (int i = elvesDictionaryLength; i >= 0; i -= 1)
{
    //child directory
    var childDirectory = elvesDirectoryDictionary[i];

    //get child directory name
    var childDirectoryName = childDirectory.DirectoryName;

    //check if child has parent
    var parentDirectory = elvesDirectoryDictionary
        .Where(x =>
        x.Value.DirectoryList.Contains(childDirectoryName) &&
        x.Value.DirectoryLevel + 1 == childDirectory.DirectoryLevel
        )
        .FirstOrDefault();

    //if child has parent
    // and parent is one level above child
    if (parentDirectory.Value != null &&
        parentDirectory.Value.DirectoryLevel + 1 == childDirectory.DirectoryLevel)
    {
        //Add child directory size to parent
        parentDirectory.Value.DirectorySize += childDirectory.DirectorySize;

        //remove child from parent
        parentDirectory.Value.DirectoryList.Remove(childDirectoryName);

        //update parent
        elvesDirectoryDictionary[parentDirectory.Key] = parentDirectory.Value;
    }

}

var filteredDirectories = elvesDirectoryDictionary
    .Where(x => x.Value.DirectorySize <= 100000)
    .ToList();

var totalSize = 0;
foreach (var item in filteredDirectories)
{
    totalSize += item.Value.DirectorySize;
}

Console.WriteLine($"Total Size: {totalSize}");