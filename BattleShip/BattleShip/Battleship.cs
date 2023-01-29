using BaseShips;
using System;
 

namespace BattleShip
{
    public class Battleship : BaseShip
    {
        public Battleship(string Name) : base(Name)
        {
            shipType = "Battleship";
            size = 3;
        }
        public override void showType()
        {
            Console.WriteLine(shipType);
        }
    }
}
