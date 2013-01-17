using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr5 {
    class Tree {
        private string postfix = "";
        private Branch trunk = null;
        /// <summary>
        /// Setting postfix string
        /// </summary>
        /// <param name="p">postfix</param>
        public void setPostfix(string p) {
            postfix = p;
        }
        /// <summary>
        /// Building a tree.
        /// </summary>
        public void buildTree() {
            if (postfix.Length < 1) { return; }
            Branch current = null;
            Stack stack = new Stack(postfix.Length);
            char ch;
            bool waitingForOperator = false;
            for (int i = 0; i < postfix.Length; i++) {
                ch = postfix[i];
                if (ch <= '9' && ch >= '0') {
                    stack.push(ch);
                } else if (ch == '+' || ch == '-' || ch == '/' || ch == '*' || ch == '^') {
                    if (current == null) {
                        //Construct the tree with ducktape, but im all out of tape.
                        char num2 = stack.pop();
                        char num1 = stack.pop();
                        current = new Branch(ch, new Branch(num1), new Branch(num2));
                    } else {
                        Branch previous = current;
                        current = new Branch(ch);
                        if (waitingForOperator == true) {
                            //yea we're basicly waiting for an operator...
                            current.setRight(previous);
                            current.setLeft(new Branch(stack.pop()));
                            waitingForOperator = false;// Or maybe not?
                        } else {
                            //this guy is so cool, he kicks ass without an operator...
                            current.setLeft(previous);
                            current.setRight(new Branch(stack.pop()));
                        }
                    }
                    if (stack.size() > 0) {
                        //yes we're waiting for an operator.
                        waitingForOperator = true;
                    }
                } else {
                    Console.WriteLine("Error char('" + ch + "') So wtf am I supposed to do with this?");
                }
            }
            trunk = current;//set dominant branch to root.
        }
        /// <summary>
        /// Print results
        /// </summary>
        public void print() {
            if (trunk == null) {
                Console.WriteLine("418 I am not a tree");
                return;
            }
            Console.WriteLine("   Infix: "+trunk.getInfixStr());
            Console.WriteLine(" Postfix: " + trunk.getPostfixStr());
            Console.WriteLine("  Prefix: " + trunk.getPrefixStr());
        }
    }
}
