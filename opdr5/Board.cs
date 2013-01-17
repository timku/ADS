using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr5 {
    class Board {
        private int maxSize;
        private int[,] stackArray;
        private int top;
        public Board(int s)       // constructor
        {
            maxSize = s;
            stackArray = new int[maxSize, maxSize];
            top = -1;
        }
        public void set(int posx, int posy, int j)  // put item on top of stack
        {
            stackArray[posx, posy] = j;
        }
        public int get(int posx, int posy){         // take item from top of stack
            if (posx < 0 || posx > maxSize - 1 || posy < 0 || posy > maxSize - 1) {
                return -1;//outside of board
            }
            return stackArray[posx, posy];
        }
        public bool isEmpty()  // true if stack is empty
        { return (top == -1); }
        public int size()         // return size
        { return top + 1; }

        public void displayBoard() {
            Console.Out.Write("");
            for (int y = 0; y < maxSize; y++) {
                for (int x = 0; x < maxSize; x++) {
                    //Console.Out.Write(peekN(j));
                    Console.Out.Write(String.Format("{0,5}", get(x,y)));
                }
                Console.Out.WriteLine("");
            }
            Console.Out.WriteLine("");
        }
    }
}
