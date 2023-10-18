using System;

class Program
{
    static void Main()
    {

        /* ARRAYS */
        string[] myArray = { "Mr. White", "Mr. Orange", "Mr. Blonde", "Mr. Pink", "Mr. Blue", "Mr. Brown" };


        // Loop (break/continue)
        Console.WriteLine("Looping with break and continue:");
        Console.WriteLine();

        Console.WriteLine("Using break:");
        foreach (string name in myArray)
        {
            if (name == "Mr. Pink")
            {
                Console.WriteLine("Encountered Mr. Pink. Breaking loop.");
                break; // Exit the loop when "Mr. Pink" is found
            }
            Console.WriteLine(name);
        }

        Console.WriteLine();

        Console.WriteLine("Using continue:");
        foreach (string name in myArray)
        {
            if (name == "Mr. Pink")
            {
                Console.WriteLine("Skipping Mr. Pink.");
                continue; // Skip Mr. Pink and continue with the next iteration
            }
            Console.WriteLine(name);
        }

        // Add element
        string[] newArray = new string[myArray.Length + 1]; // Create a new array with one more element
        
        for (int i = 0; i < myArray.Length; i++) // Copy the original elements to the new array
        {
            newArray[i] = myArray[i];
        }
        newArray[newArray.Length - 1] = "Nice Guy";  // Add the new element at the end
        myArray = newArray; // Update the reference to the new array


        // Remove element
        string[] newArray2 = new string[myArray.Length - 1];
        for (int i = 0; i < myArray.Length; i++)
        {
            if (myArray[i] == "Nice Guy") continue;
            newArray2[i] = myArray[i];
        }

        // Check existence
        newArray2.Contains("Nice Guy");


        /* LIST */

        // Create a list of integers
        List<int> myList = new List<int>();

        // Add elements
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        // Remove
        myList.Remove(2);

        // Loop
        foreach (int item in myList)
        {
            Console.WriteLine(item);
        }

        // Check existence
        myList.Contains(3);

        // Get an element
        int index = 1; // index of element to get
        int element = myList[index];
        Console.WriteLine($"Element at index {index}: {element}");


        /* DICTIONARY */

        // Create a dictionary of integers with string keys
        Dictionary<string, int> tarantinoMovies = new Dictionary<string, int>();

        // Add elements
        tarantinoMovies["Reservoir Dogs"] = 1992;
        tarantinoMovies["Pulp Fiction"] = 1994;
        tarantinoMovies["Jackie Brown"] = 1997;
        tarantinoMovies["Kill Bill: Vol. 1"] = 2003;
        tarantinoMovies["Kill Bill: Vol. 2"] = 2004;
        tarantinoMovies["Death Proof"] = 2007;
        tarantinoMovies["Inglourious Basterds"] = 2009;
        tarantinoMovies["Django Unchained"] = 2012;
        tarantinoMovies["The Hateful Eight"] = 2015;
        tarantinoMovies["Once Upon a Time in Hollywood"] = 2019;

        // Remove element
        tarantinoMovies.Remove("Jackie Brown");

        // loop 
        foreach (var kvp in tarantinoMovies)
        {
            Console.WriteLine($"{kvp.Key} ({kvp.Value})");
        }

        // check 
        tarantinoMovies.ContainsKey("Pulp Fiction");
        

        // Get 
        string movieToGet = "Kill Bill: Vol. 1";
        if (tarantinoMovies.TryGetValue(movieToGet, out int releaseYear))
        {
            Console.WriteLine($"\n'{movieToGet}' was released in {releaseYear}");
        }
        else
        {
            Console.WriteLine($"\n'{movieToGet}' not found in the dictionary.");
        }

    }
}
