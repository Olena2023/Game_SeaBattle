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
using System.Linq;
using System.Net;

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

        private Coord createCoord(Direction direction, int x, int y)
        {
            switch (direction)
            {
                case Direction.North:
                    {
                        x--;
                    }
                    break;
                case Direction.West:
                    {
                        y++;
                    }
                    break;
                case Direction.South:
                    {
                        x++;
                    }
                    break;
                case Direction.East:
                    {
                        y--;
                    }
                    break;

            }

            return new Coord(x, y);
        }

        private List<Coord> generateCoordShip(Coord firstCoord, int shipType, Direction direction)
        {
            List<Coord> tmpList = new List<Coord>();

            Coord tmp = firstCoord;
            tmpList.Add(tmp);

            if (shipType > 1)
            {
                for (int i = 0; i < shipType - 1; i++)
                {
                    tmp = this.createCoord(direction, tmp.X, tmp.Y);
                    tmpList.Add(tmp);
                }
            }

            return tmpList;
        }

        private bool checkArea(Coord coord, List<BaseShip> listShip)
        {
            List<Coord> tmp = new List<Coord>();
            int x = coord.X;
            int y = coord.Y;

            tmp.Add(new Coord(x - 1, y - 1));
            tmp.Add(new Coord(x - 1, y));
            tmp.Add(new Coord(x - 1, y + 1));

            tmp.Add(new Coord(x, y - 1));
            tmp.Add(new Coord(x, y + 1));

            tmp.Add(new Coord(x + 1, y - 1));
            tmp.Add(new Coord(x + 1, y));
            tmp.Add(new Coord(x + 1, y + 1));

            for (int i = 0; i < tmp.Count; i++)
            {
                for (int j = 0; j < listShip.Count; j++)
                {
                    for (int k = 0; k < listShip[j].getCoords().Count; k++)
                    {
                        if ((tmp[i].X == listShip[j].getCoords()[k].X && tmp[i].Y == listShip[j].getCoords()[k].Y))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private bool checkShipPosition(List<Coord> coords, List<BaseShip> listShip)
        {
            //Координати які перевіряємо
            for (int i = 0; i < coords.Count; i++)
            {
                for (int j = 0; j < listShip.Count; j++)
                {
                    for (int k = 0; k < listShip[j].getCoords().Count; k++)
                    {
                        if ((coords[i].X == listShip[j].getCoords()[k].X && coords[i].Y == listShip[j].getCoords()[k].Y))
                        {
                            return false;
                        }
                    }
                }

                return checkArea(coords[i], listShip);
            }

            return true;
            /*if (shipType == 1) // алгоритм тільки для однопалубних  кораблів
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

                 foreach (Coord tmpCoord in this.generateCoordShip(firstCoord, shipType, direction))
                 //foreach (Coord tmpCoord in this.generateCoordShip(new Coord(9, 8), 4, direction))
                 {
                     if (list.Count != 0)
                     {
                         foreach (BaseShip item in list)
                         {
                             foreach (Coord coord in item.getCoords())
                             {
                                 if ((coord.X == tmpCoord.X && coord.Y == tmpCoord.Y) || tmpCoord.Y < 0 || tmpCoord.Y > 9 || tmpCoord.X < 0 || tmpCoord.X > 9)
                                     return false;
                             }
                         }
                     } else
                     {
                         if (tmpCoord.Y < 0 || tmpCoord.Y > 9 || tmpCoord.X < 0 || tmpCoord.X > 9)
                             return false;
                     }
                 }

             }
             return true; */
        }

        public void generateShips(string[] nameList, List<BaseShip> list)
        {
            int[] types = { 1, 1, 1, 1, 2, 2, 2, 3, 3, 4 };

            foreach (var size in types)
            {
                list.Add(generateShipPlayer(nameList[random.Next(0, nameList.Length)], size));
            }
        }

        private List<Coord> generateCoord(int size, Direction dir)
        {
            bool flag = true;
            int x = 0, y = 0;
            int statX = 0, statY = 0;   
            List<Coord> list = new List<Coord>();

            do
            {
                flag = true;
                statX = x = this.random.Next(0, 10);
                statY = y = this.random.Next(0, 10);

                switch (dir)
                {
                    case Direction.North:
                        x -= (size - 1);
                        break;
                    case Direction.West:
                        y += (size - 1);
                        break;
                    case Direction.South:
                        x += (size - 1);
                        break;
                    case Direction.East:
                        y -= (size - 1);
                        break;
                }

                if (y < 0 || y > 9 || x < 0 || x > 9)
                    flag =  false;
               
            } while (!flag);

            list.Add(new Coord(statX, statY));

            for (int i = 0; i < size - 1; i++)
            {
                list.Add(createCoord(dir, list.Last().X, list.Last().Y));
            }
            
            return list;
        }

        private BaseShip generateShipPlayer(string name, int size)
        {
            BaseShip baseShip = null;
            bool isEmpty = true;
            Direction dir = (Direction)random.Next(0, 4);
            do
            {
                List<Coord> coords = generateCoord(size, dir);
                //List<Coord> firstCoord = new List<Coord> { new Coord(1, 2), new Coord(1, 3) };

                isEmpty = checkShipPosition(coords, shipListFirstPlayer);


                if (isEmpty)
                {
                    baseShip = createCapitalShip(coords, size, name);
                }
            }
            while (!isEmpty); // якщо координати зайнята ідемо на нову ітерацію 

            return baseShip;
        }

        private BaseShip createCapitalShip(List<Coord> list, int size, string name)
        {
            BaseShip obj = null;

            if (size == 2)
                obj = new Cruiser(name);
            else if (size == 3)
                obj = new Battleship(name);
            else if (size == 4)
                obj = new Carrier(name);
            else
                obj = new Destroyer(name);

            obj.Name = name;
            obj.addCoords(list);

            return obj;
        }
        public void printInterface() // обгортка для малювання інтерфейсу
        {
            this.print.printLeftField(this.shipListFirstPlayer);
            this.print.printRightField(this.shootListFirstPlayer);

            return;
        }
        public void generateAllShipFirstPlayer()
        {
            string[] names = { "Hood", "Majestick", "Von der Tann"};
            this.generateShips(names, shipListFirstPlayer);
           
        }
        public void generateAllShipSecondPlayer()
        {
            string[] names = { "Hood", "Majestick", "Von der Tann" };
            this.generateShips(names, shipListSecondPlayer);
        }

        private bool checkHit(Coord coord, List<BaseShip> list)
        {
            foreach (var ship in list)
            {
                return ship.hasHit(coord);
            }

            return false;
        }

        public void shootFirstPlayer(int x, int y)
        {
            this.shoot(x, y, this.shipListSecondPlayer, this.shootListFirstPlayer);
        }

        public void shootSecondPlayer(int x, int y)
        {
            this.shoot(x, y, this.shipListFirstPlayer, this.shootListSecondPlayer);
        }

        private void shoot(int x, int y, List<BaseShip> list, List<Shoot> shoots)
        {
            Coord coord = new Coord(x, y);

            shoots.Add(new Shoot(coord, checkHit(coord, list)));
        }
    }
}
  