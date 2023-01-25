using Coords;
using System;
 

namespace Shoots
{
   
        class Shoot // клас Постріл
        {
            private Coord coord;
            private bool isHit; //результат пострілу

            public Shoot(Coord coord, bool isHit)
            {
                this.coord = coord;
                this.isHit = isHit;
            }

            public Coord Coord { get; }

            public bool IsHit { get; }
        }
    }
