using Coords;
using System;
 

namespace Shoots
{
   
        class Shoot // клас Постріл
        {
            private Coord coord;
            private bool isHit; //результат пострілу
            DateTime createdAd;
          public Shoot(Coord coord, bool isHit)
            {
                this.coord = coord;
                this.isHit = isHit;
                createdAd = DateTime.Now;
            }

            public Coord Coord { get; }

            public bool IsHit { get; }
        }
    }
