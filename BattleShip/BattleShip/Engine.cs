using BaseShips;
using BattleShip;
using Coords;
using Shoots;
using System;
using System.Collections.Generic;
using Prints; 
using Destroyers;
using Carriers;
using Cruisers;



namespace Engines
{
    class Engine
    {
        public enum Direction  
        {
            North = 0,
            West,
            South,
            East
        }

        private List<BaseShip> shipListFirstPlayer; // Данні першого гравця
        private List<Shoot> shootListFirstPlayer;   // Данні першого гравця

        private List<BaseShip> shipListSecondPlayer; // Данні другого гравця
        private List<Shoot> shootListSecondPlayer;   // Данні другого гравця

        private Print print;
        private Random random;
        public Engine()
        {
            this.shipListFirstPlayer = new List<BaseShip>();
            this.shootListFirstPlayer = new List<Shoot>();
            this.shipListSecondPlayer = new List<BaseShip>();
            this.shootListSecondPlayer = new List<Shoot>();
            print = new Print();
            random = new Random(); 
        }
     
        private Coord createCoord(Direction direction, Coord firstCoord)
        {
           switch (direction)
            {
                case Direction.North:
                    {
                        firstCoord = new Coord(firstCoord.X--, firstCoord.Y);
                    }
                    break;
                case Direction.West:
                    {
                        firstCoord = new Coord(firstCoord.X, firstCoord.Y++); 
                    }
                    break;
                case Direction.South:
                    {
                        firstCoord = new Coord(firstCoord.X++, firstCoord.Y); 
                    }
                    break;
                case Direction.East:
                    {
                        firstCoord = new Coord(firstCoord.X, firstCoord.Y--); 
                    }
                    break;

            }
            return firstCoord;
        }
        /*private bool checkCoord(Coord shipCoord, Coord createCoord)
      {

      }*/
        private bool checkShipPosition(Coord firstCoord, int shipType, Direction direction, List<BaseShip> list)
        {
           if (shipType == 1) // алгоритм тільки для однопалубних  кораблів
            {
                foreach (BaseShip item in list)
                {
                    foreach (Coord coord in item.getCoords())
                    {
                        if (coord.X == firstCoord.X && coord.Y == firstCoord.Y)
                        {
                            return false;
                        }
                    }
                }
            }  
           else
            { 
                for (int i = 0; i < shipType; i++)
                {
                    if (i !=0) 
                    { firstCoord=this.createCoord(direction, firstCoord); }
                    foreach (BaseShip item in list)
                    {
                        foreach (Coord coord in item.getCoords())
                        {
                            if (coord.X == firstCoord.X && coord.Y == firstCoord.Y || firstCoord.Y < 0||
                                 firstCoord.Y > 9 || firstCoord.X < 0 || firstCoord.X > 9 ) 
                            {
                                return false;
                            } 
                        }
                    }
                }
            } 
            return true; 
        }
      
        private void generateShipFirstPlayer(string name, int size)
        {
            BaseShip baseShip = null; 
            bool isEmpty = true;
            Direction dir = (Direction)random.Next(0, 4);
            do
            {
                Coord firstCoord = new Coord(this.random.Next(0, 10), this.random.Next(0, 10)); 
                isEmpty = checkShipPosition(firstCoord, size, dir, shipListFirstPlayer); 
                if (isEmpty) 
                {
                    switch (size)
                    {
                        case 1:
                            {
                                baseShip = new Destroyer(name); 
                                this.addShipFirstPlayer(firstCoord, size, dir, baseShip);                       
                            }
                            break;
                        case 2:
                            {
                                baseShip = new Cruiser(name);
                                this.addShipFirstPlayer(firstCoord, size, dir, baseShip);                               
                            }
                            break;
                        case 3:
                            {
                                baseShip = new Battleship(name);
                                this.addShipFirstPlayer(firstCoord, size, dir, baseShip);                              
                            }
                            break;
                        case 4:
                            {
                                baseShip = new Carrier(name);
                                this.addShipFirstPlayer(firstCoord, size, dir, baseShip);                                                                                     
                            }
                            break; 
                        default: break;
                    }
                }
            }
            while (!isEmpty); // якщо координати зайнята ідемо на нову ітерацію 
        }
        private void generateShipSecondPlayer(string name, int size)
        {
            BaseShip baseShip = null; 
            bool isEmpty = true;
            Direction dir = (Direction)random.Next(0, 4);
            do
            { 
                Coord firstCoord = new Coord(this.random.Next(0, 10), this.random.Next(0, 10));  
                isEmpty = checkShipPosition(firstCoord, size, dir, shipListSecondPlayer);   

                if (isEmpty) 
                {
                    switch (size)
                    {
                        case 1:
                            {
                                baseShip = new Destroyer(name);
                                this.addShipSecondPlayer(firstCoord, size, dir, baseShip);
                            }
                            break;
                        case 2:
                            {
                                baseShip = new Cruiser(name);
                                this.addShipSecondPlayer(firstCoord, size, dir, baseShip);
                            }
                            break;
                        case 3:
                            {
                                baseShip = new Battleship(name);
                                this.addShipSecondPlayer(firstCoord, size, dir, baseShip);
                            }
                            break;
                        case 4:
                            {
                                baseShip = new Carrier(name);
                                this. addShipSecondPlayer(firstCoord, size, dir, baseShip);
                            }
                            break; 
                        default: break;
                    }
                }
            }
            while (!isEmpty); // якщо координати зайнята ідемо на нову ітерацію 
        }
        private void addShipFirstPlayer(Coord firstCoord, int size, Direction direction, BaseShip baseShip)
        {
            for (int i = 0; i < size; i++)
            {
                if (i !=0)
                { firstCoord = this.createCoord(direction, firstCoord); }
                baseShip.addCoords(firstCoord);
            }
            this.shipListFirstPlayer.Add(baseShip);
        }
        private void addShipSecondPlayer(Coord firstCoord, int size, Direction direction, BaseShip baseShip)
        {
            for (int i = 0; i < size; i++)
            {
                if (i != 0)
                { firstCoord = this.createCoord(direction, firstCoord); }
                baseShip.addCoords(firstCoord);
            }
            this.shipListSecondPlayer.Add(baseShip);
        }
        public void addShootFirstPlayer(Shoot shoot)  //додавання об'єктів в масив
        {
            this.shootListFirstPlayer.Add(shoot);
        }
        public void addShootSecondPlayer(Shoot shoot)  
        {
            this.shootListSecondPlayer.Add(shoot);
        }
        public void printInterface() // обгортка для малювання інтерфейсу
        {
            this.print.printLeftField(this.shipListFirstPlayer);
            this.print.printRightField(this.shootListFirstPlayer);
        }
        public void generateAllShipFirstPlayer()
        {
            this.generateShipFirstPlayer("frog", 1);
            this.generateShipFirstPlayer("tyv", 1);
            this.generateShipFirstPlayer("bff", 1);
            this.generateShipFirstPlayer("dcf", 1);
            this.generateShipFirstPlayer("djh", 2);
            this.generateShipFirstPlayer("dwy", 2);
            this.generateShipFirstPlayer("sfs", 2);
            this.generateShipFirstPlayer("dgw", 3); 
            this.generateShipFirstPlayer("ceq", 3);
            this.generateShipFirstPlayer("sws", 4);  

        }
        public void generateAllShipSecondPlayer()
        {
            this.generateShipSecondPlayer("dfg", 1);
            this.generateShipSecondPlayer("sny", 1);
            this.generateShipSecondPlayer("bff", 1);
            this.generateShipSecondPlayer("qgf", 1);
            this.generateShipSecondPlayer("djh", 2);
            this.generateShipSecondPlayer("fwy", 2);
            this.generateShipSecondPlayer("cfs", 2);
            this.generateShipSecondPlayer("dgw", 3);
            this.generateShipSecondPlayer("ces", 3);
            this.generateShipSecondPlayer("krj", 4);

        }

    }
}
  