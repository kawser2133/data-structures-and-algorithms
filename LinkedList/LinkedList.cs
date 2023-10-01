
namespace LinkedList
{
    public class DSA_LinkedList
    {
        public void LinkedListCommonFeatures()
        {
            // Create a new LinkedList
            LinkedList<int> myList = new LinkedList<int>();

            // Adding Elements
            myList.AddLast(1);
            myList.AddLast(2);
            myList.AddLast(3);

            // Accessing Elements
            Console.WriteLine("Elements:");
            foreach (int item in myList)
            {
                Console.WriteLine(item);
            }

            // Counting Elements
            Console.WriteLine("\nCount: " + myList.Count);

            // Searching for Elements by Value
            int searchValue = 2;
            Console.WriteLine($"\nSearching for {searchValue}:");
            foreach (int item in myList)
            {
                if (item == searchValue)
                {
                    Console.WriteLine("Found: " + item);
                }
            }

            // Adding Elements Before and After
            LinkedListNode<int> node = myList.Find(2);
            if (node != null)
            {
                myList.AddBefore(node, 0); // Add 0 before 2
                myList.AddAfter(node, 4);  // Add 4 after 2
            }

            // Adding Elements at the Beginning
            myList.AddFirst(9);

            // Accessing Elements Again
            Console.WriteLine("\nUpdated Elements:");
            foreach (int item in myList)
            {
                Console.WriteLine(item);
            }

            // Removing Elements
            myList.RemoveFirst();
            myList.RemoveLast();

            // Checking for Element Existence
            bool containsTwo = myList.Contains(2);
            Console.WriteLine("\nContains 2: " + containsTwo);

            // Converting to Array
            int[] array = myList.ToArray();
            Console.WriteLine("\nArray:");
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }

            // Copying to an Array
            int[] copyArray = new int[myList.Count];
            myList.CopyTo(copyArray, 0);
            Console.WriteLine("\nCopyArray:");
            foreach (int item in copyArray)
            {
                Console.WriteLine(item);
            }

            // Clearing the List
            myList.Clear();

            // Checking Count After Clear
            Console.WriteLine("\nCount After Clear: " + myList.Count);
        }
    }
}
