using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptor
{
    class Item
    {
        public float[] coords;
        public int state;

        public Item(float[] inCoords)
        {
            this.coords = inCoords;
            if (inCoords[0] > inCoords[1]) state = 1;
            else state = -1;
        }
    }
}
