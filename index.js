const data = require('./data.js')

const regPair = /,|\n/

//split each task group
let cleanUpPairs = data.split(regPair);


cleanUpTaskArray = [];

//itterate through the clean up pairs
cleanUpPairs.forEach((cleanTask) => {
    
    const tasks = [];

    const regFirstTask = /\d+/g
    const taskArray =  cleanTask.match(regFirstTask)
    const firstTask =taskArray[0];
    const lastTask = taskArray[1];

    for(let i = +firstTask; i <= +lastTask; i++){
        tasks.push(i)
    }

    cleanUpTaskArray.push(tasks);

})


let fullyContainedCounter = 0;

//itterate through clean up tasks
cleanUpTaskArray.forEach((taskGroup, index) => {
    let groupNumber = (index + 1)

    if( groupNumber % 2 == 0){

        //get the group tasks
        let firstTasks = cleanUpTaskArray[index - 1];
        let secondTasks = taskGroup;

        //if first tasks is the longer array
        if(firstTasks.length > secondTasks.length){

            if( firstTasks[0] <= secondTasks[0] &&
                firstTasks[firstTasks.length - 1] >= secondTasks[secondTasks.length - 1]){

                    fullyContainedCounter++
            }
        }else if ( secondTasks[0] <= firstTasks[0] && 
                    secondTasks[secondTasks.length - 1] >= firstTasks[firstTasks.length - 1] ){

                        fullyContainedCounter++
                    }
        
    }
})


// console.log('cleanUpTaskArray', cleanUpTaskArray)
//console.log('fullyContainedCounter', fullyContainedCounter)
