using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ADSopdr6 {
    class Program {
        static void Main(string[] args) {
            showHeader();
            string example = "+31365333666";
            string regex = @"(\+31|0031)([1-57-9][0-9]-?[1-9][0-9]{6}|6-?[1-9][0-9]{7}|[1-57-9]{2}[0-9]-?[1-9][0-9]{5})";
            Console.WriteLine("\r\n" + example + " = " + Regex.IsMatch(example, regex));
            while (true) {
                string input = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                Console.Write(input + " = " + Regex.IsMatch(input, regex) + "\r\n");
            }
            //Console.WriteLine("\r\n     End of transmission\r\n       ~~~ bzzzzt ~~~");
        }
        private static void showHeader() {
            Console.WriteLine("           _____   _____     __\r\n     /\\   |  __ \\ / ____|   / /\r\n    /  \\  | |  | | (___    / /_\r\n   / /\\ \\ | |  | |\\___ \\  | '_ \\\r\n  / ____ \\| |__| |____) | | (_) |\r\n /_/    \\_\\_____/|_____/   \\___/\r\n~~~~~~~~~~~ Tim Kuperus ~~~~~~~~~~~");
        }
    }

}
