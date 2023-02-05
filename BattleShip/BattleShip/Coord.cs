using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coords 
{
    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coord() { }

        public Coord(int x, int y) //створює об'єкт з двома координатами
        {
            this.X = x;
            this.Y = y;
        }
    }
}
