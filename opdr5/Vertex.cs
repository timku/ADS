using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr5 {
    class Vertex {
        public char label;        // label (e.g. 'A')
        public bool wasVisited;
        // -------------------------------------------------------------
        public Vertex(char lab)   // constructor
           {
            label = lab;
            wasVisited = false;
        }
        // -------------------------------------------------------------
    }
}
