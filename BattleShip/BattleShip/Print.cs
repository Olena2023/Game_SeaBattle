using BaseShips;
using Coords;
using Shoots;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Prints
{
    class Print // класс малює наші поля праве і ліве
    {
        public void printLeftField(List<BaseShip> shipListPlayer)
        {
            
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    //start field
                    if (j == 0 && i == 0)
                    {
                        Console.Write("  ");
                    }
                    else if (i == 0 && j != 0)
                    {
                        Console.Write((j - 1) + "|");
                    }

                    else if (i != 0 && j == 0)
                    {
                        Console.Write((i - 1) + "|");
                    }//end field
                    else
                    {
                        bool flag = true;
                        foreach (BaseShip ship in shipListPlayer)
                        {
                            foreach (Coord coord in ship.getCoords())
                            {
                                if (coord.X == i - 1 && coord.Y == j - 1)
                                {
                                    Console.Write(ship.getId() + "|"); // малювання корабля 
                                    flag = false;
                                    break;
                                }
                            }
                            
                        }
                        if(flag)
                            Console.Write("  "); 
                    }  
                } 
                Console.WriteLine();
            }
        }

        public void printRightField(List<Shoot> shootListPlayer)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (j == 0 && i == 0)
                    {
                        Console.Write("  ");
                    }
                    else if (i == 0 && j != 0)
                    {
                        Console.Write((j - 1) + "|");
                    }

                    if (i != 0 && j == 0)
                    {
                        Console.Write((i - 1) + "|");
                    }

                    if (j != 0 && i != 0)
                    {
                        string symbol = "  ";
                        foreach (Shoot shoot in shootListPlayer)
                        {
                            if ((shoot.Coord.X == i - 1 && shoot.Coord.Y == j - 1))
                            {
                                if (shoot.IsHit == true)
                                    symbol = "*|"; //влучання
                                else
                                    symbol = "o|";
                            }
                     
                        }

                        Console.Write(symbol);
                    }
                    

                }

                Console.WriteLine();
            }

        }
    }
}
