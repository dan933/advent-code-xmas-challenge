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


let duplicateCounter = 0;

//itterate through clean up tasks
cleanUpTaskArray.forEach((taskGroup, index) => {
    let groupNumber = (index + 1)

    if( groupNumber % 2 == 0){

        //get the group tasks
        let firstTasks = cleanUpTaskArray[index - 1];
        let secondTasks = taskGroup;

        if(firstTasks.length >= secondTasks.length){
            //itterate over longest array
            for( let i = 0; i < firstTasks.length; i++ ) {
                if(secondTasks.includes(firstTasks[i])){
                    duplicateCounter++
                    break;
                }
            }

        } else if(secondTasks.length > firstTasks.length){
            for( let i = 0; i < secondTasks.length; i++ ){
                if(firstTasks.includes(secondTasks[i])){  
                    duplicateCounter++
                    break;
                }
                
            }
        }        
    }
})

console.log('duplicateCounter', duplicateCounter)
