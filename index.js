
const rucksackData = require('./data.js');

//Each rucksack has two compartments
//Every item type is identified by a single lowercase
//or uppercase letter (that is, a and A refer to different types of items).

//A ruck sack always has the same number of items in each compartment

// so the first half of the characters represent 
// items in the first compartment, while the second half of the characters
// represent items in the second compartment.

// Lowercase item types a-z have priorities 1 through 26
// Uppercase item types A through Z have prioties 27 to 52

// In the above example, the priority of the item type that appears in both compartments of each rucksack
//  is 16 (p), 38 (L), 42 (P), 22 (v), 20 (t), and 19 (s); 
//  the sum of these is 157.


const regSplitLines = /\n/

//create an array of each rucksack
const rucksackDataArr = rucksackData.split(regSplitLines);


let total = 0;

rucksackDataArr.forEach((rucksack) => {
    //split rucksack into compartments
    const compartmentOne = rucksack.slice(0, rucksack.length / 2 );
    const compartmentTwo = rucksack.slice(rucksack.length / 2, rucksack.length);

    //find the item that repeats
    for(let i = 0; i < compartmentOne.length; i++){

        //see if there is a match
        const IsMatch = compartmentTwo.match(compartmentOne[i]);

        //if match
        if(IsMatch){
            
            const asciiValue = compartmentOne[i].charCodeAt()

            //calculate letter to value
            const rucksackValue = asciiValue >= 97 ? asciiValue - 96 : asciiValue - 38

            total += rucksackValue;

            
            break;
        }


    }
})

console.log('total', total)