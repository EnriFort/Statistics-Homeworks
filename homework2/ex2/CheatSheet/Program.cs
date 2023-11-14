using System;

class Program
{
    static void Main()
    {

        /* ARRAYS */

        // Create an Array
        string[] myArray = { "Mr. White", "Mr. Orange", "Mr. Blonde", "Mr. Pink", "Mr. Blue", "Mr. Brown" };

        // Loop
        // (break) 
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
        
        //(continue)
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




        /* SORTED LIST */

        // Create a sorted list of integers
        SortedList<int, string> mySortedList = new SortedList<int, string>();

        // Add elements
        mySortedList.Add(1, "One");
        mySortedList.Add(3, "Three");
        mySortedList.Add(2, "Two");

        // Remove
        mySortedList.Remove(2);

        // Loop
        foreach (var pair in mySortedList)
        {
            Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
        }

        // Check existence
        bool containsKey = mySortedList.ContainsKey(3);
        bool containsValue = mySortedList.ContainsValue("One");

        // Get an element by key
        int key = 1;
        string value = mySortedList[key];
        Console.WriteLine($"Value for key {key}: {value}");




        /* HASHSET */

        // Create a hash set of integers
        HashSet<int> myHashSet = new HashSet<int>();

        // Add elements
        myHashSet.Add(1);
        myHashSet.Add(2);
        myHashSet.Add(3);

        // Remove
        myHashSet.Remove(2);

        // Loop
        foreach (int item in myHashSet)
        {
            Console.WriteLine(item);
        }

        // Check existence
        bool containsItem = myHashSet.Contains(3);



        
        
        /* QUEUE */

        // Create a queue of integers
        Queue<int> myQueue = new Queue<int>();

        // Enqueue (add) elements
        myQueue.Enqueue(1);
        myQueue.Enqueue(2);
        myQueue.Enqueue(3);

        // Dequeue (remove)
        int removedItem = myQueue.Dequeue(); // Dequeued item is now in 'removedItem'

        // Loop
        foreach (int item in myQueue)
        {
            Console.WriteLine(item);
        }

        // Check existence
        containsItem = myQueue.Contains(3);

        // Peek (get the front element without removing it)
        int frontItem = myQueue.Peek();




        /* STACK */

        // Create a stack of integers
        Stack<int> myStack = new Stack<int>();

        // Add elements
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);

        // Remove (pop)
        removedItem = myStack.Pop(); // Popped item is now in 'removedItem'

        // Loop
        foreach (int item in myStack)
        {
            Console.WriteLine(item);
        }

        // Check existence
        containsItem = myStack.Contains(3);

        // Peek (get the top element without removing it)
        int topItem = myStack.Peek();





        /* LINKED LIST */

        // Create a linked list of integers
        LinkedList<int> myLinkedList = new LinkedList<int>();

        // Add elements
        myLinkedList.AddLast(1);
        myLinkedList.AddLast(2);
        myLinkedList.AddLast(3);

        // Remove
        LinkedListNode<int> nodeToRemove = myLinkedList.Find(2);
        myLinkedList.Remove(nodeToRemove);

        // Loop
        foreach (int item in myLinkedList)
        {
            Console.WriteLine(item);
        }

        // Check existence
        containsItem = myLinkedList.Contains(3);

        // Get an element
        index = 1; // index of element to get
        LinkedListNode<int> node = myLinkedList.First;
        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }
        element = node.Value;
        Console.WriteLine($"Element at index {index}: {element}");
    }
}
