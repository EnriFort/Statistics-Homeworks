/* ARRAYS */

let myArray = ["Mr. White", "Mr. Orange", "Mr. Blonde", "Mr. Pink", "Mr. Blue", "Mr. Brown"];

// Loop with break and continue
console.log("Looping with break and continue:");
console.log();

console.log("Using break:");
for (let name of myArray) {
    if (name === "Mr. Pink") {
        console.log("Encountered Mr. Pink. Breaking loop.");
        break; // Exit the loop when "Mr. Pink" is found
    }
    console.log(name);
}

console.log();

console.log("Using continue:");
for (let name of myArray) {
    if (name === "Mr. Pink") {
        console.log("Skipping Mr. Pink.");
        continue; // Skip Mr. Pink and continue with the next iteration
    }
    console.log(name);
}

// Add element
let newArray = [...myArray, "Nice Guy"]; // Create a new array with one more element

// Remove element
let newArray2 = myArray.filter(name => name !== "Nice Guy");

// Check existence
newArray2.includes("Nice Guy");


/* LIST (equivalent to JavaScript array) */

// Create an array of integers (JavaScript array)
let myList = [1, 2, 3];

// Remove
myList = myList.filter(item => item !== 2);

// Loop
for (let item of myList) {
    console.log(item);
}

// Check existence
myList.includes(3);

// Get an element
let index = 1; // Index of element to get
let element = myList[index];
console.log(`Element at index ${index}: ${element}`);


/* DICTIONARY (equivalent to JavaScript object) */

// Create an object to store Tarantino movies and their release years
let tarantinoMovies = {
    "Reservoir Dogs": 1992,
    "Pulp Fiction": 1994,
    "Jackie Brown": 1997,
    "Kill Bill: Vol. 1": 2003,
    "Kill Bill: Vol. 2": 2004,
    "Death Proof": 2007,
    "Inglourious Basterds": 2009,
    "Django Unchained": 2012,
    "The Hateful Eight": 2015,
    "Once Upon a Time in Hollywood": 2019
};

// Remove element
delete tarantinoMovies["Jackie Brown"];

// Loop
for (let movie in tarantinoMovies) {
    console.log(`${movie} (${tarantinoMovies[movie]})`);
}

// Check existence
let hasPulpFiction = "Pulp Fiction" in tarantinoMovies;

// Get
let movieToGet = "Kill Bill: Vol. 1";
let releaseYear = tarantinoMovies[movieToGet];
if (releaseYear !== undefined) {
    console.log(`'${movieToGet}' was released in ${releaseYear}`);
} else {
    console.log(`'${movieToGet}' not found in the dictionary.`);
}

