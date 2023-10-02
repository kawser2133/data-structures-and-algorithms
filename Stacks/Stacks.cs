
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

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
    }

    public class Solutions
    {
        #region Q1. Backspace String Compare
        //Given two strings s and t, return true if they are equal when both are typed into empty text editors. '#' means a backspace character.
        //Note that after backspacing an empty text, the text will continue empty.

        //Example 1:

        //Input: s = "ab#c", t = "ad#c"
        //Output: true
        //Explanation: Both s and t become "ac".

        public bool BackspaceCompare(string s, string t)
        {
            Stack<char> sStack = new Stack<char>();
            Stack<char> tStack = new Stack<char>();

            foreach (char c in s)
            {
                if (c != '#')
                {
                    sStack.Push(c);
                }
                else if (sStack.Count > 0)
                {
                    sStack.Pop();
                }
            }

            foreach (char c in t)
            {
                if (c != '#')
                {
                    tStack.Push(c);
                }
                else if (tStack.Count > 0)
                {
                    tStack.Pop();
                }
            }

            if (sStack.Count != tStack.Count)
            {
                return false;
            }

            while (sStack.Count > 0)
            {
                if (sStack.Pop() != tStack.Pop())
                    return false;
            }

            return true;

        }
        #endregion

        #region Q2. Valid Parentheses
        //https://leetcode.com/problems/valid-parentheses/
        //Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

        //An input string is valid if:
        //Open brackets must be closed by the same type of brackets.
        //Open brackets must be closed in the correct order.
        //Every close bracket has a corresponding open bracket of the same type.

        //Example 1:
        //Input: s = "()"
        //Output: true

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
        #endregion

        #region Q4. Next Greater Element I
        //The next greater element of some element x in an array is the first greater element that is to the right of x in the same array.

        //You are given two distinct 0-indexed integer arrays nums1 and nums2, where nums1 is a subset of nums2.
        //For each 0 <= i<nums1.length, find the index j such that nums1[i] == nums2[j] and determine the next greater element of nums2[j] in nums2.If there is no next greater element, then the answer for this query is -1.
        //Return an array ans of length nums1.length such that ans[i] is the next greater element as described above.

        //Example 1:
        //Input: nums1 = [4, 1, 2], nums2 = [1, 3, 4, 2]
        //Output: [-1,3,-1]
        //Explanation: The next greater element for each value of nums1 is as follows:
        //- 4 is underlined in nums2 = [1, 3, 4, 2].There is no next greater element, so the answer is -1.
        //- 1 is underlined in nums2 = [1, 3, 4, 2].The next greater element is 3.
        //- 2 is underlined in nums2 = [1, 3, 4, 2].There is no next greater element, so the answer is -1.

        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {

            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> nextGreater = new Dictionary<int, int>();
            int[] result = new int[nums1.Length];

            foreach (var item in nums2)
            {
                while (stack.Count > 0 && item > stack.Peek())
                {
                    nextGreater[stack.Pop()] = item;
                }
                stack.Push(item);
            }

            for (int i = 0; i < nums1.Length; i++)
            {
                result[i] = nextGreater.ContainsKey(nums1[i]) ? nextGreater[nums1[i]] : -1;
            }
            return result;
        }

        #endregion

        #region Q5. Daily Temperatures
        //https://leetcode.com/problems/daily-temperatures/
        //Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature.If there is no future day for which this is possible, keep answer[i] == 0 instead.

        //Example 1:
        //Input: temperatures = [73,74,75,71,69,72,76,73]
        //Output: [1,1,4,2,1,1,0,0]

        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] result = new int[temperatures.Length];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < temperatures.Length; i++)
            {

                if (stack.Count > 0)
                {
                    if (temperatures[i] > stack.Peek() )
                    {
                        result[i] = temperatures[i] - stack.Pop();
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                stack.Push(temperatures[i]);
            }

            return result;
        }

        #endregion
    }

    #region Q3. Min Stack
    //https://leetcode.com/problems/min-stack/
    //Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

    //Implement the MinStack class:

    //MinStack() initializes the stack object.
    //void push(int val) pushes the element val onto the stack.
    //void pop() removes the element on the top of the stack.
    //int top() gets the top element of the stack.
    //int getMin() retrieves the minimum element in the stack.
    //You must implement a solution with O(1) time complexity for each function.

    //Example 1:

    //Input
    //["MinStack", "push", "push", "push", "getMin", "pop", "top", "getMin"]
    //[[], [-2], [0], [-3], [], [], [], []]
    //Output
    //[null, null, null, null, -3, null, 0, -2]

    public class MinStack
    {

        private Stack<int> inputStack;

        public MinStack()
        {
            inputStack = new Stack<int>();
        }

        public void Push(int val)
        {
            inputStack.Push(val);
        }

        public void Pop()
        {
            if (inputStack.Count > 0)
                inputStack.Pop();
            else
                throw new InvalidOperationException("Stack is empty");
        }

        public int Top()
        {
            if (inputStack.Count > 0)
            {
                return inputStack.Peek();
            }
            else
                throw new InvalidOperationException("Stack is empty");
        }

        public int GetMin()
        {
            if (inputStack.Count > 0)
            {
                return inputStack.Min();
            }
            else
                throw new InvalidOperationException("Stack is empty");
        }
    }
    #endregion

}