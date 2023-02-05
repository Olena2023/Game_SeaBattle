using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coords;

namespace BaseShips
{
    abstract public class BaseShip
    {
        private static int autoInc = 0;
        private int id = 0;
        private string name;
        private List<Coord> listCoord;  //масив об'єктів класу Сооrd
        protected int size;
        protected string shipType;
        DateTime createdAd;
        public string Name { get; set; }

        private int generateId()
        {
            return autoInc++;
        }
        public BaseShip(string name)
        {
            createdAd = DateTime.Now;
            this.name = name;
            listCoord = new List<Coord>();
            this.id = this.generateId();
        }
        abstract public void showType();

        public int getId()
        {
            return this.id;
        }

        public BaseShip addCoord(Coord coord) //додає координату в масив корабля, ГЕНЕРАЦІЯ КОРАБЛЯ,задаємо координати корабля
        {
            this.listCoord.Add(coord);
            return this;
        }

        public BaseShip addCoords(List<Coord> list)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            this.listCoord.AddRange(list);
            return this;
        }

        public List<Coord> getCoords() //повертає масив координат в числовому значенні, отримуємо координати
        {
            return this.listCoord;
        }
        public bool hasHit(Coord coord)  //перевіряє чи є влучання
        {
            foreach (Coord item in this.listCoord)
            {
                if (item.X == coord.X && item.Y == coord.Y)
                {
                    return true; //влучили
                }
            }

            return false; // не влучили
        }

    }
}
