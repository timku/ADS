using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr3
{

    class StackX
    {
        private int maxSize;
        private char[] stackArray;
        private int top;
        public StackX(int s)       // constructor
        {
            maxSize = s;
            stackArray = new char[maxSize];
            top = -1;
        }
        public void push(char j)  // put item on top of stack
        { stackArray[++top] = j; }
        public char pop()         // take item from top of stack
        { return stackArray[top--]; }
        public char peek()        // peek at top of stack
        { return stackArray[top]; }
        public bool isEmpty()  // true if stack is empty
        { return (top == -1); }
        public int size()         // return size
        { return top + 1; }
        public char peekN(int n)  // return item at index n
        { return stackArray[n]; }

        public void displayStack(String s)
        {
            Console.Out.Write(s);
            Console.Out.Write("Stack (bottom-->top): ");
            for (int j = 0; j < size(); j++)
            {
                Console.Out.Write(peekN(j));
                Console.Out.Write(" ");
            }
            Console.Out.WriteLine("");
        }
    }
}
