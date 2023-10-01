
namespace Stacks
{
    public class DSA_Stacks
    {

        //StackCommonFeatures- In this code:

        // 1. create a `Stack<string>` called `stack` to hold strings.
        // 2. add elements("Apple," "Banana," and "Cherry") to the stack using the `Push` method.
        // 3. check if the stack is empty using the `Count` property.
        // 4. peek at the top element without removing it using the `Peek` method.
        // 5. iterate through the stack to display its elements.
        // 6. use the `Pop` method to remove and return the top element.
        // 7. iterate through the stack again to display the remaining elements.
        // 8. check the count of elements in the stack using the `Count` property.

        public void StackCommonFeatures()
        {
            // Create a new stack of strings
            Stack<string> stack = new Stack<string>();

            // Add elements to the stack
            stack.Push("Apple");
            stack.Push("Banana");
            stack.Push("Cherry");

            // Check if the stack is empty
            bool isEmpty = stack.Count == 0;
            Console.WriteLine($"Is the stack empty? {isEmpty}");

            // Peek at the top element without removing it
            string topElement = stack.Peek();
            Console.WriteLine($"Top element (Peek): {topElement}");

            // Display the elements in the stack
            Console.WriteLine("\nElements in the stack:");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            // Remove and return the top element from the stack
            string poppedElement = stack.Pop();
            Console.WriteLine($"\nPopped element: {poppedElement}");

            // Display the remaining elements in the stack
            Console.WriteLine("\nRemaining elements in the stack:");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            // Check the count of elements in the stack
            int count = stack.Count;
            Console.WriteLine($"\nNumber of elements in the stack: {count}");
        }

        public void StackSearchFeatures()
        {
            Stack<string> stack = new Stack<string>();

            stack.Push("Hamid");
            stack.Push("Aslam");
            stack.Push("Kalam");
            stack.Push("Jaman");
            stack.Push("Mia");

            string searchValue = "Kalam";
            int index = -1;
            int count = 1;

            foreach (var item in stack)
            {
                if (item == searchValue)
                {
                    count = index;
                    break;
                }

                index++;
            }

            if (index != -1)
                Console.WriteLine($"Index: {count}");
            else
                Console.WriteLine($"Not found the value");

        }

        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' && (stack.Count == 0 || stack.Pop() != '('))
                {
                    return false;
                }
                else if (c == ']' && (stack.Count == 0 || stack.Pop() != '['))
                {
                    return false;
                }
                else if (c == '}' && (stack.Count == 0 || stack.Pop() != '{'))
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }

    }
}