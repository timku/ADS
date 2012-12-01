using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr4 {
    class Program {
        static void Main(string[] args) {
            //int value;
            //so much help http://scriptasylum.com/tutorials/infix_postfix/infix_postfix.html

            string postfix = "4123*+-2+";
            Console.WriteLine("String is: " + postfix+"\r\n");

            Tree tree = new Tree();
            tree.setPostfix(postfix);
            tree.buildTree();
            tree.print();

            /*theTree.insert(50, 1.5);
            theTree.insert(25, 1.2);
            theTree.insert(75, 1.7);
            theTree.insert(12, 1.5);
            theTree.insert(37, 1.2);
            theTree.insert(43, 1.7);
            theTree.insert(30, 1.5);
            theTree.insert(33, 1.2);
            theTree.insert(87, 1.7);
            theTree.insert(93, 1.5);
            theTree.insert(97, 1.5);
            while (true) {
                Console.Out.Write("Enter first letter of show, ");
                Console.Out.Write("insert, find, delete, or traverse: ");
                char choice = getChar();
                switch (choice) {
                    case 's':
                        theTree.displayTree();
                        break;
                    case 'i':
                        Console.Out.Write("Enter value to insert: ");
                        value = getInt();
                        theTree.insert(value, value + 0.9);
                        break;
                    case 'f':
                        Console.Out.Write("Enter value to find: ");
                        value = getInt();
                        Node found = theTree.find(value);
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
                        bool didDelete = theTree.delete(value);
                        if (didDelete)
                            Console.Out.Write("Deleted " + value + "\n");
                        else
                            Console.Out.Write("Could not delete ");
                        Console.Out.Write(value + "\n");
                        break;
                    case 't':
                        Console.Out.Write("Enter type 1, 2 or 3: ");
                        value = getInt();
                        theTree.traverse(value);
                        break;
                    default:
                        Console.Out.Write("Invalid entry\n");
                        break;
                }  // end switch
            }  // end while*/
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
    }  // end class TreeApp
}
