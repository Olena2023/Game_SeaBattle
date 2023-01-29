using BaseShips;
using System;
 

namespace Carriers
{
    public class Carrier : BaseShip
    {
        public Carrier(string Name) : base(Name)
        {
            shipType = "Carrier";
            size = 4;
        }
        public override void showType()
        {
            Console.WriteLine(shipType);
        }
    }
}
