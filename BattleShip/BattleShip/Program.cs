using BaseShips;
using Coords;
using System;
using System.Collections.Generic;
using System.Linq;
using Shoots;
using Engines;
using Prints;
using Carriers;
using Cruisers;
using Destroyers;


namespace BattleShip

{ 
    internal class Program
    { 
        static void Main(string[] args)
        { 
            Engine engine = new Engine();
           
            engine.generateAllShipSecondPlayer();
            engine.generateAllShipFirstPlayer();

            engine.printInterface();

}
}
}
