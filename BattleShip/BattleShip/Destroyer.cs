using BaseShips;
using System;
 
namespace Destroyers
{
    public class Destroyer : BaseShip
    {
        public Destroyer(string Name) : base(Name)
        {
            shipType = "Destroyer";
            size = 1;
        }
        public override void showType()
        {
            Console.WriteLine(shipType);
        }
    }
}
