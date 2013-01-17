using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr4 {
    class Program {
        static void Main(string[] args) {
            showHeader();
            //int value;
            //so much help http://scriptasylum.com/tutorials/infix_postfix/infix_postfix.html

            string postfix = "12345*+-^6+";
            Console.WriteLine(" String is: " + postfix+"\r\n");

            Tree tree = new Tree();
            tree.setPostfix(postfix);
            tree.buildTree();
            tree.print();
            Console.WriteLine("\r\n     End of transmission\r\n       ~~~ bzzzzt ~~~");
            char choice = getChar();
        }  // end main()
        // -------------------------------------------------------------
        public static String getString() {
            String s = Console.ReadLine();
            return s;
        }
        // -------------------------------------------------------------
        public static char getChar() {
            string s = getString();
            return s[0];
        }
        //-------------------------------------------------------------
        public static int getInt(){
            string s = getString();
            return Int32.Parse(s);
        }
        // -------------------------------------------------------------
        private static void showHeader() {
            Console.WriteLine("           _____   _____   _  _\r\n     /\\   |  __ \\ / ____| | || |\r\n    /  \\  | |  | | (___   | || |_\r\n   / /\\ \\ | |  | |\\___ \\  |__   _|\r\n  / ____ \\| |__| |____) |    | |\r\n /_/    \\_\\_____/|_____/     |_|\r\n~~~~~~~~~~~ Tim Kuperus ~~~~~~~~~~~\r\n");
        }
    }  // end class TreeApp

}
