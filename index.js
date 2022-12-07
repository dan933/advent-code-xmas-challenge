const data = require('./data.js')

const containers =  data.containers;
const instructions = data.instructions;

const exampleContainers = data.exampleContainers;
const exampleInstructions = data.exampleInstructions;

//iterate over the instructions
instructions.forEach((instruction) => {
    
    let itemsMoved;

    let startIndex = 0;

    let endIndex = instruction.move;

    //remove from container
    itemsMoved = containers[instruction.from - 1].splice(startIndex, endIndex);
    containers[instruction.to - 1] = itemsMoved.concat(containers[instruction.to - 1]);
})

let topCreateCode = '';

containers.forEach((container) =>
{
        topCreateCode += container[0];
});

console.log('topCreateCode', topCreateCode)