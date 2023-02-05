using Coords;
using System;
 

namespace Shoots
{
   
        class Shoot // клас Постріл
        {
            public Coord Coord { get; set; }

            public bool IsHit { get; }
            DateTime createdAd;
            public Shoot(Coord coord, bool isHit)
            {
                this.Coord = coord;
                this.IsHit = isHit;
                createdAd = DateTime.Now;
            }


        }
    }
