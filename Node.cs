using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr4 {
    class Node {
        public int iData;              // data item (key)
        public double dData;           // data item
        public Node leftChild;         // this node’s left child
        public Node rightChild;        // this node’s right child
        public void displayNode()      // display ourself
        {
            Console.Out.Write("{");
            Console.Out.Write(iData);
            Console.Out.Write(", ");
            Console.Out.Write(dData);
            Console.Out.Write("} ");
        }
    }  // end class Node
}
