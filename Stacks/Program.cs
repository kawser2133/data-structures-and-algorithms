﻿using Stacks;

Solutions solutions = new Solutions();

// Q1. Backspace String Compare
var result = solutions.BackspaceCompare("a#c", "d#c#");

// Q2. Valid Parentheses
solutions.IsValid("()[]{}");

// Q3. Min Stack
MinStack minStack = new MinStack();
minStack.Push(-2);
minStack.Push(0);
minStack.Push(-3);
minStack.GetMin();
minStack.Pop();
minStack.Top();
minStack.GetMin();

// Q4. NextGreaterElement

int[] nums1 = { 4, 1, 2 };
int[] nums2 = { 1, 3, 4, 2 };
solutions.NextGreaterElement(nums1, nums2);



Console.WriteLine(result);
Console.ReadLine();