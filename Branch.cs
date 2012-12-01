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
                output += rightChild.getInfixStr() + ")";
            }

            return output;
        }

        public String getPostfixStr() {
            String output = "";
            if (hasLeft()) {
                output += leftChild.getPostfixStr();
            }
            if (hasRight()) {
                output += rightChild.getPostfixStr();
            }
            return output+data;
        }

        public String getPrefixStr() {
            String output = data+"";
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
