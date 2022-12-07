const data = require('./data.js')

const containers =  data.containers;
const instructions = data.instructions;

const exampleContainers = data.exampleContainers;
const exampleInstructions = data.exampleInstructions;

//iterate over the instructions
instructions.forEach((instruction) => {
    
    let itemMoved;

    //itterate over the number of moves
    for(let i = 0; i < instruction.move; i++){

        //remove from container
        itemMoved = containers[instruction.from - 1].shift();

        //Add to new container
        containers[instruction.to - 1].unshift(itemMoved);
    }
})

let topCreateCode = '';

containers.forEach((container) =>
{
        topCreateCode += container[0];
});

console.log('topCreateCode', topCreateCode)