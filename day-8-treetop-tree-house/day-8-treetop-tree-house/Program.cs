using System.Text.RegularExpressions;

var elvesData = ElvesData.GetPuzzleData();
//count the number of rows

//create an array
var treeArray = Regex.Split(elvesData, "\n");

//number of rows
var rows = treeArray.Length;


var seenTrees = 0;

//first and last rows are seen trees
seenTrees += treeArray[0].Length;
seenTrees += treeArray[treeArray.Length - 1].Length;


//left and right columns are seen
seenTrees += treeArray.Length * 2 - 4;

var treeDictionary = new Dictionary<int, List<char>>();

for (int treeLineIndex = 0; treeLineIndex < treeArray.Length; treeLineIndex++)
{
	//Tree Row
	var treeRow = treeArray[treeLineIndex];
	
	treeDictionary.Add(treeLineIndex, treeRow.ToList());
}

var columnsLength = treeDictionary[0].Count();

//Part 2
var mostViews = 0;

treeDictionary.ToList().ForEach(treeRow =>
{    
    var columnIndex = 0;
    var rowIndex = treeRow.Key;

    //only look at the inner grid
    if(rowIndex != rows - 1 & rowIndex != 0)
    {
        treeRow.Value.ForEach(tree =>
            {

                //Get current tree if it is in the inner grid
                var currentTree = treeDictionary[rowIndex]
                .Select((tree, index) => new { tree, index })
                .Where(x => x.index == columnIndex)
                .Where(x => x.index != 0 & x.index != columnsLength - 1)
                .FirstOrDefault();


                var currentViews = 0;
                var maxViewReached = false;

                var viewsLeft = 0;
                var viewsRight = 0;
                var viewsTop = 0;
                var viewsBottom = 0;

                if (currentTree != null)
                {
                    //Console.WriteLine($"Current Tree:{currentTree.tree}");

                    var IsSeenTop = true;
                    var IsSeenBottom = true;
                    var IsSeenLeft = true;
                    var IsSeenRight = true;                   


                    var leftOfTree = columnsLength - (columnsLength - currentTree.index);

                    ////check left current tree
                    treeDictionary[rowIndex]
                    .Take(leftOfTree)
                    .Reverse()
                    .ToList().ForEach(x =>
                    {
                        //part 2
                        if(currentTree.tree <= x & !maxViewReached)
                        {
                            viewsLeft += 1;
                            maxViewReached = true;

                        }
                        
                        if(currentTree.tree > x & !maxViewReached)
                        {
                            viewsLeft += 1;
                        }


                        if (currentTree.tree <= x)
                        {
                            IsSeenLeft = false;
                        }
                    });

                    var rightOfTree = currentTree.index + 1;

                    maxViewReached = false;

                    //check right current tree
                    treeDictionary[rowIndex]
                    .Skip(rightOfTree)
                    .ToList().ForEach(x =>
                    {
                        //Console.WriteLine(x);

                        //part 2
                        if (currentTree.tree <= x & !maxViewReached)
                        {
                            viewsRight += 1;
                            maxViewReached = true;
                        }
                        
                        if (currentTree.tree > x & !maxViewReached)
                        {
                            viewsRight += 1;
                        }

                        if (currentTree.tree <= x)
                        {
                            IsSeenRight = false;
                        }
                    });

                    maxViewReached = false;

                    ////check Above current tree
                    treeDictionary
                        .Where(x => x.Key < rowIndex)
                        .Reverse()
                        .ToList()
                        .ForEach(x =>
                            x.Value
                            .Select((tree, index) => new { tree, index })
                            .Where(x => x.index == columnIndex)
                            .ToList()
                                .ForEach(x =>
                                {

                                    //Console.WriteLine(x);

                                    //part 2
                                    if (currentTree.tree <= x.tree & !maxViewReached)
                                    {
                                        viewsTop += 1;
                                        maxViewReached = true;
                                    }
                                    
                                    if (currentTree.tree > x.tree & !maxViewReached)
                                    {
                                        viewsTop += 1;
                                    }

                                    if (currentTree.tree <= x.tree)
                                    {
                                        IsSeenTop = false;
                                    }
                                })
                        );

                    maxViewReached = false;

                    //check Below current tree
                    treeDictionary
                        .Where(x => x.Key > rowIndex)
                        .ToList()
                        .ForEach(x =>
                            x.Value
                            .Select((tree, index) => new { tree, index })
                            .Where(x => x.index == columnIndex)
                            .ToList()
                            .ForEach(x =>
                                {
                                    //Console.WriteLine(x);

                                    //part 2
                                    if (currentTree.tree <= x.tree & !maxViewReached)
                                    {
                                        viewsBottom += 1;
                                        maxViewReached = true;
                                    }
                                    else if (currentTree.tree > x.tree & !maxViewReached)
                                    {
                                        viewsBottom += 1;
                                    }

                                    if (currentTree.tree <= x.tree)
                                    {
                                        IsSeenBottom = false;
                                    }

                            })
                        );

                    //part 2
                    currentViews = viewsBottom * viewsTop * viewsLeft * viewsRight;

                    if(currentViews > mostViews)
                    {
                        mostViews = currentViews;
                    }

                    if (IsSeenBottom | IsSeenTop | IsSeenLeft | IsSeenRight)
                    {
                        seenTrees++;
                    }
                }


                columnIndex++;
            });
    }

});

Console.WriteLine($"MostViews: {mostViews}");

Console.WriteLine($"Seen Trees: {seenTrees}");