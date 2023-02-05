using Engines;
using Shoots;
using System;

namespace BattleShip

{ 
    internal class Program
    { 
        static void Main(string[] args)
        { 
            Engine engine = new Engine();
           
            engine.generateAllShipFirstPlayer();
            engine.generateAllShipSecondPlayer();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Shoot X: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Shoot Y: ");
                int y = Convert.ToInt32(Console.ReadLine());


                engine.shootFirstPlayer(x, y);


                engine.printInterface();

                Console.WriteLine("1 - to continue");
                Console.ReadLine();
            }

           
            return;

        }
    }
}
