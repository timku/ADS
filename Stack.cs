using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr4 {
    class Stack {
        private int maxSize;
        private Node[] stackArray;
        private int top;
        public Stack()       // constructor
        {
            maxSize = 1000;//TODO: need to make this variable
            stackArray = new Node[maxSize];
            top = -1;
        }
        public void push(Node j)  // put item on top of stack
        { stackArray[++top] = j; }
        public Node pop()         // take item from top of stack
        { return stackArray[top--]; }
        public Node peek()        // peek at top of stack
        { return stackArray[top]; }
        public bool isEmpty()  // true if stack is empty
        { return (top == -1); }
        public int size()         // return size
        { return top + 1; }
        public Node peekN(int n)  // return item at index n
        { return stackArray[n]; }

        public void displayStack(String s) {
            Console.Out.Write(s);
            Console.Out.Write("Stack (bottom-->top): ");
            for (int j = 0; j < size(); j++) {
                Console.Out.Write(peekN(j));
                Console.Out.Write(" ");
            }
            Console.Out.WriteLine("");
        }
    }
}
