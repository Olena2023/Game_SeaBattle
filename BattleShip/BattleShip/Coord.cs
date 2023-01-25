using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coords 
{
    public class Coord
    {
        private int x = 0;
        private int y = 0;

        public int X { get { return this.x; } set { this.x = value; } }
        public int Y { get { return this.y; } set { this.y = value; } }

        public Coord() { }

        public Coord(int x, int y) //створює об'єкт з двома координатами
        {
            this.x = x;
            this.y = y;
        }
    }
}
