using BarleyBreak.Data.GameElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreak.Data
{
    public class Game
    {
        public Area GameArea;

        protected Game(int n)
        { }

        public Game(int[] n)
        {
            GameArea = new Area(n);
        }

        public Tag GetLocation(int value)
        {
            for (int i = 0; i < GameArea.LengthArea; i++)
            {
                for (int j = 0; j < GameArea.LengthArea; j++)
                {
                    if (value == GameArea[i, j])
                    {
                        return new Tag(i, j, value);
                    }
                }
            }
            return null;
        }

        protected int GetValueArea(int x, int y)
        {
            return GameArea[x, y];
        }

        public virtual void Shift(int value)
        {
            var coordinates = GetLocation(0);
            var valueLocation = GetLocation(value);
            var valuenull = GetValueArea(coordinates.X,coordinates.Y);
            ChangePositionOnArea(GameArea, valueLocation, value, coordinates, valuenull);
        }
        
        protected Area ChangePositionOnArea(Area Area, Tag valueLocation, int value, Tag coordinates,int valuenull)//change
        {
            try
            {
                if (Math.Abs(valueLocation.X - coordinates.X) + Math.Abs(valueLocation.Y - coordinates.Y) == 1)
                {
                    Area[coordinates.X, coordinates.Y] = value;
                    Area[valueLocation.X, valueLocation.Y] = valuenull;
                }

                else throw new ArgumentException("Error:There is no empty cell next to the variable!");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error:There is no empty field!");
            }
            return Area;
        }
    }
}