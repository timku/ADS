using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr4 {
    class Tree {
        private string postfix = "";
        public void setPostfix(string p) {
            postfix = p;
        }
        public Branch root = null;
        public void buildTree() {
            Branch current = null;
            Stack stack = new Stack(20);
            char ch;
            char num1, num2;
            bool waitingForOperator = false;
            for (int i = 0; i < postfix.Length; i++) {
                ch = postfix[i];
                if (ch <= '9' && ch >= '0') {
                    stack.push(ch);
                } else if (ch == '+' || ch == '-' || ch == '/' || ch == '*' || ch == '^') {
                    if (current == null) {
                        //Construct the tree with ducktape, but im all out of tape.
                        num2 = stack.pop();
                        num1 = stack.pop();
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
            root = current;//set dominant branch to root.
        }

        public void print() {
            Console.WriteLine("   infix: "+root.getInfixStr());
            Console.WriteLine(" postfix: " + root.getPostfixStr());
            Console.WriteLine("  prefix: " + root.getPrefixStr());
        }
    }
}
