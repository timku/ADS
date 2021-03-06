﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr5 {

    /*enum Movez {
        Noordnoordoost, Oostnoordoost, Oostzuidoost, Zuidzuidoost, Zuidzuidwest, Westzuidwest, Westnoordwest, Noordnoordwest
    };*/


    class Knight {
        private int[] moves = { 0, 1, 2, 3, 4, 5, 6, 7 };
        private Board board;
        private int knightx = 0, knighty = 0;
        private ulong moveNumber = 0;
        private Stack stack;

        public Knight(int size) {
            board = new Board(size);
            stack = new Stack(size * size);
            knightx = 0; knighty = 0;
            Console.WriteLine("Start pos(x: " + knightx + " y: " + knighty + ")");
            setKnightPos(knightx, knighty, 1);
            ulong foundPaths = 0;
            DateTime start = DateTime.Now;
            while (stack.isEmpty() == false) {
                if (stack.size() == (size * size)) {
                    foundPaths++;
                    if (foundPaths == 1){
                        board.display();
                        Console.Write("\r\n");
                    }else{
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.Write("Found paths: " + foundPaths + "\r\n");
                    }
                }
                if (findMove() == false) {
                    //do a step back, but remember that you have been here.
                    stepBack();
                }
            }
            DateTime end = DateTime.Now;
            TimeSpan duration = end - start;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine(String.Format("{0,15}{1,-15}",    "Time: ", duration.Milliseconds.ToString() + "ms"));
            Console.WriteLine(String.Format("{0,15}{1,-15:N0}", "Paths: ", foundPaths));
            Console.WriteLine(String.Format("{0,15}{1,-15:N0}", "Movements: ", moveNumber));
        }
        private int searchfrom = -1;
        private bool findMove() {
            foreach(int move in moves) {
                if (searchfrom == -1) {
                    //Console.WriteLine("Search from: " + fromMove + " curr: "+move);
                    if (tryMove(move) == 0) {
                        //justdoit.
                        setMove(move);
                        return true;
                    }
                }
                if (move == searchfrom) {
                    searchfrom = -1;
                }
            }
            //Console.WriteLine("ERROR 404: NO MOVES FOUND (" + moveNumber + ")");
            //stack.display();
            return false;
        }
        private void stepBack() {
            board.set(knightx, knighty, 0);
            StackPart stackpart = stack.pop();
            /*if (knightx == stackpart.getX() && knighty == stackpart.getY()) {
                Console.WriteLine("ERROR: STEPBACK DIDN'T WORK!");//end
            }*/
            knightx = stackpart.getX();
            knighty = stackpart.getY();
            searchfrom = stackpart.getDir();//next move.
            //Console.WriteLine("Search from: (" + searchfrom + ") "+ stack.size());
        }
        public void setKnightPos(int x, int y,int fromDirection) {
            stack.push(knightx, knighty, fromDirection);
            knightx = x;
            knighty = y;
            moveNumber++;
            //board.set(knightx, knighty, 8);
            //board.display();
            board.set(knightx, knighty, stack.size());
            //Console.WriteLine("setMove" + String.Format("{0,4}", moveNumber) + ": " + fromDirection);
        }

        private void setMove(int direction) {
            doMove(direction, false);
        }
        private int tryMove(int direction) {
            //Console.WriteLine("try: "+direction);
            return doMove(direction, true);
        }

        private int doMove(int direction, bool peek) {
            // nnw nno noo zoo zzo zzw zww nww
            // -1 not possible, 0 possible, 0< done it
            int x, y;
            switch (direction) {
                case 0://Move.Noordnoordoost://0
                    x = knightx + 1; y = knighty - 2;
                    break;
                case 1://Move.Oostnoordoost://1
                    x = knightx + 2; y = knighty - 1;
                    break;
                case 2://Move.Oostzuidoost://2
                    x = knightx + 2; y = knighty + 1;
                    break;
                case 3://Move.Zuidzuidoost://3
                    x = knightx + 1; y = knighty + 2;
                    break;
                case 4://Move.Zuidzuidwest://4
                    x = knightx - 1; y = knighty + 2;
                    break;
                case 5://Move.Westzuidwest://5
                    x = knightx - 2; y = knighty + 1;
                    break;
                case 6://Move.Westnoordwest://6
                    x = knightx - 2; y = knighty - 1;
                    break;
                case 7://Move.Noordnoordwest://7
                    x = knightx - 1; y = knighty - 2;
                    break;
                default:
                    Console.WriteLine("MOVE ERROR: " + direction);
                    return 0;//exit function
            }
            if (peek == true) {
                return board.get(x, y);
            } else {
                setKnightPos(x, y, direction);
            }
            return 0;
        }

        /// <summary>
        /// Print results
        /// </summary>
        public void print() {
            //if (trunk == null) {
            //   Console.WriteLine("418 I am not a tree");
            //     return;
            // }
            //Console.WriteLine("   Infix: "+trunk.getInfixStr());
            //Console.WriteLine(" Postfix: " + trunk.getPostfixStr());
            //Console.WriteLine("  Prefix: " + trunk.getPrefixStr());
        }
    }
}
