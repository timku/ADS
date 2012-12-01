using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr4 {
    class Branch {
        public char data;

        public Branch parent = null;
        public Branch leftChild = null;         // this node’s left child
        public Branch rightChild = null;        // this node’s right child

        public Branch() {
        }
        public Branch(char c) {
            this.setData(c);
        }
        public Branch(char c, Branch lc, Branch rc) {
            if (lc == null || rc == null) {
                Console.WriteLine("OK WAT");
                return;
            }
            this.setData(c);
            setLeft(lc);
            setRight(rc);
            lc.setParent(this);
            rc.setParent(this);

        }
        /*
        public Branch(Branch p) {
            setParent(p);
        }
        public Branch(Branch lc,Branch rc) {
            lc.setParent(this);
            rc.setParent(this);
            setLeftChild(lc);
            setRightChild(rc);
        }
        public Branch(Branch p, Branch lc, Branch rc) {
            setParent(p);
            setLeftChild(lc);
            setRightChild(rc);
            lc.setParent(this);
            rc.setParent(this);
        }*/
        public void setData(char c) {
            this.data = c;
        }
        public void setParent(Branch p) {
            this.parent = p;
        }
        public void setLeft(Branch lc) {
            this.leftChild = lc;
        }
        public void setRight(Branch rc) {
            this.rightChild = rc;
        }
        private bool hasRight() {
            if (this.rightChild == null) {
                return false;
            } else {
                return true;
            }
        }

        private bool hasLeft() {
            if (this.leftChild == null) {
                return false;
            } else {
                return true;
            }
        }


        public String getInfixStr() {
            String output = "";

            if (hasLeft()) {
                output += "(" + leftChild.getInfixStr();
            }
            output += data;
            if (hasRight()) {
                String temp = rightChild.getInfixStr();
                output += temp+")";
            }

            return output;
        }

        public String getPostfixStr() {
            String output = "";

            if (hasLeft()) {
                String temp = leftChild.getPostfixStr();
                output += temp + "";
            }
            if (hasRight()) {
                String temp = rightChild.getPostfixStr();
                output += temp + "";
            }

            output += data;
            return output;
        }

        public String getPrefixStr() {
            String output = "";
            output += data + "";
            if (hasLeft()) {
                output += leftChild.getPrefixStr();
            }
            if (hasRight()) {
                output += rightChild.getPrefixStr();
            }

            return output;
        }
    }
}
