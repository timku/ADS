using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr4 {
    class Tree_old {
        private Tree_old parent = null;
        private Tree_old childLeft = null;
        private Tree_old childRight = null;
        private string value = null;

        public void setValue(string value) {
            this.value = value;
        }
        public string getValue() {
            return this.value;
        }
        public void setParent(Tree_old parent) {
            this.parent = parent;
        }
        public Tree_old getParent() {
            return this.parent;
        }
        public void SetChildLeft(Tree_old childLeft) {
            this.childLeft = childLeft;
        }
        public Tree_old getChildLeft() {
            return this.childLeft;
        }
        public void SetChildRight(Tree_old childRight) {
            this.childRight = childRight;
        }
        public Tree_old getChildRight() {
            return this.childRight;
        }
    }
}
