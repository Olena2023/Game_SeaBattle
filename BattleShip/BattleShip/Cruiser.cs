using BaseShips;
using System;
 
namespace Cruisers
{    public class Cruiser : BaseShip
    {
        public Cruiser(string Name) : base(Name)
        {
            shipType = " Cruiser";
            size = 2;
        }
        public override void showType()
        {
            Console.WriteLine(shipType);
        }
    }
}
