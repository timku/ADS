using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS_pract1
{
    class ADS
    {
        private int x=0, y=0;
        public ADS()
        {
            //poep
        }
        public void obj(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return "x: "+this.x+" y: "+this.y+" ";
        }
        public bool areYouAt(int x, int y)
        {
            if (this.x == x && this.y == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
