using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr5 {
    class StackPart {
        private int locX;
        private int locY;
        private int dir;
        public StackPart(int X, int Y, int d) {
            locX = X;
            locY = Y;
            dir = d;
        }
        public int getX(){
            return locX;
        }
        public int getY(){
            return locY;
        }
        public int getDir() {
            return dir;
        }
    }
    class Stack {
        private int maxSize;
        private StackPart[] stackArray;
        private int top;
        public Stack(int s)// constructor
        {
            maxSize = s;
            stackArray = new StackPart[maxSize];
            top = -1;
        }
        public void push(int x, int y, int dir) {  // put item on top of stack
            stackArray[++top] = new StackPart(x, y, dir);
        }
        public StackPart pop()         // take item from top of stack
        { return stackArray[top--]; }
        public StackPart peek()        // peek at top of stack
        { return stackArray[top]; }
        public bool isEmpty()  // true if stack is empty
        { return (top == -1); }
        public int size()         // return size
        { return top + 1; }
        public StackPart peekN(int n)  // return item at index n
        { return stackArray[n]; }

        public void displayStack() {
            Console.Out.WriteLine("---------STACK----------");
            for (int j = 0; j < size(); j++) {
                Console.Out.WriteLine("x(" + peekN(j).getX() + ") y(" + peekN(j).getY() + ") dir: " + peekN(j).getDir());
            }
            Console.Out.WriteLine("--------/STACK----------");
        }
    }
}
