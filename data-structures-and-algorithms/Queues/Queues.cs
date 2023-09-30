namespace Queues
{
    public class DSA_Queues
    {
        public void QueuesCommonFeatures() 
        {
            // Creating a Queue
            Queue<string> queue = new Queue<string>();

            // Enqueue: Adding elements to the Queue
            queue.Enqueue("Apple");
            queue.Enqueue("Banana");
            queue.Enqueue("Cherry");

            // Dequeue: Removing and returning the element at the front of the Queue
            string frontItem = queue.Dequeue();
            Console.WriteLine($"Dequeued item: {frontItem}");

            // Peek: Viewing the element at the front of the Queue without removing it
            string peekedItem = queue.Peek();
            Console.WriteLine($"Peeked item: {peekedItem}");

            // Count: Getting the number of elements in the Queue
            int itemCount = queue.Count;
            Console.WriteLine($"Number of items in the Queue: {itemCount}");

            // Contains: Checking if an element exists in the Queue
            bool containsBanana = queue.Contains("Banana");
            Console.WriteLine($"Queue contains 'Banana': {containsBanana}");

            // Clear: Removing all elements from the Queue
            queue.Clear();
            Console.WriteLine("Queue cleared.");

            // Checking if the Queue is empty
            bool isEmpty = queue.Count == 0;
            Console.WriteLine($"Is the Queue empty? {isEmpty}");
        } 
    }
}