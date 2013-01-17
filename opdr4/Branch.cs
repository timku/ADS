using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr5 {
    class Branch {
        private char data;
        private Branch parent = null;
        private Branch leftChild = null;
        private Branch rightChild = null;

        public Branch() {
        }
        public Branch(char c) {
            this.setData(c);
        }
        public Branch(char c, Branch lc, Branch rc) {
            if (lc == null || rc == null) {
                Console.WriteLine("WAT");
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

        /// <summary>
        /// Has a right child?
        /// </summary>
        /// <returns>true = yes I have a right child</returns>
        private bool hasRight() {
            if (this.rightChild == null) {
                return false;
            } else {
                return true;
            }
        }
        /// <summary>
        /// Has a left child?
        /// </summary>
        /// <returns>true = yes I have a left child</returns>
        private bool hasLeft() {
            if (this.leftChild == null) {
                return false;
            } else {
                return true;
            }
        }

        public String getInfixStr() {
            String str = "";
            if (hasLeft()) {
                str += "(" + leftChild.getInfixStr();
            }
            str += data;
            if (hasRight()) {
                str += rightChild.getInfixStr() + ")";
            }

            return str;
        }

        public String getPostfixStr() {
            String str = "";
            if (hasLeft()) {
                str += leftChild.getPostfixStr();
            }
            if (hasRight()) {
                str += rightChild.getPostfixStr();
            }
            return str + data;
            //return str+" "+data; (w/ spaces)
        }

        public String getPrefixStr() {
            String str = "";
            if (hasLeft()) {
                str += leftChild.getPrefixStr();
            }
            if (hasRight()) {
                str += rightChild.getPrefixStr();
            }
            return data + str;
            //return data+" "+str;  (w/ spaces)
        }
    }
}
