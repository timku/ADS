using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr5 {
    class Program {
        static void Main(string[] args) {
            showHeader();
            Console.WriteLine("\r\n");

            Knight knight = new Knight(5);
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
            Console.WriteLine("           _____   _____ _____\r\n     /\\   |  __ \\ / ____| ____|\r\n    /  \\  | |  | | (___ | |__\r\n   / /\\ \\ | |  | |\\___ \\|___ \\\r\n  / ____ \\| |__| |____) |___) |\r\n /_/    \\_\\_____/|_____/|____/\r\n~~~~~~~~~~~ Tim Kuperus ~~~~~~~~~~~");
        }
    }  // end class TreeApp

}
