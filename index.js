
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

//elf group
let elfGroup = []


let specialTotal = 0;

rucksackDataArr.forEach((rucksack, index) => {

    //add rucksack to elfgroup
    elfGroup.push(rucksack);

    // If last member of group
    if ( elfGroup.length % 3 === 0 ){

        // //check which chars are the same between  between group 1 and 2
        for(let i = 0; i < elfGroup[0].length; i++){
            
            //Find special key in all three groups
            let charMatchGroupZeroOne = elfGroup[1].match(elfGroup[0][i]);
            let charMatchGroupZeroTwo = elfGroup[2].match(elfGroup[0][i]);
            
            //if special key is found
            if(charMatchGroupZeroOne && charMatchGroupZeroTwo){

                //item that is in all three rucksacks
                let specialChar = elfGroup[0][i];

                const asciiValue = specialChar.charCodeAt()

                //calculate letter to value
                const rucksackValue = asciiValue >= 97 ? asciiValue - 96 : asciiValue - 38
                specialTotal += rucksackValue;

                //add value to total
                

                //break loop
                break;
            }
            
        }

        //reset elfgroup
        elfGroup = [];





    }
})

console.log('specialTotal', specialTotal)