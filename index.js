const data = require('./data.js')

const stream = data.stream;


// create counter to keep track of the stream
let counter = 0;

//array for the marker
let markerArray = [];

//while loop to itterate over the stream
while(markerArray.length < 4){

    //current stream char
    let currentStream = stream[counter]


    //stream char is already in array
    let IsInvalidMarker = markerArray.includes(currentStream)

    if(IsInvalidMarker){

        //finds the index of the repeated char
        let invalidMarkerIndex = markerArray.indexOf(currentStream);

        //resets the array after the invalid marker
        markerArray = markerArray.slice(invalidMarkerIndex + 1);        
    }

    //if marker has signal found
    if(markerArray.length === 4){
        break;    
    }
    
    //add to stream array
    markerArray.push(currentStream);

    counter++;
    

}

console.log(markerArray)
console.log(counter)