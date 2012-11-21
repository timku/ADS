using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr4 {
    class Program {
        static void Main(string[] args) {
            int value;
            Tree tree = new Tree();
            tree.insert(50, 1.5);
            tree.insert(25, 1.2);
            tree.insert(75, 1.7);
            tree.insert(12, 1.5);
            tree.insert(37, 1.2);
            tree.insert(43, 1.7);
            tree.insert(30, 1.5);
            tree.insert(33, 1.2);
            tree.insert(87, 1.7);
            tree.insert(93, 1.5);
            tree.insert(97, 1.5);
            while (true) {
                Console.Out.Write("Enter first letter of show, ");
                Console.Out.Write("insert, find, delete, or traverse: ");
                char choice = getChar();
                switch (choice) {
                    case 's':
                        tree.displayTree();
                        break;
                    case 'i':
                        Console.Out.Write("Enter value to insert: ");
                        value = getInt();
                        tree.insert(value, value + 0.9);
                        break;
                    case 'f':
                        Console.Out.Write("Enter value to find: ");
                        value = getInt();
                        Node found = tree.find(value);
                        if (found != null) {
                            Console.Out.Write("Found: ");
                            found.displayNode();
                            Console.Out.Write("\n");
                        } else {
                            Console.Out.Write("Could not find ");
                        }
                        Console.Out.Write(value + "\n");
                        break;
                    case 'd':
                        Console.Out.Write("Enter value to delete: ");
                        value = getInt();
                        bool didDelete = tree.delete(value);
                        if (didDelete)
                            Console.Out.Write("Deleted " + value + "\n");
                        else
                            Console.Out.Write("Could not delete ");
                        Console.Out.Write(value + "\n");
                        break;
                    case 't':
                        Console.Out.Write("Enter type 1, 2 or 3: ");
                        value = getInt();
                        tree.traverse(value);
                        break;
                    default:
                        Console.Out.Write("Invalid entry\n");
                        break;
                }  // end switch
            }  // end while
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
            int x;
            try {
                x = Int32.Parse(s);
            } catch (FormatException e) {
                x = 0;
            }
            return x;
        }
        // -------------------------------------------------------------
    }  // end class TreeApp
}
