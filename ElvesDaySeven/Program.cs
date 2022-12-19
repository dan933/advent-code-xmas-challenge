// See https://aka.ms/new-console-template for more information

var elvesData = new ElvesData();

var linesArray = elvesData.puzzleInput.Split('\n');

//Console.WriteLine(storageUsed);

var currentIndex = 0;
var directoryIndex = 0;
var cdBackCount = 0;
var directoryLevel = 0;
int cdBackIndex;


var dictionary = new Dictionary<int, ElvesDirectory>();

var newDirectory = new ElvesDirectory(
    CalculationService.GetDirName(linesArray[currentIndex]),
    directoryLevel,
    new List<ChildDirectory>(),
    0,
    -1,
    currentIndex
    );

dictionary.Add(currentIndex, newDirectory);

for (int i = 1; i < linesArray.Length; i++)
{
    //If current line command is cd ..
    if (ValidationService.IsCDBackward(linesArray[i]))
    {
        //track the number of cd..
        ++cdBackCount;

        //decrease the directory level
        --directoryLevel;
    }
    else
    {
        //if command line is not cd ..
        //make cd back the current index
        cdBackIndex = currentIndex;

        //run through the number of cd backs
        while(cdBackCount > 0)
        {
            //make the file size
            var fileSize = dictionary[cdBackIndex].DirectorySize;
            
            //make cdbackindex the parent of the current cdbackindex
            cdBackIndex = dictionary[cdBackIndex].ParentIndex;

            
            //add the fileSize to the parent
            dictionary[cdBackIndex].DirectorySize += fileSize;

            //decrement cd back count
            cdBackCount--;
            
        }
    }

    //If command line is a directory
    if (ValidationService.IsDir(linesArray[i]))
    {
        //increment directory index
        ++directoryIndex;

        //create the directory as a child of the current directory
        dictionary[currentIndex].ChildDirectoryList
            .Add(
             new ChildDirectory(
                 directoryIndex,
                 linesArray[i],
                 directoryLevel + 1,
                 currentIndex
                 )
            );
    }

    if (ValidationService.IsCDForward(linesArray[i]))
    {
        // convert cd dirName to dir dirName
        var directoryName = CalculationService.GetDirName(linesArray[i]);

        //find the parent with the directory name
        //parent with the closest index and IsUsed of child has to be true
        var parent = dictionary
            .Where(x => x.Value.ChildDirectoryList
                .Where(c => c.DirName == directoryName)
                .Where(c => !c.IsUsed).Any())
            .OrderByDescending(x => x.Value.DirectoryIndex)
            .First();

        

        var childDirectoryRef = parent.Value.ChildDirectoryList
            .Where(x => x.DirName == directoryName)
            .First();

        var parentIndex = parent.Value.DirectoryIndex;
        currentIndex = childDirectoryRef.DirIndex;

        //create new directory
        newDirectory = new ElvesDirectory(
            directoryName,
            childDirectoryRef.DirLevel,
            new List<ChildDirectory>(),
            0,
            parentIndex,
            currentIndex
            );

        //Add to dictionary
        dictionary.Add(childDirectoryRef.DirIndex, newDirectory);

        parent.Value.ChildDirectoryList
            .Where(x => x.DirName == directoryName)
            .First().IsUsed = true;
    }

    if (ValidationService.IsFile(linesArray[i]))
    {
        var fileSize = CalculationService.GetFileSize(linesArray[i]);

        dictionary[currentIndex].DirectorySize += fileSize;
    }

}

cdBackIndex = dictionary.Last().Value.DirectoryIndex;

//run through the number of cd backs
while (cdBackIndex != -1)
{


    //make the file size
    var fileSize = dictionary[cdBackIndex].DirectorySize;

    //make cdbackindex the parent of the current cdbackindex
    cdBackIndex = dictionary[cdBackIndex].ParentIndex;

    if (cdBackIndex == -1)
    {
        break;
    }


    //add the fileSize to the parent
    dictionary[cdBackIndex].DirectorySize += fileSize;
}




// part 1

var total = dictionary
    .Where(x => x.Value.DirectorySize <= 100000)
    .Sum(x => x.Value.DirectorySize);


//part 2
var availableDiskSpace = 70000000;
var requiredUpdateSpace = 30000000;
var usedDiskSpace = dictionary[0].DirectorySize;

var currentFreeSpace = availableDiskSpace - usedDiskSpace;

var freeSpaceNeeded = requiredUpdateSpace - currentFreeSpace;


var fileToDelete = dictionary
    .Where(x => x.Value.DirectorySize >= freeSpaceNeeded)
    .Select(x => new { x.Value.DirectorySize })
    .OrderBy(x => x.DirectorySize)
    .FirstOrDefault();

Console.WriteLine(fileToDelete);